﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigBod;
    public float speed;
    public float fireRate;
    private float lastShot = 0.0f;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject manager;
    private Vector3 mousePos;
    public Vector3 shootDir;
	
	public int powerType;
    public bool powered = false;
    public float powerStart = 0.0f;
    public float powerTime = 0.0f;
    public float powerDuration = 10.0f;
    public GameObject shieldRef;

    // Start is called before the first frame update
    void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        //mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RotateToMousePos(mousePos);
		
		//Powerup Timing
        if (powered)
        {
            powerTime = Time.time;

            if (powerTime - powerStart > powerDuration)
            {
                powered = false;
                powerTime = 0.0f;
                powerStart = 0.0f;

                switch (powerType)
                {
                    case 0:
                        fireRate *= 2;
                        break;
                    case 1:
                        Debug.Log("Tripleshot ended");
                        break;
                    case 2:
                        shieldRef.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public void updatehealth()
    {
        manager.GetComponent<manager>().health--;
    }
    private void Move()
    {
        //Position checks
        if (transform.position.x >= 10.0f)
        {
            transform.position = new Vector3(10.0f, transform.position.y, 0.0f);
        }
        if (transform.position.x <= -10.0f)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, 0.0f);
        }
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(transform.position.x, -5.5f, 0.0f);
        }
        if (transform.position.y >= 5.5f)
        {
            transform.position = new Vector3(transform.position.x, 5.5f, 0.0f);
        }
        if (transform.position.z != 0.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        }

        //Movement key checks
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigBod.AddForce(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigBod.AddForce(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigBod.AddForce(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigBod.AddForce(Vector3.right * Time.deltaTime * speed);
        }
    }

    private void Shoot()
    {
        //If it's time to shoot, then shoot!
        if (Time.time > fireRate + lastShot)
        {
            GameObject instance = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            instance.GetComponent<Rigidbody>().velocity = shootDir * Time.deltaTime * 100.0f;

            if(powered && powerType == 1)
            {
                instance = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                Vector3 adjustment = Vector3.Cross(Vector3.forward, shootDir);
                Debug.Log(adjustment);

                instance.transform.position += adjustment.normalized;
                instance.GetComponent<Rigidbody>().velocity = shootDir * Time.deltaTime * 100.0f;

                instance = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                instance.transform.position -= adjustment.normalized;
                instance.GetComponent<Rigidbody>().velocity = shootDir * Time.deltaTime * 100.0f;
            }

            lastShot = Time.time;
        }
    }

    private void RotateToMousePos(Vector3 mousePos)
    {
        Vector3 direction = new Vector3(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y,
            0.0f);

        transform.up = direction;
        shootDir = direction;
    }
}
