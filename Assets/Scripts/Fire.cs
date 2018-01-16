﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{



	public List <GameObject> FireFrames = new List<GameObject> ();
	public List <GameObject> FireFrames2 = new List<GameObject> ();
	public int CurrentFrame;
	public float TimeUntilNextFrame;
	public float TimeBetweenFrames;
	public int CurrentLevel;
	public ParticleSystem WoodAddToFireParticle;

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
		List <GameObject> ActiveFrames;

		if (CurrentLevel == 1) {
			for (int j = 0; j < FireFrames2.Count; j++) {
				FireFrames2 [j].SetActive(false);
			}			
		} else if (CurrentLevel == 2) {
			for (int k = 0; k < FireFrames.Count; k++) {
				FireFrames [k].SetActive(false);
			}
		}


		if (CurrentLevel == 1) {
			ActiveFrames = FireFrames;
		} else {
			ActiveFrames = FireFrames2;
		}


		TimeUntilNextFrame -= Time.deltaTime;

		if (TimeUntilNextFrame <= 0) {
			TimeUntilNextFrame = TimeBetweenFrames;
			CurrentFrame = CurrentFrame + 1;
			if (CurrentFrame >= ActiveFrames.Count) {
				CurrentFrame = 0;
			}

			for (int i = 0; i < ActiveFrames.Count; i++) {
				if (i == CurrentFrame) {
					ActiveFrames [i].SetActive (true);
				} else {
					ActiveFrames [i].SetActive (false);
				}
			}
		}
	}

	public void ReceiveWood(Tree tree) {
		Destroy (tree.gameObject);

		WoodAddToFireParticle.Clear ();
		WoodAddToFireParticle.Stop();
		WoodAddToFireParticle.Play();
	}
}
