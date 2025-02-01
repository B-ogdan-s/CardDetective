using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PossibleLocationPeople", menuName = "Data/Card/PossibleLocationPeople")]
public class PossibleLocationPeople : CardData
{
    [SerializeField] private RoomData _room;
    [SerializeField] private SuspectData _suspect1;
    [SerializeField] private SuspectData _suspect2;

    public override string GetCartData()
    {
        string text = $"{_suspect1.Name}\n{_suspect2.Name}\n{_room.Name}";
        return text;
    }
    public override string GetCardTextData()
    {
        string text = $"{_suspect1.Name} или {_suspect2.Name} могли пройти через {_room.Name}";
        return text;
    }
}
