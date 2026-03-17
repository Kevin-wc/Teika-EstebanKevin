using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject backPrefab; // Assign the background prefab in the inspector
    public GameObject[] bcks; // Array to hold the background instances
    public float speed; // Speed at which the background moves
    public float scale; // Scale of the background
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float pivotPoint = scale * 16 * -0.32f;
        backPrefab.transform.localScale = new Vector3(pivotPoint, pivotPoint, 0.0f);
        for (int i = 0; i < 3; i++)
        {
            float xPos = pivotPoint - (pivotPoint / 2 * i);
            float yPos = pivotPoint - (pivotPoint / 2 * i);
            bcks[i] = Instantiate(backPrefab, new Vector3(i * scale * 16, 0, 0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
