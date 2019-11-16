using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public Transform first;

    public GameObject firstPrefab;

    public float startTime = 2;
    public float SpawnTime = 5;

    void Start()
    {
        InvokeRepeating("CreateFirstObject", startTime, SpawnTime);



    }
    void CreateFirstObject()
    {
        GameObject temp = Instantiate(firstPrefab, first,true);
    }

    
   
}
