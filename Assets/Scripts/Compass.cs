using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour 
{

	public Transform target;
    public bool work = true;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (work)
        {
            // Rotate the needle so it keeps looking at the target (Which is North)
            this.transform.LookAt(target, Vector3.up);
        }
	}
}
