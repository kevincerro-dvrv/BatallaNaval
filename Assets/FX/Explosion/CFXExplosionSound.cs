using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFXExplosionSound : MonoBehaviour {
    public AudioClip explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(explosionSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
