using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.AmountChanged += DisplayAmount;
    }

    private void OnDisable()
    {
        _counter.AmountChanged -= DisplayAmount;
    }

    private void DisplayAmount()
    {
        float amount = _counter.CountAmount;

        _text.text = amount.ToString();
    }

}
