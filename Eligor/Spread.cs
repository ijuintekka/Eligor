using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Eligor
{

    public partial class Spread : Form
    {
        string[] character = { "Loves to eat.", "Takes plenty of siestas.", "Nods off a lot.", "Scatters things often.", "Likes to relax.", "Proud of its power.", "Likes to thrash about.", "A little quick tempered.", "Likes to fight.", "Quick tempered.", "Sturdy body.", "Capable of taking hits.", "Highly persistent.", "Good endurance.", "Good perseverance.", "Likes to run.", "Alert to sounds.", "Impetuous and silly.", "Somewhat of a clown.", "Quick to flee.", "Highly curious.", "Mischievous.", "Thoroughly cunning.", "Often lost in thought.", "Very finicky.", "Strong willed.", "Somewhat vain.", "Strongly defiant.", "Hates to lose.", "Somewhat stubborn." };
        string[] natures = { "Hardy", "Lonely", "Brave", "Adamant", "Naughty", "Bold", "Docile", "Relaxed", "Impish", "Lax", "Timid", "Hasty", "Serious", "Jolly", "Naive", "Modest", "Mild", "Quiet", "Bashful", "Rash", "Calm", "Gentle", "Sassy", "Careful", "Quirky" };
        string[] hpower = { "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel", "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon", "Dark" };
        public static uint[] selected_charas = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static uint[] selected_natures = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static uint[] selected_hips = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static uint[] pat_nature = { 255, 255, 255, 255, 255, 255 };
        public static string[] pat_sex = { "g", "g", "g", "g", "g", "g" };
        public static int[] pat_gender = { -1, -1, -1, -1, -1, -1 };
        public static uint defaultmaxseed = 4294967295;
        public static uint defaultresults = 4294967295;
        public static string patstring = "Eevee (XD)";
        public static uint tsiddefault = 4294967295;
        public static uint enableshinydefault = 0;
        public static uint forceshinydefault = 0;
        public static uint etidc = 4294967295;
        public static uint shinydefault = 255;
        public static int target_gender = 30;
        public static uint minsafeframes = 0;
        public static uint killthreads = 0;
        public static uint defaultseed = 0;
        public static uint threads = 2;
        public static uint output = 0;
        public static uint silent = 0;
        public static int patnum = 0;
        public static uint bar = 100;
        public static ulong maxseed;
        public static uint tid = 65536;
        public static uint sid = 65536;
        public static uint colomon;
        public static string date;
        public static uint minatk;
        public static uint maxatk;
        public static uint mindef;
        public static uint maxdef;
        public static uint minspa;
        public static uint maxspa;
        public static uint minspd;
        public static uint maxspd;
        public static uint minspe;
        public static uint maxspe;
        public static uint minhip;
        public static uint maxhip;
        public static uint summin;
        public static uint summax;
        public static uint minhp;
        public static uint maxhp;
        public static uint gs;
        uint results;
        uint writes;
        ulong step;

        public Spread( )
        {
            InitializeComponent();
        }

        private void ToGrid(string GSeed, string GPID, string GNature, string GGender, string GHP, string GAttack, string GDefense, string GSpAtk, string GSpDef, string GSpeed, string GHPT, string GHPS, string GChara, uint GPSV, string GIVSum, string GIVAverage, string GSafety, string GSChain, string GPChain)
        {
            lock (this)
            {
                string GPSV2;
                if (GPSV > 65535)
                {
                    GPSV2 = "N/A";
                }
                else
                {
                    GPSV2 = GPSV.ToString();
                }
                if (silent < 1)
                {
                    var line = string.Join("\t",
                    GSeed,
                    GPID,
                    String.Format("{0,-12}", GNature),
                    String.Format("{0,-15}", GGender),
                    String.Format("{0,2}", GHP),
                    String.Format("{0,2}", GAttack),
                    String.Format("{0,2}", GDefense),
                    String.Format("{0,2}", GSpAtk),
                    String.Format("{0,2}", GSpDef),
                    String.Format("{0,2}", GSpeed),
                    String.Format("{0,-12}", GHPT),
                    String.Format("{0,-2}", GHPS),
                    String.Format("{0,-4}", GPSV2),
                    String.Format("{0,-3}", GIVSum),
                    String.Format("{0,-2}", GIVAverage),
                    String.Format("{0,-29}", GChara),
                    GSChain,
                    GPChain,
                    GSafety,
                    "\r"
                    );
                    RichTextBox1.AppendText(line);
                    RichTextBox1.ScrollToCaret();
                }
                if (output > 0)
                {
                    var line = string.Join(";",
                    GSeed,
                    GPID,
                    GNature,
                    GGender,
                    GHP,
                    GAttack,
                    GDefense,
                    GSpAtk,
                    GSpDef,
                    GSpeed,
                    GHPT,
                    GHPS,
                    GPSV2,
                    GIVSum,
                    GIVAverage,
                    GChara,
                    GSChain,
                    GPChain,
                    GSafety
                    );
                    System.IO.File.AppendAllText("Results(" + patstring + ") " + date + ".csv", line + "\r");
                }
                writes++;
                if ((writes >= results) && (killthreads == 0))
                {
                    killthreads = 1;
                }
                Thread.Sleep(10);
            }
        }

        private void ProgBar()
        {
            lock (this)
            {
                if (ProgressBar1.Value < 99)
                {
                    ProgressBar1.PerformStep();
                }
            }
        }

        private ushort SplitRNG(uint tseed, uint frame)
        {
            uint i = 0;
            while (i < frame)
            {
                tseed = ((tseed * 0x000343fd) + 0x00269ec3) & 0xFFFFFFFF;
                i++;
            }
            return (ushort)(tseed >> 16);
        }

        private uint GetPID(uint tseed)
        {
            uint tpid;
            tpid = (uint)((SplitRNG(tseed, 4) << 16) + (SplitRNG(tseed, 5)));
            return tpid;
        }

        public void Main(uint mstep)
        {
            ulong tempseed = defaultseed + mstep - 1;
            ulong revs = tempseed;
            uint prog = 0;
            uint origseed;
            uint tpid;
            uint pid;
            uint ivs;
            uint shiny;
            uint enableshiny;
            uint forceshiny;
            uint patint;
            uint framehis;
            uint rollback = 0;
            uint eeveetid = 65536;
            uint eeveesid = 65536;
            string seedhistory;
            string pidhistory;
            string safety = "";
            uint tsid = tsiddefault;

            uint RNGAdv(uint frame, uint tseed)
            {
                uint i = 0;
                while (i < frame)
                {
                    tseed = (tseed * 0x000343fd) + 0x00269ec3; framehis++; i++;
                }
                return tseed;
            }

            void Roll()
            {
                while (!(((pat_sex[patint] == "m" && pid & 255 > pat_gender[patint]) || ((pat_sex[patint] == "f" || pat_sex[patint] == "g") && (pid & 255 <= pat_gender[patint]))) && ((pat_nature[patint] == pid % 25) || (pat_nature[patint] > 24))))
                {
                    tempseed = RNGAdv(2, (uint)(tempseed & 0xFFFFFFFF));
                    pid = GetPID((uint)(tempseed & 0xFFFFFFFF));
                }
            }

            void BeginHistory()
            {
                if (minsafeframes < 1)
                {
                seedhistory = "Seed Frame 1: " + (tempseed & 0xFFFFFFFF).ToString("X8") + " (PSV: " + ((pid >> 16 ^ pid & 0xFFFF) >> 3).ToString() + ")";
                pidhistory = "PID Frame 1: " + pid.ToString("X8") + " (PSV: " + ((pid >> 16 ^ pid & 0xFFFF) >> 3).ToString() + ")";
                }
                else
                {
                    seedhistory = "Seed Frame 1: " + (origseed).ToString("X8");
                    pidhistory = "PID Frame 1: N/A";
                    framehis = minsafeframes + framehis;
                    UpdateHistory();
                }
            }

            void UpdateHistory()
            {
                seedhistory = seedhistory + ";Seed Frame " + framehis.ToString() + ": " + (tempseed & 0xFFFFFFFF).ToString("X8") + " (PSV: " + ((pid >> 16 ^ pid & 0xFFFF) >> 3).ToString() + ")";
                pidhistory = pidhistory + ";PID Frame " + framehis.ToString() + ": " + pid.ToString("X8") + " (PSV: " + ((pid >> 16 ^ pid & 0xFFFF) >> 3).ToString() + ")";
            }

            void UpdateReRoll()
            {
                seedhistory = seedhistory + ";Seed Shiny ReRoll " + framehis.ToString() + ": " + (tempseed & 0xFFFFFFFF).ToString("X8") + " (PSV: " + ((pid >> 16 ^ pid & 0xFFFF) >> 3).ToString() + ")";
                pidhistory = pidhistory + ";PID Shiny ReRoll " + framehis.ToString() + ": " + pid.ToString("X8") + " (PSV: " + ((pid >> 16 ^ pid & 0xFFFF) >> 3).ToString() + ")";
            }

            void ShinyCheck()
            {
                if (tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3) && enableshiny == 1)
                {
                    shiny = patint;
                }
                if (shiny == patint)
                {
                    if (forceshiny == 1)
                    {
                        tsid = ((pid >> 16 ^ pid & 0xFFFF) >> 3);
                        enableshiny = 1;
                        forceshiny = 0;
                    }
                    while (tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3))
                    {
                         tempseed = RNGAdv(2, (uint)(tempseed & 0xFFFFFFFF));
                         pid = GetPID((uint)(tempseed & 0xFFFFFFFF));
                         Roll();
                    }
                    UpdateReRoll();
                }
            }



            void WriteOut()
            {
                uint bw = 0;

                if (colomon == 1 && enableshiny == 1 && (!((patstring == "Eevee (XD)") || (patstring == "Umbreon (Colosseum)") || (patstring == "Espeon (Colosseum)"))) && (!(tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3))))
                {
                    bw = 1;
                }

                //iva[0] hp
                //iva[1] atk
                //iva[2] def
                //iva[4] spa
                //iva[5] spd
                //iva[3] spe

                if (bw == 0)
                {
                    if (patnum > 0)
                    {
                        UpdateHistory();
                    }

                    if ((patstring == "Eevee (XD)") || (patstring == "Umbreon (Colosseum)") || (patstring == "Espeon (Colosseum)"))
                    {
                        uint e = 0;
                        eeveetid = origseed;
                        while (e < 3)
                        {
                            eeveetid = ((eeveetid * 0xb9b33155) + 0xa170f641) & 0xFFFFFFFF;
                            if (e == 1)
                            {
                                eeveesid = eeveetid >> 16;
                            }
                            if (e == 2)
                            {
                                eeveetid = eeveetid >> 16;
                                tsid = ((eeveetid ^ eeveesid) >> 3);
                            }
                            e++;
                        }
                        if ((patstring == "Umbreon (Colosseum)") || (patstring == "Espeon (Colosseum)"))
                        {
                            e = origseed;
                            while ((tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3)) || (pid & 255 < 31))
                            {
                                e = RNGAdv(2, e);
                                pid = GetPID(e);
                            }
                            if (patstring == "Espeon (Colosseum)")
                            {
                                e = RNGAdv(7, e);
                                tempseed = e; //Update seed to generate Espeon's IVs.
                                pid = GetPID(e);
                                while ((tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3)) || (pid & 255 < 31))
                                {
                                    e = RNGAdv(2, e);
                                    pid = GetPID(e);
                                }
                            }
                        }
                        if ( //Begin Failure Conditions
                        (enableshiny == 1 && (!(eeveesid == sid && eeveetid == tid))) ||
                        (etidc < 65536 && (!(etidc == eeveetid))) ||
                        ((patstring == "Eevee (XD)") && forceshiny == 1 && (!(tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3))))
                        ) //End Failure Conditions
                        {
                            bw = 1;
                        }
                        else
                        {
                            pidhistory = pidhistory + ";TID: " + eeveetid.ToString() + ";SID: " + eeveesid.ToString();
                        }
                    }
                    if (bw == 0)
                    {
                        ivs = (uint)((SplitRNG((uint)(tempseed & 0xFFFFFFFF), 1) << 16) + (SplitRNG((uint)(tempseed & 0xFFFFFFFF), 2)));
                        int[] iva = { (int)(ivs >> 16) & 31, (int)(ivs >> 21) & 31, (int)(ivs >> 26) & 31, (int)(ivs >> 0) & 31, (int)(ivs >> 5) & 31, (int)(ivs >> 10) & 31 };
                        int hit = (int)((((ivs >> 16) & 1) + (((ivs >> 21) & 1) << 1) + (((ivs >> 26) & 1) << 2) + (((ivs >> 0) & 1) << 3) + (((ivs >> 5) & 1) << 4) + (((ivs >> 10) & 1) << 5)) * 15) / 63;
                        int hip = (int)(((((ivs >> 17) & 1) + (((ivs >> 22) & 1) << 1) + (((ivs >> 27) & 1) << 2) + (((ivs >> 1) & 1) << 3) + (((ivs >> 6) & 1) << 4) + (((ivs >> 11) & 1) << 5)) * 40) / 63) + 30;

                        if ( // Begin Failure Conditions
                            iva[0] < minhp ||
                            iva[1] < minatk ||
                            iva[2] < mindef ||
                            iva[4] < minspa ||
                            iva[5] < minspd ||
                            iva[3] < minspe ||
                            iva[0] > maxhp ||
                            iva[1] > maxatk ||
                            iva[2] > maxdef ||
                            iva[4] > maxspa ||
                            iva[5] > maxspd ||
                            iva[3] > maxspe ||
                            selected_hips[hit] == 0 ||
                            hip < minhip ||
                            hip > maxhip ||
                            iva.Sum() > summax ||
                            iva.Sum() < summin
                            ) // End Failure Conditions
                        {
                            bw = 1;
                        }

                        if (bw == 0)
                        {
                            if (patstring != "Eevee (XD)")
                            {
                                if (tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3) && enableshiny == 1)
                                {
                                    shiny = 99;
                                }

                                if (shiny == 99)
                                {
                                    if (forceshiny == 1)
                                    {
                                        tsid = ((pid >> 16 ^ pid & 0xFFFF) >> 3);
                                    }
                                    if (colomon == 0)
                                    {
                                        tempseed = RNGAdv(2, (uint)(tempseed & 0xFFFFFFFF));
                                        pid = GetPID((uint)(tempseed & 0xFFFFFFFF));
                                        while (tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3))
                                        {
                                            tempseed = RNGAdv(2, (uint)(tempseed & 0xFFFFFFFF));
                                            pid = GetPID((uint)(tempseed & 0xFFFFFFFF));
                                        }
                                        UpdateReRoll();
                                    }
                                }
                            }
                            if (tsid == ((pid >> 16 ^ pid & 0xFFFF) >> 3))
                            {
                                pidhistory = pidhistory + ";SHINY";
                            }
                            string gender;
                            uint gv;
                            if (target_gender > 255)
                            {
                                gender = "Genderless: ";
                                gv = 2;
                            }
                            else if (pid & 255 > target_gender)
                            {
                                gender = "Male: ";
                                gv = 0;
                            }
                            else
                            {
                                gender = "Female: ";
                                gv = 1;
                            }

                            uint nat = pid % 25;
                            uint gen = pid & 255;
                            int ivm = iva.Max();
                            int charaslot = (int)(pid % 6);
                            int tiebreaker = 0;
                            uint i = 0;
                            while (i < 6)
                            {
                                if (iva[tiebreaker = charaslot++ % 6] == ivm)
                                {
                                    break;
                                }
                                i++;
                            }
                            int chara = tiebreaker * 5 + ivm % 5;

                            if ( // Begin Failure Conditions
                                selected_natures[nat] == 0 ||
                                selected_charas[chara] == 0 ||
                                (target_gender < 256 && gs < 2 && (gv != gs))
                                ) // End Failure Conditions
                            {
                                bw = 1;
                            }

                            if (bw == 0)
                            {
                                gender = gender + (pid & 255).ToString();
                                //Safety Frames
                                if ((patnum > 0) && (minsafeframes < 1))
                                {
                                    rollback = ((origseed * 0xb9b33155) + 0xa170f641) & 0xFFFFFFFF;
                                    i = 1;
                                    tpid = GetPID(rollback);
                                    if (!(((pat_sex[0] == "m" && tpid & 255 > pat_gender[0]) || ((pat_sex[0] == "f" || pat_sex[0] == "g") && (tpid & 255 <= pat_gender[0]))) && ((pat_nature[0] == pid % 25) || (pat_nature[0] > 24)) && !(tsid == ((tpid >> 16 ^ pid & 0xFFFF) >> 3) && enableshiny == 1)))
                                    {
                                        safety = "0:" + rollback.ToString("X8");
                                        while (!(((pat_sex[0] == "m" && tpid & 255 > pat_gender[0]) || ((pat_sex[0] == "f" || pat_sex[0] == "g") && (tpid & 255 <= pat_gender[0]))) && (pat_nature[0] == tpid % 25) && !(tsid == ((tpid >> 16 ^ pid & 0xFFFF) >> 3) && enableshiny == 1)))
                                        {
                                            rollback = ((rollback * 0xb9b33155) + 0xa170f641) & 0xFFFFFFFF;
                                            safety = "-" + i.ToString() + ":" + rollback.ToString("X8") + ";" + safety;
                                            tpid = GetPID(rollback);
                                            i++;
                                        }
                                        safety = "Safety Frames: " + safety;
                                    }
                                }
                                //Safety Frames
                                ToGrid(
                                origseed.ToString("X8"),
                                pid.ToString("X8"),
                                natures[nat] + ": " + nat,
                                gender,
                                iva[0].ToString(),
                                iva[1].ToString(),
                                iva[2].ToString(),
                                iva[4].ToString(),
                                iva[5].ToString(),
                                iva[3].ToString(),
                                hpower[hit] + ": " + hit,
                                hip.ToString(),
                                character[chara] + " " + chara,
                                tsid,
                                iva.Sum().ToString(),
                                (iva.Sum() / 6).ToString(),
                                safety,
                                seedhistory,
                                pidhistory
                                );
                            }
                        }
                    }
                    bw = 0;
                    shiny = shinydefault;
                    tsid = tsiddefault;
                }
            }
            
            while ((killthreads < 1) || !(tempseed > Spread.maxseed))
            {
                if ((killthreads > 0) || (tempseed > maxseed))
                {
                    break;
                }

                origseed = (uint)tempseed & 0xFFFFFFFF;
                pid = GetPID(origseed);

                if (minsafeframes > 0)
                {
                    uint i = 0;
                    while (i < minsafeframes)
                    {
                        origseed = ((origseed * 0xb9b33155) + 0xa170f641) & 0xFFFFFFFF;
                        i++;
                    }
                }

                patint = 0;
                framehis = 1;
                enableshiny = enableshinydefault;
                forceshiny = forceshinydefault;
                shiny = shinydefault;

                if (patnum == 0)
                {
                    BeginHistory();
                    WriteOut();
                }
                else if (patnum > 0 && ((pat_sex[0] == "m" && pid & 255 > pat_gender[0]) || ((pat_sex[0] == "f" || pat_sex[0] == "g") && (pid & 255 <= pat_gender[0]))) && ((pat_nature[0] == pid % 25) || (pat_nature[0] > 24)))
                {
                    BeginHistory();
                    if ((pat_nature[0] < 26) && (colomon == 0))
                    {
                        ShinyCheck();
                    }
                    if (pat_nature[0] > 25)
                    {
                        tempseed = RNGAdv(5, (uint)(tempseed & 0xFFFFFFFF));
                    }
                    else
                    {
                        tempseed = RNGAdv(7, (uint)(tempseed & 0xFFFFFFFF));
                    }
                    pid = GetPID((uint)(tempseed & 0xFFFFFFFF));
                    while (patint < (patnum - 1))
                    {
                        patint++;
                        Roll();
                        UpdateHistory();
                        if ((pat_nature[patint] < 26) && (colomon == 0))
                        {
                            ShinyCheck();
                        }
                        if (pat_nature[patint] > 25)
                        {
                            tempseed = RNGAdv(5, (uint)(tempseed & 0xFFFFFFFF));
                        }
                        else
                        {
                            tempseed = RNGAdv(7, (uint)(tempseed & 0xFFFFFFFF));
                        }
                        pid = GetPID((uint)(tempseed & 0xFFFFFFFF));
                    }
                    WriteOut();
                }
                if (prog >= step && ProgressBar1.Value < 99)
                {
                    ProgBar();
                    prog = 0;
                }
                else if (ProgressBar1.Value < 99)
                {
                    prog++;
                }
                revs = revs + threads;
                tempseed = revs;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            killthreads = 1;
        }

        public void Stop()
        {
            killthreads = 1;
        }

        public void Search()
        {
            killthreads = 0;
            writes = 0;
            Button2.Enabled = true;
            ProgressBar1.Value = 0;
            bar = 0;
            RichTextBox1.Clear();
            if (output > 0)
            {
                System.IO.File.AppendAllText("Results(" + patstring + ") " + date + ".csv", "Seed;PID;Nature;Gender;HP;Attack;Defense;Sp. Atk;Sp. Def;Speed;Hidden Power (T);Hidden Power (S);ReRoll TSV;IV Sum;IV Average;Characteristic" + "\r");
            }
            //seed = 3893673721; maxseed = 3893673723;
            results = defaultresults;
            step = defaultmaxseed / 100;
            maxseed = (ulong)defaultmaxseed + (ulong)defaultseed;
            RichTextBox1.AppendText(defaultseed.ToString("X8") + " " + patstring + "\r");
            if (silent > 0)
            {
                RichTextBox1.AppendText("Running silently... Please check the CSV for results.\r");
            }
            else
            {
                RichTextBox1.AppendText("Seed\t\tPID\t\tNature\t\tGender\t\tHP\tAttack\tDefense\tSp.Atk\tSp.Def\tSpeed\tHidden Power\t(S)\tTSV\tIV Sum\tAverage\tCharacteristic\r");
            }
            BackgroundWorker1.RunWorkerAsync();
        }

        private void Spread_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Variables Controls = new Variables();
            Controls.Show();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread thread1 = new Thread(() => Main(1));
            Thread thread2 = new Thread(() => Main(2));
            Thread thread3 = new Thread(() => Main(3));
            Thread thread4 = new Thread(() => Main(4));
            if (threads > 0)
            {
                thread1.Start();
            }
            if (threads > 1)
            {
                thread2.Start();
            }
            if (threads > 2)
            {
                thread3.Start();
            }
            if (threads > 3)
            {
                thread4.Start();
            }
            if (thread1.IsAlive)
            {
                thread1.Join();
            }
            if (thread2.IsAlive)
            {
                thread2.Join();
            }
            if (thread3.IsAlive)
            {
                thread3.Join();
            }
            if (thread4.IsAlive)
            {
                thread4.Join();
            }
            Button2.Enabled = false;
            RichTextBox1.AppendText((maxseed & 0xFFFFFFFF).ToString("X8") + " Done.");
            ProgressBar1.Value = 100;
            bar = 100;
        }

        public void Exit()
        {
            killthreads = 1;
            Environment.Exit(0);
        }

        private void Spread_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Exit();
        }
    }
}
