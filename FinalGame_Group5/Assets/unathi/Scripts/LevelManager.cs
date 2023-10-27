
using System.Collections;
using System.Collections.Generic;
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
    public List<GameObject> targetsList;

    public GameObject targetPrefab;
    public GameObject targets;

    public GameObject hidingSpotsParent;
    public GameObject walls;

    public GameObject blackscreen;
    public GameObject levelCanvas;

    public Transform[] spawnPoints;
    public Transform[] spawnPoints_h;

    public Transform player;
    public Vector3 trainingSpawn;

    public GameObject enemyPrefab;
    public GameObject enemyPrefab_h;

    int spawnIndex = 0;
    int spawnIndex_h = 0;

    public int numberOfTargets = 0;

    public State state;

    public int enemyCount = 0;
    public int enemyCount_h = 0;

    public Text question;
    public GameObject questionText;
    public GameObject trainingUI;
    public GameObject battleUI;
    public GameObject hostageUI;

    public GameObject buttons;

    [SerializeField] bool training1 = false;
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
                enemyCount = 0;
                enemyCount_h = 0;
                break;
            case State.Training1:
                hidingSpotsParent.SetActive(false);
                levelCanvas.SetActive(false);
                walls.SetActive(false);
                break;
            case State.Training2:
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
                inventoryUI.SetActive(false);
                Camera cam = Camera.main;
                cam.GetComponent<MouseLook>().lockMouse = false;
                cam.GetComponent<MouseLook>().MouseLock();
            }
            else
            {
                inventoryUI.SetActive(true);
                Camera cam = Camera.main;
                cam.GetComponent<MouseLook>().lockMouse = false;
                cam.GetComponent<MouseLook>().MouseLock();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state == State.Training1)
                DestroyAllTargets();

            state = State.Neutral;
        }
    }

    public void SpawnEnemy()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        // Instantiate the enemy at the current spawn point
        Instantiate(enemyPrefab, spawnPoints[randSpawnPoint].position, Quaternion.identity);

        // Move to the next spawn point

        if (spawnIndex == 13)
            spawnIndex = 0;
        else
        spawnIndex++;
    }

    public void SpawnEnemy_H()
    {
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        // Instantiate the enemy at the current spawn point
        Instantiate(enemyPrefab, spawnPoints[randSpawnPoint].position, Quaternion.identity);

        // Move to the next spawn point
        if (spawnIndex_h == 4)
            spawnIndex = 0;
        else
            spawnIndex_h++;
    }

    public void StartTraining()
    {
        questionText.SetActive(true);
        trainingUI.SetActive(true);
        question.text = "CHOOSE TRAINING TYPE";
        battle = false;
        hostage = false;
    }

    public void StartBattle()
    {
        questionText.SetActive(true);
        battleUI.SetActive(true);
        question.text = "START BATTLE?";
        training1 = false;
        training2 = false;
        battle = true;
        hostage = false;
    }

    public void StartRescue()
    {
        questionText.SetActive(true);
        question.text = "START RESCUE?";
        hostageUI.SetActive(true);
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

    public void HostageYes()
    {
        hostage = true;
        StartCoroutine(Countdown());
    }

    public void No()
    { 
        if(battle)
        battleUI.SetActive(false);
    else
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
            SpawnTargets();
        }
        else if (battle)
        {
            state = State.Battle;
         //spawn battle bots
        } else if(hostage)
        {
            state = State.Hostage;
            StartCoroutine(SpawnEnemies_H());

        } else if (training2)
        {
            state = State.Training2;
            StartCoroutine(SpawnEnemies());
            enemyCount = 4;
        }

        questionText.SetActive(false);
        trainingUI.SetActive(false );
        battleUI.SetActive(false);
        hostageUI.SetActive(false);
    }

    IEnumerator BlackScreen()
    {
        blackscreen.SetActive(true);

        yield return new WaitForSeconds(3);

        blackscreen.SetActive(false);
    }

    void SpawnTargets()
    {
        // Loop through each spawn point in the array.
        foreach (Transform spawnPoint in targetSpawns)
        {
            // Instantiate the prefab at the current spawn point's position and rotation.
            GameObject tar = Instantiate(targetPrefab, spawnPoint.position, spawnPoint.rotation);
            targetsList.Add(tar);
        }
    }

    void DestroyAllTargets()
    {
        foreach (GameObject obj in targetsList)
        {
            Destroy(obj);
        }

        // Clear the list to remove references to the destroyed objects
        targetsList.Clear();
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

    IEnumerator SpawnEnemies_H()
    {
        Debug.Log("Fuck");

        while (spawnIndex_h < spawnPoints_h.Length)
        {
            Transform spawnPoint = spawnPoints_h[spawnIndex_h];

            // Instantiate the enemy at the current spawn point
            Instantiate(enemyPrefab_h, spawnPoint.position, spawnPoint.rotation);

            // Wait for the specified spawnDelay
            yield return new WaitForSeconds(5);

            // Move to the next spawn point
            spawnIndex_h++;
        }
    }
}
