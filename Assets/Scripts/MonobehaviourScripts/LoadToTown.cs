using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadToTown : MonoBehaviour
{
    void Start()
    {
        LoadTownScene();
    }

    private void LoadTownScene()
    {
        SceneManager.LoadScene(SceneState.TOWN_STATE);
    }
}
