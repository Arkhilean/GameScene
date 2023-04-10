using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    //We will need a flashlight (Or well light GameObject)
    [SerializeField]
    private GameObject fLight;

    //A singular bool will be used
    public bool lightState;
    public bool clickState;

    // Start is called before the first frame update
    void Start()
    {
        lightActive();
    }

    //This method will check for input and run itself
    public void lightActive()
    {
        //First check if the button has been pressed
        if (Input.GetMouseButton(0))
        {
            if(clickState == false)
            {
                //Check for current lightState
                if(lightState==false)
                {
                    lightState = true;
                }
                else
                {
                    lightState = false;
                }

                clickState = true;

                lightManager();
            }
        }

        else
        {
            //If so restore clickstate to false
            clickState = false;
        }

        //Finally loop LightAcive again in .2 seconds
        Invoke("lightActive", 0.1f);
    }

    //This method will turn the gameObject on or off based on the bool
    public void lightManager()
    {
        //If light is on turn on, other wise turn off
        if(lightState == true)
        {
            fLight.SetActive(true);
        }
        else
        {
            fLight.SetActive(false);
        }
    }
}
