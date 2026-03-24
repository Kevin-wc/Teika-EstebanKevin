using UnityEngine;
using UnityEngine.InputSystem;

public class FruitBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public float timeThusFar;

    public GameObject[] sports;
    public int sportBallIndex;
    public int jokerIndex = 8;
    public int maxNormalIndex = 7;
    private AudioSource mergeSource;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sports = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().sports;
        mergeSource = GameObject.FindGameObjectWithTag("Player").
             GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("fruit"))
        {
            GameObject otherFruit = col.gameObject;
            int otherFruitIndex = otherFruit.GetComponent<FruitBehavior>().sportBallIndex;

            bool normalMerge = (sportBallIndex == otherFruitIndex && sportBallIndex != jokerIndex && sportBallIndex < maxNormalIndex);

            bool jokerMerge = (sportBallIndex == jokerIndex && otherFruitIndex != jokerIndex && otherFruitIndex < maxNormalIndex);
            bool otherIsJoker = (otherFruitIndex == jokerIndex && sportBallIndex != jokerIndex && sportBallIndex < maxNormalIndex);
            if (normalMerge || jokerMerge || otherIsJoker)
            {
                if (transform.position.x > otherFruit.transform.position.x ||
                    (transform.position.y > otherFruit.transform.position.y
                    && transform.position.x == otherFruit.transform.position.x))
                {
                    int newIndex = 0;
                    int scoreIndex = 0;

                    if (normalMerge)
                    {
                        newIndex = sportBallIndex + 1;
                        scoreIndex = sportBallIndex;
                    }
                    else if (jokerMerge)
                    {
                        newIndex = otherFruitIndex + 1;
                        scoreIndex = otherFruitIndex;
                    }
                    else if (otherIsJoker)
                    {
                        newIndex = sportBallIndex + 1;
                        scoreIndex = sportBallIndex;
                    }

                    GameObject newSportBall =
                    Instantiate(sports[newIndex], Vector3.Lerp(transform.position,
                    otherFruit.transform.position, 0.5f), Quaternion.identity);
                    newSportBall.GetComponent<Collider2D>().enabled = true;
                    newSportBall.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                    mergeSource.Play();
                    GameObject.FindGameObjectWithTag("Player").
                        GetComponent<PlayerBehavior>().UpdateScore(sportBallIndex);
                    Destroy(otherFruit);
                    Destroy(gameObject);
                }
            }
        }
    }
}
