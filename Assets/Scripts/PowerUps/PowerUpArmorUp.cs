using UnityEngine;

public class PowerUpArmorUp : MonoBehaviour
{
    [SerializeField] private int additionalArmor = 1;
    private Health pickerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out pickerHealth))
        {
            if (pickerHealth != null)
            {
                pickerHealth.ModifyHealth(additionalArmor);
            }
            Debug.Log("PowerUp - Armor Up");
            Destroy(this.gameObject);
        }
    }
}