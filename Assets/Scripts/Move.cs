using Unity.Netcode;
using UnityEngine;

public class Move : NetworkBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!IsOwner) return; 

        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movement += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            movement += Vector3.back;
        if (Input.GetKey(KeyCode.A))
            movement += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            movement += Vector3.right;

        movement = movement.normalized * moveSpeed * Time.fixedDeltaTime;

        MoveServerRpc(movement); 
    }

    [ServerRpc]
    private void MoveServerRpc(Vector3 movement)
    {
        rb.MovePosition(transform.position + movement);
    }
}