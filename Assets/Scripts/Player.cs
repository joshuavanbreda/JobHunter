using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxScore = 100;
    public int currentScore;

    public int CorrectDoorValue;
    public int IncorrectDoorValue;
    public int PickUpValue;
    public int ObstacleLoseValue;

    public ParticleSystem particleHearts;
    public GameObject particlePlus;
    public GameObject particlePlumber;
    public GameObject particlePowerUp;
    public GameObject particleWin;

    public GameObject nakedPlayer;

    public GameObject doc1;
    public GameObject doc2;
    public GameObject doc3;

    public GameObject docBal1;
    public GameObject docBal2;

    public ScoreBar scoreBar;

    void Start()
    {
        currentScore = 0;
        scoreBar.SetMaxScore(maxScore);

        nakedPlayer.gameObject.SetActive(true);
        doc1.gameObject.SetActive(false);
        doc2.gameObject.SetActive(false);
        doc3.gameObject.SetActive(false);
        docBal1.gameObject.SetActive(false);
        docBal2.gameObject.SetActive(false);

        particlePowerUp.gameObject.SetActive(false);
        particlePlumber.gameObject.SetActive(false);
        particleWin.gameObject.SetActive(false);
        particlePlus.gameObject.SetActive(false);
        particleHearts.gameObject.SetActive(false);

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PickUp")
        {
            TakeScore(PickUpValue);
            //other.gameObject.SetActive(false);
            Debug.Log(currentScore);
            other.gameObject.SetActive(false);
            //GetComponent<ParticleSystem>().Play();
        }

        if (other.tag == "BadPickUp")
        {
            TakeScore(-PickUpValue);
            Debug.Log(currentScore);
            other.gameObject.SetActive(false);
        }


        if (other.tag == "CorrectDoor")
        {
            other.gameObject.SetActive(false);
            TakeScore(CorrectDoorValue);
            //other.gameObject.SetActive(false);
            Debug.Log(currentScore);
            if (other.gameObject.name == "CorrectChange1")
            {
                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(true);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                docBal1.gameObject.SetActive(false);
                docBal2.gameObject.SetActive(false);
            }

            if (other.gameObject.name == "CorrectChange2")
            {
                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(true);
                doc3.gameObject.SetActive(false);
                docBal1.gameObject.SetActive(false);
                docBal2.gameObject.SetActive(false);
            }
            if(other.gameObject.name == "CorrectChange3")
            {
                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(true);
                docBal1.gameObject.SetActive(false);
                docBal2.gameObject.SetActive(false);
            }
        }

        if (other.tag == "Obstacle")                    //Obstacle Child Trigger removal
        {
            other.gameObject.SetActive(false);

            TakeScore(ObstacleLoseValue);
            //other.gameObject.SetActive(false);
            Debug.Log(currentScore);
        }

        if (other.tag == "IncorrectDoor")
        {
            other.gameObject.SetActive(false);

            TakeScore(IncorrectDoorValue);
            //other.gameObject.SetActive(false);
            Debug.Log(currentScore);

            if(other.gameObject.name == "IncorrectChange3")
            {
                other.gameObject.SetActive(false);

                return;
            }

            if(other.gameObject.name == "IncorrectChange2")
            {
                other.gameObject.SetActive(false);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                docBal1.gameObject.SetActive(true);
                docBal2.gameObject.SetActive(false);
            }

            if (other.gameObject.name == "IncorrectChange1")
            {
                other.gameObject.SetActive(false);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                docBal1.gameObject.SetActive(false);
                docBal2.gameObject.SetActive(true);
            }
        }

        //if (other.tag == "EndLevelScene")
        //{
            
        //}

    }

    void TakeScore(int score)
    {
        currentScore += score;

        if (currentScore < 0)
        {
            currentScore = 0;
        }

        scoreBar.SetScore(currentScore);
    }

    IEnumerator heartTimer()
    {
        particleHearts.Play();
        yield return new WaitForSeconds(1);
        particleHearts.Stop();
    }

    IEnumerator plusTimer()
    {
        particlePlus.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        particlePlus.gameObject.SetActive(false);
    }

    IEnumerator WinTimer()
    {
        particleWin.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        particleWin.gameObject.SetActive(false);
    }

    IEnumerator PlumberTimer()
    {
        particlePlumber.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        particlePlumber.gameObject.SetActive(false);
    }

    IEnumerator PowerUpTimer()
    {
        particlePowerUp.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        particlePowerUp.gameObject.SetActive(false);
    }
}
