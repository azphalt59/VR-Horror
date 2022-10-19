using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralItem : MonoBehaviour
{
    public int itemIndex;
    public bool DestroyItem = false;
    public bool NeedKey = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key")
        {
            NeedKey = false;
        }
        if (other.tag == "Player")
        {
            if(NeedKey == false)
            {
                Debug.Log("Hit spectral item");
                Main_Manager.Instance.QuestUpdate(itemIndex);
                if(DestroyItem == true)
            {
                Destroy(this.gameObject);
            }
            }
           
            
        }
        
    }


}
