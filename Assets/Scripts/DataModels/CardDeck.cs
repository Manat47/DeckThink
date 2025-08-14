using UnityEngine;

[CreateAssetMenu(fileName = "CardDeck", menuName = "DeckThink/CardDeck")]
public class CardDeck : ScriptableObject
{
    public CardData[] allCards;
}
