using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Node : MonoBehaviour
{
    public GameObject tower;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() )
        {
            Debug.Log("Clicked on the UI");
        }
        else
        {
            //Instantiate(tower, transform.position, Quaternion.identity);
            if ((BuyMenuUI.show || UpgradeMenuUI.show))
            {
                BuyMenuUI.show = false;
                UpgradeMenuUI.show = false;
            }
            else
            {
                if (tower == null)
                {
                    BuyMenuUI.show = true;
                    BuyMenuUI.node = this;
                }
                else
                {
                    UpgradeMenuUI.show = true;
                    UpgradeMenuUI.node = this;
                }

            }
        }
    }
}
