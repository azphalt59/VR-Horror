using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralItem : MonoBehaviour
{
    public int itemIndex;
    private void Start()
    {
        for(int i = 0; i<Main_Manager.Instance.QuestItems.Count; i++)
        {
            if (Main_Manager.Instance.QuestItems[i].name == this.gameObject.name)
            {
                itemIndex = i;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            Main_Manager.Instance.QuestUpdate(itemIndex);
        }
    }
}
