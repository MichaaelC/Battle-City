using UnityEngine;

public class ModWalk : MonoBehaviour
{
    [SerializeField] private float modifier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyMoveAI>())
        {
            collision.GetComponent<EnemyMoveAI>().movementSpeed *= modifier;
        }
        else if (collision.GetComponent<PlayerMovement>())
        {
            collision.GetComponent<PlayerMovement>().moveSpeed *= modifier;
        }
    }
    
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
