using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject curseFireAlpha;

    [SerializeField]
    private GameObject curseFireAdd;

    [SerializeField]
    private GameObject curseFireGlow;

    [SerializeField]
    private GameObject curseFireSparks;

    [SerializeField]
    private GameObject curseSmoke;

    private int fireDown;

    public GameObject curseItem;
    public List<GameObject> curseObjects = new List<GameObject>();
    private bool isInRange;

    private void Awake()
    {
        fireDown = 1;
        fireExtinguish();
    }

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
            this.GetComponent<sanityHandler>().incorporateSanity(curseObjects.Count);
        }
    }

    private void BurnItem()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isInRange)
        {
            for (int i = 0; i <= curseObjects.Count; i++)
            {
                if (curseItem != null)
                {
                    this.GetComponent<sanityHandler>().lowerDrain(curseObjects.Count);
                    fireDown++;

                    fireStart();


                    Invoke("fireExtinguish", 5f);
                }
                curseObjects.Remove(curseItem);
            }
        }
    }

    private void fireExtinguish()
    {
        fireDown--;

        if(fireDown == 0)
        {
            //This just puts out the fire
            curseFireAlpha.GetComponent<cursedParticleSystem>().stopSystem();
            curseFireAdd.GetComponent<cursedParticleSystem>().stopSystem();
            curseFireGlow.GetComponent<cursedParticleSystem>().stopSystem();
            curseFireSparks.GetComponent<cursedParticleSystem>().stopSystem();
            curseSmoke.GetComponent<cursedParticleSystem>().stopSystem();
        }
    }

    private void fireStart()
    {
        curseFireAlpha.GetComponent<cursedParticleSystem>().startSystem();
        curseFireAdd.GetComponent<cursedParticleSystem>().startSystem();
        curseFireGlow.GetComponent<cursedParticleSystem>().startSystem();
        curseFireSparks.GetComponent<cursedParticleSystem>().startSystem();
        curseSmoke.GetComponent<cursedParticleSystem>().startSystem();
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        if(other.gameObject.tag == "Cursed")
        {
            //
            curseItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }
}
