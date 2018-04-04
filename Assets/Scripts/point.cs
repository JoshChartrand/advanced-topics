using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public float speed;
    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.9)//RIGHT
        {
            Transform indexPoint = GameObject.Find("hands:b_r_index_ignore").transform;
            Transform indexBase = GameObject.Find("hands:b_r_index1").transform;
            Ray ray = new Ray(indexBase.position, indexPoint.position - indexBase.position);
            
            RaycastHit hitR;
            
            if (Physics.Raycast(ray, out hitR, 100))
            {

               
                if (OVRInput.Get(OVRInput.Button.Two))
                {
                    
                    if (hitR.collider.gameObject.CompareTag("Item"))
                    {
                        float step = speed * Time.deltaTime;
                        hitR.collider.gameObject.transform.position = Vector3.MoveTowards(hitR.collider.gameObject.transform.position, transform.position, step);
                    }
                    
                 }
             }
        }
        

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.9) //LEFT
        {
            Transform indexPoint = GameObject.Find("hands:b_l_index_ignore").transform;
            Transform indexBase = GameObject.Find("hands:b_l_index1").transform;
            Ray ray = new Ray(indexBase.position, indexPoint.position - indexBase.position);
           
            RaycastHit hitL;
            if (Physics.Raycast(ray, out hitL, 100))
            {

                
                if (OVRInput.Get(OVRInput.Button.Four))
                {
                   
                    if (hitL.collider.gameObject.CompareTag("Item"))
                    {
                        float step = speed * Time.deltaTime;
                        hitL.collider.gameObject.transform.position = Vector3.MoveTowards(hitL.collider.gameObject.transform.position, transform.position, step);
                    }
                }
            }

        }
    }
    
}
