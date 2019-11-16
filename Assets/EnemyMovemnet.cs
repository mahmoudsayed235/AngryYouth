using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemnet : MonoBehaviour {

    Rigidbody rg;
    public int speed = 100;

	void Start () {
        rg = GetComponent<Rigidbody>();
        rg.velocity = transform.forward * -speed * Time.deltaTime;

    }

    void Update () {
        if (transform.position.z < -15)
        {
            PlayerJumping.Instance.incremntMissScore();
            Destroy(this.gameObject);
        }
	}
}
