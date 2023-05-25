using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModWalk : MonoBehaviour
{
    public float _mod;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyMoveAI>())
        {
            collision.GetComponent<EnemyMoveAI>().movementSpeed *= _mod;
        }
        else if (collision.GetComponent<PlayerMovement>())
        {
            collision.GetComponent<PlayerMovement>().moveSpeed *= _mod;
        }
    }
    
    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMoveAI>())
        {
            collision.GetComponent<EnemyMoveAI>().MoveSpeedRestart();
        }
        else if (collision.GetComponent<PlayerMovement>())
        {
            collision.GetComponent<PlayerMovement>().MoveSpeedReset();
        }
    }
}
