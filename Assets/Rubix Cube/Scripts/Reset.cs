using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    public GameObject cube;
	public bool trailEnabled = false;
	public bool pistonEnabled = false;
	public int comboSelectedIndex = 6;
	private static bool spawned = false;
	void Awake(){
		if(spawned == false){
			spawned = true;		
			DontDestroyOnLoad(gameObject);
		}else{
			DestroyImmediate(gameObject);
		}
	}
}