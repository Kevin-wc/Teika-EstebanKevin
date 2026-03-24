using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public Sprite[] UISprites;
    public int[] queue;
    private SpriteRenderer[] childRenderers;

    public int jokerIndex = 8;
    private int jokerTimer = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        queue = new int[4];
        childRenderers = new SpriteRenderer[4];
        for (int i = 0; i < transform.childCount; i++)
        {
            childRenderers[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }

        for (int i = 0; i < 4; i++)
        {
            queue[i] = GetRandomFruit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            childRenderers[i].sprite = UISprites[queue[i]];
        }
    }

    private int GetRandomFruit()
    {
        if (jokerTimer >= 20)
        {
            int chance = Random.Range(0, 5);
            if (chance == 0)
            {
                jokerTimer = 0;
                return jokerIndex;
            }
        }
        jokerTimer++;
        return Random.Range(0, 4);
    }

    public int updateQueue()
    {
        int type = queue[0];

        for (int i = 0; i < 3; i++)
        {
            queue[i] = queue[i + 1];
        }

        queue[3] = GetRandomFruit();
        return type;
    }
}
