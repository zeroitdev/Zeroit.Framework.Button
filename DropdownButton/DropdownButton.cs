// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="DropdownButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Drawing;
using System.Windows.Forms;
using Zeroit.Framework.Button.Helper.Animation;


namespace Zeroit.Framework.Button
{
    #region ButtonDropDown

    /// <summary>
    /// A class for rendering a Drop down button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ZeroitButtonDropDown : System.Windows.Forms.Form
    {

        /// <summary>
        /// The button mousestate
        /// </summary>
        private int ButtonMousestate;

        /// <summary>
        /// Creates an instance of the Zeroit drop down button
        /// </summary>
        /// <param name="startLocation">Sets the start location</param>
        public ZeroitButtonDropDown(Point startLocation)
        {
            InitializeComponent();

            //Set the style--------------------------------------

            //Remove title bar and set edge-style
            this.Text = string.Empty;
            this.FormBorderStyle = FormBorderStyle.None;

            BackColor = Color.Snow;


            //Disable normal window functions
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.TopMost = true; //make it appear on the very top
            //----------------------------------------------------

            this.Capture = true; //allows mouse events to be triggered no matter where the mouse clicks

            //Match the position to the parent control
            this.Left = startLocation.X;
            this.Top = startLocation.Y;

            ButtonAnimator animate = new ButtonAnimator();
            animate.Target = this;
            animate.AnimationType = ButtonAnimator.GetAnimationType.TopAnchoredHeightEffect;
            animate.EasingType = ButtonAnimator.EasingFunctionTypes.BounceEaseOut;
            animate.Duration = 500;
            animate.ValueToReach = 120;
            animate.Activate();



        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //Check to see if the click is inside the drop-down Form
            if (this.RectangleToScreen(this.ClientRectangle).Contains(Cursor.Position))
                base.OnMouseDown(e); //normal mouse behavior
            else
                this.Close(); //close the drop-down
        }


        #region DropDownButton.Designer.cs


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            // 
            // frmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(200, 5);
            //this.Controls.Add(this.linkLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }


    #endregion


    #endregion
}
