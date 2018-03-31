using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowGrab : MonoBehaviour {

	public bool IsEquipped = false;

	public bool IsCurrentlyEquipping = false;

	OVRGrabbable grabbable;

	public bool Unequipping = false;

	GameObject socket;

	// Use this for initialization
	void Start () {
		grabbable = GetComponent<OVRGrabbable> ();
		socket = GameObject.FindGameObjectWithTag ("Socket");
		//AttachToSocket ();
	}
	
	// Update is called once per frame
	void Update () {

		if (grabbable.isGrabbed) {
			GetComponent<Animator> ().enabled = false;
			if(transform.gameObject.layer != LayerMask.NameToLayer("Player")) {
				ChangeLayerRecursively (transform, "Player");
			}
		} else {
			GetComponent<Animator> ().enabled = true;
			if (IsEquipped && transform.rotation != transform.parent.rotation) {
				transform.rotation = transform.parent.rotation;
				IsCurrentlyEquipping = false;
			}
			if(transform.gameObject.layer != LayerMask.NameToLayer("Default")) {
				ChangeLayerRecursively (transform, "Default");
			}
			if (Unequipping) {
				Unequipping = false;
			}
		}

		if (grabbable.isGrabbed && IsEquipped && (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0) && !IsCurrentlyEquipping) {
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			GetComponent<Rigidbody> ().useGravity = true;
			IsEquipped = false;
			transform.parent = null;
			Unequipping = true;
		}
	}

	void OnTriggerEnter(Collider other) {
		/*
		if (other.gameObject.tag == "PlayerBag" && !IsEquipped) {
			GetComponent<Animator> ().SetBool ("IsPlayerClose", true);
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		}
		*/

		if (other.gameObject.tag == "Socket" && grabbable.isGrabbed && !IsEquipped && !Unequipping) {
			AttachToSocket ();
		}
	}

	void OnTriggerExit(Collider other) {

		/*
		if (other.gameObject.tag == "PlayerBag" && !IsEquipped && !grabbable.isGrabbed) {
			GetComponent<Animator> ().SetBool ("IsPlayerClose", false);
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			GetComponent<Rigidbody> ().useGravity = true;
			IsEquipped = false;
		}
		*/
	}

	void AttachToSocket() {
		IsEquipped = true;
		IsCurrentlyEquipping = true;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GetComponent<Rigidbody> ().useGravity = false;
		transform.SetParent(socket.transform);
		transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
	}

	void DetachFromSocket() {
		Unequipping = true;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		IsEquipped = false;
		transform.parent = null;
	}

	void ChangeLayerRecursively(Transform trans, string name) {
		trans.gameObject.layer = LayerMask.NameToLayer (name);
		foreach (Transform child in trans) {
			ChangeLayerRecursively(child.transform, name);
		}
	}
}
