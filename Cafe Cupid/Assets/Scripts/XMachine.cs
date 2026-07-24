using UnityEngine;

public class XMachine : MonoBehaviour
{
    [SerializeField] GameObject lightButton;
    [SerializeField] GameObject normButton;
    [SerializeField] GameObject strongButton;
    private double xShot;
    
    public string Light()
    {
        xShot = .5;
        return $"{xShot} xpresso";  
    }

    public string Normal()
    {
        xShot = 1; 
        return $"{xShot} xpresso"; 
    }

    public string Strong()
    {
        xShot = 2;
        return $"{xShot} xpresso"; 
    }
}
                           