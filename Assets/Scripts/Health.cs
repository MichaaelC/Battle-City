using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int maxHealth = 1;
	[SerializeField] private int startingHealth = 1;
	[SerializeField]private int health;

	void Start()
	{
		health = startingHealth;
	}

	public void GetDamage(int damage)
	{
		health -= damage;
		if(health >= maxHealth)
		{
			health = maxHealth;
		}
        else if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

	public void ResetHealth()
	{
		health = startingHealth;
	}
}
