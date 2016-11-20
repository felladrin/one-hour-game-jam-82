using UnityEngine;
using UnityEngine.UI;

public class EndGameMessage : MonoBehaviour {

    public Text messsage;
    [SerializeField]
    private bool gameIsFinished;

    private void Update () {
	    if (gameIsFinished) return;

	    if (FindObjectsOfType<Tower>().Length != 1) return;

	    messsage.gameObject.SetActive(true);
	    messsage.text = "Tower " + FindObjectOfType<Tower>().Team +  " Wins!\n\nPress R to Restart!";
	    gameIsFinished = true;
	}
}
