using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class PlayerController : MonoBehaviour
{
    bool isDead;
    public int health;
    public float movementFactor;

    // Update is called once per frame
    void Update()
    {
        handleHealth();
        handleMovement();
    }

    void handleHealth() {
        if (health <= 0) {
            kill();
        }
    }

    void kill() {
        isDead = true;
    }

    void handleMovement() {
        if (isDead) return;
        Vector3 newPostition = this.transform.position;
        newPostition.x += Input.GetAxis("Horizontal") * movementFactor;
        newPostition.z += Input.GetAxis("Vertical") * movementFactor;

        this.transform.position = newPostition;
    }

    public override string ToString() {
        return string.Format("Health: {0}", health);
    }
}
