using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject enemy;
    private int enemies = 0;
    private int playerCount;

    private void Update()
    {
        if (enemies < 10)
        {
            for (int i = 0; i < enemies; i++)
            {
                GameObject.Instantiate(enemy, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0f), transform.rotation);
                enemies++;
            }
        }
    }
}
