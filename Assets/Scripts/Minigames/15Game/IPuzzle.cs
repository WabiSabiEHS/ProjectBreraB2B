using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPuzzle 
{
    public void StartGame(object[] param);
    public void EndGame(object[] param);
    public void ResetGame(object[] param);

}
