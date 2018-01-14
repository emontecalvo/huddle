using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

	private static Fire _inst = null;

	public static Fire inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<Fire> ();
			}
			return _inst;
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
