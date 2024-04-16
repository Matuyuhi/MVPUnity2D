using Feature.Models;
using Feature.Views;
using UnityEngine;
using VContainer;

namespace Feature.Presenters
{
    public class PlayerPresenter
    {
        [Inject]
        public PlayerPresenter(
            PlayerView playerView,
            PlayerModel playerModel
        )
        {
            Debug.Log("PlayerPresenter");
            Debug.Log(playerView);
            Debug.Log(playerModel);
        }
    }
}