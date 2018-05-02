using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

 public float dampTime = 2.0f;  // Valor da suavização
 private Vector3 velocity = Vector3.zero;  // Velocidade da camera
 public Transform target;  // Momochi
 void Update () 
 	{
		 if (target)
		 {
			Vector3 point = GetComponent<Camera> ().WorldToViewportPoint (target.position);
            //Vector3 delta = target.position - GetComponent<Camera> ().ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.4f, 0.2f, point.z));
            Vector3 destination = transform.position + delta;
   			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
  		}
 	}
 }
