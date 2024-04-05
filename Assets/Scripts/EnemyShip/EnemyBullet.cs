using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //Creamos un Delegate que se llamará para avisar del impacto de la bala
    //El barco del jugador se suscribe a este delegate para reaccionar cuando el impacto le afecte
    public delegate void OnBulletDestroyedDelegate(GameObject bullet, Collision other);
    public OnBulletDestroyedDelegate OnBulletDestoyed;

    public GameObject bulletTrailPrefab;
    public delegate void ReachedPointDelegate(Vector3 reachedPointCoordinates);
    public event ReachedPointDelegate reachedPoint;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {        
        SpawnTrail();
    }

    void OnCollisionEnter(Collision other){
        if(OnBulletDestoyed != null) {
            OnBulletDestoyed(gameObject, other);
        }

        GameObject newEffect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(newEffect, newEffect.GetComponent<ParticleSystem>().main.duration);
        if(reachedPoint != null) {
            reachedPoint(transform.position);
        }
        Destroy(gameObject);

        if(other.gameObject.CompareTag("Player")) {
            Vector3 bulletVelocity = GetComponent<Rigidbody>().velocity;            
        }
    }

    private void SpawnTrail() {
        for(int i=0; i<20; i++) {
            Instantiate(bulletTrailPrefab, transform.position - transform.forward*2 + (Vector3)Random.insideUnitCircle*0.3f, Quaternion.identity);
        }
    }
}
