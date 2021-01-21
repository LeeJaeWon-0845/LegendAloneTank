using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankDamage : MonoBehaviour
{
    private MeshRenderer[] renderers; //탱크 폭파 후 투명처리를 위한 메쉬렌더러 컴포넌트 배열
    private GameObject expEffect = null; //탱크 폭발 시 폭발 효과 프리팹
    private int initHp = 100; //초기 생명치
    private int currHp = 0; //현재 생명치
    public Text endMessage; //게임이 끝났을 때 띄울 메시지
    // Start is called before the first frame update

    public Canvas hudCanvas; //GameUI 캔버스
    public Image hpBar; //플레이어의 hpbar
    public GameObject gameOver, inGame, player; 
    void Awake()
    {
        //탱크 모델의 모든 메쉬렌더러 컴포넌트를 추출한 후 배열에 할당
        renderers = GetComponentsInChildren<MeshRenderer>(); //하위 오브젝트가 많으면 GetComponents
        currHp = initHp; //현재 생명치를 초기 생명치로 초기값 설정
        expEffect = Resources.Load<GameObject>("Large Explosion"); //탱크 폭발 시 생성시킬 프리팹 로드0
        hpBar.color = Color.green;//체력 게이지를 녹색으로 설정
    }
    private void OnTriggerEnter(Collider other)
    {
        if (currHp > 0 && other.tag == "CANNON") //탱크랑 충돌한 오브젝트가 포탄이라면..
        {
            currHp -= 20; //체력을 20감소
            hpBar.fillAmount = (float)currHp / (float)initHp;//현재 생명치 백분율=(현재 생명치)/(초기 생명치)
            if (hpBar.fillAmount <= 0.4f) hpBar.color = Color.red;//40퍼 이하면 빨간색
            else if (hpBar.fillAmount <= 0.6f) hpBar.color = Color.yellow;//60퍼 이하면 노란색
            else if (hpBar.fillAmount > 0.6f) hpBar.color = Color.green; //60퍼 이상이면 초록색

            if (currHp <= 0)//사망시
            {
                Die(); //폭발 효과 및  리스폰 코루틴 함수 호출
            }
        }
        else if (currHp > 0 && other.tag == "BOSSCANNON") //탱크랑 충돌한 오브젝트가 포탄이라면..
        {
            currHp -= 40; //체력을 20감소
            hpBar.fillAmount = (float)currHp / (float)initHp;//현재 생명치 백분율=(현재 생명치)/(초기 생명치)
            if (hpBar.fillAmount <= 0.4f) hpBar.color = Color.red;//40퍼 이하면 빨간색
            else if (hpBar.fillAmount <= 0.6f) hpBar.color = Color.yellow;//60퍼 이하면 노란색
            else if (hpBar.fillAmount > 0.6f) hpBar.color = Color.green;//60퍼 이상이면 초록색

            if (currHp <= 0)//사망시
            {
                Die(); //폭발 효과 및  리스폰 코루틴 함수 호출
            }
        }


        else if (other.tag == "HpPOTION")
        {
            currHp += 40; //체력을 40증가
            if (currHp > 100)
                currHp = 100;
            Debug.Log(currHp);
            hpBar.fillAmount = (float)currHp / (float)initHp;//현재 생명치 백분율=(현재 생명치)/(초기 생명치)
            if (hpBar.fillAmount <= 0.4f) hpBar.color = Color.red;//40퍼 이하면 빨간색
            else if (hpBar.fillAmount <= 0.6f) hpBar.color = Color.yellow;//60퍼 이하면 노란색
            else if (hpBar.fillAmount > 0.6f) hpBar.color = Color.green;//60퍼 이상이면 초록색
            Destroy(other.gameObject);//먹은 포션을 제거

        }
    }
    void Die()
    {
        Object effect = GameObject.Instantiate(expEffect, transform.position, Quaternion.identity); //폭발 효과 생성
        Destroy(effect, 3.0f); //3초 뒤에 폭발효과제거
        hudCanvas.enabled = false;  //탱크의 ui를 제거
        
        //게임종료 화면 띄우고 인게임 요소들은 비활성화
        endMessage.text = "You Die.."; 
        gameOver.SetActive(true);
        inGame.SetActive(false);
        player.SetActive(false);
    }

}
