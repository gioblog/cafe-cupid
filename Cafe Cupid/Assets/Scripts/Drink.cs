using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

enum CupType
{
    ColdGlass, 
    WarmMug
}

public class Drink : MonoBehaviour
{
    //drink data
    [SerializeField] private CupType drinkType;
    [SerializeField] private bool isSweet;
    [SerializeField] private bool isBitter;
    [SerializeField] private bool isDisappointing;
    private string drinkName;
    private List<string> drinkMenu;

    //"parameterized constructor" 
    public void Initialize(int drinkItem)
    {
        isSweet = false;
        isBitter = false;
        isDisappointing = false;
        switch (drinkItem)
        {
            case 1:
                drinkName = "Caramel Macchiato";
                drinkType = CupType.WarmMug;
                break;

            case 2:
                drinkName = "Raspberry Frappacino";
                drinkType = CupType.ColdGlass;
                break;
            default:
                throw new Exception("Valid drink number was not given");
        }
    }

}


