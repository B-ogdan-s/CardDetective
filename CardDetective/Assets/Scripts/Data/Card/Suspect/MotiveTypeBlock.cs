using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MotiveTypeBlock", menuName = "Data/Card/MotiveTypeBlock")]
public class MotiveTypeBlock : CardData
{
    [SerializeField] private MotiveType _type;
    [SerializeField] private List<SuspectData> _suspects;

    public override bool FilterCard(InvestigationData data)
    {
        if (data.Motive.Type == _type)
            return false;

        if(data.IsUSedAccomplice)
            if(data.AccompliceMotive.Type == _type)
                return false;

        return true;
    }

    public override string GetCartData()
    {
        string text = "";

        foreach(var s in _suspects)
        {
            text += $"{s.Name}\n";
        }

        return text;
    }

    public override string GetCardTextData()
    {
        string text = $"тип мотива не {_type.ToString()}";
        return text;
    }
}
