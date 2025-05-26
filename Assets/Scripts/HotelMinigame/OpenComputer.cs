using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject uiScreen; // Reference to the UI canvas for room selection

    void OnMouseDown()
    {
        uiScreen.SetActive(true);
        // Optional: Pause time or disable other inputs
    }
}
