using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    public GameObject player;
    public int speed = 2;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

		if(transform.localScale.x > player.transform.localScale.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime/ transform.localScale.x);
        }

        if (transform.localScale.x < player.transform.localScale.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -0.2f * speed * Time.deltaTime / transform.localScale.x);
        }
    }
}
