using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue {
    public Monologue[] DialogueParts;
}

[System.Serializable]
public class Monologue
{
    public string Name;

    public Sprite Sprite; 

    [TextArea(3, 10)]
    public string[] Sentences;
}
