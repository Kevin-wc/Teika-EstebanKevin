using UnityEngine;
using UnityEngine.InputSystem;

public class FruitBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;

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
        if (other.gameObject.CompareTag("gameOver"))
        {
            timeStart = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("gameOver"))
        {
            float currentTime = Time.time;
            float timeThusFar = currentTime - timeStart;
            if (timeThusFar > timeout)
            {
                print("Game Over");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("gameOver"))
        {
            timeStart = 0.0f;
        }
    }
}
