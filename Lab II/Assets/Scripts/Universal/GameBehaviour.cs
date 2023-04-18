using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : LC.Behaviour //inherits from
{
    //unquie to this project
    protected static GameManager _GM { get { return GameManager.INSTANCE; } }
    protected static Level1Controller _L1C { get { return Level1Controller.INSTANCE; } }
    protected static PuzzlePieceLocations _PPL { get { return PuzzlePieceLocations.INSTANCE; } }
    protected static UIManager _UI { get { return UIManager.INSTANCE; } }
    protected static CharacterAnimator _CA { get { return CharacterAnimator.INSTANCE; } }
    protected static ProtagonistAnimator _PA { get { return ProtagonistAnimator.INSTANCE; } }
    protected static SnapEffect _SA { get { return SnapEffect.INSTANCE; } }
    protected static AudioController _AC { get { return AudioController.INSTANCE; } }


}
//
// Instanced GameBehaviour
//
public class GameBehaviour<T> : GameBehaviour where T : GameBehaviour
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameBehaviour<" + typeof(T).ToString() + "> not instantiated!\nNeed to call Instantiate() from " + typeof(T).ToString() + "Awake().");
            return _instance;
        }
    }
    //
    // Instantiate singleton
    // Must be called first thing on Awake()
    protected bool Instantiate()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Instance of GameBehaviour<" + typeof(T).ToString() + "> already exists! Destroying myself.\nIf you see this when a scene is LOADED from another one, ignore it.");
            DestroyImmediate(gameObject);
            return false;
        }
        _instance = this as T;
        return true;
    }

}
