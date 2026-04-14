using UnityEngine;
using UnityEngine.UI;

public class MoveVertical : MonoBehaviour
{
    [Header("Configurações de Botões")]
    [SerializeField] private Button upBtn;
    [SerializeField] private Button downBtn;

    [Header("Configurações de Layout")]
    [SerializeField] private int spacing = 150; // Altura da imagem + espaço entre elas
    [SerializeField] private int visibleImages = 1;

    private RectTransform rectTransform;

    private void Awake()
    {
        // Obtém o RectTransform do objeto onde o script está (ImagemContainer)
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        // Garante que os botões estão no estado correto ao iniciar
        UpdateButtonStates();
    }

    private void MoveBar(int value)
    {
        if (rectTransform == null) return;

        // Captura a posição atual
        Vector3 newPosition = rectTransform.localPosition;

        // Soma o movimento no eixo Y
        newPosition.y += value;

        // Cálculo de limites
        int totalImages = transform.childCount;
        int maxDownMoves = Mathf.Max(0, totalImages - visibleImages);
        float maxY = spacing * maxDownMoves;

        // LIMITAR: Garante que Y nunca é menor que 0 nem maior que o máximo
        newPosition.y = Mathf.Clamp(newPosition.y, 0, maxY);

        // Aplica a nova posição
        rectTransform.localPosition = newPosition;

        // Atualiza os botões
        UpdateButtonStates(maxY);
    }

    private void UpdateButtonStates(float maxY = -1)
    {
        if (maxY < 0) // Se não passarmos o maxY, ele calcula agora
        {
            int totalImages = transform.childCount;
            int maxDownMoves = Mathf.Max(0, totalImages - visibleImages);
            maxY = spacing * maxDownMoves;
        }

        float currentY = rectTransform.localPosition.y;

        // Só altera se os botões estiverem arrastados no Inspector
        // Usamos 0.1f para evitar erros de precisão decimal do Unity
        if (upBtn != null) 
            upBtn.interactable = currentY > 0.1f;

        if (downBtn != null) 
            downBtn.interactable = currentY < (maxY - 0.1f);
    }

    public void MoveUp()
    {
        MoveBar(-spacing);
    }

    public void MoveDown()
    {
        MoveBar(spacing);
    }
}