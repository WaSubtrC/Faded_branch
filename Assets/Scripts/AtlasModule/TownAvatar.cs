using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Faded.Atlas 
{
    public class TownAvatar : PlaceAvatarBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            AtlasManager.Instance.OnTransPlace();
            GameManager.Instance.OnEnterTown();
        }
    }
}
