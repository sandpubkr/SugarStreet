using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public Button btn_Start;
    public Button btn_Exit;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager inst_gameManager = GameManager.Instance;
        //inst_gameManager.TestFunc();

        SetButtonEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtonEvents()
    {
        btn_Start.onClick.AddListener(delegate { OnStart();});
        btn_Exit.onClick.AddListener(delegate { OnExit(); });
    }

    public void OnStart()
    {
        Debug.Log("OnStart!!");
        GameManager.Instance.ShowUI(GameManager.UIs.play);
    }

    public void OnExit()
    {
        Debug.Log("OnExit!!");
        Application.Quit();
    }
}
