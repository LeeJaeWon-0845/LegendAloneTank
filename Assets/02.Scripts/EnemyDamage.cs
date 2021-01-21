using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    
    public GameObject enemy;
    private GameObject expEffect = null; //탱크 폭발 시 폭발 효과 프리팹
    private int initHp = 100; //초기 생명치
    private int currHp = 0; //현재 생명치
    // Start is called before the first frame update
    EnemySpawner enemySpawner;
    public Canvas hudCanvas;
    public Image hpBar;
    void Awake()
    {

        currHp = initHp; //현재 생명치를 초기 생명치로 초기값 설정
        expEffect = Resources.Load<GameObject>("Large Explosion"); //탱크 폭발 시 생성시킬 프리팹 로드0
        hpBar.color = Color.green;//체력 게이지를 녹색으로 설정
        enemySpawner = new EnemySpawner();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (currHp > 0 && other.tag == "CANNON") //탱크랑 충돌한 오브젝트가 포탄이라면..
        {
            currHp -= 20; //체력을 20감소
            hpBar.fillAmount = (float)currHp / (float)initHp;//현재 생명치 백분율=(현재 생명치)/(초기 생명치)
            if (hpBar.fillAmount <= 0.4f) hpBar.color = Color.red;//40퍼 이하면 빨간색
            else if (hpBar.fillAmount <= 0.6f) hpBar.color = Color.yellow;//60퍼 이하면 노란색

            if (currHp <= 0)//사망시
            {
                StartCoroutine(this.ExposionTank()); //폭발 효과 및  리스폰 코루틴 함수 호출
            }
        }
        else if (currHp > 0 && other.tag == "BOSSCANNON") //탱크랑 충돌한 오브젝트가 포탄이라면..
        {
            currHp -= 40; //체력을 20감소
            hpBar.fillAmount = (float)currHp / (float)initHp;//현재 생명치 백분율=(현재 생명치)/(초기 생명치)
            if (hpBar.fillAmount <= 0.4f) hpBar.color = Color.red;//40퍼 이하면 빨간색
            else if (hpBar.fillAmount <= 0.6f) hpBar.color = Color.yellow;//60퍼 이하면 노란색

            if (currHp <= 0)//사망시
            {
                StartCoroutine(this.ExposionTank()); //폭발 효과 및  리스폰 코루틴 함수 호출
            }
        }
    }
    IEnumerator ExposionTank()
    {
        Object effect = GameObject.Instantiate(expEffect, transform.position, Quaternion.identity); //폭발 효과 생성
        Destroy(effect, 3.0f); //3초 뒤에 폭발효과제거
        hudCanvas.enabled = false;
        SetTankVisible(false);//탱크 투명처리
        yield return new WaitForSeconds(3.0f); //3초 후 리스폰
        hpBar.fillAmount = 1.0f;//filled 이미지 초기화
        hpBar.color = Color.green; //filled 이미지 녹색으로
        hudCanvas.enabled = true; //hud 활성화

        currHp = initHp; //체력 100으로 다시..
        SetTankVisible(true); //탱크를 다시 보이게
    }
   public void SetTankVisible(bool isVisible) //탱크의 5개의 메쉬렌더러들을 비지블을 트루/false
    {
        // Debug.Log(isVisible);
          enemy.SetActive(isVisible); 
       
       
       
        EnemySpawner.Destroy();
    }
}