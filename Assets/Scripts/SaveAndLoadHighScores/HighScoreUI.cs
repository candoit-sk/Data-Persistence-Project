using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWraper;
    [SerializeField] GameObject newGameObject;
    [SerializeField] GameObject highScoreButton;
    InputHandler inputHandler = new InputHandler();
    List<GameObject> uiElements = new List<GameObject> ();
    private void OnEnable() {
        InputHandler.onHighScoreListChanged += UpdateHighscore;
    }
    private void OnDisable() {
        InputHandler.onHighScoreListChanged -= UpdateHighscore;
    }
    public void ShowHighScore()
    {
        inputHandler.LoadData();
        panel.SetActive(true);
        
    }
    public void ShowHighScoreOnMainGame()
    {
        highScoreButton.SetActive(false);
        newGameObject.SetActive(false);
        panel.SetActive(true);
    }
    public void CloseHighScoreOnMainGame()
    {
        highScoreButton.SetActive(true);
        panel.SetActive(false);
        newGameObject.SetActive(true);
    }
    public void CloseHighScore()
    {
        panel.SetActive(false);
    }
    private void UpdateHighscore(List<InputEntry> list)
    {
        
        for(int i = 0; i < list.Count; i++) {
            InputEntry el = list[i];
            if(el != null && el.points >0 ){
                if(i >= uiElements.Count)
                {
                    var inst = Instantiate (highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent (elementWraper, false);

                    uiElements.Add (inst);
                }    
                
                var texts = uiElements[i].GetComponentsInChildren<Text> ();
                texts[0].text = el.playerName;
                texts[1].text = el.points.ToString ();
            }
            
        }
    }
}
