using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] RectTransform followBar;


    private void Start()
    {
        GetComponentInParent<ResourceHandler>().Hp.OnResourceChanged += OnHpChanged; 
        OnHpChanged(1f, 1f); 
    }

    private void OnHpChanged(float current, float max)
    {
        slider.DOValue(current / max, 0.2f);
        followBar.DOAnchorMax(new Vector2(current / max, 1), 1f);
    }
}
