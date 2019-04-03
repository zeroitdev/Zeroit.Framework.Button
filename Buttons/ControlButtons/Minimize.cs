// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-23-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Minimize.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
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
