using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class CrosshairController : MonoBehaviour
{
    [Min(0f)]
    public float floorOffset;

    [Min(1f)]
    public float circleRadius;
    Camera mainCamera;

    readonly float HEIGHTOVERTWO = Screen.height/2;
    readonly float WIDTHOVERTWO = Screen.width/2;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        Vector3 mouse = Vector2.ClampMagnitude(new Vector2(Input.mousePosition.x - WIDTHOVERTWO,Input.mousePosition.y - HEIGHTOVERTWO), circleRadius);
        mouse.z = mainCamera.transform.position.y - floorOffset;
        mouse = new Vector3(mouse.x + WIDTHOVERTWO, mouse.y + HEIGHTOVERTWO, mouse.z);
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mouse);
        
        this.transform.position = worldPosition;
    }
}
