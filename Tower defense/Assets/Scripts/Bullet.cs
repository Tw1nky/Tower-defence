using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Enermy target;
    public float bulletSpeed = 1200f;
    private int damage;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (Vector3.Distance(target.transform.position, transform.position) < 100f)
        {
            target.hp -= damage - (int)(damage * target.armor);
            Destroy(gameObject);
        }

        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * bulletSpeed * Time.deltaTime);

    }

    public void setTarget(Enermy target)
    {
        this.target = target;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }
}
