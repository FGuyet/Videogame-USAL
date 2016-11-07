using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class OpponentManager : MonoBehaviour {

    [System.Serializable]
    public class OpponentTypes
    {
        public GameObject[] Types;
    }
    public GameObject[] opponentTypes;

    public int[] nbOpponentsToSpawn = new int[4] { 10, 10, 10, 10 };
    public float OpponentSpawnSpeed = 0.3f;
    public int OpponentSpawnedAtSameTime = 1;

    static List<GameObject> OpponentsToSpawnList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (OpponentsToSpawnList.Count == 0)
        {
            CancelInvoke("SpawnNextOpponent");
        }

        if (OpponentsToSpawnList.Count == 0 && GameObject.FindGameObjectsWithTag("Opponent").Length == 0)
        {
            Debug.Log("End Level");
            LevelManager.NextLevel();
        }

    }

    void SetOpponentsList()
    {
        //CreateList
        OpponentsToSpawnList.Clear();

        for (int type = 0; type < opponentTypes.Length; type++ )
        {
            int nb = nbOpponentsToSpawn[type];

            while (nb != 0)
            {
                Debug.Log(nb);
                GameObject opponent = Instantiate(opponentTypes[type]);
                opponent.SetActive(false);
                OpponentsToSpawnList.Add(opponent);
                nb--;                
            }
        }

        //Shuffle
        for (int i = 0; i < OpponentsToSpawnList.Count; i++)
        {
            GameObject temp = OpponentsToSpawnList[i];
            int randomIndex = UnityEngine.Random.Range(i, OpponentsToSpawnList.Count);
            OpponentsToSpawnList[i] = OpponentsToSpawnList[randomIndex];
            OpponentsToSpawnList[randomIndex] = temp;
        }
    }

    private void SpawnNextOpponent()
    {
        Vector2 centerPosition = new Vector2(Screen.width / 2, Screen.height/2);
        Vector2 spawnPosition = 1.1f*Mathf.Sqrt(2)*(UnityEngine.Random.insideUnitCircle.normalized * Screen.width/2) + centerPosition;

        //Pop
        GameObject opponent = OpponentsToSpawnList[0];
        OpponentsToSpawnList.RemoveAt(0);

        Vector2 localScale = opponent.transform.localScale;

        opponent.transform.SetParent(GameObject.Find("GameCanvas").transform);
        opponent.transform.localScale = localScale;
        opponent.transform.position = spawnPosition;
        opponent.SetActive(true);

        if (OpponentsToSpawnList.Count == 0)
        {
            CancelInvoke("SpawnNextOpponent");
        }
    }


    public void LoadOpponentSettings(Dictionary<string, float> settings)
    {
        Debug.Log("LoadOpponentSettings");
        nbOpponentsToSpawn = new int[4] {(int)settings["nbOpponent1"], (int)settings["nbOpponent2"], (int)settings["nbOpponent3"], (int)settings["nbOpponent4"]};
        OpponentSpawnSpeed = settings["opponentSpawnSpeed"];
        OpponentSpawnedAtSameTime = (int) settings["opponentSpawnMult"];

        SetOpponentsList();
        InvokeRepeating("SpawnNextOpponent", 5.0f, OpponentSpawnSpeed);
    }


    static public void KillAll()
    {
        while (OpponentsToSpawnList.Count > 0)
        {
            //pop
            GameObject opponent = OpponentsToSpawnList[0];
            OpponentsToSpawnList.RemoveAt(0);
            GameObject.Destroy(opponent);
        }

        GameObject[] opponents = GameObject.FindGameObjectsWithTag("Opponent");
        foreach(GameObject op in opponents)
        {
            GameObject.Destroy(op);
        }
    }
}
