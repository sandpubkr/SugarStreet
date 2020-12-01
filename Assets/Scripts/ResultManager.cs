using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

    public Button btn_Stop;
    public Button btn_Retry;
    public Text text_playScore;
    public Text text_bestScore;


    public void Init()
    {
        UpdatePlayScoreText();
        UpdateBestScoreText();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        SetButtonEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonEvents()
    {
        btn_Stop.onClick.AddListener(delegate { OnStop(); });
        btn_Retry.onClick.AddListener(delegate { OnRetry(); });
    }

    public void OnStop()
    {
        Debug.Log("OnStop!!");
        GameManager.Instance.ShowUI(GameManager.UIs.lobby);
    }

    public void OnRetry()
    {
        Debug.Log("OnRetry!!");
        GameManager.Instance.ShowUI(GameManager.UIs.play);
    }

    void UpdatePlayScoreText()
    {
        text_playScore.text = GameManager.Instance.getPlayScore().ToString();
    }

    void UpdateBestScoreText()
    {
        text_bestScore.text = GameManager.Instance.getBestScore().ToString();
    }
}
