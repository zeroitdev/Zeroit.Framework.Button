// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Shaper.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{
    /// <summary>
    /// A class for rendering circular and Polygonal
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    //[ToolboxItem(true)]
    [Designer(typeof(ShaperControlDesigner))]
    [DefaultEvent("ShapeChanged")]
    public class ZeroitShaperButton : Control
    {

        #region Private Fields

        

        //private bool ColorShape = true;
        //private bool DrawBorder = true;
        //private bool Rounding = false;

        //private int Curve = 10;
        //private int BorderWidth = 1;

        //private int UpperLeftCurve = 10;
        //private int UpperRightCurve = 10;
        //private int DownLeftCurve = 10;
        //private int DownRightCurve = 10;

        //private float StartAngle = 0f;
        //private float EndAngle = 90f;

        //private Color ShapeColor = Color.Yellow;
        //private Color BorderColor = Color.Black;

        //private Shapes Shape = Shapes.Rectangle;

        /// <summary>
        /// The hatch style
        /// </summary>
        private HatchStyle hatchStyle = HatchStyle.ForwardDiagonal;

        /// <summary>
        /// The shape input
        /// </summary>
        private ShapeInput shapeInput = new ShapeInput(Shapes.Rectangle, Color.DeepSkyBlue, Color.Yellow, 1, true, 10,
            10, 10, 10, 10, false, true);

        /// <summary>
        /// The draw mode
        /// </summary>
        Draw _drawMode = Draw.Solid;

        /// <summary>
        /// The mirror draw mode
        /// </summary>
        Helper.Bitmap.Mirror.drawMode _mirrorDrawMode = Helper.Bitmap.Mirror.drawMode.Solid;

        #endregion

        #region Public Properties


        #region Smoothing Mode

        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion
        
        #region TextRenderingHint

        #region Add it to OnPaint / Graphics Rendering component

        //e.Graphics.TextRenderingHint = textrendering;
        #endregion

        /// <summary>
        /// The textrendering
        /// </summary>
        TextRenderingHint textrendering = TextRenderingHint.AntiAlias;

        /// <summary>
        /// Gets or sets the text rendering.
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

        #region InterPolationMode

        /// <summary>
        /// The inter polation mode
        /// </summary>
        private InterpolationMode interPolationMode = InterpolationMode.HighQualityBilinear;

        /// <summary>
        /// Gets or sets the interpolation mode.
        /// </summary>
        /// <value>The interpolation mode.</value>
        public InterpolationMode InterpolationMode
        {
            get { return interPolationMode; }
            set
            {
                interPolationMode = value;
                Invalidate();
            }
        }

        #endregion

        #region PixelOffsetMode

        /// <summary>
        /// The pixel offset mode
        /// </summary>
        private PixelOffsetMode pixelOffsetMode = PixelOffsetMode.HighQuality;

        /// <summary>
        /// Gets or sets the pixel offset mode.
        /// </summary>
        /// <value>The pixel offset mode.</value>
        public PixelOffsetMode PixelOffsetMode
        {
            get { return pixelOffsetMode; }
            set
            {
                pixelOffsetMode = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the hatch style.
        /// </summary>
        /// <value>The hatch style.</value>
        public HatchStyle HatchStyle
        {
            get { return hatchStyle; }
            set
            {
                hatchStyle = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Sets the Draw mode
        /// </summary>
        public enum Draw
        {
            /// <summary>
            /// Sets the Draw mode to Solid
            /// </summary>
            Solid,

            /// <summary>
            /// Sets the Draw mode to Gradient
            /// </summary>
            Gradient,

            /// <summary>
            /// Sets the Draw mode to Hatch
            /// </summary>
            Hatch,
            /// <summary>
            /// The none
            /// </summary>
            None
        }

        /// <summary>
        /// Sets the Draw Mode
        /// </summary>
        /// <value>The draw mode.</value>
        /// <remarks>This changes the rendering style of the button</remarks>
        public Draw DrawMode
        {
            get { return _drawMode; }
            set
            {
                if (value == Draw.Solid)
                {
                    _mirrorDrawMode = Helper.Bitmap.Mirror.drawMode.Solid;
                }
                else if (value == Draw.Gradient)
                {
                    _mirrorDrawMode = Helper.Bitmap.Mirror.drawMode.Gradient;
                }
                else if (value == Draw.Hatch)
                {
                    _mirrorDrawMode = Helper.Bitmap.Mirror.drawMode.Hatch;
                }
                else
                {
                    _mirrorDrawMode = Helper.Bitmap.Mirror.drawMode.None;
                }

                _drawMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// A UI editor for manipulating the button for all purposes
        /// </summary>
        /// <value>The shape input.</value>
        public ShapeInput ShapeInput
        {
            get { return shapeInput; }
            set
            {
                shapeInput = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the inner Color of the button
        /// </summary>
        /// <value>The color of the shape.</value>
        public Color ShapeColor
        {
            get { return shapeInput.ShapeColor; }
            set
            {
                shapeInput.ShapeColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Border Color
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return shapeInput.BorderColor; }
            set
            {
                shapeInput.BorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Start angle
        /// </summary>
        /// <value>The start angle.</value>
        [Category("Pie Control")]
        public float StartAngle
        {
            get { return shapeInput.StartAngle; }
            set
            {
                shapeInput.StartAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the End angle
        /// </summary>
        /// <value>The end angle.</value>
        [Category("Pie Control")]
        public float EndAngle
        {
            get { return shapeInput.EndAngle; }
            set
            {
                shapeInput.EndAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Curvature of the rounded rectangle shape type
        /// </summary>
        /// <value>The curve.</value>
        /// <remarks>This is applicable to rounded rectangular shape type</remarks>
        [Category("Rounded Rectangle Control")]
        public int Curve
        {
            get { return shapeInput.Curve; }
            set
            {
                if (value > 0)
                {
                    UpperLeftCurve = value;
                    UpperRightCurve = value;
                    DownLeftCurve = value;
                    DownRightCurve = value;
                }

                if (value < 1)
                {
                    value = 1;
                    
                }

                shapeInput.Curve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Upper Left curve of rounded rectangle shape
        /// </summary>
        /// <value>The upper left curve.</value>
        [Category("Rounded Rectangle Control")]
        public int UpperLeftCurve
        {
            get { return shapeInput.UpperLeftCurve; }
            set
            {
                shapeInput.UpperLeftCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Upper Right curve of rounded rectangle shape
        /// </summary>
        /// <value>The upper right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int UpperRightCurve
        {
            get { return shapeInput.UpperRightCurve; }
            set
            {
                shapeInput.UpperRightCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Down Left curve of rounded rectangle shape
        /// </summary>
        /// <value>Down left curve.</value>
        [Category("Rounded Rectangle Control")]
        public int DownLeftCurve
        {
            get { return shapeInput.DownLeftCurve; }
            set
            {
                shapeInput.DownLeftCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Down Right curve of rounded rectangle shape
        /// </summary>
        /// <value>Down right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int DownRightCurve
        {
            get { return shapeInput.DownRightCurve; }
            set
            {
                shapeInput.DownRightCurve = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Border width
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return shapeInput.BorderWidth; }
            set
            {
                shapeInput.BorderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to enable the inner color of the button control to be rendered
        /// </summary>
        /// <value><c>true</c> if [color shape]; otherwise, <c>false</c>.</value>
        public bool ColorShape
        {
            get { return shapeInput.ColorShape; }
            set
            {
                shapeInput.ColorShape = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to enable the Border of the button to rendered
        /// </summary>
        /// <value><c>true</c> if [draw border]; otherwise, <c>false</c>.</value>
        public bool DrawBorder
        {
            get
            {
                return shapeInput.DrawBorder;

            }
            set
            {
                shapeInput.DrawBorder = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the typ of Shape
        /// </summary>
        /// <value>The shape.</value>
        public Shapes Shape
        {
            get { return shapeInput.Shape; }
            set
            {
                shapeInput.Shape = value;
                this.OnShapeChanged(EventArgs.Empty);
                Invalidate();
            }
        }

        /// <summary>
        /// Set to enable the rectangle to have rounding
        /// </summary>
        /// <value><c>true</c> if rounding; otherwise, <c>false</c>.</value>
        public bool Rounding
        {
            get { return shapeInput.Rounding; }
            set
            {
                shapeInput.Rounding = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to display Text of the button
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
        private ContentAlignment _TextAlignment = ContentAlignment.MiddleCenter;
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
        public ContentAlignment TextAlign
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
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, GetStringFormat(TextAlign));
                    
                    //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                    //    {
                    //        Alignment = _TextAlignment,
                    //        LineAlignment = StringAlignment.Center
                        
                    //    });
            }
            else
            {
                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);

                if (ShowText)
                    G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, GetStringFormat(TextAlign));
            }

        }


        #endregion
        
        #endregion

        #region Polygon

        //private int PolygonSides = 3;
        //private int PolygonRadius = 10;
        //private int PolygonStartingAngle = 90;
        /// <summary>
        /// The center
        /// </summary>
        Point center;

        /// <summary>
        /// Sets the Sides of the Polygon
        /// </summary>
        /// <value>The polygon sides.</value>
        public Int32 PolygonSides
        {
            get { return shapeInput.PolygonSides; }
            set
            {
                if (value < 3)
                {
                    shapeInput.PolygonSides = 3;
                    //throw new ArgumentOutOfRangeException("Minimum", "Value cannot go below 3.");
                }
                shapeInput.PolygonSides = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Radius of the Polygon
        /// </summary>
        /// <value>The polygon radius.</value>
        public Int32 PolygonRadius
        {
            get { return shapeInput.PolygonRadius; }
            set
            {
                shapeInput.PolygonRadius = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Polygon to a particular Starting point
        /// </summary>
        /// <value>The polygon starting angle.</value>
        public Int32 PolygonStartingAngle
        {
            get { return shapeInput.PolygonStartingAngle; }
            set
            {
                shapeInput.PolygonStartingAngle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="PolygonSides">The polygon sides.</param>
        /// <param name="PolygonRadius">The polygon radius.</param>
        /// <param name="PolygonStartingAngle">The polygon starting angle.</param>
        /// <param name="center">The center.</param>
        /// <returns>Array of 10 PointF structures</returns>
        /// <exception cref="System.ArgumentException">Polygon must have 3 PolygonSides or more.</exception>
        private Point[] CalculateVertices(int PolygonSides, int PolygonRadius, int PolygonStartingAngle, Point center)
        {
            if (PolygonSides < 3)
                throw new ArgumentException("Polygon must have 3 PolygonSides or more.");

            List<Point> points = new List<Point>();
            float step = 360.0f / PolygonSides;

            float angle = PolygonStartingAngle; //starting angle
            for (double i = PolygonStartingAngle; i < PolygonStartingAngle + 360.0; i += step) //go in a circle
            {
                points.Add(DegreesToXY(angle, PolygonRadius, center));
                angle += step;
            }

            return points.ToArray();
        }

        /// <summary>
        /// Degreeses to xy.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        /// <param name="PolygonRadius">The polygon radius.</param>
        /// <param name="origin">The origin.</param>
        /// <returns>Point.</returns>
        private Point DegreesToXY(float degrees, float PolygonRadius, Point origin)
        {
            Point xy = new Point();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (int)(Math.Cos(radians) * PolygonRadius + origin.X);
            xy.Y = (int)(Math.Sin(-radians) * PolygonRadius + origin.Y);

            return xy;
        }

        #endregion

        #region Mirror
        /// <summary>
        /// The bitmap
        /// </summary>
        private Bitmap bitmap;
        /// <summary>
        /// The rotate flip
        /// </summary>
        private RotateFlipType rotateFlip = RotateFlipType.Rotate180FlipX;
        /// <summary>
        /// The length
        /// </summary>
        private int length = 100;
        /// <summary>
        /// The linear gradient mode
        /// </summary>
        private LinearGradientMode linearGradientMode = LinearGradientMode.Vertical;
        /// <summary>
        /// The mirror
        /// </summary>
        private bool mirror = true;
        /// <summary>
        /// The rect
        /// </summary>
        Rectangle rect;

        /// <summary>
        /// Sets the Rotation type
        /// </summary>
        /// <value>The rotate flip.</value>
        public RotateFlipType RotateFlip
        {
            get { return rotateFlip; }
            set
            {
                rotateFlip = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Length of the mirror
        /// </summary>
        /// <value>The length.</value>
        public int Length
        {
            get { return length; }
            set { length = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the Linear gradient mode
        /// </summary>
        /// <value>The gradient mode.</value>
        public LinearGradientMode GradientMode
        {
            get { return linearGradientMode; }
            set { linearGradientMode = value; Invalidate(); }
        }

        /// <summary>
        /// Set to enable and disable mirror property
        /// </summary>
        /// <value><c>true</c> if mirror; otherwise, <c>false</c>.</value>
        public bool Mirror
        {
            get { return mirror; }
            set { mirror = value; Invalidate(); }
        }

        #endregion
        
        #region HatchBrush

        /// <summary>
        /// The gradient1
        /// </summary>
        private Color gradient1 = Color.Black;
        /// <summary>
        /// The gradient2
        /// </summary>
        private Color gradient2 = Color.Transparent;

        /// <summary>
        /// The hatch brush type
        /// </summary>
        private HatchBrushType hatchBrushType = HatchBrushType.ForwardDiagonal;

        /// <summary>
        /// This sets the Hatch brush type when drawing mode is Hatch
        /// </summary>
        public enum HatchBrushType
        {
            /// <summary>
            /// Sets the Hatch brush to BackwardDiagonal
            /// </summary>
            BackwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to Cross
            /// </summary>
            Cross,

            /// <summary>
            /// Sets the Hatch brush to DarkDownwardDiagonal
            /// </summary>
            DarkDownwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to DarkHorizontal
            /// </summary>
            DarkHorizontal,

            /// <summary>
            /// Sets the Hatch brush to DarkUpwardDiagonal
            /// </summary>
            DarkUpwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to DarkVertical
            /// </summary>
            DarkVertical,

            /// <summary>
            /// Sets the Hatch brush to DashedDownwardDiagonal
            /// </summary>
            DashedDownwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to DashedHorizontal
            /// </summary>
            DashedHorizontal,

            /// <summary>
            /// Sets the Hatch brush to DashedUpwardDiagonal
            /// </summary>
            DashedUpwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to DashedVertical
            /// </summary>
            DashedVertical,

            /// <summary>
            /// Sets the Hatch brush to DiagonalBrick
            /// </summary>
            DiagonalBrick,

            /// <summary>
            /// Sets the Hatch brush to DiagonalCross
            /// </summary>
            DiagonalCross,

            /// <summary>
            /// Sets the Hatch brush to Divot
            /// </summary>
            Divot,

            /// <summary>
            /// Sets the Hatch brush to DottedDiamond
            /// </summary>
            DottedDiamond,

            /// <summary>
            /// Sets the Hatch brush to DottedGrid
            /// </summary>
            DottedGrid,

            /// <summary>
            /// Sets the Hatch brush to ForwardDiagonal
            /// </summary>
            ForwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to Horizontal
            /// </summary>
            Horizontal,

            /// <summary>
            /// Sets the Hatch brush to HorizontalBrick
            /// </summary>
            HorizontalBrick,

            /// <summary>
            /// Sets the Hatch brush to LargeCheckerBoard
            /// </summary>
            LargeCheckerBoard,

            /// <summary>
            /// Sets the Hatch brush to LargeConfetti
            /// </summary>
            LargeConfetti,

            /// <summary>
            /// Sets the Hatch brush to LargeGrid
            /// </summary>
            LargeGrid,

            /// <summary>
            /// Sets the Hatch brush to LightDownwardDiagonal
            /// </summary>
            LightDownwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to LightHorizontal
            /// </summary>
            LightHorizontal,

            /// <summary>
            /// Sets the Hatch brush to LightUpwardDiagonal
            /// </summary>
            LightUpwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to LightVertical
            /// </summary>
            LightVertical,

            /// <summary>
            /// Sets the Hatch brush to Max
            /// </summary>
            Max,

            /// <summary>
            /// Sets the Hatch brush to Min
            /// </summary>
            Min,

            /// <summary>
            /// Sets the Hatch brush to NarrowHorizontal
            /// </summary>
            NarrowHorizontal,

            /// <summary>
            /// Sets the Hatch brush to NarrowVertical
            /// </summary>
            NarrowVertical,

            /// <summary>
            /// Sets the Hatch brush to OutlinedDiamond
            /// </summary>
            OutlinedDiamond,

            /// <summary>
            /// Sets the Hatch brush to Percent05
            /// </summary>
            Percent05,

            /// <summary>
            /// Sets the Hatch brush to Percent10
            /// </summary>
            Percent10,

            /// <summary>
            /// Sets the Hatch brush to Percent20
            /// </summary>
            Percent20,

            /// <summary>
            /// Sets the Hatch brush to Percent25
            /// </summary>
            Percent25,

            /// <summary>
            /// Sets the Hatch brush to Percent30
            /// </summary>
            Percent30,

            /// <summary>
            /// Sets the Hatch brush to Percent40
            /// </summary>
            Percent40,

            /// <summary>
            /// Sets the Hatch brush to Percent50
            /// </summary>
            Percent50,

            /// <summary>
            /// Sets the Hatch brush to Percent60
            /// </summary>
            Percent60,

            /// <summary>
            /// Sets the Hatch brush to Percent70
            /// </summary>
            Percent70,

            /// <summary>
            /// Sets the Hatch brush to Percent75
            /// </summary>
            Percent75,

            /// <summary>
            /// Sets the Hatch brush to Percent80
            /// </summary>
            Percent80,

            /// <summary>
            /// Sets the Hatch brush to Percent90
            /// </summary>
            Percent90,

            /// <summary>
            /// Sets the Hatch brush to Plaid
            /// </summary>
            Plaid,

            /// <summary>
            /// Sets the Hatch brush to Shingle
            /// </summary>
            Shingle,

            /// <summary>
            /// Sets the Hatch brush to SmallCheckerBoard
            /// </summary>
            SmallCheckerBoard,

            /// <summary>
            /// Sets the Hatch brush to SmallConfetti
            /// </summary>
            SmallConfetti,

            /// <summary>
            /// Sets the Hatch brush to SmallGrid
            /// </summary>
            SmallGrid,

            /// <summary>
            /// Sets the Hatch brush to SolidDiamond
            /// </summary>
            SolidDiamond,

            /// <summary>
            /// Sets the Hatch brush to Sphere
            /// </summary>
            Sphere,

            /// <summary>
            /// Sets the Hatch brush to Trellis
            /// </summary>
            Trellis,

            /// <summary>
            /// Sets the Hatch brush to Vertical
            /// </summary>
            Vertical,

            /// <summary>
            /// Sets the Hatch brush to Wave
            /// </summary>
            Wave,

            /// <summary>
            /// Sets the Hatch brush to Weave
            /// </summary>
            Weave,

            /// <summary>
            /// Sets the Hatch brush to WideDownwardDiagonal
            /// </summary>
            WideDownwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to WideUpwardDiagonal
            /// </summary>
            WideUpwardDiagonal,

            /// <summary>
            /// Sets the Hatch brush to ZigZag
            /// </summary>
            ZigZag
        }

        #endregion

        #region HatchBrush Property

        /// <summary>
        /// Sets the Gradient Color
        /// </summary>
        /// <value>The gradient color1.</value>
        /// <remarks>This sets the Linear gradient color 1 for the shape</remarks>
        public Color GradientColor1
        {
            get { return gradient1; }
            set
            {
                gradient1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Gradient Color
        /// </summary>
        /// <value>The gradient color2.</value>
        /// <remarks>This sets the Linear gradient color 2 for the shape</remarks>
        public Color GradientColor2
        {
            get { return gradient2; }
            set
            {
                gradient2 = value;
                Invalidate();
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Sets the Hatch brush type
        /// </summary>
        public ZeroitShaperButton()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            IncludeInConstructor();
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
        /// Rectangles the control.
        /// </summary>
        /// <param name="g">The g.</param>
        public void RectangleControl(Graphics g)
        {
            //Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.HighQuality;


            
            if (Mirror)
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height / 2 - BorderWidth - 1);

            }
            else
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height - BorderWidth - 1);

            }

            switch (_drawMode)
            {
                case Draw.Solid:
                    
                    g.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
                    
                    break;
                case Draw.Gradient:
                    
                    LinearGradientBrush linGrad = new LinearGradientBrush(ClientRectangle, GradientColor1, GradientColor2, 90f);
                    g.FillRectangle(linGrad, ClientRectangle);

                    break;
                case Draw.Hatch:
                    HatchBrush hatchbrush = new HatchBrush(HatchStyle, gradient1, gradient2);
                    g.FillRectangle(hatchbrush, ClientRectangle);
                    
                    break;
                case Draw.None:
                    break;
                default:
                    break;
            }


            if (ColorShape)
            {
                g.FillRectangle(new SolidBrush(ShapeColor), rect);

                if (DrawBorder)
                {
                    g.DrawRectangle(new Pen(BorderColor, BorderWidth), rect);
                }

            }

            else
            {
                g.DrawRectangle(new Pen(BorderColor, BorderWidth), rect);
            }

            
        }

        /// <summary>
        /// Roundeds the rect control.
        /// </summary>
        /// <param name="g">The g.</param>
        public void RoundedRectControl(Graphics g)
        {
            //Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.HighQuality;


            if (Mirror)
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height / 2 - BorderWidth - 1);

            }
            else
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height - BorderWidth - 1);

            }

            switch (_drawMode)
            {
                case Draw.Solid:
                    g.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

                    break;
                case Draw.Gradient:
                    LinearGradientBrush linGrad = new LinearGradientBrush(ClientRectangle, GradientColor1, GradientColor2, 90f);
                    g.FillRectangle(linGrad, ClientRectangle);

                    break;
                case Draw.Hatch:
                    HatchBrush hatchbrush = new HatchBrush(HatchStyle, gradient1, gradient2);
                    g.FillRectangle(hatchbrush, ClientRectangle);

                    
                    break;
                case Draw.None:
                    break;
                default:
                    break;
            }


            GraphicsPath path = Zeroit.Framework.Button.Helper.Draw.RoundRect(rect,Curve, UpperLeftCurve,UpperRightCurve, DownLeftCurve, DownRightCurve);

            if (ColorShape)
            {
                
                g.FillPath(new SolidBrush(ShapeColor), path);

                if(DrawBorder)
                {
                    g.DrawPath(new Pen(BorderColor, BorderWidth), path);
                }

            }

            else
            {
                g.DrawPath(new Pen(BorderColor,BorderWidth), path);
            }


        }

        /// <summary>
        /// Circles the control.
        /// </summary>
        /// <param name="g">The g.</param>
        public void CircleControl(Graphics g)
        {
            //Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.HighQuality;

            if (Mirror)
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height / 2 - BorderWidth - 1);

            }
            else
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height - BorderWidth - 1);

            }

            switch (_drawMode)
            {
                case Draw.Solid:
                    g.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

                    break;
                case Draw.Gradient:
                    LinearGradientBrush linGrad = new LinearGradientBrush(ClientRectangle, GradientColor1, GradientColor2, 90f);
                    g.FillRectangle(linGrad, ClientRectangle);

                    break;
                case Draw.Hatch:
                    
                    break;
                case Draw.None:
                    break;
                default:
                    break;
            }


            if (ColorShape)
            {

                g.FillEllipse(new SolidBrush(ShapeColor), rect);

                if(DrawBorder)
                {
                    g.DrawEllipse(new Pen(BorderColor, BorderWidth), rect);
                }

            }

            else
            {
                g.DrawEllipse(new Pen(BorderColor, BorderWidth), rect);
            }


        }

        /// <summary>
        /// Polygons the control.
        /// </summary>
        /// <param name="g">The g.</param>
        public void PolygonControl(Graphics g)
        {
            //Graphics g = e.Graphics;
            //g.SmoothingMode = SmoothingMode.HighQuality;
            //Rectangle rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height - BorderWidth - 1);


            if (Mirror)
            {
                center = new Point(this.Width / 2, this.Height / 3);

            }
            else
            {
                center = new Point(this.Width / 2, this.Height / 2);

            }

            switch (_drawMode)
            {
                case Draw.Solid:
                    g.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

                    break;
                case Draw.Gradient:
                    LinearGradientBrush linGrad = new LinearGradientBrush(ClientRectangle, GradientColor1, GradientColor2, 90f);
                    g.FillRectangle(linGrad, ClientRectangle);

                    break;
                case Draw.Hatch:

                    
                    break;
                case Draw.None:
                    break;
                default:
                    break;
            }


            //Graphics G = e.Graphics;
            //G.SmoothingMode = SmoothingMode.HighQuality;
            // init 4 stars


            Point[] PolyGon1 = CalculateVertices(PolygonSides, PolygonRadius, PolygonStartingAngle, center);
            SolidBrush FillBrush = new SolidBrush(ShapeColor);

            
            if (ColorShape)
            {

                g.FillPolygon(FillBrush, PolyGon1);

                if (DrawBorder)
                {
                    g.DrawPolygon(new Pen(BorderColor, BorderWidth), PolyGon1);
                }

            }

            else
            {
                g.DrawPolygon(new Pen(BorderColor, BorderWidth), PolyGon1);
            }
            
        }

        /// <summary>
        /// Pies the control.
        /// </summary>
        /// <param name="g">The g.</param>
        public void PieControl(Graphics g)
        {
            //Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            
            if (Mirror)
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height / 2 - BorderWidth - 1);

            }
            else
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height - BorderWidth - 1);

            }

            switch (_drawMode)
            {
                case Draw.Solid:
                    g.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

                    break;
                case Draw.Gradient:
                    LinearGradientBrush linGrad = new LinearGradientBrush(ClientRectangle, GradientColor1, GradientColor2, 90f);
                    g.FillRectangle(linGrad, ClientRectangle);

                    break;
                case Draw.Hatch:

                    
                    break;
                case Draw.None:
                    break;
                default:
                    break;
            }


            if (ColorShape)
            {

                g.FillPie(new SolidBrush(ShapeColor), rect, StartAngle, EndAngle);

                if (DrawBorder)
                {
                    g.DrawPie(new Pen(BorderColor, BorderWidth), rect, StartAngle, EndAngle);
                }

            }

            else
            {
                g.DrawPie(new Pen(BorderColor, BorderWidth), rect, StartAngle, EndAngle);
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

            
            int internalWidth = Width;
            int internalHeight = Height / 2;

            if (Mirror)
            {
                bitmap = new Bitmap(internalWidth, internalHeight);
                
            }
            else
            {
                bitmap = new Bitmap(Width, Height);
            }

            
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = Smoothing;
            g.InterpolationMode = InterpolationMode;
            g.TextRenderingHint = TextRendering;
            g.PixelOffsetMode = PixelOffsetMode;

            
            //g.Clear(Color.Transparent);

            #region Testing
            Rectangle rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height - BorderWidth - 1);

            //ShapePopulate_Value_Sets();
            #endregion

            switch (Shape)
            {
                case Shapes.Rectangle:

                    if (Rounding)
                    {
                        RoundedRectControl(g);

                        if (Mirror)
                        {
                            DrawImage(g, new Rectangle(0, 0, Width, Height / 2));
                        }
                        else
                        {
                            DrawImage(g, new Rectangle(0, 0, Width, Height));
                        }
                        
                    }
                    else
                    {
                        RectangleControl(g);

                        if (Mirror)
                        {
                            DrawImage(g, new Rectangle(0, 0, Width, Height / 2));
                        }
                        else
                        {
                            DrawImage(g, new Rectangle(0, 0, Width, Height));
                        }
                    }

                    break;
                //case Shapes.RoundedRectangle:
                //    //RoundedRectControl(e);
                //    break;
                case Shapes.Circle:
                    CircleControl(g);

                    if (Mirror)
                    {
                        DrawImage(g, new Rectangle(0, 0, Width, Height / 2));
                    }
                    else
                    {
                        DrawImage(g, new Rectangle(0, 0, Width, Height));
                    }
                    break;
                case Shapes.Polygon:
                    PolygonControl(g);

                    if (Mirror)
                    {
                        DrawImage(g, new Rectangle(0, 0, Width, Height / 2));
                    }
                    else
                    {
                        DrawImage(g, new Rectangle(0, 0, Width, Height));
                    }
                    break;
                case Shapes.Pie:
                    PieControl(g);

                    if (Mirror)
                    {
                        DrawImage(g, new Rectangle(0, 0, Width, Height / 2));
                    }
                    else
                    {
                        DrawImage(g, new Rectangle(0, 0, Width, Height));
                    }

                    break;
                //case Shapes.None:
                //    shapePopulate.GetShapeAlt(e,TypeOfShape,rect);
                    
                   
            }

            
            if (Mirror)
            {
                
                switch (DrawMode)
                {
                    case Draw.Solid:

                        e.Graphics.DrawImage(
                        Zeroit.Framework.Button.Helper.Bitmap.Mirror.DrawReflection(bitmap, BackColor, RotateFlip,
                        GradientMode,
                        Length), 0, 0);

                        break;
                    case Draw.Gradient:

                        e.Graphics.DrawImage(
                        Zeroit.Framework.Button.Helper.Bitmap.Mirror.DrawReflection(bitmap, gradient2, gradient1, _mirrorDrawMode, RotateFlip,
                        GradientMode,
                        Length), 0, 0);

                        break;
                    case Draw.Hatch:

                        e.Graphics.DrawImage(
                        Zeroit.Framework.Button.Helper.Bitmap.Mirror.DrawReflection(bitmap, gradient2, gradient1, _mirrorDrawMode, RotateFlip,
                        GradientMode,
                        Length), 0, 0);

                        break;
                    case Draw.None:

                        e.Graphics.DrawImage(
                            Zeroit.Framework.Button.Helper.Bitmap.Mirror.DrawReflection(bitmap, gradient2, gradient1, _mirrorDrawMode, RotateFlip,
                                GradientMode,
                                Length), 0, 0);

                        break;
                    default:
                        break;
                }
                
            }
            else
            {

                e.Graphics.DrawImage(bitmap, 0, 0);

            }

            //bitmap.Dispose();
            //k.Dispose();
            if (!DesignMode)
                GC.Collect();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            switch (Shape)
            {
                case Shapes.Polygon:
                    PolygonRadius = (Width / 2);
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


        #region Private Methods

        /// <summary>
        /// Draw Reflection
        /// </summary>
        /// <param name="img">Set Image</param>
        /// <param name="toBG">Set Color of Background</param>
        /// <param name="toBG1">Set Color of Background</param>
        /// <param name="UpperLeft">The upper left.</param>
        /// <param name="UpperRight">The upper right.</param>
        /// <param name="DownLeft">Down left.</param>
        /// <param name="DownRight">Down right.</param>
        /// <param name="drawMode">Set the Draw Mode. Default value is Solid</param>
        /// <param name="RotateFlipType">Set Rotation. Default value is Rotate180FlipX</param>
        /// <param name="LinearGradientMode">Set Gradient Mode. Default value is Vertical</param>
        /// <param name="Length">Set the length. Default value is 100</param>
        /// <returns>Image.</returns>
        public static Image DrawReflection(Image img, Color toBG,
            Color toBG1, int UpperLeft, int UpperRight, int DownLeft, int DownRight, Draw drawMode = Draw.Solid,
            RotateFlipType RotateFlipType = RotateFlipType.Rotate180FlipX,
            LinearGradientMode LinearGradientMode = LinearGradientMode.Vertical,
            int Length = 100) // img is the original image.
        {
            //This is the static function that generates the reflection...
            int height = img.Height + Length; //Added height from the original height of the image.
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img.Width, height, PixelFormat.Format64bppPArgb); //A new bitmap.


            Brush brsh = null;//The Brush that generates the fading effect to a specific color of your background.

            switch (drawMode)
            {
                case Draw.Solid:
                    brsh = new LinearGradientBrush(new Rectangle(0, 0, img.Width + 10, height), Color.Transparent, toBG, LinearGradientMode);//The Brush that generates the fading effect to a specific color of your background.
                    break;
                case Draw.Gradient:
                    brsh = new LinearGradientBrush(new Rectangle(0, 0, img.Width + 10, height), Color.Transparent, toBG, LinearGradientMode);//The Brush that generates the fading effect to a specific color of your background.
                    break;
                case Draw.Hatch:
                    brsh = new LinearGradientBrush(new Rectangle(0, 0, img.Width + 10, height), toBG1, toBG, LinearGradientMode);//The Brush that generates the fading effect to a specific color of your background.
                    break;
                default:
                    break;
            }

            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution); //Sets the new bitmap's resolution.
            using (System.Drawing.Graphics grfx = System.Drawing.Graphics.FromImage(bmp)) //A graphics to be generated from an image (here, the new Bitmap we've created (bmp)).
            {
                System.Drawing.Bitmap bm = (System.Drawing.Bitmap)img; //Generates a bitmap from the original image (img).
                grfx.DrawImage(bm, 0, 0, img.Width, img.Height); //Draws the generated bitmap (bm) to the new bitmap (bmp).
                System.Drawing.Bitmap bm1 = (System.Drawing.Bitmap)img; //Generates a bitmap again from the original image (img).
                bm1.RotateFlip(RotateFlipType); //Flips and rotates the image (bm1).
                grfx.DrawImage(bm1, 0, img.Height); //Draws (bm1) below (bm) so it serves as the reflection image.
                Rectangle rt = new Rectangle(0, img.Height, img.Width, Length); //A new rectangle to paint our gradient effect.
                //grfx.FillRectangle(brsh, rt); //Brushes the gradient on (rt).

                GraphicsPath rectangle = RoundRect(rt, UpperLeft, UpperRight, DownLeft, DownRight);

                grfx.FillPath(brsh, rectangle);
            }

            return bmp; //Returns the (bmp) with the generated image.
        }

        /// <summary>
        /// Rounded Rectangle
        /// </summary>
        /// <param name="Rectangle">Set Rectangle</param>
        /// <param name="UpperLeftCurve">Set Upper Left Curve</param>
        /// <param name="UpperRightCurve">Set Upper Right Curve</param>
        /// <param name="DownLeftCurve">Set Down Left Curve</param>
        /// <param name="DownRightCurve">Set Down Right Curve</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath RoundRect(Rectangle Rectangle, int UpperLeftCurve, int UpperRightCurve, int DownLeftCurve, int DownRightCurve)
        {
            GraphicsPath P = new GraphicsPath();
            int UpperLeftCorner = UpperLeftCurve * 2;
            int UpperRightCorner = UpperRightCurve * 2;
            int DownLeftCorner = DownLeftCurve * 2;
            int DownRightCorner = DownRightCurve * 2;

            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Y, UpperLeftCorner, UpperLeftCorner), -180, 90);
            P.AddArc(new Rectangle(Rectangle.Width - UpperRightCorner + Rectangle.X, Rectangle.Y, UpperRightCorner, UpperRightCorner), -90, 90);
            P.AddArc(new Rectangle(Rectangle.Width - DownRightCorner + Rectangle.X, Rectangle.Height - DownRightCorner + Rectangle.Y, DownRightCorner, DownRightCorner), 0, 90);
            P.AddArc(new Rectangle(Rectangle.X, Rectangle.Height - DownLeftCorner + Rectangle.Y, DownLeftCorner, DownLeftCorner), 90, 90);
            P.CloseAllFigures();
            return P;
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

    

}
