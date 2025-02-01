using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MotiveBlock", menuName = "Data/Card/MotiveBlock")]
public class MotiveBlock : CardData
{
    [SerializeField] private SuspectData _spectator;
    [SerializeField] private MotiveData _motive;

    public override bool FilterCard(InvestigationData data)
    {
        if (data.Motive == _motive)
            return false;

        return true;
    }

    public override string GetCartData()
    {
        return _spectator.Name;
    }

    public override string GetCardTextData()
    {
        string text = $"мотив {_spectator.Name}, \"{_motive.Name}\" не €вл€этьс€ мотивом убийства";
        return text;
    }
}
