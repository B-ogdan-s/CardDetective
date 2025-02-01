using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotiveType
{
    BloodFeud,
    Finance,
    Passion,
    Blackmail,
    Resentment,
    Revenge,
}


[CreateAssetMenu(fileName = "MotiveData", menuName = "Data/MotiveData")]
public class MotiveData : ScriptableObject
{
    [SerializeField] private string _name; 
    [SerializeField] private MotiveType _type;

    public string Name => _name;
    public MotiveType Type => _type;
}
