using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputHandler 
{
    [SerializeField] string fileName = "savefilejson.json"; 
    [SerializeField] int maxCount = 7;

    public delegate void OnHighScoreListChanged(List<InputEntry> list);
    public static event OnHighScoreListChanged onHighScoreListChanged;
    List<InputEntry> entries = new List<InputEntry>();
    public void LoadData()
    {
        entries = FileHandler.ReadFromJson<InputEntry>(fileName);
        while(entries.Count > maxCount)
        {
            entries.RemoveAt(maxCount);
        }
        if(onHighScoreListChanged != null)
        {
            onHighScoreListChanged.Invoke(entries);
        }
    }
    public void AddHighScoreIfPoisble(InputEntry element){
        for (int i = 0; i < maxCount; i++){
            if(i >= entries.Count || element.points > entries[i].points){
                entries.Insert(i, element);
                while(entries.Count > maxCount){
                    entries.RemoveAt(maxCount);
                }
                SaveHighScore();
                onHighScoreListChanged.Invoke(entries);
                break;
            }
        }
    }
    private void SaveHighScore()
    {
        FileHandler.SaveTOJson<InputEntry>(entries, fileName);
    }
}
