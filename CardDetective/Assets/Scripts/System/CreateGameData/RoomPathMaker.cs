using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPathMaker
{
    private const string _roomPath = "Data/Room";
    private bool _isUsedAccomplices;
    private Dictionary<RoomData, List<SuspectData>> _initialRoomAssignments;

    public RoomPathMaker(bool isUsedAccomplices, Dictionary<RoomData, List<SuspectData>> initialRoomAssignments)
    {
        _isUsedAccomplices = isUsedAccomplices;
        _initialRoomAssignments = initialRoomAssignments;
    }

    public List<RoomData> GetRoomPath(byte count)
    {
        List<RoomData> rooms = new List<RoomData>();
        List<RoomData> startedRooms = GetStartedRooms();

        if(_isUsedAccomplices)
        {
            List<RoomData> ro = new();
            foreach (RoomData r in startedRooms)
            {
                if (_initialRoomAssignments[r].Count < count)
                    ro.Add(r);    
            }
            foreach (RoomData r in ro)
            {
                startedRooms.Remove(r);
            }

        }

        RoomData startRoom = startedRooms[Random.Range(0, startedRooms.Count)];

        rooms.Add(startRoom);

        while (true)
        {
            RoomData nextRoom = DetermineNextRoom(rooms);

            if (nextRoom == null)
                break;

            rooms.Add(nextRoom);
        }

        return rooms;
    }

    private RoomData DetermineNextRoom(List<RoomData> usedRooms)
    {
        List<RoomData> nextRooms = usedRooms[usedRooms.Count - 1].Rooms;

        if (nextRooms.Count == 0)
            return null;

        RoomData room;

        int i = 0;

        do
        {
            room = nextRooms[Random.Range(0, nextRooms.Count)];

            i++;
            if (i > 50)
            {
                //Debug.LogError("Do-While Error");
                return null;
            }

        } while (ChectRommsUseds(room, usedRooms));


        return room;
    }

    private List<RoomData> GetStartedRooms()
    {
        List<RoomData> startedRooms = new();
        foreach (RoomData room in Resources.LoadAll<RoomData>(_roomPath))
        {
            if (room.IsStartedRoom)
                startedRooms.Add(room);
        }
        return startedRooms;
    }

    private bool ChectRommsUseds(RoomData room, List<RoomData> usedRooms)
    {
        if (room.Rooms.Count == 0)
            return false;

        bool value = true;

        foreach (RoomData roomData in room.Rooms)
        {
            if (!usedRooms.Contains(roomData))
            {
                value = false;
            }
        }

        if (usedRooms.Contains(room))
            value = true;

        return value;
    }
}
