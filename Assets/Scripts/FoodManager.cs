using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    public enum Foods
    {
        cookie_choco,
        apple,
        cake,
        candy,
        pie_choco,
        fry,
        gumibear,
        icecream,
        lollipop,
        macaron,
        oreo,
        GingerBread,
        poison,
    }

    [SerializeField]
    private GameObject foodPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject createNewFood()
    {
        //create Obj
        GameObject newFoodObj = Instantiate(foodPrefab);

        //Get Necessary Data
        float canvasHalfWidth = GameManager.Instance.canvasHalfWidth;
        float objWidth = newFoodObj.GetComponent<RectTransform>().rect.width;
        float objHeight = newFoodObj.GetComponent<RectTransform>().rect.height;

        //Calculate Proper PosX Range
        float minPosX = ((-1) * canvasHalfWidth) + (objWidth / 2);
        float maxPosX = canvasHalfWidth - (objWidth / 2);
        float newPosX = Random.Range(minPosX, maxPosX);

        //Set Proper PosY
        float newPosY = GameManager.Instance.canvasHalfHeight + objHeight;

        // Set Parent
        newFoodObj.transform.SetParent(GameManager.Instance.playManager.gameObject.transform);

        // Set Local Scale & Position
        newFoodObj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newFoodObj.transform.localPosition = new Vector3(newPosX, newPosY, 0);

        //Get Random food Type

        Foods eFoodType = getFoodRandomFoodType();

        //Set Tag & Image
        newFoodObj.GetComponent<Food>().enumVal = eFoodType;

        //Sprite newSprite = Resources.Load<Sprite>(string.Format("Assets/Resources/{0})", getSpriteName(eFoodType)));
        string foodName = getSpriteName(eFoodType).ToString();
        //Debug.Log(string.Format("@@ Food Name = {0}", foodName));

        Sprite newSprite = Resources.Load<Sprite>(foodName);
        newFoodObj.GetComponent<Image>().sprite = newSprite;

        return newFoodObj;
    }

    Foods getFoodRandomFoodType()
    {
        string[] foodNames = Foods.GetNames(typeof(Foods));

        //Debug.Log(string.Format("foodNames.Length = {0}", foodNames.Length));

        int randIdx = Random.Range(0, foodNames.Length - 1);
        Foods ret = (Foods)System.Enum.Parse(typeof(Foods), foodNames[randIdx]);

        return ret;
    }


    public int getFoodScore(Foods eFood)
    {
        int foodScore = 0;
        switch (eFood)
        {
            case FoodManager.Foods.apple:
                foodScore = 1;
                break;
            case FoodManager.Foods.cake:
                foodScore = 2;
                break;
            case FoodManager.Foods.candy:
                foodScore = 3;
                break;
            case FoodManager.Foods.cookie_choco:
                foodScore = 4;
                break;
            case FoodManager.Foods.fry:
                foodScore = 5;
                break;
            case FoodManager.Foods.gumibear:
                foodScore = 6;
                break;
            case FoodManager.Foods.icecream:
                foodScore = 7;
                break;
            case FoodManager.Foods.lollipop:
                foodScore = 8;
                break;
            case FoodManager.Foods.macaron:
                foodScore = 9;
                break;
            case FoodManager.Foods.oreo:
                foodScore = 10;
                break;
            case FoodManager.Foods.pie_choco:
                foodScore = 11;
                break;
            case FoodManager.Foods.GingerBread:
                foodScore = 12;
                break;
            case FoodManager.Foods.poison:
                foodScore = -10;
                break;
            default:
                foodScore = 0;
                break;
        }

        return foodScore;
    }

    string getSpriteName(Foods eFood)
    {
        string spriteName = string.Empty;
        switch (eFood)
        {
            case FoodManager.Foods.apple:
                spriteName = "Apple";
                break;
            case FoodManager.Foods.cake:
                spriteName = "Cake";
                break;
            case FoodManager.Foods.candy:
                spriteName = "Candy";
                break;
            case FoodManager.Foods.cookie_choco:
                spriteName = "ChocoCookie";
                break;
            case FoodManager.Foods.fry:
                spriteName = "Fry";
                break;
            case FoodManager.Foods.gumibear:
                spriteName = "GumiBear";
                break;
            case FoodManager.Foods.icecream:
                spriteName = "Icecream";
                break;
            case FoodManager.Foods.lollipop:
                spriteName = "Lollipop";
                break;
            case FoodManager.Foods.macaron:
                spriteName = "Macaron";
                break;
            case FoodManager.Foods.oreo:
                spriteName = "Oreo";
                break;
            case FoodManager.Foods.pie_choco:
                spriteName = "ChocoPie";
                break;
            case FoodManager.Foods.GingerBread:
                spriteName = "GInger";
                break;
            case FoodManager.Foods.poison:
                spriteName = "Poison";
                break;
            default:
                spriteName = "Cake";
                break;
        }

        return spriteName;
    }
}
