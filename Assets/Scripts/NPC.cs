using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	public GameObject player;
	public GameObject Exclamation;
	public bool newInfo = true;
	public float range;
	public float above;

	private float distance;
	private Vector3 pos;
	//private Vector3 RadPos;

	// Use this for initialization
	void Start () {
		//player = GetComponent<GameObject> ();
		GlobalVariables.NewQuest = newInfo;
	}
	
	// Update is called once per frame
	void Update () {
		newInfo = GlobalVariables.NewQuest;
		distance = Vector3.Distance (player.transform.position, transform.position);
		//print (distance);
		if(distance <= range ){
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Close enough for interactions~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		}

		pos = new Vector3 (transform.position.x, transform.position.y + above, transform.position.z);

		Exclamation.transform.position = pos;

		if (newInfo == true) {
			Exclamation.SetActive (true);
		}
		else if (newInfo == false) {
			Exclamation.SetActive (false);
		}
	}
}
