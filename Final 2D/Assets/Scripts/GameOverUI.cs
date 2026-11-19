using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    // Add member variables to store references to the Text Components for the
    //      various points texts.
    [SerializeField] private TextMeshProUGUI commonText;
    [SerializeField] private TextMeshProUGUI uncommonText;
    [SerializeField] private TextMeshProUGUI rareText;
    [SerializeField] private TextMeshProUGUI finalText;

    private string _itemString = "Final score: ";

    // ------------------------------------------------------------------------
    public void Activate(int commonPoints, int uncommonPoints, int rarePoints, int finalPoints)
    {
        gameObject.SetActive(true);

        // Update the points text with the final scores.
        commonText.text = commonPoints.ToString();
        uncommonText.text = uncommonPoints.ToString();
        rareText.text = rarePoints.ToString();
        finalText.text = _itemString + finalPoints;
    }

    // ------------------------------------------------------------------------
    // You don't need to code in this method :)
    public void RestartButton()
    {
        _gameController.RestartGame();
    }
}   
