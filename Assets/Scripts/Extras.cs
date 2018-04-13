using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extras : MonoBehaviour {

	public float timer = 0.1f;
    public GameObject roda;
    public float zRotation = 5.0F;

    //public gameObject roda;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        zRotation++;
        roda.transform.eulerAngles = new Vector3(10, 0, zRotation);
    }
}
