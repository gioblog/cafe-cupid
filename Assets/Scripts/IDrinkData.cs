using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    //enum CupType
    //{
    //    ColdGlass,
    //    WarmMug
    //}
    internal interface IDrinkData
    {

        /// <summary>
        /// Is the drink cold or hot? 
        /// </summary>
        public CupType DrinkType { get { return DrinkType; } set { DrinkType = value; } }

        /// <summary>
        /// Is the drink sweet?
        /// </summary>
        public bool IsSweet { get { return IsSweet; }  set { IsSweet = value; } } 
        
        /// <summary>
        /// Is the drink bitter? 
        /// </summary>
        public bool IsBitter { get { return IsBitter; } set { IsBitter = value; } }

        /// <summary>
        /// Is there too much milk in the drink? 
        /// </summary>
        public bool IsDisappointing { get { return IsDisappointing; } set { IsDisappointing = value; } }


        /// <summary>
        /// List of ingredients in the drink 
        /// </summary>
        public List<string> Recipe { get; set; }

        /// <summary>
        /// Name of the drink 
        /// </summary>
        public string DrinkName { get; set; }
       

    }
}
