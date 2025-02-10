using Unity.Netcode;
using System.Collections;
using UnityEngine;

public class Bomb : NetworkBehaviour
{
    public GameObject cilindroVertical;
    public GameObject cilindroHorizontal;

    
    private void Start()
    {
        if (IsServer) 
        {
            StartCoroutine(ExplodirBomba());
        }
    }

    private IEnumerator ExplodirBomba()
    {
        
        yield return new WaitForSeconds(1f);

        
        ActivateExplosionServerRpc();

       
        yield return new WaitForSeconds(0.5f);

       
        DestroyBombServerRpc();
    }

    [ServerRpc]
    private void ActivateExplosionServerRpc()
    {
        
        cilindroHorizontal.SetActive(true);
        cilindroVertical.SetActive(true);

        
        ActivateExplosionClientRpc();
    }

    [ClientRpc]
    private void ActivateExplosionClientRpc()
    {
        // Ativa os cilindros da explosão nos clientes
        cilindroHorizontal.SetActive(true);
        cilindroVertical.SetActive(true);
    }

    [ServerRpc]
    private void DestroyBombServerRpc()
    {
        Destroy(gameObject); // Destroi a bomba no servidor
        DestroyBombClientRpc(); // Notifica os clientes para destruir a bomba
    }

    [ClientRpc]
    private void DestroyBombClientRpc()
    {
        Destroy(gameObject); // Destroi a bomba nos clientes
    }
}