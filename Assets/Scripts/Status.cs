using UnityEngine;
using SimpleJSON;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
public class Status : MonoBehaviour
{
    #region Controllers
    public enum GameController
    {
        Play, Pause, Save, Load,
    }
    public class Data
    {
        public static byte level, lifes, mana;
        public static short cash;
        public static bool onPlay = true;
    }
    #endregion
    #region Objects
    public GameController gameController;
    [SerializeField] bool isPaused = false;
    byte addNum = 1;
    [SerializeField] NewPlayer playerScript;
    [SerializeField] Kura kuraScript;
    [SerializeField] GameObject pTransform;
    #endregion
    private void Awake()
    {
        gameController = GameController.Play;
    }
    private void Start()
    {
        Data.lifes = 10;
    }
    private void Update()
    {
        if (gameController == GameController.Play)
        {
            OnApplicationPause(false);
            Status.Data.onPlay = true;
            playerScript.GetComponent<NewPlayer>().pausePlayer = false;
            kuraScript.GetComponent<Kura>().pausePlayer = false;
        }
        if (gameController == GameController.Pause)
        {
            OnApplicationPause(true);
            Status.Data.onPlay = false;
            playerScript.GetComponent<NewPlayer>().pausePlayer = true;
            kuraScript.GetComponent<Kura>().pausePlayer = true;
        }
        if (gameController == GameController.Save)
        {
            Save();
        }
        if (gameController == GameController.Load)
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            Printscreen();
        }
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
    private void OnApplicationFocus(bool focusStatus)
    {
        focusStatus = !isPaused;
    }
    public void Printscreen()
    {
        ScreenCapture.CaptureScreenshot("Nekomancer" + addNum + ".png");
        addNum++;
    }
    public void Load()
    {
        //1
        PlayerPrefs.GetInt("level", Data.level);
        PlayerPrefs.GetInt("lifes", Data.lifes);
        PlayerPrefs.GetInt("mana", Data.cash);
        PlayerPrefs.GetInt("cash", Data.mana);

        StartCoroutine(LoadPreviousScene());
        //2
        string path = Application.persistentDataPath + "/PlayerSave.json";
        string jsonString = File.ReadAllText(path);
        JSONObject playerJson = (JSONObject)JSON.Parse(jsonString);

        transform.position = new Vector3(
            playerJson["Position"].AsArray[0],
            playerJson["Position"].AsArray[1],
            playerJson["Position"].AsArray[2]);
    }
    public void LoadTeste(int level, int printNum)
    {
        //1
        PlayerPrefs.GetInt("level", Data.level);
        PlayerPrefs.GetInt("lifes", Data.lifes);
        PlayerPrefs.GetInt("mana", Data.cash);
        PlayerPrefs.GetInt("cash", Data.mana);
        StartCoroutine(LoadPreviousScene());
        //2
        string path = Application.persistentDataPath + "/PlayerSave.json";
        string jsonString = File.ReadAllText(path);
        JSONObject playerJson = (JSONObject)JSON.Parse(jsonString);
        level = Data.level;
        printNum = addNum;
    }
    public void Save()
    {
        //1
        PlayerPrefs.SetInt("level", Data.level); // Valores exemplo
        PlayerPrefs.SetInt("lifes", Data.lifes); // Valores exemplo
        PlayerPrefs.SetInt("mana", Data.cash);
        PlayerPrefs.SetInt("cash", Data.mana);
        Printscreen();
        //2
        JSONObject playerJson = new JSONObject();
        JSONArray position = new JSONArray();
        position.Add(pTransform.transform.position.x);
        position.Add(pTransform.transform.position.y);
        position.Add(pTransform.transform.position.z);
        playerJson.Add("Position", position);

        string path = Application.persistentDataPath + "/PlayerSave.json";
        File.WriteAllText(path, playerJson.ToString());
    }
    IEnumerator LoadPreviousScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(Data.level);
    }
}