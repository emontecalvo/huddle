using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacePanelUI : MonoBehaviour {

	public Image FaceImage;
	public Text HappyorLonelyTxt;
	public Text FrozenOrToastyTxt;

	public GameObject StatPanelOne;
	public GameObject StatPanelTwo;
	public float NextPanelSwitchTime = 5.0f;
	public float period = 0.1f;



	void Start () {
		StatPanelOne.SetActive (true);
		StatPanelTwo.SetActive (false);
	}

	void Update () {
		SwitchUIJelloPanel ();
	}

	void SwitchUIJelloPanel() {
		if (Time.time > NextPanelSwitchTime) {
			if (StatPanelOne.activeSelf) {
				StatPanelOne.SetActive (false);
				StatPanelTwo.SetActive (true);
				NextPanelSwitchTime += 5.0f;
			} else {
				StatPanelOne.SetActive (true);
				StatPanelTwo.SetActive (false);
				NextPanelSwitchTime += 5.0f * 3.0f;
			}
		}
	}

	public void SetFace(Sprite faceSprite) {
		FaceImage.sprite = faceSprite;
	}

	public void SetJelloLonelyText (string happyOrLonely) {
		HappyorLonelyTxt.text = happyOrLonely;
	}

	public void SetJelloFrozenText (string frozenOrNot) {
		FrozenOrToastyTxt.text = frozenOrNot;
	}
}
