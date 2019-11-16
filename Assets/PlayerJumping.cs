using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class PlayerJumping : MonoBehaviour {
    public float lastSize = 0.0f;
    float val = 0.0f;
    public Transform camEye;
    public Transform floor;
    public GameObject camRig;
    public Text t1, t2, t3, t4, t5;
    bool isStart = false;
    bool ableToJump = false;
    Rigidbody rg;
    public AudioSource audio;
    public AudioClip HitClip;
    public AudioClip MissClip;
    public AudioClip JumpClip;
    public int hitScore = 0;
    public int missScore = 0;
    public Text missText, hitText;
    public MeshRenderer Wall1, Wall2;
    public Material defaultMaterial;
    public Material WrongMaterial;
    #region SINGLETON PATTERN
    private static PlayerJumping _instance;

    public static PlayerJumping Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
#endregion
void Start()
    {
        rg = GetComponent<Rigidbody>();
        Invoke("SetSize", 4);
    }
    void Update()
    {
        val = (camEye.transform.position.y - floor.position.y);
        UpdateUI();
        CheckJump();

      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            PlayHitSound();
            SetWrongMaterial();
            Invoke("ResetMaterial", 2);
            other.gameObject.SetActive(false);
            hitScore++;
        }
    }
    public void SetSize()
    {
        lastSize = (camEye.transform.position.y - floor.position.y);
        isStart = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            ableToJump = true;
        }
    }
    public void incremntMissScore()
    {
        missScore++;
        PlayMissSound();
    }
    void UpdateUI()
    {
        t1.text = "LastSize = " + lastSize;
        t3.text = "Dist = " + (camEye.position.y - floor.position.y);
        t4.text = "CamEyePos = " + camEye.position.y;
        t2.text = "Val = " + val;
        t5.text = "Rig = " + camRig.transform.position.y;
        /////
        hitText.text = "Hit\n" + hitScore;
        missText.text = "Miss\n" + missScore;
    }
    void CheckJump()
    {
        if (val - lastSize > 0.1f && isStart && ableToJump)
        {
            this.gameObject.transform.position = new Vector3(camRig.transform.position.x, camRig.transform.position.y + 0.5f, camRig.transform.position.z);
            t2.color = Color.red;
            ableToJump = false;
            PlayJumpSound();
        }
        else
        {
            t2.color = Color.green;
        }
    }
    void PlayHitSound()
    {

        audio.clip = HitClip;
        audio.Play();
    }
    void PlayMissSound()
    {
        audio.clip = MissClip;
        audio.Play();
    }
    void ResetMaterial()
    {
        Wall2.material = defaultMaterial;
        Wall1.material = defaultMaterial;
    }
    void SetWrongMaterial()
    {
        Wall2.material = WrongMaterial;
        Wall1.material = WrongMaterial;
    }
    void PlayJumpSound()
    {
        audio.clip = JumpClip;
        audio.Play();
    }
}
