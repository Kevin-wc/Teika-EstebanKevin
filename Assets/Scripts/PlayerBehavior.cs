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

    public int[] points;
    public int total;
    public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //  startTime = 0.0f;
        //  move = 0; // means you can move both ways
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
            int index = Random.Range(0, sports.Length);
            currentSportBall = Instantiate(sports[index], transform.position, Quaternion.identity);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentSportBall.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            currentSportBall.GetComponent<Collider2D>().enabled = true;
            currentSportBall = null;
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

    public void updateScore(int index)
    {
        total = total + points[index];
        text.SetText("Score: " + total);
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
