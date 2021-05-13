using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public float speed = 4f;
    public Transform end;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WorldStats.HP <= 0)
            transform.position = Vector3.Lerp(transform.position, end.position, Time.deltaTime * speed);

    }

    public void onClick()
    {
        Debug.Log("Next Scene");
        SceneManager.LoadScene("MainMenu");
        WorldStats.reset();
    }
}
