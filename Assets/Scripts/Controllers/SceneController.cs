using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //public GameObject collision;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "MainCharacter")
        {
            SceneManager.LoadScene(1);
        }
    }
        


}
