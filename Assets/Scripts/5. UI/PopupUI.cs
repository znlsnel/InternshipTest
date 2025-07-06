using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PopupUI : UIBase
{
	[SerializeField] private Transform _panel;

    public void Init()
	{
		Managers.UI.SetCanvas(gameObject); 
	}

	public override void Hide()
    { 
		_panel.transform.DOKill(); 
        _panel.transform.DOScale(0.5f, 0.3f).SetEase(Ease.OutCubic).onComplete += () => {
            base.Hide();  
			_panel.transform.localScale = Vector3.one;     
        };
    }

}
