using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum EPlayerInput
{
	Click,
	Pointer,
}

[System.Serializable]
public class InputManager : IManager
{
	[SerializeField] private InputActionAsset inputActionAsset; 

	private Dictionary<EPlayerInput, InputAction> playerInputs = new Dictionary<EPlayerInput, InputAction>();


	// Input Action Map   
	private InputActionMap _playerActionMap;


	// === Input Properties ===
	public InputAction Click => playerInputs[EPlayerInput.Click];	  
	public InputAction Pointer => playerInputs[EPlayerInput.Pointer];


	// === Input Actions ===
	public InputAction GetInput(EPlayerInput type) => playerInputs[type];

    public void Init()
    {
		if (inputActionAsset == null)
			return;

        _playerActionMap = BindAction<EPlayerInput>(typeof(EPlayerInput), out playerInputs);
		inputActionAsset.Enable(); 
    } 

    public void Clear()
    { 
         
    }

	public void SetInputActive(bool active)
	{
		if (active)
			inputActionAsset.Enable();
		else
			inputActionAsset.Disable();
	}
 
	private InputActionMap BindAction<T>(Type type, out Dictionary<T, InputAction> playerInputs) where T : Enum
	{
		playerInputs = new Dictionary<T, InputAction>();
		if (inputActionAsset == null)
			return null; 

		string mapName = type.Name;
		if (mapName[0] == 'E')
			mapName = mapName.Substring(1);

		var actionMap = inputActionAsset.FindActionMap(mapName);
		foreach (var t in Enum.GetValues(typeof(T)))
		{ 
			string name = t.ToString(); 
			playerInputs[(T)t] = actionMap.FindAction(name);  
		} 
 
		return actionMap;
	} 
}
