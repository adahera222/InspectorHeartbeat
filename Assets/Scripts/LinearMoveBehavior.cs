using UnityEngine;
using System.Collections;

public class LinearMoveBehavior : MonoBehaviour {
	
	public float speed = 1;
	public bool bounce = false;
	
	protected Transform myTransform;
	protected exSprite spriteObj;
    protected exSpriteAnimation spriteAnimation;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
		spriteObj = GetComponent<exSprite>();
		spriteAnimation = GetComponent<exSpriteAnimation>();
	}
	
	// Update is called once per frame
	void Update () {
		this.myTransform.Translate(new Vector3(speed, 0, 0));
		
		if (speed > 0 && !spriteObj.isHFlipped) {
				spriteObj.HFlip();
		}
		if (speed < 0 && spriteObj.isHFlipped) {
				spriteObj.HFlip();
		}
	}
	
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.cyan;
    	Vector3 direction = transform.TransformDirection (new Vector3(speed * 100, 0, 0));
		Gizmos.DrawRay (transform.position, direction);
	}
	
	
	void OnBecameInvisible () {
		if (bounce) {
    		speed = speed * -1;
		}
	}
}
