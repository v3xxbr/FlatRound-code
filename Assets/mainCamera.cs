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
            // Calcula a nova posi��o desejada (sobe suavemente e ajusta o eixo Z)
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, -Mathf.Abs(transform.position.z));

            // Move a c�mera em dire��o � posi��o do objeto stop de forma suave
            transform.position = Vector3.MoveTowards(transform.position, stop.position, speed * Time.deltaTime);

            // Importante: Espera o pr�ximo frame antes de verificar a condi��o novamente
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
