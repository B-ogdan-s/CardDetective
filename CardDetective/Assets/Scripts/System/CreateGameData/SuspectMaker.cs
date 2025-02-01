using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SuspectMaker
{
    private const string _suspectPath = "Data/Suspect";
    private const string _roomPath = "Data/Room";

    public static SuspectData GetSuspect()
    {
        SuspectData[] suspects = Resources.LoadAll<SuspectData>(_suspectPath);

        return suspects[Random.Range(0, suspects.Length)];
    }
    public static MotiveData GetMotive(SuspectData suspect)
    {
        List<MotiveData> motives = suspect.Motives;

        return motives[Random.Range(0, motives.Count)];
    }
    public static Dictionary<RoomData, List<SuspectData>> InitializeRoomAssignments(SuspectData suspectData)
    {
        Dictionary<int, RoomData> roomId = new();
        Dictionary<RoomData, List<SuspectData>> data = new();

        RoomData[] rooms = Resources.LoadAll<RoomData>(_roomPath);
        SuspectData[] suspects = Resources.LoadAll<SuspectData>(_suspectPath);

        int id = 0;
        foreach (RoomData room in rooms)
        {
            if(room.IsStartedRoom)
            {
                roomId.Add(id, room);
                data.Add(room, new List<SuspectData>());
                id++;
            }
        }

        foreach(SuspectData suspect in suspects)
        {
            if (suspect == suspectData)
                continue;

            int random;
            do
            {
                random = Random.Range(0, data.Count);
            } while (data[roomId[random]].Count > 4);

            data[roomId[random]].Add(suspect);

        }
        return data;
    }

    public static bool GetUsedAccomplice(InvestigationData data)
    {
        if (data.InitialRoomAssignments[data.Path[0]].Count != 0)
        {
            if (Random.Range(0, 2) == 1)
                return true;
        }
        return false;
    }

    public static SuspectData GetAccompliceSuspect(List<SuspectData> suspectDatas)
    {
        SuspectData data = suspectDatas[Random.Range(0, suspectDatas.Count)];
        return data;
    }

    public static MotiveData GetAccompliceMotive(SuspectData accompliceSuspect)
    {
        return accompliceSuspect.Motives[Random.Range(0, accompliceSuspect.Motives.Count)];
    }
}
