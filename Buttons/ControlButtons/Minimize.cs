// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Minimize.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region UniqueButtonExit    

    /// <summary>
    /// Class ZeroitMinimizeButton.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitMinimizeButton : Control
    {


        #region EventArgs



        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                if (this.FindForm().WindowState.Equals(System.Windows.Forms.FormWindowState.Normal))
                {
                    this.FindForm().WindowState = System.Windows.Forms.FormWindowState.Minimized;
                }

                if (this.FindForm().WindowState.Equals(System.Windows.Forms.FormWindowState.Maximized))
                {
                    this.FindForm().WindowState = System.Windows.Forms.FormWindowState.Minimized;
                }
                
            }
            
        }

        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCtrlBoxExitButton" /> class.
        /// </summary>
        public ZeroitMinimizeButton()
        {
            Text = "_";
            Font = new Font("Tahoma", 10);
        }

        #endregion

        #region Methods and Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            
        }
        #endregion
        

    }


    

    #endregion


}
