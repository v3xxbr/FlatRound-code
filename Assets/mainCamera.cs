using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    public float speed;
    public Transform stop;
    public GameObject endCredits;
    public GameObject trianguleEarth;

    private void Update()
    {
        UpingCamera();
        finalCredits();
    }

    void UpingCamera()
    {
        if (MrAllflet.defeated && !Eyestomb.defeated)
        {
            StartCoroutine(MoveCamera());
        }
    }

    IEnumerator MoveCamera()
    {
        while (transform.position.y < stop.position.y)
        {
            trianguleEarth.SetActive(true);

            yield return new WaitForSeconds(4f);
            // Calcula a nova posição desejada (sobe suavemente e ajusta o eixo Z)
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, -Mathf.Abs(transform.position.z));

            // Move a câmera em direção à posição do objeto stop de forma suave
            transform.position = Vector3.MoveTowards(transform.position, stop.position, speed * Time.deltaTime);

            // Importante: Espera o próximo frame antes de verificar a condição novamente
            yield return null;
        }
    }  

    void finalCredits()
    {
        if(transform.position.y == stop.position.y)
        {
            endCredits.SetActive(true);
        }
    }
}
