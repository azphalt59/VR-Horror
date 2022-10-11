using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Manager : MonoBehaviour
{
    public List<GameObject> QuestItems;
    public List<GameObject> QuestStepPrefab;
    public int StepIndex = 1;
    // Start is called before the first frame update
    public void QuestUpdate(int ItemIndex)
    {
        if (StepIndex+1 == QuestStepPrefab.Count)
        {
            Debug.Log("C'est gagn�");
            return;
        }
        Debug.Log("On passe � l'�tape " + (StepIndex+1));
        DesactivePreviousSteQuest(ItemIndex);
        if(ItemIndex<QuestStepPrefab.Count)
        {
            LoadNextStepQuest(ItemIndex + 1);
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
