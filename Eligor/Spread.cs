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
    public partial class Spread : Form
    {
        DataTable Pokemon_List = new DataTable();
        Progress ProgBar = new Progress();
        string[] CharacteristicText = { "Loves to eat.", "Takes plenty of siestas.", "Nods off a lot.", "Scatters things often.", "Likes to relax.", "Proud of its power.", "Likes to thrash about.", "A little quick tempered.", "Likes to fight.", "Quick tempered.", "Sturdy body.", "Capable of taking hits.", "Highly persistent.", "Good endurance.", "Good perseverance.", "Likes to run.", "Alert to sounds.", "Impetuous and silly.", "Somewhat of a clown.", "Quick to flee.", "Highly curious.", "Mischievous.", "Thoroughly cunning.", "Often lost in thought.", "Very finicky.", "Strong willed.", "Somewhat vain.", "Strongly defiant.", "Hates to lose.", "Somewhat stubborn." };
        string[] NatureText = { "Hardy", "Lonely", "Brave", "Adamant", "Naughty", "Bold", "Docile", "Relaxed", "Impish", "Lax", "Timid", "Hasty", "Serious", "Jolly", "Naive", "Modest", "Mild", "Quiet", "Bashful", "Rash", "Calm", "Gentle", "Sassy", "Careful", "Quirky" };
        string[] HiddenPowerText = { "Fighting", "Flying", "Poison", "Ground", "Rock", "Bug", "Ghost", "Steel", "Fire", "Water", "Grass", "Electric", "Psychic", "Ice", "Dragon", "Dark" };
        public static uint Halt;
        uint PokemonSeed;
        uint[] PID = { 0, 0, 0, 0, 0, 0 };
        uint Characteristic;
        uint seedtick;
        uint startseed;
        uint maxseed;
        uint tempseed;
        int[] IVs = { 31, 31, 31, 31, 31, 31 };
        uint MAX_HP_IV;
        uint MAX_Attack_IV;
        uint MAX_Defense_IV;
        uint MAX_Special_Attack_IV;
        uint MAX_Special_Defense_IV;
        uint MAX_Speed_IV;
        uint MIN_HP_IV;
        uint MIN_Attack_IV;
        uint MIN_Defense_IV;
        uint MIN_Special_Attack_IV;
        uint MIN_Special_Defense_IV;
        uint MIN_Speed_IV;
        uint MAX_IV_Sum;
        uint MIN_IV_Sum;
        string PokemonGenderTarget;
        int[] Selected_HiddenPowerType = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        int[] Selected_Characteristic = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        int[] Selected_Nature = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        uint HiddenPowerType;
        uint HiddenPowerStrength;
        uint MAX_HiddenPowerStrength;
        uint MIN_HiddenPowerStrength;
        uint HasLock;
        uint[] Nature = { 0, 0, 0, 0, 0, 0, 0 };
        string[] Gender = { "", "", "", "", "", "", "" };
        uint[] GenderThreshold = { 0, 0, 0, 0, 0, 0, 0 };
        uint[] PokemonShinyValue = { 0, 0, 0, 0, 0, 0, 0 };
        uint[] IsReRoll = { 0, 0, 0, 0, 0, 0, 0 };
        uint TrainerShinyValue;
        int[] TSID = { 0, 0 };
        uint AllowShiny;
        bool MustBeShiny;
        bool IsStarter;
        uint[] StarterTID = {0, 0};
        int SelectedPokemon;
        uint ForceShiny;
        uint EeveeTID;
        uint EeveeSID;
        uint EeveeSeed;
        uint progval;
        uint progtick;
        string ReRollTSV;
        bool RunSilent;
        bool OutputCSV;
        string date;

        private uint RNGAdv(uint tseed, uint frame)
        {
            for (uint i = 0; i < frame; i++)
            {
                tseed = (tseed * 0x000343fd) + 0x00269ec3;
            }
            return tseed;
        }

        private uint RNGRev(uint tseed, uint frame)
        {
            for (uint i = 0; i < frame; i++)
            {
                tseed = (tseed * 0xb9b33155) + 0xa170f641;
            }
            return tseed;
        }

        private ushort SplitAdv(uint tseed, uint frame)
        {
            for (uint i = 0; i < frame; i++)
            {
                tseed = ((tseed * 0x000343fd) + 0x00269ec3) & 0xFFFFFFFF;
            }
            return (ushort)(tseed >> 16);
        }

        private ushort SplitRev(uint tseed, uint frame)
        {
            for (uint i = 0; i < frame; i++)
            {
                tseed = ((tseed * 0xb9b33155) + 0xa170f641) & 0xFFFFFFFF;
            }
            return (ushort)(tseed >> 16);
        }

        private void WriteOut()
        {
            string Line;
            if (IsStarter == true)
            {
                Line = string.Join(",",
                (EeveeSeed).ToString("X8"),EeveeTID, EeveeSID);
            }
            else
            {
                Line = string.Join(",",
                (seedtick).ToString("X8"));
            }
            Line = string.Join(",",Line,
            (PokemonSeed).ToString("X8"),
            (PID[0]).ToString("X8")
            ); if (IsReRoll[0] > 0) { Line = $"{Line}*ReRoll={IsReRoll[0]}"; } Line = string.Join(",",Line,
            ReRollTSV,
            NatureText[Nature[0]],
            Gender[0],
            IVs[0],
            IVs[1],
            IVs[2],
            IVs[4],
            IVs[5],
            IVs[3],
            $"{HiddenPowerText[HiddenPowerType]}:{HiddenPowerStrength}",
            CharacteristicText[Characteristic]
            );
            if (HasLock > 0)
            {
                for (uint i = 1; i <= HasLock; i++)
                {
                    Line = $"{Line},{(string)Pokemon_List.Rows[SelectedPokemon][$"Shadow{i}_Species"]}:{PID[i]:X8}";
                    if (IsReRoll[i] > 0) { Line = $"{Line}*ReRoll={IsReRoll[i]}"; }
                }
            }
            if (RunSilent == false)
            {
                string[] delim = Line.Split(',');
                DataGridView1.Rows.Add(delim);
            }
            if (OutputCSV == true)
            {
                System.IO.File.AppendAllText("Results(" + (string)Pokemon_List.Rows[SelectedPokemon][$"Pokemon"] + ") " + date + ".csv", Line + "\r");
            }
        }

        private void GetIVs(uint call)
        {
            uint IVCall = (uint)((SplitAdv(call, 1) << 16) & 0xFFFF0000) + SplitAdv(call, 2);
            IVs[0] = (int)(IVCall >> 16) & 31;  //HP
            IVs[1] = (int)(IVCall >> 21) & 31;  //ATTACK
            IVs[2] = (int)(IVCall >> 26) & 31;  //DEFENSE
            IVs[3] = (int)IVCall & 31;          //SPEED
            IVs[4] = (int)(IVCall >> 5) & 31;   //SPECIAL ATTACK
            IVs[5] = (int)(IVCall >> 10) & 31;  //SPECIAL DEFENSE
        }

        private void GetHiddenPowerType()
        {
            HiddenPowerType = (uint)(((IVs[0] & 1) + ((IVs[1] & 1) << 1) + ((IVs[2] & 1) << 2) + ((IVs[3] & 1) << 3) + ((IVs[4] & 1) << 4) + ((IVs[5] & 1) << 5)) * 15) / 63;
        }

        private void GetHiddenPowerStrength()
        {
            HiddenPowerStrength = (uint)(((((IVs[0] >> 1) & 1) + (((IVs[1] >> 1) & 1) << 1) + (((IVs[2] >> 1) & 1) << 2) + (((IVs[3] >> 1) & 1) << 3) + (((IVs[4] >> 1) & 1) << 4) + (((IVs[5] >> 1) & 1) << 5)) * 40) / 63) + 30;
        }

        private uint GetPID(uint call)
        {
            return ((uint)(SplitAdv(call, 4) << 16) & 0xFFFF0000) + SplitAdv(call, 5);
        }

        private void GetCharacteristic(uint call)
        {
            uint charaslot = (call % 6);
            uint tiebreaker = 0;
            for (uint i = 0; i < 6; i++)
            {
                if (IVs[tiebreaker = charaslot++ % 6] == IVs.Max())
                {
                    break;
                }
            }
            Characteristic = tiebreaker * 5 + (uint)IVs.Max() % 5;
        }

        private string GetGender(uint call, uint threshold)
        {
            if (threshold > 255)
            {
                return "Genderless";
            }
            else if ((call & 255) >= threshold)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }

        private uint GetNature(uint call)
        {
            return (call % 25);
        }

        private uint GetSV(uint call)
        {
            return ((call >> 16 ^ call & 0xFFFF) >> 3);
        }

        private void SolveLock()
        {
            if (Nature[1] > 24 || (Gender[1] == GetGender(PID[1] = GetPID(tempseed), GenderThreshold[1]) && Nature[1] == GetNature(PID[1])))
            {
                for (uint i = 1; i <= HasLock; i++)
                {
                    if (Nature[i] == 26)
                    {
                        PokemonShinyValue[i] = PID[i] = 4294967295;
                        tempseed = RNGAdv(tempseed, 5);
                    }
                    else
                    {
                        PID[i] = GetPID(tempseed);
                        PokemonShinyValue[i] = GetSV(PID[i]);
                        if (PokemonShinyValue[i] == TrainerShinyValue)
                        {
                            ReRollTSV = TrainerShinyValue.ToString();
                        }
                        if (i > 1)
                        {
                            while (Nature[i] < 25 && ((Gender[i] != GetGender(PID[i], GenderThreshold[i])) || (Nature[i] != GetNature(PID[i]))) || ((AllowShiny == 0 && PokemonShinyValue[i] == TrainerShinyValue)))
                            {
                                tempseed = RNGAdv(tempseed, 2);
                                PID[i] = GetPID(tempseed);
                                PokemonShinyValue[i] = GetSV(PID[i]);
                                if (PokemonShinyValue[i] == TrainerShinyValue && (Nature[i] == GetNature(PID[i])) && (Gender[i] == GetGender(PID[i], GenderThreshold[i])))
                                {
                                    ReRollTSV = TrainerShinyValue.ToString();
                                }
                            }
                            if (ForceShiny == i)
                            {
                                TrainerShinyValue = PokemonShinyValue[i];
                                for (uint s = 1; s < i; s++)
                                {
                                    if (PokemonShinyValue[s] == TrainerShinyValue)
                                    {
                                        Halt = 1;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (ForceShiny == 1 && i == 1)
                        {
                            TrainerShinyValue = PokemonShinyValue[1];
                        }
                        if (PokemonShinyValue[i] == TrainerShinyValue)
                        {
                            ReRollTSV = TrainerShinyValue.ToString();
                        }
                        IsReRoll[i] = 0;
                        while ((Nature[i] < 25 && ((Gender[i] != GetGender(PID[i], GenderThreshold[i])) || (Nature[i] != GetNature(PID[i]))) || ((AllowShiny == 0 && PokemonShinyValue[i] == TrainerShinyValue))) && Halt == 0)
                        {
                            tempseed = RNGAdv(tempseed, 2);
                            PID[i] = GetPID(tempseed);
                            PokemonShinyValue[i] = GetSV(PID[i]);
                            IsReRoll[i]++;
                            if (PokemonShinyValue[i] == TrainerShinyValue && (Nature[i] == GetNature(PID[i])) && (Gender[i] == GetGender(PID[i], GenderThreshold[i])))
                            {
                                ReRollTSV = TrainerShinyValue.ToString();
                            }
                        }
                        if (Halt == 0)
                        {
                            tempseed = RNGAdv(tempseed, 7);
                        }
                    }
                }
            }
            else
            {
                Halt = 1;
            }
        }

        private void SpreadFinder()
        {
            tempseed = seedtick;
            if (HasLock > 0)
            {
                SolveLock();
            }
            else if (IsStarter == true)
            {
                EeveeSeed = tempseed;
                for (uint i = 0; i < 3; i++)
                {
                    EeveeSeed = ((EeveeSeed * 0xb9b33155) + 0xa170f641) & 0xFFFFFFFF;
                    if (i == 1)
                    {
                        EeveeSID = EeveeSeed >> 16;
                    }
                    if (i == 2)
                    {
                        EeveeTID = EeveeSeed >> 16;
                    }
                }
                TrainerShinyValue = (EeveeTID ^ EeveeSID) >> 3;
                if (StarterTID[0] == 1 && StarterTID[1] != EeveeTID)
                {
                    Halt = 1;
                }
                else if ((string)Pokemon_List.Rows[SelectedPokemon]["Pokemon"] == "Espeon (Colosseum)")
                {
                    PID[0] = GetPID(tempseed);
                    PokemonShinyValue[0] = GetSV(PID[0]);
                    while ((PokemonShinyValue[0] == TrainerShinyValue) || (GetGender(PID[0], 31) == "Female"))
                    {
                        tempseed = RNGAdv(tempseed, 2);
                        PID[0] = GetPID(tempseed);
                        PokemonShinyValue[0] = GetSV(PID[0]);
                    }
                    tempseed = RNGAdv(tempseed, 7);
                }
            }
            if (Halt == 0)
            {
                GetIVs(tempseed);
                if ( // Begin Failure Conditions
                    IVs[0] < MIN_HP_IV ||
                    IVs[1] < MIN_Attack_IV ||
                    IVs[2] < MIN_Defense_IV ||
                    IVs[4] < MIN_Special_Attack_IV ||
                    IVs[5] < MIN_Special_Defense_IV ||
                    IVs[3] < MIN_Speed_IV ||
                    IVs[0] > MAX_HP_IV ||
                    IVs[1] > MAX_Attack_IV ||
                    IVs[2] > MAX_Defense_IV ||
                    IVs[4] > MAX_Special_Attack_IV ||
                    IVs[5] > MAX_Special_Defense_IV ||
                    IVs[3] > MAX_Speed_IV ||
                    IVs.Sum() > MAX_IV_Sum ||
                    IVs.Sum() < MIN_IV_Sum
                ) // End Failure Conditions
                {
                    Halt = 1;
                }
                else
                {
                    GetHiddenPowerType();
                    if ( // Begin Failure Conditions
                    Selected_HiddenPowerType[HiddenPowerType] == 0
                    ) // End Failure Conditions
                    {
                        Halt = 1;
                    }
                    else
                    {
                        GetHiddenPowerStrength();
                        if ( // Begin Failure Conditions
                        HiddenPowerStrength < MIN_HiddenPowerStrength ||
                        HiddenPowerStrength > MAX_HiddenPowerStrength
                        ) // End Failure Conditions
                        {
                            Halt = 1;
                        }
                        else
                        {
                            PokemonSeed = tempseed;
                            PID[0] = GetPID(tempseed);
                            PokemonShinyValue[0] = GetSV(PID[0]);
                            if (ForceShiny == 6)
                            {
                                TrainerShinyValue = PokemonShinyValue[0];
                            }
                            if (IsStarter == false && PokemonShinyValue[0] == TrainerShinyValue)
                            {
                                ReRollTSV = TrainerShinyValue.ToString();
                            }
                            IsReRoll[0] = 0;
                            while ((AllowShiny == 0 && PokemonShinyValue[0] == TrainerShinyValue) || (IsStarter == true && AllowShiny == 0 && GetGender(PID[0], 31) == "Female"))
                            {
                                tempseed = RNGAdv(tempseed, 2);
                                PID[0] = GetPID(tempseed);
                                PokemonShinyValue[0] = GetSV(PID[0]);
                                IsReRoll[0]++;
                            }
                            if ((MustBeShiny == true && PokemonShinyValue[0] != TrainerShinyValue) || (EPSV_Label.Checked == true && EPSV_Val.Value != PokemonShinyValue[0]))
                            {
                                Halt = 1;
                            }
                            else
                            {
                                if (AllowShiny == 1 && PokemonShinyValue[0] == TrainerShinyValue)
                                {
                                    ReRollTSV = TrainerShinyValue.ToString();
                                }
                                Nature[0] = GetNature(PID[0]);
                                if ( // Begin Failure Conditions
                                Selected_Nature[Nature[0]] == 0
                                ) // End Failure Conditions
                                {
                                    Halt = 2;
                                }
                                else
                                {
                                    Gender[0] = GetGender(PID[0], GenderThreshold[0]);
                                    if ( // Begin Failure Conditions
                                    (Gender[0] != PokemonGenderTarget && PokemonGenderTarget != "Any")
                                    ) // End Failure Conditions
                                    {
                                        Halt = 2;
                                    }
                                    else
                                    {
                                        GetCharacteristic(PID[0]);
                                        if ( // Begin Failure Conditions
                                        Selected_Characteristic[Characteristic] == 0
                                        ) // End Failure Conditions
                                        {
                                            Halt = 2;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } 
        }

        public Spread()
        {
            InitializeComponent();
            NatureComboBox.Items.AddRange(NatureText);
            CharacteristicComboBox.Items.AddRange(CharacteristicText);
            HiddenPowerComboBox.Items.AddRange(HiddenPowerText);
            NatureComboBox.ContextMenu = CharacteristicComboBox.ContextMenu = HiddenPowerComboBox.ContextMenu = new ContextMenu();
            Pokemon_List.Columns.Add("Pokemon", typeof(string));
            Pokemon_List.Columns.Add("Gender_Threshold", typeof(uint));
            Pokemon_List.Columns.Add("Lock", typeof(uint));
            Pokemon_List.Columns.Add("AllowShiny", typeof(uint));
            Pokemon_List.Columns.Add("ShinyValue", typeof(int));
            Pokemon_List.Columns.Add("Shadow1_Species", typeof(string));
            Pokemon_List.Columns.Add("Shadow1_Gender", typeof(string));
            Pokemon_List.Columns.Add("Shadow1_Nature", typeof(uint));
            Pokemon_List.Columns.Add("Shadow1_Gender_Threshold", typeof(uint));
            Pokemon_List.Columns.Add("Shadow2_Species", typeof(string));
            Pokemon_List.Columns.Add("Shadow2_Gender", typeof(string));
            Pokemon_List.Columns.Add("Shadow2_Nature", typeof(uint));
            Pokemon_List.Columns.Add("Shadow2_Gender_Threshold", typeof(uint));
            Pokemon_List.Columns.Add("Shadow3_Species", typeof(string));
            Pokemon_List.Columns.Add("Shadow3_Gender", typeof(string));
            Pokemon_List.Columns.Add("Shadow3_Nature", typeof(uint));
            Pokemon_List.Columns.Add("Shadow3_Gender_Threshold", typeof(uint));
            Pokemon_List.Columns.Add("Shadow4_Species", typeof(string));
            Pokemon_List.Columns.Add("Shadow4_Gender", typeof(string));
            Pokemon_List.Columns.Add("Shadow4_Nature", typeof(uint));
            Pokemon_List.Columns.Add("Shadow4_Gender_Threshold", typeof(uint));
            Pokemon_List.Columns.Add("Shadow5_Species", typeof(string));
            Pokemon_List.Columns.Add("Shadow5_Gender", typeof(string));
            Pokemon_List.Columns.Add("Shadow5_Nature", typeof(uint));
            Pokemon_List.Columns.Add("Shadow5_Gender_Threshold", typeof(uint));

            //Gender Thresholds
            //Genderless or Lock-Shadow:    256+
            //100% Female:                  255
            //87.5% Female - 12.5% Male:    225
            //75% Female - 25% Male:        191
            //50% Female -50% Male:         127
            //25% Female - 75% Male:        63
            //12.5% Female - 87.5% Male:    31
            //100% Male:                    0

            Pokemon_List.Rows.Add("Umbreon (Colosseum)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Espeon (Colosseum)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Makuhita (Colosseum)",
            63, //Gender Threshold
                2, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1, //Shiny Value

                "Duskull", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Spinarak", //Pokemon 2, Hardy, Female
                "Female", 0, 127);

            Pokemon_List.Rows.Add("Bayleef (Colosseum)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Quilava (Colosseum)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Croconaw (Colosseum)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Slugma (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Noctowl (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Flaaffy (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Skiploom (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Quagsire (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Misdreavus (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Furret (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Yanma (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Remoraid (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Mantine (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Qwilfish (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Meditite (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Dunsparce (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Swablu (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Sudowoodo (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Hitmontop (Colosseum)",
                0, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Entei (Colosseum)",
                256, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Ledian (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Suicune (Colosseum)",
                256, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Gligar (Colosseum)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1, //Shiny Value

                "Teddiursa", //Pokemon 1, Serious, Male
                "Male", 12, 127,

                "Jigglypuff", //Pokemon 2, Docile, Female
                "Female", 6, 191,

                "Shroomish", //Pokemon 3, Bashful, Male
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Stantler (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Piloswine (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Sneasel (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Aipom (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Murkrow (Colosseum)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1, //Shiny Value

                "Carvahna", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Nuzleaf", //Pokemon 2, Serious, Female
                "Female", 12, 127,

                "Houndour", //Pokemon 3, Bashful, Male
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Forretress (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Ariados (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Granbull (Colosseum)",
                191, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Vibrava (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Raikou (Colosseum)",
                256, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Sunflora (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Delibird (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Heracross (Colosseum)",
            127, //Gender Threshold
                2, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1, //Shiny Value

                "Masquerain", //Pokemon 1, Hardy, Male
                "Male", 0, 127,

                "Ariados", //Pokemon 2, Hardy, Female
                "Female", 0, 127);

            Pokemon_List.Rows.Add("Skarmory (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Miltank (Colosseum)",
                255, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Absol (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Houndoom (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Tropius (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Metagross (Colosseum)",
                256, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Tyranitar (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Smeargle (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Ursaring (Colosseum)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1, //Shiny Value

                "Machoke", //Pokemon 1, Calm, Female
                "Male", 20, 63,

                "Marshtomp", //Pokemon 2, Mild, Male
                "Female", 16, 31,

                "Shiftry", //Pokemon 3, Gentle, Female
                "Female", 21, 127);

            Pokemon_List.Rows.Add("Shuckle (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Togetic (Colosseum)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Plusle (Colosseum)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                4643); //Shiny Value

            Pokemon_List.Rows.Add("Ho-Oh (Colosseum)",
                256, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                1256); //Shiny Value

            Pokemon_List.Rows.Add("Eevee (XD)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Ralts (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Kadabra", //Pokemon 1, Hardy, Male
                "Male", 0, 63,
                
                "Flaafy", //Pokemon 2, Docile, Female
                "Female", 6, 127,
                
                "Vigoroth", //Pokemon 3, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Teddiursa (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Poochyena (XD)",
                127, //Gender Threshold
                1, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Zubat", //Pokemon 1, Serious, Female
                "Female", 12, 127);

            Pokemon_List.Rows.Add("Ledyba (XD)",
                127, //Gender Threshold
                1, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Taillow", //Pokemon 1, Hardy, Female
                "Female", 0, 127);

            Pokemon_List.Rows.Add("Houndour (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Spheal -Cipher Lab- (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Horsea", //Pokemon 1, Quirky, Male
                "Male", 24, 63,

                "Goldeen", //Pokemon 2, Serious, Female
                "Female", 12, 127);

            Pokemon_List.Rows.Add("Spheal -Phenac City and Post- (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Horsea", //Pokemon 1, Quirky, Male
                "Male", 24, 63,

                "Goldeen", //Pokemon 2, Serious, Female
                "Female", 12, 127,

                "Beldum", //Pokemon 3, Hardy, Genderless
                "Genderless", 0, 256);

            Pokemon_List.Rows.Add("Baltoy (XD)",
                256, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Mareep (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Gulpin (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Koffing", //Pokemon 1, Hasty, Female
                "Female", 12, 127,

                "Grimer", //Pokemon 2, Docile, Male
                "Male", 6, 127);

            Pokemon_List.Rows.Add("Seedot -Cipher Lab- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Oddish", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Cacnea", //Pokemon 2, Quirky, Female
                "Female", 24, 127,

                "Shroomish", //Pokemon 3, Bashful, Female
                "Female", 18, 127,

                "Lotad", //Pokemon 4, Hardy, Male
                "Male", 0, 127,

                "Pineco", //Pokemon 5, Serious, Male
                "Male", 12, 127);

            Pokemon_List.Rows.Add("Seedot -Phenac City- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Oddish", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Cacnea", //Pokemon 2, Quirky, Female
                "Female", 24, 127,

                "Shroomish", //Pokemon 3, Hardy, Female
                "Female", 0, 127,

                "Lotad", //Pokemon 4, Hardy, Female
                "Female", 0, 127,

                "Pineco", //Pokemon 5, Docile, Male
                "Male", 6, 127);

            Pokemon_List.Rows.Add("Seedot -Post- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Oddish", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Cacnea", //Pokemon 2, Quirky, Female
                "Female", 24, 127,

                "Shroomish", //Pokemon 3, Hardy, Female
                "Female", 0, 127,

                "Lotad", //Pokemon 4, Hardy, Male
                "Male", 0, 127,

                "Pineco", //Pokemon 5, Docile, Male
                "Male", 6, 127);

            Pokemon_List.Rows.Add("Spinarak (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Swinub", //Pokemon 1, Hasty, Female
                "Female", 12, 127,

                "Shuppet", //Pokemon 2, Docile, Male
                "Male", 6, 127);

            Pokemon_List.Rows.Add("Numel (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ralts", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Voltorb", //Pokemon 2, Hardy, Genderless
                "Genderless", 0, 256,

                "Bagon", //Pokemon 3, Quirky, Female
                "Female", 24, 127);

            Pokemon_List.Rows.Add("Carvanha (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Shroomish (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Snubbull", //Pokemon 1, Quirky, Female
                "Female", 24, 191,

                "Kecleon", //Pokemon 2, Hardy, Female
                "Female", 0, 127);

            Pokemon_List.Rows.Add("Delcatty (XD)",
                191, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Luvdisc", //Pokemon 1, Relaxed, Female
                "Female", 6, 191,

                "Beautifly", //Pokemon 2, Hardy, Male
                "Male", 0, 127,

                "Roselia", //Pokemon 3, Quirky, Male
                "Male", 24, 127);

            Pokemon_List.Rows.Add("Voltorb (XD)",
                256, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Lombre", //Pokemon 1, Hardy, Male
                "Male", 0, 127,

                "Lombre", //Pokemon 2, Bashful, Male
                "Male", 18, 127,

                "Lombre", //Pokemon 3, Serious, Female
                "Female", 12, 127);

            Pokemon_List.Rows.Add("Makuhita (XD)",
                63, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Kecleon", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Surskit", //Pokemon 2, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Vulpix (XD)",
                191, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Spinarak", //Pokemon 1, Hardy, Male
                "Male", 0, 127,

                "Beautifly", //Pokemon 2, Docile, Female
                "Female", 6, 127,

                "Dustox", //Pokemon 3, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Duskull (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Sneasel", //Pokemon 1, Serious, Male
                "Male", 12, 127,

                "Yanma", //Pokemon 2, Bashful, Female
                "Female", 18, 127,

                "Misdreavus", //Pokemon 3, Quirky, Male
                "Male", 24, 127);

            Pokemon_List.Rows.Add("Mawile (XD)",
                63, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Loudred", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Girafarig", //Pokemon 2, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Snorunt (XD)",
                127, //Gender Threshold
                1, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Seviper", //Pokemon 1, Docile, Female
                "Female", 6, 127);

            Pokemon_List.Rows.Add("Pineco (XD)",
                127, //Gender Threshold
                1, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Murkrow", //Pokemon 1, Docile, Male
                "Male", 6, 127);

            Pokemon_List.Rows.Add("Natu (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Kirlia", //Pokemon 1, Hardy, Male
                "Male", 0, 127,

                "Linoone", //Pokemon 2, Hardy, Female
                "Female", 0, 127);

            Pokemon_List.Rows.Add("Roselia (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Remoraid", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Golbat", //Pokemon 2, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Meowth (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Kadabra", //Pokemon 1, Docile, Male
                "Male", 6, 63,

                "Sneasel", //Pokemon 2, Hardy, Female
                "Female", 0, 127,

                "Misdreavus", //Pokemon 3, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Swinub (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Torkoal", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Nuzleaf", //Pokemon 2, Hardy, Male
                "Male", 0, 127);

            Pokemon_List.Rows.Add("Spearow (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Pelipper", //Pokemon 1, Bashful, Male
                "Male", 18, 127,

                "Electrike", //Pokemon 2, Docile, Female
                "Female", 6, 127);

            Pokemon_List.Rows.Add("Grimer (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Chimecho", //Pokemon 1, Serious, Male
                "Male", 12, 127,

                "Stantler", //Pokemon 2, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Seel (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Hoothoot", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Graveller", //Pokemon 2, Bashful, Male
                "Male", 18, 127,

                "Gulpin", //Pokemon 3, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Lunatone (XD)",
                256, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Lanturn", //Pokemon 1, Hardy, Female
                "Female", 0, 127,

                "Quagsire", //Pokemon 2, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Zangoose (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Nosepass (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Lombre", //Pokemon 1, Hardy, Male
                "Male", 0, 127,

                "Lombre", //Pokemon 2, Bashful, Male
                "Male", 18, 127,

                "Lombre", //Pokemon 3, Serious, Female
                "Female", 12, 127);

            Pokemon_List.Rows.Add("Togepi (XD)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Paras (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Seviper", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Murkrow", //Pokemon 2, Docile, Female
                "Female", 6, 127);

            Pokemon_List.Rows.Add("Growlithe (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Seviper", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Murkrow", //Pokemon 2, Docile, Female
                "Female", 6, 127,

                "Shadow Paras", //Pokemon 3, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Growlithe -Paras Seen- (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Seviper", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Murkrow", //Pokemon 2, Docile, Female
                "Female", 6, 127,

                "Shadow Paras", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Shellder (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Beedrill (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Pidgeotto (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Beedrill", //Pokemon 1, Shadow
                "Genderless", 25, 256,

                "Furret", //Pokemon 2, Serious, Male
                "Male", 12, 127,

                "Togetic", //Pokemon 3, Bashful, Male
                "Male", 18, 31);

            Pokemon_List.Rows.Add("Pidgeotto -Beedrill Seen- (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Beedrill", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Furret", //Pokemon 2, Serious, Male
                "Male", 12, 127,

                "Togetic", //Pokemon 3, Bashful, Male
                "Male", 18, 31);

            Pokemon_List.Rows.Add("Tangela (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninetales", //Pokemon 1, Serious, Male
                "Male", 12, 191,

                "Jumpluff", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Azumarill", //Pokemon 3, Hardy, Female
                "Female", 0, 127);

            Pokemon_List.Rows.Add("Butterfree (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninetales", //Pokemon 1, Serious, Male
                "Male", 12, 191,

                "Jumpluff", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Azumarill", //Pokemon 3, Hardy, Female
                "Female", 0, 127,

                "Shadow Tangela", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Butterfree -Tangela Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninetales", //Pokemon 1, Serious, Male
                "Male", 12, 191,

                "Jumpluff", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Azumarill", //Pokemon 3, Hardy, Female
                "Female", 0, 127,

                "Shadow Tangela", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Magneton (XD)",
                256, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shedinja", //Pokemon 1, Bashful, Genderless
                "Genderless", 18, 256,

                "Wobbuffet", //Pokemon 2, Hardy, Male
                "Male", 0, 127,

                "Vibrava", //Pokemon 3, Serious, Female
                "Female", 12, 127);

            Pokemon_List.Rows.Add("Venomoth (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Golduck", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Hitmontop", //Pokemon 2, Quirky, Male
                "Male", 24, 0,

                "Hariyama", //Pokemon 3, Serious, Male
                "Male", 12, 63);

            Pokemon_List.Rows.Add("Weepinbell (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Golduck", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Hitmontop", //Pokemon 2, Quirky, Male
                "Male", 24, 0,

                "Hariyama", //Pokemon 3, Serious, Male
                "Male", 12, 63,

                "Shadow Venomoth", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Weepinbell -Venomoth Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Golduck", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Hitmontop", //Pokemon 2, Quirky, Male
                "Male", 24, 0,

                "Hariyama", //Pokemon 3, Serious, Male
                "Male", 12, 63,

                "Shadow Venomoth", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Arbok (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Huntail", //Pokemon 1, Docile, Male
                "Male", 6, 127,

                "Cacturne", //Pokemon 2, Hardy, Female
                "Female", 0, 127,

                "Weezing", //Pokemon 3, Serious, Female
                "Female", 12, 127,

                "Ursaring", //Pokemon 4, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Primeape (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Lairon", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Sealeo", //Pokemon 2, Serious, Female
                "Female", 12, 127,

                "Slowking", //Pokemon 3, Docile, Female
                "Female", 6, 127,

                "Ursaring", //Pokemon 4, Quirky, Male
                "Male", 24, 127);

            Pokemon_List.Rows.Add("Hypno (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Lairon", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Sealeo", //Pokemon 2, Serious, Female
                "Female", 12, 127,

                "Slowking", //Pokemon 3, Docile, Female
                "Female", 6, 127,

                "Ursaring", //Pokemon 4, Quirky, Male
                "Male", 24, 127,

                "Shadow Primeape", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Hypno -Primeape Seen- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Lairon", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Sealeo", //Pokemon 2, Serious, Female
                "Female", 12, 127,

                "Slowking", //Pokemon 3, Docile, Female
                "Female", 6, 127,

                "Ursaring", //Pokemon 4, Quirky, Male
                "Male", 24, 127,

                "Shadow Primeape", //Pokemon 5, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Golduck (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Crawdaunt", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Pelipper", //Pokemon 2, Docile, Female
                "Female", 6, 127,

                "Mantine", //Pokemon 3, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Sableye (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Crawdaunt", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Pelipper", //Pokemon 2, Docile, Female
                "Female", 6, 127,

                "Mantine", //Pokemon 3, Bashful, Female
                "Female", 18, 127,

                "Shadow Golduck", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Sableye -Golduck Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Crawdaunt", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Pelipper", //Pokemon 2, Docile, Female
                "Female", 6, 127,

                "Mantine", //Pokemon 3, Bashful, Female
                "Female", 18, 127,

                "Shadow Golduck", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Dodrio (XD)",
                127, //Gender Threshold
                1, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Xatu", //Pokemon 1, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Raticate (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Xatu", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Shadow Dodrio", //Pokemon 2, Shadow
                "Genderless", 25, 256,

                "Whiscash", //Pokemon 3, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Raticate -Dodrio Seen- (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Xatu", //Pokemon 1, Bashful, Female
                "Female", 18, 127,

                "Shadow Dodrio", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Whiscash", //Pokemon 3, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Fargetch'd (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Gardevoir", //Pokemon 1, Serious, Male
                "Male", 12, 127,

                "Gorebyss", //Pokemon 2, Hardy, Female
                "Female", 0, 127,

                "Roselia", //Pokemon 3, Quirky, Male
                "Male", 24, 127);

            Pokemon_List.Rows.Add("Altaria (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Gardevoir", //Pokemon 1, Serious, Male
                "Male", 12, 127,

                "Gorebyss", //Pokemon 2, Hardy, Female
                "Female", 0, 127,

                "Roselia", //Pokemon 3, Quirky, Male
                "Male", 24, 127,

                "Shadow Farfetch'd", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Altaria -Farfetch'd Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Gardevoir", //Pokemon 1, Serious, Male
                "Male", 12, 127,

                "Gorebyss", //Pokemon 2, Hardy, Female
                "Female", 0, 127,

                "Roselia", //Pokemon 3, Quirky, Male
                "Male", 24, 127,

                "Shadow Farfetch'd", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Kangaskhan (XD)",
                255, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Electrode", //Pokemon 1, Hardy, Genderless
                "Genderless", 18, 127,

                "Misdreavus", //Pokemon 2, Bashful, Female
                "Female", 25, 256,

                "Claydol", //Pokemon 3, Serious, Genderless
                "Genderless", 18, 127);

            Pokemon_List.Rows.Add("Banette (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Electrode", //Pokemon 1, Hardy, Genderless
                "Genderless", 18, 127,

                "Misdreavus", //Pokemon 2, Bashful, Female
                "Female", 25, 256,

                "Claydol", //Pokemon 3, Serious, Genderless
                "Genderless", 18, 127,

                "Shadow Kangaskhan", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Banette -Kangaskhan Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Electrode", //Pokemon 1, Hardy, Genderless
                "Genderless", 18, 127,

                "Misdreavus", //Pokemon 2, Bashful, Female
                "Female", 25, 256,

                "Claydol", //Pokemon 3, Serious, Genderless
                "Genderless", 18, 127,

                "Shadow Kangaskhan", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Magmar (XD)",
                63, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Houndoom", //Pokemon 1, Bashful, Male
                "Male", 18, 127,

                "Ninetales", //Pokemon 2, Bashful, Male
                "Male", 18, 191,

                "Vileplume", //Pokemon 3, Hardy, Female
                "Female", 0, 127);

            Pokemon_List.Rows.Add("Pinsir (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Houndoom", //Pokemon 1, Bashful, Male
                "Male", 18, 127,

                "Ninetales", //Pokemon 2, Bashful, Male
                "Male", 18, 191,

                "Vileplume", //Pokemon 3, Hardy, Female
                "Female", 0, 127,

                "Shadow Magmar", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Pinsir -Magmar Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Houndoom", //Pokemon 1, Bashful, Male
                "Male", 18, 127,

                "Ninetales", //Pokemon 2, Bashful, Male
                "Male", 18, 191,

                "Vileplume", //Pokemon 3, Hardy, Female
                "Female", 0, 127,

                "Shadow Magmar", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Rapidash (XD)",
                127, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Camerupt", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Weezing", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Muk", //Pokemon 3, Serious, Female
                "Female", 12, 127);

            Pokemon_List.Rows.Add("Magcargo (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Camerupt", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Weezing", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Muk", //Pokemon 3, Serious, Female
                "Female", 12, 127,

                "Shadow Rapidash", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Magcargo -Rapidash Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Camerupt", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Weezing", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Muk", //Pokemon 3, Serious, Female
                "Female", 12, 127,

                "Shadow Rapidash", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Hitmonchan (XD)",
                0, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Medicham", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Golem", //Pokemon 2, Docile, Female
                "Female", 6, 127,

                "Xatu", //Pokemon 3, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Hitmonlee (XD)",
                0, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Grumpig", //Pokemon 1, Quirky, Male
                "Male", 18, 127,

                "Skarmory", //Pokemon 2, Docile, Male
                "Male", 12, 127,

                "Metang", //Pokemon 3, Serious, Female
                "Genderless", 6, 256,

                "Hariyama", //Pokemon 4, Bashful, Female
                "Female", 24, 63);

            Pokemon_List.Rows.Add("Lickitung (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Lanturn", //Pokemon 1, Quirky, Male
                "Male", 24, 127,

                "Magneton", //Pokemon 2, Docile, Genderless
                "Genderless", 6, 256);

            Pokemon_List.Rows.Add("Scyther (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Stantler", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Exploud", //Pokemon 2, Quirky, Male
                "Male", 24, 256);

            Pokemon_List.Rows.Add("Chansey (XD)",
                255, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Stantler", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Exploud", //Pokemon 2, Quirky, Male
                "Male", 24, 256,

                "Shadow Scyther", //Pokemon 3, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Chansey -Scyther Seen- (XD)",
                255, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Stantler", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Exploud", //Pokemon 2, Quirky, Male
                "Male", 24, 256,

                "Shadow Scyther", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Solrock (XD)",
                256, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Metang", //Pokemon 1, Quirky, Genderless
                "Genderless", 24, 256,

                "Quagsire", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Scizor", //Pokemon 3, Hardy, Female
                "Female", 0, 127);

            Pokemon_List.Rows.Add("Starmie (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Metang", //Pokemon 1, Quirky, Genderless
                "Genderless", 24, 256,

                "Quagsire", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Scizor", //Pokemon 3, Hardy, Female
                "Female", 0, 127,

                "Shadow Solrock", //Pokemon 4, Shadow
                "Genderless", 25, 256,

                "Castform", //Pokemon 5, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Starmie -Solrock Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Metang", //Pokemon 1, Quirky, Genderless
                "Genderless", 24, 256,

                "Quagsire", //Pokemon 2, Docile, Male
                "Male", 6, 127,

                "Scizor", //Pokemon 3, Hardy, Female
                "Female", 0, 127,

                "Shadow Solrock", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256,

                "Castform", //Pokemon 5, Bashful, Male
                "Male", 18, 127);

            Pokemon_List.Rows.Add("Swellow (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Electabuzz (XD)",
                63, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Swellow", //Pokemon 1, Shadow
                "Genderless", 25, 256,

                "Alakazam", //Pokemon 2, Serious, Male
                "Male", 12, 63,

                "Kingdra", //Pokemon 3, Bashful, Female
                "Female", 18, 127,

                "Heracross", //Pokemon 4, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Electabuzz -Swellow Seen- (XD)",
                63, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Swellow", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Alakazam", //Pokemon 2, Serious, Male
                "Male", 12, 63,

                "Kingdra", //Pokemon 3, Bashful, Female
                "Female", 18, 127,

                "Heracross", //Pokemon 4, Bashful, Female
                "Female", 18, 127);

            Pokemon_List.Rows.Add("Snorlax (XD)",
                31, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Swellow", //Pokemon 1, Shadow
                "Genderless", 25, 256,

                "Alakazam", //Pokemon 2, Serious, Male
                "Male", 12, 63,

                "Kingdra", //Pokemon 3, Bashful, Female
                "Female", 18, 127,

                "Heracross", //Pokemon 4, Bashful, Female
                "Female", 18, 127,

                "Shadow Electabuzz", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Snorlax -Swellow Seen- (XD)",
                31, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Swellow", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Alakazam", //Pokemon 2, Serious, Male
                "Male", 12, 63,

                "Kingdra", //Pokemon 3, Bashful, Female
                "Female", 18, 127,

                "Heracross", //Pokemon 4, Bashful, Female
                "Female", 18, 127,

                "Shadow Electabuzz", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Snorlax -Swellow & Electabuzz Seen- (XD)",
                31, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Swellow", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Alakazam", //Pokemon 2, Serious, Male
                "Male", 12, 63,

                "Kingdra", //Pokemon 3, Bashful, Female
                "Female", 18, 127,

                "Heracross", //Pokemon 4, Bashful, Female
                "Female", 18, 127,

                "Shadow Electabuzz", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Poliwrath (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Slowking", //Pokemon 1, Bashful, Male
                "Male", 18, 127,

                "Ursaring", //Pokemon 2, Bashful, Male
                "Male", 18, 127,

                "Aggron", //Pokemon 3, Quirky, Male
                "Male", 24, 127,

                "Walrein", //Pokemon 4, Docile, Female
                "Female", 6, 127);

            Pokemon_List.Rows.Add("Mr. Mime (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Slowking", //Pokemon 1, Bashful, Male
                "Male", 18, 127,

                "Ursaring", //Pokemon 2, Bashful, Male
                "Male", 18, 127,

                "Aggron", //Pokemon 3, Quirky, Male
                "Male", 24, 127,

                "Walrein", //Pokemon 4, Docile, Female
                "Female", 6, 127,

                "Shadow Poliwrath", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Mr. Mime -Poliwrath Seen- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Slowking", //Pokemon 1, Bashful, Male
                "Male", 18, 127,

                "Ursaring", //Pokemon 2, Bashful, Male
                "Male", 18, 127,

                "Aggron", //Pokemon 3, Quirky, Male
                "Male", 24, 127,

                "Walrein", //Pokemon 4, Docile, Female
                "Female", 6, 127,

                "Shadow Poliwrath", //Pokemon 5, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Dugtrio (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Glalie", //Pokemon 1, Hardy, Male
                "Male", 0, 127,

                "Ampharos", //Pokemon 2, Bashful, Male
                "Male", 18, 127,

                "Breloom", //Pokemon 3, Docile, Female
                "Male", 6, 127,

                "Donphan", //Pokemon 4, Serious, Male
                "Female", 12, 127);

            Pokemon_List.Rows.Add("Manectric (XD)",
                127, //Gender Threshold
                1, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127);

            Pokemon_List.Rows.Add("Salamence (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Marowak (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow
                "Genderless", 25, 256,

                "Shadow Salamence", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Flygon", //Pokemon 4, Quirky, Male
                "Male", 24, 127);

            Pokemon_List.Rows.Add("Lapras (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow
                "Genderless", 25, 256,

                "Shadow Salamence", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Flygon", //Pokemon 4, Quirky, Male
                "Male", 24, 127,

                "Shadow Marowak", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Salamence -Manectric Seen- (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Marowak -Manectric Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Salamence", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Flygon", //Pokemon 4, Quirky, Male
                "Male", 24, 127);

            Pokemon_List.Rows.Add("Marowak -Manectric & Salamence Seen- (XD)",
                127, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Salamence", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Flygon", //Pokemon 4, Quirky, Male
                "Male", 24, 127);

            Pokemon_List.Rows.Add("Lapras -Manectric Seen- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Salamence", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Flygon", //Pokemon 4, Quirky, Male
                "Male", 24, 127,

                "Shadow Marowak", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Lapras -Manectric & Salamence Seen- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Salamence", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Flygon", //Pokemon 4, Quirky, Male
                "Male", 24, 127,

                "Shadow Marowak", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Lapras -Manectric & Marowak Seen- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Salamence", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Flygon", //Pokemon 4, Quirky, Male
                "Male", 24, 127,

                "Shadow Marowak", //Pokemon 5, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Lapras -Manectric & Salamence & Marowak Seen- (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ninjask", //Pokemon 1, Docile, Female
                "Female", 6, 127,

                "Shadow Manectric", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Salamence", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Flygon", //Pokemon 4, Quirky, Male
                "Male", 24, 127,

                "Shadow Marowak", //Pokemon 5, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Lugia (XD)",
                256, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Rhydon (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Moltres (XD)",
                256, //Gender Threshold
                1, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Exeggutor (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow
                "Genderless", 25, 256,

                "Shadow Moltres", //Pokemon 2, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Tauros (XD)",
                0, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow
                "Genderless", 25, 256,

                "Shadow Moltres", //Pokemon 2, Shadow
                "Genderless", 25, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Articuno (XD)",
                0, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow
                "Genderless", 25, 256,

                "Shadow Moltres", //Pokemon 2, Shadow
                "Genderless", 25, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Shadow Tauros", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Zapdos (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow
                "Genderless", 25, 256,

                "Shadow Moltres", //Pokemon 2, Shadow
                "Genderless", 25, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Shadow Tauros", //Pokemon 4, Shadow
                "Genderless", 25, 256,

                "Shadow Articuno", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Exeggutor -Rhydon & Moltres Seen- (XD)",
                127, //Gender Threshold
                2, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Tauros -Rhydon & Moltres Seen- (XD)",
                0, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Tauros -Rhydon & Moltres & Exeggutor Seen- (XD)",
                0, //Gender Threshold
                3, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Articuno -Rhydon & Moltres Seen- (XD)",
                0, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Shadow Tauros", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Articuno -Rhydon & Moltres & Tauros Seen- (XD)",
                0, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Shadow Tauros", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Articuno -Rhydon & Moltres & Exeggutor Seen- (XD)",
                0, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Tauros", //Pokemon 4, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Articuno -Rhydon & Moltres & Exeggutor & Tauros Seen- (XD)",
                0, //Gender Threshold
                4, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Tauros", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Zapdos -Rhydon & Moltres Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Shadow Tauros", //Pokemon 4, Shadow
                "Genderless", 25, 256,

                "Shadow Articuno", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Zapdos -Rhydon & Moltres & Tauros Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Shadow Tauros", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Articuno", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Zapdos -Rhydon & Moltres & Articuno Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Shadow Tauros", //Pokemon 4, Shadow
                "Genderless", 25, 256,

                "Shadow Articuno", //Pokemon 5, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Zapdos -Rhydon & Moltres & Exeggutor Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Tauros", //Pokemon 4, Shadow
                "Genderless", 25, 256,

                "Shadow Articuno", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Zapdos -Rhydon & Moltres & Tauros & Articuno Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow
                "Genderless", 25, 256,

                "Shadow Tauros", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Articuno", //Pokemon 5, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Zapdos -Rhydon & Moltres Exeggutor & Tauros Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Tauros", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Articuno", //Pokemon 5, Shadow
                "Genderless", 25, 256);

            Pokemon_List.Rows.Add("Zapdos -Rhydon & Moltres & Exeggutor & Articuno Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Tauros", //Pokemon 4, Shadow
                "Genderless", 25, 256,

                "Shadow Articuno", //Pokemon 5, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Zapdos -Rhydon & Moltres & Exeggutor & Tauros & Articuno Seen- (XD)",
                256, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Shadow Rhydon", //Pokemon 1, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Moltres", //Pokemon 2, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Exeggutor", //Pokemon 3, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Tauros", //Pokemon 4, Shadow -Seen-
                "Genderless", 26, 256,

                "Shadow Articuno", //Pokemon 5, Shadow -Seen-
                "Genderless", 26, 256);

            Pokemon_List.Rows.Add("Dragonite (XD)",
                127, //Gender Threshold
                5, //Number of pokemon before Shadow
                0, //1 = Shiny Allowed
                -1, //Shiny Value

                "Ludicolo", //Pokemon 1, Hardy, Male
                "Male", 0, 127,

                "Ludicolo", //Pokemon 2, Bashful, Male
                "Male", 18, 127,

                "Ludicolo", //Pokemon 3, Serious, Female
                "Female", 12, 127,

                "Ludicolo", //Pokemon 4, Serious, Female
                "Female", 12, 127,

                "Ludicolo", //Pokemon 5, Hardy, Male
                "Male", 0, 127);

            Pokemon_List.Rows.Add("Chikorita (XD)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Cyndaquil (XD)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Totodile (XD)",
                31, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                -1); //Shiny Value

            Pokemon_List.Rows.Add("Meditite (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                2993); //Shiny Value

            Pokemon_List.Rows.Add("Shuckle (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                2993); //Shiny Value

            Pokemon_List.Rows.Add("Larvitar (XD)",
                127, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                2993); //Shiny Value

            Pokemon_List.Rows.Add("Elekid (XD)",
                63, //Gender Threshold
                0, //Number of pokemon before Shadow
                1, //1 = Shiny Allowed
                3493); //Shiny Value

            DataView AZ = Pokemon_List.DefaultView;
            AZ.Sort = "Pokemon";
            Pokemon_List = AZ.ToTable();
            ComboBox1.DataSource = Pokemon_List;
            ComboBox1.DisplayMember = "Pokemon";
            SelectGender.SelectedIndex = ComboBox1.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker1.RunWorkerAsync();
            IsStarter = Button1.Enabled = false;
            SelectedPokemon = ComboBox1.SelectedIndex;
            if (Silent.Checked == false) { RunSilent = false; } else { RunSilent = true; }
            if (CSV.Checked == false) { OutputCSV = false; } else { OutputCSV = true; }
            GenderThreshold[0] = (uint)Pokemon_List.Rows[SelectedPokemon]["Gender_Threshold"];
            HasLock = (uint)Pokemon_List.Rows[SelectedPokemon]["Lock"];
            AllowShiny = (uint)Pokemon_List.Rows[SelectedPokemon]["AllowShiny"];
            for (uint i = 1; i <= HasLock; i++)
            {
                Gender[i] = (string)Pokemon_List.Rows[SelectedPokemon][$"Shadow{i}_Gender"];
                Nature[i] = (uint)Pokemon_List.Rows[SelectedPokemon][$"Shadow{i}_Nature"];
                GenderThreshold[i] = (uint)Pokemon_List.Rows[SelectedPokemon][$"Shadow{i}_Gender_Threshold"];
            }
            MAX_HP_IV = (uint)HP_Max.Value;
            MAX_Attack_IV = (uint)ATK_Max.Value;
            MAX_Defense_IV = (uint)DEF_Max.Value;
            MAX_Special_Attack_IV = (uint)SPA_Max.Value;
            MAX_Special_Defense_IV = (uint)SPD_Max.Value;
            MAX_Speed_IV = (uint)SPE_Max.Value;
            MIN_HP_IV = (uint)HP_Min.Value;
            MIN_Attack_IV = (uint)ATK_Min.Value;
            MIN_Defense_IV = (uint)DEF_Min.Value;
            MIN_Special_Attack_IV = (uint)SPA_Min.Value;
            MIN_Special_Defense_IV = (uint)SPD_Min.Value;
            MIN_Speed_IV = (uint)SPE_Min.Value;
            MAX_IV_Sum = (uint)SUM_Max.Value;
            MIN_IV_Sum = (uint)SUM_Min.Value;
            MAX_HiddenPowerStrength = (uint)HID_Max.Value;
            MIN_HiddenPowerStrength = (uint)HID_Min.Value;
            PokemonGenderTarget = SelectGender.SelectedItem.ToString();
            for (int i = 0; i < Selected_Nature.Length; i++) { if (NatureComboBox.GetItemCheckState(i) == CheckState.Checked) { Selected_Nature[i] = 1; } else { Selected_Nature[i] = 0; } }
            if (Selected_Nature.Sum() == 0) { for (int i = 0; i < Selected_Nature.Length; i++) { Selected_Nature[i] = 1; } }
            for (int i = 0; i < Selected_Characteristic.Length; i++) { if (CharacteristicComboBox.GetItemCheckState(i) == CheckState.Checked) { Selected_Characteristic[i] = 1; } else { Selected_Characteristic[i] = 0; } }
            if (Selected_Characteristic.Sum() == 0) { for (int i = 0; i < Selected_Characteristic.Length; i++) { Selected_Characteristic[i] = 1; } }
            for (int i = 0; i < Selected_HiddenPowerType.Length; i++) { if (HiddenPowerComboBox.GetItemCheckState(i) == CheckState.Checked) { Selected_HiddenPowerType[i] = 1; } else { Selected_HiddenPowerType[i] = 0; } }
            if (Selected_HiddenPowerType.Sum() == 0) { for (int i = 0; i < Selected_HiddenPowerType.Length; i++) { Selected_HiddenPowerType[i] = 1; } }
            if (PT.Checked == true) { ForceShiny = 6; }
            else if (P1.Checked == true) { ForceShiny = 1; }
            else if (P2.Checked == true) { ForceShiny = 2; }
            else if (P3.Checked == true) { ForceShiny = 3; }
            else if (P4.Checked == true) { ForceShiny = 4; }
            else if (P5.Checked == true) { ForceShiny = 5; }
            else { ForceShiny = 0; }
            if (InitialSeed.Text.Length < 1) { startseed = 0; } else { startseed = uint.Parse(InitialSeed.Text, System.Globalization.NumberStyles.AllowHexSpecifier); }
            if (EnableLimit.Checked == true) { maxseed = startseed + (uint)ResultsLimit.Value; progval = (uint)ResultsLimit.Value / 101; } else { maxseed = startseed + 4294967295; progval = 42524427; }
            progtick = 0;
            if (TID_Match.Checked == true) { TSID[0] = 1; TSID[1] = (int)TSVal.Value; } else if ((int)Pokemon_List.Rows[SelectedPokemon][$"ShinyValue"] > -1) { TSID[0] = 1; TSID[1] = (int)Pokemon_List.Rows[SelectedPokemon][$"ShinyValue"]; } else { TSID[0] = 0; }
            if (ETID_Check.Checked == true) { StarterTID[0] = 1; StarterTID[1] = (uint)ETID_Val.Value; } else { StarterTID[0] = 0; }
            MustBeShiny = ShinyOnly.Checked;
            switch ((string)Pokemon_List.Rows[SelectedPokemon]["Pokemon"]) { case string p when (p == "Eevee (XD)" || p == "Espeon (Colosseum)" || p == "Umbreon (Colosseum)"): IsStarter = true; break; }
            DataGridView1.Columns.Clear();
            DataGridView1.Columns.Add("EncounterSeed", "Encounter Seed");
            if (IsStarter == true) { DataGridView1.Columns.Add("StarterTID", "Trainer ID"); DataGridView1.Columns.Add("StarterSID", "Secret ID"); }
            DataGridView1.Columns.Add("PokemonSeed", "Pokémon Seed");
            DataGridView1.Columns.Add("PID", "PID");
            if ((uint)Pokemon_List.Rows[SelectedPokemon]["AllowShiny"] == 0) { DataGridView1.Columns.Add("ReRollTSV", "ReRoll TSV"); } else { DataGridView1.Columns.Add("ShinyTSV", "Shiny TSV"); }
            DataGridView1.Columns.Add("Nature", "Nature");
            DataGridView1.Columns.Add("Gender", "Gender");
            DataGridView1.Columns.Add("HP", "HP");
            DataGridView1.Columns.Add("Attack", "Attack");
            DataGridView1.Columns.Add("Defense", "Defense");
            DataGridView1.Columns.Add("SpecialAttack", "Special Attack");
            DataGridView1.Columns.Add("SpecialDefense", "Special Defense");
            DataGridView1.Columns.Add("Speed", "Speed");
            DataGridView1.Columns.Add("HiddenPower", "Hidden Power");
            DataGridView1.Columns.Add("Characteristic", "Characteristic");
            if (HasLock > 0) { for (uint i = 1; i <= HasLock; i++) { DataGridView1.Columns.Add($"PatternPokemon{i}", $"Pattern Pokemon {i}"); } }
            if (RunSilent == true) { DataGridView1.Rows.Add("Running silently. Check CSV for output..."); }
            seedtick = startseed;
            if (OutputCSV == true)
            {
                date = DateTime.Now.ToString("yyyyMMddhhmmss");
                string Line = DataGridView1.Columns[0].Name;
                for (int i = 1; i < DataGridView1.ColumnCount; i++)
                {
                    Line = Line + "," + DataGridView1.Columns[i].Name;
                }
                System.IO.File.AppendAllText("Results(" + (string)Pokemon_List.Rows[SelectedPokemon][$"Pokemon"] + ") " + date + ".csv", Line + "\r" + (string)Pokemon_List.Rows[SelectedPokemon][$"Pokemon"] + "\r");
            }
            Cursor = Cursors.WaitCursor;
            Halt = 0;
            ProgBar.ProgressBar1.Value = 0;
            ProgBar.Cancel.Enabled = true;
            ProgBar.Top = Top + (Height / 2) - 57;
            ProgBar.Left = Left + (Width / 2) - 111;
            ProgBar.Visible = true;
            while (seedtick != maxseed && Halt != 5) { if (ProgBar.Cancel.Enabled == true) { StartSearch(); } else { Halt = 5; } seedtick++; progtick++; }
            if (Halt != 5) { StartSearch(); }
            Cursor = Cursors.Default;
            ProgBar.Visible = false;
            Button1.Enabled = true;
        }

        private void StartSearch()
        {
            Halt = 0;
            ReRollTSV = "None";
            if (TSID[0] == 1)
            {
                TrainerShinyValue = (uint)TSID[1];
            }
            else
            {
                TrainerShinyValue = 9001;
            }
            SpreadFinder();
            if (Halt == 0)
            {
                WriteOut();
            }
            if (progtick == progval)
            {
                ProgBar.ProgressBar1.PerformStep();
                progtick = 0;
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            P1.Checked = P2.Checked = P3.Checked = P4.Checked = P5.Checked = PT.Checked = TID_Match.Checked = ETID_Check.Checked = ShinyOnly.Checked = ForceLabel.Enabled = SelectGender.Enabled = P1.Enabled = P2.Enabled = P3.Enabled = P4.Enabled = P5.Enabled = PT.Enabled = TID_Match.Enabled = EPSV_Label.Enabled = ETID_Check.Enabled = ShinyOnly.Enabled = false;
            if ((uint)Pokemon_List.Rows[ComboBox1.SelectedIndex]["AllowShiny"] == 0 && (string)Pokemon_List.Rows[ComboBox1.SelectedIndex]["Pokemon"] != "Umbreon (Colosseum)" && (string)Pokemon_List.Rows[ComboBox1.SelectedIndex]["Pokemon"] != "Espeon (Colosseum)")
            {
                ForceLabel.Enabled = TID_Match.Enabled = PT.Enabled = true;
                for (uint i = 1; i <= (uint)Pokemon_List.Rows[ComboBox1.SelectedIndex]["Lock"]; i++)
                {
                    if (i == 1) { P1.Enabled = true; }
                    if (i == 2) { P2.Enabled = true; }
                    if (i == 3) { P3.Enabled = true; }
                    if (i == 4) { P4.Enabled = true; }
                    if (i == 5) { P5.Enabled = true; }
                }
                for (uint i = 1; i < (uint)Pokemon_List.Rows[ComboBox1.SelectedIndex]["Lock"]; i++)
                {
                    if (i == 1 && (uint)Pokemon_List.Rows[ComboBox1.SelectedIndex][$"Shadow1_Nature"] == 26) { P1.Enabled = false; }
                    if (i == 2 && (uint)Pokemon_List.Rows[ComboBox1.SelectedIndex][$"Shadow2_Nature"] == 26) { P2.Enabled = false; }
                    if (i == 3 && (uint)Pokemon_List.Rows[ComboBox1.SelectedIndex][$"Shadow3_Nature"] == 26) { P3.Enabled = false; }
                    if (i == 4 && (uint)Pokemon_List.Rows[ComboBox1.SelectedIndex][$"Shadow4_Nature"] == 26) { P4.Enabled = false; }
                    if (i == 5 && (uint)Pokemon_List.Rows[ComboBox1.SelectedIndex][$"Shadow5_Nature"] == 26) { P5.Enabled = false; }
                }
            }
            else if ((uint)Pokemon_List.Rows[ComboBox1.SelectedIndex]["AllowShiny"] == 1)
            {
                if ((string)Pokemon_List.Rows[ComboBox1.SelectedIndex]["Pokemon"] != "Eevee (XD)")
                {
                    TID_Match.Enabled = true;
                }
                    ShinyOnly.Enabled = true;
            }
            switch ((uint)Pokemon_List.Rows[ComboBox1.SelectedIndex]["Gender_Threshold"])
            {
                case 0: SelectGender.SelectedIndex = 1; break;
                case 255: SelectGender.SelectedIndex = 2; break;
                case uint n when (n > 255): SelectGender.SelectedIndex = 0; break;
                case uint n when (n > 0 && n < 255): SelectGender.Enabled = true; break;
            }
            switch ((string)Pokemon_List.Rows[ComboBox1.SelectedIndex]["Pokemon"])
            {
                case string p when (p == "Eevee (XD)" || p == "Espeon (Colosseum)" || p == "Umbreon (Colosseum)"): EPSV_Label.Enabled = ETID_Check.Enabled = true; break;
            }
            if ((int)Pokemon_List.Rows[ComboBox1.SelectedIndex][$"ShinyValue"] > -1)
            {
                PT.Enabled = ForceLabel.Enabled = TID_Match.Enabled = false;
            }
        }

        private void ForceCheck()
        {
            TID_Match.Checked = P1.Checked = P2.Checked = P3.Checked = P4.Checked = P5.Checked = PT.Checked = false;
        }

        private void TID_Match_Click(object sender, EventArgs e)
        {
            if (TID_Match.Checked == true)
            {
                ForceCheck();
                TID_Match.Checked = true;
            }
        }

        private void TID_Match_CheckStateChanged(object sender, EventArgs e)
        {
            TSV_Label.Enabled = TSVal.Enabled = TID.Enabled = SID.Enabled = TID_Label.Enabled = SID_Label.Enabled = TID_Match.Checked;
        }

        private void ETID_Check_CheckStateChanged(object sender, EventArgs e)
        {
            ETID_Val.Enabled = ETID_Check.Checked;
        }

        private void EnableLimit_CheckStateChanged(object sender, EventArgs e)
        {
            ResultsLimit.Enabled = EnableLimit.Checked;
        }

        private void PT_Click(object sender, EventArgs e)
        {
            if (PT.Checked == true)
            {
                ForceCheck();
                PT.Checked = true;
            }
        }

        private void P1_Click(object sender, EventArgs e)
        {
            if (P1.Checked == true)
            {
                ForceCheck();
                P1.Checked = true;
            }
        }

        private void P2_Click(object sender, EventArgs e)
        {
            if (P2.Checked == true)
            {
                ForceCheck();
                P2.Checked = true;
            }
        }

        private void P3_Click(object sender, EventArgs e)
        {
            if (P3.Checked == true)
            {
                ForceCheck();
                P3.Checked = true;
            }
        }

        private void P4_Click(object sender, EventArgs e)
        {
            if (P4.Checked == true)
            {
                ForceCheck();
                P4.Checked = true;
            }
        }

        private void P5_Click(object sender, EventArgs e)
        {
            if (P5.Checked == true)
            {
                ForceCheck();
                P5.Checked = true;
            }
        }

        private void IVMinLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HP_Min.Value = ATK_Min.Value = DEF_Min.Value = SPA_Min.Value = SPD_Min.Value = SPE_Min.Value = 0;
        }

        private void IVMaxLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HP_Max.Value = ATK_Max.Value = DEF_Max.Value = SPA_Max.Value = SPD_Max.Value = SPE_Max.Value = 31;
        }

        private void SumMinLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SUM_Min.Value = 0;
        }

        private void SumMaxLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SUM_Max.Value = 186;
        }

        private void NatureLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < Selected_Nature.Length; i++)
            {
                NatureComboBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void CharacterLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < Selected_Characteristic.Length; i++)
            {
                CharacteristicComboBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void HiddenPowerLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < Selected_HiddenPowerType.Length; i++)
            {
                HiddenPowerComboBox.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void HIDMinLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HID_Min.Value = 30;
        }

        private void HIDMaxLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HID_Max.Value = 70;
        }

        private void CSV_CheckStateChanged(object sender, EventArgs e)
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

        private void Silent_CheckStateChanged(object sender, EventArgs e)
        {
            if (Silent.Checked == true)
            {
                CSV.Checked = true;
            }
        }

        private void BackgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            ProgBar.ShowDialog();
            ProgBar.Visible = false;
        }

        private void TID_ValueChanged(object sender, EventArgs e)
        {
            TSVal.Value = ((int)TID.Value ^ (int)SID.Value) >> 3;
        }

        private void SID_ValueChanged(object sender, EventArgs e)
        {
            TSVal.Value = ((int)TID.Value ^ (int)SID.Value) >> 3;
        }

        private void EPSV_Label_CheckStateChanged(object sender, EventArgs e)
        {
            EPSV_Val.Enabled = EPSV_Label.Checked;
        }
    }
}
