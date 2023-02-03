using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class EnemyController : MonoBehaviour
{
    [Min(0)]
    public float enemySpeedMultiplier = 0.05f;

    [Min(1)]
    public int health;
    [Min(1)]
    public int damage;

    Transform transformToChase;

    void OnTriggerEnter(Collider collision) {
        if (collision.tag == "MainCharacter")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.health -= damage;
            Debug.Log(player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    void handleMovement() {
        this.transform.LookAt(GameObject.FindWithTag("MainCharacter").transform);
        Vector3 newPosition = this.transform.position + new Vector3(this.transform.forward.x * enemySpeedMultiplier, 0f, this.transform.forward.z * enemySpeedMultiplier);
        this.transform.position = newPosition;
    }
}
