using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWalk : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerMovement>().moveSpeed *= 1.25f;
        //collision.GetComponent<EnemyMovement>().speed *= 3f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<PlayerMovement>().MoveSpeedReset();
        //collision.GetComponent<EnemyMovement>().MoveSpeedRestart();
    }
}
