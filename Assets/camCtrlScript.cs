using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCtrlScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Transform>().localPosition += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<Transform>().localPosition += new Vector3(1, 0, 0);
        }
    }
}
