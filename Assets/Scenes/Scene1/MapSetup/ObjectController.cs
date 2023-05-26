using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class ObjectController : MonoBehaviour
{
    [SerializeField] Vector2 position;
    [SerializeField] float Length;
    [SerializeField] LayerMask Ground;
    [SerializeField] float FlatformSpeed;
    [SerializeField] float MoveSpeed;
    private Rigidbody2D rb;
    RaycastHit2D rayCheck;
    Color Raycolor;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector2 center;
    Vector2 Direction;
    
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        rb = GetComponent<Rigidbody2D>();
        Direction = Vector2.right;
        FlatformSpeed = 3;
        MoveSpeed = FlatformSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        rayCast();
        platformMovement();
        transform.position = Vector2.MoveTowards(transform.position, Direction, MoveSpeed * Time.deltaTime);
    }
    void rayCast()
    {
        if (rayCheck)
            Raycolor = Color.green;
        else
            Raycolor = Color.red;
        rayCheck = Physics2D.Raycast(startPoint, Direction, Length, Ground);
        startPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        endPoint = new Vector3(Length, 0);
        Debug.DrawRay(startPoint, endPoint, Raycolor);
    }
    void platformMovement()
    {
        if (rayCheck && Direction == Vector2.right)
        {
            Direction = new Vector2(1, 0);
            MoveSpeed = -FlatformSpeed;
        }
        else if (rayCheck && Direction == Vector2.left)
        {
            Direction = new Vector2(-1, 0);
            MoveSpeed = FlatformSpeed;
        }
        else
        { }
    }
}
