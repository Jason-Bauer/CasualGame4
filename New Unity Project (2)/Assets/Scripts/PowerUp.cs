using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int powerType;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    // Start is called before the first frame update
    void Start()
    {
        switch(powerType)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = sprite1;

                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = sprite2;

                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = sprite3;

                break;
            default:
                break;
        }
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
                case 0:
                    col.gameObject.GetComponent<Player>().fireRate /= 2;
                    col.gameObject.GetComponent<Player>().powered = true;
                    col.gameObject.GetComponent<Player>().powerStart = Time.time;
                    col.gameObject.GetComponent<Player>().powerType = powerType;
                    break;
                case 1:
                    col.gameObject.GetComponent<Player>();
                    break;
                case 2:
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
