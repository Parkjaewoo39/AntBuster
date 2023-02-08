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

    private bool isClicked = false; //확인용 bool타입 선언
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
        isClicked = false;   //start에서 한번더 초기화

        objRect = gameObject.GetRect();

        initBoardZone = transform.parent.gameObject.GetComponentMust<InitBoardScript>();
        //Debug.Log($"INITBOARDZONE TEST : {initBoardZone.name}");

        //playLevel = GameManager.Instance.gameObjs[GData.LEVEL_PART_NAME].GetComponentMust<PlayLevel>();

        boardImage = gameObject.FindChildObj("normalCannon").GetComponentMust<Image>();


        //퍼즐 이미지 이름에 따라서 퍼즐의 타입이 정해진다.
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

    //! 마우스 버튼을 눌렀을 때 동작하는 함수
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;

        //gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f); 
         GFunc.Log($"{gameObject.name}을 선택했다");
    }   //OnPointerDown()

    //! 마우스 버튼을 손을 땠을 때 동작하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
         GFunc.Log($"{gameObject.name}을 선택 해제했다");
        //여기서 레벨이 가지고 있는 퍼즐 리스트를 순회해서 가장 가까운 퍼즐을 찾아온다.
        BoardLevelPart closeLevelBoard = playLevel.GetCloseSameTypeBoard(boardType, transform.position);


        if (closeLevelBoard == null || closeLevelBoard == default)
        {
            return;
        }
        GFunc.Log($"{closeLevelBoard.name}이 가장 가까이에 있습니다.");
        transform.position = closeLevelBoard.transform.position;
    }   //OnPointerUp()

    //! 마우스를 드래그 중일 때 동작하는 함수

    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            //
            gameObject.AddAnchoredPos(eventData.delta / initBoardZone.parentCanvas.scaleFactor);
        }
    }

    
}
