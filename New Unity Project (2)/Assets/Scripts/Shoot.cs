using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float startDelay;
    public float shootIncrement;
    public int ringPulseBulletAmount;
    public int rotateBulletAmount;
    public int rotationOffset = 0;
    public int sineOffset = 0;
    public bool sineDir = false;


    public bool random;
    public bool ringPulse;
    public bool rotate;
    public bool straight;
    public bool sine;
    public bool plus;
    public bool x;

    public int shotType;

    // Start is called before the first frame update
    void Start()
    {
        
        shotType = Random.Range(0, 7);
        if (shotType == 0)
            random = true;
        if (shotType == 1)
            straight = true;
        if (shotType == 2)
            plus = true;
        if (shotType == 3)
            x = true;
        if (shotType == 4)
            ringPulse = true;
        if (shotType == 5)
            rotate = true;
        if (shotType == 6)
            sine = true;


        if (random == true)
        {
            InvokeRepeating("randomShoot", startDelay, shootIncrement);
        }
        if (straight == true)
        {
            InvokeRepeating("straightShoot", startDelay, shootIncrement);
        }
        if (plus == true)
        {
            InvokeRepeating("plusShoot", startDelay, shootIncrement);
        }
        if (x == true)
        {
            InvokeRepeating("xShoot", startDelay, shootIncrement);
        }
        if (ringPulse == true)
        {
            InvokeRepeating("ringPulseShoot", startDelay, shootIncrement);
        }
        if (rotate == true)
        {
            InvokeRepeating("rotateBullets", startDelay, shootIncrement);
        }
        if (sine == true)
        {
            InvokeRepeating("sineWave", startDelay, shootIncrement);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void randomShoot()
    {
        GameObject instance = Instantiate(projectile, transform);
        instance.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * 5;
    }

    void straightShoot()
    {
        GameObject instance = Instantiate(projectile, transform);
        instance.GetComponent<Rigidbody>().velocity = new Vector3(0,-1,0) * 5;
    }

    void plusShoot()
    {
        GameObject instance = Instantiate(projectile, transform);
        GameObject instance1 = Instantiate(projectile, transform);
        GameObject instance2 = Instantiate(projectile, transform);
        GameObject instance3 = Instantiate(projectile, transform);
        instance.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 0) * 5;
        instance1.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 0) * 5;
        instance2.GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 0) * 5;
        instance3.GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 0) * 5;
    }
    void xShoot()
    {
        GameObject instance = Instantiate(projectile, transform);
        GameObject instance1 = Instantiate(projectile, transform);
        GameObject instance2 = Instantiate(projectile, transform);
        GameObject instance3 = Instantiate(projectile, transform);
        instance.GetComponent<Rigidbody>().velocity = new Vector3(1, -1, 0).normalized * 5;
        instance1.GetComponent<Rigidbody>().velocity = new Vector3(-1, 1, 0).normalized * 5;
        instance2.GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 0).normalized * 5;
        instance3.GetComponent<Rigidbody>().velocity = new Vector3(-1, -1, 0).normalized * 5;
    }

    void ringPulseShoot()
    {
        Vector3 center = transform.position;
        for (int i = 0; i < ringPulseBulletAmount ; i++)
        {
            float degree = ((360 / ringPulseBulletAmount) * i);
            Vector3 pos = placeOnCircle(center, 1.0f, (int)degree);
            Quaternion rot = Quaternion.FromToRotation(Vector3.right, center - pos);
            GameObject temp = Instantiate(projectile, pos, rot, gameObject.transform);
            //temp.transform.parent = gameObject.transform;
            temp.GetComponent<Rigidbody>().velocity = temp.transform.right.normalized * -5;
        }
    }

    void rotateBullets()
    {
        Vector3 center = transform.position;
        for (int i = 0; i < rotateBulletAmount; i++)
        {
            float degree = (((360 / rotateBulletAmount) * i) + rotationOffset);
            rotationOffset += 3;
            rotationOffset = rotationOffset % 360;
            Vector3 pos = placeOnCircle(center, 1.0f, (int)degree);
            Quaternion rot = Quaternion.FromToRotation(Vector3.right, center - pos);
            GameObject temp = Instantiate(projectile, pos, rot, gameObject.transform);
            temp.GetComponent<Rigidbody>().velocity = temp.transform.right.normalized * -5;
        }
    }

    void sineWave()
    {
        Vector3 center = transform.position;
        for (int i = 0; i < rotateBulletAmount; i++)
        {
            float degree = (((360 / rotateBulletAmount) * i) + sineOffset);
            if (sineOffset > 40)
            {
                sineDir = true;
                sineOffset -= 3;
            }
            else if(sineOffset < -40)
            {
                sineDir = false;
                sineOffset += 3;
            }
            else if (sineDir)
            {
                sineOffset -= 3;
            }
            else
            {
                sineOffset += 3;
            }
            rotationOffset = rotationOffset % 360;
            Vector3 pos = placeOnCircle(center, 1.0f, (int)degree);
            Quaternion rot = Quaternion.FromToRotation(Vector3.right, center - pos);
            GameObject temp = Instantiate(projectile, pos, rot, gameObject.transform);
            temp.GetComponent<Rigidbody>().velocity = temp.transform.right.normalized * -5;
        }
    }

    Vector3 placeOnCircle(Vector3 center, float radius, int angle)
    {
        float ang = angle;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }



}
