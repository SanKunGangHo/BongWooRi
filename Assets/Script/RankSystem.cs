using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class RankSystem : MonoBehaviour
{
    [Header("기록 출력")]
    [Tooltip("랭킹")]
    [SerializeField] private float[] rankRecorder = new float[8];
    [Tooltip("랭킹 아이콘")]
    [SerializeField] private int[] rankIcon = new int[8];

    [Space(10f)]
    [Header("랭킹 프리팹")]
    [Tooltip("1등 프리팹")]
    public GameObject firstPrefab;
    [Tooltip("2등 프리팹")]
    public GameObject secondPrefab;
    [Tooltip("3등 프리팹")]
    public GameObject thirdPrefab;
    [Tooltip("다른 등수 프리팹")]
    public GameObject otherPrefab;

    [Space(10f)]
    [Header("이미지 프리팹")]
    [Tooltip("아이콘 프리팹들 순서 맞춰서 넣어주세요.")]
    public Sprite[] iconSprite;

    private void Start() {
        RankingShow();
        RankInstantiate();
        
    }

    public void RankUpdate(int P_Icon_Now, float P_Record_Now){
        for(int i = 1; i <= 9; i++){
            float currentRecord = PlayerPrefs.GetFloat("P_Record_"+i.ToString(), 0.0f);
            int currentIcon = PlayerPrefs.GetInt("P_Icon_"+i.ToString(), 0);
            if(P_Record_Now < currentRecord)   // 기록이 없을때 조건 추가(currentRecord == 0)
            {
                PlayerPrefs.SetFloat("P_Record_" + i.ToString(), P_Record_Now);
                P_Icon_Now = currentIcon;
                P_Record_Now = currentRecord;
            }else if(currentRecord == 0.0f)
            {
                PlayerPrefs.SetFloat("P_Record_" + i.ToString(), P_Record_Now);
                P_Icon_Now = currentIcon;
                P_Record_Now = currentRecord;
            }else if(P_Record_Now == currentRecord)
            {
                break;
            }
            //if(PlayerPrefs.GetFloat("P_Record_"+i.ToString(), 0.0f) == 0.0f){
            //    break;
            //}
            //print($"currentRecord: {currentRecord}");
        }
        
        RankingShow();
        //업데이트 하고 다시 가져오기
    }
    //랭킹 업데이트

    public void RankingShow(){
        for(int i = 1; i<=8; i++){
            rankRecorder[i-1] = PlayerPrefs.GetFloat("P_Record_"+i.ToString(), 0.0f);
            rankIcon[i-1] = PlayerPrefs.GetInt("P_Record_"+i.ToString(), 0);
           // print($"{i - 1}: {rankRecorder[i - 1]}");
        }
    }

    public void RankInstantiate(){
        for(int i = 0; i < rankRecorder.Length; i++){
            float sec = rankRecorder[i] % 60;
            int min = (int)rankRecorder[i] / 60;
            if(i == 0){
                var prefab = Instantiate(firstPrefab, transform);
                prefab.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = $"{min:00}:{sec:00.00}";
                //아이콘?
            }else if(i == 1){
                var prefab = Instantiate(secondPrefab, transform);
                prefab.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = $"{min:00}:{sec:00.00}";
            }else if(i == 2){
                var prefab = Instantiate(thirdPrefab, transform);
                prefab.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = $"{min:00}:{sec:00.00}";
            }else{
                var prefab = Instantiate(otherPrefab, transform);
                prefab.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = $"{min:00}:{sec:00.00}";
                prefab.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (i+1).ToString();
            }
        }
    }

    public void RankReset()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
    //랭킹 게시판 초기화

    public void ResetPrefs(){
        PlayerPrefs.DeleteAll();
    }
    //초기화
}
