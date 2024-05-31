using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countInterval = 0.5f;
    [SerializeField] private int _addedAmount = 1;

    private int _countAmount;
    private bool _isActive;
    private IEnumerator _coroutine;

    public int CountAmount => _countAmount;

    public event Action AmountChanged;

    private void Start()
    {
        _isActive = false;
        _coroutine = AddAmountOverTime();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(_isActive == false)
            {
                _isActive = true;
                StartCoroutine(_coroutine);
            }
            else
            {
                _isActive = false;
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator AddAmountOverTime()
    {
        while(_isActive == true)
        {
            var wait = new WaitForSeconds(_countInterval);

            AddAmount();

            yield return wait;
        }
    }

    private void AddAmount()
    {
        _countAmount += _addedAmount;
        AmountChanged?.Invoke();
    }
}