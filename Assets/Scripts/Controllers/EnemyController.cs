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

    void OnTriggerEnter(Collider collision) {
        switch(collision.tag) {
            case "MainCharacter":
                MainCharacterCollision(collision.gameObject.GetComponent<PlayerController>());
                break;
            case "Bullet":
                BulletCollision(collision.gameObject.GetComponent<BulletController>());
                break;
        }
    }

    void MainCharacterCollision(PlayerController player) {
        player.health -= damage;
        Destroy(this.gameObject);
    }

    void BulletCollision(BulletController bullet) {
        this.health -= bullet.damage;
        Destroy(bullet.gameObject);
    }

    void Awake() {
        transformToChase = GameObject.FindWithTag("MainCharacter").transform;
        decideMesh();
    }

    void decideMesh() {
        GetComponent<MeshFilter>().mesh = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().getEnemyMesh();
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

    void kill() {
        Destroy(this.gameObject);
    }

    void handleMovement() {
        this.transform.LookAt(GameObject.FindWithTag("MainCharacter").transform);
        Vector3 newPosition = new Vector3(this.transform.forward.x * movementFactor, 0f, this.transform.forward.z * movementFactor);
        newPosition *= Time.deltaTime;
        // this.GetComponent<Rigidbody>().MovePosition(newPosition);
        this.transform.position += newPosition;
    }
}
