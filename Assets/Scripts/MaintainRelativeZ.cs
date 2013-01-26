using UnityEngine;
using System.Collections;

public class MaintainRelativeZ : MonoBehaviour {
	
	protected Transform myTransform;
	
	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3(transform.position.x,transform.position.y, 1);
		pos.z = pos.y / 10;
		transform.position = pos;
	}
}
