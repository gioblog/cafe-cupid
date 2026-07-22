using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FridgeDoor : MonoBehaviour
{
    [SerializeField] GameObject handle;
    [SerializeField] List<GameObject> ingredients;
    [SerializeField] GameObject organizers; 

    private SpriteRenderer[] ingredientSpriteComponents;
    private SpriteRenderer[] organizersSpriteComponents; 

    private void OnMouseDown()
    {
        Debug.Log("collision entered with " + this);
        SpriteRenderer DoorSprite = this.GetComponent<SpriteRenderer>();
        DoorSprite.enabled = false;
        handle.GetComponent<SpriteRenderer>().enabled = true;
        for (int i = 0; i < ingredients.Count; i++) //make ingredients in the fridge invisible
        {
            ingredientSpriteComponents = ingredients[i].GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in ingredientSpriteComponents)
            {
                sprite.enabled = false;
            }
        }

        organizersSpriteComponents = organizers.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in organizersSpriteComponents) //make shelving invisible 
        {
            sprite.enabled = false;
        }
    }
}
