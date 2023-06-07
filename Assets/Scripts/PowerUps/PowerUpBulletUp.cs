using UnityEngine;

public class PowerUpBulletUp : MonoBehaviour
{
    [SerializeField] private float multiplierFireRate = 1f;
    [SerializeField] private float multiplierSpeed = 1f;
    [SerializeField] private int additionalPower = 1;
    [SerializeField] private int additionalHealth = 1;
    
    private PlayerShoot pickerShoot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out pickerShoot))
        {
            if (pickerShoot != null)
            {
                pickerShoot.ModifyShootProperties(multiplierFireRate, multiplierSpeed, additionalPower, additionalHealth);
            }
            Destroy(this.gameObject);
            Debug.Log("PowerUp - BulletUp");
        }
    }
}