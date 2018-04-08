using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerOnGrab : MonoBehaviour {

	OVRGrabbable grabbable;

	// Use this for initialization
	void Start () {
		grabbable = GetComponent<OVRGrabbable> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (grabbable.isGrabbed) {
			if (gameObject.layer != LayerMask.NameToLayer ("Grabbable")) {
				ChangeLayerRecursively (transform, "Grabbable");
			}
		} else {
			if (gameObject.layer != LayerMask.NameToLayer ("Default")) {
				ChangeLayerRecursively (transform, "Default");
			}
		}

	}

	void ChangeLayerRecursively(Transform trans, string name) {
		trans.gameObject.layer = LayerMask.NameToLayer (name);
		foreach (Transform child in trans) {
			ChangeLayerRecursively(child.transform, name);
		}
	}
}
