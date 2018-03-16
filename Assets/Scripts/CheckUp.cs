using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckUp : MonoBehaviour {

    public Compass c;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider col)
    {
        if(col.transform.tag == "CollisionCheck")
        {
            print("WORK");
            c.work = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "CollisionCheck")
        {
            c.work = false;
        }
    }
}
