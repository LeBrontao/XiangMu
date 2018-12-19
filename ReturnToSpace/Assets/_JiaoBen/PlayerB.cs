using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour {

    private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            Vector3 screenPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            RaycastHit Hit;
            if(Physics.Raycast(ray,out Hit))
            {
                if(Hit.collider.gameObject.tag=="Plane")
                {
                    targetPos = Hit.point;
                    transform.LookAt(targetPos);
                    transform.gameObject.GetComponent<Animator>().Play("HumanoidRun");
                    transform.Translate(Vector3.forward * 5f);
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            transform.gameObject.GetComponent<Animator>().Play("HumanoidIdle");
        }
	}
}
