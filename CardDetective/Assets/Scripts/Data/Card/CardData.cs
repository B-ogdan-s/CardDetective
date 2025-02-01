using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : ScriptableObject
{
    [SerializeField] private uint _id;
    [SerializeField] private byte _price;
    //[SerializeField] private string _text;

    public uint Id => _id;
    public byte Price => _price;

    public virtual bool FilterCard(InvestigationData data) { return true; }
    public virtual string GetCardTextData() { return ""; }
    public virtual string GetCartData() { return ""; }

}
