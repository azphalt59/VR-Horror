using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public void SpawnIt()
    {
        GameObject.Instantiate(gameObject);
    }
}
