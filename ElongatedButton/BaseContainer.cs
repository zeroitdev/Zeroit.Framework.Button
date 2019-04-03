// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="BaseContainer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Zeroit.Framework.Button
{
    #region BaseContainer

    /// <summary>
    /// Summary description for BaseContainer.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.GroupBox" />
    /// <seealso cref="Zeroit.Framework.Button.IGradientContainer" />
	public abstract class BaseContainer : System.Windows.Forms.GroupBox, IGradientContainer
    {
        #region Constants
        /// <summary>
        /// The idefault borderwidth
        /// </summary>
        private const int IDEFAULT_BORDERWIDTH = 6;                                 // Default value of  BorderWidth Property
        /// <summary>
        /// The odefault sizeborderpixelindet
        /// </summary>
        private Size ODEFAULT_SIZEBORDERPIXELINDET = new Size(16, 16);              // Default value of moSizeBorderPixelIndent
        /// <summary>
        /// The odefault gradienttopcolor
        /// </summary>
        private static Color ODEFAULT_GRADIENTTOPCOLOR = Color.FromArgb(225, 225, 183);    // Default value of GradientTopColor Property
        /// <summary>
        /// The odefault gradientbottomcolor
        /// </summary>
        private static Color ODEFAULT_GRADIENTBOTTOMCOLOR = Color.FromArgb(167, 168, 127); // Default value of GradientBottomColor Property
        /// <summary>
        /// The odefault headingtextcolor
        /// </summary>
        private static Color ODEFAULT_HEADINGTEXTCOLOR = Color.FromArgb(57, 66, 1);        // Default value of HeaderTextColor Property
        /// <summary>
        /// The odefault interiortopcolor
        /// </summary>
        private static Color ODEFAULT_INTERIORTOPCOLOR = Color.FromArgb(245, 243, 219);    // Default value of InteriorGradientTopColor Property
        /// <summary>
        /// The odefault interiorbottomcolor
        /// </summary>
        private static Color ODEFAULT_INTERIORBOTTOMCOLOR = Color.FromArgb(214, 209, 153); // Default value of InteriorGradientBottomColor Property
        /// <summary>
        /// The odefault shadowcolor
        /// </summary>
        private static Color ODEFAULT_SHADOWCOLOR = Color.FromArgb(142, 143, 116);         // Default value of ShadowColor Property

        // These values are used in LinerGradientBrush's blend property to specify the Factor and Postion
        // When the values are changed the gradient is drawn differently
        /// <summary>
        /// The iarr relativeintensities
        /// </summary>
        protected Single[] IARR_RELATIVEINTENSITIES = { 0.0F, 0.32F, 1.0F };            // Values for Factor property of blend
        /// <summary>
        /// The iarr relativepositions
        /// </summary>
        protected Single[] IARR_RELATIVEPOSITIONS = { 0.0F, 0.44F, 1.0F };          // Values for Position property of blend
        #endregion

        #region Private Data Members
        // Defining the data member corresponding to different Properties and initializing default values
        /// <summary>
        /// The mi border width
        /// </summary>
        private int miBorderWidth = IDEFAULT_BORDERWIDTH;                           // BorderWidth Property 
        /// <summary>
        /// The mo gradient top color
        /// </summary>
        private Color moGradientTopColor = ODEFAULT_GRADIENTTOPCOLOR;               // GradientTopColor Property 
        /// <summary>
        /// The mo gradient bottom color
        /// </summary>
        private Color moGradientBottomColor = ODEFAULT_GRADIENTBOTTOMCOLOR;         // GradientBottomColor Property
        /// <summary>
        /// The mo heading text color
        /// </summary>
        private Color moHeadingTextColor = ODEFAULT_HEADINGTEXTCOLOR;               // HeaderTextColor Property
        /// <summary>
        /// The mo interior top color
        /// </summary>
        private Color moInteriorTopColor = ODEFAULT_INTERIORTOPCOLOR;               // InteriorTopColor Property
        /// <summary>
        /// The mo interior bottom color
        /// </summary>
        private Color moInteriorBottomColor = ODEFAULT_INTERIORBOTTOMCOLOR;         // InteriorBottomColor Property
        /// <summary>
        /// The mo shadow color
        /// </summary>
        private Color moShadowColor = ODEFAULT_SHADOWCOLOR;                         // ShadowColor Property
        #endregion

        #region Protected Members
        /// <summary>
        /// The mosize border pixel indent
        /// </summary>
        protected Size mosizeBorderPixelIndent;   // Size of the radius of the curves at the corners
        /// <summary>
        /// The mo text size
        /// </summary>
        protected SizeF moTextSize;               // Size(In Floating Point) of the text in pixels based on the font

        // This property defines the border within which the whole control is to be drawn.
        /// <summary>
        /// Gets the border rectangle.
        /// </summary>
        /// <value>The border rectangle.</value>
        protected Rectangle BorderRectangle
        {
            get
            {
                Rectangle rc = this.ClientRectangle;    // We reduce the size of drawing to show everything properly.
                return new Rectangle(1, 1, rc.Width - 3, rc.Height - 3);
            }

        }

        // This property defines the color of shadow of the control
        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        public Color ShadowColor
        {
            get
            {
                return moShadowColor;
            }
            set
            {
                moShadowColor = value;
                this.Invalidate();

            }
        }

        // This property defines the color of the header text
        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        public Color FontColor
        {
            get
            {
                return moHeadingTextColor;
            }
            set
            {
                moHeadingTextColor = value;
            }
        }

        // This property defines the Top Color of the BorderGradient
        /// <summary>
        /// Gets or sets the color of the border top.
        /// </summary>
        /// <value>The color of the border top.</value>
        Color IGradientBorderColor.BorderTopColor
        {
            get
            {
                return moGradientTopColor;
            }
            set
            {
                moGradientTopColor = value;
            }
        }

        // This property defines the Bottom Color of the BorderGradient
        /// <summary>
        /// Gets or sets the color of the border bottom.
        /// </summary>
        /// <value>The color of the border bottom.</value>
        Color IGradientBorderColor.BorderBottomColor
        {
            get
            {
                return moGradientBottomColor;
            }
            set
            {
                moGradientBottomColor = value;
            }
        }

        // This property defines the Top Color of the Background Gradient
        /// <summary>
        /// Gets or sets the color of the background top.
        /// </summary>
        /// <value>The color of the background top.</value>
        Color IGradientBackgroundColor.BackgroundTopColor
        {
            get
            {
                return moInteriorTopColor;
            }
            set
            {
                moInteriorTopColor = value;
            }
        }

        // This property defines the Bottom Color of the Background Gradient
        /// <summary>
        /// Gets or sets the color of the background bottom.
        /// </summary>
        /// <value>The color of the background bottom.</value>
        Color IGradientBackgroundColor.BackgroundBottomColor
        {
            get
            {
                return moInteriorBottomColor;
            }
            set
            {
                moInteriorBottomColor = value;
            }
        }
        #endregion

        #region Public Property

        // The colorscheme property which is to be implemented by the Child Classes
        /// <summary>
        /// Gets or sets the zeroit group button color scheme.
        /// </summary>
        /// <value>The zeroit group button color scheme.</value>
        public abstract EnmColorScheme ZeroitGroupButtonColorScheme { get; set; }

        // The BorderWidth Values are accessed and intialised using this property
        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get
            {
                return miBorderWidth;
            }
            set
            {
                miBorderWidth = value;
                this.Invalidate();
            }
        }
        #endregion

        #region Overridable Properties

        // This property is being used in the OnPaint Method to paint the border
        /// <summary>
        /// Gets the interior region path brush.
        /// </summary>
        /// <value>The interior region path brush.</value>
        protected virtual Brush InteriorRegionPathBrush
        {
            get
            {
                // Brush of LinearGradient type is created to draw gradient
                System.Drawing.Drawing2D.LinearGradientBrush brush =
                    new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle,
                    moGradientTopColor,
                    moGradientBottomColor,
                    LinearGradientMode.Vertical);
                // Blend is used to define the blending method for the gradient
                Blend blend = new Blend();
                blend.Factors = IARR_RELATIVEINTENSITIES;
                blend.Positions = IARR_RELATIVEPOSITIONS;
                brush.Blend = blend;
                return brush;
            }
        }
        // This Property is used in the OnPaint Method to define the region property of the control
        /// <summary>
        /// Gets the exterior region path.
        /// </summary>
        /// <value>The exterior region path.</value>
        protected virtual GraphicsPath ExteriorRegionPath
        {
            get
            {
                Rectangle oRectangle = new Rectangle(this.BorderRectangle.X, this.BorderRectangle.Y, this.BorderRectangle.Width + 3, this.BorderRectangle.Height + 3);
                Size oSize = new Size(mosizeBorderPixelIndent.Width + 2, mosizeBorderPixelIndent.Height + 2);
                return this.GetRoundedRectanglarPath(oRectangle, oSize);
            }
        }

        // This property is Used in the OnPaint Method to define path to draw the control
        /// <summary>
        /// Gets the interior region path.
        /// </summary>
        /// <value>The interior region path.</value>
        protected virtual GraphicsPath InteriorRegionPath
        {
            get
            {
                Rectangle oRectangle = new Rectangle(this.BorderRectangle.X + 1, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 2, this.BorderRectangle.Height - 2);
                Size oSize = new Size(mosizeBorderPixelIndent.Width - 2, mosizeBorderPixelIndent.Height - 2);
                return this.GetRoundedRectanglarPath(oRectangle, oSize);
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseContainer"/> class.
        /// </summary>
        public BaseContainer() : base()
        {
            // This method is to specify to the OS that this control has its own OnPaint Method and 
            // to use it. The double buffering is used so that the control does not flicker when the 
            // Invalidate method is called.
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            mosizeBorderPixelIndent = ODEFAULT_SIZEBORDERPIXELINDET;
        }

        #region Overridable Methods
        // This procedure draws the Shadows for the outer Borders and gets called from OnPaint Method
        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="aoGraphics">The ao graphics.</param>
        /// <param name="aoRectangle">The ao rectangle.</param>
        protected virtual void DrawBorder(Graphics aoGraphics, Rectangle aoRectangle)
        {
            Pen oPen;
            Size oSize = new Size(mosizeBorderPixelIndent.Width, mosizeBorderPixelIndent.Height);
            Rectangle oRectangle = new Rectangle(aoRectangle.X, aoRectangle.Y, aoRectangle.Width, aoRectangle.Height);
            SizeF szText = aoGraphics.MeasureString(this.Text, this.Font);

            // We are looping 3 times for a 3 pixel wide shadow.
            for (int i = 0; i < 3; i++)
            {
                // Creates a pen to draw Lines and Arcs Dark To Light
                oPen = new Pen(Color.FromArgb((2 - i + 1) * 64, moShadowColor));

                // Draws a shadow arc for the Top Right corner
                aoGraphics.DrawArc(oPen, oRectangle.Right - oSize.Width,
                    oRectangle.Top + 2, oSize.Width,
                    oSize.Height, 270, 90);

                // Draws a vertical shadow line for the right side
                aoGraphics.DrawLine(oPen, oRectangle.Right, oRectangle.Top + (Single)(oSize.Height / 2),
                    oRectangle.Right, oRectangle.Bottom - (Single)(oSize.Height / 2));

                // Draws a shadow arc for bottom right corner
                aoGraphics.DrawArc(oPen, oRectangle.Right - oSize.Width,
                    oRectangle.Bottom - oSize.Height,
                    oSize.Width, oSize.Height, 0, 90);
                // Draws a horizontal shadow line for the bottom
                aoGraphics.DrawLine(oPen, oRectangle.Right - (Single)(oSize.Width / 2),
                    oRectangle.Bottom, oRectangle.Left + (Single)(oSize.Width / 2),
                    oRectangle.Bottom);

                // Creates a pen to draw lines and arcs Light to Dark
                oPen = new Pen(Color.FromArgb((2 - i) * 127, moShadowColor));

                // Draw a shadow arc for the bottom left corner
                aoGraphics.DrawArc(oPen, oRectangle.Left + 2, oRectangle.Bottom - oSize.Height,
                    oSize.Width, oSize.Height, 90, 90);

                // Increasing the Rectangles X and Y position
                oRectangle.X += 1;
                oRectangle.Y += 1;

                // Reducing Height and width of the rectangle
                oRectangle.Width -= 2;
                oRectangle.Height -= 2;

                // Reducing the radius size of the arcs to draw the arcs properly
                oSize.Height -= 2;
                oSize.Width -= 2;
            }
        }

        // This Method is called from OnPaint Method to draw the Interior Part
        /// <summary>
        /// Draws the interior.
        /// </summary>
        /// <param name="aoGraphics">The ao graphics.</param>
        protected virtual void DrawInterior(Graphics aoGraphics)
        {
            // Create rectangle to draw interior
            Rectangle oRcInterior = new Rectangle(this.BorderRectangle.X + miBorderWidth + 1, this.BorderRectangle.Y + 12 + miBorderWidth, this.BorderRectangle.Width - (miBorderWidth * 2), this.BorderRectangle.Height - (12 + miBorderWidth * 2));

            SolidBrush oSolidBrush;
            for (int Index = 1; Index >= 0; Index--)
            {
                // Define Shadow Brushes Dark to Light
                oSolidBrush = new SolidBrush(Color.FromArgb(127 * (2 - Index), moShadowColor));
                Pen oPen = new Pen(oSolidBrush);

                // Draws vertical line on Left side
                aoGraphics.DrawLine(oPen, oRcInterior.X, oRcInterior.Y, oRcInterior.X, oRcInterior.Bottom);

                // Draws horizontal lines on the top
                aoGraphics.DrawLine(oPen, oRcInterior.X, oRcInterior.Y, oRcInterior.Right, oRcInterior.Y);

                // Increasing the X and Y postion of the rectangle
                oRcInterior.X += 1;
                oRcInterior.Y += 1;

                // Reducing the height and width of the rectangle
                oRcInterior.Width -= 2;
                oRcInterior.Height -= 2;
            }

            // Brush of LinearGradient type is created to draw gradient
            LinearGradientBrush oLinearGradient = new LinearGradientBrush(oRcInterior,
                moInteriorTopColor,
                moInteriorBottomColor,
                LinearGradientMode.Vertical);

            // Blend is used to define the blend of the gradient
            Blend oBlend = new Blend();
            oBlend.Factors = IARR_RELATIVEINTENSITIES;
            oBlend.Positions = IARR_RELATIVEPOSITIONS;
            oLinearGradient.Blend = oBlend;

            // Fill the rectangle using Gradient Brush created above
            aoGraphics.FillRectangle(oLinearGradient, oRcInterior);
        }
        #endregion

        #region Private methods
        // This function is used to get Rectangular GraphicsPath with Rounded Corner
        /// <summary>
        /// Gets the rounded rectanglar path.
        /// </summary>
        /// <param name="aoRectangle">The ao rectangle.</param>
        /// <param name="aoSize">Size of the ao.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath GetRoundedRectanglarPath(Rectangle aoRectangle, Size aoSize)
        {
            GraphicsPath oExteriorGraphicPath = new GraphicsPath();

            // Add top horizontal line to the Graphics Path Object
            oExteriorGraphicPath.AddLine(aoRectangle.Left + (Single)(aoSize.Height / 2), aoRectangle.Top, aoRectangle.Right - (Single)(aoSize.Height / 2), aoRectangle.Top);

            // Add arc for the top right corner curve to the Graphics Path object
            oExteriorGraphicPath.AddArc(aoRectangle.Right - aoSize.Width, aoRectangle.Top, aoSize.Width, aoSize.Height, 270, 90);

            // Add right vertical line to the Graphics Path object
            oExteriorGraphicPath.AddLine(aoRectangle.Right, aoRectangle.Top + aoSize.Height, aoRectangle.Right, aoRectangle.Bottom - (Single)(aoSize.Height / 2));

            // Add the bottom right corner curve to the Graphics object
            oExteriorGraphicPath.AddArc(aoRectangle.Right - aoSize.Width, aoRectangle.Bottom - aoSize.Height, aoSize.Width, aoSize.Height, 0, 90);

            // Add the bottom horizontal line to the Graphics Path object
            oExteriorGraphicPath.AddLine(aoRectangle.Right - (Single)(aoSize.Width / 2), aoRectangle.Bottom, aoRectangle.Left + (Single)(aoSize.Width / 2), aoRectangle.Bottom);

            // Add arc for the bottom left curve to the Graphics object
            oExteriorGraphicPath.AddArc(aoRectangle.Left, aoRectangle.Bottom - aoSize.Height, aoSize.Width, aoSize.Height, 90, 90);

            // Add left vertical line to the Graphics Path object
            oExteriorGraphicPath.AddLine(aoRectangle.Left, aoRectangle.Bottom - (Single)(aoSize.Height / 2), aoRectangle.Left, aoRectangle.Top + (Single)(aoSize.Height / 2));

            // Add arc for the top left curve to the Graphics object
            oExteriorGraphicPath.AddArc(aoRectangle.Left, aoRectangle.Top, aoSize.Width, aoSize.Height, 180, 90);
            return oExteriorGraphicPath;
        }
        #endregion

        #region Overriden Events
        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Get the size of the string in pixels for the string for a font
            this.moTextSize = e.Graphics.MeasureString(this.Text, this.Font);

            // Original Smoothing is Saved and Smoothing mode mode is change to AntiAlias
            SmoothingMode oldSmooting = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draws shadow border for the control
            DrawBorder(e.Graphics, this.BorderRectangle);

            // Fill the rectangle that represents the border with gradient
            e.Graphics.FillPath(this.InteriorRegionPathBrush, this.InteriorRegionPath);

            // Draws the gradient background with shadows
            DrawInterior(e.Graphics);

            // Defines string format to center the string 
            StringFormat oStringFormat = new StringFormat();

            // The rectangle where the text is to be drawn
            RectangleF oRectangleF =
                new RectangleF(this.BorderRectangle.X + (Single)(this.mosizeBorderPixelIndent.Width / 2) + 8,
                this.BorderRectangle.Y + 2,
                moTextSize.Width + (Single)(this.mosizeBorderPixelIndent.Width / 2),
                moTextSize.Height);

            // Drawing the string in the rectangle
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(moHeadingTextColor), oRectangleF, oStringFormat);

            // Reseting the smoothingmode back to original for OS purposes.
            e.Graphics.SmoothingMode = oldSmooting;

            // Using the graphics path property regionpath to define the non rectangular shape for the control
            this.Region = new Region(this.ExteriorRegionPath);
        }
        #endregion
    }

    #endregion
}
