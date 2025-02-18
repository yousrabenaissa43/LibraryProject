using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLsite
{
     public class RecipeBook : Book 
    {
        public int? NumberOfRecipes { get;  set; }

      
        public override string GetExtandedInfos()
        {
            return base.getInfos()+ $"contains {NumberOfRecipes} recipes" ;
        }
        public override void CalculatedExtandedValue()
        {

            if (NumberOfRecipes == 1)
            {
                Value = 1000;
            }
            else
            {
                base.CalculatedValue();
                if (NumberOfRecipes == 0)
                {
                    Environment.Exit(0); 
                }

                if (NumberOfRecipes < 50)
                {
                    Value += 20; 
                }
                else
                {
                    Value += 100; 
                }
            }

        }

    }
}
