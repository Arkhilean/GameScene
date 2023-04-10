using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanityHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject sBar;

    //This variable sets max sanity
    public int maxSanity;
    private int sanity;
    public int sanityRestore;

    //This variable will determine how much sanity is drained at a time
    public float drainRate;
    private int sDrain;

    //This variable checks for if sanity drain has begun
    private bool cursPickUp;

    // Start is called before the first frame update
    void Start()
    {
        sBar.GetComponent<sanityBar>().SetMaxSanity(maxSanity);
        sanity = maxSanity;
    }

    public void sanityDrain()
    {
        //First Check if the cursed object is picked up currently
        if (cursPickUp == true)
        {
            //If a cursed object is picked up sanity will be drained and returned to the bar
            if (sanity - sDrain > 0)
            {
                sanity -= sDrain;
            }
            else
            {
                sanity = 0;
            }

            sBar.GetComponent<sanityBar>().SetSanity(sanity);

            //Loop sanity drain to avoid using Update
            Invoke("sanityDrain", 1.5f);
        }
    }

    public void incorporateSanity(int cursedCount)
    {
        //Set the drain rate
        sDrain = Mathf.RoundToInt(drainRate * cursedCount);

        if (cursedCount == 1)
        {
            cursPickUp = true;
            sanityDrain();
        }
    }

    public void lowerDrain(int cursedCount)
    {
        sDrain = Mathf.RoundToInt(drainRate * cursedCount);

        //For now restore sanity, but make sure it doesn't overfill
        if (sanity + sanityRestore <= 100)
        {
            //Then seet sanity to this
            sanity += sanityRestore;
        }

        //Otherwise set sanity to max
        else
        {
            sanity = maxSanity;
        }
        sBar.GetComponent<sanityBar>().SetSanity(sanity);

        //Double check that thqat cursPickup doesnt need to be turned off
        if (cursedCount <= 0)
        {
            cursPickUp = false;
        }
    }
}
