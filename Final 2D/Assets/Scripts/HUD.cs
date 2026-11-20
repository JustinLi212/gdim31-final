using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Transform _checklistParent;
    [SerializeField] private ChecklistItemUI _checklistItemPrefab;
    // Add member variables for all of the Text you'll need to update.
    [SerializeField] private TextMeshProUGUI commonText;
    [SerializeField] private TextMeshProUGUI uncommonText;
    [SerializeField] private TextMeshProUGUI rareText;

    [SerializeField] private TextMeshProUGUI timerText;

    private List<ChecklistItemUI> _checklistItems;

    // ------------------------------------------------------------------------
    public void SetRequiredItems (List<GameObject> items)
    {
        // For every entry in 'items',
        //      create a new ChecklistItemUI GameObject.
        // Set its parent to _checklistParent.
        // Use the correct method in ChecklistItemUI to set up its required item.
        _checklistItems = new List<ChecklistItemUI>();
        foreach (var item in items)
        {
            var newItem = Instantiate(_checklistItemPrefab, _checklistParent);
            newItem.SetItem(item);
            _checklistItems.Add(newItem);
        }
    }

    // ------------------------------------------------------------------------
    public void KickedItem(GameObject item)
    {
        // Find the ChecklistItem in _checklistItems whose required item is the
        //      'item' input for this method.
        // Tell that item we found it!
        foreach (var listItem in _checklistItems)
        {
            if (listItem._requiredItem == item)
            {
                listItem.FoundItem();
            }
        }
    }

    // ------------------------------------------------------------------------
    public void UpdatePointsText(int commonPoints, int uncommonPoints, int rarePoints)
    {
        // Update all of the text.
        commonText.text = $"Common: {commonPoints}";
        uncommonText.text = $"Uncommon: {uncommonPoints}";
        rareText.text = $"Rare: {rarePoints}";
    }

    // ------------------------------------------------------------------------
    public void UpdateTimerText (float timeLeft)
    {
        // Update the timer text.
        timerText.text = $"{Mathf.FloorToInt(timeLeft):00}:{timeLeft * 100 % 100 :00}";
    }
}