using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet1 : MonoBehaviour
{

    public float speed = 5f; // Velocidade de movimento
    private Transform player; // Refer�ncia ao transform do jogador
    private bool isMovingTowardsPlayer = true;
    private Vector2 initialDirection;

    void Start()
    {
        bullets hitClass = new bullets();
        hitClass.speed = 5;
        hitClass.damage = 1;
        hitClass.bullet = this.gameObject;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        isMovingTowardsPlayer = true;
        initialDirection = (player.position - transform.position).normalized;
    }

    void Update()
    {
       
        if (isMovingTowardsPlayer)
        {
            MoveTowardsPlayerOnce();
        }
        else
        {
            // Continue se movendo em linha reta ap�s o movimento inicial em dire��o ao jogador
            transform.Translate(initialDirection * speed * Time.deltaTime);
            StartCoroutine(Destroy());
        }
    }

    void MoveTowardsPlayerOnce()
    {
        // Move em dire��o ao jogador no momento da inst�ncia
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        StartCoroutine(StopStraight());
    }

    IEnumerator StopStraight()
    {
        yield return new WaitForSeconds(0.9f);
        isMovingTowardsPlayer = false;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.8f);
        Destroy(gameObject);
    }
}
