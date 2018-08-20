using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour 
{
    public int Speed = 2;
    public Text ScoreText;
    public Camera MainCamera;

    private Vector3 _scale;
    private Vector3 _scaleFactor;
    private Vector3 _mousePos;
    private float _score = 0f;

    private void Awake() 
    {
        _scaleFactor = new Vector3(0.5f, 0.5f, 0.5f);
        _scale = new Vector3(1, 1, 1);
    }

    void Update() 
    {
        _mousePos = Input.mousePosition;
        _mousePos = Camera.main.ScreenToWorldPoint(_mousePos);
        transform.position = Vector2.Lerp(transform.position, _mousePos, Speed * Time.deltaTime / (_scale.x * 3));
        transform.localScale = _scale;


    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "enemy" && other.transform.localScale.x < transform.localScale.x) 
        {
            _scale += other.transform.localScale
            SetCountText();
            Debug.Log ("scale is :" + _scale);
            Destroy (other.gameObject);

            if(_scale.x > 4) 
            {
                MainCamera.orthographicSize++;
            }
        }
    }

    private void SetCountText()
    {
        _score += other.transform.localScale.x;
        ScoreText.text = _score.ToString();
    }
}