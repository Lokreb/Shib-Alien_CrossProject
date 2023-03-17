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

    [System.Serializable]
    public class ListWarperBoss

    {
        public List<GameObject> BossRoomList;
    }
    [SerializeField] List<ListWarperBoss> Boss_List;

    int randomIndex;
    public int Floor_number = 5;
    int actual_floor = 0;
    int range;
    public GameObject resetPrefab = null;
     int iteration = 0;
    static public bool GoBoss =false;
    static public bool timerBoss = false;



    void Start()
    {
        range = Floor_List[actual_floor].RoomList.Count;
        randomIndex = Random.Range(0, range);

        SelectARoom();
        //SelectBoss();


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
        if (iteration >= 1)
        {
            GoBoss = true;
        }
        Debug.Log("Le scan se fait!");
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
        timerBoss = true;
    }

   
}
