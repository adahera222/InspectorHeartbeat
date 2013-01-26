using UnityEngine;
using System.Collections;

public class EventPF: IEvent
{

	private string _name;
	private object _data;
		
	
	// levels
	public const string PHASE_GAMEPLAY_LEVEL_START = "PHASE_GAMEPLAY_LEVEL_START";
	public const string PHASE_GAMEPLAY_LEVEL_END = "PHASE_GAMEPLAY_LEVEL_START";
	public const string PHASE_GAMEPLAY_NEW_HORDE_PREPARE = "PHASE_GAMEPLAY_NEW_HORDE_PREPARE";
	public const string PHASE_GAMEPLAY_NEW_HORDE_START = "PHASE_GAMEPLAY_NEW_HORDE_START";
	public const string PHASE_GAMEPLAY_NEW_HORDE_END = "PHASE_GAMEPLAY_NEW_HORDE_END";
	public const string PHASE_GAMEPLAY_GAME_OVER = "PHASE_GAMEPLAY_GAME_OVER";
	
	// enemies
	public const string ENEMY_KILLED = "EnemyKilled";	
	public const string PLANET_RECEIVE_DAMAGE = "PLANET_RECEIVE_DAMAGE";
	public const string SKILL_USED = "SKILL_USED";
	
	// tower construction
	public const string TOWER_TO_BUILD_SELECT = "TOWER_TO_BUILD_SELECT";
	public const string TOWER_BUILD_DONE = "TOWER_BUILD_DONE";
	
	// ENERGY & FURY
	public const string UPDATE_ENERGY = "UPDATE_ENERGY";
	public const string UPDATE_FURY = "UPDATE_FURY";

	
	// BULLET
	public const string MANUAL_MODE_CHANGED = "MANUAL_MODE_CHANGED";
	public const string HIDE_LINE_OF_SIGHT = "HIDE_LINE_OF_SIGHT";
	public const string SHOW_LINE_OF_SIGHT = "SHOW_LINE_OF_SIGHT";
	
	public EventPF (string name, object data = null){
		_name = name;
		_data = data;
	}

	string IEvent.GetName ()
	{
		//return this.GetType ().ToString ();
		return _name;
	}

	object IEvent.GetData ()
	{
		//return "TestEvent Data goes here!";
		return _data;
	}
}