using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] ItemPrefab;
    public Transform[] spawnPoints;
    int itemnum;
    // Start is called before the first frame update
    void Start()
    {
        itemnum = 0;
        StartCoroutine(UpdateItem());
    }

    private IEnumerator UpdateItem()
    {
        while (true)
        {
            //두 개의 아이템을 번갈아가며 생성
            if (itemnum == 0)
                itemnum = 1;
            else
                itemnum = 0;

                CreateItem(ItemPrefab[itemnum]);
            
            // 10초 주기로 처리 반복
            yield return new WaitForSeconds(10f);

        }
    }

    void CreateItem( GameObject itemPrefab)
    {
        //spawnPoints들 중 랜덤한 위치로 spawnPoint 생성
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        //item오브젝트 생성
        GameObject item = Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
        

    }
}
