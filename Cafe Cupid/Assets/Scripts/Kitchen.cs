using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Kitchen : MonoBehaviour
{
    private Drinks caramelMac;
    private List<string> caramelRecipe = new List<string> { "1 xpresso", "2 caramel",  "1 milk" };

    public List<Drinks> menu;  
    private void Awake()
    {
        caramelMac = new Drinks("caramel macciato", CupType.WarmMug, caramelRecipe);
        menu.Add(caramelMac); 
    }

}
