using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody rb;
    public int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject RestartButton;
    public GameObject MainMenuButton;
    public GameObject LeaderBoard;

    public bool isGamePaused = true; // Track whether the game is paused
    public static bool isGameEnded = false;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        RestartButton.SetActive(false);
        MainMenuButton.SetActive(false);
        isGameEnded = false;
        LeaderBoard.SetActive(false);
        // Start the countdown coroutine
        StartCoroutine(CountdownStart());
    }

    void OnMove(InputValue movementValue)
    {
        if (!isGamePaused) // Only allow movement if the game is not paused
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    }

    void FixedUpdate()
    {
        if (CountDownController.isGameStarted) // Prevent movement while paused
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "count: " + count.ToString();
        if (count >= 9)
        {
            winTextObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);
            MainMenuButton.gameObject.SetActive(true);
            isGameEnded = true;
            LeaderBoard.SetActive(true);
            CountDownController.isGameStarted = false;
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
     

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            RestartButton.gameObject.SetActive(true);
            MainMenuButton.gameObject.SetActive(true);
            isGameEnded = true;
            CountDownController.isGameStarted = false;
        }
    }

    private IEnumerator CountdownStart()
    {
        // Countdown for 3 seconds
        for (int i = 3; i > 0; i--)
        {
            countText.text = "Starting in: " + i;
            yield return new WaitForSeconds(1f);
        }

        // End of countdown
        countText.text = "count: " + count.ToString();
        isGamePaused = false; // Resume the game
    }
}
