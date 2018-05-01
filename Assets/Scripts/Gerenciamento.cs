using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciamento : MonoBehaviour {

	// Rodas
	//public Vector3 checkpoint;
    public GameObject roda, roda2, momochi;
    public float zRotation = 5.0F;
	void Update ()
    {
        zRotation++;
        roda.transform.eulerAngles = new Vector3(0, 0, zRotation);
        roda2.transform.eulerAngles = new Vector3(0, 0, -zRotation);
    }
}
