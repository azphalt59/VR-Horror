using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(Main_Manager))]
public class Main_Editor_Inspector : Editor
{
    Main_Manager Main;
    

    private void Awake()
    {
        Main = GameObject.Find("GameManager").GetComponent<Main_Manager>();
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if(GUILayout.Button("Next Quest"))
        {
            Main.QuestUpdate(Main.StepIndex);
            Main.StepIndex++;
        }
    }
}
