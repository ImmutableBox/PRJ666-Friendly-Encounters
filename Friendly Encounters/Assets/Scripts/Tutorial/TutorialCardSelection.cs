﻿using UnityEngine;

public class TutorialCardSelection : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject cardPanel;

    private GameObject[] cards;
    private int cardType = -1;
    private int playerIndex = -1;
    private bool cardHasBeenSelected = false;
    private bool canvasActive = false;

    void Awake()
    {
        cards = new GameObject[TutorialCardPanel.MAXCARDS];
        for (int i = 0; i < TutorialCardPanel.MAXCARDS; i++)
        {
            cards[i] = Instantiate(cardPrefab, cardPanel.transform);
        }
    }

    void Update()
    {
        for (int i = 0; i < TutorialCardPanel.MAXCARDS && !cardHasBeenSelected; i++)
        {
            if (cards[i].GetComponent<NetworkCard>().Selected)
            {
                cardHasBeenSelected = true;
                TurnCanvasOff(i);
            }
        }
    }

    public void StartCardSelection(int card, int player)
    {
        cardType = card;
        playerIndex = player;
        gameObject.SetActive(true);
    }

    public void TurnCanvasOff(int selectedCardIndex)
    {
        cardPanel.GetComponent<TutorialCardPanel>().DoAction(cardType, selectedCardIndex, playerIndex);
        gameObject.SetActive(false);
        cardHasBeenSelected = false;
    }

    public bool CanvasActive
    {
        get
        {
            return canvasActive;
        }
        set
        {
            canvasActive = value;
        }
    }
}