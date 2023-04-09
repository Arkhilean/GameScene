using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject curseItem;
    public List<GameObject> curseObjects = new List<GameObject>();
    private bool isInRange;

    private void Update()
    {
        PickUpItem();

        BurnItem();
    }

    private void PickUpItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            curseObjects.Add(curseItem);
            curseItem.SetActive(false);
        }
    }

    private void BurnItem()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isInRange)
        {
            for (int i = 0; i <= curseObjects.Count; i++)
            {
                curseObjects.Remove(curseItem);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }
}
