using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임 오버시 활성화할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최종 기록 표시
    public Text killText; // 사냥한 동물 수 표시
    

    private float ScoreCount;
    private float surviveTime; // 생존 시간 = >  죽인 횟수 
    private bool isGameover; //게임 오버 상태 


    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        ScoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover) 
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = string.Format("Time: {0}", (int)surviveTime);
            killText.text = string.Format("Score: {0}", (int)surviveTime+(int)ScoreCount);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }
    //현재 게임을 게임 오버 상태로 변경하는 메서드
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestScore");

        if (surviveTime+ScoreCount > bestTime) 
        {
            bestTime = surviveTime + ScoreCount;
            PlayerPrefs.SetFloat("BestScore", bestTime);

        }
        recordText.text = string.Format("Best Score: {0}", (int)bestTime);
    }


    public void SetScore(int killscore)
    {
        ScoreCount += killscore;
    }

    public int GetScore()
    {
        return (int)ScoreCount;
    }


}
