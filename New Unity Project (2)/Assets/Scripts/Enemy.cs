﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform moveMe;
    bool goLeft;
    bool goRight;
    public GameObject enemy;
    public GameObject score;
    float enemyx;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Manager");
        moveMe = gameObject.GetComponent<Transform>();

        if (enemy.transform.position.x >=0 )
        {
            goLeft = true;

        }
        else
        {
            goRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goLeft == true)
            moveMe.position+=new Vector3(-.01f,0,0);

        if (goRight == true)
            moveMe.position += new Vector3(.01f, 0, 0);

        if (enemy.transform.position.x > 9.5)
        {
            goLeft=true;

            goRight=false;
        }

        if (enemy.transform.position.x < -9.5)
        {
            goLeft = false;

            goRight = true;
        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PlayerBullet")
        {
            gameObject.transform.DetachChildren();
            score.GetComponent<manager>().scorekeep += 10;
            Destroy(gameObject);
         
        }

    }
}