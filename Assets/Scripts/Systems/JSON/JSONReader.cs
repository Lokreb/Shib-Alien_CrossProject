using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    [System.Serializable]
    /*public class Objets
    {
        public string nom;
        public string type;
        public string[] etats;
        public int x;
        public int y;
        public Image image;

    }*/

    public class Player
    {
        public string nom;
        public string type;
        public int[] pv;
        public int degats;
        public float atkspeed;
        public float firerate;
        public float speed;
        public int projectile;
        public string[] pattern;
        public int rebond;
        public Image img;
    }

    [System.Serializable]
    public class Image
    {
        public string src;
        public int dimX;
        public int dimY;
    }

    [System.Serializable]
    public class Monstres
    {
        public string nom;
        public string type;
        public int[] pv;
        public int degats;
        public Image img;

    }

    [System.Serializable]
    public class Boss
    {
        public string nom;
        public string type;
        public int degats;
        public Image img;
    }

    [System.Serializable]
    public class BonusPassifs
    {
        public string nom;
        public string type;
        public Image img;
    }

    [System.Serializable]
    public class BonusActifs
    {
        public string nom;
        public string type;
        public int degats;
        public float cooldown;
        public Image img;
    }


    [System.Serializable]

    public class ListeMonstres
    {
        public Monstres[] monstres;
    }

    public ListeMonstres MyListeObjets = new ListeMonstres();


    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Data");
        MyListeObjets = JsonUtility.FromJson<ListeMonstres>(jsonFile.text);
    }
}
