using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, 2.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "obs")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }

    }
}
