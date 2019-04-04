using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int powerType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }
 
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            switch(powerType)
            {
                case 1:
                    col.gameObject.GetComponent<Player>().fireRate /= 2;
                    col.gameObject.GetComponent<Player>().powered = true;
                    col.gameObject.GetComponent<Player>().powerStart = Time.time;
                    col.gameObject.GetComponent<Player>().powerType = powerType;
                    break;
                case 2:
                    col.gameObject.GetComponent<Player>();
                    break;
                case 3:
                    col.gameObject.GetComponent<Player>();
                    break;
                default:
                    col.gameObject.GetComponent<Player>().fireRate /= 2;
                    break;
            }

            Destroy(gameObject);
        }

    }
}
