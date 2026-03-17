using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject backPrefab; // Assign the background prefab in the inspector
    public GameObject[] bcks; // Array to hold the background instances
    public float speed; // Speed at which the background moves
    public float pivotPoint; // Scale of the background
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bcks = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            float xPos = pivotPoint - (pivotPoint / 2 * i);
            float yPos = pivotPoint - (pivotPoint / 2 * i);
            Vector3 pos = new Vector3(xPos, yPos, 0.0f);
            bcks[i] = Instantiate(backPrefab, pos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            float xPos = bcks[i].transform.position.x + speed;
            float yPos = bcks[i].transform.position.y + speed;
            Vector3 newPos = new Vector3(xPos, yPos, 0.0f);
            bcks[i].transform.position = newPos;
            if (xPos > -pivotPoint / 2)
            {
                Vector3 pivot = new Vector3(pivotPoint, pivotPoint, 0.0f);
                bcks[i].transform.position = pivot;
            }

        }
    }
}
