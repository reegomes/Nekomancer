using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleJSON;
using System.IO;
public class Btns : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    public void Options()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
    public void Credits()
    {
        SceneManager.LoadScene(sceneBuildIndex: 7);
    }
    public void Quit()
    {
        Application.Quit();
        PlayerPrefs.Save();
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    public void Reset()
    {
        PlayerPrefs.SetInt("level", Status.Data.level = 3);
        // Colocar o numero da cena certa
        JSONObject playerJson = new JSONObject();
        JSONArray position = new JSONArray();
        position.Add(-13.4f);
        position.Add(1.1f);
        position.Add(0);
        playerJson.Add("Position", position);
        // Colocar a localização inicial da cena certa
        string path = Application.persistentDataPath + "/PlayerSave.json";
        File.WriteAllText(path, playerJson.ToString());
    }
    public void Restart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
}