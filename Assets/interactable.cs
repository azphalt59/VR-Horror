using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactable : MonoBehaviour
{
    public UnityEvent interactionEvent;
    public bool canEvent = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canEvent = true;  
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canEvent = false;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown("joystick button 0") && canEvent == true)
        {
            interact();
        }
    }
    public void interact()
    {
        Debug.Log("ss");
        interactionEvent.Invoke();
    }
}
