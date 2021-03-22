using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadMenuWidget : MenuWidget
{
    [SerializeField]
    private string SceneToLoad;
    [SerializeField]
    private const string SaveFileKey = "FileSaveData";
    [Header("References")]
    [SerializeField]
    GameObject SaveSlotPrefab;
    [SerializeField]
    private RectTransform LoadItemsPanel;
    [SerializeField]
    private TMP_InputField NewGameInputField;
    [Header("")]
    [SerializeField]
    private bool debug;

    private GameDataList GameData;

    private void Start()
    {
        if (debug)
        {
            SaveDebugData();
        }

        WipeChildren();
        LoadGameData();
    }

    private void WipeChildren()
    {
        foreach (Transform saveSlot in LoadItemsPanel)
        {
            Destroy(saveSlot.gameObject);
        }

        LoadItemsPanel.DetachChildren();
    }

    private static void SaveDebugData()
    {
        GameDataList dataList = new GameDataList();
        dataList.SaveFileNames.AddRange(new List<string> { "Save1", "Save2", "Save3" });
        PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(dataList));
    }

    private void LoadGameData()
    {
        if (PlayerPrefs.HasKey(SaveFileKey))
        {
            return;
        }

        string jsonString = PlayerPrefs.GetString(SaveFileKey);
        GameData = JsonUtility.FromJson<GameDataList>(jsonString);

        if (GameData.SaveFileNames.Count <= 0)
        {
            return;
        }

        foreach (string saveName in GameData.SaveFileNames)
        {
            SaveSlotWidget widget = Instantiate(SaveSlotPrefab, LoadItemsPanel).GetComponent<SaveSlotWidget>();
            widget.Initialize(this, saveName);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void CreateNewGame()
    {
        if (string.IsNullOrEmpty(NewGameInputField.text))
        {
            return;
        }

        GameManager.Instance.SetActiveSave(NewGameInputField.text);
        LoadScene();
    }
}

[System.Serializable]
class GameDataList
{
    public List<string> SaveFileNames = new List<string>();
}
