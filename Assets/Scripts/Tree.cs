using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	// Use this for initialization
	void Start () {

		TreeMgr.inst.Register(this);
	}

	// Update is called once per frame
	void Update () {

	}
}
