using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponMaker
{
    public static WeaponData GetWeapon(List<RoomData> rooms)
    {
        List<WeaponData> weapons = new List<WeaponData>();

        foreach (RoomData room in rooms)
        {
            weapons.AddRange(room.Weapons);
        }

        return weapons[Random.Range(0, weapons.Count)];
    }
}
