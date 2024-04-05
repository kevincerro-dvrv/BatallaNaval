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
        UserInterface.instance.SetCannonLoaded(true);
    }

    // Update is called once per frame
    void LateUpdate() {
        //Si hacemos esto en Update puede pasar (de hecho, nos pasó)
        //que se dispare un cañón, luego se gire la torre, y luego se dispare el otro cañón
        //y los disparos no serían paralelos
        //Al hacerlo en LateUpdate nos aseguramos que todos los Update han sido ejecutados previamente
        //y en particular el que gira la torre y los cañones en CannonMovement
        
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
            StartCoroutine(SetPanCameraTarget(bulletGO.GetComponent<Bullet>()));
        }

        canShot = false;
        UserInterface.instance.SetCannonLoaded(false);
        Invoke("LoadBullet", loadTime);
        cannonRecoil?.StartRecoil();
    }

    private void LoadBullet() {
        canShot = true;
        UserInterface.instance.SetCannonLoaded(true);
    } 

    private IEnumerator SetPanCameraTarget(Bullet bullet) {
        yield return new WaitForSeconds(1f);
        if(bullet != null) {
            panCameraController.Follow(bullet);
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
