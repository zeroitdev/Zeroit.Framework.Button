// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="UniqueButton.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{
    #region ZeroitUniqueButton

    /// <summary>
    /// A class collection for rendering Unique button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitButtonUniqueDesigner))]
    public class ZeroitUniqueButton : Control
    {

        #region Variables

        /// <summary>
        /// The mouse state
        /// </summary>
        private int MouseState;
        /// <summary>
        /// The shape
        /// </summary>
        private GraphicsPath Shape;
        /// <summary>
        /// The inactive gb
        /// </summary>
        private LinearGradientBrush InactiveGB;
        /// <summary>
        /// The pressed gb
        /// </summary>
        private LinearGradientBrush PressedGB;
        /// <summary>
        /// The pressed contour gb
        /// </summary>
        private LinearGradientBrush PressedContourGB;
        /// <summary>
        /// The hover gb
        /// </summary>
        private LinearGradientBrush HoverGB;
        /// <summary>
        /// The hover contour gb
        /// </summary>
        private LinearGradientBrush HoverContourGB;
        /// <summary>
        /// The inactive contour gb
        /// </summary>
        private LinearGradientBrush InactiveContourGB;
        /// <summary>
        /// The r1
        /// </summary>
        private Rectangle R1;
        /// <summary>
        /// The p1
        /// </summary>
        private Pen P1;
        /// <summary>
        /// The p2
        /// </summary>
        private Pen P2;
        /// <summary>
        /// The p3
        /// </summary>
        private Pen P3;


        /// <summary>
        /// The background color1
        /// </summary>
        private Color _BackgroundColor1 = Color.Gray;
        /// <summary>
        /// The background color2
        /// </summary>
        private Color _BackgroundColor2 = Color.LightGray;
        /// <summary>
        /// The background color pressed1
        /// </summary>
        private Color _BackgroundColorPressed1 = Color.Gray;
        /// <summary>
        /// The background color pressed2
        /// </summary>
        private Color _BackgroundColorPressed2 = Color.LightGray;
        /// <summary>
        /// The background color pressed contour1
        /// </summary>
        private Color _BackgroundColorPressedContour1 = Color.Black;
        /// <summary>
        /// The background color pressed contour2
        /// </summary>
        private Color _BackgroundColorPressedContour2 = Color.LightGray;
        /// <summary>
        /// The background contour1
        /// </summary>
        private Color _BackgroundContour1 = Color.Black;
        /// <summary>
        /// The background contour2
        /// </summary>
        private Color _BackgroundContour2 = Color.LightGray;
        /// <summary>
        /// The hover contour1
        /// </summary>
        private Color _HoverContour1 = Color.Black;
        /// <summary>
        /// The hover contour2
        /// </summary>
        private Color _HoverContour2 = Color.LightGray;
        /// <summary>
        /// The hover back color1
        /// </summary>
        private Color _HoverBackColor1 = Color.Gray;
        /// <summary>
        /// The hover back color2
        /// </summary>
        private Color _HoverBackColor2 = Color.LightGray;
        /// <summary>
        /// The radius upper left
        /// </summary>
        private Int32 _RadiusUpperLeft = 10;
        /// <summary>
        /// The radius upper right
        /// </summary>
        private Int32 _RadiusUpperRight = 10;
        /// <summary>
        /// The radius bottom left
        /// </summary>
        private Int32 _RadiusBottomLeft = 10;
        /// <summary>
        /// The radius bottom right
        /// </summary>
        private Int32 _RadiusBottomRight = 10;
        /// <summary>
        /// The angle
        /// </summary>
        private Double _Angle = 90f;
        /// <summary>
        /// The correct angle
        /// </summary>
        private float CorrectAngle;
        /// <summary>
        /// The text alignment
        /// </summary>
        private StringAlignment _TextAlignment = StringAlignment.Center;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

        /// <summary>
        /// The border
        /// </summary>
        private Color border = Color.Black;
        /// <summary>
        /// The borderwidth
        /// </summary>
        private float borderwidth = 1;

        #endregion

        #region Image Designer

        #region Include in paint method

        /////////////////////////////////////////////////////////////////////////////////////////////////// 
        /// <summary>
        /// The image
        /// </summary>
        /// ------------------------Add this to the Paint Method ------------------------       Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   if ((Image == null))                                                                        {                                                                                       _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           {                                                                               Alignment = _TextAlignment,                                                 LineAlignment = StringAlignment.Center                                      });                                                                             }                                                                                      else                                                                                        {                                                                                      _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          {                                                                               Alignment = _TextAlignment,                                                 LineAlignment = StringAlignment.Center                                      });                                                                             }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Fields
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        #endregion

        #region Include in Public Properties
        /// <summary>
        /// Sets the Image
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image size
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image alignment
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        #endregion

        #region Include in Private Methods
        /// <summary>
        /// Images the location.
        /// </summary>
        /// <param name="SF">The sf.</param>
        /// <param name="Area">The area.</param>
        /// <param name="ImageArea">The image area.</param>
        /// <returns>PointF.</returns>
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        /// <summary>
        /// Gets the string format.
        /// </summary>
        /// <param name="_ContentAlignment">The content alignment.</param>
        /// <returns>StringFormat.</returns>
        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion
        #endregion

        #region Properties

        /// <summary>
        /// Sets the Text to display on the button
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Sets the Text alignment
        /// </summary>
        /// <value>The text alignment.</value>
        public StringAlignment TextAlignment
        {
            get { return this._TextAlignment; }
            set
            {
                this._TextAlignment = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Border color
        /// </summary>
        /// <value>The border.</value>
        public Color Border
        {
            get { return border; }
            set
            {
                border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background Color
        /// </summary>
        /// <value>The background color1.</value>
        /// <remarks>This sets the Linear gradient color 1 for the background</remarks>
        public Color BackgroundColor1
        {
            get { return this._BackgroundColor1; }
            set
            {
                this._BackgroundColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background Color
        /// </summary>
        /// <value>The background color2.</value>
        /// <remarks>This sets the Linear gradient color 2 for the background</remarks>
        public Color BackgroundColor2
        {
            get { return this._BackgroundColor2; }
            set
            {
                this._BackgroundColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background Color
        /// </summary>
        /// <value>The background color pressed1.</value>
        /// <remarks>This sets the Linear gradient color 1 for the background
        /// when the button is Pressed</remarks>
        public Color BackgroundColorPressed1
        {
            get { return this._BackgroundColorPressed1; }
            set
            {
                this._BackgroundColorPressed1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background Color
        /// </summary>
        /// <value>The background color pressed2.</value>
        /// <remarks>This sets the Linear gradient color 2 for the background
        /// when the button is Pressed</remarks>
        public Color BackgroundColorPressed2
        {
            get { return this._BackgroundColorPressed2; }
            set
            {
                this._BackgroundColorPressed2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Pressed Border Color
        /// </summary>
        /// <value>The background color pressed contour1.</value>
        /// <remarks>This sets the Linear gradient color 1 for the border
        /// when the button is Pressed</remarks>
        public Color BackgroundColorPressedContour1
        {
            get { return this._BackgroundColorPressedContour1; }
            set
            {
                this._BackgroundColorPressedContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Pressed Border Color
        /// </summary>
        /// <value>The background color pressed contour2.</value>
        /// <remarks>This sets the Linear gradient color 2 for the border
        /// when the button is Pressed</remarks>
        public Color BackgroundColorPressedContour2
        {
            get { return this._BackgroundColorPressedContour2; }
            set
            {
                this._BackgroundColorPressedContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background Color when Hovered
        /// </summary>
        /// <value>The back hover color1.</value>
        /// <remarks>This sets the Linear gradient color 1 for the background
        /// when the button is Hovered</remarks>
        public Color BackHoverColor1
        {
            get { return this._HoverBackColor1; }
            set
            {
                this._HoverBackColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background Color when Hovered
        /// </summary>
        /// <value>The back hover color2.</value>
        /// <remarks>This sets the Linear gradient color 2 for the background
        /// when the button is Hovered</remarks>
        public Color BackHoverColor2
        {
            get { return this._HoverBackColor2; }
            set
            {
                this._HoverBackColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Border Color when Hovered
        /// </summary>
        /// <value>The back hover contour1.</value>
        /// <remarks>This sets the Linear gradient color 1 for the border
        /// when the button is Hovered</remarks>
        public Color BackHoverContour1
        {
            get { return this._HoverContour1; }
            set
            {
                this._HoverContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Border Color when Hovered
        /// </summary>
        /// <value>The back hover contour2.</value>
        /// <remarks>This sets the Linear gradient color 2 for the border
        /// when the button is Hovered</remarks>
        public Color BackHoverContour2
        {
            get { return this._HoverContour2; }
            set
            {
                this._HoverContour2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Border Color in its Default state
        /// </summary>
        /// <value>The background contour1.</value>
        /// <remarks>This sets the Linear gradient color 1 for the border
        /// when the button is in its Default state</remarks>
        public Color BackgroundContour1
        {
            get { return this._BackgroundContour1; }
            set
            {
                this._BackgroundContour1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Border Color in its Default state
        /// </summary>
        /// <value>The background contour2.</value>
        /// <remarks>This sets the Linear gradient color 2 for the border
        /// when the button is in its Default state</remarks>
        public Color BackgroundContour2
        {
            get { return this._BackgroundContour2; }
            set
            {
                this._BackgroundContour2 = value;
                this.Invalidate();
            }
        }


        /// <summary>
        /// Sets the Border Width
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get { return borderwidth; }
            set
            {
                int min = Math.Min(
                    Math.Min(RadiusUpperLeft, RadiusUpperRight), 
                    Math.Min(RadiusBottomLeft, RadiusBottomRight)
                    );

                if (value >= min)
                {
                    value = min - 1;
                    Invalidate();
                }

                borderwidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        /// <value>The radius upper left.</value>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusUpperLeft
        {
            get { return this._RadiusUpperLeft; }
            set
            {
                if (_RadiusUpperLeft == null)
                {
                    this._RadiusUpperLeft = 10;

                }

                
                this._RadiusUpperLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius upper right.</value>
        [Description("This changes the upper right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusUpperRight
        {
            get { return this._RadiusUpperRight; }
            set
            {
                if (_RadiusUpperRight == null)
                {
                    this._RadiusUpperRight = 10;

                }

                this._RadiusUpperRight = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius bottom left.</value>
        [Description("This changes the bottom left radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusBottomLeft
        {
            get { return this._RadiusBottomLeft; }
            set
            {
                if (_RadiusBottomLeft == null)
                {
                    this._RadiusBottomLeft = 10;

                }

                this._RadiusBottomLeft = value;
                this.Invalidate();


            }
        }

        /// <summary>
        /// This changes the upper right radius of the button
        /// </summary>
        /// <value>The radius bottom right.</value>
        [Description("This changes the bottom right radius of the button"),
        Category("Appearance"), DefaultValue(typeof(Int32), "10"),
        Browsable(true)]
        public Int32 RadiusBottomRight
        {
            get { return this._RadiusBottomRight; }
            set
            {
                if (_RadiusBottomRight == null)
                {
                    this._RadiusBottomRight = 10;

                }

                this._RadiusBottomRight = value;
                this.Invalidate();


            }
        }


        /// <summary>
        /// This changes the upper left radius of the button
        /// </summary>
        /// <value>The background angle.</value>
        [Description("This changes the upper left radius of the button"),
        Category("Appearance"),
        Browsable(true)]
        public Double BackgroundAngle
        {
            get { return this._Angle; }
            set
            {
                if (_Angle == null)
                {
                    this._Angle = 30f;
                }

                this._Angle = value;
                CorrectAngle = DoubleToFloat(_Angle);

                this.Invalidate();

            }
        }


        /// <summary>
        /// Doubles to float.
        /// </summary>
        /// <param name="dValue">The d value.</param>
        /// <returns>System.Single.</returns>
        public static float DoubleToFloat(double dValue)
        {
            if (float.IsPositiveInfinity(Convert.ToSingle(dValue)))
            {
                return float.MaxValue;
            }
            if (float.IsNegativeInfinity(Convert.ToSingle(dValue)))
            {
                return float.MinValue;
            }
            return Convert.ToSingle(dValue);
        }


        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.AntiAlias;

        /// <summary>
        /// Sets the Text rendering mode
        /// </summary>
        /// <value>The text rendering.</value>
        public TextRenderingHint TextRendering
        {
            get { return textrendering; }
            set
            {
                textrendering = value;
                Invalidate();
            }
        }

        #endregion


        #endregion

        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            MouseState = 0;
            ClickOnMouseUp(e);
            Invalidate();
            base.OnMouseUp(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseState = 1;
            ClickOnMouseDown(e);
            Invalidate();
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            MouseState = 0;
            // [Inactive]
            Invalidate();
            // Update control
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseHover" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            MouseState = 2;
            Invalidate();
            base.OnMouseHover(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of the Unique button class
        /// </summary>
        public ZeroitUniqueButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 14);
            ForeColor = Color.White;
            Size = new Size(166, 40);
            _TextAlignment = StringAlignment.Center;
            P1 = new Pen(InactiveContourGB);

            IncludeInConstructor();
        }

        #endregion

        #region Overrides and Events

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);

            #region Old Code
            //if (Width > 0 && Height > 0)
            //{
            //    Shape = new GraphicsPath();
            //    R1 = new Rectangle(0, 0, Width, Height);

            //    // Button Background Colors
            //    InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColor1, _BackgroundColor2, CorrectAngle);
            //    InactiveContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundContour1, _BackgroundContour2, CorrectAngle);
            //    PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColorPressed1, _BackgroundColorPressed2, CorrectAngle);
            //    PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackgroundColorPressedContour1, BackgroundColorPressedContour2, CorrectAngle);
            //    HoverGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverBackColor1, _HoverBackColor2, CorrectAngle);
            //    HoverContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverContour1, _HoverContour2, CorrectAngle);

            //    P3 = new Pen(PressedContourGB);
            //    P2 = new Pen(HoverContourGB);
            //}

            // Button Radius iTalk
            //var _Shape = Shape;
            //_Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            //_Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            //_Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            //_Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            //_Shape.CloseAllFigures(); 
            #endregion

            DrawButton();
            
            Invalidate();
        }

        /// <summary>
        /// Draws the button.
        /// </summary>
        private void DrawButton()
        {
            Shape = new GraphicsPath();
            R1 = new Rectangle(0, 0, Width, Height);

            // Button Background Colors
            InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColor1, _BackgroundColor2,
                CorrectAngle);
            InactiveContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundContour1,
                _BackgroundContour2, CorrectAngle);
            PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColorPressed1,
                _BackgroundColorPressed2, CorrectAngle);
            PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackgroundColorPressedContour1,
                BackgroundColorPressedContour2, CorrectAngle);
            HoverGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverBackColor1, _HoverBackColor2,
                CorrectAngle);
            HoverContourGB =
                new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverContour1, _HoverContour2, CorrectAngle);

            P3 = new Pen(PressedContourGB);
            P2 = new Pen(HoverContourGB);


            #region Working Code
            //Button Radius 
            //var _Shape = Shape;
            //_Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            //_Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            //_Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight,
            //    _RadiusBottomRight, 0, 90);
            //_Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            //_Shape.CloseAllFigures(); 
            #endregion

            //Button Radius 
            var _Shape = Shape;
            _Shape.AddArc(0 + BorderWidth, 0 + BorderWidth, _RadiusUpperLeft - BorderWidth, _RadiusUpperLeft - BorderWidth, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1 - BorderWidth, 0 + BorderWidth, _RadiusUpperRight - BorderWidth/1, _RadiusUpperRight - BorderWidth, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1 - BorderWidth, Height - _RadiusBottomRight - 1 - BorderWidth, _RadiusBottomRight - BorderWidth/1,
                _RadiusBottomRight - BorderWidth, 0, 90);
            _Shape.AddArc(0 + BorderWidth, 0 + Height - _RadiusBottomLeft - 1 - BorderWidth, _RadiusBottomLeft - BorderWidth, _RadiusBottomLeft - BorderWidth, 90, 90);
            _Shape.CloseAllFigures();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {

            TransparentInPaint(e.Graphics);

            var _G = e.Graphics;
            _G.SmoothingMode = SmoothingMode.HighQuality;
            _G.TextRenderingHint = textrendering;

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            DrawButton();

            switch (MouseState)
            {
                case 0:
                    _G.FillPath(InactiveGB, Shape);
                    _G.DrawPath(new Pen(border, borderwidth), Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }

                    break;
                case 1:
                    _G.FillPath(PressedGB, Shape);
                    _G.DrawPath(P3, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;

                case 2:
                    _G.FillPath(HoverGB, Shape);
                    _G.DrawPath(P2, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }

            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, Width, Height);

                // Button Background Colors
                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColor1, _BackgroundColor2, CorrectAngle);
                InactiveContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundContour1, _BackgroundContour2, CorrectAngle);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _BackgroundColorPressed1, _BackgroundColorPressed2, CorrectAngle);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), BackgroundColorPressedContour1, BackgroundColorPressedContour2, CorrectAngle);
                HoverGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverBackColor1, _HoverBackColor2, CorrectAngle);
                HoverContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), _HoverContour1, _HoverContour2, CorrectAngle);

                P3 = new Pen(PressedContourGB);
                P2 = new Pen(HoverContourGB);


            }

            // Button Radius iTalk
            //var _Shape = Shape;
            //_Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            //_Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            //_Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            //_Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            //_Shape.CloseAllFigures();


            //Button Radius 
            var _Shape = Shape;
            _Shape.AddArc(0, 0, _RadiusUpperLeft, _RadiusUpperLeft, 180, 90);
            _Shape.AddArc(Width - _RadiusUpperRight - 1, 0, _RadiusUpperRight, _RadiusUpperRight, 270, 90);
            _Shape.AddArc(Width - _RadiusBottomRight - 1, Height - _RadiusBottomRight - 1, _RadiusBottomRight, _RadiusBottomRight, 0, 90);
            _Shape.AddArc(0, 0 + Height - _RadiusBottomLeft - 1, _RadiusBottomLeft, _RadiusBottomLeft, 90, 90);
            _Shape.CloseAllFigures();



            base.OnPaint(e);
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

        private void ClickOnMouseUp(MouseEventArgs e)
        {

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


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonUniqueDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonUniqueDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitButtonUniqueDesignerSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonUniqueDesignerSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitButtonUniqueDesignerSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitUniqueButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonUniqueDesignerSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonUniqueDesignerSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitUniqueButton;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="System.ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return colUserControl.Image; }
            set
            {
                GetPropertyByName("Image").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return colUserControl.ImageAlign; }
            set
            {
                GetPropertyByName("ImageAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color1.
        /// </summary>
        /// <value>The background color1.</value>
        public Color BackgroundColor1
        {
            get { return colUserControl.BackgroundColor1; }
            set
            {
                GetPropertyByName("BackgroundColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color2.
        /// </summary>
        /// <value>The background color2.</value>
        public Color BackgroundColor2
        {
            get { return colUserControl.BackgroundColor2; }
            set
            {
                GetPropertyByName("BackgroundColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color pressed1.
        /// </summary>
        /// <value>The background color pressed1.</value>
        public Color BackgroundColorPressed1
        {
            get { return colUserControl.BackgroundColorPressed1; }
            set
            {
                GetPropertyByName("BackgroundColorPressed1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color pressed2.
        /// </summary>
        /// <value>The background color pressed2.</value>
        public Color BackgroundColorPressed2
        {
            get { return colUserControl.BackgroundColorPressed2; }
            set
            {
                GetPropertyByName("BackgroundColorPressed2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color pressed contour1.
        /// </summary>
        /// <value>The background color pressed contour1.</value>
        public Color BackgroundColorPressedContour1
        {
            get { return colUserControl.BackgroundColorPressedContour1; }
            set
            {
                GetPropertyByName("BackgroundColorPressedContour1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background color pressed contour2.
        /// </summary>
        /// <value>The background color pressed contour2.</value>
        public Color BackgroundColorPressedContour2
        {
            get { return colUserControl.BackgroundColorPressedContour2; }
            set
            {
                GetPropertyByName("BackgroundColorPressedContour2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the back hover color1.
        /// </summary>
        /// <value>The back hover color1.</value>
        public Color BackHoverColor1
        {
            get { return colUserControl.BackHoverColor1; }
            set
            {
                GetPropertyByName("BackHoverColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the back hover color2.
        /// </summary>
        /// <value>The back hover color2.</value>
        public Color BackHoverColor2
        {
            get { return colUserControl.BackHoverColor2; }
            set
            {
                GetPropertyByName("BackHoverColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the back hover contour1.
        /// </summary>
        /// <value>The back hover contour1.</value>
        public Color BackHoverContour1
        {
            get { return colUserControl.BackHoverContour1; }
            set
            {
                GetPropertyByName("BackHoverContour1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the back hover contour2.
        /// </summary>
        /// <value>The back hover contour2.</value>
        public Color BackHoverContour2
        {
            get { return colUserControl.BackHoverContour2; }
            set
            {
                GetPropertyByName("BackHoverContour2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return colUserControl.Text; }
            set
            {
                GetPropertyByName("Text").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius upper left.
        /// </summary>
        /// <value>The radius upper left.</value>
        public Int32 RadiusUpperLeft
        {
            get { return colUserControl.RadiusUpperLeft; }
            set
            {
                GetPropertyByName("RadiusUpperLeft").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius upper right.
        /// </summary>
        /// <value>The radius upper right.</value>
        public Int32 RadiusUpperRight
        {
            get { return colUserControl.RadiusUpperRight; }
            set
            {
                GetPropertyByName("RadiusUpperRight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius bottom left.
        /// </summary>
        /// <value>The radius bottom left.</value>
        public Int32 RadiusBottomLeft
        {
            get { return colUserControl.RadiusBottomLeft; }
            set
            {
                GetPropertyByName("RadiusBottomLeft").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the radius bottom right.
        /// </summary>
        /// <value>The radius bottom right.</value>
        public Int32 RadiusBottomRight
        {
            get { return colUserControl.RadiusBottomRight; }
            set
            {
                GetPropertyByName("RadiusBottomRight").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the background angle.
        /// </summary>
        /// <value>The background angle.</value>
        public Double BackgroundAngle
        {
            get { return colUserControl.BackgroundAngle; }
            set
            {
                GetPropertyByName("BackgroundAngle").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get { return colUserControl.BorderWidth; }
            set
            {
                GetPropertyByName("BorderWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public Color Border
        {
            get { return colUserControl.Border; }
            set
            {
                GetPropertyByName("Border").SetValue(colUserControl, value);
            }
        }



        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Selects the image of the button."));
            items.Add(new DesignerActionPropertyItem("ImageAlign",
                                 "Image Align", "Appearance",
                                 "Selects the image alignment."));

            items.Add(new DesignerActionPropertyItem("BackgroundAngle",
                                 "Background Angle", "Appearance",
                                 "Selects the background color angle."));

            items.Add(new DesignerActionPropertyItem("Border",
                                 "Border", "Appearance",
                                 "Selects the border color."));

            items.Add(new DesignerActionPropertyItem("BorderWidth",
                                 "BorderWidth", "Appearance",
                                 "Sets the border width."));

            items.Add(new DesignerActionPropertyItem("BackgroundColor1",
                                 "Background Color1", "Appearance",
                                 "Selects the background color of the button."));

            items.Add(new DesignerActionPropertyItem("BackgroundColor2",
                                 "Background Color2", "Appearance",
                                 "Selects the background color of the button."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressed1",
                                 "Background ColorPressed1", "Appearance",
                                 "Selects the background color when the button is pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressed2",
                                 "Background ColorPressed2", "Appearance",
                                 "Selects the background color when the button is pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressedContour1",
                                 "Background ColorPressed Contour1", "Appearance",
                                 "Selects the background contour color when the button is pressed."));

            items.Add(new DesignerActionPropertyItem("BackgroundColorPressedContour2",
                                 "Background ColorPressed Contour2", "Appearance",
                                 "Selects the background contour color when the button is pressed."));

            items.Add(new DesignerActionPropertyItem("BackHoverColor1",
                                 "Background Hover Color1", "Appearance",
                                 "Selects the background color when the button is hovered."));

            items.Add(new DesignerActionPropertyItem("BackHoverColor2",
                                 "Background Hover Color2", "Appearance",
                                 "Selects the background color when the button is hovered."));

            items.Add(new DesignerActionPropertyItem("BackHoverContour1",
                                 "Background Hover Contour1", "Appearance",
                                 "Selects the background contour color when the button is hovered."));

            items.Add(new DesignerActionPropertyItem("BackHoverContour2",
                                 "Background Hover Contour2", "Appearance",
                                 "Selects the background contour color when the button is hovered."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the Text of the button."));


            items.Add(new DesignerActionPropertyItem("RadiusUpperLeft",
                                 "Radius Upper Left", "Appearance",
                                 "Selects the background contour color when the button is pressed."));

            items.Add(new DesignerActionPropertyItem("RadiusUpperRight",
                                 "Radius Upper Right", "Appearance",
                                 "Selects the background contour color when the button is pressed."));

            items.Add(new DesignerActionPropertyItem("RadiusBottomLeft",
                                 "Radius Bottom Left", "Appearance",
                                 "Selects the background contour color when the button is pressed."));

            items.Add(new DesignerActionPropertyItem("RadiusBottomRight",
                                 "Radius Bottom Right", "Appearance",
                                 "Selects the background contour color when the button is pressed."));





            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion


    #endregion
}
