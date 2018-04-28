using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimaoAtivador2 : Ativador {
	void Update () {
        
        if(desceJao == true)
        {
            zRotation += 50 * Time.deltaTime;
            timaoAtivador2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            transform.eulerAngles = new Vector3(0, 0, zRotation);
        }
        if (zRotation >= 50.0f)
        {
            desceJao = false;
        }
    }

    void SpeedMotor()
    {
        desceJao = false;
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();
        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = 0f;
        hinge.motor = motor;
    }
}
