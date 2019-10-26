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
            trackGen.GeneratePiece(Random.Range(0, trackGen.trackPiecePrefabs.Length));
        }
        if (GUILayout.Button("Reset Generator")) {
            trackGen.Reset();
        }
    }
}
