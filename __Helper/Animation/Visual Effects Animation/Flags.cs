// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Flags.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
