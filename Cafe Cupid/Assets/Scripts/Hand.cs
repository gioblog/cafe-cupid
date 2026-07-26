using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] Sprite mug;  
    
    public void HoldCup(GameObject cup)
    {
        Debug.Log("lets attempt to display"); 
        if(cup.name == "Mug")
        {
            item.GetComponent<Image>().sprite = mug;
            Debug.Log("IT SHOULD BE A MUG"); 
        }
    }
}
