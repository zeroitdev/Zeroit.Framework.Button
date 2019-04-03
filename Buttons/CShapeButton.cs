// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="CShapeButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region CShape Button

    #region Enums
    /// <summary>
    /// Enum representint the graphics quality for <c><see cref="ZeroitCShape" /></c>.
    /// </summary>
    public enum RenderQuality
    {
        /// <summary>
        /// The high quality
        /// </summary>
        HighQuality = 0,
        /// <summary>
        /// The anti alias
        /// </summary>
        AntiAlias = 1,
        /// <summary>
        /// The high speed
        /// </summary>
        HighSpeed = 2,
        /// <summary>
        /// The default quality
        /// </summary>
        DefaultQuality = 3,
        /// <summary>
        /// The none
        /// </summary>
        None = 4
    }

    /// <summary>
    /// Enum representing the button shapes for  for <c><see cref="ZeroitCShape" /></c>.
    /// </summary>
    public enum ButtonShapes
    {
        /// <summary>
        /// The rectangle
        /// </summary>
        Rectangle = 0,
        /// <summary>
        /// The square
        /// </summary>
        Square = 1,
        /// <summary>
        /// The oval
        /// </summary>
        Oval = 2,
        /// <summary>
        /// The circle
        /// </summary>
        Circle = 3,
        /// <summary>
        /// The rnded rectangle
        /// </summary>
        RoundedRectangle = 4,
        /// <summary>
        /// The rnded square
        /// </summary>
        RoundedSquare = 5,
        /// <summary>
        /// The triangle
        /// </summary>
        Triangle = 6,
        /// <summary>
        /// The arrow
        /// </summary>
        Arrow = 7
    }

    /// <summary>
    /// Enum representing the 3D button shape  for <c><see cref="ZeroitCShape" /></c>.
    /// </summary>
    public enum Button3DShape
    {
        /// <summary>
        /// The flat
        /// </summary>
        Flat = 0,
        /// <summary>
        /// The shaded
        /// </summary>
        Shaded = 1,
        /// <summary>
        /// The shaded3 d
        /// </summary>
        Shaded3D = 2
    }

    /// <summary>
    /// Enum representing the button direction for  for <c><see cref="ZeroitCShape" /></c>.
    /// </summary>
    public enum ButtonDirection
    {
        /// <summary>
        /// The top
        /// </summary>
        Top = 0,
        /// <summary>
        /// The right
        /// </summary>
        Right = 1,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom = 2,
        /// <summary>
        /// The left
        /// </summary>
        Left = 3
    }
    #endregion

    #region Control    
    /// <summary>
    /// A class collection for rendering a customized button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Serializable]
    [Designer(typeof(ZeroitCShapeDesigner))]
    public class ZeroitCShape : System.Windows.Forms.Control
    {
        #region Variables
        //Custom
        /// <summary>
        /// The image3 d style
        /// </summary>
        Button3DShape Image3DStyle = Button3DShape.Flat;
        /// <summary>
        /// The image gradient mode
        /// </summary>
        LinearGradientMode ImageGradientMode = LinearGradientMode.Vertical;
        /// <summary>
        /// The image quality
        /// </summary>
        SmoothingMode ImageQuality = SmoothingMode.HighQuality;
        /// <summary>
        /// The image shape
        /// </summary>
        ButtonShapes ImageShape = ButtonShapes.Square;
        /// <summary>
        /// The image hatch style
        /// </summary>
        HatchStyle ImageHatchStyle = HatchStyle.DashedHorizontal;
        /// <summary>
        /// The image direction
        /// </summary>
        ButtonDirection ImageDirection = ButtonDirection.Top;
        /// <summary>
        /// The image ln style
        /// </summary>
        DashStyle ImageLnStyle = DashStyle.Solid;

        /// <summary>
        /// The image hatched
        /// </summary>
        bool ImageHatched = false;
        /// <summary>
        /// The object initialized
        /// </summary>
        bool objInitialized = false;
        /// <summary>
        /// The object trans parent
        /// </summary>
        bool ObjTransParent = false;
        /// <summary>
        /// The object out line
        /// </summary>
        bool objOutLine = true;
        /// <summary>
        /// The object is circ
        /// </summary>
        bool ObjIsCirc = false;

        /// <summary>
        /// The image draw width
        /// </summary>
        int ImageDrawWidth = 1;
        //Colors
        /// <summary>
        /// The col fill
        /// </summary>
        Color colFill = Color.AliceBlue;
        /// <summary>
        /// The col out line
        /// </summary>
        Color colOutLine = Color.Gray;
        /// <summary>
        /// The col alternate
        /// </summary>
        Color colAlternate = Color.LightGray;
        /// <summary>
        /// The col grad colors
        /// </summary>
        Color[] colGradColors = { };
        /// <summary>
        /// The col grad positions
        /// </summary>
        float[] colGradPositions = { };
        /// <summary>
        /// The image radius
        /// </summary>
        double ImageRadius = 0.1;

        #region Objects
        /// <summary>
        /// The GRFX pen
        /// </summary>
        Pen grfxPen = new Pen(Color.DimGray);
        //Build the object
        /// <summary>
        /// The GRFX object
        /// </summary>
        GraphicsPath grfxObject = new GraphicsPath();
        /// <summary>
        /// The GRFX brush
        /// </summary>
        Brush grfxBrush = new SolidBrush(Color.LightGray);
        #endregion

        /// <summary>
        /// Sets the size of the process working set.
        /// </summary>
        /// <param name="hProcess">The h process.</param>
        /// <param name="dwMinimumWorkingSetSize">Size of the dw minimum working set.</param>
        /// <param name="dwMaximumWorkingSetSize">Size of the dw maximum working set.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int SetProcessWorkingSetSize(
            int hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);
        #endregion

        #region Properties
        /*
		 * Remember in the properties, you only want to re-build/redraw if the new value
		 * is different from the existing value. Saves unnecessary computing
		 */
        /// <summary>
        /// Gets or sets the HatchStyle for the object when in Flat Shading mode.
        /// </summary>
        /// <value>The hatch fill style.</value>
        [Description("Sets the HatchStyle for the object when in Flat Shading mode."), 
            Category("Drawing")]
        
        public HatchStyle HatchFillStyle
        {
            get { return ImageHatchStyle; }
            set
            {
                if (ImageHatchStyle != value)
                {
                    ImageHatchStyle = value;
                    if (ImageHatched == true & Image3DStyle == Button3DShape.Flat)
                    {
                        BuildBrush();
                        DrawObject();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the object to be filled with Hatches when in Flat Shading mode.
        /// </summary>
        /// <value><c>true</c> if hatch fill; otherwise, <c>false</c>.</value>
        [Description("Sets the object to be filled with Hatches when in Flat Shading mode."), 
            Category("Drawing")]
        public bool HatchFill
        {
            get { return ImageHatched; }
            set
            {
                if (ImageHatched != value)
                {
                    ImageHatched = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }


        /// <summary>
        /// Gets or sets the Shape drawn for the object.
        /// </summary>
        /// <value>The shape.</value>
        [Description("Sets the Shape drawn for the object."), 
            Category("Drawing")]
        public ButtonShapes Shape
        {
            get { return ImageShape; }
            set
            {
                if (ImageShape != value)
                {
                    ImageShape = value;
                    BuildObject();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the gradient mode.
        /// </summary>
        /// <value>The shape gradient mode.</value>
        [Description("Sets the Gradient mode for the object."), 
            Category("Drawing")]
        public LinearGradientMode ShapeGradientMode
        {
            get
            {
                return ImageGradientMode;
            }
            set
            {
                if (ImageGradientMode != value)
                {
                    ImageGradientMode = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the level of Anti-Aliasing for the object.
        /// </summary>
        /// <value>The shape quality.</value>
        [Description("Sets the level of Anti-Aliasing for the object."), 
            Category("Drawing")]
        public RenderQuality ShapeQuality
        {
            get
            {
                switch (ImageQuality)
                {
                    case SmoothingMode.AntiAlias:
                        return RenderQuality.AntiAlias;
                    case SmoothingMode.HighQuality:
                        return RenderQuality.HighQuality;
                    case SmoothingMode.HighSpeed:
                        return RenderQuality.HighSpeed;
                    case SmoothingMode.Default:
                        return RenderQuality.DefaultQuality;
                    case SmoothingMode.None:
                        return RenderQuality.None;
                    default:
                        return RenderQuality.None;
                }
            }
            set
            {
                switch (value)
                {
                    case RenderQuality.AntiAlias:
                        ImageQuality = SmoothingMode.AntiAlias;
                        break;
                    case RenderQuality.HighQuality:
                        ImageQuality = SmoothingMode.HighQuality;
                        break;
                    case RenderQuality.HighSpeed:
                        ImageQuality = SmoothingMode.HighSpeed;
                        break;
                    case RenderQuality.DefaultQuality:
                        ImageQuality = SmoothingMode.Default;
                        break;
                    case RenderQuality.None:
                        ImageQuality = SmoothingMode.None;
                        break;
                    default:
                        ImageQuality = SmoothingMode.None;
                        break;
                }
                DrawObject();
            }
        }


        /// <summary>
        /// Gets or sets the shading mode.
        /// </summary>
        /// <value>The shape shading.</value>
        [Description("Sets the Shading mode for the object."), 
            Category("Drawing")]
        public Button3DShape ShapeShading
        {
            get
            {
                return Image3DStyle;
            }
            set
            {
                if (Image3DStyle != value)
                {
                    Image3DStyle = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Thermometer Color.
        /// </summary>
        /// <value>The Thermometer Color.</value>
        [Description("Sets the Thermometer Color."), Category("Colors")]
        public Color FillColor
        {
            get { return colFill; }
            set
            {
                if (colFill != value)
                {
                    colFill = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the outline Color the thermometer is drawn in.
        /// </summary>
        /// <value>The color of the out line.</value>
        [Description("Sets the the outline Color the thermometer is drawn in."), 
            Category("Colors")]
        public Color OutLineColor
        {
            get { return colOutLine; }
            set
            {
                if (colOutLine != value)
                {
                    colOutLine = value;
                    grfxPen = GetPen();
                    DrawObject();
                }
            }
        }


        /// <summary>
        /// Gets or sets the Alternate shading color.
        /// </summary>
        /// <value>The color of the alternate.</value>
        [Description("Sets the Alternate shading color."), 
            Category("Drawing")]
        public Color AlternateColor
        {
            get { return colAlternate; }
            set
            {
                if (colAlternate != value)
                {
                    colAlternate = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the pen width for the object.
        /// </summary>
        /// <value>The width of the draw.</value>
        [Description("Sets the pen width for the object."), 
            Category("Drawing")]
        public int BorderWidth
        {
            get { return ImageDrawWidth; }
            set
            {
                if (ImageDrawWidth != value)
                {
                    ImageDrawWidth = value;
                    grfxPen = GetPen();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the Color array used in the 3D Shading Mode.
        /// </summary>
        /// <value>The gradients.</value>
        [Description("Sets the Color array used in the 3D Shading Mode."), 
            Category("3DDrawing")]
        public Color[] Gradients
        {
            get { return colGradColors; }
            set
            {
                if (colGradColors != value)
                {
                    colGradColors = value;
                    if (colGradColors.Length != colGradPositions.Length)
                    {
                        if (colGradPositions.Length <= 0) { colGradPositions = new float[value.Length]; }
                        //colGradPositions
                        float[] m_Floats = new float[value.Length];
                        for (int i = 0; i < colGradPositions.Length; i++)
                        {
                            if (colGradPositions.Length >= i)
                            {
                                m_Floats[i] = colGradPositions[i];
                            }
                        }
                        //Reset the positions fro the length of the colors
                        colGradPositions = new float[value.Length];
                        //Copy the origional values back in
                        for (int i = 0; i < m_Floats.Length; i++)
                        {
                            colGradPositions[i] = m_Floats[i];
                        }
                    }
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the positions of each color in the gradient color array when in 3D shading mode.
        /// </summary>
        /// <value>The gradient positions.</value>
        [Description("Sets the positions of each color in the gradient color array when in 3D shading mode."), 
            Category("3DDrawing")]
        public float[] GradientPositions
        {
            get { return colGradPositions; }
            set
            {
                if (colGradPositions != value)
                {
                    colGradPositions = value;
                    BuildBrush();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Activates/Deactivates the drawing on the object.
        /// </summary>
        /// <value><c>true</c> if z object; otherwise, <c>false</c>.</value>
        [Description("Activates/Deactivates the drawing on the object."), Category("Drawing")]
        public bool zObject
        {
            get { return objInitialized; }
            set { objInitialized = value; DrawObject(); }
        }

        /// <summary>
        /// Gets or sets the radius of the rounded corners when applicable.
        /// </summary>
        /// <value>The corner radius.</value>
        [Description("Sets the radius of the rounded corners when applicable."), 
            Category("Rounded Square/Rectangle")]
        public double CornerRadius
        {
            get { return ImageRadius; }
            set
            {
                if (value >= 0.1 & value < 1)
                {
                    if (ImageRadius != value)
                    {
                        ImageRadius = value;
                        if (ImageShape == ButtonShapes.RoundedRectangle ||
                            ImageShape == ButtonShapes.RoundedSquare)
                        {
                            DrawObject();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        [Description("Sets the Direction of the object when applicable"), 
            Category("Arrow / Triangle")]
        public ButtonDirection Direction
        {
            get { return ImageDirection; }
            set
            {
                if (ImageDirection != value)
                {
                    ImageDirection = value;
                    BuildObject();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the background opacity.
        /// </summary>
        /// <value><c>true</c> if transparent background; otherwise, <c>false</c>.</value>
        [Description("Sets the background opacity."), Category("Drawing")]
        public bool TransparentBackground
        {
            get { return ObjTransParent; }
            set
            {
                if (ObjTransParent != value)
                {
                    ObjTransParent = value;
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the style of line to draw the object.
        /// </summary>
        /// <value>The line style.</value>
        [Description("Sets/Gets the style of line to draw the object."), Category("Drawing")]
        public DashStyle LineStyle
        {
            get { return ImageLnStyle; }
            set
            {
                if (ImageLnStyle != value)
                {
                    ImageLnStyle = value;
                    grfxPen = GetPen();
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not to draw an outline around the object.
        /// </summary>
        /// <value><c>true</c> if outline; otherwise, <c>false</c>.</value>
        [Description("Sets/Gets whether or not to draw an outline around the object."), Category("Drawing")]
        public bool OutLine
        {
            get { return objOutLine; }
            set
            {
                if (objOutLine != value)
                {
                    objOutLine = value;
                    DrawObject();
                }
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        [Description("Sets/Gets the shape BorderStyle."), Category("Drawing")]
        public BorderStyle BorderStyle
        {
            get { return picImage.BorderStyle; }
            set
            {
                if (picImage.BorderStyle != value)
                {
                    picImage.BorderStyle = value;
                }
            }
        }
        //Colors
        #endregion

        /// <summary>
        /// The pic image
        /// </summary>
        private System.Windows.Forms.PictureBox picImage;
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCShape" /> class.
        /// </summary>
        public ZeroitCShape()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;


            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <returns>Pen.</returns>
        #region Build Brushes/Pen
        //Builds the Pen object used to draw the shape
        private Pen GetPen()
        {
            //Here you set the pen linestyle,color and thickness
            Pen t_Pen = new Pen(colOutLine, ImageDrawWidth);
            t_Pen.DashStyle = ImageLnStyle;
            return t_Pen;
        }

        //Builds a 2 Color LinearGradientBrush
        /// <summary>
        /// Builds the brushes.
        /// </summary>
        /// <returns>LinearGradientBrush.</returns>
        private LinearGradientBrush BuildBrushes()
        {
            //Build the Brush and set it's Paint Area, The Alternate Color
            //The Primary Color, and the Gradient Mode
            return new LinearGradientBrush(this.ClientRectangle,
                colAlternate, colFill, ImageGradientMode);
        }

        //Builds a 1 Color LinearGradientBrush
        /// <summary>
        /// Builds the flat brush.
        /// </summary>
        /// <returns>LinearGradientBrush.</returns>
        private LinearGradientBrush BuildFlatBrush()
        {
            //Build the Brush and set it's Paint Area, The Alternate Color=Primary Color
            //The Primary Color, and the Gradient Mode is defaulted, because there is not 
            //Visible gradient
            return new LinearGradientBrush(this.ClientRectangle,
                colFill, colFill, LinearGradientMode.Vertical);
        }

        //Builds a User-Defined LinearGradientBrush
        /// <summary>
        /// Build3s the d brush.
        /// </summary>
        /// <returns>LinearGradientBrush.</returns>
        private LinearGradientBrush Build3DBrush()
        {
            //Multi Colored brushes are a little more difficult than the standard
            //2 color brush.
            //First thing, check for the usable properties and ensure that they are 
            //properly setup. If not just send it to the gradient brush function until they are
            //Setup properly, that will give them an image to see at least.
            //Make sure there are colors in the Color Array
            if (colGradColors == null || colGradColors.Length <= 0)
            { MessageBox.Show("No Colors Assigned to color Array!"); return BuildBrushes(); }
            //Make sure there are positions to set the colors in the color array properly
            //into the brush gradient
            if (colGradPositions == null || colGradPositions.Length <= 0)
            { MessageBox.Show("No Color positions assigned to positions array!"); return BuildBrushes(); }
            //Make sure that the color array has the same number of elements as 
            //the Color position array or it will bomb. 
            if (colGradPositions.Length != colGradPositions.Length)
            { MessageBox.Show("Different amount of color from positions!"); return BuildBrushes(); }
            //Create an new standard LinearGradientBrush as you would any other
            LinearGradientBrush lBrush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height),
                colAlternate, colFill, ImageGradientMode);
            try
            {
                //Create a Color Blend object. The ColorBlend brings together the Colors Selected
                //And the positions the user wants them put at.
                ColorBlend cBlend = new ColorBlend((int)(colGradColors.Length - 1));
                //Set the user-defined Colors
                cBlend.Colors = colGradColors;
                //Set the user-defined Positions for the Colors
                cBlend.Positions = colGradPositions;
                //Set the LinearGradientBrush's Interpolation Colors. Layman- Tell the brush
                //to paint each color to a certain percent of the fillarea and then begin the next
                //color accordingly
                lBrush.InterpolationColors = cBlend;
                //Return your newly created 3D brush;
                return lBrush;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string Message = "There was an error, Check your Gradient Positions.\r\n";
                Message += "Make Sure that the First Position is 0.0 And the Last Position is 1.0. \r\n";
                Message += "Make Sure that Number of Colors matches the number of positions.";
                MessageBox.Show(Message);
                return BuildBrushes();
            }

        }

        //Builds a HatchBrush
        /// <summary>
        /// Builds the hatch brush.
        /// </summary>
        /// <returns>HatchBrush.</returns>
        private HatchBrush BuildHatchBrush()
        {
            //Very Simple Brush
            //Here you set the brush HatchStyle,AlternateColr and PrimaryColor
            return new HatchBrush(ImageHatchStyle, colAlternate, colFill);
        }
        //Builds a Brush that is defiend for a GraphicsPath-created earlier
        /// <summary>
        /// Builds the path brush.
        /// </summary>
        /// <param name="pth">The PTH.</param>
        /// <returns>PathGradientBrush.</returns>
        private PathGradientBrush BuildPathBrush(GraphicsPath pth)
        {
            //First Create a generic Path Brush, using the graphicsPath(shape)
            //Passed in.
            PathGradientBrush brsh = new PathGradientBrush(pth);
            //Set the CenterColor for the brush, since this brush is being used for circular
            //shapes
            brsh.CenterColor = colAlternate;
            //Set the Surround Color tot he promary color for the brush, since this brush 
            //is being used for circular shapes
            brsh.SurroundColors = new Color[] { colFill };
            return brsh;
        }
        #endregion

        #region Build Objects
        /// <summary>
        /// Builds the rect.
        /// </summary>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildRect()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            //Set the New Rectangle bound = to the control bounds
            grfxRect = new Rectangle(0, 0, (int)(this.Width - 1), (int)(this.Height - 1));
            try
            {
                //Start the Figure
                grfxPath.StartFigure();
                //Add the shape to the Path
                grfxPath.AddRectangle(grfxRect);
                //Close the Path, this ensures that all line will form 
                //one Continuous shape outline
                grfxPath.CloseFigure();
                //Return the Path to be drawn and filled
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        /// <summary>
        /// Builds the square.
        /// </summary>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildSquare()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }

            try
            {
                grfxPath.StartFigure();
                grfxPath.AddRectangle(grfxRect);
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        /// <summary>
        /// Builds the oval.
        /// </summary>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildOval()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            //Set the New Rectangle bound = to the control bounds
            grfxRect = new Rectangle(0, 0, (int)(this.Width - 1), (int)(this.Height - 1));
            try
            {
                grfxPath.StartFigure();
                grfxPath.AddEllipse(grfxRect);
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        /// <summary>
        /// Builds the circle.
        /// </summary>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildCircle()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }

            try
            {
                grfxPath.StartFigure();
                grfxPath.AddEllipse(grfxRect);
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        /// <summary>
        /// Builds the random rect.
        /// </summary>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildRndRect()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            //Set the New Rectangle bound = to the control bounds
            grfxRect = new Rectangle(0, 0, (int)(this.Width - 1), (int)(this.Height - 1));
            //The Radius of the rounded edges
            float radius = (int)(grfxRect.Height * ImageRadius);
            //Width of the rectangle
            float width = (int)(grfxRect.Width);
            //Height of the rectangle
            float height = (int)(grfxRect.Height);
            //Following two lines are simply the Location of the rectangle
            float X = grfxRect.Left;
            float Y = grfxRect.Top;
            //Make sure the radius is a valid value
            if (radius < 1) { radius = 1; }
            try
            {
                grfxPath.StartFigure();
                grfxPath.AddLine(X + radius, Y, X + width - (radius * 2), Y);
                grfxPath.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
                grfxPath.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
                grfxPath.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
                grfxPath.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
                grfxPath.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
                grfxPath.AddLine(X, Y + height - (radius * 2), X, Y + radius);
                grfxPath.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        /// <summary>
        /// Builds the random square.
        /// </summary>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildRndSquare()
        {
            //Create a new Graphics Path
            GraphicsPath grfxPath = new GraphicsPath();
            //Create a new Rectangle for Calculations
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }
            float radius = (int)(grfxRect.Width * ImageRadius);
            float width = (int)(grfxRect.Width);
            float height = (int)(grfxRect.Height);
            float X = grfxRect.Left;
            float Y = grfxRect.Top;

            try
            {
                grfxPath.StartFigure();
                grfxPath.AddLine(X + radius, Y, X + width - (radius * 2), Y);
                grfxPath.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
                grfxPath.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
                grfxPath.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
                grfxPath.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
                grfxPath.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
                grfxPath.AddLine(X, Y + height - (radius * 2), X, Y + radius);
                grfxPath.AddArc(X, Y, radius * 2, radius * 2, 180, 90);

                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        /// <summary>
        /// Builds the triangle.
        /// </summary>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildTriangle()
        {
            GraphicsPath grfxPath = new GraphicsPath();
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }
            m_Diff = grfxRect.Left;
            try
            {
                grfxPath.StartFigure();
                switch (ImageDirection)
                {
                    default:
                    case ButtonDirection.Top:
                        grfxPath.AddLine((int)(this.Width * .5), 0, 0, (int)(this.Height - 1));
                        grfxPath.AddLine(0, (int)(this.Height - 1), this.Width, (int)(this.Height - 1));
                        grfxPath.AddLine(this.Width, (int)(this.Height - 1), (int)(this.Width * .5), 0);
                        break;
                    case ButtonDirection.Right:
                        grfxPath.AddLine(0, 0, 0, (int)(this.Height - 1));
                        grfxPath.AddLine(0, (int)(this.Height - 1), (int)(this.Width - 1), (int)(this.Height * .5));
                        grfxPath.AddLine((int)(this.Width - 1), (int)(this.Height * .5), 0, 0);
                        break;
                    case ButtonDirection.Bottom:
                        grfxPath.AddLine(0, 0, (int)(this.Width * .5), (int)(this.Height - 1));
                        grfxPath.AddLine((int)(this.Width * .5), (int)(this.Height - 1), this.Width, 0);
                        grfxPath.AddLine(this.Width, 0, 0, 0);
                        break;
                    case ButtonDirection.Left:
                        grfxPath.AddLine(0, (int)(this.Height * .5), (int)(this.Width - 1), (int)(this.Height - 1));
                        grfxPath.AddLine((int)(this.Width - 1), (int)(this.Height - 1), (int)(this.Width - 1), 0);
                        grfxPath.AddLine((int)(this.Width - 1), 0, 0, (int)(this.Height * .5));
                        break;
                }
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        /// <summary>
        /// Builds the arrow.
        /// </summary>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildArrow()
        {
            GraphicsPath grfxPath = new GraphicsPath();
            Rectangle grfxRect = new Rectangle();
            int m_Diff = 0;
            if (this.Height > this.Width)
            {
                m_Diff = (int)((this.Height - this.Width) * .5);
                grfxRect = new Rectangle(0, (int)(m_Diff - 1), (int)(this.Width - 1), (int)(this.Height - (m_Diff * 2)));
            }
            else
            {
                m_Diff = (int)((this.Width - this.Height) * .5);
                grfxRect = new Rectangle((int)(m_Diff - 1), 0, (int)(this.Width - (m_Diff * 2)), (int)(this.Height - 1));
            }
            m_Diff = grfxRect.Left;
            try
            {
                grfxPath.StartFigure();
                switch (ImageDirection)
                {
                    default:
                    case ButtonDirection.Top:
                        grfxPath.AddLine((int)(this.Width * .5), 0, 0, (int)(this.Height - 1));
                        grfxPath.AddLine(0, (int)(this.Height - 1), (int)(this.Width * .5), (int)(this.Height * .8));
                        grfxPath.AddLine((int)(this.Width * .5), (int)(this.Height * .8), this.Width, (int)(this.Height - 1));
                        grfxPath.AddLine(this.Width, (int)(this.Height - 1), (int)(this.Width * .5), 0);
                        break;
                    case ButtonDirection.Right:
                        grfxPath.AddLine(0, 0, (int)(this.Width * .2), (int)(this.Height * .5));
                        grfxPath.AddLine((int)(this.Width * .2), (int)(this.Height * .5), 0, (int)(this.Height - 1));
                        grfxPath.AddLine(0, (int)(this.Height - 1), (int)(this.Width - 1), (int)(this.Height * .5));
                        grfxPath.AddLine((int)(this.Width - 1), (int)(this.Height * .5), 0, 0);
                        break;
                    case ButtonDirection.Bottom:
                        grfxPath.AddLine(0, 0, (int)(this.Width * .5), (int)(this.Height - 1));
                        grfxPath.AddLine((int)(this.Width * .5), (int)(this.Height - 1), this.Width, 0);
                        grfxPath.AddLine(this.Width, 0, (int)(this.Width * .5), (int)(this.Height * .2));
                        grfxPath.AddLine((int)(this.Width * .5), (int)(this.Height * .2), 0, 0);
                        break;
                    case ButtonDirection.Left:
                        grfxPath.AddLine(0, (int)(this.Height * .5), (int)(this.Width - 1), (int)(this.Height - 1));

                        grfxPath.AddLine((int)(this.Width - 1), (int)(this.Height - 1),
                            (int)(this.Width * .8), (int)(this.Height * .5));

                        grfxPath.AddLine((int)(this.Width * .8), (int)(this.Height * .5),
                            (int)(this.Width - 1), 0);

                        grfxPath.AddLine((int)(this.Width - 1), 0, 0, (int)(this.Height * .5));
                        break;
                }
                grfxPath.CloseFigure();
                return grfxPath;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
                return null;
            }
        }
        
        #endregion


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            if (AllowTransparency)
            {
                MakeTransparent(this, g);
            }

        }






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



        #region Include in Paint

        //-----------------------------Include in Paint--------------------------//
        //
        // if(AllowTransparency)
        //  {
        //    MakeTransparent(this,g);
        //  }
        //
        //-----------------------------Include in Paint--------------------------//

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



        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Build and Draw Routines
        //The BuildObject Routine determines the object selected as the shape
        //and builds it accordingly
        /// <summary>
        /// Builds the object.
        /// </summary>
        private void BuildObject()
        {
            switch (ImageShape)
            {
                default:
                case ButtonShapes.Square:
                    grfxObject = this.BuildSquare();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.RoundedSquare:
                    grfxObject = this.BuildRndSquare();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Rectangle:
                    grfxObject = this.BuildRect();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.RoundedRectangle:
                    grfxObject = this.BuildRndRect();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Circle:
                    grfxObject = this.BuildCircle();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Oval:
                    grfxObject = this.BuildOval();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Triangle:
                    grfxObject = BuildTriangle();
                    ObjIsCirc = false;
                    break;
                case ButtonShapes.Arrow:
                    grfxObject = BuildArrow();
                    ObjIsCirc = false;
                    break;
            }
            BuildBrush();
        }

        //The BuildBrush Routine determines what type of fill was selected for the shape
        //And Builds a brush to accordingly
        /// <summary>
        /// Builds the brush.
        /// </summary>
        private void BuildBrush()
        {
            switch (Image3DStyle)
            {
                default:
                case Button3DShape.Flat:
                    if (ImageHatched == true)
                    {
                        grfxBrush = this.BuildHatchBrush();
                    }
                    else
                    {
                        grfxBrush = this.BuildFlatBrush();
                    }
                    break;
                case Button3DShape.Shaded:
                    grfxBrush = this.BuildBrushes();
                    break;
                case Button3DShape.Shaded3D:
                    if (ObjIsCirc == true)
                    {
                        grfxBrush = this.BuildPathBrush(grfxObject);
                    }
                    else
                    {
                        grfxBrush = this.Build3DBrush();
                    }
                    break;
            }
        }
        //The Rebuild() Routine re-Builds all elements on the screen
        /// <summary>
        /// Res the build.
        /// </summary>
        private void ReBuild()
        {
            //Build the pen object
            grfxPen = GetPen();
            //Build the object
            BuildObject();
            //Draw The Object to the screen
            DrawObject();
        }

        //The DrawObject routine is the routine responsible for presenting the 
        //Image to the screen after it is drawn. It utilized a seperate Image Created
        //in Memory to do the drawing and then sets it's image to the screen.
        /// <summary>
        /// Draws the object.
        /// </summary>
        private void DrawObject()
        {
            //if(objInitialized==false){return;}
            //Create the graphics Object and set Quality
            Bitmap bit = new Bitmap(picImage.Width, picImage.Height);
            Graphics grfx = Graphics.FromImage(bit);
            grfx.SmoothingMode = ImageQuality;
            
            try
            {
                //Present the Shape
                grfx.FillPath(grfxBrush, grfxObject);
                CenterString(grfx, Text, Font, ForeColor, ClientRectangle);
                //Only draw an Outline if the user wants it.
                //Point to remember when drawing in GDI+. If you want a good outline
                //Draw the outline last. To view the difference switch the previous line
                //with the following line.
                if (objOutLine == true) { grfx.DrawPath(grfxPen, grfxObject); }
                //Set the background properties
                if (ObjTransParent == true)
                {
                    this.Region = new Region(grfxObject);
                }
                else
                {
                    this.Region = new Region(this.ClientRectangle);
                }
                picImage.Image = bit;
                picImage.Refresh();
                bit = null;
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
            }
            finally
            {
                //Graphics and Pen
                grfx.Dispose(); grfx = null;
            }
            
            
            
        }

        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(17, 17);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(59, 141);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            this.picImage.DoubleClick += new System.EventHandler(this.picImage_DoubleClick);
            // 
            // csShape
            // 
            this.Controls.Add(this.picImage);
            this.Resize += new System.EventHandler(this.csShape_Resize);
            this.Size = new System.Drawing.Size(67, 150);
            this.ResumeLayout(false);

        }
        #endregion

        #region resize Events
        /// <summary>
        /// Handles the Paint event of the csShape control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void csShape_Paint(object sender, System.EventArgs e)
        {
            try
            {
                ReBuild();
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
            }
        }

        /// <summary>
        /// Handles the Resize event of the csShape control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void csShape_Resize(object sender, System.EventArgs e)
        {
            try
            {
                picImage.Location = new Point(0, 0);
                picImage.Size = new Size(this.Width, this.Height);
                ReBuild();
            }
            catch (IOException ioe)
            {
                string msg = ioe.Message;
                msg = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the picImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void picImage_Click(object sender, System.EventArgs e)
        {
            OnClick(e);
        }

        /// <summary>
        /// Handles the DoubleClick event of the picImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void picImage_DoubleClick(object sender, System.EventArgs e)
        {
            OnDoubleClick(e);
        }

        #endregion

        #region Process Management
        /// <summary>
        /// Manages the memory.
        /// </summary>
        private void ManageMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                //Tell the machine to swap processes
                Int32 RetVal = SetProcessWorkingSetSize((int)
                    System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
        
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

        

    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitCShapeDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitCShapeDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitCShapeDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitCShapeSmartTagActionList(this.Component));
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
    /// Class ZeroitCShapeSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitCShapeSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitCShape colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitCShapeSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitCShapeSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitCShape;

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
        /// Gets or sets a value indicating whether [hatch fill].
        /// </summary>
        /// <value><c>true</c> if [hatch fill]; otherwise, <c>false</c>.</value>
        public bool HatchFill
        {
            get { return colUserControl.HatchFill; }
            set
            {
                GetPropertyByName("HatchFill").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the hatch fill style.
        /// </summary>
        /// <value>The hatch fill style.</value>
        public HatchStyle HatchFillStyle
        {
            get { return colUserControl.HatchFillStyle; }
            set
            {
                GetPropertyByName("HatchFillStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>The shape.</value>
        public ButtonShapes Shape
        {
            get { return colUserControl.Shape; }
            set
            {
                GetPropertyByName("Shape").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape gradient mode.
        /// </summary>
        /// <value>The shape gradient mode.</value>
        public LinearGradientMode ShapeGradientMode
        {
            get { return colUserControl.ShapeGradientMode; }
            set
            {
                GetPropertyByName("ShapeGradientMode").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape shading.
        /// </summary>
        /// <value>The shape shading.</value>
        public Button3DShape ShapeShading
        {
            get { return colUserControl.ShapeShading; }
            set
            {
                GetPropertyByName("ShapeShading").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the line style.
        /// </summary>
        /// <value>The line style.</value>
        public DashStyle LineStyle
        {
            get { return colUserControl.LineStyle; }
            set
            {
                GetPropertyByName("LineStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        public BorderStyle BorderStyle
        {
            get { return colUserControl.BorderStyle; }
            set
            {
                GetPropertyByName("BorderStyle").SetValue(colUserControl, value);
            }
        }

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
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color FillColor
        {
            get { return colUserControl.FillColor; }
            set
            {
                GetPropertyByName("FillColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the out line.
        /// </summary>
        /// <value>The color of the out line.</value>
        public Color OutLineColor
        {
            get { return colUserControl.OutLineColor; }
            set
            {
                GetPropertyByName("OutLineColor").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the color of the alternate.
        /// </summary>
        /// <value>The color of the alternate.</value>
        public Color AlternateColor
        {
            get { return colUserControl.AlternateColor; }
            set
            {
                GetPropertyByName("AlternateColor").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the gradients.
        /// </summary>
        /// <value>The gradients.</value>
        public Color[] Gradients
        {
            get { return colUserControl.Gradients; }
            set
            {
                GetPropertyByName("Gradients").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gradient positions.
        /// </summary>
        /// <value>The gradient positions.</value>
        public float[] GradientPositions
        {
            get { return colUserControl.GradientPositions; }
            set
            {
                GetPropertyByName("GradientPositions").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return colUserControl.BorderWidth; }
            set
            {
                GetPropertyByName("BorderWidth").SetValue(colUserControl, value);
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
                        

            items.Add(new DesignerActionPropertyItem("HatchFill",
                                 "Hatch Fill", "Appearance",
                                 "Sets whether to fill with a hatch."));

            items.Add(new DesignerActionPropertyItem("HatchFillStyle",
                                 "Hatch FillStyle", "Appearance",
                                 "Sets the hatch fill style."));

            items.Add(new DesignerActionPropertyItem("Shape",
                                 "Shape", "Appearance",
                                 "Sets the shape of the control."));

            items.Add(new DesignerActionPropertyItem("ShapeGradientMode",
                                 "Gradient Mode", "Appearance",
                                 "Sets the gradient mode."));

            items.Add(new DesignerActionPropertyItem("ShapeShading",
                                 "Shape Shading", "Appearance",
                                 "Sets the style of coloring."));

            items.Add(new DesignerActionPropertyItem("LineStyle",
                                 "Line Style", "Appearance",
                                 "Sets the style of the border line."));

            items.Add(new DesignerActionPropertyItem("BorderStyle",
                                 "Border Style", "Appearance",
                                 "Sets the style of the border."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("FillColor",
                                 "Fill Color", "Appearance",
                                 "Sets which color used to fill the control."));

            items.Add(new DesignerActionPropertyItem("OutLineColor",
                                 "OutLine Color", "Appearance",
                                 "Sets the outline color."));

            items.Add(new DesignerActionPropertyItem("AlternateColor",
                                 "Alternate Color", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Gradients",
                                 "Gradients", "Appearance",
                                 "Sets the gradient color. Should match Gradient Positions."));

            items.Add(new DesignerActionPropertyItem("GradientPositions",
                                 "Gradient Positions", "Appearance",
                                 "Sets the gradient positions. Should match number of Gradient Colors."));

            items.Add(new DesignerActionPropertyItem("BorderWidth",
                                 "Border Width", "Appearance",
                                 "Sets the width of the border."));

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
