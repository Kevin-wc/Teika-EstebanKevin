using UnityEngine;
using UnityEngine.InputSystem;

using TMPro;
public class PlayerBehavior : MonoBehaviour
{

    public float speed;
    public GameObject sportBall;
    private GameObject currentSportBall;
    public GameObject[] sports;
    public float min;
    public float max;
    public GameObject queue;
    public int[] points;
    public int score;
    public TMP_Text scoreText;
    public AudioSource dropSource;
    private float nextDropTime = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //  startTime = 0.0f;
        //  move = 0; // means you can move both ways
        score = 0;
        dropSource = GetComponents<AudioSource>()[1];
        queue = GameObject.FindGameObjectWithTag("Queue");
        scoreText.SetText("Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        //float startTime = Time.time;
        //float currentTime = Time.time;
        //print(currentTime);

        if (currentSportBall != null)
        {
            Vector3 currentSportBallOffset = new Vector3(0.0f, -1.0f, 0.0f);
            currentSportBall.transform.position = gameObject.transform.position + currentSportBallOffset;
            currentSportBall.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }
        else
        {
            int choice = queue.GetComponent<QueueManager>().updateQueue();
            //int index = Random.Range(0, sports.Length);
            currentSportBall = Instantiate(sports[choice], transform.position, Quaternion.identity);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time > nextDropTime)
        {
            Rigidbody2D body = currentSportBall.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;
            dropSource.Play();
            Collider2D collider = currentSportBall.GetComponent<Collider2D>();
            collider.enabled = true;
            currentSportBall = null;
            nextDropTime = Time.time + 1.0f;
        }

        float offset = 0.0f;
        bool left = (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed);
        if (left)
        {
            offset -= speed * Time.deltaTime;
        }

        bool right = (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed);
        if (right)
        {
            offset += speed * Time.deltaTime;
        }

        Vector3 newPos = transform.position;
        newPos.x = transform.position.x + offset;

        if (newPos.x > max)
        {
            newPos.x = max;
        }

        if (newPos.x < min)
        {
            newPos.x = min;
        }
        transform.position = newPos;


    }

    public void UpdateScore(int index)
    {
        score = score + points[index];
        scoreText.SetText("Score: " + score);
    }


}
