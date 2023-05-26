using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] Transform box;
    public bool CheckGround;
    [SerializeField] LayerMask Ground;
    Vector2 center;
    Vector2 size;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        size = new Vector2(0.48f, 0.1f);
        center = new Vector3(box.position.x, box.position.y);
        CheckGround = Physics2D.OverlapBox(center, size, 0, Ground);
        DebugBox(center, size);
    }
    void DebugBox(Vector3 center, Vector3 size)
    {
        // Setup Point
        Vector3 topRightPoint = new Vector3(center.x - (size.x / 2), center.y + (size.y / 2));
        Vector3 downLeftPoint = new Vector3(center.x + (size.x / 2), center.y - (size.y / 2));

        // Draw Box
        Debug.DrawRay(topRightPoint, new Vector3(size.x, 0), Color.yellow);
        Debug.DrawRay(downLeftPoint, new Vector3(-size.x, 0), Color.yellow);
        Debug.DrawRay(topRightPoint, new Vector3(0, -size.y), Color.yellow);
        Debug.DrawRay(downLeftPoint, new Vector3(0, size.y), Color.yellow);
    }
}