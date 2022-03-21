using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;

    [Header("Knife Count Display")]
    [SerializeField]
    private GameObject panelKnives;
    [SerializeField]
    private GameObject iconKnive;
    [SerializeField]
    private Color usedKniveIconColor;

    public void ShowRestartButton(int count)
    {
        restartButton.SetActive(true);
    }

    public void SetInitialDisplayedKnifeCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(iconKnive, panelKnives.transform);

    }
    private int knifeIconIndexToChange = 0;
    public void DecrementDisplayedKnifeCount()
    {
        panelKnives.transform.GetChild(knifeIconIndexToChange++)
            .GetComponent<Image>().color = usedKniveIconColor;
    }

    internal void ShowRestartButton()
    {
        throw new NotImplementedException();
    }
}
