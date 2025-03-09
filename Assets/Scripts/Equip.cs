using UnityEngine;
using UnityEngine.UI;

public class Equip : MonoBehaviour
{
    private EquipSO equipSO;
    public EquipSO EquipSO { get => equipSO; set => equipSO = value; }

    [SerializeField] private Image icon;
    private EquipType equipType;
    public void Initialized(EquipSO equipSO)
    {
        this.equipSO = equipSO;
        icon.sprite = equipSO.equipSprite;
        equipType = equipSO.equipType;
    }
}
