using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestAssigner : MonoBehaviour
{
    public GuestRequest currentGuest;

    public void AssignRoom(string selectedRoomType)
    {
        if (currentGuest == null) return;

        bool isMatch = selectedRoomType == currentGuest.requestedRoomType;
        currentGuest.React(isMatch);

        Destroy(currentGuest.gameObject, 2f);
        currentGuest = null;
    }
}
