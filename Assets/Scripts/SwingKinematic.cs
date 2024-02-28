using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingKinematic : MonoBehaviour {
    private float angularSpeedZ;
    private float restorationTorqueRateZ = 0.01f;

    private float angularSpeedX;
    private float restorationTorqueRateX = 0.006f;

    public float empujonAlPrincipioX;
    public float empujonAlPrincipioZ;

    int numeroDivisionesPorFrame = 100;

    // Start is called before the first frame update
    void Start() {
        transform.Rotate(transform.forward * empujonAlPrincipioZ, Space.World);
        transform.Rotate(transform.right * empujonAlPrincipioX, Space.World);

    }

    // Update is called once per frame
    void LateUpdate() {

        float timePerDivision = Time.deltaTime / numeroDivisionesPorFrame;
        for(int i=0; i<numeroDivisionesPorFrame; i++) {
            //Calculamos el cambio en velocidad angular en función del
            // restorationTorqueRateZ y el ángulo de inclinación (leanAngle)
            float leanAngle = Vector3.SignedAngle(Vector3.ProjectOnPlane(transform.up, transform.forward), Vector3.up, transform.forward);
            //float leanAngle = Vector3.SignedAngle(transform.up, Vector3.up, transform.forward);
            angularSpeedZ += leanAngle * restorationTorqueRateZ * Time.deltaTime; 
 
            //Aplicamos el giro del barco en el eje Z en función del la angular speed en ese eje
            transform.Rotate(transform.forward * angularSpeedZ * timePerDivision, Space.World); 
        }


        for(int i=0; i<numeroDivisionesPorFrame; i++) {
            //Calculamos el cambio en velocidad angular en función del
            // restorationTorqueRateX y el ángulo de inclinación (leanAngleX)
            float pitchAngle = Vector3.SignedAngle(Vector3.ProjectOnPlane(transform.up, transform.right), Vector3.up, transform.right);
            angularSpeedX += pitchAngle * restorationTorqueRateX * Time.deltaTime;

            //Aplicamos el giro del barco en el eje x en función del la angular speed en ese eje
            transform.Rotate(transform.right * angularSpeedX * timePerDivision, Space.World); 
        }
        
    }
}
