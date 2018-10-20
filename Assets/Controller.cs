using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public GameObject ground;
    private bool walking;
    private Vector3 startPoint;
    float y;
    //private Vector3 prevY;
    bool lookDown = false;
	// Use this for initialization
	void Start () {
        startPoint = transform.position;
	}
    Vector3 prevY = new Vector3(9000, 9000, 9000);
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < prevY.y)
        {
           // transform.position = startPoint;
        }
        else
        {
            y = transform.position.y;
            Debug.Log(true);
        }

        if (transform.position.y < -2f)
        {
            startPoint.y = y;
            transform.position = startPoint;

        }
        
        if (walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * 50f * Time.deltaTime;
        }
        

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.name.Contains("model"))
            {
                if(walking == false)
                {
                    walking = true;
                }
                else
                {
                    walking = false;
                }
            }
            else
            {
                walking = true;
            }
        }
		
	}
}
