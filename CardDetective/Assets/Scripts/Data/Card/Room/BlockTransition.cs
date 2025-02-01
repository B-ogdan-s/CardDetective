using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockTransition", menuName = "Data/Card/BlockTransition")]
public class BlockTransition : CardData
{
    [SerializeField] private RoomData _room1;
    [SerializeField] private RoomData _room2;

    public override bool FilterCard(InvestigationData data)
    {
        List<RoomData> rooms = data.Path;

        for(int i = 0; i < rooms.Count - 1;  i++)
        {
            if((_room1 == rooms[i] && _room2 == rooms[i + 1]) || 
                (_room1 == rooms[i + 1] && _room2 == rooms[i]))
            {
                return false;
            }

        }

        return true;
    }

    public override string GetCartData()
    {
        string text = $"{_room1.Name}\n{_room2.Name}";
        return text;
    }

    public override string GetCardTextData()
    {
        string text = $"между {_room1.Name} и {_room2.Name} некто не ходил";
        return text;
    }
}
