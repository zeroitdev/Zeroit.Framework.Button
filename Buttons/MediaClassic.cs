// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="MediaClassic.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Media Classic Button

    #region Control

    #region Public Enum
    /// <summary>
    /// Enum representing the border style for <c><see cref="ZeroitMediaClassicButton" /></c>
    /// </summary>
    public enum ZeroitBorderStyle : uint
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The thin
        /// </summary>
        Thin,
        /// <summary>
        /// The raised
        /// </summary>
        Raised
    }
    #endregion

    /// <summary>
    /// A class collection for rendering media player classic button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("MouseClick")]
    [Designer(typeof(ZeroitButtonMediaClassicDesigner))]
    public partial class ZeroitMediaClassicButton : UserControl
    {

        #region Enums
        /// <summary>
        /// Enum representing the Button Style
        /// </summary>
        public enum ButtonStyle : uint
        {
            /// <summary>
            /// The menu button
            /// </summary>
            MenuButton = 0,
            /// <summary>
            /// The media button
            /// </summary>
            MediaButton,
            /// <summary>
            /// The custom button
            /// </summary>
            CustomButton
        }

        /// <summary>
        /// Enum representing the Alignment
        /// </summary>
        public enum Alignment : uint
        {
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft = 0,
            /// <summary>
            /// The top right
            /// </summary>
            TopRight,
            /// <summary>
            /// The top center
            /// </summary>
            TopCenter,
            /// <summary>
            /// The middle left
            /// </summary>
            MiddleLeft,
            /// <summary>
            /// The middle right
            /// </summary>
            MiddleRight,
            /// <summary>
            /// The middle center
            /// </summary>
            MiddleCenter,
            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft,
            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight,
            /// <summary>
            /// The bottom center
            /// </summary>
            BottomCenter
        }

        /// <summary>
        /// Enum representing the effect when the button is hovered
        /// </summary>
        public enum ButtonHoverEffect : uint
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The brighten
            /// </summary>
            Brighten,
            /// <summary>
            /// The brighten image
            /// </summary>
            BrightenImage,
            /// <summary>
            /// The raised
            /// </summary>
            Raised
        }

        /// <summary>
        /// Enum representing the effect the the button is focused
        /// </summary>
        public enum ButtonFocusEffect : uint
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The brighten
            /// </summary>
            Brighten,
            /// <summary>
            /// The bubble
            /// </summary>
            Bubble,
            /// <summary>
            /// The bubble swirl
            /// </summary>
            BubbleSwirl,
            /// <summary>
            /// The swirl
            /// </summary>
            Swirl,
        }

        /// <summary>
        /// Enum representing the effect when the button is pressed
        /// </summary>
        public enum ButtonPressedEffect : uint
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The darken
            /// </summary>
            Darken,
            /// <summary>
            /// The resize
            /// </summary>
            Resize,
            /// <summary>
            /// The swish
            /// </summary>
            Swish
        }

        /// <summary>
        /// Enum representing the effect when the button is selected
        /// </summary>
        private enum ButtonSelectedState : uint
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The disabled
            /// </summary>
            Disabled,
            /// <summary>
            /// The checked
            /// </summary>
            Checked,
            /// <summary>
            /// The focused
            /// </summary>
            Focused,
            /// <summary>
            /// The pressed
            /// </summary>
            Pressed,
            /// <summary>
            /// The depressed
            /// </summary>
            Depressed,
            /// <summary>
            /// The hover
            /// </summary>
            Hover
        }
        #endregion

        #region Structs
        /// <summary>
        /// Struct SwirlStage
        /// </summary>
        private struct SwirlStage
        {
            /// <summary>
            /// The stage
            /// </summary>
            public uint stage;
            /// <summary>
            /// The tick
            /// </summary>
            public uint tick;
            /// <summary>
            /// The linepos
            /// </summary>
            public Point linepos;
            /// <summary>
            /// The mask
            /// </summary>
            public Rectangle mask;
            /// <summary>
            /// Initializes a new instance of the <see cref="SwirlStage"/> struct.
            /// </summary>
            /// <param name="stg">The STG.</param>
            public SwirlStage(uint stg)
            {
                stage = stg;
                tick = 0;
                linepos = new Point(0, 0);
                mask = new Rectangle(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Struct SwishStage
        /// </summary>
        private struct SwishStage
        {
            /// <summary>
            /// The cycled
            /// </summary>
            public bool cycled;
            /// <summary>
            /// The position
            /// </summary>
            public int pos;
            /// <summary>
            /// The tick
            /// </summary>
            public uint tick;
            /// <summary>
            /// The mask
            /// </summary>
            public Rectangle mask;
            /// <summary>
            /// Initializes a new instance of the <see cref="SwishStage"/> struct.
            /// </summary>
            /// <param name="cyc">if set to <c>true</c> [cyc].</param>
            public SwishStage(bool cyc)
            {
                cycled = cyc;
                pos = 0;
                tick = 0;
                mask = new Rectangle(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Struct RECT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RECT"/> struct.
            /// </summary>
            /// <param name="X">The x.</param>
            /// <param name="Y">The y.</param>
            /// <param name="Width">The width.</param>
            /// <param name="Height">The height.</param>
            public RECT(int X, int Y, int Width, int Height)
            {
                this.Left = X;
                this.Top = Y;
                this.Right = Width;
                this.Bottom = Height;
            }
            /// <summary>
            /// The left
            /// </summary>
            public int Left;
            /// <summary>
            /// The top
            /// </summary>
            public int Top;
            /// <summary>
            /// The right
            /// </summary>
            public int Right;
            /// <summary>
            /// The bottom
            /// </summary>
            public int Bottom;
        }
        #endregion

        #region API
        /// <summary>
        /// Gets the dc.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr handle);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="hdc">The HDC.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        /// <summary>
        /// Bits the BLT.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="nXDest">The n x dest.</param>
        /// <param name="nYDest">The n y dest.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="nXSrc">The n x source.</param>
        /// <param name="nYSrc">The n y source.</param>
        /// <param name="dwRop">The dw rop.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        /// <summary>
        /// Validates the rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpRect">The lp rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);
        #endregion

        #region Fields
        /// <summary>
        /// The b animation complete
        /// </summary>
        private bool _bAnimationComplete = false;
        /// <summary>
        /// The b has initialized
        /// </summary>
        private bool _bHasInitialized = false;
        /// <summary>
        /// The b in designer
        /// </summary>
        private bool _bInDesigner = true;
        /// <summary>
        /// The b first focus
        /// </summary>
        private bool _bFirstFocus = true;
        /// <summary>
        /// The b pulse fading
        /// </summary>
        private bool _bPulseFading = false;
        /// <summary>
        /// The b resize on load
        /// </summary>
        private bool _bResizeOnLoad = false;
        /// <summary>
        /// The b swirl timer on
        /// </summary>
        private bool _bSwirlTimerOn = false;
        /// <summary>
        /// The b resize timer on
        /// </summary>
        private bool _bResizeTimerOn = false;
        /// <summary>
        /// The b pulse timer on
        /// </summary>
        private bool _bPulseTimerOn = false;
        /// <summary>
        /// The b swish timer on
        /// </summary>
        private bool _bSwishTimerOn = false;
        /// <summary>
        /// The b check state
        /// </summary>
        private bool _bCheckState = false;
        /// <summary>
        /// The b use check style
        /// </summary>
        private bool _bUseCheckStyle = false;
        /// <summary>
        /// The b focus on click
        /// </summary>
        private bool _bFocusOnClick = false;
        /// <summary>
        /// The b focus on hover
        /// </summary>
        private bool _bFocusOnHover = false;

        /// <summary>
        /// The ft alpha glow
        /// </summary>
        private float _ftAlphaGlow = 0;
        /// <summary>
        /// The ft alpha line
        /// </summary>
        private float _ftAlphaLine = 0;
        /// <summary>
        /// The i corner radius
        /// </summary>
        private uint _iCornerRadius = 6;
        /// <summary>
        /// The i shadow depth
        /// </summary>
        private int _iShadowDepth = 0;
        /// <summary>
        /// The i pulse tick
        /// </summary>
        private int _iPulseTick = 0;

        /// <summary>
        /// The color focused fore color
        /// </summary>
        private Color _clrFocusedForeColor = Color.WhiteSmoke;
        /// <summary>
        /// The color disabled fore color
        /// </summary>
        private Color _clrDisabledForeColor = Color.DarkGray;

        /// <summary>
        /// The o image
        /// </summary>
        private Image _oImage;
        /// <summary>
        /// The o image focused
        /// </summary>
        private Image _oImageFocused;

        /// <summary>
        /// The e text align
        /// </summary>
        private Alignment _eTextAlign = Alignment.BottomRight;

        /// <summary>
        /// The e image layout
        /// </summary>
        private Alignment _eImageLayout = Alignment.TopCenter;
        /// <summary>
        /// The e border style
        /// </summary>
        private ZeroitBorderStyle _eBorderStyle = ZeroitBorderStyle.None;
        /// <summary>
        /// The e button style
        /// </summary>
        private ButtonStyle _eButtonStyle = ButtonStyle.MenuButton;
        /// <summary>
        /// The e button state
        /// </summary>
        private ButtonSelectedState _eButtonState;
        /// <summary>
        /// The pd padding
        /// </summary>
        private Padding _pdPadding;
        /// <summary>
        /// The pd image padding
        /// </summary>
        private Padding _pdImagePadding;
        /// <summary>
        /// The pd text padding
        /// </summary>
        private Padding _pdTextPadding;

        /// <summary>
        /// The h button region
        /// </summary>
        private Region _hButtonRegion;
        /// <summary>
        /// The gp button path
        /// </summary>
        private GraphicsPath _gpButtonPath;
        /// <summary>
        /// The c mouse event arguments
        /// </summary>
        private MouseEventArgs _cMouseEventArgs;

        /// <summary>
        /// The t swirl stage
        /// </summary>
        private SwirlStage _tSwirlStage;
        /// <summary>
        /// The t swish stage
        /// </summary>
        private SwishStage _tSwishStage;
        /// <summary>
        /// The c swirl timer
        /// </summary>
        private FadeTimer _cSwirlTimer;
        /// <summary>
        /// The c resize timer
        /// </summary>
        private FadeTimer _cResizeTimer;
        /// <summary>
        /// The c swish timer
        /// </summary>
        private FadeTimer _cSwishTimer;
        /// <summary>
        /// The c pulse timer
        /// </summary>
        private FadeTimer _cPulseTimer;
        /// <summary>
        /// The BMP swish
        /// </summary>
        private Bitmap _bmpSwish;
        /// <summary>
        /// The BMP swirl line
        /// </summary>
        private Bitmap _bmpSwirlLine;
        /// <summary>
        /// The BMP swirl line vert
        /// </summary>
        private Bitmap _bmpSwirlLineVert;
        /// <summary>
        /// The BMP swirl glow
        /// </summary>
        private Bitmap _bmpSwirlGlow;
        /// <summary>
        /// The BMP swirl glow vert
        /// </summary>
        private Bitmap _bmpSwirlGlowVert;
        /// <summary>
        /// The BMP resize
        /// </summary>
        private Bitmap _bmpResize;
        /// <summary>
        /// The c button dc
        /// </summary>
        private cStoreDc _cButtonDc;
        /// <summary>
        /// The c temporary dc
        /// </summary>
        private cStoreDc _cTempDc;

        /// <summary>
        /// Delegate ResetCallback
        /// </summary>
        private delegate void ResetCallback();
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMediaClassicButton" /> class.
        /// </summary>
        public ZeroitMediaClassicButton()
        {

            LoadDefaults();
            _bInDesigner = false;

            InitializeComponent();

            
        }

        /// <summary>
        /// Create the GraphicsPath and region, load buffers
        /// </summary>
        private void Init()
        {
            DeInit();
            _bFirstFocus = !this.DesignMode && _bResizeOnLoad;
            // set style
            SetButtonStyle(_eButtonStyle);
            if (_eButtonStyle != ButtonStyle.MenuButton)
            {
                Control ct = (Control)this;
                Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
                // create the path and region
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    _gpButtonPath = CreateRoundRectanglePath(g, 0, 0, ct.Bounds.Width, ct.Bounds.Height, CornerRadius);
                    _hButtonRegion = new Region(_gpButtonPath);
                    ct.Region = _hButtonRegion;
                }
            }
            LoadBuffers();
            _eButtonState = ButtonSelectedState.None;
            _bHasInitialized = true;
        }

        /// <summary>
        /// Design time defaults
        /// </summary>
        private void LoadDefaults()
        {
            if (this.DesignMode)
            {
                this.FocusedForeColor = Color.WhiteSmoke;
                this.DisabledForeColor = Color.DarkGray;
                this.ForeColor = Color.FromArgb(244, 244, 244);
            }
            SetButtonStyle(_eButtonStyle);
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Optional manual dispose method
        /// </summary>
        public void Dispose()
        {
            DeInit();
        }

        /// <summary>
        /// Release resources
        /// </summary>
        private void DeInit()
        {
            _bHasInitialized = false;
            // reset region
            Control ct = (Control)this;
            if (ct.Region != null)
            {
                ct.Region = null;
            }
            if (_gpButtonPath != null)
            {
                _gpButtonPath.Dispose();
                _gpButtonPath = null;
            }
            if (_hButtonRegion != null)
            {
                _hButtonRegion.Dispose();
                _hButtonRegion = null;
            }
            // release resources
            if (_cButtonDc != null)
            {
                _cButtonDc.Dispose();
                _cButtonDc = null;
            }
            if (_cTempDc != null)
            {
                _cTempDc.Dispose();
                _cTempDc = null;
            }
            StopSwirlTimer();
            StopResizeTimer();
            StopPulseTimer();
            StopSwishTimer();
            DestroySwish();
            DestroyResize();
            DestroySwirl();
        }
        #endregion

        #region Properties
        #region Hidden Properties        
        /// <summary>
        /// Gets or sets a value indicating whether the control can accept data that the user drags onto it.
        /// </summary>
        /// <value><c>true</c> if allow drop; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public new bool AllowDrop
        {
            get { return base.AllowDrop; }
            set { base.AllowDrop = value; }
        }

        /// <summary>
        /// Gets or sets the edges of the container to which a control is bound and determines how a control is resized with its parent.
        /// </summary>
        /// <value>The anchor.</value>
        [Browsable(false)]
        public new AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value><c>true</c> if [automatic scroll]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public new bool AutoScroll
        {
            get { return base.AutoScroll; }
            set { base.AutoScroll = value; }
        }

        /// <summary>
        /// Gets or sets the size of the auto-scroll margin.
        /// </summary>
        /// <value>The automatic scroll margin.</value>
        [Browsable(false)]
        public new Size AutoScrollMargin
        {
            get { return base.AutoScrollMargin; }
            set { base.AutoScrollMargin = value; }
        }

        /// <summary>
        /// Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <value>The minimum size of the automatic scroll.</value>
        [Browsable(false)]
        public new Size AutoScrollMinSize
        {
            get { return base.AutoScrollMinSize; }
            set { base.AutoScrollMinSize = value; }
        }

        /// <summary>
        /// Gets or sets how the control will resize itself.
        /// </summary>
        /// <value>The automatic size mode.</value>
        [Browsable(false)]
        public new AutoSizeMode AutoSizeMode
        {
            get { return base.AutoSizeMode; }
            set { base.AutoSizeMode = value; }
        }
        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
        public new Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <value>The background image layout.</value>
        [Browsable(false)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip" /> associated with this control.
        /// </summary>
        /// <value>The context menu strip.</value>
        [Browsable(false)]
        public new ContextMenu ContextMenuStrip
        {
            get { return base.ContextMenu; }
            set { base.ContextMenu = value; }
        }
        /// <summary>
        /// Gets or sets which control borders are docked to its parent control and determines how a control is resized with its parent.
        /// </summary>
        /// <value>The dock.</value>
        [Browsable(false)]
        public new DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set border [not available on Menu style]
        /// </summary>
        /// <value>The border style.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set border style")]
        public new ZeroitBorderStyle BorderStyle
        {
            get { return _eBorderStyle; }
            set
            {
                _eBorderStyle = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set Checkbox state style [Media style only]
        /// </summary>
        /// <value><c>true</c> if [check style]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool CheckStyle
        {
            get { return _bUseCheckStyle; }
            set { _bUseCheckStyle = value; }
        }

        /// <summary>
        /// Get/Set button corner radius [Custom style only]
        /// </summary>
        /// <value>The corner radius.</value>
        [Browsable(false), Category("Style"),
        Description("Get/Set button corner radius"),
        DesignOnlyAttribute(true)]
        public uint CornerRadius
        {
            get { return _iCornerRadius; }
            set
            {
                _iCornerRadius = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set the disabled ForeColor
        /// </summary>
        /// <value>The color of the disabled fore.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set the disabled ForeColor")]
        public Color DisabledForeColor
        {
            get { return _clrDisabledForeColor; }
            set { _clrDisabledForeColor = value; }
        }

        /// <summary>
        /// Get/Set the focused ForeColor
        /// </summary>
        /// <value>The color of the focused fore.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set the focused ForeColor")]
        public Color FocusedForeColor
        {
            get { return _clrFocusedForeColor; }
            set { _clrFocusedForeColor = value; }
        }

        /// <summary>
        /// Get/Set Focus on first click [Menu style only]
        /// </summary>
        /// <value><c>true</c> if [focus on click]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set Focus on first click [Menu style only]")]
        public bool FocusOnClick
        {
            get { return _bFocusOnClick; }
            set { _bFocusOnClick = value; }
        }

        /// <summary>
        /// Get/Set Focus on button hover [Custom style only]
        /// </summary>
        /// <value><c>true</c> if [focus on hover]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set Focus on button hover [Custom style only]")]
        public bool FocusOnHover
        {
            get { return _bFocusOnHover; }
            set { _bFocusOnHover = value; }
        }

        /// <summary>
        /// Get/Set button image
        /// </summary>
        /// <value>The image.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set button image")]
        public Image Image
        {
            get { return _oImage; }
            set
            {
                _oImage = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set button focused image [only available on Menu style]
        /// </summary>
        /// <value>The image focused.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set button focused image")]
        public Image ImageFocused
        {
            get { return _oImageFocused; }
            set
            {
                _oImageFocused = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set button image alignment [only middle axis implemented]
        /// </summary>
        /// <value>The image align.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set button image alignment")]
        public Alignment ImageAlign
        {
            get { return _eImageLayout; }
            set
            {
                _eImageLayout = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set button image padding
        /// </summary>
        /// <value>The image padding.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set button image padding")]
        public Padding ImagePadding
        {
            get { return _pdImagePadding; }
            set
            {
                _pdImagePadding = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set button padding
        /// </summary>
        /// <value>The padding.</value>
        [Browsable(false)]
        public new Padding Padding
        {
            get { return _pdPadding; }
            set
            {
                _pdPadding = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set Load focused button with Resize effect [Menu style only]
        /// </summary>
        /// <value><c>true</c> if [resize on load]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set Load focused button with Resize effect [Menu style only]")]
        public bool ResizeOnLoad
        {
            get { return _bResizeOnLoad; }
            set { _bResizeOnLoad = value; }
        }

        /// <summary>
        /// Get/Set button shadow depth [Menu style only]
        /// </summary>
        /// <value>The shadow depth.</value>
        [Browsable(false),
        DesignOnlyAttribute(true)]
        public int ShadowDepth
        {
            get { return _iShadowDepth; }
            set
            {
                _iShadowDepth = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set the button style
        /// </summary>
        /// <value>The style.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set the button style")]
        public ButtonStyle Style
        {
            get { return _eButtonStyle; }
            set
            {
                _eButtonStyle = value;
                SetButtonStyle(_eButtonStyle);
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set button text
        /// </summary>
        /// <value>The text.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set the button text"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set button text alignment [only middle axis implemented]
        /// </summary>
        /// <value>The text align.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set button text alignment")]
        public Alignment TextAlign
        {
            get { return _eTextAlign; }
            set
            {
                _eTextAlign = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Get/Set button image padding
        /// </summary>
        /// <value>The text padding.</value>
        [Browsable(true), Category("Style"),
        Description("Get/Set button image padding")]
        public Padding TextPadding
        {
            get { return _pdTextPadding; }
            set
            {
                _pdTextPadding = value;
                PropertyChange();
            }
        }
        #endregion
        #endregion

        #region Overrides
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            Init();
            base.OnHandleCreated(e);
        }

        /// <summary>
        /// Raises the CreateControl event.
        /// </summary>
        protected override void OnCreateControl()
        {
            if (this.AutoSize)
                ResizeThis();
            base.OnCreateControl();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleDestroyed" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            DeInit();
            base.OnHandleDestroyed(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_bHasInitialized)
                DrawButton();
            base.OnPaint(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            // override for animations
            if (_eButtonStyle == ButtonStyle.MediaButton || _bAnimationComplete)
                base.OnMouseClick(e);
            else
                _cMouseEventArgs = e;
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // if !FocusOnClick, let it run, go to focus on first click w/ menu style
            if (_eButtonStyle == ButtonStyle.MenuButton && !this.Focused && !this.FocusOnClick)
            {
                base.OnMouseDown(e);
            }
            else
            {
                _eButtonState = ButtonSelectedState.Pressed;
                DrawButton();
                base.OnMouseDown(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseHover" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            if (!this.Focused && this.FocusOnHover && _eButtonStyle == ButtonStyle.CustomButton)
            {
                this.Focus();
            }
            else if (!(this.Focused && _eButtonStyle == ButtonStyle.MenuButton))
            {
                _eButtonState = ButtonSelectedState.Hover;
                DrawButton();
            }
            base.OnMouseHover(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _bCheckState = !_bCheckState;
            if (CheckStyle && _bCheckState && _eButtonStyle == ButtonStyle.MediaButton)
                _eButtonState = ButtonSelectedState.Checked;
            else
                _eButtonState = ButtonSelectedState.Depressed;
            DrawButton();
            
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.Focused && this.FocusOnHover && _eButtonStyle == ButtonStyle.CustomButton)
            {
                _eButtonState = ButtonSelectedState.Focused;
            }
            else if (!(this.Focused && _eButtonStyle == ButtonStyle.MenuButton))
            {
                _eButtonState = ButtonSelectedState.None;
                Repaint();
            }
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Space)
            {
                OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Space)
            {
                OnMouseUp(new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
            }
            base.OnKeyUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            if (_eButtonStyle == ButtonStyle.MenuButton)
            {
                if (_bHasInitialized && this.Visible)
                {
                    if (this.FocusOnClick)
                    {
                        MouseButtons mb = Control.MouseButtons;
                        if (mb != MouseButtons.Left)
                            _eButtonState = ButtonSelectedState.Focused;
                    }
                    else
                    {
                        _eButtonState = ButtonSelectedState.Focused;
                    }
                    Repaint();
                }
            }
            else
            {
                MouseButtons mb = Control.MouseButtons;
                if (mb != MouseButtons.Left)
                    _eButtonState = ButtonSelectedState.Focused;
                Repaint();
            }
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            _eButtonState = ButtonSelectedState.None;
            Repaint();
            base.OnLostFocus(e);
        }
        #endregion

        #region Methods
        #region Global
        /// <summary>
        /// Render hub
        /// </summary>
        private void DrawButton()
        {
            // Menu button
            // normal       -dimmed picture
            // mouse over   -brighten image
            // pressed      -size change (w/ image)
            // focused      -4 stage swirling on border w/ radiance spillover
            // disabled     -image greyed

            // Media button
            // normal       -round w/ subtle border
            // mouse over   -brighten
            // pressed      -darken
            // focused      -<normal>
            // disabled     -greyed

            // Custom button
            // normal       -rounded border - except when disabled
            // mouse over   -raised bubble w/ border and pulse effect
            // pressed      -swish effect 2 cycles fast/slow-loop
            // focused      -<mouse over>
            // disabled     -light blue/enabled white
            try
            {
                Rectangle bounds;

                switch (Style)
                {
                    case ButtonStyle.MediaButton:
                        bounds = Rectangle.Round(_gpButtonPath.GetBounds());
                        DrawMediaButton(bounds);
                        break;
                    case ButtonStyle.MenuButton:
                        bounds = new Rectangle(0, 0, this.Width, this.Height);
                        DrawMenuButton(bounds);
                        break;
                    case ButtonStyle.CustomButton:
                        bounds = Rectangle.Round(_gpButtonPath.GetBounds());
                        DrawCustomButton(bounds);
                        break;
                }
            }
            catch (Exception ex) { /*put an error handler here if you want*/ }
        }

        /// <summary>
        /// Adjust gamma of an image [not used]
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="gamma">The gamma.</param>
        private void DrawBrightImage(Graphics g, Image image, Rectangle bounds, float gamma)
        {
            try
            {
                using (Bitmap buttonImage = new Bitmap(Image))
                {
                    using (ImageAttributes imageAttr = new ImageAttributes())
                    {
                        if (gamma > .9f)
                            gamma = .9f;
                        if (gamma < .2f)
                            gamma = .2f;
                        // raise gamma
                        imageAttr.SetGamma(gamma);
                        g.DrawImage(buttonImage,
                            bounds,
                            0, 0,
                            buttonImage.Width,
                            buttonImage.Height,
                            GraphicsUnit.Pixel,
                            imageAttr);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Backfill the buffer
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawButtonBackGround(Graphics g, RectangleF bounds)
        {
            //TransparentInPaint(g);
            using (Brush br = new SolidBrush(BackColor))

                g.FillRectangle(br, bounds);
        }

        /// <summary>
        /// Draw the border thick/thin !Menu style
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawButtonBorder(Graphics g, RectangleF bounds)
        {
            if (this.BorderStyle == ZeroitBorderStyle.Thin)
            {
                bounds.Inflate(-1, -1);
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                {
                    using (GraphicsPath borderPath = CreateRoundRectanglePath(
                        g,
                        bounds.X, bounds.Y,
                        bounds.Width, bounds.Height,
                        CornerRadius))
                    {
                        // bright outer border
                        using (Pen borderPen = new Pen(Color.FromArgb(80, Color.LightGray), .5f))
                            g.DrawPath(borderPen, borderPath);
                    }
                }
            }
            else if (this.BorderStyle == ZeroitBorderStyle.Raised)
            {
                bounds.Inflate(-1, -1);
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                {
                    using (GraphicsPath borderPath = CreateRoundRectanglePath(
                        g,
                        bounds.X, bounds.Y,
                        bounds.Width, bounds.Height,
                        CornerRadius))
                    {
                        // bright outer border
                        using (Pen borderPen = new Pen(Color.FromArgb(120, Color.White), 2f))
                            g.DrawPath(borderPen, borderPath);

                    }
                    bounds.Inflate(-1.5f, -1.5f);
                    using (GraphicsPath borderPath = CreateRoundRectanglePath(
                        g,
                        bounds.X, bounds.Y,
                        bounds.Width, bounds.Height,
                        CornerRadius))
                    {
                        // dark inner border
                        using (Pen borderPen = new Pen(Color.FromArgb(120, Color.Silver), .5f))
                            g.DrawPath(borderPen, borderPath);
                    }
                }
            }
        }

        /// <summary>
        /// Draw the 'mask' gradient !Menu style
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="opacity">The opacity.</param>
        /// <param name="pitch">The pitch.</param>
        private void DrawButtonMask(Graphics g, RectangleF bounds, int opacity, float pitch)
        {
            bounds.Inflate(-.5f, -.5f);
            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                using (GraphicsPath borderPath = CreateRoundRectanglePath(
                    g,
                    bounds.X, bounds.Y,
                    bounds.Width, bounds.Height,
                    CornerRadius))
                {
                    // dark inner border
                    using (Pen borderPen = new Pen(Color.FromArgb(80, Color.DarkGray), .5f))
                        g.DrawPath(borderPen, borderPath);
                }
                // size it
                if (this.BorderStyle == ZeroitBorderStyle.Thin)
                    bounds.Inflate(-1, -1);
                else if (this.BorderStyle == ZeroitBorderStyle.Raised)
                    bounds.Inflate(-2, -2);
                // create an interior path
                using (GraphicsPath gp = CreateRoundRectanglePath(g, bounds.X, bounds.Y,
                    bounds.Width, bounds.Height, CornerRadius))
                {
                    // fill the button with a subtle glow
                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                        bounds,
                        Color.FromArgb(opacity, Color.White),
                        Color.FromArgb(5, Color.Silver),
                        pitch))
                    {
                        Blend blnd = new Blend();
                        blnd.Positions = new float[] { 0f, .1f, .2f, .3f, .4f, .5f, 1f };
                        blnd.Factors = new float[] { 0f, .1f, .2f, .4f, .7f, .8f, 1f };
                        fillBrush.Blend = blnd;
                        g.FillPath(fillBrush, gp);
                    }
                }
            }
        }

        /// <summary>
        /// Draw a disabled image using the control
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawDisabledImage(Graphics g, Image image, Rectangle bounds)
        {
            ControlPaint.DrawImageDisabled(g, image, bounds.X, bounds.Y, Color.Transparent);
        }

        /// <summary>
        /// Draw an unaltered image
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawImage(Graphics g, Image image, Rectangle bounds)
        {
            g.DrawImage(image, bounds);
        }

        /// <summary>
        /// Draw text w/ appropriate color
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="text">The text.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawText(Graphics g, string text, Rectangle bounds)
        {
            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                Color clr;

                if (_eButtonState == ButtonSelectedState.Disabled)
                    clr = this.DisabledForeColor;
                else if (this.Focused)// v1.1 fixed ju
                    clr = this.FocusedForeColor;
                else
                    clr = this.ForeColor;

                using (StringFormat sF = new StringFormat())
                {
                    sF.Alignment = StringAlignment.Near;
                    sF.LineAlignment = StringAlignment.Near;

                    using (Brush captionBrush = new SolidBrush(clr))
                        g.DrawString(this.Text, this.Font, captionBrush, new RectangleF(bounds.X, bounds.Y, bounds.Width, bounds.Height), sF);
                }
            }
        }

        /// <summary>
        /// Measure string size in control context
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>SizeF.</returns>
        private SizeF MeasureText(string text)
        {
            SizeF sz = new SizeF();
            if (text.Length != 0)
            {
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                    sz = g.MeasureString(text, this.Font);
            }
            return sz;
        }
        #endregion

        #region Menu Button
        #region Drawing
        /// <summary>
        /// Menu style Render hub
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        private void DrawMenuButton(Rectangle bounds)
        {
            if (_cButtonDc != null)
            {
                Rectangle imageRect = new Rectangle();
                Rectangle textRect = new Rectangle();

                if (Image != null)
                    imageRect = GetImageRectangle(ImageAlign, bounds, new Rectangle(0, 0, Image.Width, Image.Height));
                if (this.Text.Length != 0)
                {
                    SizeF sz = MeasureText(this.Text);
                    textRect = GetTextRectangle(TextAlign, bounds, new Rectangle(0, 0, (int)sz.Width, (int)sz.Height));
                }

                if (_bFirstFocus)
                    _eButtonState = ButtonSelectedState.Pressed;

                using (Graphics g = Graphics.FromHdc(_cButtonDc.Hdc))
                {
                    switch (_eButtonState)
                    {
                        case ButtonSelectedState.Checked:
                        case ButtonSelectedState.Pressed:
                            {
                                if (_bSwirlTimerOn)
                                    StopSwirlTimer();
                                if (!_bResizeTimerOn)
                                {
                                    // backfill
                                    DrawButtonBackGround(g, bounds);
                                    // draw image
                                    if (ImageFocused != null)
                                        DrawImage(g, ImageFocused, imageRect);
                                    else if (Image != null)
                                        DrawImage(g, Image, imageRect);
                                    // draw mask and border
                                    DrawMenuButtonMask(g, imageRect);
                                    // draw text
                                    if (this.Text.Length != 0)
                                        DrawText(g, this.Text, textRect);
                                    // allow control to load for effect
                                    if (_bFirstFocus)
                                        WaitTimer(2);
                                    // start resize
                                    if (!_bInDesigner)
                                        StartResizeTimer(_bFirstFocus);
                                }
                            }
                            break;
                        case ButtonSelectedState.Depressed:
                            {
                                if (_bResizeTimerOn)
                                    _cResizeTimer.FadeStyle = FadeTimer.FadeType.FadeOut;
                                // draw text
                                if (this.Text.Length != 0)
                                    DrawText(g, this.Text, textRect);
                            }
                            break;
                        case ButtonSelectedState.Disabled:
                            {
                                if (_bSwirlTimerOn)
                                    StopSwirlTimer();
                                DrawButtonBackGround(g, bounds);
                                if (Image != null)
                                    DrawDisabledImage(g, Image, imageRect);
                                // draw text
                                if (this.Text.Length != 0)
                                    DrawText(g, this.Text, textRect);
                            }
                            break;
                        case ButtonSelectedState.Focused:
                            {
                                if (!_bSwirlTimerOn)
                                {
                                    if (_bResizeTimerOn)
                                        StopResizeTimer();
                                    DrawButtonBackGround(g, bounds);
                                    if (ImageFocused != null)
                                        DrawImage(g, ImageFocused, imageRect);
                                    else if (Image != null)
                                        DrawImage(g, Image, imageRect);
                                    DrawMenuButtonMask(g, imageRect);
                                    // draw text
                                    if (this.Text.Length != 0)
                                        DrawText(g, this.Text, textRect);
                                    StartSwirlTimer();
                                }
                            }
                            break;
                        case ButtonSelectedState.Hover:
                            {
                                if (!_bSwirlTimerOn)
                                {
                                    DrawButtonBackGround(g, bounds);
                                    // draw text
                                    if (this.Text.Length != 0)
                                        DrawText(g, this.Text, textRect);
                                    if (Image != null)
                                    {
                                        if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                            DrawImage(g, Image, imageRect);
                                        else
                                            DrawBrightImage(g, Image, imageRect, 0.2f);
                                    }
                                }
                            }
                            break;
                        case ButtonSelectedState.None:
                            {
                                if (_bSwirlTimerOn)
                                    StopSwirlTimer();
                                DrawButtonBackGround(g, bounds);
                                // draw text
                                if (this.Text.Length != 0)
                                    DrawText(g, this.Text, textRect);
                                if (Image != null)
                                {
                                    if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                        AlphaBlend(g, (Bitmap)Image, imageRect, .7f);
                                    else
                                        DrawImage(g, Image, imageRect);
                                }
                            }
                            break;
                    }
                }
                _bFirstFocus = false;

                if (!(_bSwirlTimerOn || _bResizeTimerOn))
                {
                    // draw buffer to control
                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    {
                        BitBlt(g.GetHdc(), 0, 0, _cButtonDc.Width, _cButtonDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);
                        g.ReleaseHdc();
                    }
                    RECT r = new RECT(0, 0, this.Width, this.Height);
                    ValidateRect(this.Handle, ref r);
                }
            }
        }

        /// <summary>
        /// Draw the Menu style border
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawMenuButtonBorder(Graphics g, RectangleF bounds)
        {
            using (GraphicsPath borderPath = CreateRoundRectanglePath(
                g,
                bounds.X, bounds.Y,
                bounds.Width, bounds.Height,
                CornerRadius))
            {
                // top-left bottom-right -dark
                using (LinearGradientBrush borderBrush = new LinearGradientBrush(
                    bounds,
                    Color.FromArgb(140, Color.DarkGray),
                    Color.FromArgb(140, Color.White),
                    LinearGradientMode.BackwardDiagonal))
                {
                    Blend blnd = new Blend();
                    blnd.Positions = new float[] { 0f, .5f, 1f };
                    blnd.Factors = new float[] { 1f, 0f, 1f };
                    borderBrush.Blend = blnd;
                    using (Pen borderPen = new Pen(borderBrush, 2f))
                        g.DrawPath(borderPen, borderPath);
                }
            }
        }

        /// <summary>
        /// Draw a gradient shadow effect
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="opacity">The opacity.</param>
        private void DrawMenuButtonDropShadow(Graphics g, RectangleF bounds, int depth, int opacity)
        {
            // offset shadow dimensions
            RectangleF shadowBounds = bounds;
            shadowBounds.Inflate(1, 1);
            shadowBounds.Offset(depth, depth);

            // create a clipping region
            bounds.Inflate(1, 1);
            using (GraphicsPath clipPath = CreateRoundRectanglePath(
                g,
                bounds.X, bounds.Y,
                bounds.Width, bounds.Height,
                CornerRadius))
            {
                // clip the interior
                using (Region region = new Region(clipPath))
                    g.SetClip(region, CombineMode.Exclude);
            }

            // create a graphics path
            using (GraphicsPath gp = CreateRoundRectanglePath(g, shadowBounds.X, shadowBounds.Y,
                shadowBounds.Width, shadowBounds.Height, 8))
            {
                // draw with a path brush
                using (PathGradientBrush borderBrush = new PathGradientBrush(gp))
                {
                    borderBrush.CenterColor = Color.FromArgb(opacity, Color.Black);
                    borderBrush.SurroundColors = new Color[] { Color.Transparent };
                    borderBrush.SetBlendTriangularShape(.5f, 1.0f);
                    borderBrush.FocusScales = new PointF(.4f, .5f);
                    g.FillPath(borderBrush, gp);
                    g.ResetClip();
                }
            }
        }

        /// <summary>
        /// Draw the Menu button gradient mask
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawMenuButtonMask(Graphics g, RectangleF bounds)
        {
            RectangleF maskRect = bounds;
            int offsetX = (this.ImagePadding.Left + this.ImagePadding.Right) / 2;
            int offsetY = (this.ImagePadding.Top + this.ImagePadding.Bottom) / 2;
            maskRect.Inflate(offsetX, offsetY);

            // draw using hq anti alias
            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
            {
                // draw the drop shadow 494 210
                DrawMenuButtonDropShadow(g, maskRect, ShadowDepth, 120);
                // draw the border
                DrawMenuButtonBorder(g, maskRect);

                maskRect.Inflate(-1, -1);
                // create an interior path
                using (GraphicsPath gp = CreateRoundRectanglePath(g, maskRect.X, maskRect.Y,
                    maskRect.Width, maskRect.Height, CornerRadius))
                {
                    // fill the button with a subtle glow
                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                        maskRect,
                        Color.FromArgb(160, Color.White),
                        Color.FromArgb(5, Color.Silver),
                        75f))
                    {
                        Blend blnd = new Blend();
                        blnd.Positions = new float[] { 0f, .1f, .2f, .3f, .4f, .5f, 1f };
                        blnd.Factors = new float[] { 0f, .1f, .2f, .4f, .7f, .8f, 1f };
                        fillBrush.Blend = blnd;
                        g.FillPath(fillBrush, gp);
                    }
                }
                // init storage
                _tSwirlStage = new SwirlStage(0);
                maskRect.Inflate(1, 1);
                _tSwirlStage.mask = Rectangle.Round(maskRect);
            }
        }

        /// <summary>
        /// Draws the line sprite
        /// </summary>
        /// <param name="destdc">The destdc.</param>
        /// <param name="source">The source.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="intensity">The intensity.</param>
        private void DrawMenuButtonLine(IntPtr destdc, Bitmap source, Rectangle bounds, float intensity)
        {
            using (Graphics g = Graphics.FromHdc(destdc))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                AlphaBlend(g, source, bounds, intensity);
            }
        }

        /// <summary>
        /// Draws the mist effect
        /// </summary>
        /// <param name="destdc">The destdc.</param>
        /// <param name="source">The source.</param>
        /// <param name="cliprect">The cliprect.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="intensity">The intensity.</param>
        private void DrawMenuButtonMist(IntPtr destdc, Bitmap source, Rectangle cliprect, Rectangle bounds, float intensity)
        {
            using (ClippingRegion cp = new ClippingRegion(destdc, cliprect, bounds, CornerRadius))
            {
                using (Graphics g = Graphics.FromHdc(destdc))
                    AlphaBlend(g, source, bounds, intensity);
            }
        }
        #endregion

        #region Resize Effect
        /// <summary>
        /// Called by resize timer, renders image at size/steps
        /// </summary>
        private void DrawResized()
        {
            Rectangle canvas = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle maskRect = canvas;
            // image axis
            int offsetX = (this.ImagePadding.Left + this.ImagePadding.Right) / 2;
            int offsetY = (this.ImagePadding.Top + this.ImagePadding.Bottom) / 2;

            maskRect.Inflate(-offsetX, -offsetY);
            // inflate by -tickcount
            int sizediff = _cResizeTimer.TickCount;
            maskRect.Inflate(-sizediff, -sizediff);

            if (_cButtonDc != null)
            {
                using (Graphics g = Graphics.FromHdc(_cButtonDc.Hdc))
                {
                    using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                    {
                        // set hq render
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        // backfill
                        using (Brush br = new SolidBrush(this.BackColor))
                            g.FillRectangle(br, canvas);
                        // draw text in at normal size
                        if (this.Text.Length != 0)
                        {
                            SizeF sz = MeasureText(this.Text);
                            maskRect.Height -= (int)sz.Height + TextPadding.Top + TextPadding.Bottom;
                            Rectangle textRect = GetTextRectangle(TextAlign, canvas, new Rectangle(0, 0, (int)sz.Width, (int)sz.Height));
                            DrawText(g, this.Text, textRect);
                        }
                        // draw the sized image
                        g.DrawImage(_bmpResize, maskRect);
                    }
                }
            }

            // draw to control
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                BitBlt(g.GetHdc(), 0, 0, _cButtonDc.Width, _cButtonDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);
                g.ReleaseHdc();
            }
            // don't repaint
            RECT r = new RECT(0, 0, canvas.Width, canvas.Height);
            ValidateRect(this.Handle, ref r);
        }

        /// <summary>
        /// create the resize image and store as a bitmap
        /// </summary>
        private void CreateResize()
        {
            DestroyResize();
            Rectangle bounds = this.Bounds;
            int offsetX = (this.ImagePadding.Left + this.ImagePadding.Right) / 2;
            int offsetY = (this.ImagePadding.Top + this.ImagePadding.Bottom) / 2;
            bounds.Inflate(-offsetX, -offsetY);
            // we only want image and mask
            if (this.Text.Length != 0)
            {
                SizeF sz = MeasureText(this.Text);
                bounds.Height -= (int)sz.Height + TextPadding.Top + TextPadding.Bottom;
            }
            _bmpResize = new Bitmap(bounds.Width, bounds.Height);

            // copy image fragment from the buffer
            using (Graphics g = Graphics.FromImage(_bmpResize))
            {
                BitBlt(g.GetHdc(), 0, 0, bounds.Width, bounds.Height, _cButtonDc.Hdc, offsetX, offsetY, 0xCC0020);
                g.ReleaseHdc();
            }
        }

        /// <summary>
        /// Dispose of resize image
        /// </summary>
        private void DestroyResize()
        {
            if (_bmpResize != null)
            {
                _bmpResize.Dispose();
                _bmpResize = null;
            }
        }
        #endregion

        #region Swirl Effect
        /// <summary>
        /// Create the swirl effect bitmaps, glow and lines
        /// </summary>
        private void CreateSwirl()
        {
            int width = 0;
            int height = 0;

            DestroySwirl();

            // mist offset
            width = (int)(this.Width - (ShadowDepth * 2));
            // vertical mist
            height = (int)(this.Height * .3f);

            // draw the line sprite into a bmp
            _bmpSwirlLine = new Bitmap(28, 2);
            using (Graphics g = Graphics.FromImage(_bmpSwirlLine))
            {
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                {
                    g.CompositingMode = CompositingMode.SourceOver;
                    Rectangle imageRect = new Rectangle(0, 0, 28, 2);
                    // draw sprite
                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                        imageRect,
                        Color.White,
                        Color.Transparent,
                        LinearGradientMode.Horizontal))
                    {
                        Blend blnd = new Blend();
                        blnd.Positions = new float[] { 0f, .2f, .5f, .8f, 1f };
                        blnd.Factors = new float[] { 1f, .6f, 0f, .4f, 1f };
                        fillBrush.Blend = blnd;
                        using (GraphicsPath gp = CreateRoundRectanglePath(g, imageRect.X, imageRect.Y,
                                imageRect.Width, imageRect.Height, 2))
                            g.FillPath(fillBrush, gp);
                    }
                }
            }
            // make transparent
            _bmpSwirlLine.MakeTransparent();
            // clone and rotate
            _bmpSwirlLineVert = (Bitmap)_bmpSwirlLine.Clone();
            _bmpSwirlLineVert.RotateFlip(RotateFlipType.Rotate90FlipX);

            // draw the glow
            _bmpSwirlGlow = new Bitmap(width, 28);
            using (Graphics g = Graphics.FromImage(_bmpSwirlGlow))
            {
                Rectangle glowRect = new Rectangle(0, 0, width, 28);
                g.CompositingMode = CompositingMode.SourceOver;
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                {
                    int r = (glowRect.Height / 2);
                    r = glowRect.Height / 2;
                    float fy = glowRect.Height * .4f;
                    using (GraphicsPath gp = CreateRoundRectanglePath(g, glowRect.X, glowRect.Y,
                        glowRect.Width, glowRect.Height, r))
                    {
                        using (PathGradientBrush borderBrush = new PathGradientBrush(gp))
                        {
                            borderBrush.CenterColor = Color.FromArgb(120, Color.White);
                            borderBrush.SurroundColors = new Color[] { Color.FromArgb(5, Color.White) };
                            borderBrush.FocusScales = new PointF(.5f, .2f);
                            borderBrush.CenterPoint = new PointF(10, fy);
                            g.FillPath(borderBrush, gp);
                        }
                    }
                }
            }
            _bmpSwirlGlow.MakeTransparent();//8, 42, 105

            // right corner image
            _bmpSwirlGlowVert = new Bitmap(height, height);
            using (Graphics g = Graphics.FromImage(_bmpSwirlGlowVert))
            {
                Rectangle glowRect = new Rectangle(0, 0, height, height);
                g.CompositingMode = CompositingMode.SourceOver;
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                {
                    int r = height / 4;
                    using (GraphicsPath gp = CreateRoundRectanglePath(g, glowRect.X, glowRect.Y,
                        glowRect.Width, glowRect.Height, r))
                    {
                        using (PathGradientBrush borderBrush = new PathGradientBrush(gp))
                        {
                            borderBrush.CenterColor = Color.FromArgb(120, Color.White);
                            borderBrush.SurroundColors = new Color[] { Color.Transparent };
                            borderBrush.FocusScales = new PointF(0f, 0f);
                            borderBrush.FocusScales = new PointF(.5f, .5f);
                            borderBrush.CenterPoint = new PointF(r, r);
                            g.FillPath(borderBrush, gp);
                        }
                    }
                }
            }
            _bmpSwirlGlowVert.MakeTransparent();
        }

        /// <summary>
        /// Dispose of swirl effect images
        /// </summary>
        private void DestroySwirl()
        {
            // bitmaps
            if (_bmpSwirlLine != null)
                _bmpSwirlLine.Dispose();
            if (_bmpSwirlLineVert != null)
                _bmpSwirlLineVert.Dispose();
            if (_bmpSwirlGlow != null)
                _bmpSwirlGlow.Dispose();
            if (_bmpSwirlGlowVert != null)
                _bmpSwirlGlowVert.Dispose();
        }

        /// <summary>
        /// Draw the multi stage line and glow sprites
        /// </summary>
        private void DrawSwirl()
        {
            if (_cButtonDc != null)
            {
                int endX = 0;
                int endY = this.Height / 2;
                float alphaline = 0;
                int offset = 0;
                Rectangle cliprect;
                Rectangle mistrect;
                Rectangle linerect;

                // copy unaltered image into buffer
                BitBlt(_cTempDc.Hdc, 0, 0, _cTempDc.Width, _cTempDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);

                switch (_tSwirlStage.stage)
                {
                    #region Stage 1 - Top/Left
                    case 0:
                        {
                            endX = _tSwirlStage.mask.Width / 2;
                            if (_tSwirlStage.tick == 0)
                            {
                                _tSwirlStage.linepos.X = _tSwirlStage.mask.X + (int)CornerRadius;
                                _tSwirlStage.linepos.Y = _tSwirlStage.mask.Y;
                                _ftAlphaLine = .95f;
                                _ftAlphaGlow = .45f;
                            }

                            // just in case..
                            if (endX - _tSwirlStage.linepos.X > 0)
                            {
                                // get the alpha
                                _ftAlphaLine -= .02f;
                                if (_ftAlphaLine < .4f)
                                    _ftAlphaLine = .4f;
                                linerect = new Rectangle(_tSwirlStage.linepos.X, _tSwirlStage.linepos.Y, _bmpSwirlLine.Width, _bmpSwirlLine.Height);
                                // draw first sprite -horz
                                DrawMenuButtonLine(_cTempDc.Hdc, _bmpSwirlLine, linerect, _ftAlphaLine);
                                // second sprite -vert
                                // turn down the alpha to match border color
                                alphaline = _ftAlphaLine - .1f;
                                // draw second sprite
                                linerect = new Rectangle(_tSwirlStage.linepos.Y, _tSwirlStage.linepos.X, _bmpSwirlLineVert.Width, _bmpSwirlLineVert.Height);
                                DrawMenuButtonLine(_cTempDc.Hdc, _bmpSwirlLineVert, linerect, alphaline);
                            }

                            // draw mist //
                            if (_tSwirlStage.linepos.X < endX / 3)
                            {
                                _ftAlphaGlow += .05f;
                                if (_ftAlphaGlow > .9f)
                                    _ftAlphaGlow = .9f;
                            }
                            else
                            {
                                _ftAlphaGlow -= .05f;
                                if (_ftAlphaGlow < .1f)
                                    _ftAlphaGlow = .1f;
                            }
                            // position
                            cliprect = _tSwirlStage.mask;
                            cliprect.Inflate(1, 1);
                            cliprect.Offset(1, 1);
                            mistrect = new Rectangle(_tSwirlStage.mask.Left, _tSwirlStage.mask.Top, _bmpSwirlGlow.Width, _bmpSwirlGlow.Height);
                            offset = (int)(ShadowDepth * .7f);
                            mistrect.Offset(-offset, -offset);

                            // draw _ftAlphaGlow
                            DrawMenuButtonMist(_cTempDc.Hdc, _bmpSwirlGlow, cliprect, mistrect, _ftAlphaGlow);
                            // counters
                            _tSwirlStage.linepos.X++;
                            _tSwirlStage.tick++;
                            // reset
                            if (_tSwirlStage.linepos.X > (endX - _tSwirlStage.linepos.X))
                            {
                                _tSwirlStage.stage = 1;
                                _tSwirlStage.tick = 0;
                                _ftAlphaGlow = 0;
                                _ftAlphaLine = 0;
                            }
                            break;
                        }
                    #endregion

                    #region Stage 2 - Bottom
                    case 1:
                        {
                            endX = _tSwirlStage.mask.Width / 2;
                            if (_tSwirlStage.tick == 0)
                            {
                                _tSwirlStage.linepos.X = _tSwirlStage.mask.X + (int)CornerRadius;
                                _tSwirlStage.linepos.Y = _tSwirlStage.mask.Bottom - 1;
                                _ftAlphaLine = .7f;
                                _ftAlphaGlow = .35f;
                            }

                            // get alpha
                            if (endX - _tSwirlStage.linepos.X > 0)
                            {
                                // set alpha
                                _ftAlphaLine -= .02f;
                                if (_ftAlphaLine < .2f)
                                    _ftAlphaLine = .2f;
                                // draw bottom sprite
                                linerect = new Rectangle(_tSwirlStage.linepos.X, _tSwirlStage.linepos.Y, _bmpSwirlLine.Width, _bmpSwirlLine.Height);
                                DrawMenuButtonLine(_cTempDc.Hdc, _bmpSwirlLine, linerect, _ftAlphaLine);

                                // draw mist //
                                // calculate alpha
                                if (_tSwirlStage.linepos.X < endX / 3)
                                {
                                    _ftAlphaGlow += .05f;
                                    if (_ftAlphaGlow > .95f)
                                        _ftAlphaGlow = .95f;
                                }
                                else
                                {
                                    _ftAlphaGlow -= .05f;
                                    if (_ftAlphaGlow < .1f)
                                        _ftAlphaGlow = .1f;
                                }
                                // position
                                cliprect = _tSwirlStage.mask;
                                cliprect.Inflate(1, 1);
                                cliprect.Offset(1, 1);
                                mistrect = new Rectangle(_tSwirlStage.mask.Left, _tSwirlStage.mask.Bottom - (_bmpSwirlGlow.Height / 2), _bmpSwirlGlow.Width, _bmpSwirlGlow.Height);
                                offset = (int)(ShadowDepth * .32f);
                                mistrect.Offset(-(offset * 2), -offset);//1.1: shifted left to match top -ju

                                // draw
                                DrawMenuButtonMist(_cTempDc.Hdc, _bmpSwirlGlow, cliprect, mistrect, _ftAlphaGlow);
                            }
                            // counters
                            _tSwirlStage.linepos.X++;
                            _tSwirlStage.tick++;
                            // reset
                            if (_tSwirlStage.linepos.X > (endX - _tSwirlStage.linepos.X))
                            {
                                _tSwirlStage.stage = 2;
                                _tSwirlStage.tick = 0;
                                _ftAlphaGlow = 0;
                                _ftAlphaLine = 0;
                            }
                            break;
                        }
                    #endregion

                    #region Stage 3 - Right Side
                    case 2:
                        {
                            endY = _tSwirlStage.mask.Top + (int)CornerRadius;
                            if (_tSwirlStage.tick == 0)
                            {
                                _tSwirlStage.linepos.X = _tSwirlStage.mask.Right - 1;
                                _tSwirlStage.linepos.Y = (int)(_tSwirlStage.mask.Bottom * .4f);
                                _ftAlphaLine = .7f;
                                _ftAlphaGlow = .1f;
                            }

                            // get alpha
                            if (_tSwirlStage.linepos.Y - endY > 0)
                            {
                                _ftAlphaLine -= .02f;
                                if (_ftAlphaLine < .3f)
                                    _ftAlphaLine = .3f;

                                // adjust height of sprite as it crosses the edge
                                int height = _bmpSwirlLineVert.Height;
                                if (height > _tSwirlStage.linepos.Y - endY)
                                    height = _tSwirlStage.linepos.Y - endY;
                                // draw right side sprite
                                linerect = new Rectangle(_tSwirlStage.linepos.X, _tSwirlStage.linepos.Y, _bmpSwirlLineVert.Width, height);
                                DrawMenuButtonLine(_cTempDc.Hdc, _bmpSwirlLineVert, linerect, _ftAlphaLine);

                                // draw mist //
                                // calculate alpha
                                if (_tSwirlStage.linepos.Y > _tSwirlStage.mask.Bottom / 4)
                                {
                                    _ftAlphaGlow += .05f;
                                    if (_ftAlphaGlow > .7f)
                                        _ftAlphaGlow = .7f;
                                }
                                else
                                {
                                    _ftAlphaGlow -= .05f;
                                    if (_ftAlphaGlow < .3f)
                                        _ftAlphaGlow = .3f;
                                }
                                cliprect = _tSwirlStage.mask;
                                cliprect.Inflate(1, 1);
                                cliprect.Offset(1, 1);

                                mistrect = new Rectangle(cliprect.Right - _bmpSwirlGlowVert.Width, cliprect.Top, _bmpSwirlGlowVert.Width, _bmpSwirlGlowVert.Height);
                                offset = (int)(ShadowDepth * .8f);
                                mistrect.Offset(offset, -offset);
                                // draw
                                DrawMenuButtonMist(_cTempDc.Hdc, _bmpSwirlGlowVert, cliprect, mistrect, _ftAlphaGlow);
                            }
                            // counters
                            _tSwirlStage.linepos.Y--;
                            _tSwirlStage.tick++;
                            // reset
                            if (_tSwirlStage.linepos.Y < (endY))
                            {
                                _tSwirlStage.stage = 3;
                                _tSwirlStage.tick = 0;
                                _ftAlphaGlow = 0;
                                _ftAlphaLine = 0;
                            }
                            break;
                        }
                    #endregion

                    #region Stage 4 - Top
                    case 3:
                        {
                            endX = (_tSwirlStage.mask.Right / 2);
                            if (_tSwirlStage.tick == 0)
                            {
                                _tSwirlStage.linepos.X = _tSwirlStage.mask.Right - (int)CornerRadius;
                                _tSwirlStage.linepos.Y = _tSwirlStage.mask.Y;
                                _ftAlphaGlow = .3f;
                                _ftAlphaLine = .9f;
                            }

                            if (_tSwirlStage.linepos.X - endX > 0)
                            {
                                // get the alpha
                                _ftAlphaLine -= .02f;
                                if (_ftAlphaLine < .2f)
                                    _ftAlphaLine = .2f;
                                // adjust width
                                int width = _bmpSwirlLine.Width;
                                if (width > _tSwirlStage.mask.Right - _tSwirlStage.linepos.X)
                                    width = _tSwirlStage.mask.Right - _tSwirlStage.linepos.X;

                                // draw top sprite
                                linerect = new Rectangle(_tSwirlStage.linepos.X, _tSwirlStage.linepos.Y, width, _bmpSwirlLine.Height);
                                DrawMenuButtonLine(_cTempDc.Hdc, _bmpSwirlLine, linerect, _ftAlphaLine);

                                // draw mist // no mist on last pass (optional)
                                // calculate alpha
                                /*if (_tSwirlStage.linepos.X > _tSwirlStage.mask.Right - (endX / 2))
                                {
                                    _ftAlphaGlow += .05f;
                                    if (_ftAlphaGlow > .7f)
                                        _ftAlphaGlow = .7f;
                                }
                                else
                                {
                                    _ftAlphaGlow -= .05f;
                                    if (_ftAlphaGlow < .1f)
                                        _ftAlphaGlow = .1f;
                                }
                                // position
                                cliprect = _tSwirlStage.mask;
                                cliprect.Inflate(1, 1);
                                cliprect.Offset(1, 1);
                                mistrect = new Rectangle(endX, 0, _bmpSwirlGlow.Width, _bmpSwirlGlow.Height);
                                offset = (int)(ShadowDepth * .5f);
                                mistrect.Offset(-offset * 2, -offset);

                                // draw
                                DrawMenuButtonMist(_cSwirlDc.Hdc, _bmpSwirlGlow, cliprect, mistrect, _ftAlphaGlow);*/
                            }
                            // counters
                            _tSwirlStage.linepos.X--;
                            _tSwirlStage.tick++;
                            // reset
                            if (_tSwirlStage.linepos.X < endX)
                            {
                                _tSwirlStage.stage = 0;
                                _tSwirlStage.tick = 0;
                                _ftAlphaGlow = 0;
                                _ftAlphaLine = 0;
                            }
                            break;
                        }
                        #endregion
                }

                // draw to control
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    BitBlt(g.GetHdc(), 0, 0, _cTempDc.Width, _cTempDc.Height, _cTempDc.Hdc, 0, 0, 0xCC0020);
                    g.ReleaseHdc();
                }
                RECT r = new RECT(0, 0, this.Width, this.Height);
                ValidateRect(this.Handle, ref r);
            }
        }
        #endregion

        #region Timers
        /// <summary>
        /// Create the images and initiate Fader class
        /// </summary>
        /// <param name="sizein">if set to <c>true</c> [sizein].</param>
        private void StartResizeTimer(bool sizein)
        {
            if (_cResizeTimer != null)
                StopResizeTimer();
            // start the timer
            if (_cResizeTimer == null)
            {
                CreateResize();
                _bResizeTimerOn = true;
                _cResizeTimer = new FadeTimer(this);
                _cResizeTimer.Tick += new FadeTimer.TickDelegate(_cResizeTimer_Tick);
                _cResizeTimer.Complete += new FadeTimer.CompleteDelegate(_cResizeTimer_Complete);
                _cResizeTimer.Interval = 10;
                _cResizeTimer.TickMaximum = 8;
                if (sizein)
                {
                    _cResizeTimer.TickCount = 8;
                    _cResizeTimer.Fade(FadeTimer.FadeType.FadeOut);
                }
                else
                {
                    _cResizeTimer.Fade(FadeTimer.FadeType.FadeIn);
                }
            }
        }

        /// <summary>
        /// Dispose of Fader class and reset
        /// </summary>
        private void StopResizeTimer()
        {
            if (_cResizeTimer != null)
            {
                // tear down the timer class
                _cResizeTimer.Reset();
                _cResizeTimer.Tick -= _cResizeTimer_Tick;
                _cResizeTimer.Complete -= _cResizeTimer_Complete;
                _cResizeTimer.Dispose();
                _cResizeTimer = null;
                _bResizeTimerOn = false;
                _eButtonState = ButtonSelectedState.Focused;
                DrawButton();
                ClickThis();
            }
        }

        /// <summary>
        /// Setup of buffer dc and Fade timer
        /// </summary>
        private void StartSwirlTimer()
        {
            if (_cSwirlTimer == null)
            {
                _bSwirlTimerOn = true;
                if (_cTempDc != null)
                    _cTempDc.Dispose();
                _cTempDc = new cStoreDc();
                _cTempDc.Width = _cButtonDc.Width;
                _cTempDc.Height = _cButtonDc.Height;
                BitBlt(_cTempDc.Hdc, 0, 0, _cButtonDc.Width, _cButtonDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);
                // timer setup
                _cSwirlTimer = new FadeTimer(this);
                _cSwirlTimer.Tick += new FadeTimer.TickDelegate(_cSwirlTimer_Tick);
                _cSwirlTimer.Complete += new FadeTimer.CompleteDelegate(_cSwirlTimer_Complete);
                if (this.Image != null)
                {
                    if (Image.Width > 128)//v1.1 added some delay adjsutments ju
                        _cSwirlTimer.Interval = 28;
                    else if (Image.Width < 128)
                        _cSwirlTimer.Interval = 36;
                    else
                        _cSwirlTimer.Interval = 32;
                }
                else
                {
                    _cSwirlTimer.Interval = 32;
                }
                _cSwirlTimer.Fade(FadeTimer.FadeType.Loop);
            }
        }

        /// <summary>
        /// Dispose Fader and resources
        /// </summary>
        private void StopSwirlTimer()
        {
            if (_cSwirlTimer != null)
            {
                if (_cTempDc != null)
                    _cTempDc.Dispose();
                // tear down the timer class
                _cSwirlTimer.Reset();
                _cSwirlTimer.Tick -= _cSwirlTimer_Tick;
                _cSwirlTimer.Complete -= _cSwirlTimer_Complete;
                _cSwirlTimer.Dispose();
                _cSwirlTimer = null;
                _bSwirlTimerOn = false;
            }
        }
        #endregion

        #region Callbacks
        /// <summary>
        /// cs the resize timer complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cResizeTimer_Complete(object sender)
        {
            ResetCallback rs = new ResetCallback(StopResizeTimer);
            this.Invoke(rs);
        }

        /// <summary>
        /// cs the resize timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cResizeTimer_Tick(object sender)
        {
            if (_eButtonState == ButtonSelectedState.Depressed)
                _cResizeTimer.FadeStyle = FadeTimer.FadeType.FadeOut;
            DrawResized();
        }

        /// <summary>
        /// cs the swirl timer complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cSwirlTimer_Complete(object sender)
        {
            ResetCallback rs = new ResetCallback(StopSwirlTimer);
            this.Invoke(rs);
        }

        /// <summary>
        /// cs the swirl timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cSwirlTimer_Tick(object sender)
        {
            DrawSwirl();
        }
        #endregion
        #endregion

        #region Media Button
        #region Drawing
        /// <summary>
        /// Media style Render hub
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        private void DrawMediaButton(Rectangle bounds)
        {
            if (_cButtonDc != null)
            {
                Rectangle imageRect = new Rectangle();

                if (Image != null)
                    imageRect = GetImageRectangle(ImageAlign, bounds, new Rectangle(0, 0, Image.Width, Image.Height));

                using (Graphics g = Graphics.FromHdc(_cButtonDc.Hdc))
                {
                    // backfill dc
                    DrawButtonBackGround(g, bounds);
                    switch (_eButtonState)
                    {
                        case ButtonSelectedState.Checked:
                        case ButtonSelectedState.Depressed:
                        case ButtonSelectedState.Focused:
                        case ButtonSelectedState.Hover:
                            if (Image != null)
                                DrawImage(g, Image, imageRect);
                            DrawButtonBorder(g, bounds);
                            DrawButtonMask(g, bounds, 140, 70f);
                            break;
                        case ButtonSelectedState.Pressed:
                            if (Image != null)
                            {
                                if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                    AlphaBlend(g, (Bitmap)Image, imageRect, .8f);
                                else
                                    DrawImage(g, Image, imageRect);
                            }
                            DrawButtonMask(g, bounds, 140, 70f);
                            break;
                        case ButtonSelectedState.Disabled:
                            if (Image != null)
                                DrawDisabledImage(g, Image, imageRect);
                            break;
                        case ButtonSelectedState.None:
                            // draw image
                            if (Image != null)
                            {
                                if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                    AlphaBlend(g, (Bitmap)Image, imageRect, .8f);
                                else
                                    DrawImage(g, Image, imageRect);
                            }
                            break;
                    }
                }

                // draw to control
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    BitBlt(g.GetHdc(), 0, 0, _cButtonDc.Width, _cButtonDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);
                    g.ReleaseHdc();
                }
                RECT r = new RECT(0, 0, this.Width, this.Height);
                ValidateRect(this.Handle, ref r);
            }
        }

        #endregion
        #endregion

        #region Custom Button
        #region Drawing
        /// <summary>
        /// Custom style Render hub
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        private void DrawCustomButton(Rectangle bounds)
        {
            if (_cButtonDc != null)
            {
                Rectangle imageRect = new Rectangle();

                if (Image != null)
                    imageRect = GetImageRectangle(ImageAlign, bounds, new Rectangle(0, 0, Image.Width, Image.Height));
                else
                    imageRect = bounds;
                using (Graphics g = Graphics.FromHdc(_cButtonDc.Hdc))
                {
                    if (!_bSwishTimerOn)
                    {
                        // backfill dc
                        DrawButtonBackGround(g, bounds);
                        // no text on player buttons
                        if (this.Text.Length != 0)
                        {
                            SizeF sz = MeasureText(this.Text);
                            Rectangle textRect = GetTextRectangle(TextAlign, bounds, new Rectangle(0, 0, (int)sz.Width, (int)sz.Height));
                            DrawText(g, this.Text, textRect);
                        }
                    }
                    switch (_eButtonState)
                    {
                        case ButtonSelectedState.Checked:
                        case ButtonSelectedState.Depressed:
                            if (_bSwishTimerOn)
                            {
                                StopSwishTimer();
                            }
                            else
                            {
                                if (Image != null)
                                {
                                    if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                        AlphaBlend(g, (Bitmap)Image, imageRect, .8f);
                                    else
                                        DrawImage(g, Image, imageRect);
                                }
                                DrawButtonBorder(g, bounds);
                                DrawButtonMask(g, bounds, 100, 80f);
                            }
                            break;
                        case ButtonSelectedState.Pressed:
                            if (_bPulseTimerOn)
                                StopPulseTimer();
                            if (!_bSwishTimerOn)
                            {
                                if (Image != null)
                                {
                                    if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                        AlphaBlend(g, (Bitmap)Image, imageRect, .8f);
                                    else
                                        DrawImage(g, Image, imageRect);
                                }
                                // DrawCustomButtonBorder(g, bounds);
                                DrawButtonMask(g, bounds, 100, 80f);
                                // swish
                                StartSwishTimer();
                            }
                            break;
                        case ButtonSelectedState.Disabled:
                            if (_bSwishTimerOn)
                                StopSwishTimer();
                            if (_bPulseTimerOn)
                                StopPulseTimer();
                            if (Image != null)
                                DrawDisabledImage(g, Image, imageRect);
                            break;
                        case ButtonSelectedState.Focused:
                        case ButtonSelectedState.Hover:
                            if (_bSwishTimerOn)
                                StopSwishTimer();
                            if (!_bPulseTimerOn)
                            {
                                if (Image != null)
                                {
                                    if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                        AlphaBlend(g, (Bitmap)Image, imageRect, .8f);
                                    else
                                        DrawImage(g, Image, imageRect);
                                }
                                DrawButtonBorder(g, bounds);
                                DrawButtonMask(g, bounds, 100, 80f);
                                // pulse
                                StartPulseTimer();
                            }
                            else // v1.1 added to correct redraw on hover/focus ju
                            {
                                if (this.Focused && _eButtonState == ButtonSelectedState.Hover)
                                {
                                    if (Image != null)
                                    {
                                        if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                            AlphaBlend(g, (Bitmap)Image, imageRect, .8f);
                                        else
                                            DrawImage(g, Image, imageRect);
                                    }
                                    DrawButtonBorder(g, bounds);
                                    DrawButtonMask(g, bounds, 100, 80f);
                                }
                            }
                            break;
                        case ButtonSelectedState.None:
                            if (_bSwishTimerOn)
                                StopSwishTimer();
                            if (_bPulseTimerOn)
                                StopPulseTimer();
                            // draw image
                            if (Image != null)
                            {
                                if (Image.IsAlphaPixelFormat(PixelFormat.Alpha))
                                    AlphaBlend(g, (Bitmap)Image, imageRect, .8f);
                                else
                                    DrawImage(g, Image, imageRect);
                            }
                            break;
                    }
                }

                if (!(_bSwishTimerOn || _bPulseTimerOn))
                {
                    // draw to control
                    using (Graphics g = Graphics.FromHwnd(this.Handle))
                    {
                        BitBlt(g.GetHdc(), 0, 0, _cButtonDc.Width, _cButtonDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);
                        g.ReleaseHdc();
                    }
                    RECT r = new RECT(0, 0, this.Width, this.Height);
                    ValidateRect(this.Handle, ref r);
                }
            }
        }
        #endregion

        #region Pulse Effect
        /// <summary>
        /// Draw the pulse effect, called by PulseTimer
        /// </summary>
        private void DrawPulse()
        {
            int width = (int)(this.Width * .9f);
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            bounds.Inflate(-2, -2);
            float fy = bounds.Height * .6f;
            float fx = bounds.Width * .7f;

            // copy unaltered image into buffer
            BitBlt(_cTempDc.Hdc, 0, 0, _cTempDc.Width, _cTempDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);

            // calculate pulse glow levels and state
            if (_bPulseFading)
                _iPulseTick--;
            else
                _iPulseTick++;

            if (_iPulseTick > 40)
            {
                _iPulseTick = 40;
                _bPulseFading = true;
            }
            else if (_iPulseTick < 0)
            {
                _iPulseTick = 1;
                _bPulseFading = false;
            }

            int opacity = _iPulseTick;
            // draw a gradient edge, transparent at center to a white outer edge
            using (Graphics g = Graphics.FromHdc(_cTempDc.Hdc))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                {
                    using (GraphicsPath gp = CreateRoundRectanglePath(g, bounds.X, bounds.Y,
                        bounds.Width, bounds.Height, CornerRadius))
                    {
                        // create an inner rectangle along inner edge of white semi-transparent
                        using (PathGradientBrush borderBrush = new PathGradientBrush(gp))
                        {
                            borderBrush.CenterColor = Color.Transparent;
                            borderBrush.SurroundColors = new Color[] { Color.FromArgb(opacity, Color.White) };
                            borderBrush.CenterPoint = new PointF(fx, fy);
                            borderBrush.FocusScales = new PointF(.95f, .4f);
                            g.FillPath(borderBrush, gp);
                        }
                    }
                }
            }
            // draw to control
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                BitBlt(g.GetHdc(), 0, 0, _cTempDc.Width, _cTempDc.Height, _cTempDc.Hdc, 0, 0, 0xCC0020);
                g.ReleaseHdc();
            }
            RECT r = new RECT(0, 0, this.Width, this.Height);
            ValidateRect(this.Handle, ref r);
        }
        #endregion

        #region Swish Effect
        /// <summary>
        /// Create the swish effect bitmap
        /// </summary>
        private void CreateSwish()
        {
            DestroySwish();
            int height = (int)(this.Height * .6f);
            int width = this.Width;
            Rectangle imageRect = new Rectangle(0, 0, width, height);

            float fy = imageRect.Height * .3f;
            float fx = imageRect.Width * .8f;

            _bmpSwish = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(_bmpSwish))
            {
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                {
                    g.CompositingMode = CompositingMode.SourceOver;

                    // draw sprite
                    using (GraphicsPath gp = new GraphicsPath())
                    {
                        gp.AddEllipse(imageRect);
                        // create an inner rectangle along inner edge of white semi-transparent
                        using (PathGradientBrush borderBrush = new PathGradientBrush(gp))
                        {
                            borderBrush.CenterColor = Color.FromArgb(160, Color.White);
                            borderBrush.SurroundColors = new Color[] { Color.Transparent };
                            borderBrush.CenterPoint = new PointF(fx, fy);
                            borderBrush.FocusScales = new PointF(.4f, .1f);
                            g.FillPath(borderBrush, gp);
                        }
                    }
                }
            }
            // make transparent
            _bmpSwish.MakeTransparent();
        }

        /// <summary>
        /// Dispose of swish bitmap
        /// </summary>
        private void DestroySwish()
        {
            if (_bmpSwish != null)
            {
                _bmpSwish.Dispose();
                _bmpSwish = null;
            }
        }

        /// <summary>
        /// Draw the swish effect, called by SwishTimer
        /// </summary>
        private void DrawSwish()
        {
            int width = this.Width;

            if (_tSwishStage.tick == 0)
            {
                int offY = (int)(this.Height * .2f);
                if (_tSwishStage.cycled)
                    _tSwishStage.pos = -(width * 2);
                else
                    _tSwishStage.pos = -width;
                _tSwishStage.mask = new Rectangle(_tSwishStage.pos, offY, _bmpSwish.Width, _bmpSwish.Height);
            }
            _tSwishStage.tick++;

            // copy unaltered image into buffer
            BitBlt(_cTempDc.Hdc, 0, 0, _cTempDc.Width, _cTempDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);

            using (Graphics g = Graphics.FromHdc(_cTempDc.Hdc))
            {
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.AntiAlias))
                {
                    g.CompositingMode = CompositingMode.SourceOver;
                    // two stages fast/slow
                    if (!_tSwishStage.cycled)
                    {
                        _tSwishStage.pos += 24;//v1.1 running a little faster
                        _tSwishStage.mask.X = (int)_tSwishStage.pos;
                        AlphaBlend(g, _bmpSwish, _tSwishStage.mask, .8f);
                    }
                    else
                    {
                        _tSwishStage.pos += 6;
                        _tSwishStage.mask.X = (int)_tSwishStage.pos;
                        AlphaBlend(g, _bmpSwish, _tSwishStage.mask, .4f);
                    }
                }
            }
            // reset cycle
            if (_tSwishStage.pos > width)
            {
                _tSwishStage.cycled = true;
                _tSwishStage.tick = 0;
            }
            // draw to control
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {
                BitBlt(g.GetHdc(), 0, 0, _cTempDc.Width, _cTempDc.Height, _cTempDc.Hdc, 0, 0, 0xCC0020);
                g.ReleaseHdc();
            }
            RECT r = new RECT(0, 0, this.Width, this.Height);
            ValidateRect(this.Handle, ref r);
        }
        #endregion

        #region Timers
        /// <summary>
        /// Create dc, and setup Fade Timer
        /// </summary>
        private void StartPulseTimer()
        {
            if (_cPulseTimer == null)
            {
                _bPulseTimerOn = true;
                _iPulseTick = 0;
                if (_cTempDc != null)
                    _cTempDc.Dispose();
                _cTempDc = new cStoreDc();
                _cTempDc.Width = _cButtonDc.Width;
                _cTempDc.Height = _cButtonDc.Height;
                // blit clean image in
                BitBlt(_cTempDc.Hdc, 0, 0, _cButtonDc.Width, _cButtonDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);
                // timer setup
                _cPulseTimer = new FadeTimer(this);
                _cPulseTimer.Tick += new FadeTimer.TickDelegate(_cPulseTimer_Tick);
                _cPulseTimer.Complete += new FadeTimer.CompleteDelegate(_cPulseTimer_Complete);
                _cPulseTimer.Interval = 40;
                _cPulseTimer.Fade(FadeTimer.FadeType.Loop);
            }
        }

        /// <summary>
        /// Dispose of timer and temp dc
        /// </summary>
        private void StopPulseTimer()
        {
            if (_cPulseTimer != null)
            {
                if (_cTempDc != null)
                    _cTempDc.Dispose();
                // tear down the timer class
                _cPulseTimer.Reset();
                _cPulseTimer.Tick -= _cPulseTimer_Tick;
                _cPulseTimer.Complete -= _cPulseTimer_Complete;
                _cPulseTimer.Dispose();
                _cPulseTimer = null;
                _bPulseTimerOn = false;
            }
        }

        /// <summary>
        /// Create the bitmaps, temp dc, and Start the Fade Timer
        /// </summary>
        private void StartSwishTimer()
        {
            if (_cSwishTimer == null)
            {
                _bSwishTimerOn = true;
                CreateSwish();
                // set up the dc
                if (_cTempDc != null)
                    _cTempDc.Dispose();
                _cTempDc = new cStoreDc();
                _cTempDc.Width = _cButtonDc.Width;
                _cTempDc.Height = _cButtonDc.Height;
                // blit in clean button
                BitBlt(_cTempDc.Hdc, 0, 0, _cButtonDc.Width, _cButtonDc.Height, _cButtonDc.Hdc, 0, 0, 0xCC0020);
                // reset stage
                _tSwishStage = new SwishStage(false);
                // timer setup
                _cSwishTimer = new FadeTimer(this);
                _cSwishTimer.Tick += new FadeTimer.TickDelegate(_cSwishTimer_Tick);
                _cSwishTimer.Complete += new FadeTimer.CompleteDelegate(_cSwishTimer_Complete);
                _cSwishTimer.Interval = 10;
                _cSwishTimer.Fade(FadeTimer.FadeType.Loop);
            }
        }

        /// <summary>
        /// Dispose resources and timer teardown
        /// </summary>
        private void StopSwishTimer()
        {
            if (_cSwishTimer != null)
            {
                if (_cTempDc != null)
                    _cTempDc.Dispose();
                // tear down the timer class
                _cSwishTimer.Reset();
                _cSwishTimer.Tick -= _cSwishTimer_Tick;
                _cSwishTimer.Complete -= _cSwirlTimer_Complete;
                _cSwishTimer.Dispose();
                _cSwishTimer = null;
                _bSwishTimerOn = false;
                _eButtonState = ButtonSelectedState.Focused;
                ClickThis();
                DrawButton();
            }
        }
        #endregion

        #region Callbacks
        /// <summary>
        /// cs the pulse timer complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cPulseTimer_Complete(object sender)
        {
            ResetCallback rs = new ResetCallback(StopPulseTimer);
            this.Invoke(rs);
        }

        /// <summary>
        /// cs the pulse timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cPulseTimer_Tick(object sender)
        {
            DrawPulse();
        }

        /// <summary>
        /// cs the swish timer complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cSwishTimer_Complete(object sender)
        {
            ResetCallback rs = new ResetCallback(StopSwishTimer);
            this.Invoke(rs);
        }

        /// <summary>
        /// cs the swish timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cSwishTimer_Tick(object sender)
        {
            DrawSwish();
        }
        #endregion
        #endregion

        #region Helpers
        /// <summary>
        /// AlphaBlend an image, alpha .1-1
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bmp">The BMP.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="alpha">The alpha.</param>
        private void AlphaBlend(Graphics g, Bitmap bmp, Rectangle bounds, float alpha)
        {
            if (alpha > 1f)
                alpha = 1f;
            else if (alpha < .01f)
                alpha = .01f;
            using (ImageAttributes ia = new ImageAttributes())
            {
                ColorMatrix cm = new ColorMatrix();
                cm.Matrix00 = 1f;
                cm.Matrix11 = 1f;
                cm.Matrix22 = 1f;
                cm.Matrix44 = 1f;
                cm.Matrix33 = alpha;
                ia.SetColorMatrix(cm);
                g.DrawImage(bmp, bounds, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia);
            }
        }

        /// <summary>
        /// Fires click event after animation has concluded
        /// </summary>
        private void ClickThis()
        {
            if (_cMouseEventArgs != null)
            {
                _bAnimationComplete = true;
                OnMouseClick(_cMouseEventArgs);
                _bAnimationComplete = false;
                _cMouseEventArgs = null;
            }
        }

        /// <summary>
        /// Create a round GraphicsPath [not used]
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateRoundPath(Graphics g, Rectangle bounds)
        {
            int size = bounds.Width > bounds.Height ? bounds.Height : bounds.Width;
            bounds.Height = size;
            bounds.Width = size;
            GraphicsPath circlePath = new GraphicsPath();
            // create the path
            circlePath.AddEllipse(bounds);
            circlePath.CloseFigure();
            return circlePath;
        }

        /// <summary>
        /// Create a rounded rectangle GraphicsPath
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateRoundRectanglePath(Graphics g, float x, float y, float width, float height, float radius)
        {
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            pathBounds.AddLine(x + radius, y, x + width - (radius * 2), y);
            pathBounds.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            pathBounds.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            pathBounds.AddLine(x + width - (radius * 2), y + height, x + radius, y + height);
            pathBounds.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            pathBounds.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            pathBounds.CloseFigure();
            return pathBounds;
        }

        /// <summary>
        /// Get the size an offsets of an image within container
        /// </summary>
        /// <param name="align">The align.</param>
        /// <param name="containerRect">The container rect.</param>
        /// <param name="imageRect">The image rect.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle GetImageRectangle(Alignment align, Rectangle containerRect, Rectangle imageRect)
        {
            Rectangle dest = new Rectangle(0, 0, imageRect.Width, imageRect.Height);
            int x = 0;
            int y = 0;
            if (this.Text.Length > 0 && Style != ButtonStyle.MediaButton)
            {
                SizeF sz = MeasureText(this.Text);
                containerRect.Height -= (int)sz.Height + this.TextPadding.Top + this.TextPadding.Bottom;
            }

            switch (align)
            {
                case Alignment.BottomCenter:
                    x = (containerRect.Width - imageRect.Width) / 2;
                    y = containerRect.Height - imageRect.Height;
                    break;
                case Alignment.BottomLeft:
                    x = 0;
                    y = containerRect.Height - imageRect.Height;
                    break;
                case Alignment.BottomRight:
                    x = containerRect.Width - imageRect.Width;
                    y = containerRect.Height - imageRect.Height;
                    break;
                case Alignment.MiddleCenter:
                    x = (containerRect.Width - imageRect.Width) / 2;
                    y = (containerRect.Height - imageRect.Height) / 2;
                    break;
                case Alignment.MiddleLeft:
                    x = 0;
                    y = (containerRect.Height - imageRect.Height) / 2;
                    break;
                case Alignment.MiddleRight:
                    x = containerRect.Width - imageRect.Width;
                    y = containerRect.Height - imageRect.Height;
                    break;
                case Alignment.TopCenter:
                    x = ((containerRect.Width - imageRect.Width) / 2);
                    y = 0;
                    break;
                case Alignment.TopLeft:
                    x = 0;
                    y = 0;
                    break;
                case Alignment.TopRight:
                    x = containerRect.Width - imageRect.Width;
                    y = 0;
                    break;
            }
            dest.Offset(x, y);
            return dest;
        }

        /// <summary>
        /// Get the size and offsets of text within container
        /// </summary>
        /// <param name="align">The align.</param>
        /// <param name="containerRect">The container rect.</param>
        /// <param name="textRect">The text rect.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle GetTextRectangle(Alignment align, Rectangle containerRect, Rectangle textRect)
        {
            Rectangle dest = new Rectangle(0, 0, textRect.Width, textRect.Height);
            dest.Height += TextPadding.Top + TextPadding.Bottom;
            dest.Width += TextPadding.Right + TextPadding.Left;
            int x = 0;
            int y = 0;

            switch (align)
            {
                case Alignment.BottomCenter:
                    x = (containerRect.Width - (Padding.Left + textRect.Width)) / 2;
                    y = containerRect.Height - (textRect.Height + Padding.Bottom);
                    break;
                case Alignment.BottomLeft:
                    x = Padding.Left;
                    y = containerRect.Height - (textRect.Height + Padding.Bottom);
                    break;
                case Alignment.BottomRight:
                    x = containerRect.Width - (Padding.Right + textRect.Width);
                    y = containerRect.Height - (textRect.Height + Padding.Bottom);
                    break;
                case Alignment.MiddleCenter:
                    x = (containerRect.Width - textRect.Width) / 2;
                    y = (containerRect.Height - textRect.Height) / 2;
                    break;
                case Alignment.MiddleLeft:
                    x = Padding.Left;
                    y = (containerRect.Height - textRect.Height) / 2;
                    break;
                case Alignment.MiddleRight:
                    x = containerRect.Width - (Padding.Right + textRect.Width);
                    y = containerRect.Height - textRect.Height;
                    break;
                case Alignment.TopCenter:
                    x = (containerRect.Width - textRect.Width) / 2;
                    y = Padding.Top;
                    break;
                case Alignment.TopLeft:
                    x = Padding.Left;
                    y = Padding.Top;
                    break;
                case Alignment.TopRight:
                    x = containerRect.Width - (Padding.Right + textRect.Width);
                    y = Padding.Top;
                    break;
            }
            dest.Offset(x, y);
            return dest;
        }

        /// <summary>
        /// Repaint and optionally resize
        /// </summary>
        private void PropertyChange()
        {
            if (this.AutoSize)
                ResizeThis();
            Repaint();
        }

        /// <summary>
        /// Repaint the control
        /// </summary>
        private void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        /// <summary>
        /// Load the primary graphics buffer
        /// </summary>
        private void LoadBuffers()
        {
            // load the buffer
            if (_cButtonDc != null)
                _cButtonDc.Dispose();
            _cButtonDc = new cStoreDc();
            _cButtonDc.Height = this.Height;
            _cButtonDc.Width = this.Width;
            if (_eButtonStyle == ButtonStyle.MenuButton)
                CreateSwirl();
        }

        /// <summary>
        /// Resize the control via image and text size and alignments
        /// </summary>
        private void ResizeThis()
        {
            int width = this.Width;
            int height = this.Height;

            if (Image != null)
            {
                GraphicsUnit gu = GraphicsUnit.Pixel;
                RectangleF rf = _oImage.GetBounds(ref gu);
                // enlarge by image size, shadow and padding
                width = (int)rf.Width + ShadowDepth + this.Padding.Right + this.Padding.Left + this.ImagePadding.Left + this.ImagePadding.Right;
                height = (int)rf.Height + ShadowDepth + this.Padding.Bottom + this.Padding.Top + this.ImagePadding.Top + this.ImagePadding.Bottom;
            }
            if (this.Text.Length != 0 && Style != ButtonStyle.MediaButton)
            {
                SizeF sz;
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                    sz = g.MeasureString(this.Text, this.Font);
                if (this.TextAlign == Alignment.MiddleCenter ||
                    this.TextAlign == Alignment.MiddleLeft ||
                    this.TextAlign == Alignment.MiddleRight)
                {
                    width += (int)sz.Width + this.Padding.Right;
                }
                else
                {
                    height += (int)sz.Height + this.TextPadding.Top + this.TextPadding.Bottom;
                }
            }
            this.Width = width;
            this.Height = height;
            LoadBuffers();
            this.Refresh();
        }

        /// <summary>
        /// Set the style defaults, Custom is the only style without packaged options
        /// </summary>
        /// <param name="style">The style.</param>
        private void SetButtonStyle(ButtonStyle style)
        {
            switch (style)
            {
                case ButtonStyle.MediaButton:
                    this.Padding = new Padding(0, 0, 0, 0);
                    this.ImagePadding = new Padding(0, 0, 0, 0);
                    this.TextPadding = new Padding(0, 0, 0, 0);
                    this.ShadowDepth = 0;
                    this.BorderStyle = ZeroitBorderStyle.Thin;
                    this.CornerRadius = 2;
                    this.ImageAlign = Alignment.MiddleCenter;
                    this.Text = "";
                    break;
                case ButtonStyle.MenuButton:
                    this.Padding = new Padding(8, 8, 8, 8);
                    this.ImagePadding = new Padding(8, 8, 8, 8);
                    this.TextPadding = new Padding(4, 4, 4, 4);
                    this.ShadowDepth = 12;
                    this.BorderStyle = ZeroitBorderStyle.Thin;
                    this.CornerRadius = 2;
                    this.TextAlign = Alignment.BottomRight;
                    this.ImageAlign = Alignment.MiddleCenter;
                    break;
                case ButtonStyle.CustomButton:
                    // this.TextAlign = Alignment.MiddleRight;
                    // this.ImageAlign = Alignment.MiddleLeft;
                    break;
            }
        }

        /// <summary>
        /// Called if a Menu button is focused when form loads,
        /// allows button to finish loading before resize effect engages
        /// </summary>
        /// <param name="ms">The ms.</param>
        private void WaitTimer(int ms)
        {
            int safe = 0;
            int tick = 0;
            do
            {
                if (tick > ms)
                    break;
                tick++;
                safe++;
                Application.DoEvents();
                System.Threading.Thread.CurrentThread.Join(1);
            } while (safe < 100);
        }
        #endregion
        #endregion

        #region Clipping Region
        /// <summary>
        /// Clip rectangles or rounded rectangles
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        internal class ClippingRegion : IDisposable
        {
            #region Enum
            /// <summary>
            /// Enum CombineRgnStyles
            /// </summary>
            private enum CombineRgnStyles : int
            {
                /// <summary>
                /// The RGN and
                /// </summary>
                RGN_AND = 1,
                /// <summary>
                /// The RGN or
                /// </summary>
                RGN_OR = 2,
                /// <summary>
                /// The RGN xor
                /// </summary>
                RGN_XOR = 3,
                /// <summary>
                /// The RGN difference
                /// </summary>
                RGN_DIFF = 4,
                /// <summary>
                /// The RGN copy
                /// </summary>
                RGN_COPY = 5,
                /// <summary>
                /// The RGN minimum
                /// </summary>
                RGN_MIN = RGN_AND,
                /// <summary>
                /// The RGN maximum
                /// </summary>
                RGN_MAX = RGN_COPY
            }
            #endregion

            #region API
            /// <summary>
            /// Selects the clip RGN.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="hrgn">The HRGN.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("gdi32.dll")]
            private static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);

            /// <summary>
            /// Gets the clip RGN.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="hrgn">The HRGN.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("gdi32.dll")]
            private static extern int GetClipRgn(IntPtr hdc, [In, Out]IntPtr hrgn);

            /// <summary>
            /// Creates the rect RGN.
            /// </summary>
            /// <param name="nLeftRect">The n left rect.</param>
            /// <param name="nTopRect">The n top rect.</param>
            /// <param name="nRightRect">The n right rect.</param>
            /// <param name="nBottomRect">The n bottom rect.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

            /// <summary>
            /// Creates the elliptic RGN.
            /// </summary>
            /// <param name="nLeftRect">The n left rect.</param>
            /// <param name="nTopRect">The n top rect.</param>
            /// <param name="nRightRect">The n right rect.</param>
            /// <param name="nBottomRect">The n bottom rect.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateEllipticRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

            /// <summary>
            /// Creates the round rect RGN.
            /// </summary>
            /// <param name="x1">The x1.</param>
            /// <param name="y1">The y1.</param>
            /// <param name="x2">The x2.</param>
            /// <param name="y2">The y2.</param>
            /// <param name="cx">The cx.</param>
            /// <param name="cy">The cy.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

            /// <summary>
            /// Combines the RGN.
            /// </summary>
            /// <param name="hrgnDest">The HRGN dest.</param>
            /// <param name="hrgnSrc1">The HRGN SRC1.</param>
            /// <param name="hrgnSrc2">The HRGN SRC2.</param>
            /// <param name="fnCombineMode">The function combine mode.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("gdi32.dll")]
            private static extern int CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1, IntPtr hrgnSrc2, CombineRgnStyles fnCombineMode);

            /// <summary>
            /// Excludes the clip rect.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="nLeftRect">The n left rect.</param>
            /// <param name="nTopRect">The n top rect.</param>
            /// <param name="nRightRect">The n right rect.</param>
            /// <param name="nBottomRect">The n bottom rect.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("gdi32.dll")]
            private static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

            /// <summary>
            /// Deletes the object.
            /// </summary>
            /// <param name="hObject">The h object.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool DeleteObject(IntPtr hObject);
            #endregion

            #region Fields
            /// <summary>
            /// The h clip region
            /// </summary>
            private IntPtr _hClipRegion;
            /// <summary>
            /// The h dc
            /// </summary>
            private IntPtr _hDc;
            #endregion

            #region Methods
            /// <summary>
            /// Initializes a new instance of the <see cref="ClippingRegion"/> class.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="cliprect">The cliprect.</param>
            /// <param name="canvasrect">The canvasrect.</param>
            public ClippingRegion(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect)
            {
                CreateRectangleClip(hdc, cliprect, canvasrect);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ClippingRegion"/> class.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="cliprect">The cliprect.</param>
            /// <param name="canvasrect">The canvasrect.</param>
            /// <param name="radius">The radius.</param>
            public ClippingRegion(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect, uint radius)
            {
                CreateRoundedRectangleClip(hdc, cliprect, canvasrect, radius);
            }

            /// <summary>
            /// Creates the rectangle clip.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="cliprect">The cliprect.</param>
            /// <param name="canvasrect">The canvasrect.</param>
            public void CreateRectangleClip(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect)
            {
                _hDc = hdc;
                IntPtr clip = CreateRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom);
                IntPtr canvas = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                _hClipRegion = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                CombineRgn(_hClipRegion, canvas, clip, CombineRgnStyles.RGN_DIFF);
                SelectClipRgn(_hDc, _hClipRegion);
                DeleteObject(clip);
                DeleteObject(canvas);
            }

            /// <summary>
            /// Creates the rounded rectangle clip.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="cliprect">The cliprect.</param>
            /// <param name="canvasrect">The canvasrect.</param>
            /// <param name="radius">The radius.</param>
            public void CreateRoundedRectangleClip(IntPtr hdc, Rectangle cliprect, Rectangle canvasrect, uint radius)
            {
                int r = (int)radius;
                _hDc = hdc;
                // create rounded regions
                IntPtr clip = CreateRoundRectRgn(cliprect.Left, cliprect.Top, cliprect.Right, cliprect.Bottom, r, r);
                IntPtr canvas = CreateRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom);
                _hClipRegion = CreateRoundRectRgn(canvasrect.Left, canvasrect.Top, canvasrect.Right, canvasrect.Bottom, r, r);
                CombineRgn(_hClipRegion, canvas, clip, CombineRgnStyles.RGN_DIFF);
                // add it in
                SelectClipRgn(_hDc, _hClipRegion);
                DeleteObject(clip);
                DeleteObject(canvas);
            }

            /// <summary>
            /// Releases this instance.
            /// </summary>
            public void Release()
            {
                if (_hClipRegion != IntPtr.Zero)
                {
                    // remove region
                    SelectClipRgn(_hDc, IntPtr.Zero);
                    // delete region
                    DeleteObject(_hClipRegion);
                }
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                Release();
            }
            #endregion
        }
        #endregion

        #region Graphics Mode
        /// <summary>
        /// Maintains graphic object state
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        internal class GraphicsMode : IDisposable
        {
            #region Fields
            /// <summary>
            /// The g graphic copy
            /// </summary>
            private Graphics _gGraphicCopy;
            /// <summary>
            /// The e old mode
            /// </summary>
            private SmoothingMode _eOldMode;
            #endregion

            #region Methods
            /// <summary>
            /// Initialize a new instance of the class.
            /// </summary>
            /// <param name="g">Graphics instance.</param>
            /// <param name="mode">Desired Smoothing mode.</param>
            public GraphicsMode(Graphics g, SmoothingMode mode)
            {
                _gGraphicCopy = g;
                _eOldMode = _gGraphicCopy.SmoothingMode;
                _gGraphicCopy.SmoothingMode = mode;
            }

            /// <summary>
            /// Revert the SmoothingMode to original setting.
            /// </summary>
            public void Dispose()
            {
                _gGraphicCopy.SmoothingMode = _eOldMode;
            }
            #endregion
        }
        #endregion

        #region Effects Timer
        /// <summary>
        /// Effect timer class
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        internal class FadeTimer : IDisposable
        {
            #region Enum
            /// <summary>
            /// Enum FadeType
            /// </summary>
            internal enum FadeType
            {
                /// <summary>
                /// The none
                /// </summary>
                None = 0,
                /// <summary>
                /// The fade in
                /// </summary>
                FadeIn,
                /// <summary>
                /// The fade out
                /// </summary>
                FadeOut,
                /// <summary>
                /// The fade fast
                /// </summary>
                FadeFast,
                /// <summary>
                /// The loop
                /// </summary>
                Loop
            }
            #endregion

            #region Structs
            /// <summary>
            /// Struct RECT
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="RECT"/> struct.
                /// </summary>
                /// <param name="X">The x.</param>
                /// <param name="Y">The y.</param>
                /// <param name="Width">The width.</param>
                /// <param name="Height">The height.</param>
                public RECT(int X, int Y, int Width, int Height)
                {
                    this.Left = X;
                    this.Top = Y;
                    this.Right = Width;
                    this.Bottom = Height;
                }
                /// <summary>
                /// The left
                /// </summary>
                public int Left;
                /// <summary>
                /// The top
                /// </summary>
                public int Top;
                /// <summary>
                /// The right
                /// </summary>
                public int Right;
                /// <summary>
                /// The bottom
                /// </summary>
                public int Bottom;
            }
            #endregion

            #region API
            /// <summary>
            /// Gets the dc.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("user32.dll")]
            private static extern IntPtr GetDC(IntPtr handle);

            /// <summary>
            /// Releases the dc.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <param name="hdc">The HDC.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("user32.dll")]
            private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

            /// <summary>
            /// Bits the BLT.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="nXDest">The n x dest.</param>
            /// <param name="nYDest">The n y dest.</param>
            /// <param name="nWidth">Width of the n.</param>
            /// <param name="nHeight">Height of the n.</param>
            /// <param name="hdcSrc">The HDC source.</param>
            /// <param name="nXSrc">The n x source.</param>
            /// <param name="nYSrc">The n y source.</param>
            /// <param name="dwRop">The dw rop.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

            /// <summary>
            /// Gets the desktop window.
            /// </summary>
            /// <returns>IntPtr.</returns>
            [DllImport("user32.dll")]
            private static extern IntPtr GetDesktopWindow();

            /// <summary>
            /// Gets the window rect.
            /// </summary>
            /// <param name="hWnd">The h WND.</param>
            /// <param name="lpRect">The lp rect.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
            #endregion

            #region Events
            /// <summary>
            /// Delegate CompleteDelegate
            /// </summary>
            /// <param name="sender">The sender.</param>
            public delegate void CompleteDelegate(object sender);
            /// <summary>
            /// Delegate TickDelegate
            /// </summary>
            /// <param name="sender">The sender.</param>
            public delegate void TickDelegate(object sender);
            /// <summary>
            /// Occurs when [complete].
            /// </summary>
            public event CompleteDelegate Complete;
            /// <summary>
            /// Occurs when [tick].
            /// </summary>
            public event TickDelegate Tick;
            #endregion

            #region Fields
            /// <summary>
            /// The b capture screen
            /// </summary>
            private bool _bCaptureScreen = false;
            /// <summary>
            /// The b cancel timer
            /// </summary>
            private bool _bCancelTimer;
            /// <summary>
            /// The b is reset
            /// </summary>
            private bool _bIsReset;
            /// <summary>
            /// The i tick counter
            /// </summary>
            private int _iTickCounter;
            /// <summary>
            /// The i tick maximum
            /// </summary>
            private int _iTickMaximum;
            /// <summary>
            /// The i tick rate
            /// </summary>
            private double _iTickRate;
            /// <summary>
            /// The e fade type
            /// </summary>
            private FadeType _eFadeType;
            /// <summary>
            /// The c button dc
            /// </summary>
            private cStoreDc _cButtonDc;
            /// <summary>
            /// The ct parent control
            /// </summary>
            private UserControl _ctParentControl;
            /// <summary>
            /// a timer
            /// </summary>
            private System.Timers.Timer _aTimer;
            /// <summary>
            /// The b invalidating
            /// </summary>
            private bool _bInvalidating = false;
            #endregion

            #region Constructor
            /// <summary>
            /// Initializes a new instance of the <see cref="FadeTimer"/> class.
            /// </summary>
            /// <param name="sender">The sender.</param>
            public FadeTimer(object sender)
            {
                _iTickCounter = 0;
                _iTickMaximum = 10;
                _ctParentControl = (UserControl)sender;
                _aTimer = new System.Timers.Timer();
                _iTickRate = _aTimer.Interval;
                _aTimer.SynchronizingObject = (ISynchronizeInvoke)sender;
                _aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            }
            #endregion

            #region Properties
            /// <summary>
            /// Gets or sets the button dc.
            /// </summary>
            /// <value>The button dc.</value>
            public cStoreDc ButtonDc
            {
                get { return _cButtonDc; }
                set { _cButtonDc = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether [capture screen].
            /// </summary>
            /// <value><c>true</c> if [capture screen]; otherwise, <c>false</c>.</value>
            public bool CaptureScreen
            {
                get { return _bCaptureScreen; }
                set { _bCaptureScreen = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="FadeTimer"/> is invalidating.
            /// </summary>
            /// <value><c>true</c> if invalidating; otherwise, <c>false</c>.</value>
            public bool Invalidating
            {
                get { return _bInvalidating; }
                set { _bInvalidating = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is reset.
            /// </summary>
            /// <value><c>true</c> if this instance is reset; otherwise, <c>false</c>.</value>
            public bool IsReset
            {
                get { return _bIsReset; }
                set { _bIsReset = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="FadeTimer"/> is cancel.
            /// </summary>
            /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
            public bool Cancel
            {
                get { return _bCancelTimer; }
                set { _bCancelTimer = value; }
            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="FadeTimer"/> is enabled.
            /// </summary>
            /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
            public bool Enabled
            {
                get { return _aTimer.Enabled; }
            }

            /// <summary>
            /// Gets or sets the fade style.
            /// </summary>
            /// <value>The fade style.</value>
            public FadeType FadeStyle
            {
                get { return _eFadeType; }
                set { _eFadeType = value; }
            }

            /// <summary>
            /// Gets or sets the interval.
            /// </summary>
            /// <value>The interval.</value>
            public double Interval
            {
                get { return _iTickRate; }
                set
                {
                    _iTickRate = value;
                    _aTimer.Interval = _iTickRate;
                }
            }

            /// <summary>
            /// Gets or sets the tick count.
            /// </summary>
            /// <value>The tick count.</value>
            public int TickCount
            {
                get { return _iTickCounter; }
                set { _iTickCounter = value; }
            }

            /// <summary>
            /// Gets or sets the tick maximum.
            /// </summary>
            /// <value>The tick maximum.</value>
            public int TickMaximum
            {
                get { return _iTickMaximum; }
                set { _iTickMaximum = value; }
            }
            #endregion

            #region Public Methods
            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                Reset();
                if (_cButtonDc != null)
                    _cButtonDc.Dispose();
                if (_aTimer != null)
                    _aTimer.Dispose();
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Fades the specified ft.
            /// </summary>
            /// <param name="ft">The ft.</param>
            public void Fade(FadeType ft)
            {
                Cancel = false;
                IsReset = false;
                Invalidating = false;
                _eFadeType = ft;
                if (_eFadeType == FadeType.FadeIn)
                {
                    TickCount = 0;
                    if (CaptureScreen)
                        CaptureDc();
                }
                else if (_eFadeType == FadeType.FadeOut)
                {
                    TickCount = 10;
                }
                else if (_eFadeType == FadeType.FadeFast)
                {
                    TickCount = 10;
                }
                else if (_eFadeType == FadeType.Loop)
                {
                    TickMaximum = 100000;
                    TickCount = 0;
                    if (CaptureScreen)
                        CaptureDc();
                }
                _aTimer.Enabled = true;
            }

            /// <summary>
            /// Stops this instance.
            /// </summary>
            public void Stop()
            {
                _aTimer.Stop();
            }

            /// <summary>
            /// Resets this instance.
            /// </summary>
            public void Reset()
            {
                TickCount = 0;
                _eFadeType = FadeType.None;
                IsReset = true;
                _aTimer.Stop();
                _aTimer.Enabled = false;
            }
            #endregion

            #region Event Handlers
            /// <summary>
            /// Handles the <see cref="E:TimedEvent" /> event.
            /// </summary>
            /// <param name="source">The source.</param>
            /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
            private void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                if (Cancel)
                {
                    Invalidating = true;
                    if (Complete != null) Complete(this);
                    return;
                }
                else
                {
                    switch (_eFadeType)
                    {
                        case FadeType.FadeIn:
                            FadeIn();
                            break;
                        case FadeType.FadeFast:
                            FadeOut();
                            break;
                        case FadeType.FadeOut:
                            FadeOut();
                            break;
                        case FadeType.Loop:
                            FadeLoop();
                            break;
                    }
                }
            }
            #endregion

            #region private Methods
            /// <summary>
            /// Captures the dc.
            /// </summary>
            private void CaptureDc()
            {
                try
                {
                    _cButtonDc.Width = _ctParentControl.Width;
                    _cButtonDc.Height = _ctParentControl.Height;
                    if (_cButtonDc.Hdc != IntPtr.Zero)
                    {
                        using (Graphics g = Graphics.FromHdc(_cButtonDc.Hdc))
                        {
                            RECT boundedRect = new RECT();
                            GetWindowRect(_ctParentControl.Handle, ref boundedRect);
                            g.CopyFromScreen(boundedRect.Left, boundedRect.Top, 0, 0, new Size(_cButtonDc.Width, _cButtonDc.Height), CopyPixelOperation.SourceCopy);
                        }
                    }
                }
                catch { }
            }

            /// <summary>
            /// Fades the in.
            /// </summary>
            private void FadeIn()
            {
                if (TickCount < TickMaximum)
                {
                    TickCount++;
                    if (Tick != null)
                        Tick(this);
                }
                else
                {
                    TickCount = TickMaximum;
                }
            }

            /// <summary>
            /// Fades the loop.
            /// </summary>
            private void FadeLoop()
            {
                if (TickCount < TickMaximum)
                {
                    TickCount++;
                    if (Tick != null)
                        Tick(this);
                }
                else
                {
                    TickCount = TickMaximum;
                    Reset();
                    Invalidating = true;
                    if (Complete != null)
                        Complete(this);
                }
            }

            /// <summary>
            /// Fades the out.
            /// </summary>
            private void FadeOut()
            {
                if (TickCount > 0)
                {
                    if (_eFadeType == FadeType.FadeFast)
                    {
                        TickCount -= 2;
                        if (TickCount < 0)
                            TickCount = 0;
                    }
                    else
                    {
                        TickCount--;
                    }
                    if (Tick != null)
                        Tick(this);
                }
                else
                {
                    Reset();
                    Invalidating = true;
                    if (Complete != null)
                        Complete(this);
                }
            }

            /// <summary>
            /// Finalizes an instance of the <see cref="FadeTimer"/> class.
            /// </summary>
            ~FadeTimer()
            {
                Dispose();
            }
            #endregion
        }
        #endregion

        #region StoreDc
        /// <summary>
        /// DC buffer class
        /// </summary>
        internal class cStoreDc
        {
            #region API
            /// <summary>
            /// Creates the dca.
            /// </summary>
            /// <param name="lpszDriver">The LPSZ driver.</param>
            /// <param name="lpszDevice">The LPSZ device.</param>
            /// <param name="lpszOutput">The LPSZ output.</param>
            /// <param name="lpInitData">The lp initialize data.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateDCA([MarshalAs(UnmanagedType.LPStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPStr)]string lpszOutput, int lpInitData);

            /// <summary>
            /// Creates the DCW.
            /// </summary>
            /// <param name="lpszDriver">The LPSZ driver.</param>
            /// <param name="lpszDevice">The LPSZ device.</param>
            /// <param name="lpszOutput">The LPSZ output.</param>
            /// <param name="lpInitData">The lp initialize data.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPWStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPWStr)]string lpszOutput, int lpInitData);

            /// <summary>
            /// Creates the dc.
            /// </summary>
            /// <param name="lpszDriver">The LPSZ driver.</param>
            /// <param name="lpszDevice">The LPSZ device.</param>
            /// <param name="lpszOutput">The LPSZ output.</param>
            /// <param name="lpInitData">The lp initialize data.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);

            /// <summary>
            /// Creates the compatible dc.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

            /// <summary>
            /// Creates the compatible bitmap.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="nWidth">Width of the n.</param>
            /// <param name="nHeight">Height of the n.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

            /// <summary>
            /// Deletes the dc.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool DeleteDC(IntPtr hdc);

            /// <summary>
            /// Selects the object.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="hgdiobj">The hgdiobj.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true)]
            private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

            /// <summary>
            /// Deletes the object.
            /// </summary>
            /// <param name="hObject">The h object.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool DeleteObject(IntPtr hObject);
            #endregion

            #region Fields
            /// <summary>
            /// The height
            /// </summary>
            private int _Height = 0;
            /// <summary>
            /// The width
            /// </summary>
            private int _Width = 0;
            /// <summary>
            /// The HDC
            /// </summary>
            private IntPtr _Hdc = IntPtr.Zero;
            /// <summary>
            /// The BMP
            /// </summary>
            private IntPtr _Bmp = IntPtr.Zero;
            /// <summary>
            /// The BMP old
            /// </summary>
            private IntPtr _BmpOld = IntPtr.Zero;
            #endregion

            #region Methods
            /// <summary>
            /// Gets the HDC.
            /// </summary>
            /// <value>The HDC.</value>
            public IntPtr Hdc
            {
                get { return _Hdc; }
            }

            /// <summary>
            /// Gets the h BMP.
            /// </summary>
            /// <value>The h BMP.</value>
            public IntPtr HBmp
            {
                get { return _Bmp; }
            }

            /// <summary>
            /// Gets or sets the height.
            /// </summary>
            /// <value>The height.</value>
            public int Height
            {
                get { return _Height; }
                set
                {
                    if (_Height != value)
                    {
                        _Height = value;
                        ImageCreate(_Width, _Height);
                    }
                }
            }

            /// <summary>
            /// Gets or sets the width.
            /// </summary>
            /// <value>The width.</value>
            public int Width
            {
                get { return _Width; }
                set
                {
                    if (_Width != value)
                    {
                        _Width = value;
                        ImageCreate(_Width, _Height);
                    }
                }
            }

            /// <summary>
            /// Selects the image.
            /// </summary>
            /// <param name="image">The image.</param>
            public void SelectImage(Bitmap image)
            {
                if (Hdc != IntPtr.Zero && image != null)
                    SelectObject(Hdc, image.GetHbitmap());
            }

            /// <summary>
            /// Images the create.
            /// </summary>
            /// <param name="Width">The width.</param>
            /// <param name="Height">The height.</param>
            private void ImageCreate(int Width, int Height)
            {
                IntPtr pHdc = IntPtr.Zero;

                ImageDestroy();
                pHdc = CreateDCA("DISPLAY", "", "", 0);
                _Hdc = CreateCompatibleDC(pHdc);
                _Bmp = CreateCompatibleBitmap(pHdc, _Width, _Height);
                _BmpOld = SelectObject(_Hdc, _Bmp);
                if (_BmpOld == IntPtr.Zero)
                {
                    ImageDestroy();
                }
                else
                {
                    _Width = Width;
                    _Height = Height;
                }
                DeleteDC(pHdc);
                pHdc = IntPtr.Zero;
            }

            /// <summary>
            /// Images the destroy.
            /// </summary>
            private void ImageDestroy()
            {
                if (_BmpOld != IntPtr.Zero)
                {
                    SelectObject(_Hdc, _BmpOld);
                    _BmpOld = IntPtr.Zero;
                }
                if (_Bmp != IntPtr.Zero)
                {
                    DeleteObject(_Bmp);
                    _Bmp = IntPtr.Zero;
                }
                if (_Hdc != IntPtr.Zero)
                {
                    DeleteDC(_Hdc);
                    _Hdc = IntPtr.Zero;
                }
            }

            /// <summary>
            /// Disposes this instance.
            /// </summary>
            public void Dispose()
            {
                ImageDestroy();
            }
            #endregion
        }
        #endregion

        

    }

    #endregion

    #region Designer Generated Code

    partial class ZeroitMediaClassicButton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonMediaClassicDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonMediaClassicDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonMediaClassicSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonMediaClassicSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitButtonMediaClassicSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMediaClassicButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonMediaClassicSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonMediaClassicSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMediaClassicButton;

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
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        public ZeroitBorderStyle BorderStyle
        {
            get
            {
                return colUserControl.BorderStyle;
            }
            set
            {
                GetPropertyByName("BorderStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        public uint CornerRadius
        {
            get
            {
                return colUserControl.CornerRadius;
            }
            set
            {
                GetPropertyByName("CornerRadius").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the disabled fore.
        /// </summary>
        /// <value>The color of the disabled fore.</value>
        public Color DisabledForeColor
        {
            get
            {
                return colUserControl.DisabledForeColor;
            }
            set
            {
                GetPropertyByName("DisabledForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the focused fore.
        /// </summary>
        /// <value>The color of the focused fore.</value>
        public Color FocusedForeColor
        {
            get
            {
                return colUserControl.FocusedForeColor;
            }
            set
            {
                GetPropertyByName("FocusedForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [focus on click].
        /// </summary>
        /// <value><c>true</c> if [focus on click]; otherwise, <c>false</c>.</value>
        public bool FocusOnClick
        {
            get
            {
                return colUserControl.FocusOnClick;
            }
            set
            {
                GetPropertyByName("FocusOnClick").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [focus on hover].
        /// </summary>
        /// <value><c>true</c> if [focus on hover]; otherwise, <c>false</c>.</value>
        public bool FocusOnHover
        {
            get
            {
                return colUserControl.FocusOnHover;
            }
            set
            {
                GetPropertyByName("FocusOnHover").SetValue(colUserControl, value);
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
        /// Gets or sets the image focused.
        /// </summary>
        /// <value>The image focused.</value>
        public Image ImageFocused
        {
            get
            {
                return colUserControl.ImageFocused;
            }
            set
            {
                GetPropertyByName("ImageFocused").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public Zeroit.Framework.Button.ZeroitMediaClassicButton.Alignment ImageAlign
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

        /// <summary>
        /// Gets or sets the image padding.
        /// </summary>
        /// <value>The image padding.</value>
        public Padding ImagePadding
        {
            get
            {
                return colUserControl.ImagePadding;
            }
            set
            {
                GetPropertyByName("ImagePadding").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the padding.
        /// </summary>
        /// <value>The padding.</value>
        public Padding Padding
        {
            get
            {
                return colUserControl.Padding;
            }
            set
            {
                GetPropertyByName("Padding").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [resize on load].
        /// </summary>
        /// <value><c>true</c> if [resize on load]; otherwise, <c>false</c>.</value>
        public bool ResizeOnLoad
        {
            get
            {
                return colUserControl.ResizeOnLoad;
            }
            set
            {
                GetPropertyByName("ResizeOnLoad").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [check style].
        /// </summary>
        /// <value><c>true</c> if [check style]; otherwise, <c>false</c>.</value>
        public bool CheckStyle
        {
            get
            {
                return colUserControl.CheckStyle;
            }
            set
            {
                GetPropertyByName("CheckStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the shadow depth.
        /// </summary>
        /// <value>The shadow depth.</value>
        public int ShadowDepth
        {
            get
            {
                return colUserControl.ShadowDepth;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public Zeroit.Framework.Button.ZeroitMediaClassicButton.ButtonStyle Style
        {
            get
            {
                return colUserControl.Style;
            }
            set
            {
                GetPropertyByName("Style").SetValue(colUserControl, value);
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
        public Zeroit.Framework.Button.ZeroitMediaClassicButton.Alignment TextAlign
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
        /// Gets or sets the text padding.
        /// </summary>
        /// <value>The text padding.</value>
        public Padding TextPadding
        {
            get
            {
                return colUserControl.TextPadding;
            }
            set
            {
                GetPropertyByName("TextPadding").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Style",
                                 "Style", "Appearance",
                                 "Sets the type of control."));

            items.Add(new DesignerActionPropertyItem("BorderStyle",
                                 "Border Style", "Appearance",
                                 "Sets the border style."));

            items.Add(new DesignerActionPropertyItem("CornerRadius",
                                 "Corner Radius", "Appearance",
                                 "Sets the corner radius."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("DisabledForeColor",
                                 "Disabled ForeColor", "Appearance",
                                 "Sets the disabled forecolor."));

            items.Add(new DesignerActionPropertyItem("FocusedForeColor",
                                 "Focused ForeColor", "Appearance",
                                 "Sets the focused forecolor."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Sets the image for the background."));

            items.Add(new DesignerActionPropertyItem("ImageFocused",
                                 "Image Focused", "Appearance",
                                 "Sets the image when focused."));

            items.Add(new DesignerActionPropertyItem("ImageAlign",
                                 "Image Align", "Appearance",
                                 "Sets the image alignment."));

            items.Add(new DesignerActionPropertyItem("ImagePadding",
                                 "Image Padding", "Appearance",
                                 "Sets the image padding."));

            items.Add(new DesignerActionPropertyItem("Padding",
                                 "Padding", "Appearance",
                                 "Sets the padding."));

            items.Add(new DesignerActionPropertyItem("ShadowDepth",
                                 "Shadow Depth", "Appearance",
                                 "Sets the depth of the shadow."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the text for this control."));

            items.Add(new DesignerActionPropertyItem("TextAlign",
                                 "Text Align", "Appearance",
                                 "Sets the text alignment for this control."));

            items.Add(new DesignerActionPropertyItem("TextPadding",
                                 "Text Padding", "Appearance",
                                 "Sets the text padding for this control."));

            items.Add(new DesignerActionPropertyItem("FocusOnClick",
                                 "Focus On Click", "Appearance",
                                 "Enable focus when clicked."));

            items.Add(new DesignerActionPropertyItem("FocusOnHover",
                                 "Focus On Hover", "Appearance",
                                 "Enable focus when clicked."));


            items.Add(new DesignerActionPropertyItem("ResizeOnLoad",
                                 "Resize On Load", "Appearance",
                                 "Enable resize when loaded."));

            items.Add(new DesignerActionPropertyItem("CheckStyle",
                                 "Check Style", "Appearance",
                                 "Enable checkstyle."));

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
