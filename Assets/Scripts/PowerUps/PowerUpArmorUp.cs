using UnityEngine;

public class PowerUpArmorUp : MonoBehaviour
{
    [SerializeField] int additionalArmor = 1;
    private Health pickerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out pickerHealth))
        {
            if (pickerHealth != null)
            {
                pickerHealth.ModifyHealth(additionalArmor);
            }
            Destroy(this.gameObject);
            Debug.Log("PowerUp - Speed");
        }
    }
}
