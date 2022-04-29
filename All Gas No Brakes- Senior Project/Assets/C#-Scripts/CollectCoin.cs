using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private LevelManager gameLevelManager;
    public int coinValue;

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
        // Decide Coin Value by its Tier ... T1, T2, T3 ... Collider2D whichCoin
              
        if (other.tag == "Player")
        {           
            gameLevelManager.AddCoins(coinValue);
            coinValue--;  // minus 1 because it always adds 2, idk why.           
            // Remove the object when pickedup      
            Destroy(gameObject);
        }      
    }



}
