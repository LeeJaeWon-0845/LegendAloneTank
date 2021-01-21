using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireCannon : MonoBehaviour
{
    private GameObject cannon = null;
    public Transform firePos;
    private AudioClip fireSfx = null;
    private AudioSource sfx = null;
    public GameObject wayPoint;
    public GameObject enemy;
    public GameObject enemy1;

    //탱크별로 사정거리를 다르게 둠
    public float range;
    // Start is called before the first frame update
    void Awake()
    {
        //플레이어의 위치를 받아옴
        wayPoint = GameObject.FindGameObjectWithTag("Player");
        cannon = (GameObject)Resources.Load("cannon");
        fireSfx = Resources.Load<AudioClip>("CannonFire");
        sfx = GetComponent<AudioSource>();
        
        StartCoroutine(UpdateFire());
    }
    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator UpdateFire()
    {
        while (true)
        {
         
                //5초마다 플레이어 위치로 발사
                if (Vector3.Distance(wayPoint.transform.position, enemy.transform.position) <= range)
                {
                    Fire();
                }
                // 5초 주기로 처리 반복
                yield return new WaitForSeconds(5f);
           

        
        }
    }

    void Fire()
    {
        sfx.PlayOneShot(fireSfx, 1.0f);
        Instantiate(cannon, firePos.position, firePos.rotation);
     
    }

}
