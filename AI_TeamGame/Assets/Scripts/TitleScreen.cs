using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    Button playButton;
    [SerializeField] private string name;

    // Use this for initialization
    void Start ()
    {
        playButton = GameObject.Find(name).GetComponent<Button>();
        playButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
