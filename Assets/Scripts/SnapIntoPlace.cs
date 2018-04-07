using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapIntoPlace : MonoBehaviour {

	OVRGrabbable grabbable;
	bool playSound = true;

	// Use this for initialization
	void Start () {
		grabbable = GetComponent<OVRGrabbable> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!grabbable.isGrabbed) {
			transform.position = transform.parent.position;
			transform.rotation = transform.parent.rotation;
			playSound = true;
		} else if (playSound) {
			playSound = false;
			GetComponent<AudioSource> ().Play ();
		}

	}
}
