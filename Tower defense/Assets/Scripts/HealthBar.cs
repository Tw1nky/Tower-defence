using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Enermy parent;
    int maxHP;
    int currentHP;
    GameObject bar;
    void Start()

    {
        parent = gameObject.GetComponentInParent<Enermy>();
        bar = transform.GetChild(2).gameObject;
        maxHP = parent.hp;
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = parent.hp;
        float barScale = (float)currentHP / maxHP;
        //Debug.Log(barScale);
        //Debug.Log(bar);
        bar.transform.localScale = new Vector3(barScale, 1, 1);
    }
}
