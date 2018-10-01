﻿using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class JoinButton : MonoBehaviour {

    private Text buttonText;
    private MatchInfoSnapshot match;

    private void Awake() {
        buttonText = GetComponentInChildren<Text>();
        GetComponent<Button>().onClick.AddListener(JoinMatch);
    }

    public void Initialize(MatchInfoSnapshot match, Transform panelTransform) {
        this.match = match;
        buttonText.text = match.name;
        transform.SetParent(panelTransform);
        transform.localScale = Vector2.one;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector2.zero;
    }

    private void JoinMatch() {
        FindObjectOfType<MyNetworkManager>().JoinMatch(match);
    }
}
