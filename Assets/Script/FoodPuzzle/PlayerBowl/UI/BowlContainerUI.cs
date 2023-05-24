using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(BowlContainer))]
public class BowlContainerUI : MonoBehaviour
{
    private BowlContainer _bowlContainer;

    [SerializeField]
    private TMP_Text _containerSizeText;

    private void Awake()
    {
        TryGetComponent(out _bowlContainer);
    }

    private void OnEnable()
    {
        _bowlContainer.OnBowlContainerInit += UpdateBowlContainerSize;
        _bowlContainer.OnItemAdded += UpdateBowlContainerSize;
        _bowlContainer.OnClearedList += UpdateBowlContainerSize;
    }

    /// <summary>
    /// Updates the Container catched candies text of the BowlContainer.
    /// </summary>
    /// <param name="candy">Candy.</param>
    /// <param name="count">Count of the catched candies.</param>
    /// <param name="maxSize">Max size of candies container.</param>
    private void UpdateBowlContainerSize(Candy candy, int count, int maxSize)
    {
        UpdateBowlContainerSize(count, maxSize);
    }

    /// <summary>
    /// Updates the Container catched candies text of the BowlContainer.
    /// </summary>
    /// <param name="count">Count of the catched candies.</param>
    /// <param name="maxSize">Max size of candies container.</param>
    private void UpdateBowlContainerSize(int count, int maxSize)
    {
        _containerSizeText.text = $"{count} / {maxSize}";
    }
}
