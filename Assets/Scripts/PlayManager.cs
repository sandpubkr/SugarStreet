using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public Button btn_Pause;
    public Text text_playScore;
    public Text text_bestScore;

    float elapsedTime;

    [SerializeField]
    private GameObject playerPrefab;

    GameObject newPlayer;


    public void Init()
    {
        Debug.Log("PlayManager - Init!");
        
        elapsedTime = 0;
        GameManager.Instance.setPlayScore(0);

        createPlayer();

        UpdateScoreText();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayManager - Start!");

        SetButtonEvents();

        Init();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.5)
        {
            elapsedTime = 0;

            //Create new Food
            GameManager.Instance.foodManager.createNewFood();
        }
    }


    public void SetButtonEvents()
    {
        btn_Pause.onClick.AddListener(delegate { OnPause(); });
    }

    public void OnPause()
    {
        Debug.Log("OnPause!!");

        EndPlay();
    }

    public void EndPlay()
    {
        GameObject[] arrFoods = GameObject.FindGameObjectsWithTag("food");
        foreach (GameObject foodObj in arrFoods)
        {
            Destroy(foodObj);
        }

        Destroy(newPlayer);
        GameManager.Instance.ShowUI(GameManager.UIs.result);
    }

    public void SetPlayScoreText()
    {
        //Debug.Log(string.Format("SetPlayScoreText, {0}", playScore));
        text_playScore.text = GameManager.Instance.getPlayScore().ToString();
    }
    public void SetBestScoreText()
    {
        //Debug.Log(string.Format("SetPlayScoreText, {0}", playScore));
        text_bestScore.text = GameManager.Instance.getBestScore().ToString();
    }

    void UpdateScoreText()
    {
        SetPlayScoreText();
        SetBestScoreText();
    }


    public void AddScore(FoodManager.Foods eFood)
    {
        int foodScore = GameManager.Instance.foodManager.gameObject.GetComponent<FoodManager>().getFoodScore(eFood);
        Debug.Log(string.Format("Hit Food Score = {0}", foodScore));
        GameManager.Instance.addPlayScore(foodScore);
        
        UpdateScoreText();
    }
    
    public void createPlayer()
    {
        if (newPlayer != null)
            return;

        //create Obj
        newPlayer = Instantiate(playerPrefab);

        newPlayer.transform.SetParent(this.gameObject.transform);
        newPlayer.GetComponent<PlayerManager>().Init();
    }

}
