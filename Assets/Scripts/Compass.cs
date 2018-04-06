using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour 
{

	public Transform target;

    public List<GameObject> Objectives = new List<GameObject>();
    GameObject[] centerObjects;

    public Transform comp;

    float ClosestDistance = 0.0f;

    Vector3 CurrentItemPosition;

    // Use this for initialization
    void Start () 
	{
        centerObjects = GameObject.FindGameObjectsWithTag("Center");

		/*
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item"))
        {
            if(item.name.Contains("Plant"))
            {
                Objectives.Add(item);
            }
        }  
        */
	}
	
	// Update is called once per frame
	void Update () 
	{

        for(int i = 0; i < centerObjects.Length; i++)
        {
			if (centerObjects [i] != null) {
				centerObjects[i].transform.position = new Vector3(centerObjects[i].transform.position.x, transform.position.y, centerObjects[i].transform.position.z);
			}
        }

        int closest = -1;
        float maxDist = 1000;
        int ind = 0;

        foreach (GameObject item in Objectives)
        {
			if (item) {
				if (!item.GetComponent<ItemScript> ().InInventory) {
					float CurrentItemDistance = Vector3.Distance (transform.position, item.transform.position);
					if (CurrentItemDistance < maxDist) {
						maxDist = CurrentItemDistance;
						closest = ind;
					}
				}
			}
			ind++;
        }

		if (Objectives.Count > 0) {
			target = Objectives[closest].transform;

			// Rotate the needle so it keeps looking at the target (Which is North)
			this.transform.LookAt(target.GetChild(0).transform, Vector3.up);
			// this.transform.LookAt(target, Vector3.up);
			///this.transform.rotation = Quaternion.Euler(0.0f, this.transform.rotation.y, 0.0f);
		}

    }

	public void SetNewObjectives(string ItemName) {
		foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item"))
		{
			if(item.name.Contains(ItemName))
			{
				Objectives.Add(item);
			}
		}  
	}
}
