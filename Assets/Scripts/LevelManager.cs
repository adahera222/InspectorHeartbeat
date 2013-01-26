using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public string nextScene;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void NextScene() {
		Application.LoadLevel(nextScene);
	}
	
	void PlayerLost() {
		Application.LoadLevel("loseScene");
	}
}
