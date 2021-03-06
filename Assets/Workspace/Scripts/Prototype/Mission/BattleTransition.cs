﻿// <copyright file="BattleTransition.cs" company="Maxim Mikulski">Copyright (c) 2016 All Rights Reserved</copyright>
// <author>Maxim Mikulski</author>

using System.Collections;

using UnityEngine;

using Spine.Unity;

using V4F.FSM;

namespace V4F.Game
{

    public class BattleTransition : StateTransition
    {
        public SkeletonGraphic logo;
        public CanvasGroup group;

        private bool _wait;

        public override IEnumerable EnterNextState()
        {
            /*
            while (_wait)
            {
                yield return null;
            }
            logo.AnimationState.End -= AnimationEndHandler;
            */

            logo.AnimationState.SetAnimation(0, "animation", false);

            yield return new WaitForSeconds(1.3f);

            var alpha = 1f;
            while (alpha > 0f)
            {
                alpha = Mathf.Clamp01(alpha - Time.deltaTime * 2f);
                group.alpha = alpha;
                yield return null;
            }

            gameObject.SetActive(false);
        }

        public override IEnumerable ExitPrevState()
        {
            group.alpha = 1f;
            gameObject.SetActive(true);            

            /*
            logo.AnimationState.SetAnimation(0, "animation", false);
            logo.AnimationState.End += AnimationEndHandler;            
            _wait = true;
            */

            yield return null;
        }

        private void AnimationEndHandler(Spine.AnimationState state, int trackIndex)
        {
            _wait = false;
        }                
    }

}    
