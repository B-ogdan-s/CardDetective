using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SuspectConfirmationMotive", menuName = "Data/Card/SuspectConfirmationMotive")]
public class SuspectConfirmationMotive : CardData
{
    [SerializeField] private SuspectData _suspect1;
    [SerializeField] private SuspectData _suspect2;
    [SerializeField, Range(0, 2)] private byte _motiveID;

    public override string GetCartData()
    {
        return $"{_suspect2.Name}\n{_suspect1.Name}";
    }

    public override string GetCardTextData()
    {
        string text = $"{_suspect2.Name} каже що у {_suspect1.Name} був мотив: {_suspect1.Motives[_motiveID].Name}";
        return text ;
    }

}
