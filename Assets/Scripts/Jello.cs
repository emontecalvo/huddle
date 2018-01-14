using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jello : MonoBehaviour {


	// Use this for initialization
	void Start () {

		JelloMgr.inst.Register(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
