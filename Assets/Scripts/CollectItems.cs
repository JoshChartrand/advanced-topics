using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour {

	int itemCount;

	// Use this for initialization
	void Start () {
		UpdateItemCount ();
	}
	
	// Update is called once per frame
	void Update () {

		if (GlobalVariables.QuestNum == 6) {
			transform.parent.gameObject.GetComponentInChildren<ParticleSystem> ().Stop();
		}
		
	}

	void OnTriggerEnter(Collider col) {
		//Check current quest
		//Compare name
		//Destroy item
		//Increase count
		//Tell NPC to give next quest
	

		if(GlobalVariables.QuestNum == 1 ){ //quest 1
			if (col.gameObject.name.Contains ("plant")) {
				col.gameObject.SetActive (false);
				itemCount--;
				CheckForQuestCompletion ();
			}
		}
		else if (GlobalVariables.QuestNum == 3){ //quest 2
			if (col.gameObject.name.Contains ("meat")) {
				col.gameObject.SetActive (false);
				itemCount--;
				CheckForQuestCompletion ();
			}		
		}
		else if (GlobalVariables.QuestNum == 5){ //quest 3
			if (col.gameObject.name.Contains ("bottle")) {
				col.gameObject.SetActive (false);
				itemCount--;
				CheckForQuestCompletion ();
			}		
		}

	}

	void UpdateItemCount() {
		if (GlobalVariables.QuestNum == 1) { //quest 1
			itemCount = 3;
		} else if (GlobalVariables.QuestNum == 3) { //quest 2
			itemCount = 2;
		} else if (GlobalVariables.QuestNum == 5) { //quest 3
			itemCount = 1;
		} else {
			itemCount = 0;
		}
	}

	void CheckForQuestCompletion() {
		if (itemCount <= 0) {
			GlobalVariables.QuestNum++;
			GlobalVariables.NewQuest = true;
		}
	}
}
