using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class StayEnabled : MonoBehaviour
{
    VRTK_MoveInPlace moveinplave;
    private void Start()
    {
        moveinplave = gameObject.GetComponent<VRTK_MoveInPlace>();
        moveinplave.enabled = true;
    }
    void Update()
    {
        if(moveinplave.enabled != true)
        {
            moveinplave.enabled = true;
        }
    }
}
