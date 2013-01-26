using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {
	
	public float speed = 2;
	protected Transform myTransform;
	protected exSprite spriteObj;
    protected exSpriteAnimation spriteAnimation;
	
	private int direction = 0;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
		spriteObj = GetComponent<exSprite>();
		spriteAnimation = GetComponent<exSpriteAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mov = Vector3.zero;
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			mov.x -= speed;
			if (!spriteObj.isHFlipped) {
				spriteObj.HFlip();
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			mov.x += speed;
			if (spriteObj.isHFlipped) {
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
		
		if (mov.x == 0 &&  mov.y == 0) {
			spriteAnimation.Pause();
		} 
		else {
			spriteAnimation.Resume();
		}
	}
}
