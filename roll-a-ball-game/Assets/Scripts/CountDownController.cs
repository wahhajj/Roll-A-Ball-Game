using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;

    public static bool isGameStarted = false; // Global flag for game start

    private void Start()
    {
         isGameStarted = false;
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownDisplay.text = "GO!";
        isGameStarted = true; // Signal the game has started
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
