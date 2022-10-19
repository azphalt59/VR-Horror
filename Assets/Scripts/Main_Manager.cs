using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Main_Manager : MonoBehaviour
{
    public List<GameObject> QuestItems;
    public List<GameObject> QuestStepPrefab;
    public int StepIndex = 1;
    public GameObject Doors;
    // Start is called before the first frame update
    public static Main_Manager Instance;
    [SerializeField] private bool DoorsAreLocked = true;
    [SerializeField] private List<XRGrabInteractable> grabs;
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void QuestUpdate(int ItemIndex)
    {
        if(ItemIndex > StepIndex)
        {
            StepIndex = ItemIndex;
            if (ItemIndex + 1 == QuestStepPrefab.Count)
            {
                Debug.Log("C'est gagn�");
                return;
            }
            if (ItemIndex < QuestStepPrefab.Count)
            {
                LoadNextStepQuest(ItemIndex);
            }
        }

    }

    public void ActiveDoor(int angle)
    {
        if(DoorsAreLocked == true)
        {
            Doors.SetActive(true);
            foreach (XRGrabInteractable grab in grabs)
            {
                grab.gameObject.GetComponent<HandleDoor>().UnlockDoor(angle);
            }
            DoorsAreLocked = false;
        }
        
    }
    public void LoadNextStepQuest(int ItemIndex)
    {
        QuestItems[ItemIndex].SetActive(true);
        Debug.Log(QuestItems[ItemIndex].name + " Loading");
        QuestStepPrefab[ItemIndex].SetActive(true);
    }
    public void DesactivePreviousSteQuest(int ItemIndex)
    {
        Debug.Log(QuestStepPrefab[ItemIndex].name + " Desactive");
        QuestStepPrefab[ItemIndex].SetActive(false);
    }
    private void DesactivePreviousItem(int ItemIndex)
    {
        QuestItems[ItemIndex].SetActive(false);
        // Mettre l'anim de disappear
    }
    public void Win()
    {
        Debug.Log("Win");
    }
}

