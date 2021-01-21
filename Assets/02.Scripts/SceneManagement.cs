using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public void Retry()//GameOver 캔버스에서 retry 버튼 클릭 시
    {
        SceneManager.LoadScene("scBattleField");
    }
    public void Lobby()//GameOver 캔버스에서 Lobby 버튼 클릭 시
    {
        SceneManager.LoadScene("scLobby");
    }
}
