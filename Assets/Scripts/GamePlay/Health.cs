using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int maxHealth = 10;
	[SerializeField] private int startingHealth = 1;
	[SerializeField] private int health;
	
	private SpriteRenderer sr;
	private Color originalColor;

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
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

	public void ModifyHealth(int value)
	{
		health += value;
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
