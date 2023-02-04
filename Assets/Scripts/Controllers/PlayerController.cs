using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class PlayerController : MonoBehaviour
{
    public BulletController bullet;
    
    [Min(1)]
    public int health;
    [Min(0)]
    public float movementFactor;

    bool isDead;

    // Update is called once per frame
    void Update()
    {
        handleHealth();

        if(!isDead) {
            handleMovement();
            handleActions();
        }
        
    }

    void handleHealth() {
        if (health <= 0) {
            kill();
        }
    }

    void handleMovement() {
        Vector3 newPosition = new Vector3(Input.GetAxis("Horizontal") * movementFactor, 0f, Input.GetAxis("Vertical") * movementFactor);
        newPosition *= Time.deltaTime;
        this.transform.position += newPosition;
    }

    void handleActions() {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
        }
    }

    void kill() {
        isDead = true;
    }

    public override string ToString() {
        return string.Format("Health: {0}", health);
    }
}
