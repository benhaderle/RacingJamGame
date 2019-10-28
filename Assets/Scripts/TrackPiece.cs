using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPiece : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    public Vector3 endOffset;
    public Vector3 endRotation;
    public TrackPiece childPiece;

    public bool curved;

    Mesh mesh;

    private void Start()
    {
        
    }

    public void GenerateObstacles(float numToGenerate)
    {
        if (!curved) {
            for(int i = 0; i < numToGenerate; i++) {
                GameObject newObstacle = Instantiate(obstaclePrefab[Random.Range(0,obstaclePrefab.Length)], this.transform);

                //find where to generate
                newObstacle.transform.localPosition = Vector3.up * 7;
                newObstacle.transform.RotateAround(transform.position, newObstacle.transform.forward, Random.Range(0, 360));
                float offsetWeight = Random.Range(0, 1f);
                newObstacle.transform.localPosition = newObstacle.transform.localPosition + endOffset * offsetWeight;
                //newObstacle.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                //newObstacle.transform.Rotate(new Vector3(0, 0, 1), Random.Range(0, 360), Space.Self);
                //Debug.Log(newObstacle.transform.up);
                //float radZ = Mathf.Deg2Rad * newObstacle.transform.localRotation.eulerAngles.z;
                //Debug.Log(newObstacle.transform.localPosition);
                //newObstacle.transform.localPosition = newObstacle.transform.localPosition + new Vector3(Mathf.Sin(radZ), Mathf.Cos(radZ), 0) * 7;
               
            }
        }  
    }
}
