using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSelectionButton : MonoBehaviour
{
    public RoomProfile assignedRoomProfile;
    public GameObject screenPanel; // assign ComputerScreenUI manually in Inspector

    public void OnSelect()
    {
        RoomSelectionManager.Instance.OnRoomSelected(assignedRoomProfile);

        if (screenPanel != null)
        {
            screenPanel.SetActive(false); // Only turn off the correct UI panel
        }
        else
        {
            Debug.LogWarning("Screen Panel not assigned on RoomSelectionButton.");
        }
    }
}
