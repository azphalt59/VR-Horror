using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTeleporter : MonoBehaviour
{
    public Transform TpDestination;
    [Header("RotationPlayer, ignore if rotation is at the same angle after teleportation")]
    public bool haveToChangeRotation = false;
    public float PlayerYrotation;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = TpDestination.position;
            if(haveToChangeRotation)
            {
                other.transform.localEulerAngles = new Vector3(other.transform.localEulerAngles.x, PlayerYrotation, other.transform.localEulerAngles.z);
            }
        }
    }

}
