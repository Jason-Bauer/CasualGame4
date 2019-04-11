using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCShield : MonoBehaviour
{

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
        gameObject.transform.position += player.GetComponent<Player>().shootDir.normalized;
        gameObject.transform.up = player.GetComponent<Player>().transform.up;
    }
}
