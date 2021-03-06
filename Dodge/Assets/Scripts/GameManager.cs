using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    public GameObject level;
    public GameObject bulletSpawnerPrefab;
    private Vector3[] bulletSpawners = new Vector3[4];
    int spawnCounter = 0;


    private float surviveTime;
    private bool isGameover;

    void Start()
    {
        surviveTime = 0;
        isGameover = false;

        bulletSpawners[0].x = -8f;
        bulletSpawners[0].y = 1f;
        bulletSpawners[0].z = 8f;

        bulletSpawners[1].x = 8f;
        bulletSpawners[1].y = 1f;
        bulletSpawners[1].z = 8f;
                
        bulletSpawners[2].x = 8f;
        bulletSpawners[2].y = 1f;
        bulletSpawners[2].z = -8f; 
        
        bulletSpawners[3].x = -8f;
        bulletSpawners[3].y = 1f;
        bulletSpawners[3].z = -8f;

    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time :" + (int)surviveTime;
        
            if(surviveTime<5f && spawnCounter==0)
            {
                GameObject bulletspawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                spawnCounter++;
            }
            else if (surviveTime >= 5f && surviveTime<10f && spawnCounter == 1)
            {
                GameObject bulletspawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                spawnCounter++;
            }
            else if (surviveTime >= 10f && surviveTime < 15f && spawnCounter == 2)
            {
                GameObject bulletspawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                spawnCounter++;
            }
            else if (surviveTime >= 15f && surviveTime < 20f && spawnCounter == 3)
            {
                GameObject bulletspawner = Instantiate(bulletSpawnerPrefab, bulletSpawners[spawnCounter], Quaternion.identity);
                spawnCounter++;
            }
        }

        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        
        if(surviveTime>bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int)bestTime;
    }
}
