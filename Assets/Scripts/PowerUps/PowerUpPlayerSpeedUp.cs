using System.Collections;
using UnityEngine;

public class PlayerSpeedPowerUp : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float powerUpDuration = 3f;

    private Collider2D col;
    private SpriteRenderer sr;
    private PlayerMovement playerMovement;

    private static bool powerUpActivated = false;
    private static Coroutine speedUpCoroutine;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out playerMovement))
        {
            if (playerMovement != null)
            {
                if (powerUpActivated)
                {
                    StopCoroutine(speedUpCoroutine);
                    speedUpCoroutine = StartCoroutine(ResetSpeed(playerMovement, powerUpDuration));
                }
                else
                {
                    powerUpActivated = true;
                    playerMovement.ModifySpeed(speedMultiplier);
                    speedUpCoroutine = StartCoroutine(ResetSpeed(playerMovement, powerUpDuration));
                }
                DisablePowerUp();
                Debug.Log("PowerUp - Speed");
            }
        }
    }

    private IEnumerator ResetSpeed(PlayerMovement playerMovement, float duration)
    {
        yield return new WaitForSeconds(duration);
        playerMovement.MoveSpeedReset();
        powerUpActivated = false;
        Destroy(this.gameObject);
    }

    public void DisablePowerUp()
    {
        if (col != null)
        {
            col.enabled = false;
        }

        if (sr != null)
        {
            sr.enabled = false;
        }
    }
}