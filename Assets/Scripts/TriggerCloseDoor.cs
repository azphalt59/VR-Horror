using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseDoor : MonoBehaviour
{
    public HandleDoor handleDoorScript;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(GetComponent<MeshFilter>());
        //Destroy(GetComponent<MeshRenderer>());
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            
            handleDoorScript.CloseDoorBoolean();
        }
    }


}
