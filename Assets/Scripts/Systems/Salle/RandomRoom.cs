using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoom : MonoBehaviour
{
    [SerializeField]  List<GameObject> prefabList;

    void Start()
    {
        int randomIndex = Random.Range(0, prefabList.Count);
        GameObject randomPrefab = prefabList[randomIndex];
        randomPrefab.SetActive(true);
    }
}
