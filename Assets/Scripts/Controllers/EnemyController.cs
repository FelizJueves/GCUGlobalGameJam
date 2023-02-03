using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class EnemyController : MonoBehaviour
{
    [Min(0)]
    public float enemySpeed = 0.05f;
    Transform transformToChase;

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    void handleMovement() {
        this.transform.LookAt(GameObject.FindWithTag("MainCharacter").transform);
        Vector3 newPosition = this.transform.position + new Vector3(this.transform.forward.x * enemySpeed, 0f, this.transform.forward.z * enemySpeed);
        this.transform.position = newPosition;
    }
}
