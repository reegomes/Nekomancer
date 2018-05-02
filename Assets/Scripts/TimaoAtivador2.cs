using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimaoAtivador2 : Ativador {

    public HingeJoint2D teste;
    

    void Update () {
        

        if (desceJao == true)
        {
            if (teste.useMotor == false)
            {
                zRotation += 50 * Time.deltaTime;
                teste.useMotor = true;
                transform.eulerAngles = new Vector3(0, 0, zRotation);

            }
            else if (teste.useMotor == true)
            {
                zRotation += 50 * Time.deltaTime;
                teste.useMotor = false;
                transform.eulerAngles = new Vector3(0, 0, zRotation);
            }

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
