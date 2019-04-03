// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="DummyControl.cs" company="Zeroit Dev Technologies">
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
    /// A class collection for rendering circles and polygons
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(DummyControlDesigner))]
    [ToolboxItem(true)]
    public class ZeroitDummyControl : Control
    {

        #region Private Fields

        /// <summary>
        /// The shape populate
        /// </summary>
        private ShapePopulate shapePopulate = new ShapePopulate(Shapes.Rectangle, Color.DeepSkyBlue, Color.Yellow, true, false, true, 10, 10, 10, 10, 10);
        //private ShapePopulate shapePopulate = new ShapePopulate();


        #region ShapePopulate Values

        //private int upperLeftCurve_ShapePopulate;
        //private int upperRightCurve_ShapePopulate;
        //private int downLeftCurve_ShapePopulate;
        //private int downRightCurve_ShapePopulate;
        //private int curve_ShapePopulate;

        //private bool rounding_ShapePopulate;
        //private bool colorShape_ShapePopulate;
        //private bool drawBorder_ShapePopulate;


        //private Color bordercolor_ShapePopulate;
        //private Color shapecolor_ShapePopulate;

        //private int sides_ShapePopulate;
        //private int radius_ShapePopulate;
        //private int startingangle_ShapePopulate;
        //private int controlWidth_ShapePopulate;

        //private float startangle_ShapePopulate;
        //private float endangle_ShapePopulate;

        #endregion


        #endregion

        #region Public Properties
        /// <summary>
        /// This selects a UI Editor to edit the values of the control
        /// </summary>
        /// <value>The shape populate.</value>
        public ShapePopulate ShapePopulate
        {
            get
            {
                return shapePopulate;

            }
            set
            {
                //shapePopulate = value.Clone();

                shapePopulate = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the shape color
        /// </summary>
        /// <value>The color of the shape.</value>
        public Color ShapeColor
        {
            get { return shapePopulate.ShapeColor; }
            set
            {
                shapePopulate.ShapeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the border color
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return shapePopulate.BorderColor; }
            set
            {
                shapePopulate.BorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the start angle of the pie shape
        /// </summary>
        /// <value>The start angle.</value>
        [Category("Pie Control")]
        public float StartAngle
        {
            get
            {
                return shapePopulate.StartAngle;
            }
            set
            {
                shapePopulate.StartAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the end angle of the pie shape
        /// </summary>
        /// <value>The end angle.</value>
        [Category("Pie Control")]
        public float EndAngle
        {
            get { return shapePopulate.EndAngle; }
            set
            {
                shapePopulate.EndAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the curve for all the four corners of the rectangle
        /// </summary>
        /// <value>The curve.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Value must be more than 1</exception>
        [Category("Rounded Rectangle Control")]
        public int Curve
        {
            get { return shapePopulate.Curve; }
            set
            {
                if (value > 0)
                {
                    shapePopulate.UpperLeftCurve = value;
                    shapePopulate.UpperRightCurve = value;
                    shapePopulate.DownLeftCurve = value;
                    shapePopulate.DownRightCurve = value;
                }

                if (value < 1)
                {
                    value = 1;
                    throw new ArgumentOutOfRangeException("", "Value must be more than 1");
                }

                shapePopulate.Curve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the upper left curve of the rectangle
        /// </summary>
        /// <value>The upper left curve.</value>
        public int UpperLeftCurve
        {
            get { return shapePopulate.UpperLeftCurve; }
            set
            {
                shapePopulate.UpperLeftCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the upper right curve of the rectangle
        /// </summary>
        /// <value>The upper right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int UpperRightCurve
        {
            get { return shapePopulate.UpperRightCurve; }
            set
            {
                shapePopulate.UpperRightCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the down left curve of the rectangle
        /// </summary>
        /// <value>Down left curve.</value>
        [Category("Rounded Rectangle Control")]
        public int DownLeftCurve
        {
            get { return shapePopulate.DownLeftCurve; }
            set
            {
                shapePopulate.DownLeftCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the down right curve of the rectangle
        /// </summary>
        /// <value>Down right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int DownRightCurve
        {
            get { return shapePopulate.DownRightCurve; }
            set
            {
                shapePopulate.DownRightCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// This sets the border width
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return shapePopulate.BorderWidth; }
            set
            {
                shapePopulate.BorderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to enable inner color
        /// </summary>
        /// <value><c>true</c> if [color shape]; otherwise, <c>false</c>.</value>
        public bool ColorShape
        {
            get { return shapePopulate.ColorShape; }
            set
            {
                shapePopulate.ColorShape = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to allow the border to be colored
        /// </summary>
        /// <value><c>true</c> if [draw border]; otherwise, <c>false</c>.</value>
        public bool DrawBorder
        {
            get
            {
                return shapePopulate.DrawBorder;

            }
            set
            {
                shapePopulate.DrawBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set the type of shape
        /// </summary>
        /// <value>The shape.</value>
        public Shapes Shape
        {
            get { return shapePopulate.Shape; }
            set
            {
                shapePopulate.Shape = value;
                this.OnShapeChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        /// <summary>
        /// Set to enable the rectangle to be rounded
        /// </summary>
        /// <value><c>true</c> if rounding; otherwise, <c>false</c>.</value>
        public bool Rounding
        {
            get { return shapePopulate.Rounding; }
            set
            {
                shapePopulate.Rounding = value;
                Invalidate();
            }
        }

        #region Polygon

        //private int sides = 3;
        //private int radius = 10;
        //private int startingAngle = 90;
        /// <summary>
        /// The center
        /// </summary>
        Point center;

        /// <summary>
        /// Sets the sides of the polygonal shape
        /// </summary>
        /// <value>The polygon sides.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Minimum - Value cannot go below 3.</exception>
        public Int32 PolygonSides
        {
            get { return shapePopulate.PolygonSides; }
            set
            {
                if (value < 3)
                {
                    shapePopulate.PolygonSides = 3;
                    throw new ArgumentOutOfRangeException("Minimum", "Value cannot go below 3.");
                }
                shapePopulate.PolygonSides = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the radius of the polygonal shape
        /// </summary>
        /// <value>The polygon radius.</value>
        public Int32 PolygonRadius
        {
            get { return shapePopulate.PolygonRadius; }
            set
            {
                shapePopulate.PolygonRadius = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the starting angle of the polygonal shape
        /// </summary>
        /// <value>The polygon starting angle.</value>
        public Int32 PolygonStartingAngle
        {
            get { return shapePopulate.PolygonStartingAngle; }
            set
            {
                shapePopulate.PolygonStartingAngle = value;
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

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of the Dummy control class
        /// </summary>
        public ZeroitDummyControl()
        {


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            IncludeInConstructor();
            //DoubleBuffered = true;

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Rectangles the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        public void RectangleControl(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle((shapePopulate.BorderWidth / 2), (shapePopulate.BorderWidth / 2), Width - shapePopulate.BorderWidth - 1, Height - shapePopulate.BorderWidth - 1);


            if (shapePopulate.ColorShape)
            {
                g.FillRectangle(new SolidBrush(shapePopulate.ShapeColor), rect);

                if (shapePopulate.DrawBorder)
                {
                    g.DrawRectangle(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), rect);
                }

            }

            else
            {
                g.DrawRectangle(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), rect);
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
            Rectangle rect = new Rectangle((shapePopulate.BorderWidth / 2), (shapePopulate.BorderWidth / 2), Width - shapePopulate.BorderWidth - 1, Height - shapePopulate.BorderWidth - 1);


            GraphicsPath path = Zeroit.Framework.Button.Helper.Draw.RoundRect(rect, shapePopulate.Curve, shapePopulate.UpperLeftCurve, shapePopulate.UpperRightCurve, shapePopulate.DownLeftCurve, shapePopulate.DownRightCurve);

            if (shapePopulate.ColorShape)
            {

                g.FillPath(new SolidBrush(shapePopulate.ShapeColor), path);

                if (shapePopulate.DrawBorder)
                {
                    g.DrawPath(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), path);
                }

            }

            else
            {
                g.DrawPath(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), path);
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
            Rectangle rect = new Rectangle((shapePopulate.BorderWidth / 2), (shapePopulate.BorderWidth / 2), Width - shapePopulate.BorderWidth - 1, Height - shapePopulate.BorderWidth - 1);

            if (shapePopulate.ColorShape)
            {

                g.FillEllipse(new SolidBrush(shapePopulate.ShapeColor), rect);

                if (shapePopulate.DrawBorder)
                {
                    g.DrawEllipse(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), rect);
                }

            }

            else
            {
                g.DrawEllipse(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), rect);
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


            Point[] PolyGon1 = CalculateVertices(shapePopulate.PolygonSides, shapePopulate.PolygonRadius, shapePopulate.PolygonStartingAngle, center);
            SolidBrush FillBrush = new SolidBrush(shapePopulate.ShapeColor);


            if (shapePopulate.ColorShape)
            {

                G.FillPolygon(FillBrush, PolyGon1);

                if (shapePopulate.DrawBorder)
                {
                    G.DrawPolygon(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), PolyGon1);
                }

            }

            else
            {
                G.DrawPolygon(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), PolyGon1);
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
            Rectangle rect = new Rectangle((shapePopulate.BorderWidth / 2), (shapePopulate.BorderWidth / 2), Width - shapePopulate.BorderWidth - 1, Height - shapePopulate.BorderWidth - 1);

            if (shapePopulate.ColorShape)
            {

                g.FillPie(new SolidBrush(shapePopulate.ShapeColor), rect, shapePopulate.StartAngle, shapePopulate.EndAngle);

                if (shapePopulate.DrawBorder)
                {
                    g.DrawPie(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), rect, shapePopulate.StartAngle, shapePopulate.EndAngle);
                }

            }

            else
            {
                g.DrawPie(new Pen(shapePopulate.BorderColor, shapePopulate.BorderWidth), rect, shapePopulate.StartAngle, shapePopulate.EndAngle);
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

        /// <summary>
        /// Set to enable or disable Text
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get { return shapePopulate.ShowText; }
            set
            {
                shapePopulate.ShowText = value;
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
                if(ShowText)
                G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           
                {                                                                               
                    Alignment = TextAlign,                                                 
                    LineAlignment = StringAlignment.Center  
                    
                });                                                                             
            }                                                                                      
            else                                                                                        
            {                                                                                      
                G.DrawImage(Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);

                if (ShowText)
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    {
                        Alignment = TextAlign,
                        LineAlignment = StringAlignment.Center
                    });
            }                                                                                      

        }

        #endregion

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            GraphicsPath path = new GraphicsPath();

            #region Testing

            Rectangle rect = new Rectangle((shapePopulate.BorderWidth / 2), (shapePopulate.BorderWidth / 2), Width - shapePopulate.BorderWidth - 1, Height - shapePopulate.BorderWidth - 1);

            //ShapePopulate_Value_Sets();
            #endregion

            switch (shapePopulate.Shape)
            {
                case Shapes.Rectangle:

                    if (shapePopulate.Rounding)
                    {
                        //shapePopulate.RoundedRectangleControl(e, path, rect);
                        RoundedRectangleControl(e, path, rect);

                        ////RoundedRectControl(e);
                        //shapePopulate.DrawImage(g, new Rectangle(0, 0, Width, Height),Text,Font,ForeColor,Size);
                        DrawImage(g, new Rectangle(0, 0, Width, Height));
                    }
                    else
                    {
                        //shapePopulate.RectangleControl(e, rect);
                        RectangleControl(e, rect);
                        ////RectangleControl(e);
                        //shapePopulate.DrawImage(g, new Rectangle(0, 0, Width, Height), Text, Font, ForeColor, Size);
                        DrawImage(g, new Rectangle(0, 0, Width, Height));
                    }

                    break;
                //case Shapes.RoundedRectangle:
                //    //RoundedRectControl(e);
                //    break;
                case Shapes.Circle:
                    //shapePopulate.CircleControl(e, rect);
                    CircleControl(e, rect);
                    ////CircleControl(e);
                    //shapePopulate.DrawImage(g, new Rectangle(0, 0, Width, Height), Text, Font, ForeColor, Size);
                    DrawImage(g, new Rectangle(0, 0, Width, Height));
                    break;
                case Shapes.Polygon:
                    //shapePopulate.PolygonControl(e, rect);
                    PolygonControl(e, rect);
                    ////PolygonControl(e);
                    //shapePopulate.DrawImage(g, new Rectangle(0, 0, Width, Height), Text, Font, ForeColor, Size);
                    DrawImage(g, new Rectangle(0, 0, Width, Height));
                    break;
                case Shapes.Pie:
                    //shapePopulate.PieControl(e, rect, shapePopulate.StartAngle, shapePopulate.EndAngle);
                    PieControl(e, rect, shapePopulate.StartAngle, shapePopulate.EndAngle);
                    ////PieControl(e);
                    //shapePopulate.DrawImage(g, new Rectangle(0, 0, Width, Height), Text, Font, ForeColor, Size);
                    DrawImage(g, new Rectangle(0, 0, Width, Height));
                    break;
                    //case Shapes.Custom:
                    //shapePopulate.GetShapeAlt(e,TypeOfShape,rect);

            }

            base.OnPaint(e);


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            switch (shapePopulate.Shape)
            {
                case Shapes.Polygon:
                    shapePopulate.PolygonRadius = (Width / 2);
                    break;
            }

        }


        #endregion
        
        #region Paint Events

        /// <summary>
        /// Rectangles the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="rectangle">The rectangle.</param>
        public void RectangleControl(PaintEventArgs e, Rectangle rectangle)
        {

            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            if (ColorShape)
            {
                G.FillRectangle(new SolidBrush(ShapeColor), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

                if (DrawBorder)
                {
                    G.DrawRectangle(new Pen(BorderColor, BorderWidth), rectangle.X, rectangle.Y, rectangle.Width,
                        rectangle.Height);
                }

            }

            else
            {
                G.DrawRectangle(new Pen(BorderColor, BorderWidth), rectangle.X, rectangle.Y, rectangle.Width,
                    rectangle.Height);
            }
        }

        /// <summary>
        /// Roundeds the rectangle control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="P">The p.</param>
        /// <param name="rectangle">The rectangle.</param>
        public void RoundedRectangleControl(PaintEventArgs e, GraphicsPath P, Rectangle rectangle)
        {
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            //GraphicsPath P = new GraphicsPath();

            int UpperLeftCorner = UpperLeftCurve * 2;
            int UpperRightCorner = UpperRightCurve * 2;
            int DownLeftCorner = DownLeftCurve * 2;
            int DownRightCorner = DownRightCurve * 2;


            P.AddArc(new Rectangle(rectangle.X, rectangle.Y, UpperLeftCorner, UpperLeftCorner), -180, 90);
            P.AddArc(new Rectangle(rectangle.Width - UpperRightCorner + rectangle.X, rectangle.Y, UpperRightCorner, UpperRightCorner), -90, 90);
            P.AddArc(new Rectangle(rectangle.Width - DownRightCorner + rectangle.X, rectangle.Height - DownRightCorner + rectangle.Y, DownRightCorner, DownRightCorner), 0, 90);
            P.AddArc(new Rectangle(rectangle.X, rectangle.Height - DownLeftCorner + rectangle.Y, DownLeftCorner, DownLeftCorner), 90, 90);

            P.CloseAllFigures();


            if (ColorShape)
            {
                G.FillPath(new SolidBrush(ShapeColor), P);

                if (DrawBorder)
                {
                    G.DrawPath(new Pen(BorderColor, BorderWidth), P);
                }

            }

            else
            {
                G.DrawPath(new Pen(BorderColor, BorderWidth), P);
            }
        }

        /// <summary>
        /// Circles the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="rectangle">The rectangle.</param>
        public void CircleControl(PaintEventArgs e, Rectangle rectangle)
        {
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            if (ColorShape)
            {
                G.FillEllipse(new SolidBrush(ShapeColor), rectangle);

                if (DrawBorder)
                {
                    G.DrawEllipse(new Pen(BorderColor, BorderWidth), rectangle);
                }

            }

            else
            {
                G.DrawEllipse(new Pen(BorderColor, BorderWidth), rectangle);
            }


        }

        /// <summary>
        /// Polygons the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="rectangle">The rectangle.</param>
        public void PolygonControl(PaintEventArgs e, Rectangle rectangle)
        {
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            Point center = new Point(rectangle.Width / 2, rectangle.Height / 2);

            if (ColorShape)
            {
                G.FillPolygon(new SolidBrush(ShapeColor), Zeroit.Framework.Button.Helper.Draw.CalculateVertices(PolygonSides, PolygonRadius, PolygonStartingAngle, center));

                if (DrawBorder)
                {
                    G.DrawPolygon(new Pen(BorderColor, BorderWidth), Zeroit.Framework.Button.Helper.Draw.CalculateVertices(PolygonSides, PolygonRadius, PolygonStartingAngle, center));
                }

            }

            else
            {
                G.DrawPolygon(new Pen(BorderColor, BorderWidth), Zeroit.Framework.Button.Helper.Draw.CalculateVertices(PolygonSides, PolygonRadius, PolygonStartingAngle, center));
            }


        }

        /// <summary>
        /// Pies the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="startAngle">The start angle.</param>
        /// <param name="endAngle">The end angle.</param>
        public void PieControl(PaintEventArgs e, Rectangle rectangle, float startAngle, float endAngle)
        {
            this.StartAngle = startAngle;
            this.EndAngle = endAngle;
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            if (ColorShape)
            {
                G.FillPie(new SolidBrush(ShapeColor), rectangle, startAngle, endAngle);

                if (DrawBorder)
                {
                    G.DrawPie(new Pen(BorderColor, BorderWidth), rectangle, startAngle, endAngle);
                }

            }

            else
            {
                G.DrawPie(new Pen(BorderColor, BorderWidth), rectangle, startAngle, endAngle);
            }


        }

        /// <summary>
        /// Gets the shape.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="control">The control.</param>
        /// <returns>Graphics.</returns>
        public Graphics GetShape(PaintEventArgs e, Control control)
        {

            //controlWidth = control.Width;
            //control.Resize += Control_Resize;
            Rectangle rectangle = new Rectangle((BorderWidth / 2), (BorderWidth / 2), control.Width - BorderWidth - 1, control.Height - BorderWidth - 1);
            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath path = new GraphicsPath();

            CircleControl(e, rectangle);

            if (Shape == Shapes.Rectangle)
            {
                if (Rounding)
                {
                    RectangleControl(e, rectangle);
                }
                else
                {
                    RoundedRectangleControl(e, path, rectangle);
                }

                return G;
            }

            //if (ShapeType == Shapes.RoundedRectangle)
            //{
            //    RoundedRectangleControl(e, path, rectangle);
            //    return G;

            //}

            if (Shape == Shapes.Circle)
            {
                CircleControl(e, rectangle);
                return G;
            }

            if (Shape == Shapes.Polygon)
            {

                PolygonControl(e, rectangle);
                return G;
            }

            if (Shape == Shapes.Pie)
            {
                PieControl(e, rectangle, StartAngle, EndAngle);
                return G;

            }

            return null;
        }

        /// <summary>
        /// Gets the shape alt.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="Shape">The shape.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>Graphics.</returns>
        public Graphics GetShapeAlt(PaintEventArgs e, Shapes Shape, Rectangle rectangle)
        {


            rectangle = new Rectangle((BorderWidth / 2), (BorderWidth / 2), rectangle.Width - BorderWidth - 1, rectangle.Height - BorderWidth - 1);
            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath path = new GraphicsPath();

            RoundedRectangleControl(e, path, rectangle);

            //if (ShapeType == Shape)
            //{

            //    RectangleControl(e, rectangle);
            //    return G;
            //}

            //if (ShapeType == Shape)
            //{
            //    RoundedRectangleControl(e, path, rectangle);
            //    return G;

            //}

            //if (ShapeType == Shape)
            //{
            //    CircleControl(e, rectangle);
            //    return G;
            //}


            //if (ShapeType == Shape)
            //{
            //    PieControl(e, rectangle, startangle, endangle);
            //    return G;

            //}

            return null;
        }

        #endregion

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

    //--------------- [Designer(typeof(DummyControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class DummyControlDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class DummyControlDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new DummyControlSmartTagActionList(this.Component));
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
    /// Class DummyControlSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class DummyControlSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitDummyControl colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="DummyControlSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public DummyControlSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitDummyControl;

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
        /// Gets or sets the shape populate.
        /// </summary>
        /// <value>The shape populate.</value>
        public ShapePopulate ShapePopulate
        {
            get
            {
                return colUserControl.ShapePopulate;
            }
            set
            {
                GetPropertyByName("ShapePopulate").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("ShapePopulate",
                                 "Shape Populate", "Appearance",
                                 "Sets the shape for the control."));

            items.Add(new DesignerActionPropertyItem("ShapeColor",
                                 "Shape Color", "Appearance",
                                 "Sets the controls color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                "Border Color", "Appearance",
                "Sets the border color."));


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
