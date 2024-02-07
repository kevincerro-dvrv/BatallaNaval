using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform projectileOrigin;
    public ParticleSystem fireParticleSystem;

    private float shotForce = 600;
    private bool canShot = true;
    private float loadBulletTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShot) {
            Shot();
        }
    }

    void Shot()
    {
        fireParticleSystem.Play();
        GameObject projectile = Instantiate(bulletPrefab, projectileOrigin.position, projectileOrigin.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * shotForce, ForceMode.Impulse);
        canShot = false;
        Invoke("LoadBullet", loadBulletTime);
        gameObject.GetComponentInChildren<CanonRecoil>().StartRecoil();
    }

    private void LoadBullet()
    {
        canShot = true;
    }

    void OnGUI()
    {
        GUI.backgroundColor = Color.green;
        if (!canShot) {
            GUI.backgroundColor = Color.red;
        }

        GUI.Button(new Rect(Screen.width - 100, Screen.height - 100, 80, 80), "");
    }
}
