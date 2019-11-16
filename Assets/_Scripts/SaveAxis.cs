using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAxis : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cameraprefab;
    public GameObject floor;

    void Start()
    {
        cameraprefab.transform.position = new Vector3(0,0.7f,0);

    }

    // Update is called once per frame
    void Update()
    {
        cameraprefab.transform.position = new Vector3(cameraprefab.transform.position.x, floor.transform.position.y + 0.7f, cameraprefab.transform.position.z);

    }
}
