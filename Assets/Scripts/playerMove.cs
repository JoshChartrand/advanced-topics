using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
	GameObject leftHand;
	GameObject rightHand;
	Vector3 Direct;
	float handsPositions;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(leftHand == null){
			leftHand = GameObject.Find ("hands:b_l_hand");
		}
		if (rightHand == null) {
			rightHand = GameObject.Find ("hands:b_r_hand");
		}

		if (leftHand != null && rightHand != null) {

			//print ("Left Hand = " + leftHand.transform.position);
			//print ("Right Hand = " + rightHand.transform.position);


			handsPositions = Vector3.Distance (rightHand.transform.position, leftHand.transform.position);
			//Direct = rightHand.transform.position - leftHand.transform.position;
			//handsDistance = Direct;
			//Direct.Normalize ();
			print ("Center Hand Positions: " + handsPositions);
			print ("Player Position: " + transform.position);
			//print ("Direction : " + Direct);

			//makes sure both hands are in a fist
			if (OVRInput.Get (OVRInput.Axis1D.PrimaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.PrimaryIndexTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) > 0 && OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0) {
				//Vector3 applesauce = new Vector3(transform.position.x * Direct.x, transform.position.y * Direct.y, transform.position.z * Direct.z);
				//print (applesauce);

				//if both hands are forward move forward
				//velocity forward

				//if both hands are near chest stop
				//no velocity

				//if both hands are right go right
				//turn players forward right

				//if both hands are left go left
				//turn player forward left

				//transform.Translate ( Direct.x * 1.2f,  Direct.y * 1.2f, Direct.z * 1.2f);
			}

		}
	}
}
