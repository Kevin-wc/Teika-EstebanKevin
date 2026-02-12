using UnityEngine;
using UnityEngine.InputSystem;

public class BorderBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public GameObject gameOver;
    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
            timeStart = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
            float currentTime = Time.time;
            float timeThusFar = currentTime - timeStart;
            if (timeThusFar > timeout)
            {
                gameOver.SetActive(true);
                print("Game Over");
                Time.timeScale = 0f;
                player.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
            timeStart = 0.0f;
        }
    }
}
