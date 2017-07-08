using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticleSystem : MonoBehaviour {

    private ParticleSystem _particleSystem;

	// Use this for initialization
	void Start ()
    {
        _particleSystem = GetComponent<ParticleSystem>();

    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (_particleSystem)
        {
            if (!_particleSystem.IsAlive())
                Destroy(this.gameObject);
        }
	}
}
