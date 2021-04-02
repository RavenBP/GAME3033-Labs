using Character.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Systems.Health;

namespace Character
{
    [RequireComponent(typeof(PlayerHealthComponent))]

    public class PlayerController : MonoBehaviour, IPausable
    {        
        public bool IsFiring;
        public bool IsReloading;
        public bool IsJumping;
        public bool IsRunning;
        public bool InInventory;

        public CrossHairScript CrossHair => CrossHairComponent;
        [SerializeField] private CrossHairScript CrossHairComponent;

        public HealthComponent Health => HealthComponent;
        private HealthComponent HealthComponent;

        public InventoryComponent Inventory => InventoryComponent;
        private InventoryComponent InventoryComponent;

        public WeaponHolder WeaponHolder => WeaponHolderComponent;
        private WeaponHolder WeaponHolderComponent;

        private GameUIController UIController;
        private PlayerInput PlayerInput;

        private void Awake()
        {
            UIController = FindObjectOfType<GameUIController>();
            PlayerInput = GetComponent<PlayerInput>();

            if (HealthComponent == null)
            {
                HealthComponent = GetComponent<HealthComponent>();
            }
            
            if (WeaponHolderComponent == null)
            {
                WeaponHolderComponent = GetComponent<WeaponHolder>();
            }

            if (InventoryComponent == null)
            {
                InventoryComponent = GetComponent<InventoryComponent>();
            }
        }

        public void OnPauseGame(InputValue value)
        {
            Debug.Log("Pause game");
            PauseManager.Instance.PauseGame();
        }

        public void OnUnPauseGame(InputValue value)
        {

            Debug.Log("UnPause game");
            PauseManager.Instance.UnPauseGame();
        }

        public void OnInventory(InputValue value)
        {
            if (InInventory)
            {
                InInventory = false;
                OpenInventory(false);
            }
            else
            {
                InInventory = true;
                OpenInventory(true);
            }
        }

        private void OpenInventory(bool open)
        {
            if (open)
            {
                PauseManager.Instance.PauseGame();
                UIController.EnableInventoryMenu();
            }
            else
            {
                PauseManager.Instance.UnPauseGame();
                UIController.EnableGameMenu();
            }
        }

        public void PauseMenu()
        {
            UIController.EnablePauseMenu();
            PlayerInput.SwitchCurrentActionMap("PauseActionMap");
        }

        public void UnPauseMenu()
        {
            UIController.EnableGameMenu();
            PlayerInput.SwitchCurrentActionMap("PlayerActionMap");
        }
    }
}
