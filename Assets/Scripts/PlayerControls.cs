using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

	Transform indexPointL;
	Transform indexBaseL;
	Transform indexPointR;
	Transform indexBaseR;

	RaycastHit rhL;
	RaycastHit rhR;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if(OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Three) && OVRInput.Get(OVRInput.Button.Two) && OVRInput.Get(OVRInput.Button.Four)) {
			SceneManager.LoadScene("Main");
		}

		/*
		indexPointL = GameObject.Find("hands:b_l_hand_ignore").transform;
		indexBaseL = GameObject.Find("hands:b_l_index1").transform;

		Ray rayLeft = new Ray(indexBaseL.position, indexPointL.position - indexBaseL.position);
		Debug.DrawRay(rayLeft.origin, rayLeft.direction * 1, Color.black);

		if (Physics.Raycast(rayLeft, out rhL, 1))
		{
			print(rhL.transform.name);
		}
		*/
			
	}
}
