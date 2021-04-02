using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Character;

public class InventoryWidget : GameHUDWidget
{
    private ItemDisplayPanel ItemDisplayPanel;
    private List<CategorySelectButton> CategoryButtons;
    private PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = FindObjectOfType<PlayerController>();
        CategoryButtons = GetComponentsInChildren<CategorySelectButton>().ToList();
        ItemDisplayPanel = GetComponentInChildren<ItemDisplayPanel>();

        foreach(CategorySelectButton button in CategoryButtons)
        {
            button.Initialize(this);
        }
    }

    private void OnEnable()
    {
        if (!PlayerController || !PlayerController.Inventory)
        {
            return;
        }

        if (PlayerController.Inventory.GetItemCount() <= 0)
        {
            return;
        }

        ItemDisplayPanel.PopulatePanel(PlayerController.Inventory.GetItemsOfCategory(ItemCategory.None));
    }

    public void SelectCategory(ItemCategory category)
    {
        if (!PlayerController || !PlayerController.Inventory)
        {
            return;
        }

        if (PlayerController.Inventory.GetItemCount() <= 0)
        {
            return;
        }

        ItemDisplayPanel.PopulatePanel(PlayerController.Inventory.GetItemsOfCategory(category));
    }
}
