using UnityEngine;
using UnityEngine.InputSystem;

public class FruitBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public float timeThusFar;

    public GameObject[] sports;
    public int sportBallIndex;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sports = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().sports;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("fruit"))
        {
            GameObject otherFruit = col.gameObject;
            int otherFruitIndex = otherFruit.GetComponent<FruitBehavior>().sportBallIndex;
            if (sportBallIndex == otherFruitIndex && sportBallIndex != 0)
            {
                if (transform.position.x > otherFruit.transform.position.x ||
                    (transform.position.y > otherFruit.transform.position.y
                    && transform.position.x == otherFruit.transform.position.x))
                {
                    GameObject newSportBall =
                        Instantiate(sports[sportBallIndex + 1], Vector3.Lerp(transform.position,
                        otherFruit.transform.position, 0.5f), Quaternion.identity);
                    newSportBall.GetComponent<Collider2D>().enabled = true;
                    newSportBall.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                    Destroy(otherFruit);
                    Destroy(gameObject);
                }
            }
        }
    }
}
