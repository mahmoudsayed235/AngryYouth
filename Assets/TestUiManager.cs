using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUiManager : MonoBehaviour
{
    public Text t1, t2, t3,t4;
    public CapsuleCollider capsule;
    public Transform CamRIg;
    public Transform floor;
    public Transform eyePos;
    // Update is called once per frame
    void Update()
    {
        t1.text = "Size = " + capsule.height;
        t2.text = "CamPos = " + CamRIg.position.y;
        t3.text = "Dist = " + (eyePos.position.y - floor.position.y);
        t4.text = "CamPos = " + eyePos.position.y;
    }
}
