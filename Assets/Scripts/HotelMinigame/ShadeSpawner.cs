using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadeSpawner : MonoBehaviour
{
    public static ShadeSpawner Instance;

    [Header("References")]
    public GameObject shadePrefab;                      // Your Shade UI prefab
    public Transform spawnPoint;                        // Empty GameObject placed visually where you want the Shade to appear
    public Canvas worldCanvas;                          // The main Canvas
    public RoomProfile[] availableRoomProfiles;         // Assign all RoomProfiles here

    private GameObject currentShade;
    public Transform shadesLayer;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnShade();
    }

    public void SpawnShade()
    {
        // Destroy previous shade if needed
        if (currentShade != null)
            Destroy(currentShade);

        // Instantiate as child of the Canvas
        currentShade = Instantiate(shadePrefab, shadesLayer);

        // Position the Shade correctly within the Canvas
        RectTransform canvasRect = worldCanvas.GetComponent<RectTransform>();
        RectTransform shadeRect = currentShade.GetComponent<RectTransform>();

        if (canvasRect != null && shadeRect != null)
        {
            Vector2 screenPos = Camera.main.WorldToScreenPoint(spawnPoint.position);
            Vector2 localPos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, Camera.main, out localPos))
            {
                shadeRect.anchoredPosition = localPos;
            }
        }

        // Assign a random RoomProfile
        ShadeBehavior behavior = currentShade.GetComponent<ShadeBehavior>();
        if (behavior != null)
        {
            RoomProfile chosenRoom = availableRoomProfiles[Random.Range(0, availableRoomProfiles.Length)];
            behavior.desiredRoom = chosenRoom;

            // Set the Shade as the current one
            RoomSelectionManager.Instance.SetCurrentShade(behavior);
        }
    }

    public void SpawnShadeDelayed()
    {
        StartCoroutine(SpawnShadeAfterDelay());
    }

    IEnumerator SpawnShadeAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // delay between shades
        SpawnShade();
    }
}
