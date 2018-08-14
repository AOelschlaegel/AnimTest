using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour {

    public int speed = 2;

    public Camera mainCamera;

    private Vector3 scale;
    private Vector3 scaleFactor;
    Vector3 mousePos;

    private void Awake()
    {
        scaleFactor = new Vector3(0.5f, 0.5f, 0.5f);
        scale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update () {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = Vector2.Lerp(transform.position, mousePos, speed * Time.deltaTime/(scale.x*3));
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy" && other.transform.localScale.x < transform.localScale.x)
        {
            scale += other.transform.localScale/4;
            Debug.Log("scale is :" + scale);
            Destroy(other.gameObject);
            
            if(scale.x > 4)
            {
                mainCamera.orthographicSize++;
            }

        }
    }
}
