using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject cilindroVertical;
    public GameObject cilindroHorizontal;

    //public GameObject bomba;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(explodirBomba());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator explodirBomba()
    {
        yield return new WaitForSeconds(1f);
       // bomba.SetActive(false);
        cilindroHorizontal.SetActive(true);
        cilindroVertical.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
