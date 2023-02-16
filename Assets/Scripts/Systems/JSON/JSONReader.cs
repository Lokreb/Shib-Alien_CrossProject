using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JSONReader : MonoBehaviour
{
    [System.Serializable]
    public class Player
    {
        public string nom;
        public int pv;
        public int degats;
        public float atkspeed;
        public float projectilespeed;
        public float speed;
        public int projectile;
        public List<string> pattern = new List<string>();
        public int rebond;
        public string image;
    }

    [System.Serializable]
    public class Monstres
    {
        public string nom;
        public int degats;
        public List<EtageInfo> etage = new List<EtageInfo>();
        public int id;
        public string image;

    }

    [System.Serializable]
    public class EtageInfo
    {
        public string id;
        public int pv;
    }

    [System.Serializable]
    public class Boss
    {
        public string nom;
        public int degats;
        public int id;
        public string image;
    }

    [System.Serializable]
    public class Bonus
    {
        public string nom;
        public int type;
        public int id;
        public float increase;
        public int valeur;
        public int degats;
        public float cooldown;
        public string image;
    }


    [System.Serializable]
    public class ListeMonstres
    {
        public List<Monstres> monstres = new List<Monstres>();
    }

    [System.Serializable]
    public class ListeBoss
    {
        public List<Boss> boss = new List<Boss>();
    }

    [System.Serializable]
    public class ListeBonus
    {
        public List<Bonus> bonus = new List<Bonus>();
    }

    public TextAsset playerData;
    public TextAsset monstreData;
    public TextAsset bossData;
    public TextAsset bonusData;

    public Player joueur = new Player();
    public ListeMonstres monstreListe = new ListeMonstres();
    public ListeBoss bossListe = new ListeBoss();
    public ListeBonus bonusListe = new ListeBonus();


    void Start()
    {
        joueur = JsonConvert.DeserializeObject<Player>(playerData.text);
        monstreListe.monstres = JsonConvert.DeserializeObject<List<Monstres>>(monstreData.text);
        bossListe.boss = JsonConvert.DeserializeObject<List<Boss>>(bossData.text);
        bonusListe.bonus = JsonConvert.DeserializeObject<List<Bonus>>(bonusData.text);
    }
}
