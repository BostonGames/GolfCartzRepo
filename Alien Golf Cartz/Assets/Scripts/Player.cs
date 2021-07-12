using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public bool isInKart;
    public bool ActionRequested;
    public bool ExitOrEscapeRequested;


    [SerializeField] GameObject actionVisualGameObject;
    [SerializeField] GameObject kart;


    private void Awake()
    {
        instance = this;
    }

    public void Action()
    {
        actionVisualGameObject.SetActive(true);
    }

    private void GolfBall()
    {
        UImanager.instance.TempText("Good!!", 1.5f);
        GameManager.instance.AdjustPoints(10);
        GameManager.instance.BallHit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kart"))
        {
            UImanager.instance.SetActionItemText("Get Into Golf Cart");
        }
        if (other.CompareTag("GolfBall"))
        {
            UImanager.instance.SetActionItemText("Hit the Ball!!");
        }

        if (other.CompareTag("Checkpoint"))
        {
            UImanager.instance.TempText("Checkpoint!!", 1.5f);
            other.gameObject.SetActive(false);
            GameManager.instance.checkpointsPassed++;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Kart") && ActionRequested)
        {
            GetIntoGolfCart();
            UImanager.instance.ClearActionMessageText();
        }
        if (other.CompareTag("Kart") && ExitOrEscapeRequested)
        {
            ExitGolfCart();
        }

        if (other.CompareTag("GolfBall") && ActionRequested)
        {
            GolfBall();
            other.gameObject.SetActive(false);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Kart"))
        {
            UImanager.instance.ClearActionMessageText();
            isInKart = false;
        }
    }

    private void GetIntoGolfCart(){
        isInKart = true;
    }
    private void ExitGolfCart()
    {
        isInKart = false;
    }
}
