using System;
using System.Collections.Generic;
using System.Text;

namespace FarmGame.Model
{
    class PlayerData
    {
        public int AgricultureLevel { get; set; }
        public int DairyLevel { get; set; }
        public int ProcessingLevel { get; set; }
        public int ManagementLevel { get; set; }
        public int AgricultureExperience { get; set; }
        public int DairyExperience { get; set; }
        public int ProcessingExperience { get; set; }
        public int ManagementExperience { get; set; }
        public int Money { get; set; }
        public int Power { get; set; }
        public int MaxPower { get; set; }
        public List<Farm> farms { get; set; }
        public int[] Seed { get; set; }

        public PlayerData()
        {
            AgricultureLevel = 1;
            DairyLevel = 1;
            ProcessingLevel = 1;
            ManagementLevel = 1;
            AgricultureExperience = 0;
            DairyExperience = 0;
            ProcessingExperience = 0;
            ManagementExperience = 0;
            Money = 100;
            MaxPower = 10;
            Power = MaxPower;
            farms = new List<Farm>();
            farms.Add(new Farm());
            farms.Add(new Farm());
            farms.Add(new Farm());
            farms.Add(new Farm());
            farms.Add(new Farm());
            farms.Add(new Farm());
            farms.Add(new Farm());
            Seed = new int[2];
            Seed[0] = 3;
            Seed[1] = 3;
        }
    }
}
