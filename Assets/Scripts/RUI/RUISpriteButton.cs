using UnityEngine;
using System.Collections;

public class RUISpriteButton : MonoBehaviour
{
	public string ClickState;
	private string NormalState;
	private exSprite sp;
	
	public enum states
	{
		Clicked,
		Normal
	}
	
	private states currentState;
	
	void Start ()
	{	
		RUIManager.instance.registerRUISpriteButton(gameObject);
		
		sp = transform.GetComponent<exSprite> ();
		currentState = states.Normal;
		int idx = sp.index;
		NormalState = sp.atlas.elements [idx].name;
		
		if (ClickState == null || ClickState == "") {
			Debug.LogWarning ("Click State NOT SET: " + name);
		}
		
	}
	
	public states getCurrentState(){
		return currentState;
	}
	
	void Update()
	{
		if (Input.touchCount == 0 && currentState == states.Clicked) {
			changeToNormalState ();
		}
	}
	
	public void changeToClickedState ()
	{
		SpriteUtility.ChangeSprite (transform, ClickState);
		currentState = states.Clicked;
	}
	
	public void changeToNormalState ()
	{
		SpriteUtility.ChangeSprite (transform, NormalState);
		currentState = states.Normal;
	}
	
	public void executeAction ()
	{
		EventManager.instance.QueueEvent (new GenericEvent (name + "_clicked"));
	}
}
