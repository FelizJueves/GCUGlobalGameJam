using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class EnemyController : MonoBehaviour
{
    [Min(1)]
    public int health;
    [Min(1)]
    public int damage;
    [Min(0)]
    public float movementFactor;

    Transform transformToChase;

    void Start() {
        transformToChase = GameObject.FindWithTag("MainCharacter").transform;
        decideMesh();
    }

    void decideMesh() {
        GameController.gameController.setEnemyType(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        handleHealth();
        handleMovement();
    }

    void handleHealth() {
        if (this.health <= 0) {
            kill();
        }
    }

    public void kill() {
        Destroy(this.gameObject);
    }

    void handleMovement() {
        this.transform.LookAt(GameObject.FindWithTag("MainCharacter").transform);
        Vector3 newPosition = new Vector3(this.transform.forward.x * movementFactor, 0f, this.transform.forward.z * movementFactor);
        newPosition *= Time.deltaTime;
        this.transform.position += newPosition;
    }
}
