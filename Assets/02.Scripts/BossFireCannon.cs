using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireCannon : MonoBehaviour
{
    private GameObject cannon = null;
    public Transform firePos;
    private AudioClip fireSfx = null;
    private AudioSource sfx = null;
    public GameObject wayPoint;
    public GameObject enemy;
    public float range;
    // Start is called before the first frame update
    void Awake()
    {
        wayPoint = GameObject.FindGameObjectWithTag("Player");
        cannon = (GameObject)Resources.Load("BossCannon");
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
            //보스 탱크는 2초주기로 공격
            if (Vector3.Distance(wayPoint.transform.position, enemy.transform.position) <= range)
            {
                Fire();
            }
            // 0.25초 주기로 처리 반복
            yield return new WaitForSeconds(2f);


        }
    }

    void Fire()
    {
        sfx.PlayOneShot(fireSfx, 1.0f);
        Instantiate(cannon, firePos.position, firePos.rotation);

        Debug.Log("fire");
    }

}