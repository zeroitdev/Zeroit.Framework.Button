// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ShapeControl.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{
    /// <summary>
    /// A class collection for rendering Shapes.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    /// <remarks>This class contains values for making Shapes like circles and polygons.</remarks>
    [ToolboxItem(false)]
    [Designer(typeof(ShapeControlControlDesigner))]
    [DefaultEvent("ShapeChanged")]
    public class ShapeControl : Control
    {

        #region Private Fields
        /// <summary>
        /// The color shape
        /// </summary>
        private bool colorShape = true;
        /// <summary>
        /// The draw border
        /// </summary>
        private bool drawBorder = true;
        /// <summary>
        /// The rounding
        /// </summary>
        private bool rounding = false;

        /// <summary>
        /// The curve
        /// </summary>
        private int curve = 10;
        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;

        /// <summary>
        /// The upper left curve
        /// </summary>
        private int upperLeftCurve = 10;
        /// <summary>
        /// The upper right curve
        /// </summary>
        private int upperRightCurve = 10;
        /// <summary>
        /// Down left curve
        /// </summary>
        private int downLeftCurve = 10;
        /// <summary>
        /// Down right curve
        /// </summary>
        private int downRightCurve = 10;

        /// <summary>
        /// The start angle
        /// </summary>
        private float startAngle = 0f;
        /// <summary>
        /// The end angle
        /// </summary>
        private float endAngle = 90f;

        /// <summary>
        /// The shape color
        /// </summary>
        private Color shapeColor = Color.Yellow;
        /// <summary>
        /// The border color
        /// </summary>
        private Color borderColor = Color.Black;

        /// <summary>
        /// The shapes
        /// </summary>
        public Shapes _shapes = Shapes.Rectangle;


        #endregion

        #region Public Properties

        /// <summary>
        /// Gets and sets the Shape color.
        /// </summary>
        /// <value>The color of the shape.</value>
        public Color ShapeColor
        {
            get { return shapeColor; }
            set
            {
                shapeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the Border color.
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
        /// Gets and sets the Border color for the Pie shape type.
        /// </summary>
        /// <value>The start angle.</value>
        [Category("Pie Control")]
        public float StartAngle
        {
            get { return startAngle; }
            set
            {
                startAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the End Angle for the Pie shape type.
        /// </summary>
        /// <value>The end angle.</value>
        [Category("Pie Control")]
        public float EndAngle
        {
            get { return endAngle; }
            set
            {
                endAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the curve for all the four corners the rounded rectangle type.
        /// </summary>
        /// <value>The curve.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Value must be more than 1</exception>
        /// <remarks>When this value is set, all the four corners of the rectangle will have a rounded corner of the same value.</remarks>
        [Category("Rounded Rectangle Control")]
        public int Curve
        {
            get { return curve; }
            set
            {
                if (value > 0)
                {
                    upperLeftCurve = value;
                    upperRightCurve = value;
                    downLeftCurve = value;
                    downRightCurve = value;
                }

                if (value < 1)
                {
                    value = 1;
                    throw new ArgumentOutOfRangeException("", "Value must be more than 1");
                }

                curve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the upper left curve of the rounded rectangle shape.
        /// </summary>
        /// <value>The upper left curve.</value>
        [Category("Rounded Rectangle Control")]
        public int UpperLeftCurve
        {
            get { return upperLeftCurve; }
            set
            {
                upperLeftCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the upper right curve of the rounded rectangle shape.
        /// </summary>
        /// <value>The upper right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int UpperRightCurve
        {
            get { return upperRightCurve; }
            set
            {
                upperRightCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the down left curve of the rounded rectangle shape.
        /// </summary>
        /// <value>Down left curve.</value>
        [Category("Rounded Rectangle Control")]
        public int DownLeftCurve
        {
            get { return downLeftCurve; }
            set
            {
                downLeftCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the down right curve of the rounded rectangle shape.
        /// </summary>
        /// <value>Down right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int DownRightCurve
        {
            get { return downRightCurve; }
            set
            {
                downRightCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets and sets the border width of any shape.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to enable any shape to be colored.
        /// </summary>
        /// <value><c>true</c> if [color shape]; otherwise, <c>false</c>.</value>
        public bool ColorShape
        {
            get { return colorShape; }
            set
            {
                colorShape = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to enable any shape to have its border colored.
        /// </summary>
        /// <value><c>true</c> if [draw border]; otherwise, <c>false</c>.</value>
        public bool DrawBorder
        {
            get
            {
                return drawBorder;

            }
            set
            {
                drawBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to render the type of shape to be drawn.
        /// </summary>
        /// <value>The shape.</value>
        public Shapes Shape
        {
            get { return _shapes; }
            set
            {
                _shapes = value;
                this.OnShapeChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        /// <summary>
        /// Set to enable the rectangle shape to be rounded.
        /// </summary>
        /// <value><c>true</c> if rounding; otherwise, <c>false</c>.</value>
        public bool Rounding
        {
            get { return rounding; }
            set
            {
                rounding = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Get and set the text.
        /// </summary>
        /// <value>The text.</value>
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        #endregion

        #region Image Designer

        #region Include in paint method

        ///////////////////////////////////////////////////////////////////////////////////////////////// 
        //                                                                                             //                                                                     
        //         ------------------------Add this to the Paint Method ------------------------       //
        //                                                                                             //
        // Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
        //                                                                                             //
        // PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
        //                                                                                             //
        // if ((Image == null))                                                                        //
        //     {                                                                                       //
        //         G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        // else                                                                                        //
        //      {                                                                                      //
        //         G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
        //          G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        //                                                                                             //
        /////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Fields
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// The text alignment
        /// </summary>
        private StringAlignment _TextAlignment = StringAlignment.Center;
        /// <summary>
        /// The show text
        /// </summary>
        private bool showText = true;
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
        /// Sets the Image Size
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

        /// <summary>
        /// Set to enable and disable Text
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get { return showText; }
            set
            {
                showText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Text alignment
        /// </summary>
        /// <value>The text align.</value>
        public StringAlignment TextAlign
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
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

        /// <summary>
        /// Draws the image.
        /// </summary>
        /// <param name="G">The g.</param>
        /// <param name="R1">The r1.</param>
        private void DrawImage(Graphics G, Rectangle R1)
        {
            //Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          
            G.SmoothingMode = SmoothingMode.HighQuality;

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            if ((Image == null))
            {
                if (ShowText)
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center

                    });
            }
            else
            {
                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);

                if (ShowText)
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = _TextAlignment,
                        LineAlignment = StringAlignment.Center
                    });
            }

        }


        #endregion
        #endregion

        #region Polygon

        /// <summary>
        /// The sides
        /// </summary>
        private int sides = 3;
        /// <summary>
        /// The radius
        /// </summary>
        private int radius = 10;
        /// <summary>
        /// The starting angle
        /// </summary>
        private int startingAngle = 90;
        /// <summary>
        /// The center
        /// </summary>
        Point center;

        /// <summary>
        /// This sets the sides of the polygon shape.
        /// </summary>
        /// <value>The polygon sides.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Minimum - Value cannot go below 3.</exception>
        public Int32 PolygonSides
        {
            get { return sides; }
            set
            {
                if (value < 3)
                {
                    sides = 3;
                    throw new ArgumentOutOfRangeException("Minimum", "Value cannot go below 3.");
                }
                sides = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This sets the radius of the polygon shape.
        /// </summary>
        /// <value>The polygon radius.</value>
        /// <remarks>An increase/decrease in the radius will either enlarge/reduce the size of the polygon shape control.</remarks>
        public Int32 PolygonRadius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the position where the polygon shape will be set to.
        /// </summary>
        /// <value>The polygon starting angle.</value>
        public Int32 PolygonStartingAngle
        {
            get { return startingAngle; }
            set
            {
                startingAngle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="sides">The sides.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="startingAngle">The starting angle.</param>
        /// <param name="center">The center.</param>
        /// <returns>Array of 10 PointF structures</returns>
        /// <exception cref="System.ArgumentException">Polygon must have 3 sides or more.</exception>
        private Point[] CalculateVertices(int sides, int radius, int startingAngle, Point center)
        {
            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a circle
            {
                points.Add(DegreesToXY(angle, radius, center));
                angle += step;
            }

            return points.ToArray();
        }

        /// <summary>
        /// Degreeses to xy.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="origin">The origin.</param>
        /// <returns>Point.</returns>
        private Point DegreesToXY(float degrees, float radius, Point origin)
        {
            Point xy = new Point();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (int)(Math.Cos(radians) * radius + origin.X);
            xy.Y = (int)(Math.Sin(-radians) * radius + origin.Y);

            return xy;
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
        /// Creates an instance of the Shape control
        /// </summary>
        public ShapeControl()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            IncludeInConstructor();
        }

        /// <summary>
        /// Rectangles the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void RectangleControl(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle((borderWidth / 2), (borderWidth / 2), Width - borderWidth - 1, Height - borderWidth - 1);


            if (colorShape)
            {
                g.FillRectangle(new SolidBrush(shapeColor), rect);

                if (drawBorder)
                {
                    g.DrawRectangle(new Pen(borderColor, borderWidth), rect);
                }

            }

            else
            {
                g.DrawRectangle(new Pen(borderColor, borderWidth), rect);
            }

            
        }

        /// <summary>
        /// Roundeds the rect control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void RoundedRectControl(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle((borderWidth / 2), (borderWidth / 2), Width - borderWidth - 1, Height - borderWidth - 1);
            

            GraphicsPath path = Zeroit.Framework.Button.Helper.Draw.RoundRect(rect,curve, upperLeftCurve,upperRightCurve, downLeftCurve, downRightCurve);

            if (colorShape)
            {
                
                g.FillPath(new SolidBrush(shapeColor), path);

                if(drawBorder)
                {
                    g.DrawPath(new Pen(borderColor, borderWidth), path);
                }

            }

            else
            {
                g.DrawPath(new Pen(borderColor,borderWidth), path);
            }


        }

        /// <summary>
        /// Circles the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void CircleControl(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle((borderWidth / 2), (borderWidth / 2), Width - borderWidth - 1, Height - borderWidth - 1);

            if (colorShape)
            {

                g.FillEllipse(new SolidBrush(shapeColor), rect);

                if(drawBorder)
                {
                    g.DrawEllipse(new Pen(borderColor, borderWidth), rect);
                }

            }

            else
            {
                g.DrawEllipse(new Pen(borderColor, borderWidth), rect);
            }


        }

        /// <summary>
        /// Polygons the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void PolygonControl(PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.HighQuality;
            //Rectangle rect = new Rectangle((borderWidth / 2), (borderWidth / 2), Width - borderWidth - 1, Height - borderWidth - 1);


            center = new Point(this.Width / 2, this.Height / 2);

            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            // init 4 stars


            Point[] PolyGon1 = CalculateVertices(sides, radius, startingAngle, center);
            SolidBrush FillBrush = new SolidBrush(shapeColor);

            
            if (colorShape)
            {

                G.FillPolygon(FillBrush, PolyGon1);

                if (drawBorder)
                {
                    G.DrawPolygon(new Pen(borderColor, borderWidth), PolyGon1);
                }

            }

            else
            {
                G.DrawPolygon(new Pen(borderColor, borderWidth), PolyGon1);
            }
            
        }

        /// <summary>
        /// Pies the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void PieControl(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle((borderWidth / 2), (borderWidth / 2), Width - borderWidth - 1, Height - borderWidth - 1);

            if (colorShape)
            {

                g.FillPie(new SolidBrush(shapeColor), rect, startAngle, endAngle);

                if (drawBorder)
                {
                    g.DrawPie(new Pen(borderColor, borderWidth), rect, startAngle, endAngle);
                }

            }

            else
            {
                g.DrawPie(new Pen(borderColor, borderWidth), rect, startAngle, endAngle);
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
            
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            
            #region Testing
            Rectangle rect = new Rectangle((borderWidth / 2), (borderWidth / 2), Width - borderWidth - 1, Height - borderWidth - 1);

            //ShapePopulate_Value_Sets();
            #endregion

            switch (_shapes)
            {
                case Shapes.Rectangle:

                    if (rounding)
                    {
                        RoundedRectControl(e);

                        DrawImage(g, new Rectangle(0, 0, Width, Height));
                    }
                    else
                    {
                        RectangleControl(e);

                        DrawImage(g, new Rectangle(0, 0, Width, Height));
                    }

                    break;
                //case Shapes.RoundedRectangle:
                //    //RoundedRectControl(e);
                //    break;
                case Shapes.Circle:
                    CircleControl(e);

                    DrawImage(g, new Rectangle(0, 0, Width, Height));
                    break;
                case Shapes.Polygon:
                    PolygonControl(e);

                    DrawImage(g, new Rectangle(0, 0, Width, Height));
                    break;
                case Shapes.Pie:
                    PieControl(e);

                    DrawImage(g, new Rectangle(0, 0, Width, Height));

                    break;
                //case Shapes.None:
                //    shapePopulate.GetShapeAlt(e,TypeOfShape,rect);
                    
                   
            }



        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            switch (_shapes)
            {
                case Shapes.Polygon:
                    radius = (Width / 2);
                    break;
            }
            
        }

        #region Event Creation

        /////Implement this in the Property you want to trigger the event///////////////////////////
        // 
        //  For Example this will be triggered by the Value Property
        //
        //  public int Value
        //   { 
        //      get { return _value;}
        //      set
        //         {
        //          
        //              _value = value;
        //
        //              this.OnShapeChanged(EventArgs.Empty);
        //              Invalidate();
        //          }
        //    }
        //
        ////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// The on shape changed
        /// </summary>
        private EventHandler onShapeChanged;

        /// <summary>
        /// Triggered when the Value changes
        /// </summary>

        public event EventHandler ShapeChanged
        {
            add
            {
                this.onShapeChanged = this.onShapeChanged + value;
            }
            remove
            {
                this.onShapeChanged = this.onShapeChanged - value;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ShapeChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnShapeChanged(EventArgs e)
        {
            if (this.onShapeChanged == null)
                return;
            this.onShapeChanged((object)this, e);
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
    }

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ShapeControlControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ShapeControlControlDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ShapeControlControlDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ShapeControlControlSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }

        #region Zeroit Filter (Remove Properties)
        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
        }
        #endregion

    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ShapeControlControlSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ShapeControlControlSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ShapeControl colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeControlControlSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ShapeControlControlSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ShapeControl;

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
        /// Gets or sets the color of the shape.
        /// </summary>
        /// <value>The color of the shape.</value>
        public Color ShapeColor
        {
            get
            {
                return colUserControl.ShapeColor;
            }
            set
            {
                GetPropertyByName("ShapeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return colUserControl.Text;
            }
            set
            {
                GetPropertyByName("Text").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the curve.
        /// </summary>
        /// <value>The curve.</value>
        public int Curve
        {
            get
            {
                return colUserControl.Curve;
            }
            set
            {
                GetPropertyByName("Curve").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get
            {
                return colUserControl.BorderWidth;
            }
            set
            {
                GetPropertyByName("BorderWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShapeControlControlSmartTagActionList"/> is rounding.
        /// </summary>
        /// <value><c>true</c> if rounding; otherwise, <c>false</c>.</value>
        public bool Rounding
        {
            get
            {
                return colUserControl.Rounding;
            }
            set
            {
                GetPropertyByName("Rounding").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Rounding",
                "Rounding", "Appearance",
                "Sets the Rectangle to be rounded."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Sets the image for the control."));

            items.Add(new DesignerActionPropertyItem("ShapeColor",
                                 "Shape Color", "Appearance",
                                 "Sets the controls color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                "Border Color", "Appearance",
                "Sets the border color."));
            
            items.Add(new DesignerActionPropertyItem("BorderWidth",
                "BorderWidth", "Appearance",
                "Sets the width of the border."));

            items.Add(new DesignerActionPropertyItem("Curve",
                "Curve", "Appearance",
                "Sets the curve of the rectangle control."));

            items.Add(new DesignerActionPropertyItem("Text",
                "Text", "Appearance",
                "Sets the text."));


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


}
