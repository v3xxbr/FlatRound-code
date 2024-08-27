using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Eyestomb : MonoBehaviour
{
    [Header("atribbutes")]
    public int speed;
    public int health = 5;
    bool isShooting;

    [Header("text")]
    public TextMeshProUGUI healthText;

    [Header("componnents")]
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spr;
    public static BoxCollider2D boxc;
    private AudioSource aud;

    [Header("objects")]
    public GameObject pi;
    public Transform gun;
    public GameObject initialPos;

    [Header("bools")]
    public static bool takeDamage;
    private bool recovery;
    public static bool defeated;
    public static bool entering = true;

    public GameObject gameOver;

    [Header("sounds")]
    public AudioClip audioshoot;
    public AudioClip audiohit;
    public AudioClip audiogameOver;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString() + "x";
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        boxc = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (!defeated && !entering)
        {
            Movement();
            Shooting();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Entering();
    }

    public void Entering()
    {
        if(entering)
        {
            StartCoroutine(Enter());
        }
    }

    IEnumerator Enter()
    {
        boxc.isTrigger = true;
        yield return new WaitForSeconds(0.5f);
        transform.position = Vector2.MoveTowards(transform.position, initialPos.transform.position, 7f * Time.deltaTime);
        yield return new WaitForSeconds(0.9f);
        boxc.isTrigger = false;
        entering = false;
    }

    void Movement()
    {
        //animacao idle
        anim.SetInteger("transition", 0);
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += movement * Time.deltaTime * speed;
    }

    void Shooting()
    {
        if(Input.GetButtonDown("Fire1") && !isShooting)
        {
            StartCoroutine(Shot());
        }
    }

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.2f);
          isShooting = true;
          aud.PlayOneShot(audioshoot);
        isShooting = false;
        Instantiate(pi, gun.transform.position, gun.transform.rotation);     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        if(other.tag == "Hit" && !recovery)
        {
            health -= 1;
            healthText.text = health.ToString() + "x";
            aud.PlayOneShot(audiohit);
            takeDamage = true;
            recovery = true;
            StartCoroutine(Damage());
            IsDead();
        }
    }

    void IsDead()
    {
        if(health <= 0)
        {
            defeated = true;
            healthText.text = health.ToString() + "x";
            anim.SetInteger("transition", 1);
            gameOver.SetActive(true);
        }
    }

    IEnumerator Damage()
    {
        //flick
        spr.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        spr.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        spr.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.2f);
        spr.color = new Color(1, 1, 1, 1);

        //animation
        yield return new WaitForSeconds(0.5f);
        takeDamage = false;
        recovery = false;
    }
}
