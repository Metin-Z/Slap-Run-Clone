using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    public LevelGenerator generator;
    public float distanceExponent =40;

    Vector3 generatePos;
    float basePackageExponent;

    private void Start()
    {
        //GameObject player =Instantiate(generator.player,Vector3.zero,Quaternion.identity);
        //player.transform.parent = transform;

        for (int i = 0; i < generator.levelLength; i++)
        {
            int x = Random.RandomRange(0, generator.packages.Count);

            generatePos = new Vector3(0,0,i * distanceExponent);
            GameObject spawnedPath = Instantiate(generator.packages[x], generatePos,Quaternion.identity);
            spawnedPath.transform.parent = transform;
            basePackageExponent = i * distanceExponent;
        }

        Vector3 bonusPos = new Vector3(generatePos.x, generatePos.y,generatePos.z + distanceExponent /2);
        GameObject bonusGame = Instantiate(generator.bonusStarter, bonusPos, Quaternion.identity);
        bonusGame.transform.parent = transform;

        for (int i = 0; i < generator.bonusLevelLength; i++)
        {
            int x = Random.RandomRange(0, generator.bonusPackages.Count);

            generatePos = new Vector3(0, 0, (i * distanceExponent) + distanceExponent +basePackageExponent);
            GameObject spawnedPath = Instantiate(generator.bonusPackages[x], generatePos, Quaternion.identity);
            spawnedPath.transform.parent = transform;
        }

        Vector3 bonusPart = new Vector3(generatePos.x, generatePos.y, generatePos.z + distanceExponent /2);
        GameObject finalGame = Instantiate(generator.finalGame, bonusPart, Quaternion.identity);
        finalGame.transform.parent = transform;

    }
}
