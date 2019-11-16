using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanimator : MonoBehaviour
{
    public UiManager ui;
    public Animator anim;
    // Start is called before the first frame update
    void OnEnable()
    {
        int ave = ui.result * 100;
        ave = ave / 16;
        if (ave >= 0 && ave <= 25)
        {
            anim.SetTrigger("1");
        }
        else if(ave >= 26 && ave <= 50)
        {

            anim.SetTrigger("2");
        }
        else if (ave >= 51 && ave <= 75)
        {

            anim.SetTrigger("3");
        }
        else if(ave >= 76 && ave <= 100)
        {
            anim.SetTrigger("4");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
