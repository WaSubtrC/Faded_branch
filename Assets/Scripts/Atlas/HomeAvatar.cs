using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Faded.Town;

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