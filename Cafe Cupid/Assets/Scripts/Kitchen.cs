using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Kitchen : MonoBehaviour
{
    private Drink currentCup;
    private Drink caramelMac;
    private Drink raspFrap; 
    private bool isHandEmpty;
    private GameObject objectHolding;
    private List<Drink> drinkMenu;

    [SerializeField] GameObject lightButton;
    [SerializeField] GameObject normButton;
    [SerializeField] GameObject strongButton;
    private double xShot;

    private void Awake()
    {
        //drinks available on the menu 
        //caramelMac = caramelMac.Initialize(1);
        //raspFrap.Initialize(2); 
        //drinkMenu = new List<Drink> { caramelMac, raspFrap }; 
    }
    public string Light()
    {
        xShot = .5;
        return $"{xShot} xpresso";
    }



}
