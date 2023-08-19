using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TMP_Text bestScore;
    public TMP_InputField inputField;
    public string nameInput;
    public static StartMenu Instance;

    Scene scene;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


    }

    void Start()
    {
        LoadPoint();
    }
    private void Update()
    {
        if (nameInput != inputField.text)
        {
            nameInput = inputField.text;
        }
    }
    public void StartNew()
    {

        
        MainManager.TempName = nameInput;
        SceneManager.LoadScene(1);
       

    }

  

    [System.Serializable]
    public class SaveData
    {
        public  int BestScore;
        public  string PlayerName;
    }

    public void SaveName()
    {

    }
    public void LoadPoint()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //BestScore = data.BestScore;
            //PlayerName = data.PlayerName;

            bestScore.text = "Best Score: " + data.PlayerName + ": " + data.BestScore;


        }
    }


    public void Exit()
    {
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // Unity 플레이어를 종료하는 원본 코드
#endif
    }

    
}
