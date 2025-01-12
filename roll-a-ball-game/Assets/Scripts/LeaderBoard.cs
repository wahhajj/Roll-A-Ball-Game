using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey = "6c48823694a7df41c347b4d932e95435ef21a7556a6679bf39909402f0e2f941";


    public void GetLeaderBoard()
    {
        LeaderBoardCreator.GetLeaderBoard(publicLeaderboardKey, ((msg) => {
            for (int i  = 0l i< names.Count; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].score.ToString();
            }
        }));
    }

    public void SetLeaderBoardEntry (string username, int score)
    {
        LeaderBoardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => {
            username.Substring(0,8);
            GetLeaderBoard();
        }));
    }
   
}
