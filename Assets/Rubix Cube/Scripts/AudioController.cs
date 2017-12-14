using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioController : MonoBehaviour {
	public bool isBGMPlaying = true;

	public AudioClip rubikturnsfx;
	[HideInInspector]
	public AudioSource sfxsource;
	public bool enableSFX = true;
	public int play = 0;
	private static bool spawned = false;
	
	void Awake(){

		if (spawned == false) {
			spawned = true;			
			DontDestroyOnLoad (gameObject);	

		} else {
			DestroyImmediate (gameObject);
		}
	}

	void Start(){
		sfxsource = gameObject.AddComponent < AudioSource > ();
	}

	public void OnSFXTogglePushed(){
		enableSFX = enableSFX ? false : true;
	}
}
