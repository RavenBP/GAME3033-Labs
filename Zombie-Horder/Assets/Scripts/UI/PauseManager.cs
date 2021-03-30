using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UnPauseGame();
    }

    public void PauseGame()
    {
        var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();

        foreach(IPausable pausable in pausables)
        {
            pausable.PauseMenu();
        }

        Time.timeScale = 0;
        AppEvents.Invoke_OnMouseCursorEnable(true);
    }

    public void UnPauseGame()
    {
        var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();

        foreach(IPausable pausable in pausables)
        {
            pausable.UnPauseMenu();
        }

        Time.timeScale = 1;
        AppEvents.Invoke_OnMouseCursorEnable(false);
    }

    private void OnDestroy()
    {
        UnPauseGame();
    }
}

interface IPausable
{
    void PauseMenu();
    void UnPauseMenu();
}
