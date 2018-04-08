using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapIntoPlace : MonoBehaviour {

	OVRGrabbable grabbable;
	bool playSound = true;
	private Vector3 TempPos; 
	private Vector3 normal;
	private Vector3 elbowPos;
	public float distance;
	public bool Left;
	private Transform finger;
	private Transform hand;
	public GameObject leftHand;
	public GameObject rightHand;

	// Use this for initialization
	void Start () {
		grabbable = GetComponent<OVRGrabbable> ();
	}

	// Update is called once per frame
	void Update () {
		//body = GameObject.Find("body_JNT");
		if (Left == false) {
			finger = GameObject.Find ("hands:b_r_index1").transform;
			hand = GameObject.Find ("hands:b_r_hand").transform;
			TempPos = finger.position - hand.position;
			normal = Vector3.Normalize (TempPos);
			elbowPos = hand.position;
			elbowPos = elbowPos - (normal * distance);
		}
		if(Left == true){
			finger = GameObject.Find ("hands:b_l_index1").transform;
			hand = GameObject.Find ("hands:b_l_hand").transform;

			TempPos = finger.position - hand.position;
			normal = Vector3.Normalize (TempPos);
			elbowPos = hand.position;
			elbowPos = elbowPos - (normal * distance);
		}

		if (!grabbable.isGrabbed) {
			//transform.position = transform.parent.position;
			//transform.rotation = transform.parent.rotation;
			transform.position = elbowPos;
			transform.rotation = hand.rotation;
			//transform.eulerAngles
			//transform.Rotate(Vector3.forward);
			playSound = true;
		} else if (playSound) {
			playSound = false;
			GetComponent<AudioSource> ().Play ();
		}


	}
}
