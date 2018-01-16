using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacePanelUI : MonoBehaviour {

	public Image FaceImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetFace(Sprite faceSprite) {
		FaceImage.sprite = faceSprite;
	}
}
