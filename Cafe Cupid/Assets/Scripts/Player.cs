using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float speed;
    [SerializeField] LayerMask defaultLayer;
    [SerializeField] Fridge fridgeScriptReference;
    [SerializeField] XMachine xScriptReference;
    [SerializeField] Kitchen kitchenReference;
    [SerializeField] Hand handReference; 


    private Vector2 position;
    private Vector2 velocity; 
    private Vector2 direction;
    private Mouse mouse;
    private DrinkOrder currentCup;
    private bool isHandEmpty;

    Drinks baseDrinks; 

    private void Start()
    {
        isHandEmpty = true; 
    }

    private void FixedUpdate()
    {
        position = mainCamera.transform.position;
        velocity = speed * direction.x * mainCamera.transform.right; //right = red axis (x)  
        position += velocity * Time.fixedDeltaTime;
        //if(position.x < -8)
        //{
        //    position.x = -6; 
        //}
        mainCamera.transform.position = position; //updates where the camera is? 
    }

    public void Move(InputAction.CallbackContext context)
    {
       direction = context.ReadValue<Vector2>();
       direction = direction.normalized;
    }

    //trying to get interaction input system to work so that I can develop for controller & mouse
    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.started) return;  //only want initial click

        //cast a ray
        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        
        if (!rayHit.collider) return;  //no collider found 
        GameObject clickedObject = rayHit.collider.gameObject;

        switch (clickedObject.name)
        {
            case "Mug":
            case "Glass":
                currentCup = clickedObject.GetComponent<DrinkOrder>();
                Debug.Log("a cup was clicked"); 
                isHandEmpty = false;
                handReference.HoldCup(clickedObject); 
                break; 

            case "Handle":
                fridgeScriptReference.Handle(); 
                break;

            case "Milk":
                //animation 
                currentCup.recipe.Add("1 milk"); 
                break;

            case "Caramel":
                //animation 
                currentCup.recipe.Add("1 caramel"); 
                //caramel.Add()
                break; 

            case "Door(interior)":
                fridgeScriptReference.CloseDoor(); 
                break;

            case "LButton":
                //play animation 
                currentCup.recipe.Add(xScriptReference.Light());
                break;

            case "NButton":
                //play animation
                currentCup.recipe.Add(xScriptReference.Normal());
                break;

            case "SButton":
                //play animation 
                currentCup.recipe.Add(xScriptReference.Strong());
                break;

            case "ServeButton":
                currentCup.EvalCup(); 
                break; 

            default:
                break; 
        }
    }

}
