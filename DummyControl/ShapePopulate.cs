// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ShapePopulate.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using Zeroit.Framework.Button.Editor;

namespace Zeroit.Framework.Button
{
    /// <summary>
    /// Specifies the type of Shape to use
    /// </summary>
    public enum ShapeType
    {
        /// <summary>
        /// Specifies a pie control type.
        /// </summary>
        None,
        /// <summary>
        /// Specifies a rectangle control type
        /// </summary>
        Rectangle,

        /// <summary>
        /// Specifies a rectangle control type
        /// </summary>
        RoundedRectangle,

        /// <summary>
        /// Specifies a polygon control type
        /// </summary>
        Circle,

        /// <summary>
        /// Specifies a polygon control type
        /// </summary>
        Polygon,

        /// <summary>
        /// Specifies a pie control type.
        /// </summary>
        Pie,

    };

    /// <summary>
    /// Class representing a circular and polygonal manipulation.
    /// </summary>
    [TypeConverter(typeof(ShapeConverter))]
    [EditorAttribute(typeof(ShapePopulateEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [Serializable]
    public class ShapePopulate : ISerializable
    {

        #region Private Fields
        /// <summary>
        /// The borderwidth
        /// </summary>
        private int borderwidth = 2;
        /// <summary>
        /// The upper left curve
        /// </summary>
        private int upperLeftCurve = 40;
        /// <summary>
        /// The upper right curve
        /// </summary>
        private int upperRightCurve = 40;
        /// <summary>
        /// Down left curve
        /// </summary>
        private int downLeftCurve = 40;
        /// <summary>
        /// Down right curve
        /// </summary>
        private int downRightCurve = 40;
        /// <summary>
        /// The curve
        /// </summary>
        private int curve = 10;

        /// <summary>
        /// The rounding
        /// </summary>
        private bool rounding = false;
        /// <summary>
        /// The color shape
        /// </summary>
        private bool colorShape = false;
        /// <summary>
        /// The draw border
        /// </summary>
        private bool drawBorder = true;

        /// <summary>
        /// The pie draw
        /// </summary>
        private readonly bool pieDraw = true;
        /// <summary>
        /// The none draw
        /// </summary>
        private readonly bool noneDraw = true;


        /// <summary>
        /// The bordercolor
        /// </summary>
        private Color bordercolor = Color.DeepSkyBlue;
        /// <summary>
        /// The shapecolor
        /// </summary>
        private Color shapecolor = Color.DarkSlateBlue;

        /// <summary>
        /// The sides
        /// </summary>
        private int sides = 3;
        /// <summary>
        /// The radius
        /// </summary>
        private int radius = 10;
        /// <summary>
        /// The startingangle
        /// </summary>
        private int startingangle = 90;
        /// <summary>
        /// The control width
        /// </summary>
        private int controlWidth;

        /// <summary>
        /// The startangle
        /// </summary>
        private float startangle = 0;
        /// <summary>
        /// The endangle
        /// </summary>
        private float endangle = 90;

        /// <summary>
        /// The rectangle shape
        /// </summary>
        private readonly Shapes rectangleShape = Shapes.Rectangle;
        //private readonly Shapes roundedRectangle = Shapes.RoundedRectangle;
        /// <summary>
        /// The circle
        /// </summary>
        private readonly Shapes circle = Shapes.Circle;
        /// <summary>
        /// The polygon
        /// </summary>
        private readonly Shapes polygon = Shapes.Polygon;
        /// <summary>
        /// The pie
        /// </summary>
        private readonly Shapes pie = Shapes.Pie;
        /// <summary>
        /// The none
        /// </summary>
        private readonly Shapes none = Shapes.None;

        /// <summary>
        /// The graph
        /// </summary>
        private Graphics graph;
        /// <summary>
        /// The rectangle
        /// </summary>
        private Rectangle rectangle;

        /// <summary>
        /// The dummy draw
        /// </summary>
        private bool dummyDraw = true;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets foreground color in a solid fill.
        /// </summary>
        /// <value>Foreground color in a solid fill.</value>
        public Shapes None
        {
            get { return none; }
        }
        /// <summary>
        /// Gets foreground color in a solid fill.
        /// </summary>
        /// <value>Foreground color in a solid fill.</value>
        public Shapes Rectangle
        {
            get { return rectangleShape; }
        }

        /// <summary>
        /// Gets foreground color in a solid fill.
        /// </summary>
        /// <value>Foreground color in a solid fill.</value>
        public Shapes Circle
        {
            get { return circle; }
        }

        /// <summary>
        /// Gets foreground color in a solid fill.
        /// </summary>
        /// <value>Foreground color in a solid fill.</value>
        public Shapes Pie
        {
            get { return pie; }
        }

        /// <summary>
        /// Gets foreground color in a solid fill.
        /// </summary>
        /// <value>Foreground color in a solid fill.</value>
        public Shapes Polygon
        {
            get { return polygon; }
        }

        /// <summary>
        /// Gets foreground color in a solid fill.
        /// </summary>
        /// <value>Foreground color in a solid fill.</value>
        public Color ShapeColor
        {
            get { return shapecolor; }
            set { shapecolor = value; }
        }

        /// <summary>
        /// Gets foreground color in a hatched fill.
        /// </summary>
        /// <value>Foreground color in a hatched fill.</value>
        public Color BorderColor
        {
            get { return bordercolor; }

            set { bordercolor = value; }
        }

        /// <summary>
        /// Gets background color in a hatched fill.
        /// </summary>
        /// <value>Background color in a hatched fill.</value>
        public Color BackColor { get { return shapecolor; }
            set { shapecolor = value; }
        }

        /// <summary>
        /// Type of fill.
        /// </summary>
        public Shapes ShapeType = Shapes.Rectangle;



        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <value>The width of the control.</value>
        public int ControlWidth
        {
            get { return controlWidth; }
            set
            {
                controlWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        [Category("Pie Control")]
        public float StartAngle
        {
            get { return startangle; }
            set
            {
                startangle = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the end angle.
        /// </summary>
        /// <value>The end angle.</value>
        [Category("Pie Control")]
        public float EndAngle
        {
            get { return endangle; }
            set
            {
                endangle = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the curve.
        /// </summary>
        /// <value>The curve.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Value must be more than 1</exception>
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
                
            }
        }

        /// <summary>
        /// Gets or sets the upper left curve.
        /// </summary>
        /// <value>The upper left curve.</value>
        public int UpperLeftCurve
        {
            get { return upperLeftCurve; }
            set
            {
                upperLeftCurve = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the upper right curve.
        /// </summary>
        /// <value>The upper right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int UpperRightCurve
        {
            get { return upperRightCurve; }
            set
            {
                upperRightCurve = value;
                
            }
        }

        /// <summary>
        /// Gets or sets down left curve.
        /// </summary>
        /// <value>Down left curve.</value>
        [Category("Rounded Rectangle Control")]
        public int DownLeftCurve
        {
            get { return downLeftCurve; }
            set
            {
                downLeftCurve = value;

            }
        }

        /// <summary>
        /// Gets or sets down right curve.
        /// </summary>
        /// <value>Down right curve.</value>
        [Category("Rounded Rectangle Control")]
        public int DownRightCurve
        {
            get { return downRightCurve; }
            set
            {
                downRightCurve = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the polygon sides.
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
                
            }
        }

        /// <summary>
        /// Gets or sets the polygon radius.
        /// </summary>
        /// <value>The polygon radius.</value>
        public Int32 PolygonRadius
        {
            get { return radius; }
            set
            {
                radius = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the polygon starting angle.
        /// </summary>
        /// <value>The polygon starting angle.</value>
        public Int32 PolygonStartingAngle
        {
            get { return startingangle; }
            set
            {
                startingangle = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return borderwidth; }
            set
            {
                borderwidth = value;
                
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [color shape].
        /// </summary>
        /// <value><c>true</c> if [color shape]; otherwise, <c>false</c>.</value>
        public bool ColorShape
        {
            get { return colorShape; }
            set
            {
                colorShape = value;
                
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw border].
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
                
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShapePopulate"/> is rounding.
        /// </summary>
        /// <value><c>true</c> if rounding; otherwise, <c>false</c>.</value>
        public bool Rounding
        {
            get { return rounding; }
            set
            {
                rounding = value;
                
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public Shapes Shape
        {
            get { return ShapeType; }
            set
            {
                ShapeType = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [pie draw].
        /// </summary>
        /// <value><c>true</c> if [pie draw]; otherwise, <c>false</c>.</value>
        public bool PieDraw
        {
            get { return pieDraw; }
        }

        /// <summary>
        /// Gets a value indicating whether [none draw].
        /// </summary>
        /// <value><c>true</c> if [none draw]; otherwise, <c>false</c>.</value>
        public bool NoneDraw
        {
            get { return noneDraw; }
        }

        #endregion

        #region Constructors

        // Internal constructor 
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapePopulate"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="shapecolor">The shapecolor.</param>
        /// <param name="borderwidth">The borderwidth.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="colorShape">if set to <c>true</c> [color shape].</param>
        /// <param name="drawBorder">if set to <c>true</c> [draw border].</param>
        /// <param name="curve">The curve.</param>
        /// <param name="upperLeftCurve">The upper left curve.</param>
        /// <param name="upperRightCurve">The upper right curve.</param>
        /// <param name="downLeftCurve">Down left curve.</param>
        /// <param name="downRightCurve">Down right curve.</param>
        /// <param name="sides">The sides.</param>
        /// <param name="startingangle">The startingangle.</param>
        /// <param name="startangle">The startangle.</param>
        /// <param name="endangle">The endangle.</param>
        /// <param name="alwaysYes">if set to <c>true</c> [always yes].</param>
        /// <param name="_Image">The image.</param>
        public ShapePopulate(
            Shapes type, 
            Color borderColor, 
            Color shapecolor, 
            int borderwidth, 
            bool rounding, 
            bool colorShape, 
            bool drawBorder, 
            int curve, 
            int upperLeftCurve, 
            int upperRightCurve, 
            int downLeftCurve, 
            int downRightCurve, 
            int sides, 
            int startingangle, 
            float startangle, 
            float endangle, 
            bool alwaysYes,
            Image _Image
            )
        {
            this.ShapeType = type;
            this.bordercolor = borderColor;
            this.shapecolor = shapecolor;
            this.borderwidth = borderwidth;
            this.sides = sides;
            this.startingangle = startingangle;
            this.startangle = startangle;
            this.endangle = endangle;
            this.pieDraw = alwaysYes;
            this.rounding = rounding;
            this.colorShape = colorShape;
            this.upperLeftCurve = upperLeftCurve;
            this.upperRightCurve = upperRightCurve;
            this.downLeftCurve = downLeftCurve;
            this.downRightCurve = downRightCurve;
            this.drawBorder = drawBorder;
            this.curve = curve;
            this._Image = _Image;
        }


        /// <summary>
        /// Constructor for no fill.
        /// </summary>
        public ShapePopulate() : this(Shapes.None, Color.DeepSkyBlue, Color.Yellow, 2, true, true, true, 10, 10, 10, 10, 10, 3, 90, 0, 90, true, new Bitmap(32,32)) /* gradientColors */
        {
        }

        /// <summary>
        /// Constructor for none fill.
        /// </summary>
        /// <param name="None">The none.</param>
        /// <param name="draw">if set to <c>true</c> [draw].</param>
        public ShapePopulate(Shapes None, bool draw) : 
            this(Shapes.None, Color.DeepSkyBlue, Color.Yellow, 2, true, true,true,10, 10, 10, 10, 10, 3, 90, 0, 90, true, new Bitmap(32, 32)) /* gradientColors */
        {
            this.ShapeType = None;
            this.noneDraw = draw;
        }

        /// <summary>
        /// Constructor for Rectangle.
        /// </summary>
        /// <param name="Rectangle">The rectangle.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="shapecolor">The shapecolor.</param>
        /// <param name="rounding">if set to <c>true</c> [rounding].</param>
        /// <param name="colorShape">if set to <c>true</c> [color shape].</param>
        /// <param name="drawborder">if set to <c>true</c> [drawborder].</param>
        /// <param name="curve">The curve.</param>
        /// <param name="upperLeftCurve">The upper left curve.</param>
        /// <param name="upperRightCurve">The upper right curve.</param>
        /// <param name="downLeftCurve">Down left curve.</param>
        /// <param name="downRightCurve">Down right curve.</param>
        public ShapePopulate(Shapes Rectangle, 
            Color borderColor, Color shapecolor, 
            bool rounding, bool colorShape, bool drawborder,
            int curve, int upperLeftCurve, int upperRightCurve, int downLeftCurve, int downRightCurve) : 
            this(Shapes.Rectangle, Color.DeepSkyBlue, Color.Yellow, 2, true, false, true, 10, 10, 10, 10, 10, 3, 90, 0, 90, true, new Bitmap(32, 32))
        {
            this.ShapeType = Rectangle;
            this.bordercolor = borderColor;
            this.shapecolor = shapecolor;
            this.sides = PolygonSides;
            this.rounding = rounding;
            this.colorShape = colorShape;
            this.upperLeftCurve = upperLeftCurve;
            this.upperRightCurve = upperRightCurve;
            this.downLeftCurve = downLeftCurve;
            this.downRightCurve = downRightCurve;
            this.drawBorder = drawborder;
            this.curve = curve;

        }

        //public ShapePopulate(Shapes RoundedRectangle, int upperLeftCurve, int upperRightCurve,
        //    int downLeftCurve, int downRightCurve) : this(Shapes.RoundedRectangle, Color.DeepSkyBlue, Color.Yellow, borderwidth)
        //{

        //}

        /// <summary>
        /// Constructor for Circle.
        /// </summary>
        /// <param name="Circle">The circle.</param>
        /// <param name="borderColor">Color of the border.</param>
        /// <param name="shapecolor">The shapecolor.</param>
        /// <param name="colorShape">if set to <c>true</c> [color shape].</param>
        /// <param name="drawBorder">if set to <c>true</c> [draw border].</param>
        public ShapePopulate(Shapes Circle, Color borderColor, Color shapecolor, bool colorShape, bool drawBorder) : 
            this(Shapes.Circle, Color.DeepSkyBlue, Color.Yellow, 2, true, false, true, 10, 10, 10, 10, 10, 3, 90, 0, 90, true, new Bitmap(32, 32))
        {
            this.ShapeType = Circle;
            this.bordercolor = borderColor;
            this.shapecolor = shapecolor;
            this.colorShape = colorShape;
            this.drawBorder = drawBorder;
        }

        /// <summary>
        /// Constructor for Polygon.
        /// </summary>
        /// <param name="Polygon">The polygon.</param>
        /// <param name="sides">The sides.</param>
        /// <param name="startingangle">The startingangle.</param>
        public ShapePopulate(Shapes Polygon, int sides, int startingangle) : 
            this(Shapes.Polygon,Color.DeepSkyBlue, Color.Yellow, 2, true, false, true, 10, 10, 10, 10, 10, 3, 90, 0, 90, true, new Bitmap(32, 32))
        {
            this.ShapeType = Polygon;
            this.sides = sides;
            this.startingangle = startingangle;
        }

        /// <summary>
        /// Constructor for Pie.
        /// </summary>
        /// <param name="Pie">The pie.</param>
        /// <param name="startangle">The startangle.</param>
        /// <param name="endangle">The endangle.</param>
        /// <param name="alwaysYes">if set to <c>true</c> [always yes].</param>
        public ShapePopulate(Shapes Pie, float startangle, float endangle, bool alwaysYes) : 
            this(Shapes.Pie,Color.DeepSkyBlue, Color.Yellow, 2, true, false, true, 10, 10, 10, 10, 10, 3, 90, 0, 90, true, new Bitmap(32, 32))
        {
            this.ShapeType = Pie;
            this.startangle = startangle;
            this.endangle = endangle;
            this.dummyDraw = alwaysYes;
        }

        //public ShapePopulate(Shapes Custom, PaintEventArgs e) : this(Shapes.Custom,
        //    Color.DeepSkyBlue, Color.Yellow, 2, true, false, true, 10, 10, 10, 10, 10, 3, 90, 0, 90, true)
        //{

        //}


        #endregion

        #region Public Methods


        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>ShapePopulate.</returns>
        public ShapePopulate Clone()
        {
            return new ShapePopulate(
                ShapeType, 
                bordercolor, 
                shapecolor, 
                borderwidth,
                rounding,
                colorShape,
                drawBorder,
                curve,
                upperLeftCurve,
                upperRightCurve,
                downLeftCurve,
                downRightCurve,
                sides,
                startingangle,
                startangle,
                endangle,
                pieDraw,
                _Image);
        }


        /// <summary>
        /// Empties this instance.
        /// </summary>
        /// <returns>ShapePopulate.</returns>
        public static ShapePopulate Empty()
        {
            return new ShapePopulate();
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
        /// Gets or sets the image.
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
                //Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the size of the image.
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                //Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                //Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show text].
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get { return showText; }
            set
            {
                showText = value;
                //Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public StringAlignment TextAlign
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                //Invalidate();
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
        /// <param name="Text">The text.</param>
        /// <param name="Font">The font.</param>
        /// <param name="ForeColor">Color of the fore.</param>
        /// <param name="Size">The size.</param>
        public void DrawImage(Graphics G, Rectangle R1, string Text, Font Font, Color ForeColor, Size Size)
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
            if (colorShape)
            {
                G.FillRectangle(new SolidBrush(shapecolor), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

                if (drawBorder)
                {
                    G.DrawRectangle(new Pen(bordercolor, borderwidth), rectangle.X, rectangle.Y, rectangle.Width,
                        rectangle.Height);
                }
                
            }
            
            else
            {
                G.DrawRectangle(new Pen(bordercolor, borderwidth), rectangle.X, rectangle.Y, rectangle.Width,
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

            int UpperLeftCorner = upperLeftCurve * 2;
            int UpperRightCorner = upperRightCurve * 2;
            int DownLeftCorner = downLeftCurve * 2;
            int DownRightCorner = downRightCurve * 2;


            P.AddArc(new Rectangle(rectangle.X, rectangle.Y, UpperLeftCorner, UpperLeftCorner), -180, 90);
            P.AddArc(new Rectangle(rectangle.Width - UpperRightCorner + rectangle.X, rectangle.Y, UpperRightCorner, UpperRightCorner), -90, 90);
            P.AddArc(new Rectangle(rectangle.Width - DownRightCorner + rectangle.X, rectangle.Height - DownRightCorner + rectangle.Y, DownRightCorner, DownRightCorner), 0, 90);
            P.AddArc(new Rectangle(rectangle.X, rectangle.Height - DownLeftCorner + rectangle.Y, DownLeftCorner, DownLeftCorner), 90, 90);

            P.CloseAllFigures();
            

            if (colorShape)
            {
                G.FillPath(new SolidBrush(shapecolor), P);

                if (drawBorder)
                {
                    G.DrawPath(new Pen(bordercolor, borderwidth), P);
                }

            }

            else
            {
                G.DrawPath(new Pen(bordercolor, borderwidth), P);
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

            if (colorShape)
            {
                G.FillEllipse(new SolidBrush(shapecolor), rectangle);

                if (drawBorder)
                {
                    G.DrawEllipse(new Pen(bordercolor, borderwidth), rectangle);
                }

            }

            else
            {
                G.DrawEllipse(new Pen(bordercolor, borderwidth), rectangle);
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

            if (colorShape)
            {
                G.FillPolygon(new SolidBrush(shapecolor), Zeroit.Framework.Button.Helper.Draw.CalculateVertices(sides, radius, startingangle, center));

                if (drawBorder)
                {
                    G.DrawPolygon(new Pen(bordercolor, borderwidth), Zeroit.Framework.Button.Helper.Draw.CalculateVertices(sides, radius, startingangle, center));
                }

            }

            else
            {
                G.DrawPolygon(new Pen(bordercolor, borderwidth), Zeroit.Framework.Button.Helper.Draw.CalculateVertices(sides, radius, startingangle, center));
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
            this.startangle = startAngle;
            this.endangle = endAngle;
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;

            if (colorShape)
            {
                G.FillPie(new SolidBrush(shapecolor), rectangle, startAngle, endAngle);

                if (drawBorder)
                {
                    G.DrawPie(new Pen(bordercolor, borderwidth), rectangle, startAngle, endAngle);
                }

            }

            else
            {
                G.DrawPie(new Pen(bordercolor, borderwidth), rectangle, startAngle, endAngle);
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

            controlWidth = control.Width;
            control.Resize += Control_Resize;
            rectangle = new Rectangle((borderwidth / 2), (borderwidth / 2), control.Width - borderwidth - 1, control.Height - borderwidth - 1);
            Graphics G = e.Graphics;

            G.SmoothingMode = SmoothingMode.HighQuality;
            GraphicsPath path = new GraphicsPath();

            CircleControl(e, rectangle);

            if (ShapeType == Shapes.Rectangle)
            {
                if (rounding)
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

            if (ShapeType == Shapes.Circle)
            {
                CircleControl(e, rectangle);
                return G;
            }

            if (ShapeType == Shapes.Polygon)
            {

                PolygonControl(e, rectangle);
                return G;
            }

            if (ShapeType == Shapes.Pie)
            {
                PieControl(e, rectangle, startangle, endangle);
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
            
            rectangle = new Rectangle((borderwidth / 2), (borderwidth / 2), rectangle.Width - borderwidth - 1, rectangle.Height - borderwidth - 1);
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

        #region Mouse Events

        /// <summary>
        /// Handles the Resize event of the Control control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Control_Resize(object sender, EventArgs e)
        {
            radius = (controlWidth / 2);
        }

        #endregion

        #region Converter

        //internal class Converter : TypeConverter
        //{

        //    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        //    {
        //        if (destinationType == typeof(InstanceDescriptor) || destinationType == typeof(string))
        //        {
        //            return true;
        //        }
        //        return base.CanConvertTo(context, destinationType);
        //    }

        //    // This code allows the designer to generate the Shape constructor

        //    public override object ConvertTo(ITypeDescriptorContext context,
        //        CultureInfo culture,
        //        object value,
        //        Type destinationType)
        //    {
        //        if (value is ShapePopulate)
        //        {
        //            if (destinationType == typeof(string))
        //            {
        //                // Display string in designer
        //                return "(ShapePopulate)";
        //            }
        //            else if (destinationType == typeof(InstanceDescriptor))
        //            {
        //                ShapePopulate shapePopulate = (ShapePopulate)value;

        //                if (shapePopulate.Shape == Shapes.Rectangle)
        //                {
        //                    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[]
        //                    {
        //                        typeof(Shapes),
        //                        typeof(Color),
        //                        typeof(Color),
        //                        typeof(bool),
        //                        typeof(bool),
        //                        typeof(bool),
        //                        typeof(int),
        //                        typeof(int),
        //                        typeof(int),
        //                        typeof(int),
        //                        typeof(int)


        //                    });
        //                    if (ctor != null)
        //                    {
        //                        return new InstanceDescriptor(ctor, new object[] {
        //                            //shapePopulate.Rectangle,
        //                            shapePopulate.ShapeType,
        //                            shapePopulate.bordercolor,
        //                            shapePopulate.shapecolor,
        //                            shapePopulate.rounding,
        //                            shapePopulate.colorShape,
        //                            shapePopulate.drawBorder,
        //                            shapePopulate.curve,
        //                            shapePopulate.upperLeftCurve,
        //                            shapePopulate.upperRightCurve,
        //                            shapePopulate.downLeftCurve,
        //                            shapePopulate.downRightCurve});
        //                    }
        //                }

        //                else if (shapePopulate.Shape == Shapes.Circle)
        //                {
        //                    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[] {
        //                        typeof(Shapes),
        //                        typeof(Color),
        //                        typeof(Color),
        //                        typeof(bool),
        //                        typeof(bool),
        //                        });
        //                    if (ctor != null)
        //                    {
        //                        return new InstanceDescriptor(ctor, new object[] {
        //                            //shapePopulate.Circle,
        //                            shapePopulate.ShapeType,
        //                            shapePopulate.bordercolor,
        //                            shapePopulate.shapecolor,
        //                            shapePopulate.colorShape,
        //                            shapePopulate.drawBorder,
        //                            });
        //                    }
        //                }

        //                else if (shapePopulate.Shape == Shapes.Polygon)
        //                {
        //                    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[] {
        //                        typeof(Shapes),
        //                        typeof(int),
        //                        typeof(int) });
        //                    if (ctor != null)
        //                    {
        //                        return new InstanceDescriptor(ctor, new object[] {
        //                            //shapePopulate.Polygon,
        //                            shapePopulate.ShapeType,
        //                            shapePopulate.sides,
        //                            shapePopulate.startingangle,
        //                            });
        //                    }
        //                }

        //                else if (shapePopulate.Shape == Shapes.Pie)
        //                {
        //                    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[] {
        //                        typeof(Shapes),
        //                        typeof(float),
        //                        typeof(float),
        //                        typeof(bool)});
        //                    if (ctor != null)
        //                    {
        //                        return new InstanceDescriptor(ctor, new object[] {
        //                            //shapePopulate.Pie,
        //                            shapePopulate.ShapeType,
        //                            shapePopulate.startangle,
        //                            shapePopulate.endangle,
        //                            shapePopulate.pieDraw
        //                        });
        //                    }
        //                }

        //                else if (shapePopulate.Shape == Shapes.None)
        //                {
        //                    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[] {
        //                        typeof(Shapes),
        //                        typeof(bool),
        //                        });
        //                    if (ctor != null)
        //                    {
        //                        return new InstanceDescriptor(ctor, new object[] {
        //                            //shapePopulate.None,
        //                            shapePopulate.ShapeType,
        //                            shapePopulate.noneDraw,

        //                        });
        //                    }
        //                }


        //                else
        //                {
        //                    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(Type.EmptyTypes);
        //                    if (ctor != null)
        //                    {
        //                        return new InstanceDescriptor(ctor, null);
        //                    }
        //                }
        //            }
        //        }
        //        return base.ConvertTo(context, culture, value, destinationType);
        //    }
        //}

        #endregion

        #region Editor Brush

        /// <summary>
        /// Gets the UI type editor pen.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <returns>Pen.</returns>
        internal Pen GetUITypeEditorPen(Rectangle bounds)
        {
            return GetPen(bounds);
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Pen GetPen(Rectangle rect)
        {
            return GetPen(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Pen GetPen(RectangleF rect)
        {
            if (ShapeType == rectangleShape)
            {
                return new Pen(BorderColor);
            }
            else if (ShapeType == circle)
            {
                return new Pen(BorderColor);
            }
            else if (ShapeType == pie)
            {
                return new Pen(BorderColor);
            }
            else if (ShapeType == polygon)
            {
                return new Pen(BorderColor);
            }

            return null;
        }



        /// <summary>
        /// Gets the UI type editor brush.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        /// <returns>Brush.</returns>
        internal Brush GetUITypeEditorBrush(Rectangle bounds)
        {
            return GetBrush(bounds);
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Brush GetBrush(Rectangle rect)
        {
            return GetBrush(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height));
        }

        /// <summary>
        /// Get <c>Brush</c> for this fill.
        /// </summary>
        /// <param name="rect">Rectangle area to which fill is to be applied.</param>
        /// <returns>Brush.</returns>
        /// <remarks>The <c>rect</c> parameter only affects the brush if <c>FillerType</c> is <c>LinearGradient</c> or <c>PathGradient</c>.
        /// <para>
        /// The caller is responsible for disposing of the returned brush.
        /// </para></remarks>
        public Brush GetBrush(RectangleF rect)
        {
            if (ShapeType == rectangleShape)
            {
                return new SolidBrush(ShapeColor);
            }
            else if (ShapeType == circle)
            {
                return new SolidBrush(ShapeColor);
            }
            else if (ShapeType == pie)
            {
                return new SolidBrush(ShapeColor);
            }
            else if (ShapeType == polygon)
            {
                return new SolidBrush(ShapeColor);
            }

            return null;
        }

        #endregion

        public ShapePopulate(SerializationInfo info, StreamingContext context)
        {
            endangle = (float)info.GetValue("endangle", typeof(float));
            startangle = (float)info.GetValue("startangle", typeof(float));
            controlWidth = info.GetInt32("controlWidth");
            startingangle = info.GetInt32("startingangle");
            radius = info.GetInt32("radius");
            sides = info.GetInt32("sides");
            shapecolor = (Color)info.GetValue("shapecolor", typeof(Color));
            bordercolor = (Color)info.GetValue("bordercolor", typeof(Color));
            drawBorder = info.GetBoolean("drawBorder");
            colorShape = info.GetBoolean("colorShape");
            rounding = info.GetBoolean("rounding");
            curve = info.GetInt32("curve");
            downRightCurve = info.GetInt32("downRightCurve");
            downLeftCurve = info.GetInt32("downLeftCurve");
            upperRightCurve = info.GetInt32("upperRightCurve");
            upperLeftCurve = info.GetInt32("upperLeftCurve");
            borderwidth = info.GetInt32("borderwidth");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("endangle", endangle);
            info.AddValue("startangle", startangle);
            info.AddValue("controlWidth", controlWidth);
            info.AddValue("startingangle", startingangle);
            info.AddValue("radius", radius);
            info.AddValue("sides", sides);
            info.AddValue("shapecolor", shapecolor);
            info.AddValue("bordercolor", bordercolor);
            info.AddValue("drawBorder", drawBorder);
            info.AddValue("colorShape", colorShape);
            info.AddValue("rounding", rounding);
            info.AddValue("curve", curve);
            info.AddValue("downRightCurve", downRightCurve);
            info.AddValue("downLeftCurve", downLeftCurve);
            info.AddValue("upperRightCurve", upperRightCurve);
            info.AddValue("upperLeftCurve", upperLeftCurve);
            info.AddValue("borderwidth", borderwidth);
            
            
        }
    }

    #region Converter

    /// <summary>
    /// Class ShapeConverter.
    /// </summary>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    public class ShapeConverter : TypeConverter
    {

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns>true if this converter can perform the conversion; otherwise, false.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor)/* || destinationType == typeof(string)*/)
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        // This code allows the designer to generate the Shape constructor

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context,
            CultureInfo culture,
            object value,
            Type destinationType)
        {
            
                if (destinationType == typeof(string))
                {
                    // Display string in designer
                    return "(Customize)";
                }
                else if (destinationType == typeof(InstanceDescriptor) && value is ShapePopulate)
                {
                    ShapePopulate shapePopulate = (ShapePopulate)value;

                    switch (shapePopulate.Shape)
                    {
                        case Shapes.None:
                            ConstructorInfo ctorNone = typeof(ShapePopulate).GetConstructor(new Type[] {
                                typeof(Shapes),
                                typeof(bool),
                            });
                            if (ctorNone != null)
                            {
                                return new InstanceDescriptor(ctorNone, new object[] {
                                    //shapePopulate.None,
                                    shapePopulate.Shape,
                                    shapePopulate.NoneDraw,

                                });
                            }

                            break;
                        case Shapes.Rectangle:
                            ConstructorInfo ctorRect = typeof(ShapePopulate).GetConstructor(new Type[]
                            {
                                typeof(Shapes),
                                typeof(Color),
                                typeof(Color),
                                typeof(bool),
                                typeof(bool),
                                typeof(bool),
                                typeof(int),
                                typeof(int),
                                typeof(int),
                                typeof(int),
                                typeof(int)


                            });

                            if (ctorRect != null)
                            {
                                return new InstanceDescriptor(ctorRect, new object[] {
                                    //shapePopulate.Rectangle,
                                    shapePopulate.Shape,
                                    shapePopulate.BorderColor,
                                    shapePopulate.ShapeColor,
                                    shapePopulate.Rounding,
                                    shapePopulate.ColorShape,
                                    shapePopulate.DrawBorder,
                                    shapePopulate.Curve,
                                    shapePopulate.UpperLeftCurve,
                                    shapePopulate.UpperRightCurve,
                                    shapePopulate.DownLeftCurve,
                                    shapePopulate.DownRightCurve});
                            }

                            break;
                        case Shapes.Circle:

                            ConstructorInfo ctorCirc = typeof(ShapePopulate).GetConstructor(new Type[] {
                                typeof(Shapes),
                                typeof(Color),
                                typeof(Color),
                                typeof(bool),
                                typeof(bool),
                            });

                            if (ctorCirc != null)
                            {
                                return new InstanceDescriptor(ctorCirc, new object[] {
                                    //shapePopulate.Circle,
                                    shapePopulate.Shape,
                                    shapePopulate.BorderColor,
                                    shapePopulate.ShapeColor,
                                    shapePopulate.ColorShape,
                                    shapePopulate.DrawBorder,
                                });
                            }

                            break;
                        case Shapes.Polygon:

                            ConstructorInfo ctorPoly = typeof(ShapePopulate).GetConstructor(new Type[] {
                                typeof(Shapes),
                                typeof(int),
                                typeof(int) });
                            if (ctorPoly != null)
                            {
                                return new InstanceDescriptor(ctorPoly, new object[] {
                                    //shapePopulate.Polygon,
                                    shapePopulate.Shape,
                                    shapePopulate.PolygonSides,
                                    shapePopulate.PolygonStartingAngle,
                                });
                            }

                            break;
                        case Shapes.Pie:

                            ConstructorInfo ctorPie = typeof(ShapePopulate).GetConstructor(new Type[] {
                                typeof(Shapes),
                                typeof(float),
                                typeof(float),
                                typeof(bool)});

                            if (ctorPie != null)
                            {
                                return new InstanceDescriptor(ctorPie, new object[] {
                                    //shapePopulate.Pie,
                                    shapePopulate.Shape,
                                    shapePopulate.StartAngle,
                                    shapePopulate.EndAngle,
                                    shapePopulate.PieDraw
                                });
                            }

                            break;
                        default:
                            ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(Type.EmptyTypes);
                            if (ctor != null)
                            {
                                return new InstanceDescriptor(ctor, null);
                            }
                            break;
                    }

                    #region Old Code
                    //if (shapePopulate.Shape == Shapes.Rectangle)
                    //{
                    //    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[]
                    //    {
                    //            typeof(Shapes),
                    //            typeof(Color),
                    //            typeof(Color),
                    //            typeof(bool),
                    //            typeof(bool),
                    //            typeof(bool),
                    //            typeof(int),
                    //            typeof(int),
                    //            typeof(int),
                    //            typeof(int),
                    //            typeof(int)


                    //    });

                    //    if (ctor != null)
                    //    {
                    //        return new InstanceDescriptor(ctor, new object[] {
                    //                //shapePopulate.Rectangle,
                    //                shapePopulate.ShapeType,
                    //                shapePopulate.BorderColor,
                    //                shapePopulate.ShapeColor,
                    //                shapePopulate.Rounding,
                    //                shapePopulate.ColorShape,
                    //                shapePopulate.DrawBorder,
                    //                shapePopulate.Curve,
                    //                shapePopulate.UpperLeftCurve,
                    //                shapePopulate.UpperRightCurve,
                    //                shapePopulate.DownLeftCurve,
                    //                shapePopulate.DownRightCurve});
                    //    }
                    //}

                    //else if (shapePopulate.Shape == Shapes.Circle)
                    //{
                    //    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[] {
                    //            typeof(Shapes),
                    //            typeof(Color),
                    //            typeof(Color),
                    //            typeof(bool),
                    //            typeof(bool),
                    //            });
                    //    if (ctor != null)
                    //    {
                    //        return new InstanceDescriptor(ctor, new object[] {
                    //                //shapePopulate.Circle,
                    //                shapePopulate.ShapeType,
                    //                shapePopulate.BorderColor,
                    //                shapePopulate.ShapeColor,
                    //                shapePopulate.ColorShape,
                    //                shapePopulate.DrawBorder,
                    //                });
                    //    }
                    //}

                    //else if (shapePopulate.Shape == Shapes.Polygon)
                    //{
                    //    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[] {
                    //            typeof(Shapes),
                    //            typeof(int),
                    //            typeof(int) });
                    //    if (ctor != null)
                    //    {
                    //        return new InstanceDescriptor(ctor, new object[] {
                    //                //shapePopulate.Polygon,
                    //                shapePopulate.ShapeType,
                    //                shapePopulate.PolygonSides,
                    //                shapePopulate.PolygonStartingAngle,
                    //                });
                    //    }
                    //}

                    //else if (shapePopulate.Shape == Shapes.Pie)
                    //{
                    //    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[] {
                    //            typeof(Shapes),
                    //            typeof(float),
                    //            typeof(float),
                    //            typeof(bool)});
                    //    if (ctor != null)
                    //    {
                    //        return new InstanceDescriptor(ctor, new object[] {
                    //                //shapePopulate.Pie,
                    //                shapePopulate.ShapeType,
                    //                shapePopulate.StartAngle,
                    //                shapePopulate.EndAngle,
                    //                shapePopulate.PieDraw
                    //            });
                    //    }
                    //}

                    //else if (shapePopulate.Shape == Shapes.None)
                    //{
                    //    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(new Type[] {
                    //            typeof(Shapes),
                    //            typeof(bool),
                    //            });
                    //    if (ctor != null)
                    //    {
                    //        return new InstanceDescriptor(ctor, new object[] {
                    //                //shapePopulate.None,
                    //                shapePopulate.ShapeType,
                    //                shapePopulate.NoneDraw,

                    //            });
                    //    }
                    //}


                    //else
                    //{
                    //    ConstructorInfo ctor = typeof(ShapePopulate).GetConstructor(Type.EmptyTypes);
                    //    if (ctor != null)
                    //    {
                    //        return new InstanceDescriptor(ctor, null);
                    //    }
                    //} 
                    #endregion
                }
            

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    #endregion
}
