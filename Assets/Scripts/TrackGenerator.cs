using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TrackGenerator : MonoBehaviour
{
    public TrackPiece[] trackPiecePrefabs;

    List<TrackPiece> activeTrackPieces = new List<TrackPiece>();
    TrackPiece lastPieceAdded;
    Dictionary<string, int> trackStringIDDict = new Dictionary<string, int>();

    public void GeneratPiece(string type)
    {
        GeneratePiece(trackStringIDDict[type]);
    }

    public void GeneratePiece(int type)
    {
        TrackPiece nextPiece = Instantiate(trackPiecePrefabs[type], this.transform);

        if (activeTrackPieces.Count > 0) {
            nextPiece.transform.rotation = lastPieceAdded.transform.rotation;
            nextPiece.transform.Rotate(lastPieceAdded.endRotation);
            nextPiece.transform.position = lastPieceAdded.transform.position + lastPieceAdded.endOffset.x * lastPieceAdded.transform.right +
                lastPieceAdded.endOffset.y * lastPieceAdded.transform.up +
                lastPieceAdded.endOffset.z * lastPieceAdded.transform.forward;
            
        }
        else {
            
        }

        activeTrackPieces.Add(nextPiece);
        lastPieceAdded = nextPiece;
    }

    public void Reset()
    {
        foreach(TrackPiece t in activeTrackPieces) {
           if (t.gameObject != null) DestroyImmediate(t.gameObject);
        }
        activeTrackPieces.Clear();
    }
}
