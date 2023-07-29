using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkin : MonoBehaviour
{
    public SkinnedMeshRenderer meshRenderer;
    public bool shoe;
    private void Start()
    {
        Material material;

        List<Material> list = GameManager.instance.enemyRandomMats;

        material = list[Random.Range(0, list.Count)];


        if (shoe)
        {
            Material[] mats = meshRenderer.materials;
            mats[1] = material;
            meshRenderer.materials = mats;
        }
        else
        {
            meshRenderer.material = material;
        }
    }
}
