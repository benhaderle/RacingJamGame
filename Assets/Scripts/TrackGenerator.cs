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
            nextPiece.transform.position = lastPieceAdded.transform.position + lastPieceAdded.endOffset;
        }
        else {
            
        }

        activeTrackPieces.Add(nextPiece);
        lastPieceAdded = nextPiece;
    }

    public void Reset()
    {
        activeTrackPieces.Clear();
    }
}
