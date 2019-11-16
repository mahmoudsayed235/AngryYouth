using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using VRKeys;

public class FuckingTest : MonoBehaviour
{
    public List<string> Name =
     new List<string>() { "Guest" };

    public List<string> found0; // this is the first filter result from your first string word
    int textLength = 0;
    public Text center, A1, A2;
    public string fileName = "names.txt";
    string path;
    int c = 0;
    public Keyboard keys;
    string curentText;
    private void Start()
    {
        curentText = keys.placeholder.text;
        textLength = curentText.Length;
        found0 = new List<string>();
        path = Application.dataPath + "/Resources/" + fileName;
        StreamReader rd = new StreamReader(path);
        while (!rd.EndOfStream)
        {
            string inp_ln = rd.ReadLine();
            Name.Add(inp_ln);
        }

        rd.Close();
    }
    private void Update()
    {
       
        curentText = keys.placeholder.text;
        print("Curent: " + curentText);

        if (textLength != curentText.Length)
        {
            print("DD");

            //Change in the text update auto compelete
            found0.Clear();
            for (int i = 0; i < Name.Count; i++)
            {
                string ss = Name[i].ToLower();
                if (ss.StartsWith(curentText.ToLower()))
                {
                    found0.Add(Name[i]);
                    if (c > 5)
                    {
                        break;
                    }
                    c++;
                }

            }

            if (found0.Count > 0)
            {
                if (found0.Count > 0)
                {
                    center.text = found0[0];
                    print("1");
                }
                if (found0.Count >= 2)
                {
                    A1.text = found0[1];
                    print("2");
                }
                if (found0.Count > 2)
                {
                    A2.text = found0[2];
                    print("3");

                }
            }
            textLength = curentText.Length;
            c = 0;
        }

    }

}