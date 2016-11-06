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

    List<GameObject> OpponentsToSpawnList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        SetOpponentsList();
        InvokeRepeating("SpawnNextOpponent", 2.0f, OpponentSpawnSpeed);
    }
	
	// Update is called once per frame
	void Update () {

	
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
}
