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

	public AudioClip FirstQuestComplete;
	public AudioClip SecondQuestComplete;
	public AudioClip ThirdQuestComplete;

    AudioSource audioSource;

    private float distance;
	private Vector3 pos;
	private bool CurrentlyInDialogue;

	GlobalVariables globalVariables = null;
	CollectItems collectItems = null;
	Compass compass = null;

	public AudioSource audio = null;

	int plantCount;
	int meatCount;
	int bottleCount;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		globalVariables = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GlobalVariables> ();
		collectItems = GameObject.Find ("ItemTrigger").GetComponent<CollectItems> ();
		pos = new Vector3 (transform.position.x, transform.position.y + above, transform.position.z);
		Exclamation.transform.position = pos;
		compass = GameObject.FindGameObjectWithTag ("Compass").GetComponent<Compass> ();
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

            //PLAY AUDIO TRACK	
            audio.PlayOneShot(FirstQuestClip, 0.7F);
        }

        else if (globalVariables.questNum == 2) { //quest 1 done
			CurrentlyInDialogue = true;

            //PLAY AUDIO TRACK	
            audio.PlayOneShot(SecondQuestClip, 0.7F);
            

        } else if (globalVariables.questNum == 4) { //quest 2 done
			CurrentlyInDialogue = true;

            //PLAY AUDIO TRACK	
            audio.PlayOneShot(ThirdQuestClip, 0.7F);

        } else if (globalVariables.questNum == 6) { //quest 3 done
			CurrentlyInDialogue = true;

            //PLAY AUDIO TRACK	
            audio.PlayOneShot(EndingClip, 0.7F);

        }

        
    }

	void ProceedToNextQuest() {
		CurrentlyInDialogue = false;
		globalVariables.questNum++;
		collectItems.UpdateItemCount ();
		if (globalVariables.questNum == 1) { //quest 1
			compass.SetNewObjectives("Plant");
		} else if (globalVariables.questNum == 3) { //quest 1 done
			compass.SetNewObjectives("Pig");
		} 
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			CheckForItems ();
			PlayFollowupAudio ();
			ResetItems ();
		}
	}

	void CheckForItems() {
		GameObject[] items = GameObject.FindGameObjectsWithTag ("Item");
		foreach (GameObject item in items) {
			if (item.GetComponent<ItemScript> ()) {
				if(item.GetComponent<ItemScript> ().InInventory) {
					if (globalVariables.questNum == 1 && item.name.Contains("Plant")) { //quest 1
						plantCount++;
					} else if (globalVariables.questNum == 3 && item.name.Contains("Meat")) { //quest 2
						meatCount++;
					} else if (globalVariables.questNum == 5 && item.name.Contains("Bottle")) { //quest 3
						bottleCount++;
					} 
				}
			}
		}
	}

	void PlayFollowupAudio () {
		if (plantCount >= 3) { //quest 1
			audio.PlayOneShot(FirstQuestComplete);
		} else if (meatCount >= 2) { //quest 2
			audio.PlayOneShot(SecondQuestComplete);
		} else if (bottleCount >= 1) { //quest 3
			audio.PlayOneShot(ThirdQuestComplete);
		} 
	}

	void ResetItems() {
		plantCount = 0;
		meatCount = 0;
		bottleCount = 0;
	}

}
