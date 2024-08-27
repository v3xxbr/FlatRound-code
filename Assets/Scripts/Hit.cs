using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
   
}

public class bullets
{
    public GameObject player = GameObject.FindGameObjectWithTag("Player");
    public int damage;
    public GameObject bullet;
    public int speed;
}