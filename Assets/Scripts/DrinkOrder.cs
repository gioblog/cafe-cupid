using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using Assets.Scripts; 



public class DrinkOrder : MonoBehaviour
{
    //drink data
    [SerializeField] private CupType drinkType;
    [SerializeField] private string drinkName;
    [SerializeField] private bool isSweet;
    [SerializeField] private bool isBitter;
    [SerializeField] private bool isDisappointing;
    [SerializeField] public List<Ingredient> recipe;
    //[SerializeField] public List<Ingredient> theRecipe;


    //bool IsSweet { get { return IsSweet; } }
    //public bool IsBitter { get { return isBitter; } }
    //bool IsDisappointing { get { return IsDisappointing; } }

    //private void Consolidate()
    //{
    //    int tracker = 0; 
    //    for(int i = 0; i < recipe.Count; i ++)
    //    {
    //        tracker = 1; 
    //        for(int j = 1; j < recipe.Count; j++)
    //        {
    //            if (recipe[i] == recipe[j])
    //            {
    //                recipe.Remove(recipe[j]);
    //                tracker++; 
    //                //recipe[i] = $"{tracker}"  //how do ik what ingredient word it is to update i? 
    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// Based on all possible drinks in the menu, identifies what drink the 
    /// player made by comparing reciepes 
    /// </summary>
    public void EvalCup()
    {
       //comparing two lists of strings where order does not matter 
       //the number in front allows me to see if they made the drink extra sweet or extra bitter or added a lot of milk 

        //based on what the recipe holds, at the end of the function the sprite should
        //change to the corresponding imagery of the drink's name 

        //additionally the bool variables should be updated as needed 
    }

    //{
    //    foreach (Drink drinkItem in baseDrinks.drinkMenu)
    //    {
    //        if (currentCup.recipe.Count == drinkItem.recipe.Count)
    //        {
    //            for (int i = 0; i < currentCup.recipe.Count; i++)
    //            {
    //                //but then how would this let the user customize the flavors of the drink?
    //                if (currentCup.recipe[i] != drinkItem.recipe[i])
    //                {
    //                    break;
    //                }

    //                if (i < currentCup.recipe.Count - 1) //every ingredient is a successful match
    //                {
    //                    currentCup.name = drinkItem.name;
    //                    return;
    //                }
    //            }
    //        }
    //    }
    //}



}


