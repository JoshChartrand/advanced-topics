using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowGrab : MonoBehaviour {

	bool IsEquipped = false;

	OVRGrabbable grabbable;

	bool Unequipping = false;

	GameObject socket;

	// Use this for initialization
	void Start () {
		grabbable = GetComponent<OVRGrabbable> ();
		socket = GameObject.FindGameObjectWithTag ("Socket");
	}
	
	// Update is called once per frame
	void Update () {

		if (grabbable.isGrabbed) {
			GetComponent<Animator> ().enabled = false;
		} else {
			GetComponent<Animator> ().enabled = true;
			if (Unequipping) {
				Unequipping = false;
			}
		}

		if (grabbable.isGrabbed && IsEquipped && (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)) {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			IsEquipped = false;
			transform.parent = null;
			Unequipping = true;
		}
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PlayerBag" && !IsEquipped) {
			GetComponent<Animator> ().SetBool ("IsPlayerClose", true);
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		}

		if (other.gameObject.tag == "Socket" && grabbable.isGrabbed && !IsEquipped && !Unequipping) {
			IsEquipped = true;
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
			transform.localPosition = new Vector3 (0.0f, 0.1f, -0.3f);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "PlayerBag" && !IsEquipped && !grabbable.isGrabbed) {
			GetComponent<Animator> ().SetBool ("IsPlayerClose", false);
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			IsEquipped = false;
		}
	}
}
