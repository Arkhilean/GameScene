using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sanityBar : MonoBehaviour
{
    public Slider slider;
    public Text sanityTotal;
    //public Gradient gradient;
   //public Image fill;

    public void SetMaxSanity(int sanity)
    {
        slider.maxValue = sanity;
        slider.value = sanity;
        sanityTotal.text = sanity + "%";

        //fill.color = gradient.Evaluate(1f);
    }

    public void SetSanity(int sanity)
    {
        slider.value = sanity;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
        sanityTotal.text = sanity + "%";
    }
}
