using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSS;

public class ChangeLightingOnEnable : MonoBehaviour {

	[SerializeField] string loadFloader;
	[SerializeField] bool Oui;
    
    public void ChangeLight(string loadFloader)
    {
        GameObject.FindObjectOfType<LSS_FrontEnd>().Load(loadFloader);


    }

}
