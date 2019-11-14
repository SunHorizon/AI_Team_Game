using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCheck : MonoBehaviour
{

    [SerializeField] private PlayerHelth player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (player.getHealth() <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
      
    }
}
