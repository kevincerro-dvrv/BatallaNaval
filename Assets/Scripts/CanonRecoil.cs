using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRecoil : MonoBehaviour
{
    private float recoilSpeed = 100;
    private float restorationAcceletation = 100;
    private bool recoilActive = false;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!recoilActive) {
            return;
        }

        rb.AddForce(Vector3.back * recoilSpeed, ForceMode.Force);
        //rb.AddForce(Vector3.forward * restorationAcceletation, ForceMode.Acceleration);

        //if (gameObject.transform.position.z ===)

        /*Vector3 recoil = Vector3.back * recoilSpeed * Time.deltaTime;
        Vector3 position = gameObject.transform.position;
        position += recoil;
        gameObject.transform.position = position;*/

        recoilActive = false;
    }

    public void StartRecoil()
    {
        recoilActive = true;
    }
}
