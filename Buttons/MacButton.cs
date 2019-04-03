// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="MacButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region ZeroitMacButton

    #region Control
    /// <summary>
    /// <para>
    /// MACButton control for .NET is a special 3D button control, that
    /// provides your application buttons nice same as MAC buttons, Aqua buttons...
    /// with many shape styles, texture styles, color styles...
    /// Further more, you can add text, image on the button and adjust their positions
    /// as good as you want.
    /// </para>
    /// <para>
    /// To change color of button and text in states
    /// use following properties <see cref="ZeroitMacButton.ButtonColorDefault" />, <see cref="ButtonColorNormal" />,
    /// <see cref="ButtonColorHover" />, <see cref="ButtonColorDisabled" />, <see cref="TextColorDefault" />, <see cref="TextColorNormal" />,
    /// <see cref="TextColorHover" />, <see cref="TextColorDisabled" />.
    /// Or you can use <see cref="ZeroitMacButton.ButtonColorDefault" />, <see cref="ZeroitMacButton.ButtonColorNormal" />,
    /// <see cref="ZeroitMacButton.ButtonColorHover" />, <see cref="ZeroitMacButton.ButtonColorDisabled" /> for faster selection.
    /// </para>
    /// <para>
    /// You can add text and image on the button by using <see cref="Text">Text</see>,
    /// <see cref="Image">Image</see> properties, and adjust their positions exactly to
    /// the positions you want by using following properties: <see cref="TextAlign">TextAlign</see>, <see cref="TextPaddingX">TextPaddingX</see>
    /// , <see cref="TextPaddingY">TextPaddingY</see>, <see cref="ImageAlign">ImageAlign</see>, <see cref="ImagePaddingX">ImagePaddingX</see>
    /// , <see cref="ImagePaddingY">ImagePaddingY</see>.
    /// </para>
    /// <para>
    /// MACButton supports the following features:
    /// <list type="bullet"><item><c>Very nice 3D Button.</c></item><item><c>Supports MAC style button.</c></item><item><c>Many button styles with properties: ButtonShapeStyle, ButtonTextureStyle.</c></item><item><c>Any color for the button and text.</c></item><item><c>Different button colors and text colors for 4 states of the button: Normal, Default, Hover, and Disabled.</c></item><item><c>Fast selecting good color style for both button and text by using the property: ColorStyleDefault, ColorStyleDisabled, ColorStyleHover, ColorStyleNormal.</c></item><item><c>Pulsing as MAC X button style. Further more you can adjust the pulsing as you want with properties: BrightnessDefault, PulseBrightnessMax, PulseBrightnessMin, Pulse, PulseInterval.</c></item><item><c>Very better alignment and allocation for text and image with following properties: ImageAlign, ImagePaddingX, ImagePaddingY, TextAlign, TextPaddingX, TextPaddingY.</c></item><item><c>Easy to Use and Integrate in Visual Studio .NET.</c></item><item><c>100% compatible to standard button control in VS.NET.</c></item><item><c>100% managed code.</c></item><item><c>No coding RAD component.</c></item><item><c>Supports text shadow.</c></item><item><c>Supports .ico file.</c></item><item><c>Left menu popup.</c></item><item><c>Supports the AcceptButton or CancelButton</c></item><item><c>Supports Shortcut Key</c></item></list></para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    /// <remarks>In case you want to choose a specified picture as your button,
    /// you can use the <see cref="ZeroitMacButton.ECTPictureButtonEx">ECTPictureButtonEx</see> control for that purpose.
    /// This <see cref="ZeroitMacButton.ECTPictureButtonEx">ECTPictureButtonEx</see> control has <see cref="ECTPictureButtonEx.ButtonPicture">ButtonPicture</see>
    /// property to select customized picture as button.</remarks>
	[Description("Extended MAC Button Control")]
    [ToolboxBitmap(typeof(ZeroitMacButton), "MACButton.bmp")]
    [Designer(typeof(ZeroitMacButtonDesigner))]
    [DefaultProperty("ButtonColorNormal")]
    [DefaultEvent("Click")]
    public class ZeroitMacButton : System.Windows.Forms.Control
    {
        //===============================================================
        #region Class Constants
        //Default Button Color
        /// <summary>
        /// The button color origin
        /// </summary>
        internal static Color buttonColorOrigin = Color.FromArgb(90, 162, 214);

        #endregion

        #region Static Member Variables

        /// <summary>
        /// The string format
        /// </summary>
        internal static StringFormat stringFormat = null;

        #endregion

        //===============================================================
        #region Member Variables

        //Button Colors on States
        /// <summary>
        /// The button color disabled
        /// </summary>
        private Color buttonColorDisabled = Color.FromArgb(132, 130, 132);
        /// <summary>
        /// The button color hover
        /// </summary>
        private Color buttonColorHover = Color.FromArgb(59, 122, 87);
        /// <summary>
        /// The button color normal
        /// </summary>
        private Color buttonColorNormal = buttonColorOrigin;
        /// <summary>
        /// The button color default
        /// </summary>
        private Color buttonColorDefault = buttonColorOrigin;

        /// <summary>
        /// The text color disabled
        /// </summary>
        private Color textColorDisabled = Color.Black;
        /// <summary>
        /// The text color hover
        /// </summary>
        private Color textColorHover = Color.White;
        /// <summary>
        /// The text color normal
        /// </summary>
        private Color textColorNormal = Color.Black;
        /// <summary>
        /// The text color default
        /// </summary>
        private Color textColorDefault = Color.Black;

        // If your source bitmaps have shadows, set this 
        // to the shadow size so DrawText can position the 
        // label appears centered on the label
        /// <summary>
        /// The button shadow offset
        /// </summary>
        private int buttonShadowOffset = 7;

        //Text Variables
        /// <summary>
        /// The text shadow offset
        /// </summary>
        private int textShadowOffset = 0;

        //Content Padding
        /// <summary>
        /// The image padding x
        /// </summary>
        private int imagePaddingX = 14;
        /// <summary>
        /// The image padding y
        /// </summary>
        private int imagePaddingY = 5;
        /// <summary>
        /// The text padding x
        /// </summary>
        private int textPaddingX = 2;
        /// <summary>
        /// The text padding y
        /// </summary>
        private int textPaddingY = 5;

        //For Sizing Button
        /// <summary>
        /// The size to label
        /// </summary>
        private bool sizeToLabel = false;

        //------------------------------------------------------------------
        // Mouse tracking
        /// <summary>
        /// The mouse pressed
        /// </summary>
        private bool mousePressed;
        /// <summary>
        /// The bl entered
        /// </summary>
        private bool blEntered;
        /// <summary>
        /// The pt mouse position
        /// </summary>
        private Point ptMousePosition = new Point(0, 0);

        // Images used to draw the button
        /// <summary>
        /// The button picture
        /// </summary>
        private Bitmap buttonPicture;

        // Rectangle that really contains the button image without shadow
        /// <summary>
        /// The button rect
        /// </summary>
        private Rectangle buttonRect;

        // Matrices for transparency transformation
        /// <summary>
        /// The ia default
        /// </summary>
        private ImageAttributes iaDefault, iaNormal, iaHover, iaDisabled;
        /// <summary>
        /// The cm default
        /// </summary>
        private ColorMatrix cmDefault, cmNormal, cmHover, cmDisabled;

        // Text properties
        /// <summary>
        /// The text align
        /// </summary>
        private System.Drawing.ContentAlignment textAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // Image properties
        /// <summary>
        /// The image align
        /// </summary>
        private System.Drawing.ContentAlignment imageAlign = System.Drawing.ContentAlignment.MiddleLeft;

        #endregion

        //===============================================================
        #region Constructors and Initializers

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMacButton" /> class.
        /// </summary>
        public ZeroitMacButton()
        {

            // Prevent drawing flicker by blitting from memory in WM_PAINT
            SetStyle(ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.Selectable |
                ControlStyles.ResizeRedraw, true);

            // Prevent base class from trying to generate double click events and
            // so testing clicks against the double click time and rectangle. Getting
            // rid of this allows the user to press then button very quickly.
            SetStyle(ControlStyles.StandardDoubleClick, false);

            LoadButtonImage();

            InitializeGraphics();

            this.BackColor = Color.Transparent;
            this.Font = new Font("Verdana Ref", 9, FontStyle.Bold);

            if (stringFormat == null)
            {
                stringFormat = new StringFormat();
                stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                stringFormat.HotkeyPrefix = HotkeyPrefix.Show;
            }

            IncludeInConstructor();
        }

        #endregion

        //===============================================================
        #region Properties

        //---------------------------------------------------------------
        //Button Color
        //---------------------------------------------------------------
        /// <summary>
        /// The Button Color that is used on the <b>Disabled</b> state of the button.
        /// You can select any <see cref="Color" /> you want for this state.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the color of the button when it's in <b>Disabled</b> state.</value>
        /// <remarks><b>Note</b>: When you want to set the button color by ButtonColorDisabled property,
        /// and set the text color by <see cref="TextColorDisabled" /> property, you must set the <see cref="ColorStyleDisabled" />
        /// to 'UserDefinedf value. If you set ColorStyleDisabled to another value, that will overrides
        /// this property's value.</remarks>
        [Description("The Button Color that is used on the Disabled state of the button.")]
        [Category("Appearance Color")]
        public Color ButtonColorDisabled
        {
            get { return buttonColorDisabled; }
            set
            {
                buttonColorDisabled = value;
                if (iaDisabled != null)
                {
                    cmDisabled = GetTranslationColorMatrix(buttonColorOrigin, buttonColorDisabled);
                    iaDisabled.SetColorMatrix(cmDisabled, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// The Button Color that is used on the <b>Hover</b> state of the button.
        /// You can select any <see cref="Color" /> you want for this state.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the color of the button when it's in <b>Hover</b> state.</value>
        /// <remarks><b>Note</b>: When you want to set the button color by ButtonColorHover property,
        /// and set the text color by <see cref="TextColorHover" /> property, you must set the <see cref="ColorStyleHover" />
        /// to 'UserDefinedf value. If you set ColorStyleHover to another value, that will overrides
        /// this property's value.</remarks>
        [Description("The Button Color is used on the Hovered state of the button.")]
        [Category("Appearance Color")]
        public Color ButtonColorHover
        {
            get { return buttonColorHover; }
            set
            {
                buttonColorHover = value;
                if (iaHover != null)
                {
                    cmHover = GetTranslationColorMatrix(buttonColorOrigin, buttonColorHover);
                    iaHover.SetColorMatrix(cmHover, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// The Button Color that is used on the <b>Normal</b> state of the button.
        /// You can select any <see cref="Color" /> you want for this state.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the color of the button when it's in <b>Normal</b> state.</value>
        /// <remarks><b>Note</b>: When you want to set the button color by ButtonColorNormal property,
        /// and set the text color by <see cref="TextColorNormal" /> property, you must set the <see cref="ColorStyleNormal" />
        /// to 'UserDefinedf value. If you set ColorStyleNormal to another value, that will overrides
        /// this property's value.</remarks>
        [Description("This Button Color is used on the Normal state of the button.")]
        [Category("Appearance Color")]
        public Color ButtonColorNormal
        {
            get { return buttonColorNormal; }
            set
            {
                buttonColorNormal = value;
                if (iaNormal != null)
                {
                    cmNormal = GetTranslationColorMatrix(buttonColorOrigin, buttonColorNormal);
                    iaNormal.SetColorMatrix(cmNormal, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                }
                this.Invalidate();
            }
        }

        /// <summary>
        /// The Button Color that is used on the <b>Default</b> state of the button.
        /// You can select any <see cref="Color" /> you want for this state.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the color of the button when it's in <b>Default</b> state.</value>
        /// <remarks><b>Note</b>: When you want to set the button color by ButtonColorDefault property,
        /// and set the text color by <see cref="TextColorDefault" /> property, you must set the <see cref="ColorStyleDefault" />
        /// to 'UserDefinedf value. If you set ColorStyleDefault to another value, that will overrides
        /// this property's value.</remarks>
        [Description("This Button Color is used on the Default state of the button.")]
        [Category("Appearance Color")]
        public Color ButtonColorDefault
        {
            get { return buttonColorDefault; }
            set
            {
                buttonColorDefault = value;
                if (iaDefault != null)
                {
                    cmDefault = GetTranslationColorMatrix(buttonColorOrigin, buttonColorDefault);
                    iaDefault.SetColorMatrix(cmDefault, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                }

                this.Invalidate();
            }
        }

        //---------------------------------------------------------------
        //Text Color
        //---------------------------------------------------------------
        /// <summary>
        /// This property determines the Text Color that is used on the Disabled state of the button.
        /// You can select any <see cref="Color" /> you want for this state.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the color of the <see cref="Text" /> when it's in <b>Disabled</b> state.</value>
        /// <remarks><b>Note</b>: When you want to set the button color by ButtonColorDisabled property,
        /// and set the text color by <see cref="TextColorDisabled" /> property, you must set the <see cref="ColorStyleDisabled" />
        /// to 'UserDefinedf value. If you set ColorStyleDisabled to another value, that will overrides
        /// this property's value.</remarks>
        [Description("This property determines the Text Color that is used on the Disabled state of the button.")]
        [Category("Appearance Color")]
        public Color TextColorDisabled
        {
            get { return textColorDisabled; }
            set
            {
                textColorDisabled = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This property determines the Text Color that is used on the Hover state of the button.
        /// You can select any <see cref="Color" /> you want for this state.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the color of the <see cref="Text" /> when it's in <b>Hover</b> state.</value>
        /// <remarks><b>Note</b>: When you want to set the button color by ButtonColorHover property,
        /// and set the text color by <see cref="TextColorHover" /> property, you must set the <see cref="ColorStyleHover" />
        /// to 'UserDefinedf value. If you set ColorStyleHover to another value, that will overrides
        /// this property's value.</remarks>
        [Description("This property determines the Text Color that is used on the Hover state of the button.")]
        [Category("Appearance Color")]
        public Color TextColorHover
        {
            get { return textColorHover; }
            set
            {
                textColorHover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This property determines the Text Color that is used on the Normal state of the button.
        /// You can select any <see cref="Color" /> you want for this state.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the color of the <see cref="Text" /> when it's in <b>Normal</b> state.</value>
        /// <remarks><b>Note</b>: When you want to set the button color by ButtonColorNormal property,
        /// and set the text color by <see cref="TextColorNormal" /> property, you must set the <see cref="ColorStyleNormal" />
        /// to 'UserDefinedf value. If you set ColorStyleNormal to another value, that will overrides
        /// this property's value.</remarks>
        [Description("This property determines the Text Color that is used on the Normal state of the button.")]
        [Category("Appearance Color")]
        public Color TextColorNormal
        {
            get { return textColorNormal; }
            set
            {
                textColorNormal = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// This property determines the Text Color that is used on the Default state of the button.
        /// You can select any <see cref="Color" /> you want for this state.
        /// </summary>
        /// <value>A <see cref="Color" /> that represents the color of the <see cref="Text" /> when it's in <b>Default</b> state.</value>
        /// <remarks><b>Note</b>: When you want to set the button color by ButtonColorDefault property,
        /// and set the text color by <see cref="TextColorDefault" /> property, you must set the <see cref="ColorStyleDefault" />
        /// to 'UserDefinedf value. If you set ColorStyleDefault to another value, that will overrides
        /// this property's value.</remarks>
        [Description("This property determines the Text Color that is used on the Default state of the button.")]
        [Category("Appearance Color")]
        public Color TextColorDefault
        {
            get { return textColorDefault; }
            set
            {
                textColorDefault = value;
                this.Invalidate();
            }
        }

        //---------------------------------------------------------------

        /// <summary>
        /// Gets or sets the value that determines shadow offset of the <see cref="Text" /> within button.
        /// </summary>
        /// <value>The shadow offset of the <see cref="Text" /> within button in pixels. The default value is 0.</value>
        /// <remarks>The <see cref="Text" /> hasnt' shadow if this property is set to 0.</remarks>
        [Description("This property determines shadow offset of the text within button.")]
        [Category("Appearance Text")]
        [DefaultValue(0)]
        public int TextShadowOffset
        {
            get { return textShadowOffset; }
            set
            {
                textShadowOffset = value;
                this.Invalidate();
            }
        }

        //---------------------------------------------------------------
        /// <summary>
        /// Gets or sets the value that determines Image Padding in the X-axis.
        /// </summary>
        /// <value>This property determines Image Padding in X-axis. The default value is 14.</value>
        /// <remarks><para>
        /// Please note that MACButton supports very better alignment and allocation for text and image with following properties:
        /// <see cref="ImageAlign" />, <see cref="ImagePaddingX" />, <see cref="ImagePaddingY" />, <see cref="TextAlign" />,
        /// <see cref="TextPaddingX" />, <see cref="TextPaddingY" />.
        /// </para>
        /// <para>
        /// Please read the section eAlignment of Text and Image on Buttonffor detail.
        /// </para></remarks>
        [Browsable(true)]
        [Category("Appearance Child Image")]
        [Description("Gets or sets the value that determines Image Padding in the X-axis. Please note that this MACButton supports very better alignment and allocation for text and image with following properties: ImageAlign, ImagePaddingX, ImagePaddingY, TextAlign, TextPaddingX, TextPaddingY.")]
        [DefaultValue(14)]
        public int ImagePaddingX
        {
            get { return imagePaddingX; }
            set
            {
                if (imagePaddingX != value)
                {
                    imagePaddingX = value;
                    this.Invalidate();
                }
            }
        }

        //---------------------------------------------------------------

        /// <summary>
        /// Gets or sets the value that determines Image Padding in the Y-axis.
        /// </summary>
        /// <value>This property determines Image Padding in Y-axis. The default value is 5.</value>
        /// <remarks><para>
        /// Please note that MACButton supports very better alignment and allocation for text and image with following properties:
        /// <see cref="ImageAlign" />, <see cref="ImagePaddingX" />, <see cref="ImagePaddingY" />, <see cref="TextAlign" />,
        /// <see cref="TextPaddingX" />, <see cref="TextPaddingY" />.
        /// </para>
        /// <para>
        /// Please read the section eAlignment of Text and Image on Buttonffor detail.
        /// </para></remarks>
        [Browsable(true)]
        [Category("Appearance Child Image")]
        [Description("Gets or sets the value that determines Image Padding in Y-axis. Please note that this MACButton supports very better alignment and allocation for text and image with following properties: ImageAlign, ImagePaddingX, ImagePaddingY, TextAlign, TextPaddingX, TextPaddingY.")]
        [DefaultValue(5)]
        public int ImagePaddingY
        {
            get { return imagePaddingY; }
            set
            {
                if (imagePaddingY != value)
                {
                    imagePaddingY = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the value that determines Text Padding in the X-axis.
        /// </summary>
        /// <value>This property determines Text Padding in X-axis. The default value is 2.</value>
        /// <remarks><para>
        /// Please note that MACButton supports very better alignment and allocation for text and image with following properties:
        /// <see cref="ImageAlign" />, <see cref="ImagePaddingX" />, <see cref="ImagePaddingY" />, <see cref="TextAlign" />,
        /// <see cref="TextPaddingX" />, <see cref="TextPaddingY" />.
        /// </para>
        /// <para>
        /// Please read the section eAlignment of Text and Image on Buttonffor detail.
        /// </para></remarks>
        [Browsable(true)]
        [CategoryAttribute("Appearance Text")]
        [Description("Gets or sets the value that determines Text Padding in X-axis. Please note that this MACButton supports very better alignment and allocation for text and image with following properties: ImageAlign, ImagePaddingX, ImagePaddingY, TextAlign, TextPaddingX, TextPaddingY.")]
        [DefaultValue(2)]
        public int TextPaddingX
        {
            get { return textPaddingX; }
            set
            {
                if (textPaddingX != value)
                {
                    textPaddingX = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the value that determines Text Padding in the Y-axis.
        /// </summary>
        /// <value>This property determines Text Padding in Y-axis. The default value is 5.</value>
        /// <remarks><para>
        /// Please note that MACButton supports very better alignment and allocation for text and image with following properties:
        /// <see cref="ImageAlign" />, <see cref="ImagePaddingX" />, <see cref="ImagePaddingY" />, <see cref="TextAlign" />,
        /// <see cref="TextPaddingX" />, <see cref="TextPaddingY" />.
        /// </para>
        /// <para>
        /// Please read the section eAlignment of Text and Image on Buttonffor detail.
        /// </para></remarks>
        [Browsable(true)]
        [CategoryAttribute("Appearance Text")]
        [Description("Gets or sets the value that determines Text Padding in Y-axis. Please note that this MACButton supports very better alignment and allocation for text and image with following properties: ImageAlign, ImagePaddingX, ImagePaddingY, TextAlign, TextPaddingX, TextPaddingY.")]
        [DefaultValue(5)]
        public int TextPaddingY
        {
            get { return textPaddingY; }
            set
            {
                if (textPaddingY != value)
                {
                    textPaddingY = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text caption displayed in the button control.
        /// </summary>
        /// <value>The text caption displayed in the button control. The default value is <see cref="String.Empty" />.</value>
        /// <remarks>Use the Text property to specify or determine the caption to display in the button control.</remarks>
        [Description("Gets or sets the text displayed in control.")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [CategoryAttribute("Appearance Text")]
        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the alignment of the text on the button control.
        /// </summary>
        /// <value>One of the <see cref="ContentAlignment" /> values. The default is MiddleCenter.</value>
        /// <remarks><para>
        /// Please note that MACButton supports very better alignment and allocation for text and image with following properties:
        /// <see cref="ImageAlign" />, <see cref="ImagePaddingX" />, <see cref="ImagePaddingY" />, <see cref="TextAlign" />,
        /// <see cref="TextPaddingX" />, <see cref="TextPaddingY" />.
        /// </para>
        /// <para>
        /// Please read the section eAlignment of Text and Image on Buttonffor detail.
        /// </para></remarks>
        [Browsable(true)]
        [CategoryAttribute("Appearance Text")]
        [DefaultValue(System.Drawing.ContentAlignment.MiddleCenter)]
        [Description("Gets or sets the alignment of the text on the button control.")]
        public System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return textAlign;
            }
            set
            {
                if (textAlign != value)
                {
                    textAlign = value;
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The <see cref="Font" /> object to apply to the text displayed by the control. The default is the value of the <see cref="Control.DefaultFont" /> property.</value>
        /// <remarks><para>
        /// The <see cref="Font" /> property is an ambient property.
        /// An ambient property is a control property that,
        /// if not set, is retrieved from the parent control. For example, a <see cref="Button" /> will have the same <see cref="Control.BackColor" /> as its parent <see cref="Form" /> by default.
        /// For more information about ambient properties, see the <see cref="AmbientProperties" /> class or the <see cref="Control" /> class overview.
        /// </para>
        /// <para>
        /// Because the <see cref="Font" /> object is immutable (meaning that you cannot adjust any of it's
        /// properties), you can only assign the <see cref="Font" /> property a new <see cref="Font" /> object.
        /// However, you can base the new font on the existing font.
        /// </para></remarks>
        [CategoryAttribute("Appearance Text")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
            }
        }


        //End=====================Pulsing Properties============================================

        /// <summary>
        /// This property determines whether the button should automatically size to fit the Text within it.
        /// </summary>
        /// <value>The default value is false.</value>
        /// <remarks>In case this property is set to true,
        /// whenver you change <see cref="Text" />, the button's size is recalculated to fit with the text.</remarks>
        [Description("This property determines whether the button should automatically size to fit the Text within it. The default value is False.")]
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool SizeToLabel
        {
            get { return sizeToLabel; }
            set
            {
                sizeToLabel = value;
                ResizeButton();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines shadow offset of the button.
        /// </summary>
        /// <value>This property determines shadow offset of the button. You can use this property to adjust vertical position of text on the button. The default value is 7.</value>
        /// <remarks><para>
        /// Please note that MACButton supports very better alignment and allocation for text and image with following properties:
        /// <see cref="ImageAlign" />, <see cref="ImagePaddingX" />, <see cref="ImagePaddingY" />, <see cref="TextAlign" />,
        /// <see cref="TextPaddingX" />, <see cref="TextPaddingY" />.
        /// </para>
        /// <para>
        /// Please read the section eAlignment of Text and Image on Buttonffor detail.
        /// </para></remarks>
        [Description("This property determines shadow offset of the button. You can use this property to adjust vertical position of text on the button. The default value is 7.")]
        [Category("Appearance")]
        [Browsable(true)]
        [DefaultValue(7)]
        public int ButtonShadowOffset
        {
            get { return buttonShadowOffset; }
            set { buttonShadowOffset = value; this.Invalidate(); }
        }

        #endregion

        //===============================================================
        #region Property overrides

        /// <summary>
        /// Gets or sets the alignment of the image on the button control.
        /// </summary>
        /// <value>One of the <see cref="ContentAlignment" /> values. The default is MiddleCenter.</value>
        /// <remarks><para>
        /// Please note that MACButton supports very better alignment and allocation for text and image with following properties:
        /// <see cref="ImageAlign" />, <see cref="ImagePaddingX" />, <see cref="ImagePaddingY" />, <see cref="TextAlign" />,
        /// <see cref="TextPaddingX" />, <see cref="TextPaddingY" />.
        /// </para>
        /// <para>
        /// Please read the section eAlignment of Text and Image on Buttonffor detail.
        /// </para></remarks>
        [Description("Gets or sets the alignment of the image on the button. Its value is one of the ContentAlignment values. The default value is MiddleLeft.")]
        [Category("Appearance Child Image")]
        [Browsable(true)]
        [DefaultValue(System.Drawing.ContentAlignment.MiddleLeft)]
        public System.Drawing.ContentAlignment ImageAlign
        {
            get { return imageAlign; }
            set
            {
                if (imageAlign != value)
                {
                    imageAlign = value;
                    this.Invalidate();
                }

            }
        }


        #endregion

        //===============================================================
        #region Method overrides

        /// <summary>
        /// This member overrides <see cref="Control.OnSizeChanged">Control.OnSizeChanged</see>.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeButton();
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnTextChanged">Control.OnTextChanged</see>.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            ResizeButton();
            base.OnTextChanged(e);
        }

        /// <summary>
        /// Resizes the button.
        /// </summary>
        private void ResizeButton()
        {
            if (sizeToLabel)
            {
                Graphics g = this.CreateGraphics();
                SizeF sizeF = g.MeasureString(Text, Font);
                Width = (int)sizeF.Width + 12 * textPaddingX;
                Height = (int)sizeF.Height + 4 * textPaddingY;
                g.Dispose();
                Invalidate();
            }
        }


        /// <summary>
        /// This member overrides <see cref="Control.OnPaint">Control.OnPaint</see>.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            Graphics g = e.Graphics;

            CalculateButtonRect();
            DrawButton(g);
            DrawText(g);
        }


        /// <summary>
        /// This member overrides <see cref="Control.OnMouseDown">Control.OnMouseDown</see>.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                mousePressed = true;

                ptMousePosition.X = e.X;
                ptMousePosition.Y = e.Y;

            }

            ClickOnMouseDown(e);

            this.Invalidate();
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnMouseMove">Control.OnMouseMove</see>.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Buttons receives MouseMove events when the
            // mouse enters or leaves the client area.

            base.OnMouseMove(e);

            if (mousePressed && (e.Button & MouseButtons.Left) != 0)
            {
                ptMousePosition.X = e.X;
                ptMousePosition.Y = e.Y;
            }
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnMouseLeave">Control.OnMouseLeave</see>.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            // Buttons receives MouseMove events when the
            // mouse enters or leaves the client area.
            base.OnMouseLeave(e);

            blEntered = false;
            Invalidate();
            //Update(); //By NghiaNT 06June2006 - Performance Review
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnMouseEnter">Control.OnMouseEnter</see>.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            // Buttons receives MouseMove events when the
            // mouse enters or leaves the client area.
            base.OnMouseEnter(e);

            blEntered = true;
            Invalidate();
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnMouseUp">Control.OnMouseUp</see>.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (mousePressed)
            {
                mousePressed = false;

                Invalidate();
            }

            ClickOnMouseUp(e);
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnKeyPress">Control.OnKeyPress</see>.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs" /> that contains the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (mousePressed && e.KeyChar == (char)Keys.Escape)
            {
                mousePressed = false;

            }
        }

        /// <summary>
        /// This member overrides <see cref="Control.Dispose">Control.Dispose</see>.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (iaDefault != null)
                    iaDefault.Dispose();
                if (iaNormal != null)
                    iaNormal.Dispose();
                if (iaDisabled != null)
                    iaDisabled.Dispose();
                if (iaHover != null)
                    iaHover.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        //===============================================================
        #region Paiting Implementation

        /// <summary>
        /// Loads the button image.
        /// </summary>
        private void LoadButtonImage()
        {
            if (buttonPicture != null)
                buttonPicture.Dispose();

            //string templateFileName = "Resources.RoundedRectangle.png";
            //buttonPicture = new Bitmap(GetType(), templateFileName);
            buttonPicture = new Bitmap(Properties.Resources.RoundedRectangle);
        }

        /// <summary>
        /// Initializes the graphics.
        /// </summary>
        private void InitializeGraphics()
        {
            //----------------------------------------
            //Disbled State
            //Image attributes used to lighten default buttons
            cmDisabled = GetTranslationColorMatrix(buttonColorOrigin, buttonColorDisabled);
            iaDisabled = new ImageAttributes();
            iaDisabled.SetColorMatrix(cmDisabled, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //----------------------------------------

            //----------------------------------------
            //Default State
            //Image attributes used to lighten default buttons
            cmDefault = GetTranslationColorMatrix(buttonColorOrigin, buttonColorDefault);
            iaDefault = new ImageAttributes();
            iaDefault.SetColorMatrix(cmDefault, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //----------------------------------------

            //----------------------------------------
            //Normal State
            //Image attributes that lighten and desaturate normal buttons
            cmNormal = GetTranslationColorMatrix(buttonColorOrigin, buttonColorNormal);
            iaNormal = new ImageAttributes();
            iaNormal.SetColorMatrix(cmNormal, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //----------------------------------------

            //----------------------------------------
            //Hover State
            //Image attributes for mouse over status
            cmHover = GetTranslationColorMatrix(buttonColorOrigin, buttonColorHover);
            iaHover = new ImageAttributes();
            iaHover.SetColorMatrix(cmHover, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //----------------------------------------

        }

        /// <summary>
        /// Calculates the button rect.
        /// </summary>
        private void CalculateButtonRect()
        {
            int scaledOffset;
            scaledOffset = buttonShadowOffset * this.Height / buttonPicture.Height;
            buttonRect = new Rectangle(0, 0, this.Width, this.Height - scaledOffset);
        }
        /// <summary>
        /// calculates the left/top edge for content.
        /// </summary>
        /// <param name="Alignment">the alignment of the content</param>
        /// <param name="rect">rectagular region to place content</param>
        /// <param name="nWidth">with of content</param>
        /// <param name="nHeight">height of content</param>
        /// <returns>returns the left/top edge to place content</returns>
        private Point Calculate_LeftEdgeTopEdge(System.Drawing.ContentAlignment Alignment, Rectangle rect, int nWidth, int nHeight)
        {
            Point pt = new Point(0, 0);
            switch (Alignment)
            {
                case System.Drawing.ContentAlignment.BottomCenter:
                    pt.X = (rect.Width - nWidth) / 2;
                    pt.Y = rect.Height - nHeight;
                    break;
                case System.Drawing.ContentAlignment.BottomLeft:
                    pt.X = 0;
                    pt.Y = rect.Height - nHeight;
                    break;
                case System.Drawing.ContentAlignment.BottomRight:
                    pt.X = rect.Width - nWidth;
                    pt.Y = rect.Height - nHeight;
                    break;
                case System.Drawing.ContentAlignment.MiddleCenter:
                    pt.X = (rect.Width - nWidth) / 2;
                    pt.Y = (rect.Height - nHeight) / 2;
                    break;
                case System.Drawing.ContentAlignment.MiddleLeft:
                    pt.X = 0;
                    pt.Y = (rect.Height - nHeight) / 2;
                    break;
                case System.Drawing.ContentAlignment.MiddleRight:
                    pt.X = rect.Width - nWidth;
                    pt.Y = (rect.Height - nHeight) / 2;
                    break;
                case System.Drawing.ContentAlignment.TopCenter:
                    pt.X = (rect.Width - nWidth) / 2;
                    pt.Y = 0;
                    break;
                case System.Drawing.ContentAlignment.TopLeft:
                    pt.X = 0;
                    pt.Y = 0;
                    break;
                case System.Drawing.ContentAlignment.TopRight:
                    pt.X = rect.Width - nWidth;
                    pt.Y = 0;
                    break;
            }
            pt.X += rect.Left;
            pt.Y += rect.Top;
            return (pt);
        }

        //==============================================================
        // Drawing Button
        //==============================================================
        /// <summary>
        /// Draws the button.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawButton(Graphics g)
        {
            if (this.Enabled == false)
            {
                DrawButtonState(g, iaDisabled);
            }
            else if (mousePressed)
            {
                if (ClientRectangle.Contains(ptMousePosition.X, ptMousePosition.Y))
                    DrawButtonState(g, iaDefault);// If Mouse Pressed then Draw Click State (not Default State)
                else
                    DrawButtonState(g, iaNormal);
            }
            else if (blEntered)
            {
                DrawButtonState(g, iaHover);
            }
            else
            {
                DrawButtonState(g, iaNormal);
            }
        }

        /// <summary>
        /// Draws the state of the button.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="ia">The ia.</param>
        private void DrawButtonState(Graphics g, ImageAttributes ia)
        {
            g.DrawImage(buttonPicture, this.ClientRectangle, 0, 0, buttonPicture.Width, buttonPicture.Height, GraphicsUnit.Pixel, ia);
        }

        //==============================================================
        // Drawing Text
        //==============================================================
        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawText(Graphics g)
        {
            string textTemp = this.Text;
            textTemp.Trim();

            if (textTemp.Length != 0)
            {
                Rectangle drawRect = GetTextDestinationRect();

                // Caculate bounding Rectangle for the text
                SizeF size = g.MeasureString(this.Text, this.Font);

                // Calculate the starting location to paint the text
                Point pt = Calculate_LeftEdgeTopEdge(this.TextAlign, drawRect, (int)size.Width, (int)size.Height);

                // Draw text at the above Point
                DrawTextByColor(g, pt, GetTextColor());
            }
        }

        /// <summary>
        /// Calculates the rectangular region used for text display.
        /// </summary>
        /// <returns>returns the rectangular region for the text display</returns>
        private Rectangle GetTextDestinationRect()
        {
            Rectangle textRect = buttonRect;
            textRect.Inflate(-this.textPaddingX, -this.textPaddingY);
            return (textRect);
        }

        /// <summary>
        /// Gets the color of the text.
        /// </summary>
        /// <returns>Color.</returns>
        private Color GetTextColor()
        {
            Color textColor;

            if (this.Enabled == false)
            {
                textColor = textColorDisabled;
            }
            else if (mousePressed)
            {
                if (ClientRectangle.Contains(ptMousePosition.X, ptMousePosition.Y))
                    textColor = textColorDefault;
                else
                    textColor = textColorNormal;
            }
            else if (blEntered)
            {
                textColor = textColorHover;
            }
            else
            {
                textColor = textColorNormal;
            }

            return textColor;
        }

        /// <summary>
        /// Draws the color of the text by.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="pt">The pt.</param>
        /// <param name="textColor">Color of the text.</param>
        private void DrawTextByColor(Graphics g, Point pt, Color textColor)
        {
            // Draw the shadow below the label
            if (textShadowOffset != 0)
            {
                Point shadowPoint = pt;
                shadowPoint.Offset(0, textShadowOffset);
                g.DrawString(this.Text, this.Font, Brushes.Gray, shadowPoint.X, shadowPoint.Y, stringFormat);
            }

            // and the label itself
            SolidBrush brushText = new SolidBrush(textColor);
            g.DrawString(this.Text, this.Font, brushText, pt.X, pt.Y, stringFormat);
            brushText.Dispose();
        }

        //==============================================================
        /// <summary>
        /// Detect if it is in Design Mode.
        /// </summary>
        /// <returns>true if is being in Design Mode; otherwize false.</returns>
        protected bool DesignModeDetected()
        {
            IDesignerHost host =
                (IDesignerHost)this.GetService(typeof(IDesignerHost));

            return (host != null);
        }

        #endregion


        /// <summary>
        /// Get ColorMatrix that transform from the origin color to a new color
        /// </summary>
        /// <param name="originColor">Color of the origin.</param>
        /// <param name="newColor">The new color.</param>
        /// <returns>ColorMatrix.</returns>
        private ColorMatrix GetTranslationColorMatrix(Color originColor, Color newColor)
        {

            // Image attributes that lighten and desaturate normal buttons
            ColorMatrix cmTrans = new ColorMatrix();

            if (newColor.Equals(originColor))
                return cmTrans;

            float fTransRed = (float)newColor.R / (float)(originColor.R + originColor.G + originColor.B);
            float fTransGreen = (float)newColor.G / (float)(originColor.R + originColor.G + originColor.B);
            float fTransBlue = (float)newColor.B / (float)(originColor.R + originColor.G + originColor.B);

            // Translate the Origin Color to New Color
            cmTrans.Matrix00 = fTransRed;
            cmTrans.Matrix10 = fTransRed;
            cmTrans.Matrix20 = fTransRed;

            cmTrans.Matrix01 = fTransGreen;
            cmTrans.Matrix11 = fTransGreen;
            cmTrans.Matrix21 = fTransGreen;

            cmTrans.Matrix02 = fTransBlue;
            cmTrans.Matrix12 = fTransBlue;
            cmTrans.Matrix22 = fTransBlue;

            return cmTrans;

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

    #region Designer Generated Code
    /// <summary>
    /// The Designer for the <see cref="MACButton" />.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
	internal class MACButtonDesigner : System.Windows.Forms.Design.ControlDesigner
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MACButtonDesigner"/> class.
        /// </summary>
        public MACButtonDesigner()
        {
        }

        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the <see cref="MACButton" />.
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            Properties.Remove("AllowDrop");
            Properties.Remove("FlatStyle");
            Properties.Remove("ForeColor");
            Properties.Remove("ImageIndex");
            Properties.Remove("ImageList");
        }
    }
    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitMacButtonDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMacButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMacButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitMacButtonSmartTagActionList(this.Component));
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
            Properties.Remove("AllowDrop");
            Properties.Remove("FlatStyle");
            Properties.Remove("ForeColor");
            Properties.Remove("ImageIndex");
            Properties.Remove("ImageList");
        }
        #endregion
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitMacButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMacButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMacButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMacButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMacButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMacButton;

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

        //===============================================================
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether [size to label].
        /// </summary>
        /// <value><c>true</c> if [size to label]; otherwise, <c>false</c>.</value>
        public bool SizeToLabel
        {
            get
            {
                return colUserControl.SizeToLabel;
            }
            set
            {
                GetPropertyByName("SizeToLabel").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button color disabled.
        /// </summary>
        /// <value>The button color disabled.</value>
        public Color ButtonColorDisabled
        {
            get
            {
                return colUserControl.ButtonColorDisabled;
            }
            set
            {
                GetPropertyByName("ButtonColorDisabled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button color hover.
        /// </summary>
        /// <value>The button color hover.</value>
        public Color ButtonColorHover
        {
            get
            {
                return colUserControl.ButtonColorHover;
            }
            set
            {
                GetPropertyByName("ButtonColorHover").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button color normal.
        /// </summary>
        /// <value>The button color normal.</value>
        public Color ButtonColorNormal
        {
            get
            {
                return colUserControl.ButtonColorNormal;
            }
            set
            {
                GetPropertyByName("ButtonColorNormal").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button color default.
        /// </summary>
        /// <value>The button color default.</value>
        public Color ButtonColorDefault
        {
            get
            {
                return colUserControl.ButtonColorDefault;
            }
            set
            {
                GetPropertyByName("ButtonColorDefault").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text color disabled.
        /// </summary>
        /// <value>The text color disabled.</value>
        public Color TextColorDisabled
        {
            get
            {
                return colUserControl.TextColorDisabled;
            }
            set
            {
                GetPropertyByName("TextColorDisabled").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text color hover.
        /// </summary>
        /// <value>The text color hover.</value>
        public Color TextColorHover
        {
            get
            {
                return colUserControl.TextColorHover;
            }
            set
            {
                GetPropertyByName("TextColorHover").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text color normal.
        /// </summary>
        /// <value>The text color normal.</value>
        public Color TextColorNormal
        {
            get
            {
                return colUserControl.TextColorNormal;
            }
            set
            {
                GetPropertyByName("TextColorNormal").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text color default.
        /// </summary>
        /// <value>The text color default.</value>
        public Color TextColorDefault
        {
            get
            {
                return colUserControl.TextColorDefault;
            }
            set
            {
                GetPropertyByName("TextColorDefault").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text shadow offset.
        /// </summary>
        /// <value>The text shadow offset.</value>
        public int TextShadowOffset
        {
            get
            {
                return colUserControl.TextShadowOffset;
            }
            set
            {
                GetPropertyByName("TextShadowOffset").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image padding x.
        /// </summary>
        /// <value>The image padding x.</value>
        public int ImagePaddingX
        {
            get
            {
                return colUserControl.ImagePaddingX;
            }
            set
            {
                GetPropertyByName("ImagePaddingX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image padding y.
        /// </summary>
        /// <value>The image padding y.</value>
        public int ImagePaddingY
        {
            get
            {
                return colUserControl.ImagePaddingY;
            }
            set
            {
                GetPropertyByName("ImagePaddingY").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text padding x.
        /// </summary>
        /// <value>The text padding x.</value>
        public int TextPaddingX
        {
            get
            {
                return colUserControl.TextPaddingX;
            }
            set
            {
                GetPropertyByName("TextPaddingX").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text padding y.
        /// </summary>
        /// <value>The text padding y.</value>
        public int TextPaddingY
        {
            get
            {
                return colUserControl.TextPaddingY;
            }
            set
            {
                GetPropertyByName("TextPaddingY").SetValue(colUserControl, value);
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
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public System.Drawing.ContentAlignment TextAlign
        {
            get
            {
                return colUserControl.TextAlign;
            }
            set
            {
                GetPropertyByName("TextAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get
            {
                return colUserControl.Font;
            }
            set
            {
                GetPropertyByName("Font").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button shadow offset.
        /// </summary>
        /// <value>The button shadow offset.</value>
        public int ButtonShadowOffset
        {
            get
            {
                return colUserControl.ButtonShadowOffset;
            }
            set
            {
                GetPropertyByName("ButtonShadowOffset").SetValue(colUserControl, value);
            }
        }

        #endregion

        //===============================================================
        #region Property overrides

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public System.Drawing.ContentAlignment ImageAlign
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

            items.Add(new DesignerActionPropertyItem("SizeToLabel",
                                 "Size To Label", "Appearance",
                                 "Sets the size to the label."));

            items.Add(new DesignerActionPropertyItem("ButtonColorDisabled",
                                 "Button Color Disabled", "Appearance",
                                 "Sets the disabled color of the button."));

            items.Add(new DesignerActionPropertyItem("ButtonColorHover",
                                 "Button Color Hover", "Appearance",
                                 "Sets the hover color of the button."));

            items.Add(new DesignerActionPropertyItem("ButtonColorNormal",
                                 "Button Color Normal", "Appearance",
                                 "Sets the normal color of the button."));

            items.Add(new DesignerActionPropertyItem("ButtonColorDefault",
                                 "Button Color Default", "Appearance",
                                 "Sets the default color of the button."));

            items.Add(new DesignerActionPropertyItem("TextColorDisabled",
                                 "Text Color Disabled", "Appearance",
                                 "Sets the disabled color of the text."));

            items.Add(new DesignerActionPropertyItem("TextColorHover",
                                 "Text Color Hover", "Appearance",
                                 "Sets the hover color of the text."));

            items.Add(new DesignerActionPropertyItem("TextColorNormal",
                                 "Text Color Normal", "Appearance",
                                 "Sets the normal color of the text."));

            items.Add(new DesignerActionPropertyItem("TextColorDefault",
                                 "Text Color Default", "Appearance",
                                 "Sets the default color of the text."));

            items.Add(new DesignerActionPropertyItem("TextShadowOffset",
                                 "Text Shadow Offset", "Appearance",
                                 "Sets the shadow offset of the text."));

            items.Add(new DesignerActionPropertyItem("ImagePaddingX",
                                 "Image Padding X", "Appearance",
                                 "Sets the image padding."));

            items.Add(new DesignerActionPropertyItem("ImagePaddingY",
                                 "Image Padding Y", "Appearance",
                                 "Sets the image padding."));

            items.Add(new DesignerActionPropertyItem("TextPaddingX",
                                 "Text Padding X", "Appearance",
                                 "Sets the text padding."));

            items.Add(new DesignerActionPropertyItem("TextPaddingY",
                                 "Text Padding Y", "Appearance",
                                 "Sets the text padding."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the text."));

            items.Add(new DesignerActionPropertyItem("TextAlign",
                                 "Text Align", "Appearance",
                                 "Sets the text alignment."));

            items.Add(new DesignerActionPropertyItem("Font",
                                 "Font", "Appearance",
                                 "Sets the font of the text."));

            items.Add(new DesignerActionPropertyItem("ButtonShadowOffset",
                                 "Button Shadow Offset", "Appearance",
                                 "Sets the shadow offset."));

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
