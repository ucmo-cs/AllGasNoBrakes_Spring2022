using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public Player_Controller gamePlayer;
    public int coins;
    public string currentCoins;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCoins = coins.ToString();
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerable RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
    
    public void AddCoins(int numOfCoins)
    {
        coins += numOfCoins;
    }

    
}
