using System.Collections;
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

	// Use this for initialization
	void Start () {
		//closedBook = GetComponent<GameObject>();
		//openBook = GetComponent<GameObject>();
		numQuest = GlobalVariables.QuestNum;
	}

	// Update is called once per frame
	void Update () {
		//openBook.transform.position = closedBook.transform.position;

		if (closebook == true) {
			book.GetComponent<MeshFilter> ().mesh = closedBook;
			book.GetComponent<MeshRenderer>().material.mainTexture = ClosedBookMat;
			/*
			closedBook.SetActive(true);
			openBook.SetActive(false);
			*/
		}
		else if (closebook == false){
			book.GetComponent<MeshFilter> ().mesh = openBook;
			book.GetComponent<MeshRenderer>().material.mainTexture = OpenBookMat;
			/*
			closedBook.SetActive(false);
			openBook.SetActive(true);
			*/
		}

		GlobalVariables.QuestNum = numQuest;
		//if (numQuest != GlobalVariables.QuestNum) {
			if(GlobalVariables.QuestNum == 1 ){ //quest 1
			book.GetComponent<MeshRenderer>().material.mainTexture = Plant;
			}
			else if (GlobalVariables.QuestNum == 2){ //quest 1 done
			book.GetComponent<MeshRenderer>().material.mainTexture = PlantCrossed;
			}
			else if (GlobalVariables.QuestNum == 3){ //quest 2
			book.GetComponent<MeshRenderer>().material.mainTexture =  Meat;
			}
			else if (GlobalVariables.QuestNum == 4){ //quest 2 done
			book.GetComponent<MeshRenderer>().material.mainTexture = MeatCrossed;
			}
			else if (GlobalVariables.QuestNum == 5){ //quest 3
			book.GetComponent<MeshRenderer>().material.mainTexture = Bottle;
			}
			else if (GlobalVariables.QuestNum == 6){ //quest 3 done
			book.GetComponent<MeshRenderer>().material.mainTexture = BottleCrossed;
			}
		//}
	}
}
