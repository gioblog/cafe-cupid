using UnityEngine;

//public class Ingredient : MonoBehaviour 
//{
//    private string _name;
//    private int _amt; 

//    void Awake ()
//    {
//        _name = this.name;
//        _amt = 0; 
//    }

//    public void Add()
//    {
//        _amt++; 
//    }
    
//}

public class Ingredient
{
    private string _name;
    private int _amt; 

    public Ingredient(string name, int amt)
    {
        _name = name;
        _amt = amt; 
    }

    /// <summary>
    /// Getter property that returns the name of the ingredient 
    /// </summary>
    public string Name { get { return _name; } set { _name = value; } }

    /// <summary>
    /// Getter & setter property for amount 
    /// </summary>
    public int Amount { get { return _amt; } set { _amt = value; } }

    /// <summary>
    /// adds one of the ingredient item 
    /// </summary>
    public void AddAmount()
    {
        _amt++; 
    }
}
