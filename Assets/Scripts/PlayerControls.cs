using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

	public GameObject leftAnchor;
	public GameObject rightAnchor;
	private float handZ;
	private float originZ;
	private float originX;
	private float handX;

	public bool IsMounted = false;

	public float MountedHeight = 0.0f;

	GameObject Mountable = null;

	GameObject trackingSpace = null;

	GameObject leftHand;
	GameObject rightHand;
	Vector3 Direct;
	float handsPositions;

	float direction;

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
		if (IsMounted && (OVRInput.Get(OVRInput.Button.Two) == true && OVRInput.Get(OVRInput.Button.Four) == true)) {
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

			if(GlobalVariables.Mounting == true){
				//makes sure both hands are in a fist
				if (OVRInput.Get (OVRInput.Axis1D.PrimaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0) {

					handZ = ((leftAnchor.transform.localPosition.z + rightAnchor.transform.localPosition.z) / 2);

					//if both hands are near chest stop
					//no velocity
					if(handZ <= originZ){
						GetComponent<OVRPlayerController> ().SetMoveScaleMultiplier (0.0f);
					}
						
					print (handX - originX);

					//if both hands are right go right
					//turn players forward right
					handX = ((leftAnchor.transform.localPosition.x + rightAnchor.transform.localPosition.x) / 2);
					handX -= originX;
					if (handX > 0.2) {
						//print ("right");
						transform.rotation *= Quaternion.Euler(new Vector3(0.0f, (handX * 0.001) + 1.0f, 0.0f));
					} else if (handX < -0.2) {
						//print ("left");
						transform.rotation *= Quaternion.Euler(new Vector3(0.0f, ((handX * 0.001) + 1.0f) * -1.0f, 0.0f));
					} else {
						direction = 1.0f;
					}

					if(handZ > originZ ){
						handZ = handZ - originZ ;
						handZ = handZ * 2;
						Vector3 temp = new Vector3(transform.forward.x * handZ, transform.forward.y * handZ, transform.forward.z * handZ);
						GetComponent<OVRPlayerController> ().SetMoveScaleMultiplier (handZ);
						GetComponent<CharacterController> ().Move (temp);
					}
				}
			}
		}
	}

	void FixedUpdate () {

	}

	public void Mount(GameObject mount) {
		originZ = ((leftAnchor.transform.localPosition.z + rightAnchor.transform.localPosition.z) / 2);
		originX = ((leftAnchor.transform.localPosition.x + rightAnchor.transform.localPosition.x) / 2);
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
