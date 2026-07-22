using System;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    //[SerializeField] LayerMask defaultLayer;
    [SerializeField] GameObject interiorDoor;
    [SerializeField] List<GameObject> ingredients;
    [SerializeField] GameObject organizers;

    private SpriteRenderer[] ingredientSpriteComponents;
    private SpriteRenderer[] organizersSpriteComponents;

    private void OnMouseDown()
    {
        Debug.Log("collision entered with " + this);
        SpriteRenderer handleSprite = this.GetComponent<SpriteRenderer>();

        handleSprite.enabled = false; //turn off the sprite renderer 
        interiorDoor.GetComponent<SpriteRenderer>().enabled = true;

        for (int i = 0; i < ingredients.Count; i++) //make ingredients in the fridge visible
        {
            ingredientSpriteComponents = ingredients[i].GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sprite in ingredientSpriteComponents)
            {
                sprite.enabled = true;
            }
        }

        organizersSpriteComponents = organizers.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in organizersSpriteComponents)  //make shelving visible 
        {
            sprite.enabled = true;
        }
    }

}
