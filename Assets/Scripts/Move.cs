using UnityEngine;

public class Move : MonoBehaviour
{

    private Rigidbody rb;
    public float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        // Verifica as teclas pressionadas
        if (Input.GetKey(KeyCode.W)) // Move para frente
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S)) // Move para trás
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A)) // Move para a esquerda
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) // Move para a direita
        {
            movement += Vector3.right;
        }

        // Aplica movimento ao Rigidbody
        rb.MovePosition(transform.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
