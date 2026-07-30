using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] GameObject handle;
    [SerializeField] GameObject interiorDoor;
    [SerializeField] List<GameObject> ingredients;
    [SerializeField] GameObject organizers;

    private SpriteRenderer[] organizersSpriteComponents;
 
    public void Handle()
    {
        Debug.Log("collision entered with " + handle.name);
        SpriteRenderer handleSprite = handle.GetComponent<SpriteRenderer>();

        handleSprite.enabled = false; //turn off the sprite renderer 
        interiorDoor.GetComponent<SpriteRenderer>().enabled = true;

        for (int i = 0; i < ingredients.Count; i++) //make ingredients in the fridge visible
        {
            ingredients[i].GetComponent<SpriteRenderer>().enabled = true;
        }

        organizersSpriteComponents = organizers.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in organizersSpriteComponents)  //make shelving visible 
        {
            sprite.enabled = true;
        }
    }

    public void CloseDoor()
    {
        Debug.Log("collision entered with " + interiorDoor.name);
        SpriteRenderer DoorSprite = interiorDoor.GetComponent<SpriteRenderer>();
        DoorSprite.enabled = false;
        handle.GetComponent<SpriteRenderer>().enabled = true;
        for (int i = 0; i < ingredients.Count; i++) //make ingredients in the fridge invisible
        {
            ingredients[i].GetComponent<SpriteRenderer>().enabled = false;
        }
       
        organizersSpriteComponents = organizers.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in organizersSpriteComponents) //make shelving invisible 
        {
            sprite.enabled = false;
        }
    }
}
