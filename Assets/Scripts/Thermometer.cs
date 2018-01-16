using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : MonoBehaviour {

	private static Thermometer _inst = null;

	public static Thermometer inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<Thermometer> ();
			}
			return _inst;
		}
	}

	public Image ThermoFillImg;
	public float fillAmount;
	public float randomFill;

	void Start () {
		
	}

	void Update () {
		fillAmount = 0.1f;
		randomFill = Mathf.Cos (Time.time) * 0.05f;
		float totalFill = fillAmount + randomFill;
		ThermoFillImg.fillAmount = totalFill;
	}
}
