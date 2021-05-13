using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuUI : MonoBehaviour
{
    [Header("UI")]
    public Transform end;
    public Transform start;
    public float speed = 4f;
    public static bool show = false;

    [Header("Towers")]
    public List<Button> upgradeButtons;
    public static Node node;

    [Header("Start Prices")]
    public int fireRateStartPrice = 50;
    public int damageStartPrice = 50;
    public int rangeStartPrice = 50;

    [Header("Price Increment Per Upgrade")]
    public int fireRateIncrementPrice = 10;
    public int damageIncrementPrice = 30;
    public int rangeIncrementPrice = 10;

    [Header("Upgrade Increment")]
    public float firerateIncrement = .2f;
    public int damageIncrement = 10;
    public int rangeIncrement = 10;

    private int fireratePrice;
    private int damagePrice;
    private int rangePrice;
    private int currentGold;


    void Start()
    {
        foreach (var btn in upgradeButtons)
        {
            btn.onClick.AddListener(() => upgradeTower(btn));
        }

    }

    void Update()
    {
        if (node != null)
        {
            if (show)
            {
                transform.position = Vector3.Lerp(transform.position, end.position, Time.deltaTime * speed);
                node.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255);
             
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, start.position, Time.deltaTime * speed);
                node.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

            }
            var towerFirerate = node.tower.GetComponent<Tower>().fireRate;
            var towerDMG = node.tower.GetComponent<Tower>().damage;
            var towerRange = node.tower.GetComponent<Tower>().range;

            var fireratePriceMultiplyer = node.tower.GetComponent<Tower>().firerateUpgrade;
            var damagePriceMultiplyer = node.tower.GetComponent<Tower>().damageUpgrade;
            var rangePriceMultiplyer = node.tower.GetComponent<Tower>().rangeUpgrade;

            currentGold = WorldStats.gold;
            fireratePrice = fireRateStartPrice + fireRateIncrementPrice * fireratePriceMultiplyer;
            damagePrice = damageStartPrice + damageIncrementPrice * damagePriceMultiplyer;
            rangePrice = rangeStartPrice + rangeIncrementPrice * rangePriceMultiplyer;



            upgradeButtons[0].transform.Find("Current").GetComponent<Text>().text = towerFirerate.ToString("F2") + " A/S";
            upgradeButtons[1].transform.Find("Current").GetComponent<Text>().text = towerDMG.ToString() + " DMG";
            upgradeButtons[2].transform.Find("Current").GetComponent<Text>().text = towerRange.ToString() + " Units";

            upgradeButtons[0].transform.Find("Price").GetComponent<Text>().text = string.Format("{0} G", fireratePrice);
            upgradeButtons[1].transform.Find("Price").GetComponent<Text>().text = string.Format("{0} G", damagePrice);
            upgradeButtons[2].transform.Find("Price").GetComponent<Text>().text = string.Format("{0} G", rangePrice);

            upgradeButtons[0].transform.Find("Text").GetComponent<Text>().text = string.Format("Fire Rate + {0}", firerateIncrement);
            upgradeButtons[1].transform.Find("Text").GetComponent<Text>().text = string.Format("Damage + {0}", damageIncrement);
            upgradeButtons[2].transform.Find("Text").GetComponent<Text>().text = string.Format("Range + {0}", rangeIncrement);



        }

    }
    void upgradeTower(Button button)
    {

        string buttonName = button.name;
        if (buttonName.Equals("Speed") && currentGold >= fireratePrice)
        {
            node.tower.GetComponent<Tower>().fireRate += firerateIncrement;
            node.tower.GetComponent<Tower>().firerateUpgrade += 1;
            WorldStats.gold -= fireratePrice;

        }
        if (buttonName.Equals("Damage") && currentGold >= damagePrice)
        {
            node.tower.GetComponent<Tower>().damage += damageIncrement;
            node.tower.GetComponent<Tower>().damageUpgrade += 1;
            WorldStats.gold -= damagePrice;
        }
        if (buttonName.Equals("Range") && currentGold >= rangePrice)
        {
            node.tower.GetComponent<Tower>().range += rangeIncrement;
            node.tower.GetComponent<Tower>().rangeUpgrade += 1;
            WorldStats.gold -= rangePrice;

        }

    }

}


