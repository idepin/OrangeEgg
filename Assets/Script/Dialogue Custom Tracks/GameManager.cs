using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static Cinemachine.CinemachineTriggerAction.ActionSettings;

public class GameManager : Singleton<GameManager>
{
    public GameMode gameMode = GameMode.Gameplay;
    private PlayableDirector activeDirector;

    public void PauseTimeline(PlayableDirector whichOne)
    {
        activeDirector = whichOne;
        activeDirector.playableGraph.GetRootPlayable(0).SetSpeed(0d);
        gameMode = GameMode.DialogueMoment; //InputManager will be waiting for a spacebar to resume
        UIManager.Instance.TogglePressSpacebarMessage(true);
    }

    public void ResumeTimeline()
    {
        UIManager.Instance.TogglePressSpacebarMessage(false);
        UIManager.Instance.ToggleDialoguePanel(false);
        activeDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);
        gameMode = GameMode.Gameplay;
    }

    public enum GameMode
    {
        Gameplay,
        //Cutscene,
        DialogueMoment, //waiting for input
    }
}
