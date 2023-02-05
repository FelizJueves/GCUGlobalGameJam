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
        GameController.gameController.decrementEnemies();
        Destroy(this.gameObject);
    }

    void handleMovement() {
        Transform transform = this.transform.parent;
        transform.LookAt(transformToChase);
        Vector3 newPosition = new Vector3(transform.forward.x * movementFactor, 0f, transform.forward.z * movementFactor);
        newPosition *= Time.deltaTime;
        transform.position += newPosition;
    }
}
