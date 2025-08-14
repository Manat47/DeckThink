using UnityEngine;

[CreateAssetMenu(fileName = "PromptData", menuName = "DeckThink/Prompt")]
public class PromptData : ScriptableObject
{
    [TextArea(2, 5)] public string promptText;  // ข้อความโจทย์
    public string[] keywords;                   // คีย์เวิร์ดที่เกี่ยวข้อง
    [Range(1, 5)] public int difficulty = 1;    // ใช้คูณ/บวกคะแนนเล็กน้อยได้ภายหลัง
}
