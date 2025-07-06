using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameStartUI : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(Click);
        startButton.transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void Click() 
    {
        Managers.Game.GameStart();
        gameObject.SetActive(false); 
    }
}
