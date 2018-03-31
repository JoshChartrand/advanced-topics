using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCut : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log (col.relativeVelocity.magnitude);
		//col.gameObject.tag == "Weapon" && 
		if (col.relativeVelocity.magnitude >= 20) {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		}
	}
}
