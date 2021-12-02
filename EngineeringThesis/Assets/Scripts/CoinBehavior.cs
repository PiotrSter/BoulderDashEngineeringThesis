using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //gm.coin++; tutaj dodawanie coinów bedzie, jeœli wszystkie coiny siê zbierze to otworzy sieprzejœcei na next lvl
            Destroy(this.gameObject);
        }
    }
}
