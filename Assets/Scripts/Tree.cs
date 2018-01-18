using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	bool AmIChopped = false;

	public GameObject TreeView;
	public GameObject WoodView;

	public GameObject TreeBend1;
	public GameObject TreeBend2;
	public GameObject TreeBend3;
	public float NextPanelSwitchTimeTree = 0.5f;

	void Start () {

		TreeMgr.inst.Register(this);
		TreeView.SetActive (true);
		WoodView.SetActive (false);

		TreeBend1.SetActive (false);
		TreeBend2.SetActive (false);
		TreeBend3.SetActive (false);
	}

	void OnDestroy() {
		if (TreeMgr.inst != null) {
			TreeMgr.inst.Unregister (this);
		}

	}
		
	void Update () {
		// make trees at top appear smaller:
		float heightRatio = (transform.position.z - -10) / (10 - -10);
		float scale = 1.2f - heightRatio * 0.4f;
		transform.localScale = new Vector3 (scale, scale, scale);
		SwitchTreePanels ();

	}

	public void GetChopped() {
		AmIChopped = true;
		WoodView.SetActive (true);
		TreeView.SetActive (false);

	}

	void SwitchTreePanels() {
		// if there is a storm....
		if (!WoodView.activeSelf) {
			if (Time.time > NextPanelSwitchTimeTree) {
				if (TreeView.activeSelf) {
					TreeView.SetActive (false);
					TreeBend1.SetActive (true);
					NextPanelSwitchTimeTree += 0.5f;
				} else if (TreeBend1.activeSelf) {
					TreeBend1.SetActive (false);
					TreeBend2.SetActive (true);
					NextPanelSwitchTimeTree += 0.5f;
				} else if (TreeBend2.activeSelf) {
					TreeBend2.SetActive (false);
					TreeBend3.SetActive (false);
					NextPanelSwitchTimeTree += 0.5f;
				} else if (TreeBend3.activeSelf) {
					TreeBend3.SetActive (false);
					TreeView.SetActive (true);
					NextPanelSwitchTimeTree += 0.5f;
				}
			}
		}

		if (!WoodView.activeSelf && !TreeBend1.activeSelf && !TreeBend2.activeSelf && !TreeBend3.activeSelf) {
			TreeView.SetActive (true);
		}

	}


//	void SwitchUIJelloPanel() {
//		if (Time.time > NextPanelSwitchTime) {
//			if (StatPanelOne.activeSelf) {
//				StatPanelOne.SetActive (false);
//				StatPanelTwo.SetActive (true);
//				NextPanelSwitchTime += 5.0f;
//			} else {
//				StatPanelOne.SetActive (true);
//				StatPanelTwo.SetActive (false);
//				NextPanelSwitchTime += 5.0f * 3.0f;
//			}
//		}
//	}
}
