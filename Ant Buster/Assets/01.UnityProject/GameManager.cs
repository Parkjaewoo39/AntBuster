using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GSingleton<GameManager>
{
    public float gameScore = default;
    public float Score = default;


    public bool isGameover = false;
    public bool isAntKill = false;

    public float normalBulletDamege = 1.0f;

    public Dictionary<string, GameObject> gameObjs = default;
    public override void Awake()
    {
        base.Awake();
        //여기서 싱글턴 인스턴스 생성
        Create();

    }
    void Start()
    {
        normalBulletDamege = 1f;
        isGameover = false;
        gameScore = 0;
        Score = 0;
    }
    void Update()
    {

        if (!isGameover)
        {
            Score = gameScore;
            
        }
    }

    protected override void Init()
    {
        base.Init();
        //여기서 게임 매니저가 초기화 된다.
        gameObjs = new Dictionary<string, GameObject>();
    }

    public void ScoreAdd()
    {
        if (isGameover && !isAntKill)
        {
            gameScore += 10;
        }
    }
}
