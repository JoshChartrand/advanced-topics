using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
	public GameObject player;
	public GameObject Exclamation;
	public bool newInfo = true;
	public float range;
	public float above;

	public AudioClip IntroClip;
	public AudioClip FirstQuestClip;
	public AudioClip SecondQuestClip;
	public AudioClip ThirdQuestClip;
	public AudioClip EndingClip;

	private float distance;
	private Vector3 pos;
	private bool CurrentlyInDialogue;

	GlobalVariables globalVariables = null;
	CollectItems collectItems = null;

	// Use this for initialization
	void Start () {
		globalVariables = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GlobalVariables> ();
		collectItems = GameObject.Find ("ItemTrigger").GetComponent<CollectItems> ();
		pos = new Vector3 (transform.position.x, transform.position.y + above, transform.position.z);
		Exclamation.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		newInfo = globalVariables.newQuest;
		distance = Vector3.Distance (player.transform.position, transform.position);

		if(distance <= range ){
			globalVariables.newQuest = false;
			// START AUDIO BASED ON QUEST NUMBER	
			if (!CurrentlyInDialogue) {
				PlayDialogue ();
			}
		}
		if (CurrentlyInDialogue && !GetComponent<AudioSource> ().isPlaying) {
			ProceedToNextQuest ();
		}

		if (newInfo == true) {
			Exclamation.SetActive (true);
		}
		else if (newInfo == false) {
			Exclamation.SetActive (false);
		}
	}

	void PlayDialogue() {
		if (globalVariables.questNum == 0) { //quest 1
			CurrentlyInDialogue = true;
			GetComponent<AudioSource> ().Play ();
			//PLAY AUDIO TRACK	
		} else if (globalVariables.questNum == 2) { //quest 1 done
			CurrentlyInDialogue = true;
			GetComponent<AudioSource> ().Play ();
			//PLAY AUDIO TRACK	
		} else if (globalVariables.questNum == 4) { //quest 2 done
			CurrentlyInDialogue = true;
			GetComponent<AudioSource> ().Play ();
			//PLAY AUDIO TRACK	
		} else if (globalVariables.questNum == 6) { //quest 3 done
			CurrentlyInDialogue = true;
			GetComponent<AudioSource> ().Play ();
			//PLAY AUDIO TRACK	
		}
	}

	void ProceedToNextQuest() {
		CurrentlyInDialogue = false;
		globalVariables.questNum++;
		collectItems.UpdateItemCount ();
	}
}
