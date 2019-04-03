// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="IEffect.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Button.Helper.Animation
{

    #region IEffect
    /// <summary>
    /// By implementing this interface you define what property of your control
    /// is manipulated and the way you manipulate it.
    /// </summary>
    public interface IEffect
    {
        /// <summary>
        /// Gets the interaction.
        /// </summary>
        /// <value>The interaction.</value>
        EffectInteractions Interaction { get; }

        /// <summary>
        /// Gets the current value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.Int32.</returns>
        int GetCurrentValue(Control control);
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="valueToReach">The value to reach.</param>
        /// <param name="newValue">The new value.</param>
        void SetValue(Control control, int originalValue, int valueToReach, int newValue);

        /// <summary>
        /// Gets the minimum value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.Int32.</returns>
        int GetMinimumValue(Control control);
        /// <summary>
        /// Gets the maximum value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.Int32.</returns>
        int GetMaximumValue(Control control);
    }
    #endregion

}
