using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacePanelUI : MonoBehaviour {

	public Image FaceImage;
	public Text HappyorLonelyTxt;
	public Text FrozenOrToastyTxt;

	void Start () {
		
	}

	void Update () {
		
	}

	public void SetFace(Sprite faceSprite) {
		FaceImage.sprite = faceSprite;
	}

	public void SetJelloLonelyText (Text happyOrLonely) {
		HappyorLonelyTxt.text = happyOrLonely.ToString();
	}

	public void SetJelloFrozenText (Text frozenOrNot) {
		FrozenOrToastyTxt.text = frozenOrNot.ToString();
	}
}
