using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class ItemPickupComponent : MonoBehaviour
{
    [SerializeField]
    private ItemScriptable PickupItem;
    [Tooltip("Manual override for drop amount, if left at -1 it will use the amount from the scriptable object.")]
    [SerializeField]
    private int Amount = -1;
    [SerializeField]
    private MeshRenderer PropMeshRenderer;
    [SerializeField]
    private MeshFilter PropMeshFilter;

    private ItemScriptable ItemInstance;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate();
    }

    private void Instantiate()
    {
        ItemInstance = Instantiate(PickupItem);

        if (Amount > 0)
        {
            ItemInstance.SetAmount(Amount);

            ApplyMesh();
        }
    }

    private void ApplyMesh()
    {
        if (PropMeshFilter)
        {
            PropMeshFilter.mesh = PickupItem.ItemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        }

        if (PropMeshRenderer)
        {
            PropMeshRenderer.materials = PickupItem.ItemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterials;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        
        Debug.Log($"{PickupItem.name} - Picked Up");
        InventoryComponent playerInventory = other.GetComponent<InventoryComponent>();

        if (playerInventory)
        {
            playerInventory.AddItem(ItemInstance, Amount);
        }

        Destroy(gameObject);
    }

    private void OnValidate()
    {
        ApplyMesh();
    }
}
