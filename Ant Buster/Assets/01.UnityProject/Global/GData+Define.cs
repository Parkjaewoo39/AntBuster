using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GData
{    
    public const string SCENE_NAME_TITLE = "00.TitleScene";

    public const string SCENE_NAME_LOAD_STAGE_ONE = "11.StageScene1";

    public const string SCENE_NAME_LOAD_STAGE_Two = "12.StageScene2";


    public const string SCENE_NAME_STAGE_ONE = "02.PlayStage1";

    public const string SCENE_NAME_STAGE_TWO = "03.PlayStage2";

    public const string OBJ_NAME_CURRENT_LEVEL = "Level_1";

    public const string LEVEL_PART_NAME = "BoardObject";

    public const string TOWER_BOARD = "BoardObject";

    public static int gameScore = 0;

    public static int life = 3;

    public static int bonusTime = 5000;
}

public enum PuzzleType 
{
    //enumŸ������ �����ϸ�
    //����Ÿ���� �����ϸ� ���ڶ� 1:1 ��������
    //-1�� ���ָ� �� Ÿ���� 0�� ��.
    //-1�� �����ϸ� ���������� ����
    //������ �Ʒ��� ���� Ÿ���� �þ.
    //none���� 0���� �������� 1���� �������� �ʱ�ȭ �������� ����� �ִ�?
    NONE = -1,
    PUZZLE_BIG_TRIANGLE,
    PUZZLE_SQUARE,
    PUZZLE_MIDDLE_TRIANGLE,
    //Puzzle_Parallelogram
    PUZZLE_PARALLELOGRAM,
    PUZZLE_SMALL_TRIANGLE,
}   //PuzzleType()

public enum BoardType 
{
    NONE = -1,
    BOARD_PEACE,
}