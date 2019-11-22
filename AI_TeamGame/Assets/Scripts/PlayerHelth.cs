using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelth : MonoBehaviour {


    [SerializeField] private string name;
    [SerializeField] private float Health = 100f;
    [SerializeField] private RectTransform heathBar;

    private float healthScale;
    // Use this for initialization
    void Start ()
    {

        healthScale = heathBar.sizeDelta.x / Health;
    }
	
	// Update is called once per frame
	void Update () {
        if (Health <= 0)
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }

	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == name)
        {
            Health -= 10;
            heathBar.sizeDelta = new Vector2(Health * healthScale, heathBar.sizeDelta.y);
            Destroy(other.gameObject);
        }
    }

    public float getHealth()
    {
        return Health;
    }
}
