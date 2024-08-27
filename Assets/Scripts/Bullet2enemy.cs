using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2enemy : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento
    private Transform player; // Referência ao transform do jogador
    private bool isMovingTowardsPlayer = true;
    private Vector2 initialDirection;
    public int radiouss;
    public LayerMask playerLayer;

    public GameObject explosion;
    public GameObject pointCenter;

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
        Explosion();

        if (isMovingTowardsPlayer)
        {
            MoveTowardsPlayerOnce();
        }
        else
        {
            // Continue se movendo em linha reta após o movimento inicial em direção ao jogador
            transform.Translate(initialDirection * speed * Time.deltaTime);
        }
    }

    void MoveTowardsPlayerOnce()
    {
        // Move em direção ao jogador no momento da instância
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        StartCoroutine(StopStraight());
    }

    IEnumerator StopStraight()
    {
        yield return new WaitForSeconds(0.9f);
        isMovingTowardsPlayer = false;
    }

    void Explosion()
    {
        Collider2D area = Physics2D.OverlapCircle(transform.position, radiouss, playerLayer);
        if(area != null)
        {
            StartCoroutine(Boom());
        }
    }
    IEnumerator Boom()
    {
        yield return new WaitForSeconds(0.9f);
        Instantiate(explosion, pointCenter.transform.position, pointCenter.transform.rotation);
        gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiouss);
    }
}
