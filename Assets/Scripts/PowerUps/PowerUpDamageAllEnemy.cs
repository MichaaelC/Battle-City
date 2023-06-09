using UnityEngine;

public class PowerUpDamageAllEnemy : MonoBehaviour
{
    [SerializeField] private int damage = 2;
    
    private HealthEnemy[] enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthPlayer>())
        {
            enemies = FindObjectsByType<HealthEnemy>(FindObjectsSortMode.None);
            foreach (var enemy in enemies)
            {
                enemy.GetDamage(damage);
            }
        }
        Destroy(this.gameObject);
        Debug.Log("PowerUp - Damage All Enemy");
    }
}