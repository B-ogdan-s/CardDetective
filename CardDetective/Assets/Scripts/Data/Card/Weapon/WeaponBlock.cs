using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponBlock", menuName = "Data/Card/WeaponBlock")]
public class WeaponBlock : CardData
{
    [SerializeField] private RoomData _room;
    [SerializeField] private WeaponData _weapon;

    public override bool FilterCard(InvestigationData data)
    {
        if (data.Weapon == _weapon)
            return false;
        return true;
    }

    public override string GetCartData()
    {
        return _room.Name;
    }
    public override string GetCardTextData()
    {
        string text = $"{_weapon.Name} не орудие убийства";
        return text;
    }
}
