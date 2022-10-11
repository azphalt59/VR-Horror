using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(torchlight))]
public class torchlight_Inspector : Editor
{
    torchlight light;
    // Start is called before the first frame update
    private void Awake()
    {
        light = GameObject.Find("Torchlight Light").GetComponent<torchlight>();
    }

    // Update is called once per frame
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("perform light"))
        {
            light.Perform();
        }
    }
}
