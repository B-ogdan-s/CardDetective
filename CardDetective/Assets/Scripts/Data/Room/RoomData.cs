using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomData", menuName = "Data/RoomData")]
public class RoomData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private bool _isStartedRoom;

    [SerializeField] private List<RoomData> _rooms = new();
    [SerializeField] private List<WeaponData> _weapons = new();

    public string Name => _name;
    public bool IsStartedRoom => _isStartedRoom;
    public List<RoomData> Rooms => _rooms;
    public List<WeaponData> Weapons => _weapons;
}
