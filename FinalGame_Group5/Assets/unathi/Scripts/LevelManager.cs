using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum State
{
    Neutral,
    Battle,
    Training
}

public class LevelManager : MonoBehaviour
{
    public List<Transform> hidingSpots;

    public GameObject hidingSpotsParent;
    public GameObject targets;
    public GameObject walls;

    public GameObject blackscreen;
    public GameObject levelCanvas;

    public Transform[] spawnPoints;
    public Transform player;
    public Vector3 trainingSpawn;

    public GameObject enemyPrefab;

    int spawnIndex = 0;

    public State state;

    public int enemyCount = 0;

    public Text question;
    public GameObject questionText;

    public GameObject buttons;

    [SerializeField]bool training = false;
    [SerializeField] bool battle = false;

    // Start is called before the first frame update
    private void Start()
    {
        trainingSpawn = new Vector3(71, 1.69f, 46f);
        state = State.Neutral;
    }

    void Awake()
    {
        hidingSpots = new List<Transform>();
    }
    
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Neutral:
                hidingSpotsParent.SetActive(false);
                targets.SetActive(false);
                levelCanvas.SetActive(true);
                break;
            case State.Training:
                targets.SetActive(true);
                hidingSpotsParent.SetActive(false);
                levelCanvas.SetActive(false);
                break;
            case State.Battle:
                hidingSpotsParent.SetActive(true);
                walls.SetActive(true);
                levelCanvas.SetActive(false);
                break;
        }
    }

    IEnumerator SpawnEnemies()
    {
        Debug.Log("Fuck");

        while (spawnIndex < spawnPoints.Length)
        {
            Transform spawnPoint = spawnPoints[spawnIndex];

            // Instantiate the enemy at the current spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Wait for the specified spawnDelay
            yield return new WaitForSeconds(5);

            // Move to the next spawn point
            spawnIndex++;
        }
    }

    public void SpawnEnemy()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        // Instantiate the enemy at the current spawn point
        Instantiate(enemyPrefab, spawnPoints[randSpawnPoint].position, Quaternion.identity);

        // Move to the next spawn point
        spawnIndex++;
    }

    public void StartTraining()
    {
        questionText.SetActive(true);
        question.text = "START TRAINING?";
        training = true;
        battle = false;
    }

    public void StartBattle()
    {
        questionText.SetActive(true);
        question.text = "START BATTLE?";
        training = false;
        battle = true;
    }

    public void Yes()
    {
        StartCoroutine(Countdown());
    }

    public void No()
    {
        questionText.SetActive(false);
    }

    IEnumerator Countdown()
    {
        question.text = "Starting in: 5";

        yield return new WaitForSeconds(1);

        question.text = "Starting in: 4";

        yield return new WaitForSeconds(1);

        question.text = "Starting in: 3";

        yield return new WaitForSeconds(1);

        question.text = "Starting in: 2";

        yield return new WaitForSeconds(1);

        question.text = "Starting in: 1";

        yield return new WaitForSeconds(1);

        if (training)
        {
            state = State.Training;
            StartCoroutine(BlackScreen());
            player.position = trainingSpawn;

        }
        else if (battle)
        {
            state = State.Battle;
            StartCoroutine(SpawnEnemies());
        }

        questionText.SetActive(false);
    }

    IEnumerator BlackScreen()
    {
        blackscreen.SetActive(true);

        yield return new WaitForSeconds(3);

        blackscreen.SetActive(false);
    }
}
