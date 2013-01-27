using UnityEngine;
using System.Collections;

public class LinearMoveBehavior : MonoBehaviour {
	
	public float speed = 1;
	public float ySpeed = 0;
	public bool bounce = false;
	public bool loopY = false;
	
	protected Transform myTransform;
	protected exSprite spriteObj;
    protected exSpriteAnimation spriteAnimation;
	
	protected float bounceTimeOut = 0;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
		spriteObj = GetComponent<exSprite>();
		spriteAnimation = GetComponent<exSpriteAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		this.myTransform.Translate(new Vector3(speed, ySpeed, 0));
		
		if (speed > 0 && !spriteObj.isHFlipped) {
				spriteObj.HFlip();
		}
		if (speed < 0 && spriteObj.isHFlipped) {
				spriteObj.HFlip();
		}
		if (bounceTimeOut > 0) {
			bounceTimeOut -= Time.deltaTime;
		}
	}
	
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.cyan;
    	Vector3 direction = transform.TransformDirection (new Vector3(speed * 100, 0, 0));
		Gizmos.DrawRay (transform.position, direction);
	}
	
	
	void OnBecameInvisible () {
		if (bounce && bounceTimeOut <= 0) {
    		speed = speed * -1;
			myTransform.Translate(new Vector3(speed * 5, 0, 0));
			bounceTimeOut = 1;
		}
		if (loopY) {
			myTransform.position = new Vector3(transform.position.x, -200, transform.position.z);
		}
	}
}
