using UnityEngine;

internal class InventoryController : MonoBehaviour
{
    [SerializeField] private InventorySlot[] inventorySlots;
    private PlayerControls playerControl;

    private void Awake()
    {
        playerControl = new PlayerControls();
        playerControl.Inventory.Keyboard.performed += Keyboard_performed;
    }
    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void Start()
    {
        ToggleActiveSlot(0);
    }

    private void Keyboard_performed(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        var activeIndex = (int)ctx.ReadValue<float>() - 1;
        ToggleActiveSlot(activeIndex);
    }

    private void ToggleActiveSlot(int index)
    {
        if (index < 0 || index >= inventorySlots.Length)
        {
            return;
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].SetActive(i == index);
            if (i == index)
            {
                SetCurrentWeapon(inventorySlots[i].GetWeaponInfo());
            }
        }
    }

    private void SetCurrentWeapon(WeaponInfo weaponInfo)
    {
        DataManager.GetInstance().CurrentSelectWeapon.Value = weaponInfo;
    }
}