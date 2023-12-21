using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialogue
{
    public NPCMonologue[] NPCMonologues;
}

[System.Serializable]
public class NPCMonologue
{
    public Sprite NPCSprite;

    [TextArea(3, 10)]
    public string NPCPhrase;
}
