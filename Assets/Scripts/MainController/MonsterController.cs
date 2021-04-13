using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MonsterController : MonoBehaviour
{
    #region Member Variables

    private List<GameObject> Monsters;

    #endregion

    #region MonoBehaviour Events

    void Awake()
    {
        Monsters = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }

    #endregion

    #region Public Methods

    public void Reset()
    {
        foreach (GameObject monster in Monsters)
        {
            GameObject.Destroy(monster);
        }

        Monsters.Clear();
    }

    public void AddMonster(GameObject newMonster)
    {
        Monsters.Add(newMonster);
    }

    public void RemoveMonster(GameObject removeMonster)
    {
        Monsters.Remove(removeMonster);
    }

    public GameObject[] GetMonsters()
    {
        return Monsters.ToArray();
    }

    public GameObject GetMonsterAtTile(int x, int y)
    {
        foreach (GameObject monster in Monsters)
        {
            if
            (
                (monster.GetComponent<Transform>().position.x == x) &&
                (monster.GetComponent<Transform>().position.y == y)
            )
            {
                return monster;
            }
        }

        return null;
    }

    #endregion

    #region Private Methods

    private void CheckState()
    {
        if (GetComponent<GameStateController>().CurrentState == GameState.PLAYING)
        {
            MonsterTurnCheck();
        }
    }

    private void MonsterTurnCheck()
    {
        if (GetComponent<GameStateController>().CurrentTurnState == TurnState.ENEMY_TURN)
        {
            foreach (GameObject monster in Monsters)
            {
                monster.GetComponent<MonsterAI>().PerformAction();
            }

            GetComponent<GameStateController>().IncrementTurnState();
        }
    }

    #endregion
}
