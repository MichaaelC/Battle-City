using UnityEngine;

public class PowerUpModifyAllEnemyMovement : MonoBehaviour
{
    [SerializeField] float movementModificationMultiplier = 0.5f;
    private EnemyMoveAI[] enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthPlayer>())
        {
            enemies = FindObjectsByType<EnemyMoveAI>(FindObjectsSortMode.None);
            foreach(var enemy in enemies)
            {
                enemy.ModifySpeed(movementModificationMultiplier);
            }
        }
    }
}