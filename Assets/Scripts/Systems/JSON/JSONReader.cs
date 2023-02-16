using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    [System.Serializable]

    public class Player
    {
        public string nom;
        public int pv;
        public int degats;
        public float atkspeed;
        public float firerate;
        public float speed;
        public int projectile;
        public string[] pattern;
        public int rebond;
        public string image;
    }

    [System.Serializable]
    public class Monstres
    {
        public string nom;
        public int[] pv;
        public int degats;
        public int id;
        public string image;

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
        public int degats;
        public float cooldown;
        public string image;
    }


    [System.Serializable]

    public class ListeMonstres
    {
        public Monstres[] monstres;
    }

    [System.Serializable]

    public class ListeBoss
    {
        public Boss[] boss;
    }

    [System.Serializable]

    public class ListeBonus
    {
        public Bonus[] bonus;
    }

    public Player joueur = new Player();
    public ListeMonstres monstreListe = new ListeMonstres();
    public ListeBoss bossListe = new ListeBoss();

    public ListeBonus bonusListe = new ListeBonus();


    void Start()
    {
        /*TextAsset jsonFile1 = Resources.Load<TextAsset>("Player");
        joueur = JsonUtility.FromJson<Player>(jsonFile1.text);
        Debug.Log(joueur.nom);*/

        /*TextAsset jsonFile2 = Resources.Load<TextAsset>("Monsters");
        monstreListe = JsonUtility.FromJson<ListeMonstres>(jsonFile2.text);
        Debug.Log(monstreListe.monstres[2].nom);*/

        /*TextAsset jsonFile3 = Resources.Load<TextAsset>("Boss");
        bossListe = JsonUtility.FromJson<ListeBoss>(jsonFile3.text);
        Debug.Log(bossListe.boss[1].nom);*/

        /*TextAsset jsonFile4 = Resources.Load<TextAsset>("Bonus");
        bonusListe = JsonUtility.FromJson<ListeBonus>(jsonFile4.text);*/
    }
}
