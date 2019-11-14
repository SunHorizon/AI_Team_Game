using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour {


    [SerializeField] private Text score;
    Button playAgainButton;
    [SerializeField] private string name;

    // Use this for initialization
    void Start () {

        playAgainButton = GameObject.Find(name).GetComponent<Button>();
        playAgainButton.onClick.AddListener(Again);

        score.text = "Points: " + GameScore.points.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void Again()
    {
        GameScore.points = 0;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
