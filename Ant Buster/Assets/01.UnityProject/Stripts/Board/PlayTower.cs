using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayTower : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler//, IPointerMoveHandler
{         
    private BoardType boardType = BoardType.NONE;
    private Image boardImage = default;
    private PlayLevel playLevel = default;

    private bool isClicked = false; //Ȯ�ο� boolŸ�� ����
    private RectTransform objRect = default;
    private InitBoardScript initBoardZone = default;

    public Canvas canvas;
    //private PlayLevel playLevel = default;
    //List<PuzzleLevelPart> puzzleLevelParts
    // Start is called before the first frame update
    void Start()
    {
        
        playLevel = GameManager.Instance.gameObjs[GData.TOWER_BOARD].
            GetComponentMust<PlayLevel>();
        isClicked = false;   //start���� �ѹ��� �ʱ�ȭ

        objRect = gameObject.GetRect();

        initBoardZone = transform.parent.gameObject.GetComponentMust<InitBoardScript>();
        //Debug.Log($"INITBOARDZONE TEST : {initBoardZone.name}");

        //playLevel = GameManager.Instance.gameObjs[GData.LEVEL_PART_NAME].GetComponentMust<PlayLevel>();

        boardImage = gameObject.FindChildObj("normalCannon").GetComponentMust<Image>();


        //���� �̹��� �̸��� ���� ������ Ÿ���� ��������.
        switch (boardImage.sprite.name)
        {
            case "NormalCannon":
                boardType = BoardType.BOARD_PEACE;
                break;            

            default:
                boardType = BoardType.NONE;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //! ���콺 ��ư�� ������ �� �����ϴ� �Լ�
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;

        //gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f); 
         GFunc.Log($"{gameObject.name}�� �����ߴ�");
    }   //OnPointerDown()

    //! ���콺 ��ư�� ���� ���� �� �����ϴ� �Լ�
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
         GFunc.Log($"{gameObject.name}�� ���� �����ߴ�");
        //���⼭ ������ ������ �ִ� ���� ����Ʈ�� ��ȸ�ؼ� ���� ����� ������ ã�ƿ´�.
        BoardLevelPart closeLevelBoard = playLevel.GetCloseSameTypeBoard(boardType, transform.position);


        if (closeLevelBoard == null || closeLevelBoard == default)
        {
            return;
        }
        GFunc.Log($"{closeLevelBoard.name}�� ���� �����̿� �ֽ��ϴ�.");
        transform.position = closeLevelBoard.transform.position;
    }   //OnPointerUp()

    //! ���콺�� �巡�� ���� �� �����ϴ� �Լ�

    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            //
            gameObject.AddAnchoredPos(eventData.delta / initBoardZone.parentCanvas.scaleFactor);
        }
    }

    
}
