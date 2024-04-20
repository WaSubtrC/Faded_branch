using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Faded.Atlas
{
    public class HomeAvatar : PlaceAvatarBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            AtlasManager.Instance.OnTransPlace();
            GameManager.Instance.OnEnterHome();
        }
    }

}