using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCameraController : MonoBehaviour {
    public Transform cabinPivot;
    public Camera panCamera;
    
    private Quaternion startCameraRotation;
    private float startFov;
    private Transform target;


    // Start is called before the first frame update
    void Start() {
         
         startCameraRotation = panCamera.transform.localRotation;
         startFov = panCamera.fieldOfView;
         
    }

    // Update is called once per frame
    void Update() {
        transform.rotation = cabinPivot.rotation;

        if(target != null) {
            panCamera.transform.LookAt(target.position);
            panCamera.fieldOfView = 4000f / Vector3.Distance(target.position, panCamera.transform.position);
        
        } 

    }

    public void Follow(Bullet bulletToFollow) {
        target = bulletToFollow.transform;
        bulletToFollow.OnBulletDestoyed += Unfollow;        
    }

    private void Unfollow(GameObject bullet) {
        panCamera.transform.localRotation = startCameraRotation;
        panCamera.fieldOfView = startFov;
        //target = null;
        Invoke("ResetTarget", 1);
    }

    private void ResetTarget() {
        target = null;
    }
}
