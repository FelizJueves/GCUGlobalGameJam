using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;

    public float movementFactor;
    public int MultiKill;
    public GameObject GameController;

    public float timeToLive;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.LookAt(GameObject.FindWithTag("Crosshair").transform);
    }

    // Update is called once per frame
    void Update()
    {
        handleLifetime();
        handleMovement();
    }

    void handleLifetime() {
        timeToLive -= Time.deltaTime;
        if (timeToLive < 0f)
        {
            kill();
        }
    }

    void kill()
    {
        int KillScore = 0;

        if (MultiKill == 1)
        {
            KillScore = 100;
            GameController.GetComponent<GameController>().UpdateScore(KillScore);
        }
        else if (MultiKill == 2)
        {
            KillScore = 250;
            GameController.GetComponent<GameController>().UpdateScore(KillScore);
        }
        else if (MultiKill == 3)
        {
            KillScore = 400;
            GameController.GetComponent<GameController>().UpdateScore(KillScore);
        }
        else if (MultiKill == 4) 
        {
            KillScore = 650;
            GameController.GetComponent<GameController>().UpdateScore(KillScore);
        }
        else if (MultiKill >= 5)
        {
            KillScore = 1000;
            GameController.GetComponent<GameController>().UpdateScore(KillScore);
        }

        Destroy(this.gameObject);
    }

    void handleMovement() {
        Vector3 newPosition = new Vector3(this.transform.forward.x * movementFactor, 0f, this.transform.forward.z * movementFactor);
        this.transform.position += newPosition;
    }
    public void KillCounter()
    {
        MultiKill++;
    }
    
}
