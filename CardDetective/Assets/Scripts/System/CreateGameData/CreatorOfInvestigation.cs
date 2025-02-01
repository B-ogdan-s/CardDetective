using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class CreatorOfInvestigation
{
    public InvestigationData CreateInvestigation(DifficultyLevelData difficultyLevelData)
    {
        InvestigationData data = new();
        data.Suspect = SuspectMaker.GetSuspect();
        data.Motive = SuspectMaker.GetMotive(data.Suspect);
        data.InitialRoomAssignments = SuspectMaker.InitializeRoomAssignments(data.Suspect);

        List<RoomData> roomData;
        do
        {
            RoomPathMaker roomPathMaker = new RoomPathMaker(difficultyLevelData.IsUsedAccomplices, data.InitialRoomAssignments);
            roomData = roomPathMaker.GetRoomPath(difficultyLevelData.MinSuspectCountInRoom);
        } while (roomData.Count < difficultyLevelData.MinPathCount 
            || roomData.Count > difficultyLevelData.MaxPathCount);

        data.Path = roomData;
        data.Weapon = WeaponMaker.GetWeapon(roomData);

        if (difficultyLevelData.IsUsedAccomplices)
        {
            data.IsUSedAccomplice = SuspectMaker.GetUsedAccomplice(data);
            if (data.IsUSedAccomplice)
            {
                data.AccompliceSuspect = SuspectMaker.GetAccompliceSuspect(data.InitialRoomAssignments[data.Path[0]]);
                data.AccompliceMotive = SuspectMaker.GetAccompliceMotive(data.AccompliceSuspect);
            }
        }
        return data;
    }

}