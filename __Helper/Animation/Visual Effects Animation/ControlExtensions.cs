// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ControlExtensions.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System.Drawing;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Button.Helper.Animation
{
    #region ControlExtensions
    /// <summary>
    /// Class ControlExtensions.
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Selects the next control.
        /// </summary>
        /// <param name="initialControl">The initial control.</param>
        public static void SelectNextControl(this Control initialControl)
        {
            if (initialControl != null)
            {
                var ctrlSelected = initialControl.SelectNextControl(initialControl, true, true, false, false);
                if (!ctrlSelected)
                    SelectNextControl(initialControl.Parent);
            }
        }

        /// <summary>
        /// Gets the snapshot.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <returns>System.Drawing.Bitmap.</returns>
        public static System.Drawing.Bitmap GetSnapshot(this Control control)
        {
            if (control.Width <= 0 || control.Height <= 0)
                return null;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap(control.Width, control.Height);
            Rectangle targetBounds = new Rectangle(0, 0, control.Width, control.Height);

            control.DrawToBitmap(image, targetBounds);
            return image;
        }

        /// <summary>
        /// Gets the form borderless snapshot.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>System.Drawing.Bitmap.</returns>
        public static System.Drawing.Bitmap GetFormBorderlessSnapshot(this System.Windows.Forms.Form window)
        {
            using (var bmp = new System.Drawing.Bitmap(window.Width, window.Height))
            {
                window.DrawToBitmap(bmp, new Rectangle(0, 0, window.Width, window.Height));

                System.Drawing.Point point = window.PointToScreen(System.Drawing.Point.Empty);

                System.Drawing.Bitmap target = new System.Drawing.Bitmap(window.ClientSize.Width, window.ClientSize.Height);
                using (Graphics g = Graphics.FromImage(target))
                {
                    var srcRect = new Rectangle(point.X - window.Location.X,
                        point.Y - window.Location.Y, target.Width, target.Height);

                    g.DrawImage(bmp, 0, 0, srcRect, GraphicsUnit.Pixel);
                }

                return target;
            }
        }
    }
    #endregion
}
