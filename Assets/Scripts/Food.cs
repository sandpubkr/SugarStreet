using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [HideInInspector]
    public string foodTag = string.Empty;

    [HideInInspector]
    public FoodManager.Foods enumVal;
    //public int score;

    // Start is called before the first frame update
    void Start()
    {
        foodTag = enumVal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        checkDestroySelf();
    }

    void checkDestroySelf()
    {
        float objHeight = this.GetComponent<RectTransform>().rect.height;
        float destroyPosY = ((-1) * GameManager.Instance.canvasHalfHeight) - objHeight;
        float curPosY = this.transform.localPosition.y;

        if (curPosY < destroyPosY)
        {
            Destroy(this.gameObject);
        }
    }
}
