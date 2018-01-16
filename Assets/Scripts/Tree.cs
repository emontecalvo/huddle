using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	bool AmIChopped = false;

	public GameObject TreeView;
	public GameObject WoodView;

	// Use this for initialization
	void Start () {

		TreeMgr.inst.Register(this);
		TreeView.SetActive (true);
		WoodView.SetActive (false);
	}

	void OnDestroy() {
		if (TreeMgr.inst != null) {
			TreeMgr.inst.Unregister (this);
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void GetChopped() {
		AmIChopped = true;
		WoodView.SetActive (true);
		TreeView.SetActive (false);

	}
}
