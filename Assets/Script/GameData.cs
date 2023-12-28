using System.Collections;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [Header("Scene - GameManager에 넣기")]
    public static GameData instance;
    //싱글톤 설정
    public GameObject Savepoint;
    //세이브 포인트가 저장될 공간
    public bool rightHooked = false;
    //올바르게 훅이 설치되었는가?
    public float LocalTime;
    //시간

    [Header("랭킹 시스템")]
    public RankSystem rank;
    //랭킹 시스템
    public int selectedIcon;
    //아이콘
    
    
    [Header("GameManager 추가분")]
    public bool isStart;
    //게임 시작 Bool값
    //float currentTime;
    //현재 시간
    public string timeText;
    //시간 표시
    public GameObject flagObj;
    //깃발
    public GameObject TimeUI;
    //시간 표시 UI

    public AudioSource fireSFX;
    //폭죽소리

    private void Awake()
    {
        instance = this;
    }//인스턴스화

    private void Start()
    {

    }

    public void Update()
    {
        if (isStart)
        {
            LocalTime += Time.deltaTime;
            float sec = LocalTime % 60;
            int min = (int)LocalTime / 60;
            timeText = $"{min:00}:{sec:00}";
        }
    }

    public void TimeStart()
    {
        isStart = true;
    }

    public void TimeStop()
    {
            fireSFX.Play();
            rank.RankUpdate(selectedIcon, LocalTime);
            rank.RankReset();
            rank.RankInstantiate();
            isStart = false;
    }

    /*IEnumerator StartTimer()
    {
        Invoke("FlagDestroy", 1f); // ��� ��ġ 1���� ��� ����� Ÿ�̸� Ȱ��ȭ

        while (true)
        {
            isStart = true;
            currentTime += Time.deltaTime;
            float sec = currentTime % 60;
            int min = (int)currentTime / 60;
            timeText = $"{min:00}:{sec:00}";
            yield return null;
        }
        
    }*/

    /*void FlagDestroy()
    {
        TimeUI.SetActive(true);
        flagObj.SetActive(false); 
    }*/

}
