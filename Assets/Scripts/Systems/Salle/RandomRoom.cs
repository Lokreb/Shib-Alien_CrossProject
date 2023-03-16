using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoom : MonoBehaviour
{
    [System.Serializable]
    public class ListWarperRoom
     
    {
        public List<GameObject> RoomList;
    }
    [SerializeField] List<ListWarperRoom> Floor_List;
    public class ListWarperBoss

    {
        public List<GameObject> BossRoomList;
    }
    [SerializeField] List<ListWarperBoss> Boss_List;

    int randomIndex;
    public int Floor_number = 5;
    int actual_floor = 0;
    int range;
    GameObject resetPrefab = null;
     int iteration = 0;
    static public bool GoBoss =false;



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
        iteration++;
        if (iteration >= 3)
        {
            GoBoss = true;
        }
        Debug.Log("AstarPath il passe");
        AstarPath.active.Scan();




    }

    public void SelectBoss()
        {
        if (resetPrefab != null)
        {
            resetPrefab.SetActive(false);
            range = Boss_List[actual_floor].BossRoomList.Count;
            randomIndex = Random.Range(0, range);
        }
        GameObject randomPrefab = Boss_List[actual_floor].BossRoomList[randomIndex];
        randomPrefab.SetActive(true);
        resetPrefab = randomPrefab;
        Floor_List[actual_floor].RoomList.RemoveAt(randomIndex);
        iteration = 0;
        actual_floor++;
        GoBoss = false;
        

    }

   
}
