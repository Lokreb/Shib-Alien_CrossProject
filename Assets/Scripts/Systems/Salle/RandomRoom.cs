using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoom : MonoBehaviour
{
    [System.Serializable]
    public class ListWarper
    {
        public List<GameObject> RoomList;
    }
    [SerializeField] List<ListWarper> Floor_List;

    int randomIndex;
    public int Floor_number = 5;
    int actual_floor = 0;
    int range;
    GameObject resetPrefab = null;



    void Start()
    {
        range = Floor_List[actual_floor].RoomList.Count;
        randomIndex = Random.Range(0, range);
        SelectARoom();


    } 

    public void SelectARoom()
    {
        if (resetPrefab != null)
        {
            resetPrefab.SetActive(false);
            range = Floor_List[actual_floor].RoomList.Count;
            randomIndex = Random.Range(0, range);
        }
            GameObject randomPrefab = Floor_List[actual_floor].RoomList[randomIndex];
            randomPrefab.SetActive(true);
            resetPrefab = randomPrefab;
            Floor_List[actual_floor].RoomList.RemoveAt(randomIndex);
             
            


    }

   
}
