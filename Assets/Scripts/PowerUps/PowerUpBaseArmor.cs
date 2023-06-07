using UnityEngine;

public class PowerUpBaseArmor : MonoBehaviour
{
    [SerializeField] private int additionalBaseArmor = 2;
    
    private HealthPlayer pickerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out pickerHealth))
        {
            if (pickerHealth != null)
            {
                FindObjectOfType<HealthBase>().ModifyHealth(additionalBaseArmor);
            }
            Debug.Log("PowerUp - Base Armor Up");
            Destroy(this.gameObject);
        }
    }
}
