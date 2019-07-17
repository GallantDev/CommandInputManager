using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager instance = null;
    [SerializeField] private GameState currentState = GameState.MENU;

    public static GameManager Instance { get { return instance; } set { instance = value; } }
    public GameState CurrentState { get { return currentState; } set { currentState = value; } }

    private void Awake() {
        Init();
    }

    private void Init() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void PauseGame() {
        if (currentState == GameState.PLAY) {
            currentState = GameState.PAUSE;
        }
        else if (currentState == GameState.PAUSE) {
            currentState = GameState.PLAY;
        }
    }
}