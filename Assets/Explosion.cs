using Unity.Netcode;
using UnityEngine;

public class Explosion : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caixa"))
        {
            Debug.Log("Explosão atingiu uma caixa!");

            
            if (IsServer)
            {
                NetworkObject networkObject = other.GetComponent<NetworkObject>();
                if (networkObject != null)
                {
                    networkObject.Despawn(); 
                }
            }
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Explosão atingiu um jogador!");

            if (IsServer)
            {
                NetworkObject playerNetworkObject = other.GetComponent<NetworkObject>();
                if (playerNetworkObject != null)
                {
                    playerNetworkObject.Despawn(); 
                }
            }
        }
    }
}