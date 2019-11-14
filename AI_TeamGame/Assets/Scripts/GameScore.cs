using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour
{

     [SerializeField] private Text score;
     public static int points = 0;

	// Use this for initialization
	void Start ()
    {
        score.text = "Points: " + points.ToString();
    }
	
	// Update is called once per frame
	void Update () {

        score.text = "Points: " + points.ToString();
    }

}
