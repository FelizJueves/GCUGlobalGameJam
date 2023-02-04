using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;

    public float movementFactor;

    float timeToLive;
    // Start is called before the first frame update
    void Start()
    {
        timeToLive = 1f / movementFactor;
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
        if (timeToLive < 0f) {
            Destroy(this.gameObject);
        }
    }

    void handleMovement() {
        Vector3 newPosition = new Vector3(this.transform.forward.x * movementFactor, 0f, this.transform.forward.z * movementFactor);
        this.transform.position += newPosition;
    }
}
