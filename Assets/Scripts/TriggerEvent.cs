using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent Event;
    public string interactorTag;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == interactorTag)
        {
            Event.Invoke();
        }
    }
}
