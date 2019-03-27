using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float startDelay;
    public float shootIncrement;
    public int ringPulseBulletAmount;
    public bool random;
    public bool ringPulse;
    public bool straight;
    public bool curve;
    public bool plus;
    public bool x;

    // Start is called before the first frame update
    void Start()
    {
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
