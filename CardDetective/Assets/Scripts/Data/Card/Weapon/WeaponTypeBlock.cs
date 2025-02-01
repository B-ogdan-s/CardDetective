using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponTypeBloc", menuName = "Data/Card/WeaponTypeBlock")]
public class WeaponTypeBlock : CardData
{
    [SerializeField] private RoomData _roomData;
    [SerializeField] private List<WeaponData> _weapons;
    [SerializeField] private WeaponType _type;

    public override bool FilterCard(InvestigationData data)
    {
        if (data.Weapon.Type == _type)
            return false;

        return true;
    }

    public override string GetCartData()
    {
        return _roomData.Name;
    }
    public override string GetCardTextData()
    {
        string text = $"{_type} НЕ использовались для убийства";
        return text;
    }
}
