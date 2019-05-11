using UnityEngine;
using UnityEngine.UI;

public class MessageList : MonoBehaviour 
{
    [SerializeField] private VerticalLayoutGroup layout;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private GameObject messagePrefab;

    const float SIZE_PER_LINE = 22f;
    const float PADDING_PER_LINE = 1f;

    private float verticalHeight = 0.0f;

    public void AddMessage(string message)
    {
        GameObject newMessage = Instantiate(messagePrefab, transform);
        Text messageText = newMessage.GetComponent<Text>();
        if (messageText == null)
        {
            Debug.LogError("[F" + Time.frameCount + "]: Message prefab does not have a Text component!");
            Destroy(newMessage);
            return;
        }
        messageText.text = message;
        // Get fresh text line information
        Canvas.ForceUpdateCanvases();

        // Fit text to content since VLGs don't cooperate with Content Fitters
        int lines = messageText.cachedTextGenerator.lineCount;
        float newTextHeight = lines * SIZE_PER_LINE + (lines - 1) * PADDING_PER_LINE;
        RectTransform textRect = newMessage.transform as RectTransform;
        textRect.sizeDelta = new Vector2(textRect.sizeDelta.x, newTextHeight);

        // Expand list to accomodate new message
        RectTransform listRect = transform as RectTransform;
        listRect.sizeDelta = new Vector2(listRect.sizeDelta.x, listRect.sizeDelta.y + newTextHeight + layout.spacing);

        scrollbar.value = 1f;
    }

	private void OnEnable()
	{
		if (layout == null ||
            scrollbar == null ||
            messagePrefab == null)
        {
            Debug.LogError("[F" + Time.frameCount + "]: Something isn't hooked up to MessageList properly. Disabling.");
            gameObject.SetActive(false);
        }
	}
}
