using UnityEngine;
using UnityEngine.SceneManagement;

public class BotãoMercedes : MonoBehaviour
{
    public void LoadMercedes()
    {
        SceneManager.LoadScene("CatálogoMercedes");
    }
}

