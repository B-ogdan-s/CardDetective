using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private List<DifficultyLevelData> _difficultyLevels;
    [SerializeField] private TMP_Dropdown _levelDropdown;

    [SerializeField] private Button _button;
    [SerializeField] private ShowingGameData _showingGameData;

    private DifficultyLevelData _difficultyLevel;
    private CreatorOfInvestigation _creatorOfInvestigation = new();
    private CardDeckAssembler _cardAssembler = new();

    private void Awake()
    {
        _levelDropdown.onValueChanged.AddListener(ChangeLevel);
        _levelDropdown.ClearOptions();
        List<string> optionsList = new List<string>();
        foreach (var level in _difficultyLevels)
        {
            optionsList.Add(level.name);
        }
        _levelDropdown.AddOptions(optionsList);
        _levelDropdown.value = 0;
        ChangeLevel(0);

        _button.onClick.AddListener(Click);
    }

    private void ChangeLevel(int value)
    {
        _difficultyLevel = _difficultyLevels[value];
    }

    public void Click()
    {
        InvestigationData data = _creatorOfInvestigation.CreateInvestigation(_difficultyLevel);
        List<CardData> cards = _cardAssembler.FilterDeck(data);
        List<CardData> gameCards = _cardAssembler.CollectDeck(cards, _difficultyLevel, data);

        _showingGameData.UpdateData(data);
        _showingGameData.UpdateCardCount(gameCards.Count);
        _showingGameData.SpawnCards(gameCards);
    }


}
