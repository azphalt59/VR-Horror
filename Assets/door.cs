using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public float addRotation = 90f;
    private interactable i;
    
    public void Start()
    {
        i = GetComponent<interactable>();
    }

    public void RotateCharacter(float multiply)
    {
        if(i.canEvent == true)
        {
            transform.Rotate(0, multiply * addRotation, 0);
        }
        
    }
}
