
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MonsterLevel
{
    public int cost;
    public GameObject visualization;
}

public class MonsterData : MonoBehaviour
{
    public List<MonsterLevel> levels;
    private MonsterLevel _currentLevel;
    public MonsterLevel CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;
            var currentLevelIndex = levels.IndexOf(_currentLevel);

            var levelVisualization = levels[currentLevelIndex].visualization;
            for (var i = 0; i < levels.Count; i++)
            {
                if (levelVisualization == null) continue;
                levels[i].visualization.SetActive(i == currentLevelIndex);
            }
        }
    }
    public MonsterLevel GetNextLevel()
    {
        var currentLevelIndex = levels.IndexOf (_currentLevel);
        var maxLevelIndex = levels.Count - 1;
        return currentLevelIndex < maxLevelIndex ? levels[currentLevelIndex+1] : null;
    }
    
    public void IncreaseLevel()
    {
        var currentLevelIndex = levels.IndexOf(_currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
    
    private void OnEnable()
    {
        CurrentLevel = levels[0];
    }
}
