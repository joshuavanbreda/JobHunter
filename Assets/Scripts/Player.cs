using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Score")]
    public ScoreBar scoreBar;
    public int maxScore = 100;
    public int currentScore;
    public bool win;

    [Header("Doorways")]
    public int CorrectDoorValue;
    public int IncorrectDoorValue;
    public int PickUpValue;
    public int ObstacleLoseValue;

    [Header("Particles")]
    public GameObject particlesPosition;
    public ParticleSystem particleHearts;
    public ParticleSystem particlePlus;
    public ParticleSystem particlePlumber;
    public ParticleSystem particlePowerUp;
    public ParticleSystem particleWin;

    [Header("Character Gameobjects")]
    public GameObject nakedPlayer;

    public GameObject doc1;
    public GameObject doc2;
    public GameObject doc3;

    public GameObject docBal1;
    public GameObject docBal2;

    [Header("Door GameObjects")]
    public GameObject shoes;
    public GameObject coat;
    public GameObject toTo;
    public GameObject hat;
    public GameObject toolBox;
    public GameObject doctorBag;

    public bool scoreDocCheck;
    public bool scoreBalCheck;


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

        scoreBalCheck = false;
        scoreBalCheck = false;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PickUp")
        {
            Instantiate(particlePlus, particlesPosition.transform.position, Quaternion.identity);
            TakeScore(PickUpValue);
            Debug.Log(currentScore);
            other.gameObject.SetActive(false);

            
        }

        if (other.tag == "BadPickUp")
        {
            TakeScore(-PickUpValue);
            Debug.Log(currentScore);

            other.gameObject.SetActive(false);
        }


        if (other.tag == "DoctorDoor")
        {
            Instantiate(particlePowerUp, particlesPosition.transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);
            //TakeScore(CorrectDoorValue);
            Debug.Log(currentScore);
            if (other.gameObject.name == "DoctorChange1")
            {
                scoreDocCheck = true;
                scoreBalCheck = false;

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(true);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                docBal1.gameObject.SetActive(false);
                docBal2.gameObject.SetActive(false);

                coat.SetActive(false);
            }

            if (other.gameObject.name == "DoctorChange2")
            {
                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(true);
                doc3.gameObject.SetActive(false);
                docBal1.gameObject.SetActive(false);
                docBal2.gameObject.SetActive(false);

                hat.SetActive(false);
            }
            if(other.gameObject.name == "DoctorChange3")
            {
                win = true;
                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(true);
                docBal1.gameObject.SetActive(false);
                docBal2.gameObject.SetActive(false);

                doctorBag.SetActive(false);
            }

            if (scoreDocCheck == true)
            {
                TakeScore(CorrectDoorValue);
            }
            else if (scoreBalCheck == true)
            {
                TakeScore(-CorrectDoorValue);
            }
        }

        if (other.tag == "Obstacle")                    //Obstacle Child Trigger removal
        {
            other.gameObject.SetActive(false);

            TakeScore(ObstacleLoseValue);
            Debug.Log(currentScore);
        }

        if (other.tag == "BallerinaDoor")
        {
            Instantiate(particleHearts, particlesPosition.transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);


            Debug.Log(currentScore);

            if(other.gameObject.name == "BallerinaChange1")
            {
                scoreDocCheck = false;
                scoreBalCheck = true;

                other.gameObject.SetActive(false);

                shoes.SetActive(false);
            }

            if(other.gameObject.name == "BallerinaChange2")
            {
                other.gameObject.SetActive(false);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                docBal1.gameObject.SetActive(true);
                docBal2.gameObject.SetActive(false);

                toTo.SetActive(false);
            }

            if (other.gameObject.name == "BallerinaChange3")
            {
                other.gameObject.SetActive(false);

                nakedPlayer.gameObject.SetActive(false);
                doc1.gameObject.SetActive(false);
                doc2.gameObject.SetActive(false);
                doc3.gameObject.SetActive(false);
                docBal1.gameObject.SetActive(false);
                docBal2.gameObject.SetActive(true);

                toolBox.SetActive(false);
            }

            if (scoreBalCheck == true)
            {
                TakeScore(CorrectDoorValue);
            }
            else if (scoreDocCheck == true)
            {
                TakeScore(-CorrectDoorValue);
            }
        }

        if (other.tag == "FinalDoor")
        {
            TakeScore(CorrectDoorValue);
        }

        if (other.tag == "EndLevelScene" && win == true)
        {
            Instantiate(particleWin, particlesPosition.transform.position, Quaternion.identity);
        }

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
