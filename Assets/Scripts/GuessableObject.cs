using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessableObject : MonoBehaviour
{
    public bool isCorrectGuess;
    [SerializeField]
    private Material highlightMaterial;
    public int gmIndex;

    public void Guessing()
    {
        foreach(MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
        {
            List<Material> mats = new List<Material>();
            mats.AddRange(mr.materials);
            mats.Add(highlightMaterial);
            mr.materials = mats.ToArray();
        }
        foreach (SkinnedMeshRenderer mr in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            List<Material> mats = new List<Material>();
            mats.AddRange(mr.materials);
            mats.Add(highlightMaterial);
            mr.materials = mats.ToArray();
        }
        if(GameManager.ActiveLevel != "LEVEL_THREE") GameManager.Instance.ForceSetCaption(name);
    }

    public void StopGuessing()
    {
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
        {
            List<Material> mats = new List<Material>();
            mats.AddRange(mr.materials);
            mats.RemoveAt(mats.Count - 1);
            mr.materials = mats.ToArray();
        }
        foreach (SkinnedMeshRenderer mr in GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            List<Material> mats = new List<Material>();
            mats.AddRange(mr.materials);
            mats.RemoveAt(mats.Count - 1);
            mr.materials = mats.ToArray();
        }
        GameManager.Instance.ForceSetCaption("");
    }

    private void OnTriggerEnter(Collider other)
    {
        Lvl1GM.vistedBuildings[gmIndex] = true;
    }
}
