using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SussgisionEvent : MonoBehaviour
{
    public TextMeshProUGUI MainText;


    public void ChooseWord()
    {
        MainText.text = this.gameObject.GetComponent<Text>().text;
    }
}
