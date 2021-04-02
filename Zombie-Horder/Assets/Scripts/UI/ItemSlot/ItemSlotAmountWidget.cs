using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlotAmountWidget : MonoBehaviour
{
    [SerializeField]
    private TMP_Text AmountText;

    private ItemScriptable Item;

    private void Awake()
    {
        HideWidget();
    }

    public void ShowWidget()
    {
        gameObject.SetActive(true);
    }

    public void HideWidget()
    {
        gameObject.SetActive(false);
    }

    public void Initialize(ItemScriptable item)
    {
        if (!item.Stackable)
        {
            return;
        }    

        Item = item;
        ShowWidget();
        Item.OnAmountChange += OnAmountChange;
        OnAmountChange();
    }

    private void OnAmountChange()
    {
        AmountText.text = Item.Amount.ToString();
    }

    private void OnDisable()
    {
        if (Item)
        {
            Item.OnAmountChange -= OnAmountChange;
        }
    }
}
