using UnityEngine;

#if UNITY_EDITOR
[ExecuteAlways]
public class DataValidator : MonoBehaviour
{
    public PromptBank promptBank;
    public CardDeck cardDeck;

    void OnEnable() { Validate(); }
    void OnValidate() { Validate(); }

    void Validate()
    {
        if (promptBank != null)
        {
            foreach (var p in promptBank.allPrompts)
            {
                if (p == null) continue;
                if (string.IsNullOrWhiteSpace(p.promptText))
                    Debug.LogWarning($"[Prompt Warning] promptText ว่าง: {p.name}");
                if (p.keywords == null || p.keywords.Length == 0)
                    Debug.LogWarning($"[Prompt Warning] keywords ว่าง: {p.name}");
            }
        }
        if (cardDeck != null)
        {
            foreach (var c in cardDeck.allCards)
            {
                if (c == null) continue;
                if (string.IsNullOrWhiteSpace(c.cardName))
                    Debug.LogWarning($"[Card Warning] cardName ว่าง: {c.name}");
                if (c.keywords == null || c.keywords.Length == 0)
                    Debug.LogWarning($"[Card Warning] keywords ว่าง: {c.name}");
            }
        }
    }
}
#endif
