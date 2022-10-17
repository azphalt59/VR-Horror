using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent Event;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Event.Invoke();
        }
    }
    public void Debugger(string blablabla)
    {
        Debug.Log(blablabla);
    }

}
