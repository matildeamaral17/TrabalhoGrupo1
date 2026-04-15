using UnityEngine;
using UnityEngine.SceneManagement;

public class Avancar : MonoBehaviour
{
    public string CenaParaAvançar;

    public void AvançarPagina()
    {
        SceneManager.LoadScene(CenaParaAvançar);
    }
}
