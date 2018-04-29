using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
	
	public Vector3 checkpoint;
	public GameObject checkpoint1;
	private void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E)){
			Debug.Log("Checkpoint salvo");
			checkpoint = checkpoint1.transform.position;
		}
	}
}
