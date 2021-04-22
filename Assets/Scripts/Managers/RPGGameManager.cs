using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager instanciaCompartilhada = null; // instância compartilhada do Singleton

    public RPGCameraManager cameraManager; // referência da componente RPGCameraManager

    public PontoSpawn playerPontoSpawn; // referência do Ponto de Spawn do Player

    private void Awake()
    {
        if (instanciaCompartilhada != null && instanciaCompartilhada != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instanciaCompartilhada = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupScene();
    }

    /// <summary>
    /// Aplica as configurações iniciais do jogo
    /// </summary>
    public void SetupScene()
    {
        SpawnPlayer();
    }

    /// <summary>
    /// Realiza o spawn do Player e direciona a câmera virtual a ele
    /// </summary>
    public void SpawnPlayer()
    {
        if (playerPontoSpawn != null)
        {
            GameObject player = playerPontoSpawn.SpawnO();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }
}
