using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cursedLights;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject light in cursedLights)
        {
            //
            light.GetComponent<cursedParticleSystem>().startSystem();
        }
    }
}
