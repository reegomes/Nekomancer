using UnityEngine;
public class Links : MonoBehaviour
{
    public void Facebook()
    {
        Application.OpenURL("http://facebook.com/nekomancergame");
    }
    public void GitHub()
    {
        Application.OpenURL("http://github.com/reegomes/nekomancer");
    }
    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/nekomancergame/");
    }
    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/NekoMancerGame");
    }
    public void Others()
    {
        Application.OpenURL("https://jjire.com.br/nekomancer2/");
    }
}