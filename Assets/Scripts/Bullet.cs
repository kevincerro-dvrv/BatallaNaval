using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody>().AddForce(transform.forward * 600f, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        Destroy(gameObject);
    }
}
