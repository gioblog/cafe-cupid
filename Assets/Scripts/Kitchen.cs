using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Kitchen : MonoBehaviour
{
    //private Drinks caramelMac;
    //private List<string> caramelRecipe = new List<string> { "1 xpresso", "2 caramel",  "1 milk" };

    public List<Drinks> menu;

    private List<Ingredient> macRecipe;// = new List<Ingredient>() 
   // { new Ingredient ("caramel", 2), new Ingredient ("xpresso", 1), new Ingredient("milk", 1)};
    private Drinks caramelMac;// = new Drinks("caramel macciato", CupType.WarmMug, macRecipe);  

    private Ingredient caramel = new Ingredient("caramel", 0);
    private Ingredient milk = new Ingredient("milk", 0);
    private Ingredient ice = new Ingredient("ice", 0);
    private Ingredient xpresso = new Ingredient("xpresso", 0);
    public List<Ingredient> ingredientList = new List<Ingredient>();  
    
    private void Awake()
    {
        //master list of ingredients 
        ingredientList.Add(caramel);
        ingredientList.Add(milk);
        ingredientList.Add(ice);
        ingredientList.Add(xpresso);

        //master list of drink menu 
        macRecipe = new List<Ingredient>() { new Ingredient("caramel", 2), new Ingredient("xpresso", 1), new Ingredient("milk", 1) };
        caramelMac = new Drinks("caramel macciato", CupType.WarmMug, macRecipe);
        menu.Add(caramelMac); 
    }

    /// <summary>
    /// Search for the ingredient in the list and add to its amount 
    /// </summary>
    /// <param name="name"></param>
    public void AddIngredient(string name, DrinkOrder currentCup)
    {  
        for(int i = 0; i < ingredientList.Count; i++)
        {
            //when currentCup alr has that ingredient inside of its cup, but the user wants to add more
            if (!(currentCup.recipe[i] == null) && currentCup.recipe[i].Name == ingredientList[i].Name)
            {
                currentCup.recipe[i].AddAmount(); 
            }
            else if(ingredientList[i].Name == name.ToLower()) //new ingredient to add 
            {
                ingredientList[i].AddAmount();
                currentCup.recipe.Add(ingredientList[i]);
            }
        }
    }

    /// <summary>
    /// Sets all possible ingredients the user used back to zero 
    /// </summary>
    public void ResetIngredients()
    {
        for(int i = 0; i < ingredientList.Count; i++)
        {
            ingredientList[i].Amount = 0; 
        }
    }

    public void EvalCup(DrinkOrder createdDrink)
    {
       //dictionary comparion instead of list 
       //makes lookup O(n); better efficiency 
       //key -> ingredient name pair -> amt 

    }

}
