using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    BluntObjects,
    Firearms,
    ColdWeapon,
    Poison,
    StrangulationWeapons,
}
public enum TraceType
{
    SelfDefense,
    Defense,
    Bleeding,
    OilySubstance,
    FromBehind,
    Powder,
    Bruises,
    Burns,
    Dirt,
    Smell,
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "Data/WeaponData")]
public class WeaponData : ScriptableObject

{
    [SerializeField] private string _name;
    [SerializeField] private WeaponType _type = new();
    [SerializeField] private List<TraceType> _traces = new();

    public string Name => _name;
    public WeaponType Type => _type;
    public List<TraceType> Traits => _traces;
}
