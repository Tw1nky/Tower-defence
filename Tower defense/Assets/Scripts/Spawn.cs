using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    public GameObject enermy;
    public GameObject[] enermies;
    public float spawnTimer = 2f;
    public int enermiesPerWave = 10;
    private GameObject childObject;

    IEnumerator spawn()
    {
        WorldStats.level += 1;
        int currentLevel = WorldStats.level;
        WaitForSeconds wait = new WaitForSeconds(spawnTimer);
        for (int i = 0; i < enermiesPerWave; i++)
        {
            if ( currentLevel % 4 == 0)
            {
                 childObject = Instantiate(enermies[1], gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                 childObject = Instantiate(enermies[0], gameObject.transform.position, Quaternion.identity);
            }
            childObject.transform.parent = GameObject.Find("Enermies").transform;
            yield return wait;
        }

    }
    public void nextWave()
    {
        StartCoroutine(spawn());
    }


}
