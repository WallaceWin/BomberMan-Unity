using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject bombaPrefeb;

    public GameObject bombaAtual = null;
    public GameObject player;
    
    public float raycastDistance = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Space) && bombaAtual == null)
        {
            Instantiate(bombaPrefeb, player.transform.position, bombaPrefeb.transform.rotation);
        }
    }
}
