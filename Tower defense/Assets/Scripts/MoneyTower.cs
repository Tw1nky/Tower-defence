using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTower : MonoBehaviour
{

    [Header("Attributes")]
    public float range = 400;
    public int damage = 20;
    public float fireRate = 1.1f;
    private float firecountdown = 0;

    [Header("Unity Setup")]
    public float turnSpeed = 10f;
    public GameObject bullet;
    public Enermy target;
    public string enermytag = "Enermy";
    public WorldStats worldStats;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.2f);
    }

   
    void Update()
    {
        worldStats.gold = worldStats.gold + 10;
            }

    private void OnDrawGizmosSelected()
    {
        // Tower range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
   
}
