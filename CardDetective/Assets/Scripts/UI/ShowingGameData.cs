using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowingGameData : MonoBehaviour
{
    [SerializeField] private string _cardCountText;
    [SerializeField] private TextMeshProUGUI _cardCountTMP;
    [SerializeField] private string _roomPathText;
    [SerializeField] private TextMeshProUGUI _roomPathTMP;
    [SerializeField] private string _weaponText;
    [SerializeField] private TextMeshProUGUI _weaponTMP;
    [SerializeField] private string _suspectText;
    [SerializeField] private TextMeshProUGUI _suspectTMP;
    [SerializeField] private string _motiveText;
    [SerializeField] private TextMeshProUGUI _motiveTMP;
    [SerializeField] private string _accompliceText;
    [SerializeField] private TextMeshProUGUI _accompliceTMP;
    [SerializeField] private string _motiveAccompliceText;
    [SerializeField] private TextMeshProUGUI _motiveAccompliceTMP;

    [SerializeField] private Transform _cardParent;
    [SerializeField] private ShowCard _cardPrefab;

    private List<ShowCard> _cards = new();

    public void UpdateData(InvestigationData data)
    {
        _roomPathTMP.text = $"{_roomPathText}: {PrintRoomsPath(data.Path)}";
        _weaponTMP.text = $"{_weaponText}: {data.Weapon.Name}";
        _suspectTMP.text = $"{_suspectText}: {data.Suspect.Name}";
        _motiveTMP.text = $"{_motiveText}: {data.Motive.Name}";
        if(data.IsUSedAccomplice)
        {
            _accompliceTMP.text = $"{_accompliceText}: {data.AccompliceSuspect.Name}";
            _motiveAccompliceTMP.text = $"{_motiveAccompliceText}: {data.AccompliceMotive.Name}";
        }
        else
        {
            _accompliceTMP.text = $"{_accompliceText}: -";
            _motiveAccompliceTMP.text = $"{_motiveAccompliceText}: -";
        }
    }

    internal void UpdateCardCount(int count)
    {
        _cardCountTMP.text = $"{_cardCountText}: {count}";
    }

    private string PrintRoomsPath(List<RoomData> rooms)
    {
        string path = rooms[0].Name;

        for (int i = 1; i < rooms.Count; i++)
        {
            path += "-";
            path += rooms[i].Name;
        }

        return path;
    }

    public void SpawnCards(List<CardData> datas)
    {
        foreach(var card in _cards)
        {
            Destroy(card.gameObject);
        }
        _cards.Clear();

        foreach(var card in datas)
        {
            ShowCard newCard = Instantiate(_cardPrefab, _cardParent);
            newCard.SetData(card);
            _cards.Add(newCard);
        }
    }
}
