using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "DeckThink/Card")]
public class CardData : ScriptableObject
{
    public string cardName;       // ชื่อการ์ด
    public int baseScore = 1;     // คะแนนพื้นฐาน
    public string[] keywords;     // คีย์เวิร์ดของการ์ด
}
