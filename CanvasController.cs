using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public Movement player;
    public Slider slider;
    public GameObject bubV;
    public GameObject foodV;
    public GameObject mineV;
    public TextMeshProUGUI oxiText;
    public TextMeshProUGUI oxyText;

    public TextMeshProUGUI foodText;

    public TextMeshProUGUI drillText;

    public TextMeshProUGUI Happy;
    public TextMeshProUGUI Population;
    public TextMeshProUGUI Oxygen;
    public TextMeshProUGUI Food;
    public TextMeshProUGUI Mine;

    public TextMeshProUGUI Day;
    public TextMeshProUGUI Time;

    public GameObject cityInfo;
    public City city;

    // Start is called before the first frame update
    void Start()
    {
    }
    void PrintCity()
    {

        Happy.text = city.satisfaction / city.people * 100 + "%";
        Population.text = city.people + "";
        Oxygen.text = city.oxigen + "";
        Food.text = city.food + "";
        Mine.text = 100 + "";
        Day.text = "Day " + GameManager.instance.currentDay;

        string s = "" + (int)((120 - (int)GameManager.instance.counter) % 60);
        if (s.Length < 2)
        {
            string a = "0" + s;
            s = a;
        }
        Time.text = (int)((120 - (int)GameManager.instance.counter) / 60) + ":" + s;
    }
    // Update is called once per frame
    void Update()
    {

        SetSliderValue();
        PrintCity();
        cityInfo.SetActive(player.InCity());
        switch (player.gunIndex)
        {
            case 0: bubV.SetActive(true); foodV.SetActive(false); mineV.SetActive(false); break;
            case 1: bubV.SetActive(false); foodV.SetActive(true); mineV.SetActive(false); break;
            case 2: bubV.SetActive(false); foodV.SetActive(false); mineV.SetActive(true); break;

        }
        oxyText.text = "" + player.oxygenStorage;
        foodText.text = "" + player.foodStorage;
        drillText.text = "" + player.drillStorage;
    }
    void SetSliderValue()
    {
        slider.value = player.oxigen;
        oxiText.text = Mathf.Round(player.oxigen * 100) + "%";
    }
}
