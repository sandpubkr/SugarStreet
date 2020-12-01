using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public enum UIs
    {
        lobby,
        play,
        result
    }


    public LobbyManager lobbyManager;
    public PlayManager playManager;
    public ResultManager resultManager;
    public FoodManager foodManager;

    [SerializeField]
    private GameObject canvasObj;

    private static GameManager m_inst;

    public int bestScore;
    public int playScore;
    
    public float canvasHalfWidth;
    public float canvasHalfHeight;

    public static GameManager Instance
    {
        get
        {
            if (m_inst == null)
            {
                // Search for existing instance.
                m_inst = (GameManager)FindObjectOfType(typeof(GameManager));

                // Create new instance if one doesn't already exist.
                if (m_inst == null)
                {
                    // Need to create a new GameObject to attach the singleton to.
                    var singletonObject = new GameObject();
                    m_inst = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";

                    // Make instance persistent.
                    DontDestroyOnLoad(singletonObject);
                }
            }

            return m_inst;
        }
    }


    public void ShowUI(UIs enum_UI)
    {
        Vector3 showPos = new Vector3(0, 0, 0);
        Vector3 hidePos = new Vector3(500, 0, 0);

        RectTransform trRect_Lobby = lobbyManager.GetComponent<RectTransform>();
        RectTransform trRect_Play = playManager.GetComponent<RectTransform>();
        RectTransform trRect_Result = resultManager.GetComponent<RectTransform>();

        if (enum_UI == UIs.lobby)
        {
            trRect_Lobby.localPosition = showPos;
            trRect_Play.localPosition = hidePos;
            trRect_Result.localPosition = hidePos;
        }
        else if (enum_UI == UIs.play)
        {
            trRect_Lobby.localPosition = hidePos;
            trRect_Play.localPosition = showPos;
            trRect_Result.localPosition = hidePos;

            playManager.GetComponent<PlayManager>().Init();
        }
        else if (enum_UI == UIs.result)
        {
            trRect_Lobby.localPosition = hidePos;
            trRect_Play.localPosition = hidePos;
            trRect_Result.localPosition = showPos;

            resultManager.GetComponent<ResultManager>().Init();
        }

        lobbyManager.gameObject.SetActive(enum_UI == UIs.lobby);
        playManager.gameObject.SetActive(enum_UI == UIs.play);
        resultManager.gameObject.SetActive(enum_UI == UIs.result);
    }

    // Start is called before the first frame update
    void Start()
    {
        setBestScore(0);
        setPlayScore(0);

        canvasHalfWidth = canvasObj.GetComponent<RectTransform>().rect.width / 2;
        canvasHalfHeight = canvasObj.GetComponent<RectTransform>().rect.height / 2;
        //Debug.Log(string.Format("Canvas Width = {0}", canvasWidth));

        ShowUI(UIs.lobby);
    }

    public void setPlayScore(int newPlayScore)
    {
        playScore = newPlayScore;
        UpdateBestScore(playScore);
    }

    public void setBestScore(int newBestScore)
    {
        bestScore = newBestScore;
    }

    public void addPlayScore(int addPlayScore)
    {
        playScore = Mathf.Max(0, playScore += addPlayScore);
        UpdateBestScore(playScore);
    }

    public void UpdateBestScore(int newBestScore)
    {
        if (newBestScore > bestScore)
        {
            setBestScore(newBestScore);
        }
    }

    public int getPlayScore()
    {
        return playScore;
    }

    public int getBestScore()
    {
        return bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
