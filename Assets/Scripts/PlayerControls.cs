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
		if (IsMounted && (OVRInput.Get(OVRInput.Button.Two) > 0 && OVRInput.Get(OVRInput.Button.Four) > 0)) {
			Unmount ();
		}
			
		if (IsMounted) {
			Mountable.GetComponent<Animator>().SetFloat("Velocity", GetComponent<CharacterController>().velocity.magnitude);
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
			//if (OVRInput.Get (OVRInput.Axis1D.PrimaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0) {
				//print ("Left Hand Positions: " + leftHand.transform.position);
				//print ("Right Hand Positions: " + rightHand.transform.position);
				//print ("Player Position: " + transform.position);
			//}
			if(GlobalVariables.Mounting == true){
				//makes sure both hands are in a fist
				if (OVRInput.Get (OVRInput.Axis1D.PrimaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0) {
					//Vector3 applesauce = new Vector3(transform.position.x * Direct.x, transform.position.y * Direct.y, transform.position.z * Direct.z);
					//print (applesauce);

					//if both hands are forward move forward
					//velocity forward

					//if both hands are near chest stop
					//no velocity
					print("Player: " + transform.position);
					print("Left Controller: " + leftHand.transform.position);
					print("Right Controller: " + rightHand.transform.position);

					//if both hands are right go right
					//turn players forward right

					//if both hands are left go left
					//turn player forward left

					//transform.Translate ( Direct.x * 1.2f,  Direct.y * 1.2f, Direct.z * 1.2f);
				}
			}
		}
	}

	void FixedUpdate () {

	}

	public void Mount(GameObject mount) {
		GetComponent<OVRPlayerController> ().SetMoveScaleMultiplier (2.0f);
		Mountable = mount;
		IsMounted = true;
		GlobalVariables.Mounting = IsMounted;
		ChangeLayerRecursively (Mountable.transform, "Mount");
		Mountable.transform.SetParent (transform);
		Mountable.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		trackingSpace.transform.localPosition = new Vector3(trackingSpace.transform.localPosition.x, trackingSpace.transform.localPosition.y + 1.0f, trackingSpace.transform.localPosition.z);
		Mountable.transform.localPosition = new Vector3 (0.25f, Mountable.transform.localPosition.y, 0.5f);
		Mountable.transform.localRotation = Quaternion.identity;
	}

	void Unmount() {
		Mountable.GetComponent<Animator>().SetFloat("Velocity", 0.0f);
		GetComponent<OVRPlayerController> ().SetMoveScaleMultiplier (1.0f);
		IsMounted = false;
		GlobalVariables.Mounting = IsMounted;
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
