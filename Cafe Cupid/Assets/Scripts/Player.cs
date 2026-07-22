using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float speed;
    [SerializeField] LayerMask defaultLayer;

    private Vector2 position;
    private Vector2 velocity; 
    private Vector2 direction;
    private Mouse mouse; 

    private void FixedUpdate()
    {
        position = mainCamera.transform.position;
        velocity = speed * direction.x * mainCamera.transform.right; //right = red axis (x)  
        position += velocity * Time.fixedDeltaTime;
        mainCamera.transform.position = position; //updates where the camera is? 
    }

    public void Move(InputAction.CallbackContext content)
    {
       direction = content.ReadValue<Vector2>();
       direction = direction.normalized;
    }

    //trying to get interaction input system to work so that I can develop for controller & mouse
    public void Interact(InputAction.CallbackContext content)
    {
       
    }

}
