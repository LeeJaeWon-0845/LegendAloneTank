using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab; // 생성할 적 AI
    public Text wavetv, enemiestv; //웨이브, 적의 수 인게임 UI
    public Transform[] spawnPoints; // 적 AI를 소환할 위치들
    public GameObject gameOver, inGame, player;
    
    private int wave; // 현재 웨이브
    //적들의 수를 관리할 변수
    public static int enemies;
    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        enemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //웨이브당 적들을 다 잡으면 다음 웨이브 진행
        if (enemies <= 0)
        {
            SpawnWave();
        }
        enemiestv.text = "ENEMIES : "+enemies;
    }

    private void SpawnWave()
    {
        //웨이브 숫자를 늘리고
        wave++;
        wavetv.text = "WAVE : " + wave;
        int spawnCount = Mathf.RoundToInt(wave * 2.5f); //현재 웨이브*2.5를 반올림한 수만큼 적 생성
        //전체 웨이브는 5웨이브 
        if (wave < 6)
        {
            if (wave >= 3)//3웨이브 부터 새로운 적 등장
            {
                for (int i = 0; i < wave; i++)
                {
                    float enemyIntensity = Random.Range(10f, 0f);
                    CreateEnemy(enemyIntensity, enemyPrefab[1]);
                }
            }
            if (wave == 5)//5웨이브에는 Boss 등장
            {
                float enemyIntensity = Random.Range(10f, 0f);
                CreateEnemy(enemyIntensity, enemyPrefab[2]);
            }
            //웨이브마다 웨이브 *2.5만큼 적 탱크 등장
            for (int i = 0; i < spawnCount; i++)
            {
                float enemyIntensity = Random.Range(10f, 0f);
                CreateEnemy(enemyIntensity, enemyPrefab[0]);
            }
        }
        //5웨이브가 끝나면 게임종료 UI
        else
        {
            gameOver.SetActive(true);
            inGame.SetActive(false);
            player.SetActive(false);
        }
    }
    private void CreateEnemy(float intensity, GameObject enemyPrefab)
    {
       

        //탱크가 생성될 위치를 랜덤하게 결정
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //탱크 프리팹 생성
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemies++;
        
  
    }
    public static void Destroy()
    {
        //탱크가 파괴될 시 탱크의 전체 수를 줄임
        enemies--;
    }
}
