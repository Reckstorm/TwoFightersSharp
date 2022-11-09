using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoFighters.Fighters
{
    internal abstract class AbstractFighter : IFighter
    {
        public delegate double Strike(int hitType);
        public Strike? Fight{ get; set; }
        public string Name { get; set; }
        public double? Hp { get; set; }

        public bool FlagCrit { get; set; }

        protected double Dmg;
        protected double Crit;
        protected double Block;
        protected double Dodge;

        public AbstractFighter() { }

        public double Hit(int hitType)
        {
            Random random = new Random();
            double tempNum = random.Next(1, 51);
            double tempDodgeChance = 0;
            double tempBlockChance = 0;
            double tempCritChance = 0;
            double tempDmg = 0;

            if (hitType == 1)
            {
                tempDmg = this.Dmg * 0.8;
                tempDodgeChance = tempNum * (this.Dodge - 0.05);
                tempBlockChance = tempNum * (this.Block - 0.05);
                tempCritChance = tempNum * (this.Crit + 0.05);
            }
            if (hitType == 2)
            {
                tempDmg = this.Dmg;
                tempDodgeChance = tempNum * this.Dodge;
                tempBlockChance = tempNum * this.Block;
                tempCritChance = tempNum * this.Crit;
            }
            if (hitType == 3)
            {
                tempDmg = this.Dmg * 1.2;
                tempDodgeChance = tempNum * (this.Dodge + 0.05);
                tempBlockChance = tempNum * (this.Block + 0.05);
                tempCritChance = tempNum * (this.Crit - 0.05);
            }


            if (tempDodgeChance > 20 && tempBlockChance > 20)
            {
                if (tempCritChance > 8)
                {
                    this.FlagCrit = true;
                    return tempDmg * 2;
                }
                else
                {
                    this.FlagCrit = false;
                    return tempDmg;
                }
            }

            else if (tempDodgeChance > 20
                && tempBlockChance < 20)
                return -2;
            else
                return -1;
        }
    }
}
