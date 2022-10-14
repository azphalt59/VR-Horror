using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Main_Manager : MonoBehaviour
{
    public List<GameObject> QuestItems;
    public List<GameObject> QuestStepPrefab;
    public int StepIndex = 1;
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
        if (StepIndex + 1 == QuestStepPrefab.Count)
        {
            Debug.Log("C'est gagné");
            return;
        }
        Debug.Log("On passe à l'étape " + (StepIndex + 1));
        DesactivePreviousSteQuest(ItemIndex);
        if (ItemIndex < QuestStepPrefab.Count)
        {
            LoadNextStepQuest(ItemIndex + 1);
        }

    }

    public void ActiveDoor()
    {
        if(DoorsAreLocked == true)
        {
            foreach (XRGrabInteractable grab in grabs)
            {
                grab.enabled = true;
                //grab.gameObject.GetComponent<HandleDoor>().
            }
            DoorsAreLocked = false;
        }
        
    }
    private void LoadNextStepQuest(int ItemIndex)
    {
        QuestItems[ItemIndex].SetActive(true);
        QuestStepPrefab[ItemIndex].SetActive(true);
    }
    private void DesactivePreviousSteQuest(int ItemIndex)
    {
        QuestStepPrefab[ItemIndex].SetActive(false);
        DesactivePreviousItem(ItemIndex);
    }
    private void DesactivePreviousItem(int ItemIndex)
    {
        QuestItems[ItemIndex].SetActive(false);
        // Mettre l'anim de disappear
    }
}

