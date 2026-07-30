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
    public List<string> _recipe;

    public CupType Type { get { return _cupType; } set { _cupType = value; } }

    public Drinks(string drinkName, CupType cupType, List<string> recipe)
    {
        _drinkName = drinkName;
        _cupType = cupType; 
        _recipe = recipe; 
    }
    //2 caramel 
    //1 xpresso 
    //1 milk   
}
