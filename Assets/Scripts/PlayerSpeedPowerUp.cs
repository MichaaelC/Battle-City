using System.Collections;
using UnityEngine;

public class PlayerSpeedPowerUp : MonoBehaviour
{
    public float speedMultiplier = 1.5f;
    public float powerUpDuration = 5f;

    private static bool powerUpActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !powerUpActivated)
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                powerUpActivated = true;

                playerMovement.IncreaseSpeed(speedMultiplier);
                StartCoroutine(ResetSpeed(playerMovement, powerUpDuration));
                DisablePowerUp();
                //GetComponent<Collider2D>().enabled = false;
                //GetComponent<SpriteRenderer>().enabled = false;
                //gameObject.SetActive(false);
                //Destroy(gameObject);
            }
        }
    }

    private IEnumerator ResetSpeed(PlayerMovement playerMovement, float duration)
    {
        yield return new WaitForSeconds(duration);
        playerMovement.MoveSpeedReset();
        powerUpActivated = false;
        Destroy(this.gameObject);
        //EnablePowerUp();
        //GetComponent<Collider2D>().enabled = true;
        //GetComponent<SpriteRenderer>().enabled = true;
        //gameObject.SetActive(true);
    }

    public void DisablePowerUp()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            Debug.Log("PowerUp");
            collider.enabled = false;
        }

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }

    public void EnablePowerUp()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            Debug.Log("No Power Up");
            collider.enabled = true;
        }

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = true;
        }
    }
}