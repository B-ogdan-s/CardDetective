using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DifficultyLevelData", menuName = "Data/DifficultyLevelData")]
public class DifficultyLevelData : ScriptableObject
{
    [SerializeField] private byte _minPathCount;
    [SerializeField] private byte _maxPathCount;

    [SerializeField] private byte _minSuspectCoundInRoom;
    [SerializeField] private bool _isUsedAccomplices;
    [SerializeField] private bool _isSuspectAloneInRoom;

    [SerializeField] private CardCountInfo _cardCount;
    [SerializeField] private CardCountInfo _cardCountWithAccomplice;


    public byte MinPathCount => _minPathCount;
    public byte MaxPathCount => _maxPathCount;
    public byte MinSuspectCountInRoom => _minSuspectCoundInRoom;
    public bool IsUsedAccomplices => _isUsedAccomplices;
    public bool IsSuspectAloneInRoom => _isSuspectAloneInRoom;

    public CardCountInfo SetCardCount(bool isAccomp)
    {
        if(isAccomp)
            return _cardCountWithAccomplice;
        
        return _cardCount;
    }
}

[Serializable]
public class CardCountInfo
{
    [SerializeField] private byte _blockTransitionCount;
    [SerializeField] private byte _confirmationMotiveCount;
    [SerializeField] private byte _motiveBlockCount;
    [SerializeField] private byte _suspectConfirmationMotiveCount;
    [SerializeField] private byte _weaponBlockCount;

    public byte BlockTransitionCount => _blockTransitionCount;
    public byte ConfirmationMotiveCount => _confirmationMotiveCount;
    public byte MotiveBlockCount => _motiveBlockCount;
    public byte SuspectConfirmationMotiveCount => _suspectConfirmationMotiveCount;
    public byte WeaponBlockCount => _weaponBlockCount;
}