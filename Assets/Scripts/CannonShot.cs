using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShot : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform projectileOrigin;
    public ParticleSystem fireParticleSystem;
    public CannonRecoil cannonRecoil;

    public PanCameraController panCameraController;

    private float loadTime = 4f;
    private bool canShot;

    public bool onGUI;
    // Start is called before the first frame update
    void Start() {
        canShot = true;
    }

    // Update is called once per frame
    void Update() {
        
        if(canShot && Input.GetKeyDown(KeyCode.Space)) {
            //Disparamos... o no
            Shot();
        }
        
    }


    private void Shot() {
        fireParticleSystem.Play();
        GameObject bulletGO = Instantiate(bulletPrefab, projectileOrigin.position, projectileOrigin.rotation);
        //Si tenemos establecida la referencia a panCameraController (sólo uno de los dos cañones debe tenerla)
        //le pasamos la referencia de la bala para que la cámara la siga
        if(panCameraController != null) {
            StartCoroutine(SetPanCameraTarget(bulletGO.transform));
        }

        canShot = false;
        Invoke("LoadBullet", loadTime);
        cannonRecoil?.StartRecoil();
    }

    private void LoadBullet() {
        canShot = true;
    } 

    private IEnumerator SetPanCameraTarget(Transform bulletTransform) {
        yield return new WaitForSeconds(2f);
        if(bulletTransform != null) {
            panCameraController.target = bulletTransform;
        }
    }


    void OnGUI() {
        if( ! onGUI) {
            return;
        }
        GUI.backgroundColor = Color.green;
        if( ! canShot ) {
            GUI.backgroundColor = Color.red;
        }
        
        GUI.Button(new Rect(Screen.width - 100, Screen.height -100, 80, 80), "");

        
        
    }
}
