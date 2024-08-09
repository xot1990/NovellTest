using UnityEngine;
using UnityEngine.SceneManagement;

namespace Naninovel
{
    [InitializeAtRuntime]
    public class MiniGameService : IEngineService
    {
        private readonly InputManager inputManager;
        private readonly ScriptPlayer scriptPlayer;
        private readonly CustomVariableManager customVariableManager;

        public MiniGameService(InputManager inputManager, ScriptPlayer scriptPlayer,
            CustomVariableManager customVariableManager)
        {
            this.inputManager = inputManager;
            this.scriptPlayer = scriptPlayer;
            this.customVariableManager = customVariableManager;
        }

        public UniTask InitializeServiceAsync()
        {
            Debug.Log(inputManager.ProcessInput);
            Debug.Log(scriptPlayer.PlayedScript);
            return UniTask.CompletedTask;
        }

        public async void LoadMiniGame()
        {
            var player = Engine.GetService<IScriptPlayer>();

            player.PreloadAndPlayAsync("RunMiniGame").Forget();
            await SceneManager.LoadSceneAsync("MiniGame");
        }

        public async void UnLoadMiniGame()
        {
            var player = Engine.GetService<IScriptPlayer>();

            await SceneManager.LoadSceneAsync("Game");
            player.PreloadAndPlayAsync("EndMiniGame").Forget();
        }

        public void SetGameResault(string variable, string value)
        {
            if (customVariableManager.VariableExists(variable))
                customVariableManager.SetVariableValue(variable, value);
            else Debug.Log("Variable " + variable + " dont exist");
        }


        public void ResetService()
        {

        }

        public void DestroyService()
        {

        }
    }
}
