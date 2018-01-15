using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{



	public List <GameObject> FireFrames = new List<GameObject> ();
	public int CurrentFrame;
	public float TimeUntilNextFrame;
	public float TimeBetweenFrames;

	private static Fire _inst = null;

	public static Fire inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<Fire> ();
			}
			return _inst;
		}
	}
		
	void Start ()
	{
		
	}

	void Update ()
	{
		TimeUntilNextFrame -= Time.deltaTime;

		if (TimeUntilNextFrame <= 0) {
			TimeUntilNextFrame = TimeBetweenFrames;
			CurrentFrame = CurrentFrame + 1;
			if (CurrentFrame >= FireFrames.Count) {
				CurrentFrame = 0;
			}

			for (int i = 0; i <= FireFrames.Count; i++) {
				if (i == CurrentFrame) {
					FireFrames [i].SetActive (true);
				} else {
					FireFrames [i].SetActive (false);
				}
			}
		}
	}

	public void ReceiveWood(Tree tree) {
		Destroy (tree.gameObject);
	}
}
