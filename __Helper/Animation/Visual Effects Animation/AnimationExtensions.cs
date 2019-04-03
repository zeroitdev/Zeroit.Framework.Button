// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-22-2018
// ***********************************************************************
// <copyright file="AnimationExtensions.cs" company="Zeroit Dev Technologies">
//    This program is for creating a Button controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
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
