using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform moveMe;
    //bool goLeft;
    //bool goRight;
    public GameObject enemy;
    public GameObject score;
    private Vector3 randDir;
    float enemyx;

    int clusterChance;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Manager");
        moveMe = gameObject.GetComponent<Transform>();

        //if (enemy.transform.position.x >= 0)
        //{
        //    goLeft = true;
        //
        //}
        //else
        //{
        //    goRight = true;
        //}

        randDir = new Vector3(Random.Range(-1.5f,1.5f), Random.Range(-1.5f,1.5f), 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (goLeft == true)
        //    moveMe.position += new Vector3(-.01f, 0, 0);
        //
        //if (goRight == true)
        //    moveMe.position += new Vector3(.01f, 0, 0);
        //
        //if (enemy.transform.position.x > 9.5)
        //{
        //    goLeft = true;
        //
        //    goRight = false;
        //}
        //
        //if (enemy.transform.position.x < -9.5)
        //{
        //    goLeft = false;
        //
        //    goRight = true;
        //}

        moveMe.position += randDir * Time.deltaTime;

        CheckBounds();

    }

    void CheckBounds()
    {
        if (enemy.transform.position.x <= -10f)
        {
            randDir.x *= -1.0f;
        }
        if (enemy.transform.position.x >= 10f)
        {
            randDir.x *= -1.0f;
        }
        if (enemy.transform.position.y <= -5.5f)
        {
            randDir.y *= -1.0f;
        }
        if (enemy.transform.position.y >= 5.5f)
        {
            randDir.y *= -1.0f;
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

    void OnDestroy()
    {
        clusterChance = Random.Range(0, 101);
        if (clusterChance < 5)
        {
            int numberOfEnemies = Random.Range(1, 5);
            Vector3 center = transform.position;
            for (int i =0; i<numberOfEnemies; i++)
            {
                float degree = (((360 / numberOfEnemies) * i)+45);
                Vector3 pos = placeOnCircle(center, 1.0f, (int)degree);
                Quaternion rot = Quaternion.FromToRotation(Vector3.right, center - pos);
                GameObject temp = Instantiate(enemy, pos, rot);
                temp.SetActive(true);
                temp.gameObject.GetComponent<Enemy>().enabled = true;
                temp.gameObject.GetComponent<Shoot>().enabled = true;
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
