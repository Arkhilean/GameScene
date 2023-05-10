using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject[] campFire;

    [SerializeField]
    private GameObject[] curseFire;

    [SerializeField]
    private GameObject instructions;

    public int fireDown;

    public GameObject curseItem;
    public List<GameObject> curseObjects = new List<GameObject>();
    public bool isInRange;
    public bool isInRangeItem;

    private void Awake()
    {
        fireDown = 1;
        fireExtinguish();
    }

    private void PickUpItem()
    {
        if (Input.GetKey(KeyCode.E) && isInRangeItem)
        {
            curseObjects.Add(curseItem);
            curseItem.SetActive(false);
            this.GetComponent<sanityHandler>().incorporateSanity(curseObjects.Count);
            fireDown++;
            instructions.GetComponent<Instructions>().eOff();

            isInRangeItem = false;
        }

        if (isInRangeItem == true)
        {
            //Loop code check as long as its possible to pick up item
            Invoke("PickUpItem", .1f);
        }
    }

    private void BurnItem()
    {
        if (Input.GetKey(KeyCode.Q) && isInRange)
        {
            foreach (GameObject curseItem in curseObjects)
            {
                if (curseItem != null)
                {
                    fireStart();

                    Invoke("fireExtinguish", 5f);
                    curseObjects.Remove(curseItem);
                }
            }
        }

        if (isInRange == true && curseObjects.Count > 0)
        {
            Invoke("BurnItem", .05f);
        }
    }

    private void fireExtinguish()
    {
        fireDown--;
        this.GetComponent<sanityHandler>().lowerDrain(fireDown);

        if (fireDown == 0)
        {
            foreach (GameObject fire in campFire)
            {
                fire.GetComponent<cursedParticleSystem>().startSystem();
            }

            //Grab the list for cursed fire and stop every particle system
            foreach (GameObject cFire in curseFire)
            {
                cFire.GetComponent<cursedParticleSystem>().stopSystem();
            }

            //Use invoke in order to get a more accurate fire stopping point
            Invoke("stopFireCrackling", 1.2f);
        }
    }

    private void stopFireCrackling()
    {
        //Stop playing the fire audio
        curseFire[0].GetComponent<PlayAudioCall>().stopAudioTrack();
        campFire[0].GetComponent<PlayAudioCall>().playAudioTrack();
    }

    private void fireStart()
    {
        foreach (GameObject fire in campFire)
        {
            fire.GetComponent<cursedParticleSystem>().stopSystem();
        }

        //Grab the list for cursed fire and start every particle system
        foreach (GameObject cFire in curseFire)
        {
            cFire.GetComponent<cursedParticleSystem>().startSystem();
        }

        //Call the first object in the cursefire list and play the audio
        curseFire[0].GetComponent<PlayAudioCall>().playAudioTrack();
        campFire[0].GetComponent<PlayAudioCall>().stopAudioTrack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cursed")
        {
            instructions.GetComponent<Instructions>().eOn();
            curseItem = other.gameObject;
            isInRangeItem = true;
            PickUpItem();
        }
        else
        {
            isInRange = true;
            instructions.GetComponent<Instructions>().qOn();

            if (curseObjects.Count > 0)
            {
                BurnItem();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        isInRangeItem = false;

        if (other.gameObject.tag == "Cursed")
        {
            instructions.GetComponent<Instructions>().eOff();
        }

        else
        {
            instructions.GetComponent<Instructions>().qOff();
        }
    }
}
