using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Zeroit.Framework.Utilities.Bitmap;

namespace Zeroit.Framework.Button
{
    /// <summary>
    /// A class for rendering circular and Polygonal 
    /// </summary>
    [ToolboxItem(true)]
    [Designer(typeof(ShaperControlDesigner))]
    [DefaultEvent("ShapeChanged")]
    public class Shaper : Control
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

        private HatchStyle hatchStyle = HatchStyle.ForwardDiagonal;

        private ShapeInput shapeInput = new ShapeInput(Shapes.Rectangle, Color.DeepSkyBlue, Color.Yellow, 1, true, 10,
            10, 10, 10, 10, false, true);

        Draw _drawMode = Draw.Solid;

        Zeroit.Framework.Utilities.Bitmap.Mirror.drawMode _mirrorDrawMode = Utilities.Bitmap.Mirror.drawMode.Solid;

        #endregion

        #region Public Properties

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
            Hatch
        }

        /// <summary>
        /// Sets the Draw Mode
        /// </summary>
        /// <remarks>
        /// This changes the rendering style of the button
        /// </remarks>
        public Draw DrawMode
        {
            get { return _drawMode; }
            set
            {
                if (value == Draw.Solid)
                {
                    _mirrorDrawMode = Utilities.Bitmap.Mirror.drawMode.Solid;
                }
                else if (value == Draw.Gradient)
                {
                    _mirrorDrawMode = Utilities.Bitmap.Mirror.drawMode.Gradient;
                }
                else
                {
                    _mirrorDrawMode = Utilities.Bitmap.Mirror.drawMode.Hatch;
                }

                _drawMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// A UI editor for manipulating the button for all purposes
        /// </summary>
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
        /// <remarks>
        /// This is applicable to rounded rectangular shape type
        /// </remarks>
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
        private Image _Image;
        private Size _ImageSize;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        private ContentAlignment _TextAlignment = ContentAlignment.MiddleCenter;
        private bool showText = true;
        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Sets the Image
        /// </summary>
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
        Point center;

        /// <summary>
        /// Sets the Sides of the Polygon
        /// </summary>
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
        /// <param name="Orig"> The origin is the middle of the star.</param>
        /// <param name="outerradius">Radius of the surRounding circle.</param>
        /// <param name="innerradius">Radius of the circle for the "inner" points</param>
        /// <returns>Array of 10 PointF structures</returns>
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
        private Bitmap bitmap;
        private RotateFlipType rotateFlip = RotateFlipType.Rotate180FlipX;
        private int length = 100;
        private LinearGradientMode linearGradientMode = LinearGradientMode.Vertical;
        private bool mirror = true;
        Rectangle rect;

        /// <summary>
        /// Sets the Rotation type
        /// </summary>
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
        public int Length
        {
            get { return length; }
            set { length = value; Invalidate(); }
        }

        /// <summary>
        /// Sets the Linear gradient mode 
        /// </summary>
        public LinearGradientMode GradientMode
        {
            get { return linearGradientMode; }
            set { linearGradientMode = value; Invalidate(); }
        }

        /// <summary>
        /// Set to enable and disable mirror property
        /// </summary>
        public bool Mirror
        {
            get { return mirror; }
            set { mirror = value; Invalidate(); }
        }

        public Mirror.drawMode MirrorDrawMode
        {
            get { return _mirrorDrawMode; }
            set { _mirrorDrawMode = value;
                Invalidate();
            }
        }

        #endregion


        #region HatchBrush

        private Color gradient1 = Color.Black;
        private Color gradient2 = Color.Transparent;



        #endregion
        
        #region HatchBrush Property

        /// <summary>
        /// Sets the Gradient Color
        /// </summary>
        /// <remarks>
        /// This sets the Linear gradient color 1 for the shape
        /// </remarks>
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
        /// <remarks>
        /// This sets the Linear gradient color 2 for the shape
        /// </remarks>
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

        

        /// <summary>
        /// Creates an instance of the Shaper class
        /// </summary>
        public Shaper()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            
        }

        public void RectangleControl(Graphics g)
        {
            
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
                    
                    break;
                case Draw.Gradient:
                    LinearGradientBrush linGrad = new LinearGradientBrush(rect, GradientColor1, GradientColor2, 90f);

                    if (ColorShape)
                    {
                        g.FillRectangle(linGrad, rect);

                        if (DrawBorder)
                        {
                            g.DrawRectangle(new Pen(BorderColor, BorderWidth), rect);
                        }
                    }
                    else
                    {
                        g.DrawRectangle(new Pen(BorderColor, BorderWidth), rect);
                    }

                    break;
                case Draw.Hatch:
                    HatchBrush hatchbrush = new HatchBrush(HatchStyle, gradient1, gradient2);

                    if (ColorShape)
                    {

                        g.FillRectangle(hatchbrush, rect);

                        if (DrawBorder)
                        {
                            g.DrawRectangle(new Pen(BorderColor, BorderWidth), rect);
                        }

                    }

                    else
                    {
                        g.DrawRectangle(new Pen(BorderColor, BorderWidth), rect);
                    }
                    
                    break;
                default:
                    break;
            }
            
            
        }
        
        public void RoundedRectControl(Graphics g)
        {
            if (Mirror)
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height / 2 - BorderWidth - 1);

            }
            else
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height - BorderWidth - 1);

            }


            GraphicsPath path = Zeroit.Framework.Button.Helper.Draw.RoundRect(rect, Curve, UpperLeftCurve, UpperRightCurve, DownLeftCurve, DownRightCurve);

            
            switch (DrawMode)
            {
                    
                case Draw.Solid:

                    if (ColorShape)
                    {

                        g.FillPath(new SolidBrush(ShapeColor), path);

                        if (DrawBorder)
                        {
                            g.DrawPath(new Pen(BorderColor, BorderWidth), path);
                        }

                    }

                    else
                    {
                        g.DrawPath(new Pen(BorderColor, BorderWidth), path);
                    }

                    break;
                case Draw.Gradient:
                    LinearGradientBrush linGrad = new LinearGradientBrush(rect, GradientColor1, GradientColor2, 90f);
                    
                    if (ColorShape)
                    {

                        g.FillPath(linGrad, path);

                        if (DrawBorder)
                        {
                            g.DrawPath(new Pen(BorderColor, BorderWidth), path);
                        }

                    }

                    else
                    {
                        g.DrawPath(new Pen(BorderColor, BorderWidth), path);
                    }

                    break;
                case Draw.Hatch:
                    HatchBrush hatchbrush = new HatchBrush(HatchStyle, gradient1, gradient2);

                    if (ColorShape)
                    {

                        g.FillPath(hatchbrush, path);

                        if (DrawBorder)
                        {
                            g.DrawPath(new Pen(BorderColor, BorderWidth), path);
                        }

                    }

                    else
                    {
                        g.DrawPath(new Pen(BorderColor, BorderWidth), path);
                    }

                    break;
                default:
                    break;
            }
            
        }

        public void CircleControl(Graphics g)
        {
            
            if (Mirror)
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height / 2 - BorderWidth - 1);

            }
            else
            {
                rect = new Rectangle((BorderWidth / 2), (BorderWidth / 2), Width - BorderWidth - 1, Height - BorderWidth - 1);

            }

            switch (DrawMode)
            {
                case Draw.Solid:
                    
                    if (ColorShape)
                    {

                        g.FillEllipse(new SolidBrush(ShapeColor), rect);

                        if (DrawBorder)
                        {
                            g.DrawEllipse(new Pen(BorderColor, BorderWidth), rect);
                        }

                    }

                    else
                    {
                        g.DrawEllipse(new Pen(BorderColor, BorderWidth), rect);
                    }

                    break;
                case Draw.Gradient:
                    LinearGradientBrush linGrad = new LinearGradientBrush(rect, GradientColor1, GradientColor2, 90f);

                    if (ColorShape)
                    {

                        g.FillEllipse(linGrad, rect);

                        if (DrawBorder)
                        {
                            g.DrawEllipse(new Pen(BorderColor, BorderWidth), rect);
                        }

                    }

                    else
                    {
                        g.DrawEllipse(new Pen(BorderColor, BorderWidth), rect);
                    }

                    break;
                case Draw.Hatch:
                    HatchBrush HB = new HatchBrush(HatchStyle, gradient1, gradient2);
                    
                    if (ColorShape)
                    {

                        g.FillEllipse(HB, rect);

                        if (DrawBorder)
                        {
                            g.DrawEllipse(new Pen(BorderColor, BorderWidth), rect);
                        }

                    }

                    else
                    {
                        g.DrawEllipse(new Pen(BorderColor, BorderWidth), rect);
                    }


                    break;
                default:
                    break;
            }
            

        }

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

            Point[] PolyGon1 = CalculateVertices(PolygonSides, PolygonRadius, PolygonStartingAngle, center);

            switch (DrawMode)
            {
                case Draw.Solid:
                    
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

                    break;
                case Draw.Gradient:

                    int counts = PolyGon1.Count();
                    LinearGradientBrush linGrad = new LinearGradientBrush(PolyGon1[0], PolyGon1[counts-1], GradientColor1, GradientColor2);
                    
                    if (ColorShape)
                    {

                        g.FillPolygon(linGrad, PolyGon1);

                        if (DrawBorder)
                        {
                            g.DrawPolygon(new Pen(BorderColor, BorderWidth), PolyGon1);
                        }

                    }

                    else
                    {
                        g.DrawPolygon(new Pen(BorderColor, BorderWidth), PolyGon1);
                    }
                    break;
                case Draw.Hatch:
                    HatchBrush HB = new HatchBrush(HatchStyle, gradient1, gradient2);

                    if (ColorShape)
                    {

                        g.FillPolygon(HB, PolyGon1);

                        if (DrawBorder)
                        {
                            g.DrawPolygon(new Pen(BorderColor, BorderWidth), PolyGon1);
                        }

                    }

                    else
                    {
                        g.DrawPolygon(new Pen(BorderColor, BorderWidth), PolyGon1);
                    }

                    break;
                default:
                    break;
            }


            //Graphics G = e.Graphics;
            //G.SmoothingMode = SmoothingMode.HighQuality;
            // init 4 stars


            
            
            
        }

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
            

            if (ColorShape)
            {
                switch (_drawMode)
                {
                    case Draw.Solid:
                        g.FillPie(new SolidBrush(ShapeColor), rect, StartAngle, EndAngle);

                        if (DrawBorder)
                        {
                            g.DrawPie(new Pen(BorderColor, BorderWidth), rect, StartAngle, EndAngle);
                        }
                        break;
                    case Draw.Gradient:
                        LinearGradientBrush linGrad = new LinearGradientBrush(rect, GradientColor1, GradientColor2, 90f);
                        
                        g.FillPie(linGrad, rect, StartAngle, EndAngle);

                        if (DrawBorder)
                        {
                            g.DrawPie(new Pen(BorderColor, BorderWidth), rect, StartAngle, EndAngle);
                        }

                        break;
                    case Draw.Hatch:
                        HatchBrush HB = new HatchBrush(HatchStyle, gradient1, gradient2);

                        g.FillPie(HB, rect, StartAngle, EndAngle);

                        if (DrawBorder)
                        {
                            g.DrawPie(new Pen(BorderColor, BorderWidth), rect, StartAngle, EndAngle);
                        }

                        break;
                    default:
                        break;
                }

                

            }

            else
            {
                g.DrawPie(new Pen(BorderColor, BorderWidth), rect, StartAngle, EndAngle);
            }


        }

        protected override void OnPaint(PaintEventArgs e)
        {
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
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.Clear(Color.Transparent);

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
                        Zeroit.Framework.Utilities.Bitmap.Mirror.DrawReflection(bitmap, BackColor, RotateFlip,
                        GradientMode,
                        Length), 0, 0);

                        break;
                    case Draw.Gradient:
                        //_mirrorDrawMode = Utilities.Bitmap.Mirror.drawMode.Gradient;
                        e.Graphics.DrawImage(
                        Zeroit.Framework.Utilities.Bitmap.Mirror.DrawReflection(bitmap, gradient2, gradient1, _mirrorDrawMode, RotateFlip,
                        GradientMode,
                        Length), 0, 0);

                        break;
                    case Draw.Hatch:
                        //_mirrorDrawMode = Utilities.Bitmap.Mirror.drawMode.Hatch;
                        e.Graphics.DrawImage(
                        Zeroit.Framework.Utilities.Bitmap.Mirror.DrawReflection(bitmap, gradient2, gradient1, _mirrorDrawMode, RotateFlip,
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

        }

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
        /// <param name="drawMode">Set the Draw Mode. Default value is Solid</param>
        /// <param name="RotateFlipType">Set Rotation. Default value is Rotate180FlipX</param>
        /// <param name="LinearGradientMode">Set Gradient Mode. Default value is Vertical</param>
        /// <param name="Length">Set the length. Default value is 100</param>
        /// <returns></returns>
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
        /// <param name="Curve">Set Curve</param>
        /// <param name="UpperLeftCurve">Set Upper Left Curve</param>
        /// <param name="UpperRightCurve">Set Upper Right Curve</param>
        /// <param name="DownLeftCurve">Set Down Left Curve</param>
        /// <param name="DownRightCurve">Set Down Right Curve</param>
        /// <returns></returns>
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
    }



}
