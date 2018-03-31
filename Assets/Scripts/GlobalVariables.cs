using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {
	private static bool newQuest;
	private static int questNum;
	private static bool mounting;

	// Use this for initialization
	void Start () {
		newQuest = true;
		questNum = 0;
	}

	public static bool NewQuest {

		get {
			return newQuest; 
		}

		set {
			newQuest = value; 
		}
	}

	public static int QuestNum {

		get {
			return questNum; 
		}

		set {
			questNum = value; 
		}
	}

	public static bool Mounting {

		get {
			return mounting; 
		}

		set {
			mounting = value; 
		}
	}
}
