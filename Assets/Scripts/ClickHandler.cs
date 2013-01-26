using UnityEngine;
using System.Collections;

public class ClickHandler : MonoBehaviour {
	
	public bool isAlien = false;
	public float timeToExit = 1;
	public AudioClip winSound;
	public AudioClip loseSound;
	public static int maxAliens = 1;
	protected bool hasLost = false;
	protected bool hasWon = false;
	protected static int nHandlers = 0;
	protected static int nAliens = 0;
	protected static int nHumans = 0;
	protected Transform myTransform;
	protected exSprite spriteObj;
    protected exSpriteAnimation spriteAnimation;
	protected GameObject player;
	protected LevelManager LM;
	void Awake() {
		Debug.Log("Awaking #" + nHandlers);
		nHandlers++;
	}
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		LM = (LevelManager)FindObjectOfType(typeof(LevelManager));
		
		Debug.Log("Starting #" + nHumans);
		myTransform = transform;
		spriteObj = GetComponent<exSprite>();
		spriteAnimation = GetComponent<exSpriteAnimation>();
		// Determine if I should be an alien.
		if (nAliens < maxAliens) {
			float pAlien = 0;
			if (nHumans >= nHandlers - maxAliens) {
				pAlien = 1;
			}
			else {
				pAlien = Random.Range(0, nHandlers);
			}			
			if (pAlien <= 1 || nHumans >= nHandlers ) {
				Debug.Log("Human "+ nHumans + " Is an ALIEN!");
				isAlien = true;
				nAliens++;
				nHumans++;
			}
			else {
				Debug.Log("Human "+ nHumans + " Is a HUMAN!");
				nHumans++;
			}
		}
		//EventManager.instance.AddListener(this, "Oso_clicked");
		if (isAlien) {
			audio.pitch = 1.75f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (hasLost || hasWon) {
			if (timeToExit > 0) {
				timeToExit -= Time.deltaTime;
			}
			else {
				if (hasWon) {
					// Ganamo
					LM.SendMessage("NextScene");
				}
				else {
					// Perdimo
					LM.SendMessage("PlayerLost");
				}
			}
		}
	}
	
	void OnMouseDown() {
		if (isAlien) {
			// Ganamo
			hasWon = true;
			audio.clip = winSound;
			audio.loop = false;
			audio.pitch = 1;
			audio.Play();
			spriteAnimation.Play("AlienAnimationDie");
			player.SendMessage("AimedAndWon");
		}
		else {
			// Perdimo
			hasLost = true;
			audio.clip = loseSound;
			audio.loop = false;
			audio.Play();
			player.SendMessage("AimedAndFailed");
		}
	}
	
	void OnDestroy() {
		nHandlers = 0;
		nHumans = 0;
		nAliens = 0;
	}
}
