using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public int level = default;
    public List<BoardLevelPart> boardLevelParts = default;


    private const float LEVEL_BOARD_DISTANCE_LIMIT = 1f;
    public void Awake()
    {
        //GameManager.Instance.Create();
        GameManager.Instance.gameObjs.Add(gameObject.name, gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        boardLevelParts = new List<BoardLevelPart>();
        for (int i = 0; i < transform.childCount; i++)
        {
            boardLevelParts.Add(transform.GetChild(i).
                gameObject.GetComponentMust<BoardLevelPart>());

        }   //loop: 레벨 하위에서 퍼즐 파츠를 모두 캐싱하는 루프

    }

    // Update is called once per frame
    void Update()
    {

    }

    //! 퍼즐 타입을 받아서 해당 타입과 같은 타입의 퍼즐을 리턴하는 함수
    private List<BoardLevelPart> GetSameTypeBoard(BoardType boardType)
    {
        List<BoardLevelPart> sameTypes = new List<BoardLevelPart>();
        foreach (var boardLvPart in boardLevelParts)
        {
            if (boardLvPart.boardType.Equals(boardType))
            {

                sameTypes.Add(boardLvPart);
            }
            else { continue; }

        }   //loop: 같은 타입의 퍼즐을 찾아주는 루프

        return sameTypes;
    }   //GetSameTypePuzzle()

    //! 가장 가까운 퍼즐을 찾아주는 함수
    public BoardLevelPart GetCloseSameTypeBoard(BoardType boardType, Vector3 boardWorldPos)
    {
        List<BoardLevelPart> sameTypes = GetSameTypeBoard(boardType);

        float minDistance = float.MaxValue;
        float distance = float.MaxValue;
        int index = 0;
        BoardLevelPart result = default;
        foreach (var boardLvPart in sameTypes)
        {
            distance = Mathf.Abs(
                (boardLvPart.transform.position -
                boardWorldPos).magnitude);


            if (distance <= minDistance)
            {
                minDistance = distance;
                result = boardLvPart;

            }   // if: 가장 가까운 퍼즐을 캐싱한다. 
            index++;

        }   //loop: 
        GFunc.Log($"{LEVEL_BOARD_DISTANCE_LIMIT - minDistance}");
        if (LEVEL_BOARD_DISTANCE_LIMIT < minDistance)
        {
            result = default;
        }   //if 너무 멀리 있는 퍼즐은 생략한다.

        return result;
    }   //GetCloseSameTypePuzzle
}
