using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extras : MonoBehaviour {
    public GameObject roda, roda2;
    public float zRotation = 5.0F;
	void Update ()
    {
        zRotation++;
        roda.transform.eulerAngles = new Vector3(0, 0, zRotation);
        roda2.transform.eulerAngles = new Vector3(0, 0, -zRotation);
    }
}
