using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoardLevelPart : MonoBehaviour
{
    public BoardType boardType = BoardType.NONE;
    private Image boardImage = default;
    private PlayLevel playLevel = default;

    // Start is called before the first frame update
    void Start()
    {
        //ºò Æ®¶óÀÌ¾Þ±Û ¼±¾ð
        boardImage = gameObject.FindChildObj("normalCanonBase").GetComponentMust<Image>();



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
}
