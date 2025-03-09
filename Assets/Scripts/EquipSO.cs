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
    Aský,
    Helikopter,
    Kamyon,
    Robot,
    Cekic,

}
