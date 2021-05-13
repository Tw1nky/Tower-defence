using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enermy : MonoBehaviour
{

    public float speed = 30f;
    public int hp = 100;
    public int gold = 20;
    public GameObject healthBar;
    [Range(0,1)]
    public float armor = 0;
    private Transform target;
    private int wavePointIndex = 0;


    // Use this for initialization
    void Start()
    {
        target = Waypoints.points[wavePointIndex];
        hp += Mathf.RoundToInt(WorldStats.level * .1f * hp);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Debug.Log(Vector3.Distance(target.position, transform.position));
        if (Vector3.Distance(target.position, transform.position) < 6f)
        {
            if (wavePointIndex == Waypoints.points.Length-1)
            {
                WorldStats.HP -= 1;
                Destroy(gameObject);
            }
            else
            {
                wavePointIndex++;
                target = Waypoints.points[wavePointIndex];
            }

        }
        if (hp <= 0)
        {
            WorldStats.gold += gold;
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }
}
