using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelectionManager : MonoBehaviour
{
    public static RoomSelectionManager Instance;

    public ShadeBehavior currentShade;

    public void SetCurrentShade(ShadeBehavior shade)
    {
        currentShade = shade;
    }

    void Awake()
    {
        Instance = this;
    }

    public void OnRoomSelected(RoomProfile selectedRoom)
    {
        if (currentShade == null) return;

        bool isCorrect = selectedRoom == currentShade.desiredRoom;
        currentShade.ReactToGuess(isCorrect);

        if (isCorrect)
        {
            Debug.Log("Correct!");
            currentShade.SetExpression("happy");
            currentShade.StartFadeOut(); // triggers delay + respawn
        }
        else
        {
            Debug.Log("Incorrect!");
            currentShade.SetExpression("mad");
            currentShade.StartFadeOut(); // or just despawn immediately
        }
    }
}
