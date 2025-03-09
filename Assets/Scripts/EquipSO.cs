using UnityEngine;

[CreateAssetMenu(fileName = "EquipSO", menuName = "Scriptable Objects/EquipSO")]
public class EquipSO : ScriptableObject
{
    public Sprite equipSprite;
    public EquipType equipType;
}

public enum EquipType
{
    Kep,
    Dart,
    Bez,
    Anahtar,
    Ask�,
    Helikopter,
    Kamyon,
    Robot,
    Cekic,

}
