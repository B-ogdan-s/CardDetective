using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationData
{
    public List<RoomData> Path;

    public Dictionary<RoomData, List<SuspectData>> InitialRoomAssignments = new();

    public WeaponData Weapon;
    public SuspectData Suspect;
    public MotiveData Motive;

    public bool IsUSedAccomplice;

    public SuspectData AccompliceSuspect;
    public MotiveData AccompliceMotive;
}
