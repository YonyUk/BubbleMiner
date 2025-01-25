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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetSliderValue();
        switch (player.gunIndex)
        {
            case 0: bubV.SetActive(true); foodV.SetActive(false); mineV.SetActive(false); break;
            case 1: bubV.SetActive(false); foodV.SetActive(true); mineV.SetActive(false); break;
            case 2: bubV.SetActive(false); foodV.SetActive(false); mineV.SetActive(true); break;

        }
    }
    void SetSliderValue()
    {
        slider.value = player.oxigen;
        oxiText.text = Mathf.Round(player.oxigen * 100) + "%";
    }
}
