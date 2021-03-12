using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantInfoCardHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText = null;
    [SerializeField] private TMP_Text contentText = null;

    public void SetText(string title, string content)
    {
        titleText.text = title;
        contentText.text = content;
    }
}
