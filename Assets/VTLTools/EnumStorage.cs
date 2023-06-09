using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VTLTools
{
    [Serializable]
    public enum GameState
    {
        None,
        ResetRound,
        Starting,
        Idle,
        ChoosingNode,
        Run,
        Fight,
        AttackCastle,
        Lose,
        Win,
        Retry,
    }

    public enum MenuItemState
    {
        None,
        Showing,
        Showed,
        Hiding,
        Hidden,
    }

}