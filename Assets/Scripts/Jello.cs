using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jello : MonoBehaviour
{
	public KeyCode UpKey;
	public KeyCode DownKey;
	public KeyCode LeftKey;
	public KeyCode RightKey;
	public Tree BeingHauled = null;

	public float MyTemp = 10.0f;
	public float tempDelta = 0f;

	public bool IsNextToFire = false;
	public bool IsNextToOther = false;
	public bool AmIFrozen = false;
	public bool AmIToasty = false;

	void Start ()
	{
		JelloMgr.inst.Register (this);
	}

	void Update ()
	{
		MovementLogic ();
		ChopTrees ();
		TemperatureLogic ();

		if (BeingHauled != null) {
			HaulTrees ();
		}
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
		if (BeingHauled != null) {
			return;
		}

		foreach (Tree tree in TreeMgr.inst.AllTrees) {
			Vector3 toTree = tree.transform.position - transform.position;
			float distance = toTree.magnitude;

			if (distance <= 1.5f) {
				tree.GetChopped ();
				BeingHauled = tree;
			}
		}

	}

	void HaulTrees() {
		Vector3 toWood = BeingHauled.transform.position - transform.position;

		float distance = toWood.magnitude;
		float followDistance = 1.25f;

		if (distance > followDistance) {
			Vector3 toWood2 = ( (toWood * followDistance) / distance );
			Vector3 woodPos2 = transform.position + toWood2;
			BeingHauled.transform.position = woodPos2;
			PutWoodInFire ();
		}
			


	}

	void PutWoodInFire() {
		Vector3 toFire = Fire.inst.transform.position - transform.position;

		float distanceToFire = toFire.magnitude;

		if (distanceToFire <= 1.25f) {
			Fire.inst.ReceiveWood (BeingHauled);
			BeingHauled = null;
		}

	}

	void TemperatureLogic() {
		tempDelta = 0;
		float maxTemp = 8f;

		Vector3 toFire = Fire.inst.transform.position - transform.position;
		float distanceToFire = toFire.magnitude;

		if (distanceToFire < 3) {
			IsNextToFire = true;
		} else {
			IsNextToFire = false;
		}

		foreach (Jello jello in JelloMgr.inst.AllJellos) {
			if (jello != this) {
				Vector3 toJello = jello.transform.position - transform.position;
				float distance = toJello.magnitude;

				if (distance <= 1.25f) {
					IsNextToOther = true;
				} else {
					IsNextToOther = false;
				}				
			}
		}

		if (IsNextToFire == false && IsNextToOther == false) {
			tempDelta = -0.01f;
			if (MyTemp <= 0) {
				AmIFrozen = true;
				MyTemp = 0;
			}
		}

		if (IsNextToFire == true && IsNextToOther == true) {
			AmIFrozen = false;
			tempDelta = 0.05f;
			maxTemp = 11f;
		}

		if (IsNextToFire == true && IsNextToOther == false) {
			AmIFrozen = false;
			AmIToasty = false;
			maxTemp = 10f;
			tempDelta = 0.03f;
		}

		if (IsNextToFire == false && IsNextToOther == true) {
			AmIFrozen = false;
			AmIToasty = false;
			tempDelta = 0.02f;

		}

		MyTemp = MyTemp + tempDelta * Time.deltaTime;
		if (MyTemp < 0f) {
			MyTemp = 0f;
			AmIFrozen = true;
			AmIToasty = false;
		}
		if (MyTemp > maxTemp) {
			MyTemp = maxTemp;
		}
		if (MyTemp >= 11) {
			AmIFrozen = false;
			AmIToasty = true;
		}
		if (MyTemp < 11 && MyTemp > 0) {
			AmIFrozen = false;
			AmIToasty = false;
		}
		Debug.Log ("Am I frozen?" + AmIFrozen);
		Debug.Log ("Am I Toasty?" + AmIToasty);
		Debug.Log (MyTemp);



	}
	
}
