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
            if(this.transform.parent.CompareTag("Level1Tele"))
            {
                SceneManager.LoadScene(1);
            }
            else if(this.transform.parent.CompareTag("Level2Tele"))
            {
                SceneManager.LoadScene(2);
            }
            else if (this.transform.parent.CompareTag("Level3Tele"))
            {
                SceneManager.LoadScene(3);
            }
            else if (this.transform.parent.CompareTag("Level4Tele"))
            {
                SceneManager.LoadScene(4);
            }
            else if (this.transform.parent.CompareTag("HomeTele"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
        


}
