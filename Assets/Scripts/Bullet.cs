using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject explosionPrefab;

    public delegate void OnBulletDestroyedDelegate(GameObject bullet);
    public OnBulletDestroyedDelegate OnBulletDestoyed;

    private Rigidbody rb;
    private bool sterile;
   
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 600f, ForceMode.Impulse);
        sterile = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 0.3 || rb.velocity.y > 0.3 || rb.velocity.z > 0.3) {
            transform.LookAt(transform.position + rb.velocity);
        }
    }

    void OnCollisionEnter(Collision other) {
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        if(OnBulletDestoyed != null) {
            OnBulletDestoyed(gameObject);
        }

        if(! sterile && other.gameObject.CompareTag("EnemyShip")) {
            GameManager.instance.AddScore(50);
            sterile = true;
        }

        Destroy(gameObject, 2f);
   
    }
}
