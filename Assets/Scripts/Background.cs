using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float velocidade = 5f; // Ajuste a velocidade conforme necessário
    public float larguraDoFundo = 15f; // Ajuste a largura conforme necessário

    void Update()
    {
        MoveFundo();
    }

    void MoveFundo()
    {
        float movimento = velocidade * Time.deltaTime;
        transform.Translate(Vector3.right * movimento);

        // Verifique se o fundo precisa ser reposicionado para criar o efeito de looping
        if (transform.position.x > larguraDoFundo)
        {
            RepositionarFundo();
        }
    }

    void RepositionarFundo()
    {
        // Reposiciona o fundo para a esquerda
        transform.position = new Vector3(transform.position.x - larguraDoFundo * 2, transform.position.y, transform.position.z);
    }
}
