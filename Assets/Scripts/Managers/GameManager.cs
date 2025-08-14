using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Data")]
    public PromptBank promptBank;
    public CardDeck cardDeck;

    [Header("Config")]
    [Range(3, 5)] public int cardsPerRound = 4;
    [Range(1, 2)] public int maxCardsSelect = 2;
    [Range(1, 10)] public int totalRounds = 5;

    private int totalScore = 0;
    private PromptData currentPrompt;
    private List<CardData> hand = new List<CardData>();

    void Start()
    {
        totalScore = 0;

        for (int i = 0; i < totalRounds; i++)
        {
            currentPrompt = RandomPrompt();
            hand = DrawHand(cardsPerRound);

            var picked = AutoPick(hand, maxCardsSelect); // เดี๋ยวมี UI ค่อยแทนที่
            int gained = CalculateScore(currentPrompt, picked);
            totalScore += gained;

            Debug.Log($"Round {i + 1} | Prompt: {currentPrompt.promptText}");
            Debug.Log($"Picked: {string.Join(", ", picked.Select(c => c.cardName))} -> +{gained}");
        }

        Debug.Log($"TOTAL SCORE = {totalScore}");
    }

    PromptData RandomPrompt()
    {
        var list = promptBank?.allPrompts;
        if (list == null || list.Length == 0) { Debug.LogError("PromptBank is empty"); return null; }
        return list[Random.Range(0, list.Length)];
    }

    List<CardData> DrawHand(int count)
    {
        var list = cardDeck?.allCards;
        if (list == null || list.Length == 0) { Debug.LogError("CardDeck is empty"); return new List<CardData>(); }
        return list.OrderBy(_ => Random.value).Take(count).ToList(); // สุ่มไม่ซ้ำง่าย ๆ
    }

    List<CardData> AutoPick(List<CardData> src, int n)
    {
        return src.OrderBy(_ => Random.value).Take(n).ToList();
    }

    public int CalculateScore(PromptData prompt, List<CardData> picked)
    {
        if (prompt == null || picked == null || picked.Count == 0) return 0;

        int baseScore = picked.Sum(c => c.baseScore);

        // จับคู่คีย์เวิร์ด (ปรับรูปแบบตัวอักษรให้เท่ากัน)
        var pSet = new HashSet<string>(prompt.keywords.Select(k => k.Trim().ToLower()));
        int matchCount = picked.Sum(c => c.keywords.Select(k => k.Trim().ToLower()).Count(k => pSet.Contains(k)));

        int perMatchBonus = 2;      // โบนัสต่อการแมตช์ 1 คำ
        int keywordBonus = matchCount * perMatchBonus;

        int randomBonus = Random.Range(0, 3);  // 0..2
        int diffBoost = prompt.difficulty - 1; // 0..4

        int total = baseScore + keywordBonus + randomBonus + diffBoost;
        return Mathf.Max(0, total);
    }
}
