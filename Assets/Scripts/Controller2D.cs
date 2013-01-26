using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {
	
	public float speed = 2;
	public AudioClip actionSound;
	
	protected Transform myTransform;
	protected exSprite spriteObj;
    protected exSpriteAnimation spriteAnimation;
	protected bool failing = false;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
		spriteObj = GetComponent<exSprite>();
		spriteAnimation = GetComponent<exSpriteAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!failing) {
			Vector3 mov = Vector3.zero;
			
			if (Input.GetKey(KeyCode.LeftArrow)) {
				mov.x -= speed;
				if (spriteObj.isHFlipped) {
					spriteObj.HFlip();
				}
			}
			if (Input.GetKey(KeyCode.RightArrow)) {
				mov.x += speed;
				if (!spriteObj.isHFlipped) {
					spriteObj.HFlip();
				}
			}
			if (Input.GetKey(KeyCode.UpArrow)) {
				mov.y += speed;
			}
			if (Input.GetKey(KeyCode.DownArrow)) {
				mov.y -= speed;
			}
			myTransform.Translate(mov,Space.World);
			
			//string animName = spriteAnimation.GetCurrentAnimation().name;
			exSpriteAnimState anim = spriteAnimation.GetCurrentAnimation();
			string animName = "";
			if (anim != null) {
				animName = anim.name;
			}
			if (mov.x == 0 &&  mov.y == 0) {
				spriteAnimation.Pause();
				if (animName != "InspectorAnimationIdle") {
					spriteAnimation.Play("InspectorAnimationIdle");
				}
			} 
			else if (animName != "InspectorAnimationMoving") {
				spriteAnimation.Play("InspectorAnimationMoving");
				//spriteAnimation.Resume();
			}
			
			// Handle clicks
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				audio.clip = actionSound;
				audio.Play();
			}
		}
	}
	
	void AimedAndFailed() {
		failing = true;
		spriteAnimation.Play("InspectorAnimationActing");
	}
	void AimedAndWon() {
		failing = true;
		spriteAnimation.Play("InspectorAnimationWin");
	}
}
