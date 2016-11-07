using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class LevelManager : MonoBehaviour {

    static List<Dictionary<string, float>> LevelSettings = new List<Dictionary<string, float>>();
    public static int CurrentLevel = 0;
    public int defaultStartLevel = 1; 
    static OpponentManager om;
    public GameObject player;

    public TextAsset textFile;     // drop your file here in inspector

    // Use this for initialization
    void Start () {
        om = gameObject.GetComponent<OpponentManager>();

        LoadLevelSettings();

        StartLevel(defaultStartLevel);
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            OpponentManager.KillAll();

            SpawnPlayer();

            StartLevel(defaultStartLevel);
        }

	}

    private void SpawnPlayer()
    {
        GameObject instance = Instantiate(player);

        //Set canvas, initial position, and speed 
        instance.transform.SetParent(GameObject.Find("GameCanvas").transform);
        instance.transform.localPosition = Vector2.zero;
        instance.transform.localScale = new Vector2(1,1);
    }

    public static void NextLevel()
    {
        StartLevel(CurrentLevel + 1);
    }

    public static void StartLevel(int level)
    {
        CurrentLevel = level;
        om.LoadOpponentSettings(LevelSettings[level-1]);
        GameObject.Find("LevelText").GetComponent<Text>().text = "Level " + level;
    }

    private void LoadLevelSettings()
    {
        string text = textFile.text;
        Debug.Log(text);

        string[] lines = text.Split('\n');
        foreach (string l in lines)
        {
            string[] param = l.Split('	');
            int nbOpponent1 = int.Parse(param[0]);
            int nbOpponent2 = int.Parse(param[1]);
            int nbOpponent3 = int.Parse(param[2]);
            int nbOpponent4 = int.Parse(param[3]);
            float opponentSpawnSpeed = float.Parse(param[5].Replace(',','.'));
            int opponentSpawnMult = int.Parse(param[4]);

            Debug.Log(  "LEVEL" + (LevelSettings.Count + 1) +
                        " 1:" + nbOpponent1 +
                        " 2:" + nbOpponent2 +
                        " 3:" + nbOpponent3 +
                        " 4:" + nbOpponent4 +
                        " rate:" + opponentSpawnSpeed +
                        " mult:" + opponentSpawnMult
                        );

            Dictionary <string, float> level = new Dictionary<string, float>
            {
                {"nbOpponent1", nbOpponent1},
                {"nbOpponent2", nbOpponent2},
                {"nbOpponent3", nbOpponent3},
                {"nbOpponent4", nbOpponent4},
                {"opponentSpawnSpeed", opponentSpawnSpeed},
                {"opponentSpawnMult", opponentSpawnMult},
            };
            LevelSettings.Add(level);
        }

        Debug.Log("Level Settings Loaded");
    }
}