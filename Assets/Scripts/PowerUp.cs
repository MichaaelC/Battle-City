using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    ExtraSpeed,
    IncreasedFirePower,
    Invincibility,
    EnemyDestroy
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public float powerUpDuration = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyPowerUpEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }
    public void ApplyPowerUpEffect(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        switch (powerUpType)
        {
            case PowerUpType.ExtraSpeed:
                playerMovement.IncreaseSpeed();
                break;
            case PowerUpType.EnemyDestroy:
                AI[] enemies = FindObjectsOfType<AI>();
                foreach(AI enemy in enemies)
                {
                    enemy.DestroyEnemy();
                }
                break;
            default:
                break;
        }
    }
   
}
