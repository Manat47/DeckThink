using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "DeckThink/Card")]
public class CardData : ScriptableObject
{
    public string cardName;       // ���͡���
    public int baseScore = 1;     // ��ṹ��鹰ҹ
    public string[] keywords;     // ��������촢ͧ����
}
