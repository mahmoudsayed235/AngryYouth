using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliasransform : MonoBehaviour
{
    public GameObject ToFollow;

    // Update is called once per frame
    private void Start()
    {
        transform.parent = ToFollow.transform;


    }
    void Update()
    {
        transform.rotation = ToFollow.transform.rotation;
    }
 
}
