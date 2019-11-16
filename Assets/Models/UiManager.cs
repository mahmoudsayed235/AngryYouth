using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class UiManager : MonoBehaviour
{
    public int numberOfQuwsrion = 4;
    public GameObject[] panels;
    private static UiManager _instance;
    public GameObject game1, game2;
    public GameObject leftController;
    public GameObject RightController;

    public GameObject CameraRigperfab;
    public GameObject FaderSphere;
    bool flag = false;
    public int result = 0;
    public Text textResult;
    public string name = "";
    public GameObject C, D;
    public GameObject endResultCanas;
    public static UiManager Instance { get { return _instance; } }
    bool endBoxing = false;
    public Text Timer;
    float timeLeft = 50.0f;
    bool beginCounting = false;
    /// <summary>
    /// /////////////////////////////////
    /// </summary>
    public AudioSource audioSource;
    public AudioSource QuestionsAudioSource;
    public AudioClip WrongAnswerClip;
    public AudioClip RightAnswerClip;
    int rightAnswerCounter = 0;
    public GameObject fireWorks;
    /// <summary>
    /// /////////////////////////////////////
    /// </summary>
    private void Awake()
    {
       // CameraRigperfab.transform.position = new Vector3(-32.289f, 0, 0);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        numberOfQuwsrion = panels.Length - 1;
    }
    private void Update()
    {
      
        if (beginCounting)
        {
            timeLeft -= Time.deltaTime;
            int tmp =(int) timeLeft;
            Timer.text = "Timer\n" + "00:" + "00:" + tmp;
            if (timeLeft < 0)
            {
                StartEndingBoxing();
            }
            else if (timeLeft < 10)
            {
                if (audioSource.isPlaying == false)
                {
                    audioSource.Play();
                }
            }
        }
    }
    int currentQuest = 0;
    public void ChooseAnswer(int isRight)
    {
        
        if (currentQuest == 3)
        {
            print("Clicked");
            textResult.text=" Your Result=  " +result+" Correct Questions";
            FaderSphere.SetActive(true);
            game1.SetActive(true);
            game2.SetActive(true);
            leftController.GetComponent<VRTK_StraightPointerRenderer>().enabled = false;
            RightController.GetComponent<VRTK_StraightPointerRenderer>().enabled = false;
            C.SetActive(false);
            D.SetActive(false);
            StartCoroutine("HideFader");
        }
        
        result+=isRight;
       /* if (currentQuest <= 3)
        {
            panels[3].SetActive(false);
        }
        else
        */
        {

            panels[currentQuest].SetActive(false);
            currentQuest++;
            panels[currentQuest].SetActive(true);
        }
        //ShowNextQuestion();
       }

    void ShowNextQuestion()
    {
        print("current question : " + numberOfQuwsrion);
        if (numberOfQuwsrion < 0)
        {
            return;
        }
        for (int i = 0; i < panels.Length - 1; i++)
        {
            if (i != numberOfQuwsrion)
            {
                panels[i].SetActive(false);
            }
            else
            {
                panels[numberOfQuwsrion].SetActive(true);
            }
        }
    }

    IEnumerator HideFader()
    {
        yield return new WaitForSeconds(8f);
        FaderSphere.SetActive(false);      
        leftController.GetComponent<VRTK_StraightPointerRenderer>().enabled = false;
        RightController.GetComponent<VRTK_StraightPointerRenderer>().enabled = false;
        endBoxing = true;
        beginCounting = true;
       
        CameraRigperfab.transform.position = new Vector3(15.18f, 2.5f, -2.577f);
        CameraRigperfab.transform.rotation = new Quaternion(0, 187f, 0, 0);
    }


    void  StartEndingBoxing()
    {

        CameraRigperfab.transform.position = new Vector3(-31.7f, 2.5f, 0f);
        CameraRigperfab.transform.rotation = new Quaternion(0, 0, 0, 0);
        audioSource.Pause();
        game1.SetActive(false);
        game2.SetActive(false);
        C.SetActive(true);
        D.SetActive(true);
        leftController.GetComponent<VRTK_StraightPointerRenderer>().enabled = true;
        RightController.GetComponent<VRTK_StraightPointerRenderer>().enabled = true;
        endResultCanas.SetActive(true);
    }
    public void PlayRightAnswer()
    {
        rightAnswerCounter++;
        if (RightAnswerClip != null)
            QuestionsAudioSource.clip = RightAnswerClip;
        QuestionsAudioSource.Play();
        PlayFireWorks();
    }
    public void PlayWrongAnswer()
    {
        if (WrongAnswerClip != null)
            QuestionsAudioSource.clip = WrongAnswerClip;
        QuestionsAudioSource.Play();
    }
    public void PlayFireWorks()
    {
        fireWorks.SetActive(false);
        fireWorks.SetActive(true);
    }
}
   
