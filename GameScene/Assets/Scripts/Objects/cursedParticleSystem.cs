using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursedParticleSystem : MonoBehaviour
{
    /*ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }

    //private ParticleSystem _Cachedsystem;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    public void stopSystem()
    {
        //This will stop hte same
        this.GetComponent<ParticleSystem>().Stop();
    }

    public void startSystem()
    {
        //system.Play(true);
        this.GetComponent<ParticleSystem>().Play();
    }
}
