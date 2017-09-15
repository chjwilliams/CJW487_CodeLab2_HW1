using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public  Text scoreText;
	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<Text>();	
	}


    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
