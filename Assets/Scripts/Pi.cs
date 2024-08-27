using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
        StartCoroutine(DestroyPi());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "MrAllflet")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyPi()
    {
        yield return new WaitForSeconds(1.4f);
        Destroy(gameObject);
    }
}

