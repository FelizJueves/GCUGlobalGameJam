using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class CrosshairController : MonoBehaviour
{
    [Min(0f)]
    public float floorOffset;

    void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = Camera.main.transform.position.y - floorOffset;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouse);
        this.transform.position = worldPosition;
    }
}
