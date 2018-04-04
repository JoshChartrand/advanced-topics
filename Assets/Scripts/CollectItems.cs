using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour {

	int itemCount;
	GlobalVariables globalVariables = null;

	// Use this for initialization
	void Start () {
		globalVariables = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GlobalVariables> ();
		UpdateItemCount ();
	}
	
	// Update is called once per frame
	void Update () {

		if (globalVariables.questNum == 6) {
			transform.parent.gameObject.GetComponentInChildren<ParticleSystem> ().Stop();
		}
		
	}

	void OnTriggerEnter(Collider col) {
		//Check current quest
		//Compare name
		//Destroy item
		//Increase count
		//Tell NPC to give next quest

		Debug.Log (col.gameObject.name);

		if(globalVariables.questNum == 1 ){ //quest 1
			if (col.gameObject.name.Contains ("Plant")) {
				Destroy (col.gameObject);
				itemCount--;
				CheckForQuestCompletion ();
			}
		}
		else if (globalVariables.questNum == 3){ //quest 2
			if (col.gameObject.name.Contains ("Meat")) {
				Destroy (col.gameObject);
				itemCount--;
				CheckForQuestCompletion ();
			}		
		}
		else if (globalVariables.questNum == 5){ //quest 3
			if (col.gameObject.name.Contains ("Bottle")) {
				Destroy (col.gameObject);
				itemCount--;
				CheckForQuestCompletion ();
			}		
		}

	}

	public void UpdateItemCount() {
		if (globalVariables.questNum == 1) { //quest 1
			itemCount = 3;
		} else if (globalVariables.questNum == 3) { //quest 2
			itemCount = 2;
		} else if (globalVariables.questNum == 5) { //quest 3
			itemCount = 1;
		} else {
			itemCount = 0;
		}
	}

	void CheckForQuestCompletion() {
		if (itemCount <= 0) {
			globalVariables.questNum++;
			globalVariables.newQuest = true;
		}
	}
}
