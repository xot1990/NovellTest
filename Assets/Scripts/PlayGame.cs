using System.Collections;
using System.Collections.Generic;
using Naninovel;
using UnityEngine;

public class PlayGame : PlayScript
{
    private MiniGameService _miniGameService;

    protected override void Awake()
    {
        base.Awake();
        _miniGameService = Engine.GetService<MiniGameService>();
    }

    public override void Play()
    {
        _miniGameService.LoadMiniGame();
    }
}
