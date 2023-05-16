using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    
    //public float rayCastDistance = 10f;
    private Transform tf;
    //public LayerMask obstacleLayer;
    private float moveSpeedOriginal;
    private Rigidbody2D rb;
    private int currentDirectionIndex = 0;
    private float timeSinceLastDirectionChange = 0f;
    //public float direction;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        moveSpeedOriginal = speed;
    }
    private void FixedUpdate()
    {
        rb.velocity = directions[currentDirectionIndex] * speed;

        /*if (Vector2.Dot(rb.velocity, directions[currentDirectionIndex]) < 0)
        {
            
            currentDirectionIndex = (currentDirectionIndex + 1) % directions.Length;
        }*/

        //RaycastHit2D collide = Physics2D.BoxCast(transform.position,  new Vector2 (1.5f, 1.5f), 0f, transform.forward);
        RaycastHit2D collide = Physics2D.Raycast(transform.position, directions[currentDirectionIndex]);
        Debug.Log(collide.collider);
        if (collide.distance < 1.5f)
        {
            Debug.Log("asdsdasasd");
            rb.velocity = Vector2.zero;
            /*Debug.Log("asdsd");
            rb.velocity = Vector2.zero;
            currentDirectionIndex = (currentDirectionIndex + 1) % directions.Length;*/
        }

        timeSinceLastDirectionChange += Time.fixedDeltaTime;
        if (timeSinceLastDirectionChange >= 1)
        {
            currentDirectionIndex = Random.Range(0, directions.Length);
            timeSinceLastDirectionChange =0f;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + transform.forward, transform.localScale);
    }

    /*public void MoveSpeedRestart()
    {
        speed = moveSpeedOriginal;
    }*/

}
