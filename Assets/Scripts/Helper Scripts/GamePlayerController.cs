using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayerController : MonoBehaviour
{

    public static GamePlayerController instance;

    public GameObject fruit_Pickup, bomb_Pickup;


    private float min_X = 1.70f, max_X = 9.5f, min_Y = -0.44f, max_Y = 3.9f;
    private float z_Pos = 0.31f;

    private Text score_Text;
    private int scoreCount;

    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
    }


    void Start()
    {
        score_Text = GameObject.Find("Score").GetComponent<Text>();

        Invoke("StartSpawning", 0.5f);
    }

    // Update is called once per frame
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void StartSpawning()
    {
        StartCoroutine(SpawPickUps());
    }

    public void CancelSpawning()
    {
        CancelInvoke("StartSpawning");
    }

    IEnumerator SpawPickUps()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));

        if (Random.Range(0, 10) >= 2)
        {
            Instantiate(fruit_Pickup, new Vector3(Random.Range(min_X, max_X),
                                                  Random.Range(min_Y, max_Y), z_Pos), Quaternion.identity);
        }
        else
        {
            Instantiate(bomb_Pickup, new Vector3(Random.Range(min_X, max_X),
                                                  Random.Range(min_Y, max_Y), z_Pos), Quaternion.identity);
        }
        Invoke("StartSpawning", 0f);
    }

    public void IncreaseScore()
    {
        scoreCount++;
        score_Text.text = "Score: " + scoreCount;
    }
}
