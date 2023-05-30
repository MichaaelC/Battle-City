using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int maxHealth = 1;
	[SerializeField] private int startingHealth = 1;
	[SerializeField] private int health;
	private Color originalColor;
	private SpriteRenderer sr;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		originalColor = sr.color;
		health = startingHealth;
	}

	public void GetDamage(int damage)
	{
		health -= damage;
		StartCoroutine(HitColor());
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

	private IEnumerator HitColor()
	{
        sr.color = Color.red;
        yield return new WaitForSeconds(.1f);
		sr.color = originalColor;
	}
}
