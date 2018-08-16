using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerryUM : MonoBehaviour {

    public TextMeshProUGUI scorenum;
    public TextMeshProUGUI timenum;
    public TextMeshProUGUI avenum;
    public TextMeshProUGUI[] minuteStats;
    private int currScore = 0;
    private int[] scoreArray;
    private float timeElapsed = 0;

    private void Start()
    {
        
        StartCoroutine(currentMinutes());
        scorenum.text = currScore.ToString();
    }
    public void increaseScore()
    {
        currScore++;
        scorenum.text = currScore.ToString() + " Ums";
    }
    private void buttonMappedIncreaseScore()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            increaseScore();
        }
    }
    private float calculateTerryScore()
    {
        return (currScore * (60 / timeElapsed));
    }
    private void Update()
    {
        buttonMappedIncreaseScore();
        timeElapsed += Time.deltaTime;
        timenum.text = "Time elapsed : " + ((int)timeElapsed).ToString() + " seconds ";
        avenum.text = "average UPM :" + calculateTerryScore().ToString("0");
    }

    IEnumerator currentMinutes()
    {
        scoreArray = new int[+1]; 
        //scoreArray.add(currScore);
        yield return new WaitForSecondsRealtime(60);
    }
}
