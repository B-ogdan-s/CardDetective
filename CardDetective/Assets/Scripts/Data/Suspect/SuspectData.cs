using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SuspectData", menuName = "Data/SuspectData")]
public class SuspectData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private List<MotiveData> _motives;

    public string Name => _name;
    public List<MotiveData> Motives => _motives;
}