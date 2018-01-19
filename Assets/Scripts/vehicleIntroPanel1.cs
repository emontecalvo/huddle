using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vehicleIntroPanel1 : MonoBehaviour {

	private static vehicleIntroPanel1 _inst = null;

	public static vehicleIntroPanel1 inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<vehicleIntroPanel1> ();
			}
			return _inst;
		}
	}

	public Button CarBtn;
	public Button PlaneBtn;
	public Button BoatBtn;
	public Button TrainBtn;

	public Image CarBackgroundImg;
	public Image PlaneBackgroundImg;
	public Image BoatBackgroundImg;
	public Image TrainBackgroundImg;

	public Color ActiveColor;
	public Color InactiveColor;



	void Start () {
		CarBtn.onClick.AddListener(CarBtnClicked);
		PlaneBtn.onClick.AddListener(PlaneBtnClicked);
		BoatBtn.onClick.AddListener(BoatBtnClicked);
		TrainBtn.onClick.AddListener(TrainBtnClicked);
	}
	

	void Update () {
		
	}

	void CarBtnClicked() {
		CarBackgroundImg.color = ActiveColor;
		PlaneBackgroundImg.color = InactiveColor;
		BoatBackgroundImg.color = InactiveColor;
		TrainBackgroundImg.color = InactiveColor;
	}

	void PlaneBtnClicked() {
		CarBackgroundImg.color = InactiveColor;
		PlaneBackgroundImg.color = ActiveColor;
		BoatBackgroundImg.color = InactiveColor;
		TrainBackgroundImg.color = InactiveColor;
	}

	void BoatBtnClicked() {
		CarBackgroundImg.color = InactiveColor;
		PlaneBackgroundImg.color = InactiveColor;
		BoatBackgroundImg.color = ActiveColor;
		TrainBackgroundImg.color = InactiveColor;
	}

	void TrainBtnClicked() {
		CarBackgroundImg.color = InactiveColor;
		PlaneBackgroundImg.color = InactiveColor;
		BoatBackgroundImg.color = InactiveColor;
		TrainBackgroundImg.color = ActiveColor;
	}

	void OnValidate() {
		CarBtnClicked ();
	}


}
