using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject ItemSlotPrefab;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        WipeChildren();
    }

    public void PopulatePanel(List<ItemScriptable> itemList)
    {
        WipeChildren();

        foreach(ItemScriptable item in itemList)
        {
            IconSlot icon = Instantiate(ItemSlotPrefab, rectTransform).GetComponent<IconSlot>();
            icon.Initialize(item);
        }
    }

    private void WipeChildren()
    {
        foreach(RectTransform child in rectTransform)
        {
            Destroy(child.gameObject);
        }
    }
}
