using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace CheckComboBox
{
    public class CheckedComboBox : ComboBox
    {
        protected override void OnClick(EventArgs e)
        {
            if (DroppedDown == false)
            {
                DroppedDown = true;
            }
            Enabled = false;
            Enabled = true;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 0x7)
            {
                base.WndProc(ref m);
            }
        }

        internal class Dropdown : Form
        {
            internal class CCBoxEventArgs : EventArgs
            {
                private bool assignValues;
                public bool AssignValues
                {
                    get { return assignValues; }
                    set { assignValues = value; }
                }
                private EventArgs e;
                public EventArgs EventArgs
                {
                    get { return e; }
                    set { e = value; }
                }
                public CCBoxEventArgs(EventArgs e, bool assignValues) : base()
                {
                    this.e = e;
                    this.assignValues = assignValues;
                }
            }

            internal class CustomCheckedListBox : CheckedListBox
            {
                private int curSelIndex = -1;

                public CustomCheckedListBox() : base()
                {
                    SelectionMode = SelectionMode.One;
                    HorizontalScrollbar = true;
                }

                protected override void OnKeyDown(KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        ((CheckedComboBox.Dropdown)Parent).OnDeactivate(new CCBoxEventArgs(null, true));
                        e.Handled = true;

                    }
                    else if (e.KeyCode == Keys.Escape)
                    {
                        ((CheckedComboBox.Dropdown)Parent).OnDeactivate(new CCBoxEventArgs(null, false));
                        e.Handled = true;

                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        for (int i = 0; i < Items.Count; i++)
                        {
                            SetItemChecked(i, e.Shift);
                        }
                        e.Handled = true;
                    }
                    base.OnKeyDown(e);
                }

                protected override void OnMouseMove(MouseEventArgs e)
                {
                    base.OnMouseMove(e);
                    int index = IndexFromPoint(e.Location);
                    Debug.WriteLine("Mouse over item: " + (index >= 0 ? GetItemText(Items[index]) : "None"));
                    if ((index >= 0) && (index != curSelIndex))
                    {
                        curSelIndex = index;
                        SetSelected(index, true);
                    }
                }

            }

            private CheckedComboBox ccbParent;
            private string oldStrValue = "";
            public bool ValueChanged
            {
                get
                {
                    string newStrValue = ccbParent.Text;
                    if ((oldStrValue.Length > 0) && (newStrValue.Length > 0))
                    {
                        return (oldStrValue.CompareTo(newStrValue) != 0);
                    }
                    else
                    {
                        return (oldStrValue.Length != newStrValue.Length);
                    }
                }
            }

            bool[] checkedStateArr;

            private bool dropdownClosed = true;

            private CustomCheckedListBox cclb;
            public CustomCheckedListBox List
            {
                get { return cclb; }
                set { cclb = value; }
            }

            public Dropdown(CheckedComboBox ccbParent)
            {
                this.ccbParent = ccbParent;
                InitializeComponent();
                ShowInTaskbar = false;
                // Add a handler to notify our parent of ItemCheck events.
                cclb.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(cclb_ItemCheck);
            }

            private void InitializeComponent()
            {
                cclb = new CustomCheckedListBox();
                SuspendLayout();
                cclb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                cclb.Dock = System.Windows.Forms.DockStyle.Fill;
                cclb.FormattingEnabled = true;
                cclb.Location = new System.Drawing.Point(0, 0);
                cclb.Name = "cclb";
                cclb.Size = new System.Drawing.Size(47, 15);
                cclb.TabIndex = 0;
                AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                BackColor = System.Drawing.SystemColors.Menu;
                ClientSize = new System.Drawing.Size(47, 16);
                ControlBox = false;
                Controls.Add(cclb);
                ForeColor = System.Drawing.SystemColors.ControlText;
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                MinimizeBox = false;
                Name = "ccbParent";
                StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                ResumeLayout(false);
            }

            public string GetCheckedItemsStringValue()
            {
                if (cclb.CheckedItems.Count == cclb.Items.Count || cclb.CheckedItems.Count == 0)
                {
                    return "Any";
                }
                else
                {
                    StringBuilder sb = new StringBuilder("");
                    for (int i = 0; i < cclb.CheckedItems.Count; i++)
                    {
                        sb.Append(cclb.GetItemText(cclb.CheckedItems[i])).Append(ccbParent.ValueSeparator);
                    }
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - ccbParent.ValueSeparator.Length, ccbParent.ValueSeparator.Length);
                    }
                    return sb.ToString();
                }
            }

            public void CloseDropdown(bool enactChanges)
            {
                if (dropdownClosed)
                {
                    return;
                }
                Debug.WriteLine("CloseDropdown");
                if (enactChanges)
                {
                    ccbParent.SelectedIndex = -1;
                    ccbParent.Text = GetCheckedItemsStringValue();
                }
                else
                {
                    for (int i = 0; i < cclb.Items.Count; i++)
                    {
                        cclb.SetItemChecked(i, checkedStateArr[i]);
                    }
                }
                Owner.TopMost = true;
                dropdownClosed = true;
                ccbParent.Focus();
                Hide();
                ccbParent.OnDropDownClosed(new CCBoxEventArgs(null, false));
                Owner.TopMost = false;
            }

            protected override void OnActivated(EventArgs e)
            {
                Debug.WriteLine("OnActivated");
                base.OnActivated(e);
                dropdownClosed = false;
                oldStrValue = ccbParent.Text;
                checkedStateArr = new bool[cclb.Items.Count];
                for (int i = 0; i < cclb.Items.Count; i++)
                {
                    checkedStateArr[i] = cclb.GetItemChecked(i);
                }
            }

            protected override void OnDeactivate(EventArgs e)
            {
                Debug.WriteLine("OnDeactivate");
                base.OnDeactivate(e);
                CCBoxEventArgs ce = e as CCBoxEventArgs;
                if (ce != null)
                {
                    CloseDropdown(ce.AssignValues);

                }
                else
                {
                    CloseDropdown(true);
                }
            }

            private void cclb_ItemCheck(object sender, ItemCheckEventArgs e)
            {
                if (ccbParent.ItemCheck != null)
                {
                    ccbParent.ItemCheck(sender, e);
                }
            }

        }

        private System.ComponentModel.IContainer components = null;
        private Dropdown dropdown;

        private string valueSeparator;
        public string ValueSeparator
        {
            get { return valueSeparator; }
            set { valueSeparator = value; }
        }

        public bool CheckOnClick
        {
            get { return dropdown.List.CheckOnClick; }
            set { dropdown.List.CheckOnClick = value; }
        }

        public new string DisplayMember
        {
            get { return dropdown.List.DisplayMember; }
            set { dropdown.List.DisplayMember = value; }
        }

        public new CheckedListBox.ObjectCollection Items
        {
            get { return dropdown.List.Items; }
        }

        public CheckedListBox.CheckedItemCollection CheckedItems
        {
            get { return dropdown.List.CheckedItems; }
        }

        public CheckedListBox.CheckedIndexCollection CheckedIndices
        {
            get { return dropdown.List.CheckedIndices; }
        }

        public bool ValueChanged
        {
            get { return dropdown.ValueChanged; }
        }

        public event ItemCheckEventHandler ItemCheck;

        // ******************************** Construction ********************************

        public CheckedComboBox() : base()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            valueSeparator = ", ";
            DropDownHeight = 1;
            DropDownStyle = ComboBoxStyle.DropDown;
            dropdown = new Dropdown(this);
            CheckOnClick = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnDropDown(EventArgs e)
        {
            base.OnDropDown(e);
            DoDropDown();
        }

        private void DoDropDown()
        {
            if (!dropdown.Visible)
            {
                Rectangle rect = RectangleToScreen(ClientRectangle);
                dropdown.Location = new Point(rect.X, rect.Y + Size.Height);
                int count = dropdown.List.Items.Count;
                if (count > MaxDropDownItems)
                {
                    count = MaxDropDownItems;
                }
                else if (count == 0)
                {
                    count = 1;
                }
                dropdown.Size = new Size(Size.Width, (dropdown.List.ItemHeight) * count + 2);
                dropdown.Show(this);
            }
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            if (e is Dropdown.CCBoxEventArgs)
            {
                base.OnDropDownClosed(e);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {             
                OnDropDown(null);
            }
            e.Handled = !e.Alt && !(e.KeyCode == Keys.Tab) &&
                !((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Home) || (e.KeyCode == Keys.End));

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            base.OnKeyPress(e);
        }

        public bool GetItemChecked(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("Index", "Value out of range");
            }
            else
            {
                return dropdown.List.GetItemChecked(index);
            }
        }

        public void SetItemChecked(int index, bool isChecked)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("Index", "Value out of range");
            }
            else
            {
                dropdown.List.SetItemChecked(index, isChecked);
                Text = dropdown.GetCheckedItemsStringValue();
            }
        }

        public CheckState GetItemCheckState(int index)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("Index", "Value out of range");
            }
            else
            {
                return dropdown.List.GetItemCheckState(index);
            }
        }

        public void SetItemCheckState(int index, CheckState state)
        {
            if (index < 0 || index > Items.Count)
            {
                throw new ArgumentOutOfRangeException("Index", "Value out of range");
            }
            else
            {
                dropdown.List.SetItemCheckState(index, state);
                Text = dropdown.GetCheckedItemsStringValue();
            }
        }

    }

}
public class CCBoxItem
{
    private int val;
    public int Value
    {
        get { return val; }
        set { val = value; }
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public CCBoxItem()
    {
    }

    public CCBoxItem(string name, int val)
    {
        this.name = name;
        this.val = val;
    }

    public override string ToString()
    {
        return string.Format(name);
    }
}