using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Levels/Create Level Settings")]
public class LevelSettings : ScriptableObject
{
    public Color BallColor;
    public Color BeamColor;
    public Color SpawnPlatformColor;
    public Color MainPlatformColor1;
    public Color FinishPlatformColor;
    public int LevelCount;
}
