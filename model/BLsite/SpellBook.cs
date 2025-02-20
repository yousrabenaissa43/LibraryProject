using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLsite
{
    public class SpellBook : Book
    {
        public MagicType magicType {  get;  set; }

      
      
        public override string GetExtandedInfos()
        {
           return  base.getInfos() + $"contains {magicType} spells" ; 
        }
        public override void CalculatedExtandedValue()
        {
            base.CalculatedValue();
            if(magicType == MagicType.Enchantment)
            {
                this.Value = Value * 5;
            }
            if (magicType == MagicType.Transmutation)
            {
                this.Value = Value * 15;
            }
            if (magicType == MagicType.Cruse)
            {
                this.Value = Value * 2;
            }
        }
    }
}
