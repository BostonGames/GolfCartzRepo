using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    
    [SerializeField] TextMeshProUGUI actionMessageText;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI holesText;
    [SerializeField] TextMeshProUGUI checkpointsText;




    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        pointsText.text = "Points: " + GameManager.instance.points.ToString();
        holesText.text = "Holes: " + GameManager.instance.ballsHit.ToString();
        checkpointsText.text = "Checkpoints: " + GameManager.instance.checkpointsPassed.ToString() + " of " + GameManager.instance.checkpointsTotal.ToString();


        // maybe put this into the EndTally function or something
        if(GameManager.instance.checkpointsPassed == GameManager.instance.checkpointsTotal)
        {
            // give a bonus
            GameManager.instance.AdjustPoints(50);

            // play SFX
            // some sort of anim (2d or 3d)
        }
    }

    public void SetActionItemText(string textToDisplay)
    {
        actionMessageText.text = textToDisplay;
    }

    public void ClearActionMessageText()
    {
        actionMessageText.text = "";
    }
    public void TempText(string textToDisplay, float time)
    {
        actionMessageText.text = textToDisplay;
        Invoke("ClearActionMessageText", time);
    }

}
