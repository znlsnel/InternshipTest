using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIManager : IManager
{
    private Stack<PopupUI> _popupStack = new Stack<PopupUI>();
    private UIBase _sceneUI = null; 

    private int _order = 10;


    public void Clear()
    {
        
    }

    public void Init()
    {
        
    }


    public void SetCanvas(GameObject go)
    {
        Canvas canvas = go.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

 
        canvas.sortingOrder = _order;
        _order++;

    }

    public void RegisterSceneUI(SceneUI sceneUI)
    {
        if (_sceneUI != null)
            _sceneUI.Hide();

        _sceneUI = sceneUI;
    }

    public void HideSceneUI()
    {
        if (_sceneUI == null)
            return;

        _sceneUI.Hide();
    }

    public void ShowSceneUI()
    {
        if (_sceneUI == null)
            return;

        _sceneUI.Show();
    }


    public void ShowPopupUI<T>(T popup) where T : PopupUI
    {
        _popupStack.Push(popup);   

        popup.Show(); 
        popup.Init();  
		return; 
    }


    public void ClosePopupUI(float time = 0.0f)
    {
        if (_popupStack.Count == 0) 
            return;

        PopupUI popup = _popupStack.Pop();
        while (_popupStack.Count > 0 && (popup == null || popup.IsOpen == false))
        {
            popup = _popupStack.Pop();
            _order--;
        }
        
        if (popup != null)
        {
            popup.Hide();
            _order--; 
        } 
    }


    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

}
