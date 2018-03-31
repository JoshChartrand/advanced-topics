using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

	public bool IsMounted = false;

	public float MountedHeight = 0.0f;

	GameObject Mountable = null;

	GameObject trackingSpace = null;

	GameObject leftHand;
	GameObject rightHand;
	Vector3 Direct;
	float handsPositions;

	// Use this for initialization
	void Start () {
		trackingSpace = GameObject.Find("TrackingSpace");
	}

	// Update is called once per frame
	void Update () {

		if(OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Three) && OVRInput.Get(OVRInput.Button.Two) && OVRInput.Get(OVRInput.Button.Four)) {
			//SceneManager.LoadScene("Main");
		}

		// Checking to unmount
		if (IsMounted && (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)) {
			Unmount ();
		}


		if(leftHand == null){
			leftHand = GameObject.Find ("hands:b_l_hand");
		}
		if (rightHand == null) {
			rightHand = GameObject.Find ("hands:b_r_hand");
		}

		if (leftHand != null && rightHand != null) {
			handsPositions = Vector3.Distance (rightHand.transform.position, leftHand.transform.position);
			//Direct = rightHand.transform.position - leftHand.transform.position;
			//handsDistance = Direct;
			//Direct.Normalize ();

			//print ("Direction : " + Direct);
			if (OVRInput.Get (OVRInput.Axis1D.PrimaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0) {
				print ("Left Hand Positions: " + leftHand.transform.position);
				print ("Right Hand Positions: " + rightHand.transform.position);
				print ("Player Position: " + transform.position);
			}
		}
	}

	void FixedUpdate () {

	}

	public void Mount(GameObject mount) {
		Mountable = mount;
		IsMounted = true;
		ChangeLayerRecursively (Mountable.transform, "Mount");
		Mountable.transform.SetParent (transform);
		Mountable.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		trackingSpace.transform.localPosition = new Vector3(trackingSpace.transform.localPosition.x, trackingSpace.transform.localPosition.y + 1.0f, trackingSpace.transform.localPosition.z);
		Mountable.transform.localPosition = new Vector3 (0.25f, Mountable.transform.localPosition.y, 0.5f);
		Mountable.transform.localRotation = Quaternion.identity;
		//Player.GetComponent<CharacterController> ().radius = 2.5f;
		//Player.GetComponent<CharacterController> ().height = 5.0f;
	}

	void Unmount() {
		IsMounted = false;
		Mountable.transform.parent = null;
		Mountable.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		Mountable.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		Mountable.transform.position = new Vector3 (transform.position.x, 0.0f, transform.position.z + 3.0f);
		Vector3 lookAtPosition = transform.position - Mountable.transform.position;
		lookAtPosition.y = 0.0f;
		Mountable.transform.rotation = Quaternion.LookRotation (lookAtPosition);
		trackingSpace.transform.localPosition = new Vector3(trackingSpace.transform.localPosition.x, trackingSpace.transform.localPosition.y - 1.0f, trackingSpace.transform.localPosition.z);
		ChangeLayerRecursively (Mountable.transform, "Default");
	}

	void ChangeLayerRecursively(Transform trans, string name) {
		trans.gameObject.layer = LayerMask.NameToLayer (name);
		foreach (Transform child in trans) {
			ChangeLayerRecursively(child.transform, name);
		}
	}

}
