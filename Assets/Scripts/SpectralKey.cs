using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Drawer")
        {
            Main_Manager.Instance.QuestUpdate(5);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
