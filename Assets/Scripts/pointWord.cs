using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pointWord : MonoBehaviour
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
            
            if (Physics.Raycast(ray, out hitR, 500))
            {

                
                if (OVRInput.Get(OVRInput.Button.Two))
                {
                    
                    if (hitR.collider.gameObject.CompareTag("cross"))
                    {
                        SceneManager.LoadScene("Desktop", LoadSceneMode.Single);
                        
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
            if (Physics.Raycast(ray, out hitL, 500))
            {

               
                if (OVRInput.Get(OVRInput.Button.Four))
                {
                    
                    if (hitL.collider.gameObject.CompareTag("cross"))
                    {
                        SceneManager.LoadScene("Desktop", LoadSceneMode.Single);
                        
                    }
                }
            }

        }
    }
    
}
