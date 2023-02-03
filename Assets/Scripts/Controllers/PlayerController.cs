using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class PlayerController : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    void handleMovement() {
        Vector3 newPostition = this.transform.position;
        newPostition.x += Input.GetAxis("Horizontal");
        newPostition.z += Input.GetAxis("Vertical");

        this.transform.position = newPostition;
    }
}
