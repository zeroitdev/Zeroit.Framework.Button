// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Flags.cs" company="Zeroit Dev Technologies">
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

using System;
//using System.Windows.Forms.VisualStyles;

#endregion

namespace Zeroit.Framework.Button.Helper.Animation
{
    #region Flags
    /// <summary>
    /// Set the effect interactions for <c><see cref="ButtonAnimator" /></c> and
    /// <br></br><c><see cref="ZeroitAnimate_VisualEffectsAnimatorWithEditor" /></c> animators.
    /// </summary>
    [Flags]
    public enum EffectInteractions
    {
        /// <summary>
        /// The x
        /// </summary>
        X = 1,
        /// <summary>
        /// The y
        /// </summary>
        Y = 2,
        /// <summary>
        /// The width
        /// </summary>
        WIDTH = 8,
        /// <summary>
        /// The height
        /// </summary>
        HEIGHT = 4,
        /// <summary>
        /// The color
        /// </summary>
        COLOR = 16,
        /// <summary>
        /// The transparency
        /// </summary>
        TRANSPARENCY = 32,
        /// <summary>
        /// The location
        /// </summary>
        LOCATION = X | Y,
        /// <summary>
        /// The size
        /// </summary>
        SIZE = WIDTH | HEIGHT,
        /// <summary>
        /// The bounds
        /// </summary>
        BOUNDS = X | Y | WIDTH | HEIGHT
    }
    #endregion
}
