using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class Level
{
    [Range(1, 9)]
    public int partCount = 9;

    [Range(0, 9)]
    public int deathPartCount = 1;
}

[CreateAssetMenu(fileName ="New Satge")]
public class Stage : ScriptableObject
{
    public Color stageBackgroundColor = Color.white;
    public Color stageLevelPartColor = Color.green;
    public Color stageBallColor = Color.magenta;

    public List<Level> levels = new List<Level>();
}
