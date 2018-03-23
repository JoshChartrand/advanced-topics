using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountHorse : MonoBehaviour {

	bool IsOverlapping = false;

	GameObject Player = null;

	GameObject Mountable = null;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (IsOverlapping && (OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0) && Player.transform.parent != Mountable) {
			Debug.Log ("Mounting");
			Player.transform.SetParent(Mountable.transform);
			Collider[] Colliders = Player.GetComponentsInChildren<Collider> ();
			foreach (Collider col in Colliders) {
				Physics.IgnoreCollision (col, Mountable.GetComponent<Collider> ());
			}
			Player.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
			//Player.GetComponent<OVRPlayerController>()
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
			//Mountable = null;
		}
	}

}
