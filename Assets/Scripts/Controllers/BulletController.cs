using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;

    public float movementFactor;
    public int MultiKill;
    GameController gameController;

    public float timeToLive;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.LookAt(GameObject.FindWithTag("Crosshair").transform);
        gameController = GameController.gameController;
    }

    // Update is called once per frame
    void Update()
    {
        handleLifetime();
        handleMovement();
    }

    void OnTriggerEnter(Collider collision) {
        switch(collision.tag) {
            case "Enemy":
                EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
                enemy.kill();
                this.KillCounter();
                break;
        }
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
            gameController.UpdateScore(KillScore);
        }
        else if (MultiKill == 2)
        {
            KillScore = 250;
            gameController.UpdateScore(KillScore);
        }
        else if (MultiKill == 3)
        {
            KillScore = 400;
            gameController.UpdateScore(KillScore);
        }
        else if (MultiKill == 4) 
        {
            KillScore = 650;
            gameController.UpdateScore(KillScore);
        }
        else if (MultiKill >= 5)
        {
            KillScore = 1000;
            gameController.UpdateScore(KillScore);
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
