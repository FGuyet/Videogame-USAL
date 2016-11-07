using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class LevelManager : MonoBehaviour {

    static List<Dictionary<string, float>> LevelSettings = new List<Dictionary<string, float>>();
    public static int CurrentLevel = 0;
    static OpponentManager om;
    public GameObject player;

    // Use this for initialization
    void Start () {
        om = gameObject.GetComponent<OpponentManager>();

        Dictionary<string, float> level1 = new Dictionary<string, float> {
                                                    {"nbOpponent1", 1 },
                                                    {"nbOpponent2", 1 },
                                                    {"nbOpponent3", 1 },
                                                    {"nbOpponent4", 1 },
                                                    {"opponentSpawnSpeed", 1 },
                                                    {"opponentSpawnMult", 1 },
                                                };

        Dictionary<string, float> level2 = new Dictionary<string, float> {
                                                    {"nbOpponent1", 1 },
                                                    {"nbOpponent2", 1 },
                                                    {"nbOpponent3", 1 },
                                                    {"nbOpponent4", 1 },
                                                    {"opponentSpawnSpeed", 1 },
                                                    {"opponentSpawnMult", 1 },
                                                };

        Dictionary<string, float> level3 = new Dictionary<string, float> {
                                                    {"nbOpponent1", 1 },
                                                    {"nbOpponent2", 1 },
                                                    {"nbOpponent3", 1 },
                                                    {"nbOpponent4", 1 },
                                                    {"opponentSpawnSpeed", 1 },
                                                    {"opponentSpawnMult", 1 },
                                                };

        Dictionary<string, float> level4 = new Dictionary<string, float> {
                                                    {"nbOpponent1", 1 },
                                                    {"nbOpponent2", 1 },
                                                    {"nbOpponent3", 1 },
                                                    {"nbOpponent4", 1 },
                                                    {"opponentSpawnSpeed", 1 },
                                                    {"opponentSpawnMult", 1 },
                                                };
        //Load level composition
        LevelSettings.Add(level1);
        LevelSettings.Add(level2);
        LevelSettings.Add(level3);
        LevelSettings.Add(level4);

        StartLevel(1);
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            OpponentManager.KillAll();

            SpawnPlayer();

            StartLevel(1);
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

}
