using UnityEngine;
using System.Collections;

/// <summary>
/// This will take a GameObject it is attached too and prevent it from being destroyed between scenes.
/// </summary>
public class PreserveGameObject : MonoBehaviour
{
    #region MonoBehaviour Methods

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #endregion
}
