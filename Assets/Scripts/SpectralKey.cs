using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralKey : MonoBehaviour
{
    public GameObject SpectralDrawer;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Drawer")
        {
            Main_Manager.Instance.QuestUpdate(5);
            Main_Manager.Instance.DesactivePreviousSteQuest(3);
            Destroy(SpectralDrawer);
            Destroy(this.gameObject);
        }

    }
}
