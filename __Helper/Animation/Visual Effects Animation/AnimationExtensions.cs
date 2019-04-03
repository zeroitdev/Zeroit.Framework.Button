// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-22-2018
// ***********************************************************************
// <copyright file="AnimationExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Button.Helper.Animation
{
    #region AnimationExtensions
    /// <summary>
    /// Class AnimationExtensions.
    /// </summary>
    public static class AnimationExtensions
    {
        /// <summary>
        /// Animates the specified i animation.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="iAnimation">The i animation.</param>
        /// <param name="easing">The easing.</param>
        /// <param name="valueToReach">The value to reach.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="delay">The delay.</param>
        /// <param name="reverse">if set to <c>true</c> [reverse].</param>
        /// <param name="loops">The loops.</param>
        /// <returns>AnimationStatus.</returns>
        public static AnimationStatus Animate(this Control control, IEffect iAnimation,
            EasingDelegate easing, int valueToReach, int duration, int delay, bool reverse = false, int loops = 1)
        {
            return ButtonAnimator.Animate(control, iAnimation, easing, valueToReach, duration, delay, reverse, loops);
        }
    }
    #endregion
}
