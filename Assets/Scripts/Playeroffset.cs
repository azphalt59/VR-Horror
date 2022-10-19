using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeroffset : MonoBehaviour
{
    public float offsetY = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, offsetY, transform.position.z);
    }

}
