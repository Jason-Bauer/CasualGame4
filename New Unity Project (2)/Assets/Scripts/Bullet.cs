using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject projectile;
    public bool deathExplode = false;
    // Start is called before the first frame update
    void Start()
    {
        if(deathExplode == true)
        {
            Object.Destroy(gameObject, .5f);
        }
        else
        {
            Object.Destroy(gameObject, 2.0f);
        }
        
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "obs")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            col.gameObject.GetComponent<Player>().updatehealth();
        }

    }

    void OnDestroy()
    {
        if (deathExplode)
        {
            Vector3 center = transform.position;
            for (int i = 0; i < 3; i++)
            {
                float degree = (((360 / 3) * i)+120);
                Vector3 pos = placeOnCircle(center, 1.0f, (int)degree);
                Quaternion rot = Quaternion.FromToRotation(Vector3.right, center - pos);
                GameObject temp = Instantiate(projectile, pos, rot);
                temp.GetComponent<Rigidbody>().velocity = temp.transform.right.normalized * -5;
                temp.gameObject.name = "bul" + i;
                temp.SetActive(true);
                temp.gameObject.GetComponent<Bullet>().deathExplode = false;
                temp.transform.localScale = new Vector3(0.05f, .05f, .05f);
            }
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
