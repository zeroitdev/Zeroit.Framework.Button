// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="SpringButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Spring Button

    /// <summary>
    /// A simple example about
    /// how to  create a c# control
    /// and
    /// how to manage a delegate with
    /// embedded Eventargs
    /// </summary>


    //This is the Embedded eventargs...
    //it just say if the clicked items
    //is right or left triangle

    public class TriangleClickEventArgs
    {
        /// <summary>
        /// The isleft
        /// </summary>
        public bool Isleft = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="TriangleClickEventArgs"/> class.
        /// </summary>
        /// <param name="TriangleIsleft">if set to <c>true</c> [triangle isleft].</param>
        public TriangleClickEventArgs(bool TriangleIsleft)
        {

            Isleft = TriangleIsleft;

        }

    }

    /// <summary>
    /// A class collection for rendering a button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitSpringButton : Control
    {


        #region Events and Delegates
        //When user click on the triangle(left o right)
        //the control  run a new event called "TriangleClick"
        //and say what triangle has been clicked.


        /// <summary>
        /// Occurs when [triangle click].
        /// </summary>
        public event TriangleClickDelegate TriangleClick;

        /// <summary>
        /// Delegate TriangleClickDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TriangleClickEventArgs"/> instance containing the event data.</param>
        public delegate void TriangleClickDelegate(Object sender, TriangleClickEventArgs e);
        #endregion

        #region Private Fields
        //this variable say if the
        //mouse is over the contol
        /// <summary>
        /// The sel
        /// </summary>
        private bool Sel = false;
        /// <summary>
        /// The back color2
        /// </summary>
        private Color BackColor2 = Color.Gray;
        /// <summary>
        /// The triangle
        /// </summary>
        int _triangle = 25;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the ending border's color.
        /// </summary>
        /// <value>The back color end.</value>
        public Color BackColorEnd
        {
            get { return BackColor2; }
            set
            {
                BackColor2 = value;
                this.Invalidate();
            }

        }


        //I add a proprety
        //that's the length of
        //a triangle rectangle (45°)

        /// <summary>
        /// Gets or sets the triangle.
        /// </summary>
        /// <value>The triangle.</value>
        public int Triangle
        {
            get { return _triangle; }
            set
            {
                _triangle = value;
                //if lenght change I update 
                //the control
                this.Invalidate(true);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSpringButton" /> class.
        /// </summary>
        public ZeroitSpringButton()
        {
            //First of all i set the style 

            //this.SetStyle(ControlStyles.AllPaintingInWmPaint |
            //     ControlStyles.ResizeRedraw | ControlStyles.UserPaint
            //     | ControlStyles.UserMouse, true);


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | 
                ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor | 
                ControlStyles.UserMouse, true);

            IncludeInConstructor();

            this.Invalidate();

        }

        #endregion

        #region Methods and Overrides
        //I override the default event " Onclick"
        //adding the detection of "triangle click"

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnClick(e);
            // if the user use this delegate...
            if (this.TriangleClick != null)
            {
                //check if the user click on the left triangle
                //or in the right with some geometrics  rules...
                //(is't possible to click all triangle at the same time )

                int x = e.X;
                int y = e.Y;

                if ((x < _triangle) && (y <= (_triangle - x)) ||
                   (x > this.ClientRectangle.Width - _triangle) && (y >= (this.ClientRectangle.Height - _triangle - x)))
                {


                    //try with right...
                    TriangleClickEventArgs te = new TriangleClickEventArgs(false);
                    //if not...
                    if ((x < _triangle) && (y <= (_triangle - x)))
                        te = new TriangleClickEventArgs(true);

                    this.TriangleClick(this, te);


                }
            }

            ClickOnMouseDown(e);
        }
        //set the button as "selected" on mouse entering
        //and as not selected on mouse leaving
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            Sel = true;

            this.Invalidate();

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            Sel = false;

            this.Invalidate();

        }

        //i overide the default paint
        //and do my special routine...
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            TransparentInPaint(e.Graphics);
            this.PaintBut(e);
        }

        //If  this component is resized i update him
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(true);
        }

        //The Core of this control...
        /// <summary>
        /// Paints the but.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected void PaintBut(PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //I select the rights color 
            //To paint the button...
            Color FColor = this.BackColorEnd;
            Color BColor = this.BackColor;
            if (Sel == true)
            {
                FColor = this.BackColor;

                BColor = this.BackColorEnd;
            }
            //I daw the central rectangle


            //e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), this.ClientRectangle);

            Rectangle rect = new Rectangle(5, 5, this.ClientRectangle.Width - 10, this.ClientRectangle.Height - 10);

            e.Graphics.FillRectangle(new LinearGradientBrush(rect, BColor, Color.FromArgb(10, BColor), 45, true), rect);
            e.Graphics.DrawRectangle(new Pen(FColor), rect);

            //I define the triangle's coordinate...
            Point[] tringleleft = new Point[4];
            tringleleft[0] = new Point(0, 0);
            tringleleft[1] = new Point(_triangle, 0);
            tringleleft[2] = new Point(0, _triangle);
            tringleleft[3] = new Point(0, 0);

            Point[] tringleright = new Point[4];
            tringleright[0] = new Point(this.Width - 1, this.Height - 1);
            tringleright[1] = new Point(this.Width - _triangle - 1, this.Height - 1);
            tringleright[2] = new Point(this.Width - 1, this.Height - _triangle - 1);
            tringleright[3] = new Point(this.Width - 1, this.Height - 1);




            //..and paint the triangle on the control 
            e.Graphics.FillPolygon(new SolidBrush(BColor), tringleleft);
            e.Graphics.DrawPolygon(new Pen(FColor), tringleleft);


            e.Graphics.FillPolygon(new SolidBrush(BColor), tringleright);
            e.Graphics.DrawPolygon(new Pen(FColor), tringleright);

            //At last i write the text with
            //some allignament...
            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;

            sf.Trimming = StringTrimming.Character;
            sf.LineAlignment = StringAlignment.Center;
            sf.FormatFlags = StringFormatFlags.NoWrap;

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.ClientRectangle, sf);

        }

        #endregion

        #region Click Animation

        #region Include in Constructor

        private void IncludeInConstructor()
        {
            locate = new Point(Location.X, Location.Y);
            ClickTimer.Tick += ClickTimer_Tick;
        }

        #endregion

        #region Fields
        int xx;
        int yy;
        private bool clicked = false;
        private Point locate;
        Timer ClickTimer = new Timer();
        private bool allowClickAnimation = true;
        private int clickinterval = 1;
        private int offset = 1;
        private int maxOffset = 10;
        #endregion

        #region Properties

        public int ClickOffset
        {
            get { return offset; }
            set
            {
                offset = value;
                Invalidate();
            }
        }

        public int ClickMaxOffset
        {
            get { return maxOffset; }
            set
            {
                maxOffset = value;
                Invalidate();
            }
        }

        public int ClickSpeed
        {
            get { return clickinterval; }
            set
            {
                clickinterval = value;
                Invalidate();
            }
        }

        public bool AllowClickAnimation
        {
            get { return allowClickAnimation; }
            set { allowClickAnimation = value; }
        }

        #endregion

        #region Events

        private void ClickTimer_Tick(object sender, EventArgs e)
        {

            if (clicked)
            {
                this.Location = new Point(Location.X, Location.Y + ClickOffset);
                //this.Location = new Point(Location.X, Location.Y - 10);
            }
            else
            {
                this.Location = locate;
            }

            if (Location.Y > locate.Y + ClickMaxOffset)
            {
                this.Location = locate;
                ClickTimer.Stop();
            }

            Invalidate();

        }

        private void ClickOnMouseDown(MouseEventArgs e)
        {
            locate = new Point(Location.X, Location.Y);
            clicked = true;

            xx = e.X;
            yy = e.Y;
            //Focus = true;
            //AnimationTimer.Start();

            ClickTimer.Start();

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            clicked = false;

            //Focus = false;
            //AnimationTimer.Start();
            if (allowClickAnimation)
            {
                ClickTimer.Start();
            }

            Invalidate();
        }

        #endregion

        #endregion

        #region Transparency

        #region Include in Paint

        private void TransparentInPaint(Graphics g)
        {
            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }
        }

        #endregion

        #region Include in Private Field

        private bool allowTransparency = true;

        #endregion

        #region Include in Public Properties

        public bool AllowTransparency
        {
            get { return allowTransparency; }
            set
            {
                allowTransparency = value;

                Invalidate();
            }
        }

        #endregion

        #region Method


        private static void MakeTransparent(Control control, Graphics g)
        {
            var parent = control.Parent;
            if (parent == null) return;
            var bounds = control.Bounds;
            var siblings = parent.Controls;
            int index = siblings.IndexOf(control);
            Bitmap behind = null;
            for (int i = siblings.Count - 1; i > index; i--)
            {
                var c = siblings[i];
                if (!c.Bounds.IntersectsWith(bounds)) continue;
                if (behind == null)
                    behind = new Bitmap(control.Parent.ClientSize.Width, control.Parent.ClientSize.Height);
                c.DrawToBitmap(behind, c.Bounds);
            }
            if (behind == null) return;
            g.DrawImage(behind, control.ClientRectangle, bounds, GraphicsUnit.Pixel);
            behind.Dispose();
        }

        #endregion

        #endregion

    }
    #endregion

}
