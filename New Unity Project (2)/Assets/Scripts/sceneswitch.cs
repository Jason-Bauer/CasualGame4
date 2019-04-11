using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneswitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void switcher(int i){
        SceneManager.LoadScene(i);
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
