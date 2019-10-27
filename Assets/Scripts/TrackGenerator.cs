using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


//if button down
    //move left or right along ship right vector

//rotate based on normal of tube surface
//lock ship y down to tube surface

//move along ship forward vector
public class TrackGenerator : MonoBehaviour
{
    public float speed = 1;
    public TrackPiece[] trackPiecePrefabs;

    const int MAXROTATIONS = 12;
    const float ROTUNIT = 360 / MAXROTATIONS;
    
    List<TrackPiece> activeTrackPieces = new List<TrackPiece>();
    Dictionary<string, int> trackStringIDDict = new Dictionary<string, int>();
    TrackPiece lastPieceAdded;
    TrackPiece oldestPiece;

    float timer = 10f;

    private void Start()
    {
        for (int i = 0; i< trackPiecePrefabs.Length; i++) {
            trackStringIDDict[trackPiecePrefabs[i].name] = i;
        }

        Reset();

        Physics.IgnoreLayerCollision(8, 9, true);
    }

    void StartTrack()
    {
        for(int i = 0; i < 25; i++) {
            GeneratePiece(Random.Range(0, trackPiecePrefabs.Length));
        }
    }

    public void GeneratPiece(string type)
    {
        GeneratePiece(trackStringIDDict[type]);
    }

    public void GeneratePiece(int type)
    {
        //newpiece
        TrackPiece nextPiece = Instantiate(trackPiecePrefabs[type], this.transform).GetComponent<TrackPiece>();

        //adding on to the end of the track or starting a new track
        if (activeTrackPieces.Count > 0) {
            nextPiece.transform.rotation = lastPieceAdded.transform.rotation;
            nextPiece.transform.Rotate(lastPieceAdded.endRotation);
            nextPiece.transform.position = lastPieceAdded.transform.position + lastPieceAdded.endOffset.x * lastPieceAdded.transform.right +
                lastPieceAdded.endOffset.y * lastPieceAdded.transform.up +
                lastPieceAdded.endOffset.z * lastPieceAdded.transform.forward;
            lastPieceAdded.childPiece = nextPiece;
        }
        else {
            oldestPiece = nextPiece;
        }

        //random rotation
       // nextPiece.transform.Rotate(0, 0, Random.Range(0, MAXROTATIONS) * ROTUNIT, Space.Self);

        //check for collisionss
        /*foreach (TrackPiece t in activeTrackPieces) {
            if(t != nextPiece) {
                Debug.Log(nextPiece.GetComponentsInChildren<MeshCollider>()[0].ClosestPointOnBounds(t.transform.position));
            }
        }*/


        //generate obstacles on piece
        int numToGenerate = Mathf.RoundToInt(Mathf.Clamp(3 / speed, .500001f, 5));
        nextPiece.GenerateObstacles(numToGenerate);

        //add piece to the end of the track
        activeTrackPieces.Add(nextPiece);
        lastPieceAdded = nextPiece;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0) {
            //adding new piece
            GeneratePiece(Random.Range(0, trackPiecePrefabs.Length));

            //deleting oldest piece
            activeTrackPieces.Remove(oldestPiece);
            TrackPiece pieceToDelete = oldestPiece;
            oldestPiece = pieceToDelete.childPiece;
            Destroy(pieceToDelete.gameObject);

            timer = 10 / speed;
        }
    }

    public void Reset()
    {
        foreach(TrackPiece t in activeTrackPieces) {
            if (t.gameObject != null) DestroyImmediate(t.gameObject);
        }
        activeTrackPieces.Clear();

        StartTrack();
    }
}
