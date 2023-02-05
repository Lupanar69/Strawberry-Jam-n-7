using System;
using UnityEngine;

/// <summary>
/// Gère le framerate et le GC en cas de mémoire faible
/// </summary>
public class ApplicationPerformance
{
    #region Fonctions publiques

    /// <summary>
    /// Appelée au lancement du jeu
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    public static void BeforeSplashScreen()
    {
        SetFPS(45);
        Application.lowMemory += OnLowMemory;
    }

    /// <summary>
    /// Assigne un nombre fixe de FPS pour éviter
    /// de consommer trop d'énergie
    /// </summary>
    /// <param name="fps">Le nombre de FPS auquel bloquer le jeu</param>
    public static void SetFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }

    #endregion

    #region Fonctions privées

    /// <summary>
    /// Appelée quand la mémoire restante est faible
    /// </summary>
    private static void OnLowMemory()
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
    }


    #endregion
}
