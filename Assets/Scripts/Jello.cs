using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jello : MonoBehaviour
{
	public KeyCode UpKey;
	public KeyCode DownKey;
	public KeyCode LeftKey;
	public KeyCode RightKey;

	void Start ()
	{
		JelloMgr.inst.Register (this);
	}

	void Update ()
	{
		MovementLogic ();
		ChopTrees ();
	}

	void MovementLogic () {
		Vector3 speed = Vector3.zero;

		if (Input.GetKey (UpKey)) {
			speed.z = 1;
		}

		if (Input.GetKey (DownKey)) {
			speed.z = -1;
		}

		if (Input.GetKey (LeftKey)) {
			speed.x = -1;
		}

		if (Input.GetKey (RightKey)) {
			speed.x = 1;
		}

		transform.position = transform.position + speed * Time.deltaTime;
	}

	void ChopTrees() {
		// for each tree find distance from my jello to tree
		// if distance is less than X, chop the tree down
		// add wood to jelllo

		foreach (Tree tree in TreeMgr.inst.AllTrees) {
			Vector3 toTree = tree.transform.position - transform.position;
			float distance = toTree.magnitude;
			Debug.Log (distance.ToString());

			if (distance <= 1.5f) {
				tree.GetChopped ();
			}
		}

	}
	
}
