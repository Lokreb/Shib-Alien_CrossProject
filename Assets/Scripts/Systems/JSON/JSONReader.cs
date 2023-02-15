using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    [System.Serializable]
    public class Objets
    {
        public string nom;
        public string type;
        public string[] etats;
        public int x;
        public int y;
        public bool mobile;
        public Image image;

    }

    [System.Serializable]
    public class Image
    {
        public string src;
        public int dimX;
        public int dimY;
        public Clefs clefs;
    }

    [System.Serializable]

    public class Clefs
    {
        public int x;
        public int y;
    }

    [System.Serializable]

    public class ListeObjets
    {
        public Objets[] objects;
    }

    public ListeObjets MyListeObjets = new ListeObjets();


    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("objets");
        MyListeObjets = JsonUtility.FromJson<ListeObjets>(jsonFile.text);
    }
}
