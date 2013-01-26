using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RUIManager : MonoBehaviour
{
	public static RUIManager instance;
	public bool debug = true;
	//	------------------------------
	
	LayerMask UILayer;
	bool layerDefined = false;
	bool somethingToManage = false;
	int rayDistance = 50000;
	
	//	BUTTONS	----------------------------------------
	bool manageButtons = false;
	private List<GameObject> buttons;
	GameObject pressButton;
	
	void Awake ()
	{
		instance = this;
	}
	
	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (somethingToManage) {
		
			
			if (Input.touchCount == 1) {
				
				Touch t = Input.touches [0];
				Ray ray = Camera.main.ScreenPointToRay (t.position);
				
				if (debug) {
					Debug.DrawRay (ray.origin, ray.direction * rayDistance, Color.red);
				}
				
				if (manageButtons) {
					
					if (t.phase == TouchPhase.Began) {
						
						RaycastHit hit;
						if (Physics.Raycast (ray, out hit, rayDistance, UILayer)) {
							
							GameObject go = findInButtonsList (hit.transform.gameObject);
							
							if (go) {
								RUISpriteButton sb = go.GetComponent<RUISpriteButton>();
								if (sb.getCurrentState() == RUISpriteButton.states.Normal){
									pressButton = go;
									sb.changeToClickedState();
								}
							}
						}
						
					} else if ((t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)) {
						RaycastHit hit;
						if (Physics.Raycast (ray, out hit, rayDistance, UILayer)) {
							
							GameObject go = findInButtonsList (hit.transform.gameObject);
							
							if (go) {
								RUISpriteButton sb = go.GetComponent<RUISpriteButton>();
								if (sb.getCurrentState() == RUISpriteButton.states.Clicked){
									
									if (go == pressButton){
										sb.executeAction();
									} else {
										pressButton = null;
									}
									
									sb.changeToNormalState();
								}
							}
						}
					}
				}
			}
		}
	}
	
	public void registerRUISpriteButton (GameObject go)
	{
		somethingToManage = true;
		
		if (!manageButtons) {
			buttons = new List<GameObject> ();
			if (!layerDefined) {
				UILayer = 1 << go.layer;
				layerDefined = true;
			}
		}
		
		manageButtons = true;
		buttons.Add (go);		
	}
	
	public void unRegisterRUISpriteButton (GameObject go)
	{
				
	}
	
	GameObject findInButtonsList (GameObject go)
	{
		foreach (GameObject goi in buttons) {
			if (goi.GetInstanceID () == go.GetInstanceID ()) {
				return goi;
			}
		}
		
		return null;
	}
	
}
