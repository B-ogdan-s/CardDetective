using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraceTypeBlock", menuName = "Data/Card/TraceTypeBlock")]
public class TraceTypeBlock : CardData
{
    [SerializeField] private RoomData _roomData;
    [SerializeField] private List<WeaponData> _weapons;
    [SerializeField] private TraceType _traceType;

    public override bool FilterCard(InvestigationData data)
    {
        foreach(var type in data.Weapon.Traits)
        {
            if(type == _traceType) return false;
        }

        return true;
    }
    public override string GetCartData()
    {
        return _roomData.Name;
    }
    public override string GetCardTextData()
    {
        string text = $"на теле не било обноружено следов {_traceType}";
        return text;
    }
}
