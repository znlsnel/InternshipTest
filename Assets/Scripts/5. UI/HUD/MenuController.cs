using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button menuCatalogButton;
    [SerializeField] private MonsterCatalogUI monsterCatalogUIPrefab;

    private MonsterCatalogUI monsterCatalogUI;

    void Start()
    {
        menuCatalogButton.onClick.AddListener(ClickMenuCatalog);
    }


    private void ClickMenuCatalog()
    {
        if (monsterCatalogUI == null)
            monsterCatalogUI = Instantiate(monsterCatalogUIPrefab);

        Managers.UI.ShowPopupUI(monsterCatalogUI);
        monsterCatalogUI.Open();
    }
}
