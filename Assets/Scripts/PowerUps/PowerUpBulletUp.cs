using UnityEngine;

public class PowerUpBulletUp : MonoBehaviour
{
    [SerializeField] private float additionalFireRate= 1f;
    [SerializeField] private float additionalSpeed = 1f;
    [SerializeField] private int additionalPower = 1;
    [SerializeField] private int additionalHealth = 1;
    private PlayerShoot pickerShoot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out pickerShoot))
        {
            if (pickerShoot != null)
            {
                pickerShoot.ModifyShootProperties(additionalFireRate, additionalSpeed, additionalPower, additionalHealth);
            }
            Destroy(this.gameObject);
            Debug.Log("PowerUp - BulletUp");
        }
    }
}
