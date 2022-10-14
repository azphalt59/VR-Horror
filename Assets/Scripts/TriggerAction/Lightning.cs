using LSS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

   // [SerializeField] string loadFloader;


  
    public void Lightnin(string loadFloader )
    {
        GetComponent<Animator>().SetBool("Isactive", true);
        GameObject.FindObjectOfType<LSS_FrontEnd>().Load(loadFloader);
    }
    public void OnFinish()
    {
        GetComponent<Animator>().SetBool("Isactive", false);
        Destroy(transform.parent.gameObject);

    }
}

