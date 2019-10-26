using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrackGenerator))]
public class TrackGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        TrackGenerator trackGen = (TrackGenerator)target;
        if (GUILayout.Button("Generate Piece")) {
            trackGen.GeneratePiece(0);
        }
        if (GUILayout.Button("Reset Generator")) {
            trackGen.Reset();
        }
    }
}
