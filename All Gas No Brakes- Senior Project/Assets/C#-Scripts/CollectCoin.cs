using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private LevelManager gameLevelManager;
    private int coinValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gameLevelManager.AddCoins(coinValue);
            coinValue--;  // minus 1 because it always adds 2, idk why.
            Destroy(gameObject);
        }      
    }

}
