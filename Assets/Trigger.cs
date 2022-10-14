using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
   public GameObject Anim;

    public void Lightning()
    {
        Anim.GetComponent<Animator>().SetBool("Isactive", true);
    }
    public void OnFinish()
    {
        Anim.GetComponent<Animator>().SetBool("Isactive",false);

    }

}
