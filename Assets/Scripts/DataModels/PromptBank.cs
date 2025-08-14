using UnityEngine;

[CreateAssetMenu(fileName = "PromptBank", menuName = "DeckThink/PromptBank")]
public class PromptBank : ScriptableObject
{
    public PromptData[] allPrompts;
}
