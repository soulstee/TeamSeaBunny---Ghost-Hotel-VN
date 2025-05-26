using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : MonoBehaviour
{
    public GameObject screenPanel; // The full UI panel with the room buttons

    public void OnClick()
    {
        Debug.Log("Computer clicked!");
        screenPanel.SetActive(true); // Bring up the selection screen
    }
}

