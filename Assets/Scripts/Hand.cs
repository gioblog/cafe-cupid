using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] Sprite mug;
    [SerializeField] Sprite glass; 
    
    /// <summary>
    /// Determines what type of sprite should be displayed in the "hand" of the player 
    /// </summary>
    /// <param name="cup"></param>
    public void HoldCup(GameObject cup)
    {
        if(cup.name == "Mug")
        {
            item.GetComponent<Image>().sprite = mug;
        }
        else
        {
            item.GetComponent<Image>().sprite = glass; 
        }
    }
}
