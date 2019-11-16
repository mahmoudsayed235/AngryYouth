using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUIScript : MonoBehaviour
{
    public GameObject follower;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = follower.transform.rotation.ToString();
    }
}
