using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUnit : baseUnit
{
    // Start is called before the first frame update

    public GameObject hero;
    public GameObject opponent;
    private Vector3 player;

    void Start()
    {
        opponent = GameObject.FindWithTag("Opponent");
        hero = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        opponent = GameObject.FindWithTag("Opponent");
        hero = GameObject.FindWithTag("Player");

        if (opponent.transform.position.x + 20 <= hero.transform.position.x - 20 && opponent.transform.position.y + 20 <= hero.transform.position.y - 20)
        {
            player = opponent.transform.position;
            player.x = transform.position.x;
            player.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, player, speed * Time.deltaTime);
        }

        else if (opponent.transform.position.x - 20 >= hero.transform.position.x + 20 && opponent.transform.position.y - 20 >= hero.transform.position.y + 20)
        {
            player = opponent.transform.position;
            player.x = transform.position.x;
            player.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, player, speed * Time.deltaTime);
        }
    }
}
