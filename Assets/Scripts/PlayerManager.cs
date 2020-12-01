using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    Vector3 minScreenPos;
    Vector3 maxScreenPos;

    float playerHalfWidth;

    float initPosY = -300;

    public void Init()
    {
        this.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        this.transform.localPosition = new Vector3(0, initPosY, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        minScreenPos = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxScreenPos = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Debug.Log(string.Format("@@@ minScreenPos = {0} // maxScreenPos = {1}", minScreenPos, maxScreenPos));

        float playerWidth = this.GetComponent<RectTransform>().rect.width;
        playerHalfWidth = playerWidth / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float destPosX = UpdateDestinationPos();
            MovePlayerPos(destPosX);
        }
    }

    void MovePlayerPos(float destPosX)
    {
        //Debug.Log(string.Format("@@@ MovePlayerPos::destPos = {0}", destPosX));

        Vector3 localPos = this.transform.localPosition;
        Vector3 newPos = new Vector3(destPosX, localPos.y, localPos.z);
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(newPos);
        //Vector3 viewPos = Camera.main.WorldToViewportPoint(newPos);
        //Debug.Log(string.Format("@@@ MovePlayerPos::newPos = {0}", viewPos));
        //this.transform.Translate(viewPos, Space.World);
        this.transform.localPosition = newPos;

        //Debug.Log(string.Format("@@@ MovePlayerPos::destPosX = {0}", destPosX));
        //Debug.Log(string.Format("@@@ MovePlayerPos::localPos = {0}", localPos));
        //Debug.Log(string.Format("@@@ MovePlayerPos::newPos = {0}", newPos));
        //Debug.Log(string.Format("@@@ MovePlayerPos::screenPos = {0}", screenPos));
        //Debug.Log(string.Format("@@@ MovePlayerPos::viewPos = {0}", viewPos));
    }


    float UpdateDestinationPos()
    {
        //Vector2 target = new Vector2(Input.mousePosition.x, 0);

        float canvasHalfWidth = GameManager.Instance.canvasHalfWidth;
        float newPosX = Input.mousePosition.x - canvasHalfWidth;
        //Debug.Log(string.Format("@@@ newPosX Orig = {0}", newPosX));

        float minPosX = ((-1) * canvasHalfWidth) + playerHalfWidth;
        float maxPosX = canvasHalfWidth - playerHalfWidth;

        newPosX = Mathf.Clamp(newPosX, minPosX, maxPosX);
        //Debug.Log(string.Format("@@@ newPosX ({0}) / minPosX({1}) / maxPosX({2})", newPosX, minPosX, maxPosX));

        return newPosX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Play Hit!");

        Food foodObj = collision.gameObject.GetComponent<Food>();

        Debug.Log(string.Format("Hit Food Type = {0}", foodObj.enumVal.ToString()));

        if (FoodManager.Foods.poison == foodObj.enumVal)
        {
            GameManager.Instance.playManager.EndPlay();
            return;
        }

        GameManager.Instance.playManager.AddScore(foodObj.enumVal);
        Destroy(foodObj.gameObject);
        //int foodScore = GameManager.Instance.foodManager.getFoodScore(foodObj.enumVal);
        //GameManager.Instance.addCurScore(foodScore);
    }
}
