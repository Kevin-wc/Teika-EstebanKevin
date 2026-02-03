using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float speed;
    public GameObject sportBall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sportBall != null)
        {
            Vector3 sportBallOffset = new Vector3(0.0f, -1.0f, 0.0f);
            sportBall.transform.position = gameObject.transform.position + sportBallOffset;
            sportBall.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            sportBall.GetComponent<Collider2D>().enabled = false;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            sportBall.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            sportBall.GetComponent<Collider2D>().enabled = true;
            sportBall = null;
        }

        float offset = 0.0f;
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            offset -= speed;
        }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            offset += speed;
        }
        Vector3 newPos = transform.position;
        newPos.x = transform.position.x + offset;
        transform.position = newPos;
    }
}
