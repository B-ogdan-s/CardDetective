using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Accomplice", menuName = "Data/Card/Accomplice")]
public class Accomplice : CardData
{
    [SerializeField] private SuspectData _suspect;

    public override bool FilterCard(InvestigationData data)
    {
        if (!data.IsUSedAccomplice)
            return false;

        if(_suspect == data.Suspect || _suspect == data.AccompliceSuspect)
            return true;

        return false;
    }
    public override string GetCartData()
    {
        return _suspect.Name;
    }
    public override string GetCardTextData()
    {
        string text = $"{_suspect.Name} плели заговор";
        return base.GetCardTextData();
    }
}
