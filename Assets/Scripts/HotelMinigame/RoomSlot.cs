using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSlot : MonoBehaviour
{
    public RoomProfile profile;

    public bool CheckMatch(string requestedRoomType)
    {
        return requestedRoomType == profile.roomType;
    }
}