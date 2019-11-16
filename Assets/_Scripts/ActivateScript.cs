using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ActivateScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<VRTK_ControllerEvents>().enabled = true;
        gameObject.GetComponent<VRTK_InteractGrab>().enabled = true;
        gameObject.GetComponent<VRTK_InteractTouch>().enabled = true;
        gameObject.GetComponent<VRTK_InteractUse>().enabled = true;
        gameObject.GetComponent<VRTK_PolicyList>().enabled = true;


    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<VRTK_ControllerEvents>().enabled = true;
        gameObject.GetComponent<VRTK_InteractGrab>().enabled = true;
        gameObject.GetComponent<VRTK_InteractTouch>().enabled = true;

    }
}
