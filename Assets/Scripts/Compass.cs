using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour 
{

	public Transform target;
    public bool work = true;

    public List<GameObject> Objectives = new List<GameObject>();
    GameObject[] centerObjects;

    public Transform comp;

    //List<float> Positions = new List<float>();

    float ClosestDistance = 0.0f;

    Vector3 CurrentItemPosition;

    // Use this for initialization
    void Start () 
	{
        centerObjects = GameObject.FindGameObjectsWithTag("Center");

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Plant"))
        {
            if(item.name.Contains("Plant"))
            {
                Objectives.Add(item);

                //Positions.Add(0.0f);
            }
        }     
	}
	
	// Update is called once per frame
	void Update () 
	{

      //  comp.rotation = transform.rotation;

        for(int i = 0; i < centerObjects.Length; i++)
        {
            centerObjects[i].transform.position = new Vector3(centerObjects[i].transform.position.x, transform.position.y, centerObjects[i].transform.position.z);
        }

        int closest = -1;
        float maxDist = 1000;
        int ind = 0;
        foreach (GameObject item in Objectives)
        {

            float CurrentItemDistance = Vector3.Distance(transform.position, item.transform.position);
            if(CurrentItemDistance < maxDist)
            {
                maxDist = CurrentItemDistance;
                closest = ind;
            }

            ind++;
          //  if(ClosestDistance == 0.0f)
          //  {
          //      ClosestDistance = CurrentItemDistance;
          //      CurrentItemPosition = item.transform.position;
          //  }
          //  else
          //  {
          //      if (CurrentItemDistance < ClosestDistance)
          //      {
          //          ClosestDistance = CurrentItemDistance;
          //          CurrentItemPosition = item.transform.position;
          //      }
          //  }

             
            //Positions.Insert(Objectives.IndexOf(item), Vector3.Distance(transform.position, item.transform.position));
        }

        target = Objectives[closest].transform;

        //get component item script
        //check if it's in inventory
        //if in inventory, removw item from list
        //cycle through till all list is complete

       // Debug.Log("Item position: " + CurrentItemPosition);

        // Rotate the needle so it keeps looking at the target (Which is North)
        this.transform.LookAt(target.GetChild(0).transform, Vector3.up);
       // this.transform.LookAt(target, Vector3.up);
        ///this.transform.rotation = Quaternion.Euler(0.0f, this.transform.rotation.y, 0.0f);

    }
}
