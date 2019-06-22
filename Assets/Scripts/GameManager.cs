using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManagerAsbtract : MonoBehaviour
{

    #region GAMEMANAGESTUFF   
    public float bottomBound = -13.5f;
    public float topBound = 16.5f;
    public float leftBound = -23.5f;
    public float rightBound = 23.5f;

    [Header("Enemy settings")]
    public GameObject enemyShipPrefab;
    public float enemySpeed = 1f;

    [Header("Spawn settings")]
    public int enemyShipCount = 1;
    public int enemyShipIncrement = 1;

    protected int count = 0;
    protected FPS fps;

    public static GameManagerAsbtract instance;

    #endregion

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    protected void Init()
    {
        fps = GetComponent<FPS>();
        AddShips(enemyShipCount);
    }

    protected void CheckInput()
    {
        if (Input.GetKeyDown("space"))
        {
            AddShips(enemyShipIncrement);
        }
    }

    protected abstract void AddShips(int amount);

    protected GameObject InstantiateShip()
    {
        float xVal = Random.Range(leftBound, rightBound);
        float zVal = Random.Range(0f, 10f);

        Vector3 pos = new Vector3(xVal, 0f, zVal + topBound);
        Quaternion rot = Quaternion.Euler(0f, 180f, 0f);
        var obj = Instantiate(enemyShipPrefab, pos, rot) as GameObject;
        return obj;
    }

    protected void InsertAmount(int amount){
        count+=amount;
        fps.SetElementCount(count);
    }

}
