using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputscore;
    [SerializeField]
    private TMP_InputField inputName;
    //when the submit button is clicked, score text is changed to an int, string and int is sent to leaderboard, which will be defined as the name and score
    public UnityEvent<string, int> submitScoreEvent;

    public void Submitscore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputscore.text));
    }
}
