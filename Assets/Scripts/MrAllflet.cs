using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrAllflet : MonoBehaviour
{
    public int health = 300;

    [Header("shooting")]
    public GameObject[] pos;
    public GameObject[] bullets;
    float time;

    public GameObject lamp;

    private SpriteRenderer spr;
    private Animator anim;
    public static bool defeated;

    public Transform swimPos;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!defeated)
        {
            anim.SetInteger("transition", 0);
            SpawnBullet();
            Death();
            Animations();
        }

        else if(defeated)
        {
            StartCoroutine(Defeated());
        }
    }

    void SpawnBullet()
    {
        if(!Eyestomb.defeated && !Eyestomb.entering)
        {
            time = time + Time.deltaTime;
            if (time >= 0.9f)
            {
                int x = Random.Range(0, 3);
                int b = Random.Range(0, 2);
                Instantiate(bullets[b], pos[x].transform.position, Quaternion.identity);
                time = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pi")
        {
            health -= 3;
            StartCoroutine(Flick());
        }
            if(health == 200 || (health == 100))
            {
                StartCoroutine(Lamp());
            }
    }

    IEnumerator Flick()
    {
        //flick
        yield return new WaitForSeconds(1.4f);
        spr.color = new Color(212, 173, 173, 255);
        yield return new WaitForSeconds(0.2f);
        spr.color = new Color(212, 173, 173, 255);
        yield return new WaitForSeconds(0.2f);
        spr.color = new Color(212, 173, 173, 255);
        yield return new WaitForSeconds(0.2f);
        spr.color = new Color(212, 173, 173, 255);
    }

    IEnumerator Lamp()
    {
        lamp.SetActive(true);
        yield return new WaitForSeconds(3f);
        lamp.SetActive(false);
    }

    void Death()
    {
          if(health <= 0)
          {
             defeated = true;
          }
    }

    void Animations()
    {
        //laugh
        if(Eyestomb.takeDamage || Eyestomb.defeated || Eyestomb.entering)
        {
            anim.SetInteger("transition", 1);
        }

        //defeated
        if(defeated)
        {
            anim.SetInteger("transition", 2);
        }

        //entering
        if(Eyestomb.entering)
        {
            anim.SetInteger("transition", 3);
        }
    }

    IEnumerator Defeated()
    {
         yield return new WaitForSeconds(10f);
        transform.position = Vector3.Lerp(transform.position, swimPos.position, 1 * Time.deltaTime);
        anim.SetInteger("transition", 4);
    }
}
