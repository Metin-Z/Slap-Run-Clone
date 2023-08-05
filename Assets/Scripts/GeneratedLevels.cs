using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "LevelGenerator")]
public class LevelGenerator : ScriptableObject
{
    public GameObject player;

    public int levelLength;
    public List<GameObject> packages;

    public int bonusLevelLength;
    public List<GameObject> bonusPackages;

    public GameObject bonusStarter;
    public GameObject finalGame;
}
