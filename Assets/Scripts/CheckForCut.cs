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
		if (col.gameObject.name == "Sickle" && col.relativeVelocity.magnitude >= 20) {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			transform.localScale = new Vector3 (transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z * 0.5f);
		}
	}
}
