using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public int level = default;
    public List<BoardLevelPart> boardLevelParts = default;


    private const float LEVEL_BOARD_DISTANCE_LIMIT = 10f;
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

        }   //loop: ���� �������� ���� ������ ��� ĳ���ϴ� ����

    }

    // Update is called once per frame
    void Update()
    {

    }

    //! ���� Ÿ���� �޾Ƽ� �ش� Ÿ�԰� ���� Ÿ���� ������ �����ϴ� �Լ�
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

        }   //loop: ���� Ÿ���� ������ ã���ִ� ����

        return sameTypes;
    }   //GetSameTypePuzzle()

    //! ���� ����� ������ ã���ִ� �Լ�
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

            }   // if: ���� ����� ������ ĳ���Ѵ�. 
            index++;

        }   //loop: 
        GFunc.Log($"{LEVEL_BOARD_DISTANCE_LIMIT - minDistance}");
        if (LEVEL_BOARD_DISTANCE_LIMIT < minDistance)
        {
            result = default;
        }   //if �ʹ� �ָ� �ִ� ������ �����Ѵ�.

        return result;
    }   //GetCloseSameTypePuzzle
}
