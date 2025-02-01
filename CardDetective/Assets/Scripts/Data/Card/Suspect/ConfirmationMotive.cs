using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfirmationMotive", menuName = "Data/Card/ConfirmationMotive")]
public class ConfirmationMotive : CardData
{
    [SerializeField] private SuspectData _suspect;
    [SerializeField] private RoomData _room;
    [SerializeField, Range(0, 2)] private byte _motiveID;

    public override string GetCartData()
    {
        string text = $"{_suspect.Name}\n{_room.Name}";
        return text;
    }
    public override string GetCardTextData()
    {
        string text = $"у {_suspect.Name}, был мотив: {_suspect.Motives[_motiveID].Name}";
        return text;
    }
}
