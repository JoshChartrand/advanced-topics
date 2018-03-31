using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour {
	public GameObject closedBook;
	public GameObject openBook;
	public Material OpenBookMaterial;
	public Renderer openBookRender;
	public bool closebook;
	public int numQuest;

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
		openBook.transform.position = closedBook.transform.position;

		if (closebook == true) {
			closedBook.SetActive(true);
			openBook.SetActive(false);
		}
		else if (closebook == false){
			closedBook.SetActive(false);
			openBook.SetActive(true);
		}
		GlobalVariables.QuestNum = numQuest;
		//if (numQuest != GlobalVariables.QuestNum) {
			if(GlobalVariables.QuestNum == 1 ){ //quest 1
				openBookRender.material.SetTexture("Book_Open", Plant);
			}
			else if (GlobalVariables.QuestNum == 2){ //quest 1 done
				openBookRender.material.SetTexture("Book_Open", PlantCrossed);
			}
			else if (GlobalVariables.QuestNum == 3){ //quest 2
				openBookRender.material.SetTexture("Book_Open", Meat);
			}
			else if (GlobalVariables.QuestNum == 4){ //quest 2 done
				openBookRender.material.SetTexture("Book_Open", MeatCrossed);
			}
			else if (GlobalVariables.QuestNum == 5){ //quest 3
				openBookRender.material.SetTexture("Book_Open", Bottle);
			}
			else if (GlobalVariables.QuestNum == 6){ //quest 3 done
				openBookRender.material.SetTexture("Book_Open", BottleCrossed);
			}
		//}
	}
}
