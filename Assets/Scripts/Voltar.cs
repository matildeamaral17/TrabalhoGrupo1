using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltar : MonoBehaviour
{
    [SerializeField] private string cenaParaVoltar;

    public void VoltarPagina()
    {
        SceneManager.LoadScene(cenaParaVoltar);
    }
}