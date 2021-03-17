using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class baseUnit : MonoBehaviour
{

    public float speed;
    public int hp;
    public int damage;
    public float rotation_speed;

    public Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
}
