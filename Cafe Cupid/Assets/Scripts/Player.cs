using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float speed;
    [SerializeField] LayerMask defaultLayer;
    [SerializeField] Fridge fridgeScriptReference;
    //[SerializeField] XMachine xScriptReference;
    [SerializeField] Kitchen kitchenReference; 

    private Vector2 position;
    private Vector2 velocity; 
    private Vector2 direction;
    private Mouse mouse; 

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

        switch(rayHit.collider.gameObject.name)
        {
            case "Handle":
                fridgeScriptReference.Handle(); 
                break;
            case "Door(interior)":
                fridgeScriptReference.CloseDoor(); 
                break;

            case "LButton":
                Debug.Log(kitchenReference.Light()); 
                break; 
        }
    }

}
