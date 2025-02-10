using Unity.Netcode;
using UnityEngine;

public class BombController : NetworkBehaviour
{
    public GameObject bombaPrefab;
    public GameObject bombaAtual = null;
    public GameObject player;

    public float raycastDistance = 2f;

    void Update()
    {
        if (IsOwner && Input.GetKeyUp(KeyCode.Space) && bombaAtual == null)
        {
            
            InstantiateBombServerRpc(player.transform.position, bombaPrefab.transform.rotation);
        }
    }

    [ServerRpc]
    private void InstantiateBombServerRpc(Vector3 position, Quaternion rotation)
    {
        GameObject bomba = Instantiate(bombaPrefab, position, rotation);
        bomba.GetComponent<NetworkObject>().Spawn(); 
    }
}