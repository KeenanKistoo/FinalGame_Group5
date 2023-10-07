using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    public Transform[] spawnPoints;

    public GameObject enemyPrefab;

    int spawnIndex = 0;

    public State state;

    public int enemyCount = 0;

    public Text question;
    public GameObject questionText;

    public GameObject buttons;

    // Start is called before the first frame update
    private void Start()
    {
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
                break;
            case State.Training:
                targets.SetActive(true);
                hidingSpotsParent.SetActive(false);
                break;
            case State.Battle:
                hidingSpotsParent.SetActive(true);
                break;
        }
    }

    IEnumerator SpawnEnemies()
    {
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
    }

    public void StartBattle()
    {
        questionText.SetActive(true);
        question.text = "START TRAINING?";
    }

    public void Yes()
    {

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


    }
}
