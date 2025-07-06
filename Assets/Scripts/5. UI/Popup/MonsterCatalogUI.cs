using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MonsterCatalogUI : PopupUI
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private MonsterInfoUI infoPanel;
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonParent;

    Vector3 mainPanelPosition;
    private bool isOpen = true;

    private void Start()
    {
        infoPanel.gameObject.SetActive(false);
        closeButton.onClick.AddListener(ClickClose);
        mainPanelPosition = mainPanel.transform.localPosition;
        Setup();
    }

    private void Setup()
    {
        foreach (MonsterData data in Managers.Data.monsterData.Values)
        {
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<TextMeshProUGUI>().text = data.Name;
            button.GetComponent<Button>().onClick.AddListener(
                () => infoPanel.Setup(data)
            );
        }
    }

    public void Open()
    {
        if (isOpen) 
            return;

        isOpen = true;
        closeButton.gameObject.SetActive(true);
        mainPanel.transform.localPosition = mainPanelPosition + new Vector3(0, -400, 0);   

        mainPanel.transform.DOKill();
        mainPanel.transform.DOMoveY(0, 0.5f).SetEase(Ease.OutCubic);
    }


    private void ClickClose()
    {
        if (isOpen == false)
            return;

        if (infoPanel.gameObject.activeSelf)
        {
            infoPanel.gameObject.SetActive(false);
        }
        else
        {
            closeButton.gameObject.SetActive(false);
 
            isOpen = false;
            mainPanel.transform.localPosition = mainPanelPosition;  

            mainPanel.transform.DOKill();
            mainPanel.transform.DOMoveY(-400, 0.5f).SetEase(Ease.OutCubic);  
        }
    }
    
}
