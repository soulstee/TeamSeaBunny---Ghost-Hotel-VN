using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadeBehavior : MonoBehaviour
{
    public RoomProfile desiredRoom;

    [Header("Dialogue")]
    public string clueIntroLine = "I'm looking for a room with ";
    public GameObject dialogueBubblePrefab;
    public Transform dialogueSpawnPoint;

    [Header("Expressions")]
    public Sprite neutralSprite;
    public Sprite happySprite;
    public Sprite madSprite;

    private Image image;
    private GameObject currentBubble;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Start()
    {
        Debug.Log("Assigned Room: " + (desiredRoom != null ? desiredRoom.name : "None"));

        SetExpression("neutral");

        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.SetTrigger("TriggerFadeIn");
        }

        StartCoroutine(ShowClueDialogue());
    }

    IEnumerator ShowClueDialogue()
    {
        yield return new WaitForSeconds(3f); // wait for FadeIn

        currentBubble = Instantiate(dialogueBubblePrefab, dialogueSpawnPoint.position, Quaternion.identity, transform);
        CanvasGroup cg = currentBubble.GetComponent<CanvasGroup>();
        Text text = currentBubble.GetComponentInChildren<Text>();

        if (cg != null && text != null)
        {
            cg.alpha = 0f;
            float t = 0f;
            float fadeDuration = 1f;

            while (t < fadeDuration)
            {
                cg.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
                t += Time.deltaTime;
                yield return null;
            }

            cg.alpha = 1f;
            text.text = GenerateRoomHint();
        }
    }

    public void ReactToGuess(bool isCorrect)
    {
        // 💥 Remove existing clue bubble
        if (currentBubble != null)
        {
            Destroy(currentBubble);
            currentBubble = null;
        }

        SetExpression(isCorrect ? "happy" : "mad");

        StartFadeOut(); // or call a reaction method if needed
    }


    public void StartFadeOut()
    {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.SetTrigger("TriggerFadeOut");
            StartCoroutine(FinishFadeOut());
        }
    }

    IEnumerator FinishFadeOut()
    {
        yield return new WaitForSeconds(1.5f); // match FadeOut animation
        ShadeSpawner.Instance.SpawnShadeDelayed();
        Destroy(gameObject);
    }

    public void SetExpression(string mood)
    {
        switch (mood)
        {
            case "happy":
                image.sprite = happySprite;
                break;
            case "mad":
                image.sprite = madSprite;
                break;
            default:
                image.sprite = neutralSprite;
                break;
        }
    }

    public string GenerateRoomHint()
    {
        List<string> clues = new List<string>();
        clues.Add($"a {desiredRoom.bedType} bed");

        if (Random.value > 0.5f) clues.Add($"an item like {desiredRoom.keyItemA}");
        if (Random.value > 0.5f) clues.Add($"something with {desiredRoom.keyItemB}");

        return clueIntroLine + string.Join(" and ", clues) + ".";
    }
}
