using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

	public bool newQuest;
	public int questNum;
	private static bool mounting;

	private static bool MOVEleft;

	private static bool newQuest2;
	private static int questNum2;

	// Use this for initialization
	void Start () {
		newQuest = true;
		questNum = 0;
	}
		
	public static bool NewQuest {

		get {
			return newQuest2; 
		}

		set {
			newQuest2 = value; 
		}
	}

	public static int QuestNum {

		get {
			return questNum2; 
		}

		set {
			questNum2 = value; 
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

	public static bool moveLEFT {

		get {
			return MOVEleft; 
		}

		set {
			MOVEleft = value; 
		}
	}
}
