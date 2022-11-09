using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoFighters.Fighters
{
    internal class Fighter : AbstractFighter
    {
        public Fighter(string name = "Fighter", double dmg = 0, double crit = 0, double dodge = 0, double block = 0)
        {
            Fight = Hit;
            Name = name;
            this.Hp = 100;
            this.Dmg = dmg;
            this.Crit = crit;
            this.Block = block;
            this.Dodge = dodge;
            this.FlagCrit = false;
        }
    }
}
