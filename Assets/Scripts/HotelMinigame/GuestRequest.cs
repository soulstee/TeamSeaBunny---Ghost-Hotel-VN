using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestRequest : MonoBehaviour
{
    public string requestedRoomType;

    [Header("UI References")]
    public Image portraitImage;
    public GameObject reactionIcon;
    public Sprite happySprite;
    public Sprite madSprite;

    [Header("Animation")]
    public Animator animator;

    [Header("Dialogue Box")]
    public GameObject dialogueBox;
    public Text dialogueText;
    public CanvasGroup dialogueCanvas;
    public string happyResponse = "This is perfect!";
    public string madResponse = "This isn’t what I expected...";


    public void Init(string roomType)
    {
        Debug.Log("[GUEST REQUEST] Init called for: " + roomType);
        requestedRoomType = roomType;

        if (animator != null)
            animator.SetTrigger("TriggerFadeIn");
        else
            Debug.LogWarning("[GUEST REQUEST] Animator is not assigned!");

        StartCoroutine(ShowRequestDialogueWithDelay());
    }


    IEnumerator ShowRequestDialogueWithDelay()
    {
        yield return new WaitForSeconds(5f); // Wait for FadeIn animation
        dialogueText.text = GenerateDialogue(requestedRoomType);
        dialogueBox.SetActive(true);
        yield return StartCoroutine(FadeCanvasGroup(dialogueCanvas, 0f, 1f, 0.5f));
    }

    string GenerateDialogue(string roomType)
    {
        switch (roomType)
        {
            case "Elegant Shades": return "I'd like a room with a touch of elegance...";
            case "Captain’s Cabin": return "Got a cabin fit for a captain?";
            case "Nature Preserve": return "Something with fresh air and plants, please.";
            default: return "Got a room that fits my… vibe?";
        }
    }

    public void React(bool isHappy)
    {
        if (reactionIcon != null)
        {
            Image iconImage = reactionIcon.GetComponent<Image>();
            if (iconImage != null)
            {
                iconImage.sprite = isHappy ? happySprite : madSprite;
                reactionIcon.SetActive(true);
                Invoke(nameof(HideReaction), 1.5f);
            }
        }

        if (animator != null)
        {
            animator.SetTrigger("TriggerFadeOut");
            Destroy(gameObject, 1.5f); // Or return to object pool
        }
    }

    void HideReaction()
    {
        if (reactionIcon != null)
            reactionIcon.SetActive(false);
    }

    IEnumerator FadeCanvasGroup(CanvasGroup canvas, float from, float to, float duration)
    {
        float elapsed = 0f;
        canvas.alpha = from;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }
        canvas.alpha = to;
    }
}
