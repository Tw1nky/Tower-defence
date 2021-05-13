using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMenuUI : MonoBehaviour
{
    [Header("UI")]
    public Transform end;
    public Transform start;
    public float speed = 4f;
    public static bool show = false;
    

    

    [Header("Towers")]
    public List<BuyTower> towers;
    private Button btn1;
    public static Node node;
    public Button buyButtonObject;


    void Start()
    {
        int ypos = 100;
        foreach (var tower in towers)
        {
            //Debug.Log(tower.Tower.name);
            Button btn =  Instantiate(buyButtonObject);
            btn.transform.SetParent(gameObject.transform);
            btn.name = tower.Tower.name;
            btn.image.sprite = tower.Tower.GetComponent<SpriteRenderer>().sprite;
            btn.transform.GetChild(0).GetComponent<Text>().text = "" + tower.price + "G";
            BuyTower towerToAdd = tower;
            btn.onClick.AddListener(()=>addTower(towerToAdd));
            btn.GetComponent<RectTransform>().localPosition = new Vector3(55, ypos,0);
            ypos -= 150;
        }

    }

    void Update()
    {
        if (node != null)
        {
            if (show)
            {
                transform.position = Vector3.Lerp(transform.position, end.position, Time.deltaTime * speed);
                node.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, start.position, Time.deltaTime * speed);
                node.GetComponent<SpriteRenderer>().color = new Color(255,255,255);
            }
        }

    }


    void addTower(BuyTower tower)
    {
        Debug.Log(tower.Tower.name);
        if (node != null && WorldStats.gold >= tower.price && node.tower == null)
        {
            WorldStats.gold -= tower.price;
            var towerInst = Instantiate(tower.Tower, node.transform.position, Quaternion.identity);
            node.tower = towerInst;
            towerInst.transform.parent = GameObject.Find("Towers").transform;
            show = false;
        }
    }
    [System.Serializable]
    public class BuyTower
    {
        public GameObject Tower;
        public int price;

    }
}


