using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public string nextScene;
	public float allowedTime;
	public AudioClip randomClip;
	
	protected TextMesh textMesh;
	
	// Use this for initialization
	void Start () {
		textMesh = GetComponentInChildren<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		allowedTime -= Time.deltaTime;
		if (allowedTime <= 0) {
			textMesh.text = "00:00";
			//GameObject.FindGameObjectWithTag("Player").SendMessage("AimedAndFailed");
			PlayerLost();
		}
		else {
			int minutes = Mathf.FloorToInt(allowedTime / 60F);
			int seconds = Mathf.FloorToInt(allowedTime - minutes * 60);
			string time = string.Format("{0:00}:{1:00}", minutes, seconds);
			Debug.Log(time);
			textMesh.text = time;
		}
	}
	
	void NextScene() {
		Application.LoadLevel(nextScene);
	}
	
	void PlayerLost() {
		Application.LoadLevel("loseScene");
	}
}
