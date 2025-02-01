using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WasWithSomeone", menuName = "Data/Card/WasWithSomeone")]
public class WasWithSomeone : CardData
{
    [SerializeField] private SuspectData _suspect1;
    [SerializeField] private SuspectData _suspect2;

    public override bool FilterCard(InvestigationData data)
    {
        if (data.Suspect == _suspect1)
        {
            if (_suspect1 == _suspect2)
                return true;

            List<SuspectData> list = data.InitialRoomAssignments[data.Path[0]];

            foreach (SuspectData s in list)
            {
                if (s == _suspect2)
                    return true;
            }
            return false;
        }

        foreach(var info in data.InitialRoomAssignments)
        {
            if(info.Value.Count == 0)
                continue;

            if (_suspect1 == _suspect2)
            {
                if (info.Value.Count == 1)
                {
                    if (info.Value[0] == _suspect1)
                        return true;
                }
                continue;
            }

            foreach (var s1 in info.Value)
            {
                foreach (var s2 in info.Value)
                {
                    if(s1 == _suspect1 && s2 == _suspect2)
                        return true;
                }
            }
        }

        return false;
    }

    public bool IsAlone(SuspectData data)
    {
        return (_suspect1 == _suspect2 && _suspect1 == data);
    }

    public override string GetCartData()
    {
        if (_suspect1 == _suspect2)
            return _suspect1.Name;

        return $"{_suspect1.Name}\n{_suspect2.Name}";
    }
    public override string GetCardTextData()
    {
        if (_suspect1 == _suspect2)
            return $"{_suspect1.Name} бил один во время убийства";

        return $"{_suspect1.Name} утверждаэ что бил вместе с {_suspect2.Name}";
    }
}
