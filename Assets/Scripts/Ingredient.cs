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
}
