using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckAssembler
{
    private const string _cardPath = "Data/Card";

    public List<CardData> FilterDeck(InvestigationData data)
    {
        List<CardData> cards = new();

        CardData[] cardsData = Resources.LoadAll<CardData>(_cardPath);

        foreach (CardData card in cardsData)
        {
            if(card.FilterCard(data))
                cards.Add(card);
        }
        return cards;
    }

    public List<CardData> CollectDeck(List<CardData> fullCards, DifficultyLevelData levelData, InvestigationData data)
    {
        Dictionary<Type, List<CardData>> cardType = new();

        List<CardData> cards = new();

        foreach (CardData card in fullCards)
        {
            if (!cardType.ContainsKey(card.GetType()))
            {
                cardType.Add(card.GetType(), new());
            }
            cardType[card.GetType()].Add(card);
        }
        return CheckUsedCard(cardType, levelData, data);
    }

    private List<CardData> CheckUsedCard(Dictionary<Type, List<CardData>> cardType, DifficultyLevelData levelData, InvestigationData data)
    {
        List<CardData> cards = new();
        Dictionary<Type, List<CardData>> addCardType = new();

        foreach (var type in cardType)
        {
            switch (type.Key)
            {
                case Type t when t == typeof(BlockPeople):
                    cards.AddRange(SetRandomCard(type.Value, 3));
                    break;
                case Type t when t == typeof(PossibleLocationPeople):
                    cards.AddRange(SetRandomCard(type.Value, 3));
                    break;
                case Type t when t == typeof(ConfirmationMotive):
                    cards.AddRange(SetRandomCard(type.Value, 3));
                    break;
                case Type t when t == typeof(BlockTransition):
                    addCardType.Add(type.Key, type.Value);
                    break;
                case Type t when t == typeof(MotiveBlock):
                    addCardType.Add(type.Key, type.Value);
                    break;
                case Type t when t == typeof(SuspectConfirmationMotive):
                    addCardType.Add(type.Key, type.Value);
                    break;
                case Type t when t == typeof(WeaponBlock):
                    addCardType.Add(type.Key, type.Value);
                    break;
                case Type t when t == typeof(WasWithSomeone):
                    foreach (var card in type.Value)
                    {
                        if(!((WasWithSomeone)card).IsAlone(data.Suspect) || levelData.IsSuspectAloneInRoom)
                        {
                            cards.Add(card);
                        }
                    }
                    break;
                default:
                    cards.AddRange(type.Value);
                    break;
            }
        }

        byte addCardCount = (byte)((70 - cards.Count) / 4);

        foreach(var type in addCardType)
        {
            cards.AddRange(SetRandomCard(type.Value, addCardCount));
        }

        addCardCount = (byte)(70 - cards.Count);
        for(byte i = 0; i < addCardCount; i++)
        {
            CardData card;
            do
            {
                card = addCardType[typeof(WeaponBlock)][UnityEngine.Random.Range(0, addCardType[typeof(WeaponBlock)].Count)]; //cardDatas[UnityEngine.Random.Range(0, cardDatas.Count)];
            } while (cards.Contains(card));
            cards.Add(card);
        }

        return cards;
    }

    private List<CardData> SetRandomCard(List<CardData> cardDatas, byte count)
    {
        List<CardData> cards = new();

        for(byte i = 0; i < count; i++)
        {
            CardData card;
            do
            {
                card = cardDatas[UnityEngine.Random.Range(0, cardDatas.Count)];
            } while (cards.Contains(card));
            cards.Add(card);
        }
        return cards;
    }
}
