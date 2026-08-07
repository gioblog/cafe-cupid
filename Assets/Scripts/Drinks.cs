using Assets.Scripts;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public enum CupType
{
    ColdGlass,
    WarmMug
}

public class Drinks 
{
    private CupType _cupType;
    public string _drinkName;
    public List<Ingredient> _recipe;

    public CupType Type { get { return _cupType; } set { _cupType = value; } }

    public Drinks(string drinkName, CupType cupType, List<Ingredient> recipe)
    {
        _drinkName = drinkName;
        _cupType = cupType; 
        _recipe = recipe; 
    }

    //caramel macciato 
    //2 caramel 
    //1 xpresso 
    //1 milk

    //iced chai latte
    //1 ice 
    //1 chai 
    //1 milk 

    //rasberry frap
    //1 scoop raz
    //2 rasz syrup
    //1 scoop ice
    //2 milk 
    //whipped cream
}
