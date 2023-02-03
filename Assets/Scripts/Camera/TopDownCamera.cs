using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public GameObject attachTo;
    [Min(1f)]
    public float heightOffset;

    void LateUpdate() {
        Vector3 offset = new Vector3(attachTo.transform.position.x, attachTo.transform.position.y + heightOffset, attachTo.transform.position.z);
        this.transform.position = offset;
    }
}
