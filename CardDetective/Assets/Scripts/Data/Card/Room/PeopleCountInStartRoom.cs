using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PeopleCountInStartRoom", menuName = "Data/Card/PeopleCountInStartRoom")]
public class PeopleCountInStartRoom : CardData
{
    [SerializeField] private RoomData _room;
    [SerializeField] private byte _count;

    public override bool FilterCard(InvestigationData data)
    {
        int count = data.InitialRoomAssignments[_room].Count;

        if(count == _count)
            return true;

        return false;
    }

    public override string GetCartData()
    {
        return _room.Name;
    }
    public override string GetCardTextData()
    {
        string text = $"в {_room.Name} было {_count} людей";
        return text;
    }
}
