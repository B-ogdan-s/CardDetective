using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StartedPosition", menuName = "Data/Card/StartedPosition")]
public class StartedPosition : CardData
{
    [SerializeField] private RoomData _room;
    [SerializeField] private SuspectData _suspect;

    public override bool FilterCard(InvestigationData data)
    {
        if (data.Suspect == _suspect && data.Path[0] == _room)
            return true;

        foreach (var info in data.InitialRoomAssignments)
        {
            if (info.Key == _room)
            {
                foreach (var s in info.Value)
                {
                    if (s == _suspect)
                        return true;
                }
            }
        }

        return false;
    }

    public override string GetCartData()
    {
        string text = $"{_suspect.Name}\n{_room.Name}";
        return text;
    }
    public override string GetCardTextData()
    {
        string text = $"{_suspect.Name} заявляет что била в {_room.Name} во время убийства";
        return text;
    }
}
