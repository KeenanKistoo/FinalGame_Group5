using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;


public enum State
{
    Neutral,
    Battle,
   Training1,
   Training2,
   Hostage
}

public class LevelManager : MonoBehaviour
{
    public List<Transform> hidingSpots;
    public List<Transform> targetSpawns;

    public GameObject targetPrefab;
    public GameObject targets;
    public GameObject uICam;

    public GameObject hidingSpotsParent;
    public GameObject walls;

    public GameObject blackscreen;
    public GameObject levelCanvas;

    public Transform[] spawnPoints;
    public Transform player;
    public Vector3 hostageStartPoint;
    public Vector3 trainingSpawn;

    public GameObject enemyPrefab;

    int spawnIndex = 0;

    int numberOfTargets = 0;

    public State state;

    public int enemyCount = 0;

    public Text question;
    public GameObject questionText;

    public GameObject buttons;

    [SerializeField]bool training1 = false;
    [SerializeField] bool training2 = false;
    [SerializeField] bool battle = false;
    [SerializeField] bool hostage = false;

    [SerializeField] GameObject inventoryUI;

    // Start is called before the first frame update
    private void Start()
    {
        trainingSpawn = new Vector3(83.5f, 1.95000005f, 47.5f);
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
                walls.SetActive(false);
                break;
            case State.Training1:
                if (numberOfTargets < 13)
                {
                    int rand = Random.Range(0, 12);
                    Instantiate(targetPrefab, targetSpawns[rand].position, Quaternion.identity);
                    numberOfTargets++;
                }
                hidingSpotsParent.SetActive(false);
                levelCanvas.SetActive(false);
                walls.SetActive(false);
                break;
            case State.Battle:
                hidingSpotsParent.SetActive(true);
                walls.SetActive(true);
                levelCanvas.SetActive(false);
                break;
        }

        if (enemyCount == 10)
        {
            state = State.Neutral;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (inventoryUI.activeInHierarchy)
            {
                uICam.SetActive(false);
                inventoryUI.SetActive(false);
                Camera cam = Camera.main;
                cam.GetComponent<MouseLook>().lockMouse = true;
                cam.GetComponent<MouseLook>().MouseLock();
            }
            else
            {
                uICam.SetActive(true);
                inventoryUI.SetActive(true);
                Camera cam = Camera.main;
                cam.GetComponent<MouseLook>().lockMouse = false;
                cam.GetComponent<MouseLook>().MouseLock();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            state = State.Neutral;
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
        uICam.SetActive(true);
        questionText.SetActive(true);
        question.text = "CHOOSE TRAINING TYPE";
        battle = false;
        hostage = false;
    }

    public void StartBattle()
    {
        uICam.SetActive(true);
        questionText.SetActive(true);
        question.text = "START BATTLE?";
        training1 = false;
        training2 = false;
        battle = true;
        hostage = false;
    }

    public void StartRescue()
    {
        uICam.SetActive(true);
        questionText.SetActive(true);
        question.text = "START RESCUE?";
        training1 = false;
        training2 = false;
        battle = false;
        hostage = true;
    }

    public void TargetsYes()
    {
        training1 = true;
        StartCoroutine(Countdown());
    }

    public void BotsYes()
    {
        training2 = true;
        StartCoroutine(Countdown());
    }

    public void No()
    {
        uICam.SetActive(false);
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

        if (training1)
        {
            state = State.Training1;
            StartCoroutine(BlackScreen());
            player.position = trainingSpawn;

        }
        else if (battle)
        {
            state = State.Battle;
         //spawn battle bots
        } else if(hostage)
        {
            state = State.Hostage;
            StartCoroutine(BlackScreen());
            player.position = hostageStartPoint;
        } else if (training2)
        {
            state = State.Training2;
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
