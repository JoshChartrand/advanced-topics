using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	public bool InInventory = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag("Backpack").transform.position) < 0.5f) {
			InInventory = true;
		} else {
			InInventory = false;
		}

	}
}
