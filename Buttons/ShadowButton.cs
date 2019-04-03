// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ShadowButton.cs" company="Zeroit Dev Technologies">
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
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Shadow Button

    /// <summary>
    /// A class collection for rendering a shadow button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitShadowButton : Control
    {
        #region Private Fields
        /// <summary>
        /// The shadow distance
        /// </summary>
        private float _ShadowDistance = -7f;
        /// <summary>
        /// The depth
        /// </summary>
        private float depth = 7;
        /// <summary>
        /// The shadow alpha
        /// </summary>
        private int shadowAlpha = 180;
        /// <summary>
        /// The radius
        /// </summary>
        private float _Radius = 1;
        /// <summary>
        /// The radius curvature
        /// </summary>
        private float radiusCurvature = 2f;
        /// <summary>
        /// The shadow
        /// </summary>
        private bool shadow = true;

        /// <summary>
        /// The shadow color
        /// </summary>
        private Color shadowColor = Color.DimGray;
        /// <summary>
        /// The background color1
        /// </summary>
        private Color backgroundColor1 = Color.Tomato;
        /// <summary>
        /// The background color2
        /// </summary>
        private Color backgroundColor2 = Color.MistyRose;

        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.DimGray;
        /// <summary>
        /// The border width
        /// </summary>
        private float borderWidth = 1f;
        /// <summary>
        /// The gradient mode
        /// </summary>
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;

        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitShadowButton" /> has shadow enabled.
        /// </summary>
        /// <value><c>true</c> if shadow; otherwise, <c>false</c>.</value>
        public bool Shadow
        {
            get { return shadow; }
            set
            {
                shadow = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the radius curvature.
        /// </summary>
        /// <value>The radius curvature.</value>
        public float RadiusCurvature
        {
            get { return radiusCurvature; }
            set
            {
                if (value < 0.1f)
                {
                    value = 0.1f;
                }

                radiusCurvature = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border radius.
        /// </summary>
        /// <value>The border radius.</value>
        public float BorderRadius
        {
            get { return _Radius; }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                _Radius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow alpha.
        /// </summary>
        /// <value>The shadow alpha.</value>
        public int ShadowAlpha
        {
            get { return shadowAlpha; }
            set
            {
                shadowAlpha = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the gradient mode.
        /// </summary>
        /// <value>The gradient mode.</value>
        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color1.</value>
        public Color BackgroundColor1
        {
            get { return backgroundColor1; }
            set
            {
                backgroundColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color2.</value>
        public Color BackgroundColor2
        {
            get { return backgroundColor2; }
            set
            {
                backgroundColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow depth.
        /// </summary>
        /// <value>The shadow depth.</value>
        public float ShadowDepth
        {
            get { return depth; }
            set
            {
                depth = value;

                _ShadowDistance = 0f - depth;

                Invalidate();
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitShadowButton" /> class.
        /// </summary>
        public ZeroitShadowButton()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);

            IncludeInConstructor();

        }

        #endregion

        #region Methods and overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            base.OnPaint(e);
            DrawRndRect(ref e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            CenterString(g, Text, Font, ForeColor, ClientRectangle);
        }

        /// <summary>
        /// Draws the random rect.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawRndRect(ref PaintEventArgs e)
        {
            // I like clean lines so set the smoothingmode to Anti-Alias
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // lets create a rectangle that will be centered in the picturebox and
            // just under half the size

            Rectangle _Rectangle = new Rectangle(10 + (int)depth, 10 + (int)depth, this.Width - 20 - (int)depth, this.Height - 20 - (int)depth);
            //Rectangle _Rectangle = new Rectangle((int)(picCanvas.Width * .3), (int)(picCanvas.Height * .3),
            //    (int)(picCanvas.Width * .4), (int)(picCanvas.Height * .4));

            // create the radius variable and set it equal to 20% the height of the rectangle
            // this will determine the amount of bend at the corners
            _Radius = (int)(_Rectangle.Height * .2);

            // create an x and y variable so that we can reduce the length of our code lines
            float X = _Rectangle.Left;
            float Y = _Rectangle.Top;

            // make sure that we have a valid radius, too small and we have a problem
            if (_Radius < 1)
                _Radius = 1;

            try
            {
                // Create a graphicspath object with the using operator so the framework
                // can clean up the resources for us
                using (GraphicsPath _Path = new GraphicsPath())
                {
                    // build the rounded rectangle starting at the top line and going around
                    // until the line meets itself again
                    _Path.AddLine(X + _Radius, Y, X + _Rectangle.Width - (_Radius * radiusCurvature), Y);
                    _Path.AddArc(X + _Rectangle.Width - (_Radius * radiusCurvature), Y, (_Radius * radiusCurvature), (_Radius * radiusCurvature), 270, 90);
                    _Path.AddLine(X + _Rectangle.Width, Y + _Radius, X + _Rectangle.Width, Y + _Rectangle.Height - (_Radius * 2));
                    _Path.AddArc(X + _Rectangle.Width - (_Radius * radiusCurvature), Y + _Rectangle.Height - (_Radius * radiusCurvature), (_Radius * radiusCurvature), (_Radius * radiusCurvature), 0, 90);
                    _Path.AddLine(X + _Rectangle.Width - (_Radius * radiusCurvature), Y + _Rectangle.Height, X + _Radius, Y + _Rectangle.Height);
                    _Path.AddArc(X, Y + _Rectangle.Height - (_Radius * radiusCurvature), (_Radius * radiusCurvature), (_Radius * radiusCurvature), 90, 90);
                    _Path.AddLine(X, Y + _Rectangle.Height - (_Radius * radiusCurvature), X, Y + _Radius);
                    _Path.AddArc(X, Y, (_Radius * radiusCurvature), (_Radius * radiusCurvature), 180, 90);

                    // this is where we create the shadow effect, so we will use a 
                    // pathgradientbursh

                    PathGradientBrush _Brush = new PathGradientBrush(_Path);

                    // set the wrapmode so that the colors will layer themselves
                    // from the outer edge in
                    _Brush.WrapMode = WrapMode.Clamp;

                    // Create a color blend to manage our colors and positions and
                    // since we need 3 colors set the default length to 3
                    ColorBlend _ColorBlend = new ColorBlend(3);

                    // here is the important part of the shadow making process, remember
                    // the clamp mode on the colorblend object layers the colors from
                    // the outside to the center so we want our transparent color first
                    // followed by the actual shadow color. Set the shadow color to a 
                    // slightly transparent DimGray, I find that it works best.

                    if (Shadow)
                    {
                        _ColorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(shadowAlpha, shadowColor), Color.FromArgb(shadowAlpha, shadowColor) };
                    }

                    else
                    {
                        _ColorBlend.Colors = new Color[] { Color.Transparent, Color.FromArgb(0, shadowColor), Color.FromArgb(0, shadowColor) };
                    }


                    // our color blend will control the distance of each color layer
                    // we want to set our transparent color to 0 indicating that the 
                    // transparent color should be the outer most color drawn, then
                    // our Dimgray color at about 10% of the distance from the edge
                    _ColorBlend.Positions = new float[] { 0f, .1f, 1f };

                    // assign the color blend to the pathgradientbrush
                    _Brush.InterpolationColors = _ColorBlend;

                    // fill the shadow with our pathgradientbrush
                    e.Graphics.FillPath(_Brush, _Path);

                    // since the shadow was drawm first we need to move the actual path
                    // up and back a little so that we can show the shadow underneath
                    // the object. To accomplish this we will create a Matrix Object
                    Matrix _Matrix = new Matrix();

                    // tell the matrix to move the path up and back the designated distance
                    _Matrix.Translate(_ShadowDistance, _ShadowDistance);

                    // assign the matrix to the graphics path of the rounded rectangle
                    _Path.Transform(_Matrix);

                    // fill the graphics path first
                    LinearGradientBrush _LinBrush = new LinearGradientBrush(this.ClientRectangle, backgroundColor1, backgroundColor2, gradientMode);
                    e.Graphics.FillPath(_LinBrush, _Path);


                    //using (LinearGradientBrush _Brush = new LinearGradientBrush(
                    //                picCanvas.ClientRectangle, Color.Tomato, Color.MistyRose, LinearGradientMode.Vertical))
                    //{
                    //    e.Graphics.FillPath(_Brush, _Path);
                    //}

                    // Draw the Graphicspath last so that we have cleaner borders
                    using (Pen _Pen = new Pen(borderColor, borderWidth))
                    {
                        e.Graphics.DrawPath(_Pen, _Path);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(GetType().Name + ".DrawRndRect() Error: " + ex.Message);
            }
        }



        #region Center Text

        //------------------------------Include in Paint----------------------------//
        //
        // CenterString(G,Text,Font,ForeColor,this.ClientRectangle);
        //
        //------------------------------Include in Paint----------------------------//

        /// <summary>
        /// Center Text
        /// </summary>
        /// <param name="G">Set Graphics</param>
        /// <param name="T">Set string</param>
        /// <param name="F">Set Font</param>
        /// <param name="C">Set color</param>
        /// <param name="R">Set rectangle</param>
        private static void CenterString(System.Drawing.Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point((int)(R.Width / 2 - (TS.Width / 2)), (int)(R.Height / 2 - (TS.Height / 2))));
            }
        }

        #endregion



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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
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
