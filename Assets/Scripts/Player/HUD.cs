using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject pausePanel;

    void Awake()
    {
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
                Play();
            else
                Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;

        hudPanel.SetActive(false);
        pausePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isPaused = true;
        Debug.Log("Pause");
    }

    public void Play()
    {
        Time.timeScale = 1;

        hudPanel.SetActive(true);
        pausePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPaused = false;
        Debug.Log("Play");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
