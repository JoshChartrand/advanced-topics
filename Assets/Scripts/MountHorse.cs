using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountHorse : MonoBehaviour {

	bool IsOverlapping = false;

	GameObject Player = null;

	GameObject Mountable = null;

	PlayerControls playerControls;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		playerControls = Player.GetComponent<PlayerControls>();
	}
	
	// Update is called once per frame
	void Update () {

		// Check to mount
		if (IsOverlapping && (OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0) && !playerControls.IsMounted) {
			playerControls.Mount (Mountable);
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Saddle") {
			IsOverlapping = true;
			Mountable = other.transform.parent.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Saddle") {
			IsOverlapping = false;
		}
	}

}
