using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioData audioData;
    void Start()
    {
        SceneDataManager.Instance.GoToPlayScene(audioData);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
