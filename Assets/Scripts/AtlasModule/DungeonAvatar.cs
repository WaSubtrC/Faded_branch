using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Faded.Atlas {
    public class DungeonAvatar : PlaceAvatarBase
    {
        [Header("Scale for dungeon")]
        public int layer = 1;
        public int level = 1;

        public void SetupDungeon(int lv)
        {
            level = Mathf.Max(1, lv + Random.Range((int)-2, (int)3));
            layer = 1 + Random.Range((int)0, (int)2);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameManager.Instance.OnEnterDungeon();
        }
    }
}
