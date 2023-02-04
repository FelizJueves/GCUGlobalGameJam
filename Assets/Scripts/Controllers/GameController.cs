using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
         Scene CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene.name == "Level1")
        {
            Debug.Log("Level1");
        }
        else if (CurrentScene.name == "Level2")
        {
            Debug.Log("Level2");
        }
        else if (CurrentScene.name == "Level3")
        {
            Debug.Log("Level3");
        }
        else if (CurrentScene.name == "Level4")
        {
            Debug.Log("Level4");
        }
        else if (CurrentScene.name == "HubWorld")
        {
            Debug.Log("Hub World");
        }
    }
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            CheckLevel();
        }*/
        
    }
}
