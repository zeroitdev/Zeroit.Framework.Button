// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="RoundButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{
    #region ZeroitRoundButton

    /// <summary>
    /// A class collection for rendering Round Button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitButtonRoundDefaultDesigner))]
    public class ZeroitRndButtonDefault : Control
    {

        #region  Variables

        /// <summary>
        /// The mouse state
        /// </summary>
        private int MouseState;
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
        /// The r1
        /// </summary>
        private Rectangle R1;
        /// <summary>
        /// The p1
        /// </summary>
        private Pen P1;
        /// <summary>
        /// The p3
        /// </summary>
        private Pen P3;
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image pressed
        /// </summary>
        private Image _ImagePressed;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The radius
        /// </summary>
        private Int32 _Radius = 10;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;

        #endregion

        #region  Image Designer

        /// <summary>
        /// Images the location.
        /// </summary>
        /// <param name="SF">The sf.</param>
        /// <param name="Area">The area.</param>
        /// <param name="ImageArea">The image area.</param>
        /// <returns>PointF.</returns>
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = new PointF();
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = (float)((Area.Width - ImageArea.Width) / 2);
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
                    MyPoint.Y = (float)((Area.Height - ImageArea.Height) / 2);
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

        #region  Properties

        /// <summary>
        /// Sets the default Background Image
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get
            {
                return _Image;
            }
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
        /// Sets the Background Image when the button is Pressed
        /// </summary>
        /// <value>The image pressed.</value>
        public Image ImagePressed
        {
            get
            {
                return _ImagePressed;
            }
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

                _ImagePressed = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image Size
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get
            {
                return _ImageSize;
            }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image Alignment
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get
            {
                return _ImageAlign;
            }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the button Radius
        /// </summary>
        /// <value>The radius.</value>
        [Browsable(false)]
        public Int32 Radius
        {
            get { return this._Radius; }
            set
            {
                if (_Radius == null)
                {
                    this._Radius = 10;

                }

                else
                {
                    this._Radius = value;
                    int _reassignRadius = _Radius;

                    if (_reassignRadius > 300)
                    {
                        this._Radius = 300;
                    }
                    this.Invalidate();
                }



            }
        }


        #endregion

        #region  EventArgs

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
            Invalidate();
            base.OnMouseLeave(e);
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

        /// <summary>
        /// Creates an instance of the Round Button class
        /// </summary>
        public ZeroitRndButtonDefault()
        {
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint), true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            //Size = new Size(100, 100);
            P1 = new Pen(Color.FromArgb(190, 190, 190)); // P1 = Border color
            IncludeInConstructor();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(System.EventArgs e)
        {

            this.Size = new Size(Width, Height);
            //this.Size = new Size(100, 100);
            R1 = new Rectangle(0, 0, Width, Height);

            InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(255, 255, 255), Color.FromArgb(240, 240, 240), 90.0F);
            PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(245, 245, 245), Color.FromArgb(240, 240, 240), 90.0F);
            PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(167, 167, 167), Color.FromArgb(167, 167, 167), 90.0F);
            P3 = new Pen(PressedContourGB);

            Invalidate();
            base.OnResize(e);
        }

        /// <summary>
        /// Finishes the drawing.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="center">The center.</param>
        /// <param name="radius">The radius.</param>
        private void FinishDrawing(Graphics g, Point center, int radius)
        {
            Rectangle MyCircle = new Rectangle((int)(center.X / 2), (int)(center.Y / 2), /*radius*/((Width - 5) / 2) * 2, /*radius*/((Height - 10) / 2) * 2);
            PointF ImagePoint = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);


            switch (MouseState)
            {
                case 0: //Inactive
                    g.FillEllipse(InactiveGB, MyCircle);
                    g.DrawEllipse(P1, MyCircle);

                    if (Image == null)
                    {
                    }
                    else
                    {
                        #region Draw Image
                        ////g.DrawImage(_Image, x, y, width, height);

                        //if (_Radius <= 10)
                        //{
                        //    g.DrawImage(_Image, _Radius - 4, _Radius - 4, 8, 8);
                        //}

                        //else if (_Radius > 10 && _Radius <= 20)
                        //{
                        //    g.DrawImage(_Image, _Radius - 6, _Radius - 6, 12, 12);
                        //}

                        //else if (_Radius > 20 && _Radius <= 30)
                        //{
                        //    g.DrawImage(_Image, _Radius - 8, _Radius - 8, 16, 16);
                        //}

                        //else if (_Radius > 30 && _Radius <= 40)
                        //{
                        //    g.DrawImage(_Image, _Radius - 10, _Radius - 10, 20, 20);
                        //}

                        //else if (_Radius > 40 && _Radius <= 50)
                        //{
                        //    g.DrawImage(_Image, _Radius - 12, _Radius - 12, 24, 24);
                        //}

                        //else if (_Radius > 50 && _Radius <= 60)
                        //{
                        //    g.DrawImage(_Image, _Radius - 14, _Radius - 14, 28, 28);
                        //}

                        //else if (_Radius > 60 && _Radius <= 70)
                        //{
                        //    g.DrawImage(_Image, _Radius - 16, _Radius - 16, 32, 32);
                        //}

                        //else if (_Radius > 70 && _Radius <= 80)
                        //{
                        //    g.DrawImage(_Image, _Radius - 18, _Radius - 18, 36, 36);
                        //}

                        //else if (_Radius > 80 && _Radius <= 90)
                        //{
                        //    g.DrawImage(_Image, _Radius - 20, _Radius - 20, 40, 40);
                        //}

                        //else if (_Radius > 90 && _Radius <= 100)
                        //{
                        //    g.DrawImage(_Image, _Radius - 22, _Radius - 22, 44, 44);
                        //}

                        //else if (_Radius > 100 && _Radius <= 110)
                        //{
                        //    g.DrawImage(_Image, _Radius - 24, _Radius - 24, 48, 48);
                        //}

                        //else if (_Radius > 110 && _Radius <= 120)
                        //{
                        //    g.DrawImage(_Image, _Radius - 26, _Radius - 26, 52, 52);
                        //}

                        //else if (_Radius > 120 && _Radius <= 130)
                        //{
                        //    g.DrawImage(_Image, _Radius - 28, _Radius - 28, 56, 56);
                        //}

                        //else if (_Radius > 130 && _Radius <= 140)
                        //{
                        //    g.DrawImage(_Image, _Radius - 30, _Radius - 30, 60, 60);
                        //}

                        //else if (_Radius > 140 && _Radius <= 150)
                        //{
                        //    g.DrawImage(_Image, _Radius - 32, _Radius - 32, 64, 64);
                        //}

                        //else if (_Radius > 150 && _Radius <= 160)
                        //{
                        //    g.DrawImage(_Image, _Radius - 34, _Radius - 34, 68, 68);
                        //}

                        //else if (_Radius > 160 && _Radius <= 170)
                        //{
                        //    g.DrawImage(_Image, _Radius - 36, _Radius - 36, 72, 72);
                        //}

                        //else if (_Radius > 170 && _Radius <= 180)
                        //{
                        //    g.DrawImage(_Image, _Radius - 38, _Radius - 38, 76, 76);
                        //}

                        //else if (_Radius > 180 && _Radius <= 190)
                        //{
                        //    g.DrawImage(_Image, _Radius - 40, _Radius - 40, 80, 80);
                        //}

                        //else if (_Radius > 190 && _Radius <= 200)
                        //{
                        //    g.DrawImage(_Image, _Radius - 42, _Radius - 42, 84, 84);
                        //}

                        //else if (_Radius > 200 && _Radius <= 210)
                        //{
                        //    g.DrawImage(_Image, _Radius - 44, _Radius - 44, 88, 88);
                        //}

                        //else if (_Radius > 210 && _Radius <= 220)
                        //{
                        //    g.DrawImage(_Image, _Radius - 46, _Radius - 46, 92, 92);
                        //}

                        //else if (_Radius > 220 && _Radius <= 230)
                        //{
                        //    g.DrawImage(_Image, _Radius - 48, _Radius - 48, 96, 96);
                        //}

                        //else if (_Radius > 230 && _Radius <= 240)
                        //{
                        //    g.DrawImage(_Image, _Radius - 50, _Radius - 50, 100, 100);
                        //}

                        //else if (_Radius > 240 && _Radius <= 250)
                        //{
                        //    g.DrawImage(_Image, _Radius - 52, _Radius - 52, 104, 104);
                        //}

                        //else if (_Radius > 250 && _Radius <= 260)
                        //{
                        //    g.DrawImage(_Image, _Radius - 54, _Radius - 54, 108, 108);
                        //}

                        //else if (_Radius > 260 && _Radius <= 270)
                        //{
                        //    g.DrawImage(_Image, _Radius - 56, _Radius - 56, 112, 112);
                        //}

                        //else if (_Radius > 270 && _Radius <= 280)
                        //{
                        //    g.DrawImage(_Image, _Radius - 58, _Radius - 58, 116, 116);
                        //}

                        //else if (_Radius > 280 && _Radius <= 290)
                        //{
                        //    g.DrawImage(_Image, _Radius - 60, _Radius - 60, 120, 120);
                        //}

                        //else if (_Radius > 290 && _Radius <= 300)
                        //{
                        //    g.DrawImage(_Image, _Radius - 62, _Radius - 62, 124, 124);
                        //}

                        //else if (_Radius > 300)
                        //{
                        //    _Radius = 300;
                        //    //g.DrawImage(_Image, _Radius - 62, _Radius - 62, 124, 124);
                        //    g.DrawImage(_Image, _Radius - 72, _Radius - 72, 144, 144);
                        //}
                        #endregion

                        PointF ImgPoint = ImageLocation(GetStringFormat(_ImageAlign), Size, ImageSize);
                        if (Image != null)
                        {
                            g.DrawImage(_Image, (int)ImgPoint.X, (int)ImgPoint.Y, ImageSize.Width, ImageSize.Height);
                        }

                    }
                    break;

                case 1: //Pressed
                    g.FillEllipse(PressedGB, MyCircle);
                    g.DrawEllipse(P1, MyCircle);

                    if (_ImagePressed == null)
                    {
                    }
                    else
                    {
                        #region Draw Image
                        ////g.DrawImage(_Image, x, y, width, height);

                        //if (_Radius <= 10)
                        //{
                        //    g.DrawImage(_Image, _Radius - 4, _Radius - 4, 8, 8);
                        //}

                        //else if (_Radius > 10 && _Radius <= 20)
                        //{
                        //    g.DrawImage(_Image, _Radius - 6, _Radius - 6, 12, 12);
                        //}

                        //else if (_Radius > 20 && _Radius <= 30)
                        //{
                        //    g.DrawImage(_Image, _Radius - 8, _Radius - 8, 16, 16);
                        //}

                        //else if (_Radius > 30 && _Radius <= 40)
                        //{
                        //    g.DrawImage(_Image, _Radius - 10, _Radius - 10, 20, 20);
                        //}

                        //else if (_Radius > 40 && _Radius <= 50)
                        //{
                        //    g.DrawImage(_Image, _Radius - 12, _Radius - 12, 24, 24);
                        //}

                        //else if (_Radius > 50 && _Radius <= 60)
                        //{
                        //    g.DrawImage(_Image, _Radius - 14, _Radius - 14, 28, 28);
                        //}

                        //else if (_Radius > 60 && _Radius <= 70)
                        //{
                        //    g.DrawImage(_Image, _Radius - 16, _Radius - 16, 32, 32);
                        //}

                        //else if (_Radius > 70 && _Radius <= 80)
                        //{
                        //    g.DrawImage(_Image, _Radius - 18, _Radius - 18, 36, 36);
                        //}

                        //else if (_Radius > 80 && _Radius <= 90)
                        //{
                        //    g.DrawImage(_Image, _Radius - 20, _Radius - 20, 40, 40);
                        //}

                        //else if (_Radius > 90 && _Radius <= 100)
                        //{
                        //    g.DrawImage(_Image, _Radius - 22, _Radius - 22, 44, 44);
                        //}

                        //else if (_Radius > 100 && _Radius <= 110)
                        //{
                        //    g.DrawImage(_Image, _Radius - 24, _Radius - 24, 48, 48);
                        //}

                        //else if (_Radius > 110 && _Radius <= 120)
                        //{
                        //    g.DrawImage(_Image, _Radius - 26, _Radius - 26, 52, 52);
                        //}

                        //else if (_Radius > 120 && _Radius <= 130)
                        //{
                        //    g.DrawImage(_Image, _Radius - 28, _Radius - 28, 56, 56);
                        //}

                        //else if (_Radius > 130 && _Radius <= 140)
                        //{
                        //    g.DrawImage(_Image, _Radius - 30, _Radius - 30, 60, 60);
                        //}

                        //else if (_Radius > 140 && _Radius <= 150)
                        //{
                        //    g.DrawImage(_Image, _Radius - 32, _Radius - 32, 64, 64);
                        //}

                        //else if (_Radius > 150 && _Radius <= 160)
                        //{
                        //    g.DrawImage(_Image, _Radius - 34, _Radius - 34, 68, 68);
                        //}

                        //else if (_Radius > 160 && _Radius <= 170)
                        //{
                        //    g.DrawImage(_Image, _Radius - 36, _Radius - 36, 72, 72);
                        //}

                        //else if (_Radius > 170 && _Radius <= 180)
                        //{
                        //    g.DrawImage(_Image, _Radius - 38, _Radius - 38, 76, 76);
                        //}

                        //else if (_Radius > 180 && _Radius <= 190)
                        //{
                        //    g.DrawImage(_Image, _Radius - 40, _Radius - 40, 80, 80);
                        //}

                        //else if (_Radius > 190 && _Radius <= 200)
                        //{
                        //    g.DrawImage(_Image, _Radius - 42, _Radius - 42, 84, 84);
                        //}

                        //else if (_Radius > 200 && _Radius <= 210)
                        //{
                        //    g.DrawImage(_Image, _Radius - 44, _Radius - 44, 88, 88);
                        //}

                        //else if (_Radius > 210 && _Radius <= 220)
                        //{
                        //    g.DrawImage(_Image, _Radius - 46, _Radius - 46, 92, 92);
                        //}

                        //else if (_Radius > 220 && _Radius <= 230)
                        //{
                        //    g.DrawImage(_Image, _Radius - 48, _Radius - 48, 96, 96);
                        //}

                        //else if (_Radius > 230 && _Radius <= 240)
                        //{
                        //    g.DrawImage(_Image, _Radius - 50, _Radius - 50, 100, 100);
                        //}

                        //else if (_Radius > 240 && _Radius <= 250)
                        //{
                        //    g.DrawImage(_Image, _Radius - 52, _Radius - 52, 104, 104);
                        //}

                        //else if (_Radius > 250 && _Radius <= 260)
                        //{
                        //    g.DrawImage(_Image, _Radius - 54, _Radius - 54, 108, 108);
                        //}

                        //else if (_Radius > 260 && _Radius <= 270)
                        //{
                        //    g.DrawImage(_Image, _Radius - 56, _Radius - 56, 112, 112);
                        //}

                        //else if (_Radius > 270 && _Radius <= 280)
                        //{
                        //    g.DrawImage(_Image, _Radius - 58, _Radius - 58, 116, 116);
                        //}

                        //else if (_Radius > 280 && _Radius <= 290)
                        //{
                        //    g.DrawImage(_Image, _Radius - 60, _Radius - 60, 120, 120);
                        //}

                        //else if (_Radius > 290 && _Radius <= 300)
                        //{
                        //    g.DrawImage(_Image, _Radius - 62, _Radius - 62, 124, 124);
                        //}

                        //else if (_Radius > 300)
                        //{
                        //    _Radius = 300;
                        //    //g.DrawImage(_Image, _Radius - 62, _Radius - 62, 124, 124);
                        //    g.DrawImage(_Image, _Radius - 72, _Radius - 72, 144, 144);
                        //}
                        #endregion

                        PointF ImgPoint1 = ImageLocation(GetStringFormat(_ImageAlign), Size, ImageSize);
                        if (_ImagePressed != null)
                        {
                            g.DrawImage(_ImagePressed, (int)ImgPoint1.X, (int)ImgPoint1.Y, ImageSize.Width, ImageSize.Height);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            FinishDrawing(e.Graphics, new Point(0, 0), _Radius);
        }

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

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonRoundDefaultDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonRoundDefaultDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonRoundDefaultSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonRoundDefaultSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitButtonRoundDefaultSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitRndButtonDefault colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonRoundDefaultSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonRoundDefaultSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitRndButtonDefault;

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
            get
            {
                return colUserControl.Image;
            }
            set
            {
                GetPropertyByName("Image").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image pressed.
        /// </summary>
        /// <value>The image pressed.</value>
        public Image ImagePressed
        {
            get
            {
                return colUserControl.ImagePressed;
            }
            set
            {
                GetPropertyByName("ImagePressed").SetValue(colUserControl, value);
            }
        }




        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get
            {
                return colUserControl.ImageAlign;
            }
            set
            {
                GetPropertyByName("ImageAlign").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));
            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));
            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Sets the Background Image."));

            items.Add(new DesignerActionPropertyItem("ImagePressed",
                                 "Image Pressed", "Appearance",
                                 "Sets the Background Image when pressed."));

            items.Add(new DesignerActionPropertyItem("ImageAlign",
                                 "Image Align", "Appearance",
                                 "Aligns the Background Image"));

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
