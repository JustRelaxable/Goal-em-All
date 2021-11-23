using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Update : MonoBehaviour

{
    public Text moneyText;
    public Slider moneySlider;
    bool gameOver;
    int Money;

    // Use this for initialization
    void Start()
    {
        gameOver = false;
        Money = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Money = MoneyTriggerController.money;
        moneyText.text = "" + Money;
        moneySlider.value = EnemyLayerController.enemy_score;
    }

    public void gameOVER()
    {
        gameOver = true;
    }

}
