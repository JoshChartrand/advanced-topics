﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour {
	public GameObject book;
	//public GameObject openBook;
	//public Material OpenBookMaterial;
	//public Renderer bookRender;
	public bool closebook;
	public int numQuest;

	public Mesh	closedBook;
	public Mesh	openBook;

	public Texture OpenBookMat;
	public Texture ClosedBookMat;
	public Texture Plant;
	public Texture PlantCrossed;
	public Texture Meat;
	public Texture MeatCrossed;
	public Texture Bottle;
	public Texture BottleCrossed;

	GlobalVariables globalVariables = null;

	// Use this for initialization
	void Start () {
		globalVariables = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GlobalVariables> ();
		numQuest = GlobalVariables.QuestNum;
	}

	// Update is called once per frame
	void Update () {
		//openBook.transform.position = closedBook.transform.position;

		if (book.GetComponent<OVRGrabbable>().isGrabbed && book.GetComponent<MeshFilter> ().mesh != openBook) {
			book.GetComponent<MeshFilter> ().mesh = openBook;
			book.GetComponent<MeshRenderer>().material.mainTexture = OpenBookMat;
		}
		else if (!book.GetComponent<OVRGrabbable>().isGrabbed && book.GetComponent<MeshFilter> ().mesh != closedBook){
			book.GetComponent<MeshFilter> ().mesh = closedBook;
			book.GetComponent<MeshRenderer>().material.mainTexture = ClosedBookMat;
		}

		if (book.GetComponent<OVRGrabbable> ().isGrabbed) {
			if (globalVariables.questNum == 1) { //quest 1
				book.GetComponent<MeshRenderer> ().material.mainTexture = Plant;
			} else if (globalVariables.questNum == 2) { //quest 1 done
				book.GetComponent<MeshRenderer> ().material.mainTexture = PlantCrossed;
			} else if (globalVariables.questNum == 3) { //quest 2
				book.GetComponent<MeshRenderer> ().material.mainTexture = Meat;
			} else if (globalVariables.questNum == 4) { //quest 2 done
				book.GetComponent<MeshRenderer> ().material.mainTexture = MeatCrossed;
			} else if (globalVariables.questNum == 5) { //quest 3
				book.GetComponent<MeshRenderer> ().material.mainTexture = Bottle;
			} else if (globalVariables.questNum == 6) { //quest 3 done
				book.GetComponent<MeshRenderer> ().material.mainTexture = BottleCrossed;
			}
		}
	}
}
