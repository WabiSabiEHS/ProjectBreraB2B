using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private int m_PiecesCount;
    private int m_PiecesCompletedCount = 0;

    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.PUZZLE_MG_PIECE_IN_PLACE, CompletedPiece);
    }

    public void CompletedPiece(object[] param)
    {
        m_PiecesCompletedCount++;
        if (m_PiecesCompletedCount == m_PiecesCount)
        {
            GameManager.instance.EventManager.TriggerEvent(Constants.PLAY_SOUND, Constants.SFX_WIN_CONDITION);

            Debug.Log("WIN PUZZLE");
        }
    }
}
