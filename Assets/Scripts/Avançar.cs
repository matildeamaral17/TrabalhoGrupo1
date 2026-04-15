using UnityEngine;
using UnityEngine.SceneManagement;

public class Avancar : MonoBehaviour
{
    [SerializeField] private string cenaParaAvancar;

    public void AvancarPagina()
    {
        SceneManager.LoadScene(cenaParaAvancar);
    }
}
