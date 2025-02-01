using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BlockPeople", menuName = "Data/Card/BlockPeople")]
public class BlockPeople : CardData
{
    [SerializeField] private RoomData _room;
    [SerializeField] private SuspectData _suspect1;
    [SerializeField] private SuspectData _suspect2;

    public override bool FilterCard(InvestigationData data)
    {
        foreach(var room in data.Path)
        {
            if(room == _room && (data.Suspect == _suspect1 || data.Suspect == _suspect2))
            {
                return false;
            }
        }
        return true;
    }

    public override string GetCartData()
    {
        string text = $"{_suspect1.Name}\n{_suspect2.Name}\n{_room.Name}";
        return text;
    }
    public override string GetCardTextData()
    {
        string text = $"{_suspect1.Name} и {_suspect2.Name} НЕ проходив через {_room.Name}";
        return text;
    }
}
