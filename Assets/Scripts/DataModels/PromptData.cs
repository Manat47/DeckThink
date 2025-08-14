using UnityEngine;

[CreateAssetMenu(fileName = "PromptData", menuName = "DeckThink/Prompt")]
public class PromptData : ScriptableObject
{
    [TextArea(2, 5)] public string promptText;  // ��ͤ���⨷��
    public string[] keywords;                   // ��������촷������Ǣ�ͧ
    [Range(1, 5)] public int difficulty = 1;    // ��ٳ/�ǡ��ṹ��硹����������ѧ
}
