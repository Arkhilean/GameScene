using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [SerializeField]
    private GameObject welcome;

    [SerializeField]
    private GameObject howFlash;

    [SerializeField]
    private GameObject howE;

    [SerializeField]
    private GameObject howQ;

    // Start is called before the first frame update
    void Awake()
    {
        welcomeOn();
    }

    //This text will pop up to tell the player
    private void welcomeOn()
    {
        welcome.SetActive(true);
        Invoke("welcomeOff", 4f);
    }

    private void welcomeOff()
    {
        welcome.SetActive(false);
        Invoke("flashOn", 2f);
    }

    private void flashOn()
    {
        howFlash.SetActive(true);
        Invoke("flashOff", 4f);
    }

    private void flashOff()
    {
        howFlash.SetActive(false);
    }

    public void eOn()
    {
        howE.SetActive(true);
    }

    public void eOff()
    {
        howE.SetActive(false);
    }

    public void qOn()
    {
        howQ.SetActive(true);
    }

    public void qOff()
    {
        howQ.SetActive(false);
    }

    /*
     * 1.) Welcome player to level
     * 2.) Press Left-Click to turn on and off flashlight, and shift to run.
     * 4.) When close to object: press E
     * 5.) When close to bonfire: press Q
     */
}
