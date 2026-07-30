using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] Sprite mug;
    [SerializeField] Sprite glass; 
    
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
