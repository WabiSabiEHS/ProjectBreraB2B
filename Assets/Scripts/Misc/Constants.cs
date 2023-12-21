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
    public static string CHANGE_BUTTON_TRIGGER = "ChangeButtonTrigger";

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
    public static string SM_BOOL_HAS_WON = "SMHasWon";

    //---SOUND MANAGER---
    public static string PLAY_SOUND = "PlaySound";
    public static string PLAY_LOOP_SOUND = "PlayLoopSound";

    public static string SFX_CLUE_NOTE = "ClueNote";
    public static string SFX_CODE_NUMBER = "CodeNumber";
    public static string SFX_CODE_NUMBER_CONDITION = "CodeNumberCondition";
    public static string SFX_GAME_15 = "Game15SFX";
    public static string SFX_NEG_FEEDBACK = "NegFeedback";
    public static string SFX_TAP_MINIGAME = "TapMinigame";
    public static string SFX_TAP_SKIP = "TapSkip";
    public static string SFX_TAP_UI = "TapUI";
    public static string SFX_WIN_CONDITION = "WinConditionSFX";
    public static string MUS_ENDING = "EndingMusic";

    //---PAINTINGS MANAGER---
    public static string ACTIVATE_PUZZLE = "ActivatePuzzle";
    public static string CHANGE_PAINTING_DESCRIPTION = "ChangeDescription";
    public static string UNLOCK_PUZZLE = "UnlockPainting";
    public static string ACTIVATE_NEW_NOTES = "ActivateNewNotes";

    //---NOTES MANAGER---
    public static string NOTE_PICK_UP = "NotePickUp";

    //---COLOR MINIGAME---
    public static string COLOR_MG_CHANGE_SELECTED_COLOR = "ChangeSelectedColor";
    public static string COLOR_MG_DELETE_PIECE = "ChangeSelectedColor";
    public static string COLOR_MG_TILE_COMPLETED = "ColorTilesCompleted";

    //---PUZZLE MINIGAME---
    public static string PUZZLE_MG_PIECE_IN_PLACE = "PieceCorrectPlace";

    //---15 GAME---
    public static string GO15_MG_SWAP_TILES = "SwapTiles";
    public static string GO15_MG_CHECK_WIN = "GO15CheckWin";
}
