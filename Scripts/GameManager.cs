using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
using Generators;
using GameStates;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentDay = 0;
    public float counter = 0;

    public GameObject city;
    public GameObject fish;
    public List<Transform> cardumenPos;
    private GameState gameState;
    List<List<Vector3>> grid = new List<List<Vector3>>();
    List<List<GameObject>> obj = new List<List<GameObject>>();
    public List<GameObject> Instantiables = new List<GameObject>();//0//corales//
    public GameObject win;
    public GameObject lose;
    Generator generator;
    public Animator anim;
    public bool start = false;
    int[,] Map;
    public void Mapear()
    {
        for (int i = 0; i < 100; i++)
        {
            grid.Add(new List<Vector3>());
            obj.Add(new List<GameObject>());
            for (int j = 0; j < 100; j++)
            {
                grid[i].Add(new Vector3(i * 5 - 250, 0, j * 5 - 250));
                obj[i].Add(Instantiate(new GameObject(), grid[i][j], Quaternion.identity));
            }
        }

    }
    public void DrawMaze()
    {
        for (int i = 0; i < cardumenPos.Count; i++)
        {
            //Instantiate(fish, cardumenPos[i]);
        }
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                if (Map[i, j] != 0)
                {
                    Instantiate(Instantiables[Map[i, j] - 1], obj[i][j].transform);

                }
            }
        }
    }
    public void ClearGrid()
    {
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                if (obj[i][j].transform.childCount > 0)
                    Destroy(obj[i][j].transform.GetChild(0));

            }
        }
    }
    public void NextDayOnFaint()
    {
        counter = 0;
        currentDay++;
    }
    private void DayTiming()
    {
        if (counter >= 120f)
        {
            currentDay++;
            city.GetComponent<City>().NextDay();
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;

        }
    }

    public void FinishGame()
    {
        if (gameState == GameState.Win)
        {
            win.SetActive(true);
            //codigo que se ejecuta al ganar el juego
        }
        else if (gameState == GameState.Lose)
        {
            lose.SetActive(true);
            //codigo que se ejecuta al perder el juego
        }
    }

    void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }
    void Start()
    {
        gameState = GameState.InGame;
        Mapear();
        generator = new Generator(100, 100, 4, 2, 0.17f);
        generator.Generate();
        generator.ClearInRange(new Vector2(50, 50), 13);
        Map = generator.Map;
        DrawMaze();
    }
    void Update()
    {
        if (start)
            DayTiming();
        if (currentDay == Globals.daysToWin)
        {
            gameState = GameState.Win;
            FinishGame();
        }
        if (city.GetComponent<City>().satisfaction <= Globals.satisfactionBreakPoint)
        {
            gameState = GameState.Lose;
            FinishGame();
        }


    }
    public void Star()
    {
        anim.SetTrigger("start");
        start = true;
    }
}



