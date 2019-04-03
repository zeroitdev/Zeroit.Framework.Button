// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="BezierShapeControl.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Zeroit.Framework.Button
{
    /// <summary>
    /// Class BezierShapeControl.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(false)]
    class BezierShapeControl : Control
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //PictureBox picBox = new PictureBox();
            //picBox.Size = this.Size;
            //picBox.Location = this.Location;
            //Parent.Controls.Add(picBox);

            //Bitmap DrawArea = new Bitmap(picBox.Width, picBox.Height);
            //Graphics g = Graphics.FromImage(DrawArea);
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            Pen b1 = new Pen(Color.Black);
            Pen red = new Pen(Color.Red);

            Point p1 = new Point(25, 25);
            Point p2 = new Point(300, 25);
            Point p3 = new Point(25, 300);
            Point p4 = new Point(300, 300);

            List<Point> p = new List<Point> {p1, p2, p3, p4};
            g.DrawBezier(red, p1, p2, p3, p4);

            foreach (Point point in p)
            {
                g.DrawRectangle(b1, point.X - 1, point.Y - 1, 2, 2);
            }

            

        }
    }
}
