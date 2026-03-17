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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //  startTime = 0.0f;
        //  move = 0; // means you can move both ways
        score = 0;
        dropSource = GetComponents<AudioSource>()[1];
        queue = GameObject.FindGameObjectWithTag("Queue");
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
        float nextDropTime = 0.0f;
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
            offset -= speed;
        }

        bool right = (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed);
        if (right)
        {
            offset += speed;
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

    /* private void OnCollisionEnter2D(Collision2D other)
     {
         print("Collided with " + other.gameObject.name);
         if (other.gameObject.CompareTag("AB"))
         {
             //  move = 1;
         }
     }*/
    /* private void OnCollisionStay2D(Collision2D other)
     {
         print("Colliding with " + other.gameObject.name);
         if (true)
         {

         }
     }*/

    /* private void OnCollisionExit2D(Collision2D other)
     {
         print("Stopped Colliding with " + other.gameObject.name);
         if (other.gameObject.CompareTag("AB"))
         {
             //  move = 1;
         }

     }*/
}
