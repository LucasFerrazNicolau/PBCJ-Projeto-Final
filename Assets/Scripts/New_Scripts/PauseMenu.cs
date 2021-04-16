using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu :MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject menu;
    // Start is called before the first frame update
    void Start() {
        menu = GameObject.Find("BotoesPause");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        menu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        menu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void mainMenu() {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Start");
    }

    public void quit() {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
