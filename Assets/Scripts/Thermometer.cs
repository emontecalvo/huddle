using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
	public Image ThermoIceFill;
	public float fillAmount;
	public float randomFill;

	public float StormOneStartTime;
	public float StormOneEndTime;
	public float StormTwoStartTime;
	public float StormTwoEndTime;
	public float LastTime;

	public ParticleSystem StormOneParticle;
	public ParticleSystem MainParticle;

	public bool IsItAStorm = false;

	public float TotalFill;

	void Start () {
		
	}

	void Update () {
		if (!IsItAStorm) {
			fillAmount = 0.1f;
			randomFill = Mathf.Cos (Time.time) * 0.05f;
			TotalFill = fillAmount + randomFill;

			//		Debug.Log ("Time dot time:" + Time.time.ToString () + "Time delta:" + Time.deltaTime.ToString ());		
		} else {
			TotalFill -= 1 * Time.deltaTime;
			if (TotalFill < 0) {
				TotalFill = 0;
			}
		}

		ThermoFillImg.fillAmount = TotalFill;


		float time = Time.time;
		if (time > StormOneStartTime && LastTime < StormOneStartTime) {
			BeginStorm ();
			MainParticle.gameObject.SetActive (false);
			StormOneParticle.gameObject.SetActive (true);
		}
			
		if (time > StormOneEndTime && LastTime < StormOneEndTime) {
			EndStorm ();
			MainParticle.gameObject.SetActive (true);
			StormOneParticle.gameObject.SetActive (false);
		}

		if (time > StormTwoStartTime && LastTime < StormTwoStartTime) {
			BeginStorm ();
			MainParticle.gameObject.SetActive (false);
			StormOneParticle.gameObject.SetActive (true);
		}

		if (time > StormTwoEndTime && LastTime < StormTwoEndTime) {
			EndStorm ();
			MainParticle.gameObject.SetActive (false);
			StormOneParticle.gameObject.SetActive (true);
		}

		LastTime = time;

	}

	void BeginStorm() {
//		Debug.Log ("BEGIN STORM!");
		IsItAStorm = true;
		ThermoIceFill.gameObject.SetActive (true);
		ThermoIceFill.DOFillAmount (1f, 1f);
	}

	void EndStorm () {
//		Debug.Log ("You survived, end of storm");
		IsItAStorm = false;
		ThermoIceFill.DOFillAmount (0f, 1f).OnComplete (() => {
			ThermoIceFill.gameObject.SetActive (false);
		});
	}
}
