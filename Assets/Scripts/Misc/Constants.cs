using System.Collections;
using System.Collections.Generic;

public static class Constants
{
    //---GAME MANAGER---
    public static string TOGGLE_PLAYER_UI = "TogglePlayerUI";
    public static string TOGGLE_PAINTING_DESCRIPTION = "ToggleDescription";

    //---DIALOGUE MANAGER---
    public static string START_NPC_DIALOGUE = "StartNPCDialogue";
    public static string SET_NPC_LANGUAGE = "StartNPCDialogue";

    //---CAMERA------
    //rotation
    public static string UPDATE_CAMERA_ROTATION = "UpdateCameraRotation";

    //zoom
    public static string UPDATE_CAMERA_ZOOMING = "UpdateCameraZooming";
    public static string STOP_CAMERA_ZOOMING = "StopCameraZooming";

    //---SAVE MANAGER---
    public static string SAVE_FLOAT = "SaveFloat";
    public static string LOAD_FLOAT = "LoadFloat";

    public static string SAVE_BOOL = "SaveBool";
    public static string LOAD_BOOL = "Load_Bool";


    public static string SM_BOOL_LANGUAGE = "Language";

    //---SOUND MANAGER---
    public static string PLAY_SOUND = "PlaySound";

    //---PAINTINGS MANAGER---
    public static string ACTIVATE_PUZZLE = "ActivatePuzzle";
    public static string CHANGE_PAINTING_DESCRIPTION = "ChangeDescription";

    //---COLOR MINIGAME---
    public static string COLOR_MG_CHANGE_SELECTED_COLOR = "ChangeSelectedColor";
    public static string COLOR_MG_DELETE_PIECE = "ChangeSelectedColor";
    public static string COLOR_MG_TILE_COMPLETED = "ColorTilesCompleted";

    //---PUZZLE MINIGAME---
    public static string PUZZLE_MG_PIECE_IN_PLACE = "PieceCorrectPlace";
}
