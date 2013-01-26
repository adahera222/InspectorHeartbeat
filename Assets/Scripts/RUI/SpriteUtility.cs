using UnityEngine;
using System.Collections;

/**
 * NOTE: 
 * 		Functions that use atlasName (in order to switch the sprite between different atlases). Must follow the next guidelines:
 * 				- Texture, Material and exAtlas file MUST be into Resources Folder
 * 				- exAtlas file MUSTN'T share the name with the Texture and the Material. exAtlas name MUST be different
 * 
 * 		Functions that receives the Transform name MUST be used in cases where you aren't sure the object you are trying to find has a unique name.
 * 		Functions that receives the transformName instead, uses GameObject.Find function to locate the GameObject / Transform, so it may not work if you
 * 		have duplicity
 * */
public class SpriteUtility {
	
	/// <summary>
	/// Change the sprite image from another image in the same (or different atlas), using the specific index
	/// </summary>
	/// <param name='sprite'>
	/// Sprite. exSprite to be changed
	/// </param>
	/// <param name='atlas'>
	/// Atlas. exAtlas (may be the same atlas or a new one)
	/// </param>
	/// <param name='index'>
	/// Index. int (the identifier of the new Sprite)
	/// </param> 
	private static void ChangeSprite(exSprite sprite, exAtlas atlas, int index){			
		float width = sprite.width;
		float height = sprite.height;
		sprite.SetSprite(atlas,index,false);
		sprite.height = height;
		sprite.width = width;							
	}
	
	/// <summary>
	/// Gets the transform.
	/// </summary>
	/// <returns>
	/// The transform.
	/// </returns>
	/// <param name='transformName'>
	/// Transform name.
	/// </param>
	private static Transform GetTransform(string transformName){
		GameObject go = GameObject.Find(transformName);
		if(go==null) {
			Debug.LogWarning(transformName + " not found, can't find a GameObject with this name");
		}
		return go.transform;
	}	
	/// <summary>
	/// Gets the sprite from transform.
	/// </summary>
	/// <returns>
	/// The sprite from transform.
	/// </returns>
	/// <param name='transform'>
	/// Transform.
	/// </param>
	private static exSprite GetSpriteFromTransform(Transform transform){
		exSprite sprite = transform.GetComponent<exSprite>();
		if(sprite==null) Debug.LogWarning("exSprite component not found for object " + transform.name);
		return transform.GetComponent<exSprite>();
	}	
	
	/// <summary>
	/// Gets the atlas from sprite.
	/// </summary>
	/// <returns>
	/// The atlas from sprite.
	/// </returns>
	/// <param name='sprite'>
	/// Sprite.
	/// </param>
	private static exAtlas GetAtlasFromSprite(exSprite sprite){
		return sprite.atlas;
	}
	
	/// <summary>
	/// Gets the atlas from resource.
	/// </summary>
	/// <returns>
	/// The atlas from resource.
	/// </returns>
	/// <param name='atlasName'>
	/// Atlas name.
	/// </param>
	private static exAtlas GetAtlasFromResource(string atlasName){
		exAtlas atlas = Resources.Load(atlasName) as exAtlas;		
		if(atlas==null) Debug.LogWarning("Can't load the resource " + atlasName);
		return atlas;
	}
	
	/// <summary>
	/// Changes the sprite.
	/// </summary>
	/// <param name='transform'>
	/// Transform.
	/// </param>
	/// <param name='spriteName'>
	/// Sprite name.
	/// </param>
	public static void ChangeSprite(Transform transform,string spriteName){				
			exSprite sprite = GetSpriteFromTransform(transform);
			exAtlas atlas = GetAtlasFromSprite(sprite);				
			int index = atlas.GetIndexByName(spriteName);
			ChangeSprite(sprite,atlas,index);				
	}
	
	/// <summary>
	/// Changes the sprite.
	/// </summary>
	/// <param name='transform'>
	/// Transform.
	/// </param>
	/// <param name='spriteIndex'>
	/// Sprite index.
	/// </param>
	public static void ChangeSprite(Transform transform,int spriteIndex){		
		exSprite sprite = GetSpriteFromTransform(transform);
		ChangeSprite(sprite,sprite.atlas,spriteIndex);
	}
	
	/// <summary>
	/// Changes the sprite. USING ATLAS FROM RESOURCE
	/// </summary>
	/// <param name='transform'>
	/// Transform.
	/// </param>
	/// <param name='spriteName'>
	/// Sprite name.
	/// </param>
	/// <param name='atlasName'>
	/// Atlas name.
	/// </param>
	public static void ChangeSprite(Transform transform,string spriteName,string atlasName){
		exSprite sprite = GetSpriteFromTransform(transform);
		exAtlas atlas = GetAtlasFromResource(atlasName);
		int index = atlas.GetIndexByName(spriteName);
		ChangeSprite(sprite,atlas,index);
	}
	
	/// <summary>
	/// Changes the sprite. USING ATLAS FROM RESOURCE
	/// </summary>
	/// <param name='transform'>
	/// Transform.
	/// </param>
	/// <param name='spriteIndex'>
	/// Sprite index.
	/// </param>
	/// <param name='atlasName'>
	/// Atlas name.
	/// </param>
	public static void ChangeSprite(Transform transform,int spriteIndex,string atlasName){
		exSprite sprite = GetSpriteFromTransform(transform);
		exAtlas atlas = GetAtlasFromResource(atlasName);
		ChangeSprite(sprite,atlas,spriteIndex);
	}
	
	/// <summary>
	/// Changes the sprite.
	/// </summary>
	/// <param name='transformName'>
	/// Transform name.
	/// </param>
	/// <param name='spriteName'>
	/// Sprite name.
	/// </param>
	public static void ChangeSprite(string transformName, string spriteName){
		ChangeSprite(GetTransform(transformName),spriteName);
	}
	
	/// <summary>
	/// Changes the sprite.
	/// </summary>
	/// <param name='transformName'>
	/// Transform name.
	/// </param>
	/// <param name='spriteIndex'>
	/// Sprite index.
	/// </param>
	public static void ChangeSprite(string transformName, int spriteIndex){
		ChangeSprite(GetTransform(transformName),spriteIndex);
	}
	
	/// <summary>
	/// Changes the sprite. USING ATLAS FROM RESOURCE
	/// </summary>
	/// <param name='transformName'>
	/// Transform name.
	/// </param>
	/// <param name='spriteName'>
	/// Sprite name.
	/// </param>
	/// <param name='atlasName'>
	/// Atlas name.
	/// </param>
	public static void ChangeSprite(string transformName,string spriteName,string atlasName){
		ChangeSprite(GetTransform(transformName),spriteName,atlasName);
	}
	
	/// <summary>
	/// Changes the sprite. USING ATLAS FROM RESOURCE
	/// </summary>
	/// <param name='transformName'>
	/// Transform name.
	/// </param>
	/// <param name='spriteIndex'>
	/// Sprite index.
	/// </param>
	/// <param name='atlasName'>
	/// Atlas name.
	/// </param>
	public static void ChangeSprite(string transformName,int spriteIndex,string atlasName){
		ChangeSprite(GetTransform(transformName),spriteIndex,atlasName);
	}

	
}
