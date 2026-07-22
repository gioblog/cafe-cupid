using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] GameObject handle;
    [SerializeField] GameObject interiorDoor;
    [SerializeField] List<GameObject> ingredients;
    [SerializeField] GameObject organizers;

    private SpriteRenderer[] ingredientSpriteComponents;
    private SpriteRenderer[] organizersSpriteComponents;
    //private void OnMouseDown()
    //{
    //    Debug.Log("mouse clicked");
    //    Collider2D colliderSelected= this.GetComponentInChildren<Collider2D>();
    //    Debug.Log(colliderSelected); 
    //}
}
