using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eligor
{
    public partial class Variables : Form
    {
        uint bp = 0;
        string local_patstring = Spread.patstring;
        int local_target_gender = Spread.target_gender;
        int local_patnum = Spread.patnum;
        uint[] local_pat_nature = Spread.pat_nature;
        string[] local_pat_sex = Spread.pat_sex;
        int[] local_pat_gender = Spread.pat_gender;
        uint local_forceshiny = Spread.forceshinydefault;
        uint local_shinydefault = Spread.shinydefault;
        uint local_minsafeframes = 0;

        public Variables()
        {
            InitializeComponent();
            ComboBox1.SelectedIndex = 0;
            NThreads.SelectedIndex = 0;
            SelectGender.SelectedIndex = 2;
            local_patstring = ComboBox1.Text;
        }

        private void ForceSegments()
        {
            int i = 0;
            P1.Checked = false;
            P2.Checked = false;
            P3.Checked = false;
            P4.Checked = false;
            P5.Checked = false;
            P1.Enabled = false;
            P2.Enabled = false;
            P3.Enabled = false;
            P4.Enabled = false;
            P5.Enabled = false;
            while (i < local_patnum)
            {
                if (i == 0)
                {
                    P1.Enabled = true;
                }
                if (i == 1)
                {
                    P2.Enabled = true;
                }
                if (i == 2)
                {
                    P3.Enabled = true;
                }
                if (i == 3)
                {
                    P4.Enabled = true;
                }
                if (i == 4)
                {
                    P5.Enabled = true;
                }
                i++;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            local_patstring = ComboBox1.Text;
            local_minsafeframes = 0;

            //Gender Thresholds
            //Genderless:                   256+
            //100% Female:                  255
            //87.5% Female - 12.5% Male:    224
            //75% Female - 25% Male:        190
            //50% Female -50% Male:         126
            //25% Female - 75% Male:        62
            //12.5% Female - 87.5% Male:    30
            //100% Male:                    -1

            if (local_patstring == "Eevee (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 30;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Eevee (XD)" || local_patstring == "Espeon (Colosseum)" || local_patstring == "Umbreon (Colosseum)")
            {
                ETID_Check.Enabled = true;
                ETID_Val.Enabled = true;
            }
            else
            {
                ETID_Check.Checked = false;
                ETID_Check.Enabled = false;
                ETID_Val.Enabled = false;
            }

            if (local_patstring == "Teddiursa (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Poochyena (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 1;

                //Pokemon 1 - Not Golbat, Serious, Female
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;
            }

            if (local_patstring == "Ledyba (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 1;

                //Pokemon 1 - Taillow
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;
            }

            if (local_patstring == "Houndour (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;  
            }

            if (local_patstring == "Spheal -Cipher Lab- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Horsea, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Goldeen, Serious, Female
                local_pat_nature[1] = 12;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Spheal -Phenac City and Post- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Horsea, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Goldeen, Serious, Female
                local_pat_nature[1] = 12;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Beldum, Hardy, Genderless
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;
            }

            if (local_patstring == "Baltoy (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0; 
            }

            if (local_patstring == "Mareep (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Gulpin (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Koffing, Hasty, Female
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Grimer, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Seedot -Cipher Lab- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Oddish, Docile, Male 
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Cacnea, Quirky, Female
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Shroomish, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Lotad, Hardy, Male
                local_pat_nature[3] = 0;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Pineco, Serious, Male
                local_pat_nature[4] = 12;
                local_pat_sex[4] = "m";
                local_pat_gender[4] = 126;
            }

            if (local_patstring == "Seedot -Phenac City- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Oddish, Docile, Male 
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Cacnea, Quirky, Female
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Shroomish, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Lotad, Hardy, Female
                local_pat_nature[3] = 0;
                local_pat_sex[3] = "f";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Pineco, Docile, Male
                local_pat_nature[4] = 6;
                local_pat_sex[4] = "m";
                local_pat_gender[4] = 126;
            }

            if (local_patstring == "Seedot -Post- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Oddish, Docile, Male 
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Cacnea, Quirky, Female
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Shroomish, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Lotad, Hardy, Male
                local_pat_nature[3] = 0;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Pineco, Docile, Male
                local_pat_nature[4] = 12;
                local_pat_sex[4] = "m";
                local_pat_gender[4] = 126;
            }

            if (local_patstring == "Spinarak (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Swinub, Hasty, Female
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shuppet, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Numel (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Ralts, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Voltorb, Hardy, Genderless
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Bagon, Quirky, Female
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Carvanha (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0; 
            }

            if (local_patstring == "Shroomish (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Snubbull, Quirky, Female
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 190;

                //Pokemon 2 - Kecleon, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Delcatty (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 190;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Luvdisc, Relaxed, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 190;

                //Pokemon 2 - Beautifly, Hardy, Male
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Roselia, Quirky, Male
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Voltorb (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Lombre, Hardy, Male
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Lombre, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Lombre, Serious, Female
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Makuhita (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 62;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Kecleon, Docile, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Surskit, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Vulpix (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 190;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Spinarak, Hardy, Male
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Beautifly, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Dustox, Bashful, Male
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Duskull (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Sneasel, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Yanma, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Misdreavus, Quirky, Male
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Ralts (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Kadabra, Hardy, Male
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Flaafy, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Vigoroth, Bashful, Male
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Mawile (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 62;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Loudred, Docile, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Girafarig, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Snorunt (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 1;

                //Pokemon 1 - Seviper, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;
            }

            if (local_patstring == "Pineco (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 1;

                //Pokemon 1 - Murkrow, Docile, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;
            }

            if (local_patstring == "Natu (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Kirlia, Hardy, Male
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Linoone, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Roselia (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Remoraid, Docile, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Golbat, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Meowth (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Kadabra, Docile, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Sneasel, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Misdreavus, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Swinub (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Torkoal, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Nuzleaf, Hardy, Male
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Spearow (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Pelipper, Bashful, Male
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Electrike, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Grimer (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Chimecho, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Stantler, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Seel (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Hoothoot, Docile, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Graveller, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Gulpin, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Lunatone (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Lanturn, Hardy, Female
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Quagsire, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Zangoose (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Nosepass (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Lombre, Hardy, Male
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Lombre, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Lombre, Serious, Female
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Togepi (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 30;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Paras (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Seviper, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Murkrow, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Growlithe (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Seviper, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Murkrow, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Shadow Paras
                local_pat_nature[2] = 25;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;
            }

            if (local_patstring == "Growlithe -Paras Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Seviper, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Murkrow, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Shadow Paras (Seen)
                local_pat_nature[2] = 26;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;
            }

            if (local_patstring == "Shellder (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Beedrill (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Pidgeotto (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                local_minsafeframes = 7;

                //Pokemon 1 - Shadow Beedrill
                //7 Frames

                //Pokemon 2 - Furret, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Togetic, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 30;
            }

            if (local_patstring == "Pidgeotto -Beedrill Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                local_minsafeframes = 5;

                //Pokemon 1 - Shadow Beedrill (Seen)
                //5 Frames

                //Pokemon 2 - Furret, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Togetic, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 30;
            }

            if (local_patstring == "Tangela (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Ninetales, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 190;

                //Pokemon 2 - Jumpluff, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Azumarill, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Butterfree (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Ninetales, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 190;

                //Pokemon 2 - Jumpluff, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Azumarill, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Tangela
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Butterfree -Tangela Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Ninetales, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 190;

                //Pokemon 2 - Jumpluff, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Azumarill, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Tangela (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Magneton (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Shedinja, Bashful, Genderless
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "g";
                local_pat_gender[0] = 256;

                //Pokemon 2 - Wobbuffet, Hardy, Male
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Vibrava, Serious, Female
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Venomoth (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Golduck, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Hitmontop, Quirky, Male
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = -1;

                //Pokemon 3 - Hariyama, Serious, Male
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 62;
            }

            if (local_patstring == "Weepinbell (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Golduck, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Hitmontop, Quirky, Male
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = -1;

                //Pokemon 3 - Hariyama, Serious, Male
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 62;

                //Pokemon 4 - Shadow Venomoth
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Weepinbell -Venomoth Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Golduck, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Hitmontop, Quirky, Male
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = -1;

                //Pokemon 3 - Hariyama, Serious, Male
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 62;

                //Pokemon 4 - Shadow Venomoth (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Arbok (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Huntail, Docile, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Cacturne, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Weezing, Serious, Female
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Ursaring, Bashful, Female
                local_pat_nature[3] = 18;
                local_pat_sex[3] = "f";
                local_pat_gender[3] = 126;
            }

            if (local_patstring == "Primeape (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Lairon, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Sealeo, Serious, Female
                local_pat_nature[1] = 12;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Slowking, Docile, Female
                local_pat_nature[2] = 6;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Ursaring, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;
            }

            if (local_patstring == "Hypno (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Lairon, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Sealeo, Serious, Female
                local_pat_nature[1] = 12;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Slowking, Docile, Female
                local_pat_nature[2] = 6;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Ursaring, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Primeape
                local_pat_nature[4] = 25;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Hypno -Primeape Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Lairon, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Sealeo, Serious, Female
                local_pat_nature[1] = 12;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Slowking, Docile, Female
                local_pat_nature[2] = 6;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Ursaring, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Primeape (Seen)
                local_pat_nature[4] = 26;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Golduck (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Crawdaunt, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Pelipper, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Mantine, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Sableye (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Crawdaunt, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Pelipper, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Mantine, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Golduck
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Sableye -Golduck Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Crawdaunt, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Pelipper, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Mantine, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Golduck (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Dodrio (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 1;

                //Pokemon 1 - Xatu, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;
            }

            if (local_patstring == "Raticate (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Xatu, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Dodrio
                local_pat_nature[1] = 25;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Whiscash, Bashful, Male
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Raticate -Dodrio Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Xatu, Bashful, Female
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Dodrio (Seen)
                local_pat_nature[1] = 26;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Whiscash, Bashful, Male
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Farfetch'd (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Gardevoir, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Gorebyss, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Roselia, Quirky, Male
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Altaria (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Gardevoir, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Gorebyss, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Roselia, Quirky, Male
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Farfetch'd
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Altaria -Farfetch'd Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Gardevoir, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Gorebyss, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Roselia, Quirky, Male
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Farfetch'd (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Kangaskhan (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 255;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Electrode, Hardy, Genderless
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "g";
                local_pat_gender[0] = 256;

                //Pokemon 2 - Misdreavus, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Claydol, Serious, Genderless
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;
            }

            if (local_patstring == "Banette (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Electrode, Hardy, Genderless
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "g";
                local_pat_gender[0] = 256;

                //Pokemon 2 - Misdreavus, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Claydol, Serious, Genderless
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Shadow Kangaskhan
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Banette -Kangaskhan Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Electrode, Hardy, Genderless
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "g";
                local_pat_gender[0] = 256;

                //Pokemon 2 - Misdreavus, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Claydol, Serious, Genderless
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Shadow Kangaskhan (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Magmar (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 62;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Houndoom, Bashful, Male
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ninetales, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 190;

                //Pokemon 3 - Vileplume, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Pinsir (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Houndoom, Bashful, Male
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ninetales, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 190;

                //Pokemon 3 - Vileplume, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Magmar
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Pinsir -Magmar Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Houndoom, Bashful, Male
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ninetales, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 190;

                //Pokemon 3 - Vileplume, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Magmar (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Rapidash (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Camerupt, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Weezing, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Muk, Serious, Female
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Magcargo (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Camerupt, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Weezing, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Muk, Serious, Female
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Rapidash
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Magcargo -Rapidash Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Camerupt, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Weezing, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Muk, Serious, Female
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Rapidash (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Hitmonchan (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = -1;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Medicham, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Golem, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Xatu, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Hitmonlee (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = -1;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Grumpig, Quirky, Male
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Skarmory, Docile, Female
                local_pat_nature[1] = 12;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Metang, Bashful, Genderless
                local_pat_nature[2] = 6;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Hariyama, Bashful, Female
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "f";
                local_pat_gender[3] = 62;
            }

            if (local_patstring == "Lickitung (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Lanturn, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Magneton, Docile, Genderless
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;
            }

            if (local_patstring == "Scyther (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Stantler, Quirky, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Exploud, Docile, Genderless
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Chansey (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 255;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Stantler, Quirky, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Exploud, Docile, Genderless
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Shadow Scyther
                local_pat_nature[2] = 25;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;
            }

            if (local_patstring == "Chansey -Scyther Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 255;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Stantler, Quirky, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Exploud, Docile, Genderless
                local_pat_nature[1] = 24;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Shadow Scyther (Seen)
                local_pat_nature[2] = 26;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;
            }

            if (local_patstring == "Solrock (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Metang, Quirky, Genderless
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "g";
                local_pat_gender[0] = 256;

                //Pokemon 2 - Quagsire, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Scizor, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Starmie (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Metang, Quirky, Genderless
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "g";
                local_pat_gender[0] = 256;

                //Pokemon 2 - Quagsire, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Scizor, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Solrock
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;

                //Pokemon 5 - Castform, Bashful, Male
                local_pat_nature[4] = 18;
                local_pat_sex[4] = "m";
                local_pat_gender[4] = 126;
            }

            if (local_patstring == "Starmie -Solrock Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Metang, Quirky, Genderless
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "g";
                local_pat_gender[0] = 256;

                //Pokemon 2 - Quagsire, Docile, Male
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Scizor, Hardy, Female
                local_pat_nature[2] = 0;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Solrock (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;

                //Pokemon 5 - Castform, Bashful, Male
                local_pat_nature[4] = 18;
                local_pat_sex[4] = "m";
                local_pat_gender[4] = 126;
            }

            if (local_patstring == "Swellow (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Electabuzz (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 62;

                //Number of pokemon before Shadow
                local_patnum = 3;

                local_minsafeframes = 7;

                //Pokemon 1 - Shadow Swellow
                //7 Frames

                //Pokemon 2 - Alakazam, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Kingdra, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Heracross, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Electabuzz -Swellow Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 62;

                //Number of pokemon before Shadow
                local_patnum = 3;

                local_minsafeframes = 5;

                //Pokemon 1 - Shadow Swellow (Seen)
                //5 Frames

                //Pokemon 2 - Alakazam, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Kingdra, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Heracross, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Snorlax (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 30;

                //Number of pokemon before Shadow
                local_patnum = 4;

                local_minsafeframes = 7;

                //Pokemon 1 - Shadow Swellow
                //7 Frames

                //Pokemon 2 - Alakazam, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Kingdra, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Heracross, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Electabuzz
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Snorlax -Swellow Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 30;

                //Number of pokemon before Shadow
                local_patnum = 4;

                local_minsafeframes = 5;

                //Pokemon 1 - Shadow Swellow
                //5 Frames

                //Pokemon 2 - Alakazam, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Kingdra, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Heracross, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Electabuzz
                local_pat_nature[3] = 25;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Snorlax -Swellow, Electabuzz Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 30;

                //Number of pokemon before Shadow
                local_patnum = 4;

                local_minsafeframes = 5;

                //Pokemon 1 - Shadow Swellow
                //5 Frames

                //Pokemon 2 - Alakazam, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Kingdra, Bashful, Female
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Heracross, Bashful, Female
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Shadow Electabuzz (Seen)
                local_pat_nature[3] = 26;
                local_pat_sex[3] = "g";
                local_pat_gender[3] = 256;
            }

            if (local_patstring == "Poliwrath (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Slowking, Bashful, Male
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ursaring, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Aggron, Quirky, Male
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Walrein, Docile, Female
                local_pat_nature[3] = 6;
                local_pat_sex[3] = "f";
                local_pat_gender[3] = 126;
            }

            if (local_patstring == "Mr. Mime (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Slowking, Bashful, Male
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ursaring, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Aggron, Quirky, Male
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Walrein, Docile, Female
                local_pat_nature[3] = 6;
                local_pat_sex[3] = "f";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Poliwrath
                local_pat_nature[4] = 25;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Mr. Mime -Poliwrath Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Slowking, Bashful, Male
                local_pat_nature[0] = 18;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ursaring, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Aggron, Quirky, Male
                local_pat_nature[2] = 24;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Walrein, Docile, Female
                local_pat_nature[3] = 6;
                local_pat_sex[3] = "f";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Poliwrath (Seen)
                local_pat_nature[4] = 26;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Dugtrio (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Glalie, Hardy, Male
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ampharos, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Breloom, Docile, Female
                local_pat_nature[2] = 6;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Donphan, Serious, Male
                local_pat_nature[3] = 12;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;
            }

            if (local_patstring == "Manectric (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 1;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;
            }

            if (local_patstring == "Salamence (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric
                local_pat_nature[1] = 25;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;
            }

            if (local_patstring == "Marowak (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric
                local_pat_nature[1] = 25;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;
                
                //Pokemon 3 - Shadow Salamence
                local_pat_nature[2] = 25;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Flygon, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;
            }

            if (local_patstring == "Lapras (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric
                local_pat_nature[1] = 25;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Shadow Salamence
                local_pat_nature[2] = 25;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Flygon, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Marowak
                local_pat_nature[4] = 25;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Salamence -Manectric Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric (Seen)
                local_pat_nature[1] = 26;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;
            }

            if (local_patstring == "Marowak -Manectric Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric (Seen)
                local_pat_nature[1] = 26;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Shadow Salamence
                local_pat_nature[2] = 25;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Flygon, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;
            }

            if (local_patstring == "Marowak -Manectric, Salamence Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 4;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric (Seen)
                local_pat_nature[1] = 26;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Shadow Salamence (Seen)
                local_pat_nature[2] = 26;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Flygon, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;
            }

            if (local_patstring == "Lapras -Manectric Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric (Seen)
                local_pat_nature[1] = 26;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Shadow Salamence
                local_pat_nature[2] = 25;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Flygon, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Marowak
                local_pat_nature[4] = 25;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Lapras -Manectric, Salamence Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric (Seen)
                local_pat_nature[1] = 26;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Shadow Salamence (Seen)
                local_pat_nature[2] = 26;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Flygon, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Marowak
                local_pat_nature[4] = 25;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Lapras -Manectric, Marowak Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric (Seen)
                local_pat_nature[1] = 26;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Shadow Salamence
                local_pat_nature[2] = 25;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Flygon, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Marowak (Seen)
                local_pat_nature[4] = 26;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Lapras -Manectric, Salamence, Marowak Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Ninjask, Docile, Female
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Shadow Manectric (Seen)
                local_pat_nature[1] = 26;
                local_pat_sex[1] = "g";
                local_pat_gender[1] = 256;

                //Pokemon 3 - Shadow Salamence (Seen)
                local_pat_nature[2] = 26;
                local_pat_sex[2] = "g";
                local_pat_gender[2] = 256;

                //Pokemon 4 - Flygon, Quirky, Male
                local_pat_nature[3] = 24;
                local_pat_sex[3] = "m";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Shadow Marowak (Seen)
                local_pat_nature[4] = 26;
                local_pat_sex[4] = "g";
                local_pat_gender[4] = 256;
            }

            if (local_patstring == "Lugia (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Rhydon (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Moltres (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon
                local_minsafeframes = 7;
            }

            if (local_patstring == "Exeggutor (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon
                local_minsafeframes = 7;

                //Pokemon 2 - Shadow Moltres
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Tauros (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = -1;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon
                local_minsafeframes = 7;

                //Pokemon 2 - Shadow Moltres
                local_minsafeframes = local_minsafeframes + 7;
                
                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Articuno (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon
                local_minsafeframes = 7;

                //Pokemon 2 - Shadow Moltres
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 4 - Shadow Tauros
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Zapdos (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon
                local_minsafeframes = 7;

                //Pokemon 2 - Shadow Moltres
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 4 - Shadow Tauros
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 5 - Shadow Articuno
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Exeggutor -Rhydon, Moltres Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;
            }

            if (local_patstring == "Tauros -Rhydon, Moltres Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = -1;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Tauros -Rhydon, Moltres, Exeggutor Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = -1;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor (Seen)
                local_minsafeframes = local_minsafeframes + 5;
            }

            if (local_patstring == "Articuno -Rhydon, Moltres Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 4 - Shadow Tauros
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Articuno -Rhydon, Moltres, Tauros Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 4 - Shadow Tauros (Seen)
                local_minsafeframes = local_minsafeframes + 5;
            }

            if (local_patstring == "Articuno -Rhydon, Moltres, Exeggutor Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 4 - Shadow Tauros
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Articuno -Rhydon, Moltres, Exeggutor, Tauros Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 4 - Shadow Tauros (Seen)
                local_minsafeframes = local_minsafeframes + 5;
            }

            if (local_patstring == "Zapdos -Rhydon, Moltres Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 4 - Shadow Tauros
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 5 - Shadow Articuno
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Zapdos -Rhydon, Moltres, Tauros Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 4 - Shadow Tauros (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 5 - Shadow Articuno
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Zapdos -Rhydon, Moltres, Articuno Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 4 - Shadow Tauros
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 5 - Shadow Articuno (Seen)
                local_minsafeframes = local_minsafeframes + 5;
            }

            if (local_patstring == "Zapdos -Rhydon, Moltres, Exeggutor Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 4 - Shadow Tauros
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 5 - Shadow Articuno
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Zapdos -Rhydon, Moltres, Tauros, Articuno Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 4 - Shadow Tauros (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 5 - Shadow Articuno (Seen)
                local_minsafeframes = local_minsafeframes + 5;
            }

            if (local_patstring == "Zapdos -Rhydon, Moltres, Exeggutor, Tauros Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 4 - Shadow Tauros (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 5 - Shadow Articuno
                local_minsafeframes = local_minsafeframes + 7;
            }

            if (local_patstring == "Zapdos -Rhydon, Moltres, Exeggutor, Articuno Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 4 - Shadow Tauros
                local_minsafeframes = local_minsafeframes + 7;

                //Pokemon 5 - Shadow Articuno (Seen)
                local_minsafeframes = local_minsafeframes + 5;
            }

            if (local_patstring == "Zapdos -Rhydon, Moltres, Exeggutor, Tauros, Articuno Seen- (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;

                //Pokemon 1 - Shadow Rhydon (Seen)
                local_minsafeframes = 5;

                //Pokemon 2 - Shadow Moltres (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 3 - Shadow Exeggutor (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 4 - Shadow Tauros (Seen)
                local_minsafeframes = local_minsafeframes + 5;

                //Pokemon 5 - Shadow Articuno (Seen)
                local_minsafeframes = local_minsafeframes + 5;
            }

            if (local_patstring == "Dragonite (XD)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 5;

                //Pokemon 1 - Ludicolo, Hardy, Male
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ludicolo, Bashful, Male
                local_pat_nature[1] = 18;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Ludicolo, Serious, Female
                local_pat_nature[2] = 12;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;

                //Pokemon 4 - Ludicolo, Serious, Female
                local_pat_nature[3] = 12;
                local_pat_sex[3] = "f";
                local_pat_gender[3] = 126;

                //Pokemon 5 - Ludicolo, Hardy, Male
                local_pat_nature[4] = 0;
                local_pat_sex[4] = "m";
                local_pat_gender[4] = 126;
            }

            if (local_patstring == "Plusle (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Ho-Oh (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = 256;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Espeon (Colosseum)" || local_patstring == "Umbreon (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = -1;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_patstring == "Makuhita (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = 62;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Duskull, Quirky, Male
                local_pat_nature[0] = 24;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Spinarak, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Gligar (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Teddiursa, Serious, Male
                local_pat_nature[0] = 12;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Jigglypuff, Docile, Female
                local_pat_nature[1] = 6;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 190;

                //Pokemon 3 - Shroomish, Bashful, Male
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Murkrow (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Carvahna, Docile, Male
                local_pat_nature[0] = 6;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Nuzleaf, Serious, Female
                local_pat_nature[1] = 12;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;

                //Pokemon 3 - Houndour, Bashful, Male
                local_pat_nature[2] = 18;
                local_pat_sex[2] = "m";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Heracross (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 2;

                //Pokemon 1 - Masquerain, Hardy, Male
                local_pat_nature[0] = 0;
                local_pat_sex[0] = "m";
                local_pat_gender[0] = 126;

                //Pokemon 2 - Ariados, Hardy, Female
                local_pat_nature[1] = 0;
                local_pat_sex[1] = "f";
                local_pat_gender[1] = 126;
            }

            if (local_patstring == "Ursaring (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = 126;

                //Number of pokemon before Shadow
                local_patnum = 3;

                //Pokemon 1 - Machoke, Calm, Female
                local_pat_nature[0] = 20;
                local_pat_sex[0] = "f";
                local_pat_gender[0] = 62;

                //Pokemon 2 - Marshtomp, Mild, Male
                local_pat_nature[1] = 16;
                local_pat_sex[1] = "m";
                local_pat_gender[1] = 30;

                //Pokemon 3 - Shiftry, Gentle, Female
                local_pat_nature[2] = 21;
                local_pat_sex[2] = "f";
                local_pat_gender[2] = 126;
            }

            if (local_patstring == "Bayleef (Colosseum)" || local_patstring == "Quilava (Colosseum)" || local_patstring == "Quilava (Colosseum)")
            {
                //Shadow Gender Threshold
                local_target_gender = 30;

                //Number of pokemon before Shadow
                local_patnum = 0;
            }

            if (local_target_gender > 255)
            {
                SelectGender.SelectedIndex = 2;
                SelectGender.Enabled = false;
            }
            else if (local_target_gender == 255)
            {
                SelectGender.SelectedIndex = 1;
                SelectGender.Enabled = false;
            }
            else if (local_target_gender == -1)
            {
                SelectGender.SelectedIndex = 0;
                SelectGender.Enabled = false;
            }
            else
            {
                SelectGender.Enabled = true;
            }
            ForceSegments();
            if (local_patstring == "Espeon (Colosseum)" || local_patstring == "Umbreon (Colosseum)" || local_patstring == "Plusle (Colosseum)" || local_patstring == "Ho-Oh (Colosseum)")
            {
                PT.Checked = false;
                PT.Enabled = false;
            }
            else
            {
                PT.Enabled = true;
            }
            if (local_patstring == "Plusle (Colosseum)" || local_patstring == "Ho-Oh (Colosseum)")
            {
                TID_Match.Enabled = false;
                TID_Match.Checked = false;
            }
            else
            {
                TID_Match.Enabled = true;
            }
        }

        private void P1_CheckedChanged(object sender, EventArgs e)
        {
            if (P1.Checked == true)
            {
                P2.Checked = false;
                P3.Checked = false;
                P4.Checked = false;
                P5.Checked = false;
                PT.Checked = false;
                TID_Match.Checked = false;
                local_forceshiny = 1;
                local_shinydefault = 0;
            }
        }

        private void P2_CheckedChanged(object sender, EventArgs e)
        {
            if (P2.Checked == true)
            {
                P1.Checked = false;
                P3.Checked = false;
                P4.Checked = false;
                P5.Checked = false;
                PT.Checked = false;
                TID_Match.Checked = false;
                local_forceshiny = 1;
                local_shinydefault = 1;
            }
        }

        private void P3_CheckedChanged(object sender, EventArgs e)
        {
            if (P3.Checked == true)
            {
                P1.Checked = false;
                P2.Checked = false;
                P4.Checked = false;
                P5.Checked = false;
                PT.Checked = false;
                TID_Match.Checked = false;
                local_forceshiny = 1;
                local_shinydefault = 2;
            }
        }

        private void P4_CheckedChanged(object sender, EventArgs e)
        {
            if (P4.Checked == true)
            {
                P1.Checked = false;
                P2.Checked = false;
                P3.Checked = false;
                P5.Checked = false;
                PT.Checked = false;
                TID_Match.Checked = false;
                local_forceshiny = 1;
                local_shinydefault = 3;
            }
        }

        private void P5_CheckedChanged(object sender, EventArgs e)
        {
            if (P5.Checked == true)
            {
                P1.Checked = false;
                P2.Checked = false;
                P3.Checked = false;
                P4.Checked = false;
                PT.Checked = false;
                TID_Match.Checked = false;
                local_forceshiny = 1;
                local_shinydefault = 4;
            }
        }

        private void PT_CheckedChanged(object sender, EventArgs e)
        {
            if (PT.Checked == true)
            {
                P1.Checked = false;
                P2.Checked = false;
                P3.Checked = false;
                P4.Checked = false;
                P5.Checked = false;
                TID_Match.Checked = false;
                local_forceshiny = 1;
                local_shinydefault = 99;
            }
        }

        private void TID_Match_CheckedChanged(object sender, EventArgs e)
        {
            if (TID_Match.Checked == true)
            {
                P1.Checked = false;
                P2.Checked = false;
                P3.Checked = false;
                P4.Checked = false;
                P5.Checked = false;
                PT.Checked = false;
                ETID_Check.Checked = false;
                TID.Enabled = true;
                SID.Enabled = true;
            }
            else
            {
                TID.Enabled = false;
                SID.Enabled = false;
            }
        }

        private void Variables_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            var exit = Application.OpenForms.OfType<Spread>().Single();
            exit.Exit();
        }

        private void Variables_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void CSV_CheckedChanged(object sender, EventArgs e)
        {
            if (CSV.Checked == true)
            {
                MessageBox.Show("If your search is overly permissive, this can result in an extremely large file. Please be careful.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (CSV.Checked == false)
            {
                Silent.Checked = false;
            }
        }

        private void InitialSeed_TextChanged(object sender, EventArgs e)
        {
            string item = InitialSeed.Text;
            if (!uint.TryParse(item, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.CurrentInfo, out uint i) && item != String.Empty)
            {
                InitialSeed.Text = item.Remove(item.Length - 1, 1);
                InitialSeed.SelectionStart = InitialSeed.Text.Length;
            }
        }

        private void EnableLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableLimit.Checked == true)
            {
                ResultsLimit.Enabled = true;
            }
            else
            {
                ResultsLimit.Enabled = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string error = null;
            if (Natures_Select.CheckedItems.Count < 1)
            {
                error = error + "You must select at least one nature.\r";
            }
            if (HP_Select.CheckedItems.Count < 1)
            {
                error = error + "You must select at least one type of hidden power.\r";
            }
            if (Chara_Select.CheckedItems.Count < 1)
            {
                error = error + "You must select at least one characteristic.\r";
            }
            if (error != null)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Spread.patstring = local_patstring;
                Spread.target_gender = local_target_gender;
                Spread.patnum = local_patnum;
                Spread.pat_nature = local_pat_nature;
                Spread.pat_sex = local_pat_sex;
                Spread.pat_gender = local_pat_gender;
                Spread.forceshinydefault = local_forceshiny;
                Spread.shinydefault = local_shinydefault;
                Spread.minsafeframes = local_minsafeframes;
                if (local_patstring.Contains("Colosseum"))
                {
                    Spread.colomon = 1;
                }
                else
                {
                    Spread.colomon = 0;
                }
                if (Spread.bar > 99)
                {
                    if (P1.Checked == false && P2.Checked == false && P3.Checked == false && P4.Checked == false && P5.Checked == false && PT.Checked == false)
                    {
                        Spread.forceshinydefault = 0;
                        Spread.shinydefault = 255;
                    }
                    for (int i = 0; i < Natures_Select.Items.Count; i++)
                    {
                        if (Natures_Select.GetItemChecked(i))
                        {
                            Spread.selected_natures[i] = 1;
                        }
                        else
                        {
                            Spread.selected_natures[i] = 0;
                        }
                    }
                    for (int i = 0; i < HP_Select.Items.Count; i++)
                    {
                        if (HP_Select.GetItemChecked(i))
                        {
                            Spread.selected_hips[i] = 1;
                        }
                        else
                        {
                            Spread.selected_hips[i] = 0;
                        }
                    }
                    for (int i = 0; i < Chara_Select.Items.Count; i++)
                    {
                        if (Chara_Select.GetItemChecked(i))
                        {
                            Spread.selected_charas[i] = 1;
                        }
                        else
                        {
                            Spread.selected_charas[i] = 0;
                        }
                    }
                    if (CSV.Checked == true)
                    {
                        Spread.output = 1;
                    }
                    else
                    {
                        Spread.output = 0;
                    }
                    if (Silent.Checked == true)
                    {
                        Spread.silent = 1;
                    }
                    else
                    {
                        Spread.silent = 0;
                    }
                    if (local_patstring == "Plusle (Colosseum)")
                    {
                        Spread.colomon = 0;
                        Spread.enableshinydefault = 1;
                        Spread.tsiddefault = 4643;
                        Spread.tid = 37149;
                        Spread.sid = 0;
                    }
                    else if (local_patstring == "Ho-Oh (Colosseum)")
                    {
                        Spread.colomon = 0;
                        Spread.enableshinydefault = 1;
                        Spread.tsiddefault = 1256;
                        Spread.tid = 10048;
                        Spread.sid = 0;
                    }
                    else if (TID_Match.Checked == true)
                    {
                        Spread.enableshinydefault = 1;
                        Spread.tsiddefault = (((uint)TID.Value ^ (uint)SID.Value) >> 3);
                        Spread.tid = (uint)TID.Value;
                        Spread.sid = (uint)SID.Value;
                    }
                    else
                    {
                        Spread.enableshinydefault = 0;
                        Spread.tsiddefault = 4294967295;
                        Spread.tid = 65536;
                        Spread.sid = 65536;
                    }
                    if (EnableLimit.Checked == true)
                    {
                        Spread.defaultresults = (uint)ResultsLimit.Value;
                    }
                    else
                    {
                        Spread.defaultresults = 4294967295;
                    }
                    if (InitialSeed.Text.Length < 1) { Spread.defaultseed = 0; }
                    else
                    {
                        Spread.defaultseed = uint.Parse(InitialSeed.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
                    }
                    Spread.minhp = (uint)HP_Min.Value;
                    Spread.maxhp = (uint)HP_Max.Value;
                    Spread.minatk = (uint)ATK_Min.Value;
                    Spread.maxatk = (uint)ATK_Max.Value;
                    Spread.mindef = (uint)DEF_Min.Value;
                    Spread.maxdef = (uint)DEF_Max.Value;
                    Spread.minspa = (uint)SPA_Min.Value;
                    Spread.maxspa = (uint)SPA_Max.Value;
                    Spread.minspd = (uint)SPD_Min.Value;
                    Spread.maxspd = (uint)SPD_Max.Value;
                    Spread.minspe = (uint)SPE_Min.Value;
                    Spread.maxspe = (uint)SPE_Max.Value;
                    Spread.minhip = (uint)HID_Min.Value;
                    Spread.maxhip = (uint)HID_Max.Value;
                    Spread.gs = (uint)SelectGender.SelectedIndex;
                    if (HID_Min.Value > HID_Max.Value)
                    {
                        HID_Min.Value = HID_Max.Value;
                    }
                    if (SUM_Min.Value > SUM_Max.Value)
                    {
                        SUM_Min.Value = SUM_Max.Value;
                    }
                    if (SUM_Max.Value < HP_Min.Value + ATK_Min.Value + DEF_Min.Value + SPA_Min.Value + SPD_Min.Value + SPE_Min.Value)
                    {
                        SUM_Max.Value = HP_Min.Value + ATK_Min.Value + DEF_Min.Value + SPA_Min.Value + SPD_Min.Value + SPE_Min.Value;
                    }
                    if (SUM_Min.Value > HP_Max.Value + ATK_Max.Value + DEF_Max.Value + SPA_Max.Value + SPD_Max.Value + SPE_Max.Value)
                    {
                        SUM_Min.Value = HP_Max.Value + ATK_Max.Value + DEF_Max.Value + SPA_Max.Value + SPD_Max.Value + SPE_Max.Value;
                    }
                    if (SUM_Min.Value < HP_Min.Value + ATK_Min.Value + DEF_Min.Value + SPA_Min.Value + SPD_Min.Value + SPE_Min.Value)
                    {
                        SUM_Min.Value = HP_Min.Value + ATK_Min.Value + DEF_Min.Value + SPA_Min.Value + SPD_Min.Value + SPE_Min.Value;
                    }
                    Spread.summax = (uint)SUM_Max.Value;
                    Spread.summin = (uint)SUM_Min.Value;
                    Spread.date = DateTime.Now.ToString("yyyyMMddhhmmss");
                    if (ETID_Check.Checked == true)
                    {
                        Spread.etidc = (uint)ETID_Val.Value;
                    }
                    else
                    {
                        Spread.etidc = 4294967295;
                    }

                    if (bp == 0)
                    {
                        Spread.threads = (uint)NThreads.SelectedIndex + 1;
                        var search = Application.OpenForms.OfType<Spread>().Single();
                        search.Search();
                    }
                    else
                    {
                        MessageBox.Show("No pattern defined for " + Spread.patstring + ".", "Undefined", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bp = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Please complete or cancel the current search.", "Busy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HP_All_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < HP_Select.Items.Count; i++) HP_Select.SetItemChecked(i, true);
        }

        private void HP_None_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < HP_Select.Items.Count; i++) HP_Select.SetItemChecked(i, false);
        }

        private void Nature_All_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Natures_Select.Items.Count; i++) Natures_Select.SetItemChecked(i, true);
        }

        private void Nature_None_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Natures_Select.Items.Count; i++) Natures_Select.SetItemChecked(i, false);
        }

        private void Chara_All_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Chara_Select.Items.Count; i++) Chara_Select.SetItemChecked(i, true);
        }

        private void Chara_None_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Chara_Select.Items.Count; i++) Chara_Select.SetItemChecked(i, false);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var stop = Application.OpenForms.OfType<Spread>().Single();
            stop.Stop();
        }

        private void Silent_CheckedChanged(object sender, EventArgs e)
        {
            if (Silent.Checked == true)
            {
                CSV.Checked = true;
            }
            
        }

        private void ETID_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (ETID_Check.Checked == true)
            {
                TID_Match.Checked = false;
            }
        }
    }    
}