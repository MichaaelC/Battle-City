using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public bool isEnabled = true;

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject player;

    public void SpawnPlayer()
    {
        if (isEnabled)
        {
            player = Instantiate(playerPrefab, transform.position, transform.rotation);
            player.transform.parent = transform;
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}