using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerBase;

    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private Vector3 basePosition;
    
    void Start()
    {
        playerBase = FindObjectOfType<HealthBase>().gameObject;
        basePosition = playerBase.transform.position;
        basePosition.Set(basePosition.x, basePosition.y, transform.position.z);
    }

    void FixedUpdate()
    {
        SetPlayer();
        Follow();
    }

    private void Follow()
    {
        if(player == null)
        {
            transform.position = Vector3.Lerp(transform.position, basePosition, 0.125f);
        }
        else
        {
            playerPosition.Set(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosition, 0.125f);
        }
    }

    private void SetPlayer()
    {
        if (player == null && FindAnyObjectByType<HealthPlayer>())
        {
            player = FindAnyObjectByType<HealthPlayer>().gameObject;
        }
    }
}
