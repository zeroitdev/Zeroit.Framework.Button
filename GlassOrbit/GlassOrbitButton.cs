// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="GlassOrbitButton.cs" company="Zeroit Dev Technologies">
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

    #region ZeroitGlassOrbit

    /// <summary>
    /// A class collection for rendering Orbit Button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitGlassOrbitDesigner))]
    public class ZeroitOrbitButton : UserControl
    {
        #region Private Fields
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer _timer;
        /// <summary>
        /// The main color
        /// </summary>
        private Color _mainColor = Color.DarkSlateGray;
        /// <summary>
        /// The end color
        /// </summary>
        private Color _endColor = Color.LightYellow;
        /// <summary>
        /// The mouse enter
        /// </summary>
        private bool _mouseEnter = false;
        /// <summary>
        /// The mouse down
        /// </summary>
        private bool _mouseDown = false;
        /// <summary>
        /// The border color
        /// </summary>
        private Color _borderColor = Color.Black;
        /// <summary>
        /// The icon image
        /// </summary>
        private Image _icoImage = null;
        /// <summary>
        /// The text
        /// </summary>
        private String _text = "";
        /// <summary>
        /// The font color
        /// </summary>
        private Color _fontColor = Color.Black;
        /// <summary>
        /// The outer color
        /// </summary>
        private Color outerColor = Color.WhiteSmoke;
        /// <summary>
        /// The focus
        /// </summary>
        private float _focus = 0f;

        /// <summary>
        /// The focus effects
        /// </summary>
        private float _focusEffects = 0f;
        /// <summary>
        /// The focus scales
        /// </summary>
        private float focusScales = 0.2f;
        /// <summary>
        /// The shrink
        /// </summary>
        private float shrink = 0.1f;


        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the controls inner circle to shrik shrink.
        /// </summary>
        /// <value>The inner shrink.</value>
        /// <remarks>A higher value will make the inner circle very small.
        /// A decimal value is required for the property.</remarks>
        public float InnerShrink
        {
            get { return shrink; }
            set
            {
                shrink = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set to increase dispersed brightness.
        /// </summary>
        /// <value>The focu scales.</value>
        public float FocuScales
        {
            get { return focusScales; }
            set
            {
                focusScales = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set value to give a realistic effect.
        /// </summary>
        /// <value>The focus effect.</value>
        /// <remarks>Lower value is highly recommended.</remarks>
        public float FocusEffect
        {
            get { return _focusEffects; }
            set
            {
                _focusEffects = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize = new Size(24, 24);

        /// <summary>
        /// Set Image.
        /// </summary>
        /// <value>The icon image.</value>
        public Image IcoImage
        {
            get { return _icoImage; }
            set
            {
                if (_icoImage != value)
                {
                    if (value == null)
                    {
                        _ImageSize = Size.Empty;
                    }
                    else
                    {
                        _ImageSize = value.Size;
                    }

                    _icoImage = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Set the size of the image.
        /// </summary>
        /// <value>The size of the icon image.</value>
        public Size IcoImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Set text to display on the control.
        /// </summary>
        /// <value>The display text.</value>
        public String DisplayText
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Set the Text color.
        /// </summary>
        /// <value>The color of the font.</value>
        public Color FontColor
        {
            get { return _fontColor; }
            set
            {
                if (_fontColor != value)
                {
                    _fontColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Set the Border color.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Set the End color.
        /// </summary>
        /// <value>The end color.</value>
        public Color EndColor
        {
            get { return _endColor; }
            set
            {
                if (_endColor != value)
                {
                    _endColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Set the Outer color.
        /// </summary>
        /// <value>The color of the outer.</value>
        public Color OuterColor
        {
            get { return outerColor; }
            set
            {
                if (outerColor != value)
                {
                    outerColor = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Set the Main color.
        /// </summary>
        /// <value>The color of the main.</value>
        public Color MainColor
        {
            get { return _mainColor; }
            set
            {
                if (_mainColor != value)
                {
                    _mainColor = value;

                    Invalidate();
                }
            }
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
        /// Creates an instance of the Orbit Button class
        /// </summary>
        public ZeroitOrbitButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, false);
            DoubleBuffered = true;
            this.BackColor = Color.Transparent;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1;
            _timer.Tick += new EventHandler(_timer_Tick);

            IncludeInConstructor();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle rect = Shrink(new Rectangle(0, 0, this.Width, this.Height), 3);
            GraphicsPath path = new GraphicsPath();
            e.Graphics.FillEllipse(new SolidBrush(outerColor), new Rectangle(0, 0, this.Width, this.Height));
            path.AddEllipse(rect);
            PathGradientBrush pgb1 = new PathGradientBrush(path);
            pgb1.CenterColor = this._endColor;
            pgb1.SurroundColors = new Color[] { this._mainColor };
            pgb1.FocusScales = new PointF(_focus - _focusEffects, _focus - _focusEffects);
            e.Graphics.FillEllipse(pgb1, rect);
            Rectangle small = Shrink(rect, (int)(rect.Width * shrink));
            GraphicsPath p2 = new GraphicsPath();
            p2.AddEllipse(small);
            if (!_mouseDown)
            {
                PathGradientBrush pgb = new PathGradientBrush(p2);
                pgb.CenterColor = Color.FromArgb(0, this._mainColor);
                pgb.SurroundColors = new Color[] { this._mainColor };
                pgb.CenterPoint = new PointF(small.Left, small.Top);
                pgb.FocusScales = new PointF(focusScales, focusScales);
                e.Graphics.FillEllipse(pgb, small);
            }
            else
            {
                LinearGradientBrush lgb2 = new LinearGradientBrush(small, _mainColor, _endColor, 225);

                e.Graphics.FillEllipse(lgb2, small);
            }
            GraphicsState state = e.Graphics.Save();
            e.Graphics.SetClip(p2);
            if (_icoImage != null && _text != "")
            {

                float side = Side(small) / 3f;
                float left = small.Left + small.Width / 2f - side / 2f;
                float top = small.Top + small.Height / 2f - side;
                e.Graphics.DrawImage(_icoImage, new RectangleF(left, top, side, side),
                                                new RectangleF(0, 0, _icoImage.Width, _icoImage.Height),
                GraphicsUnit.Pixel);

                Size s = TextRenderer.MeasureText(_text, base.Font);
                e.Graphics.DrawString(_text, base.Font, new SolidBrush(_fontColor),
                    new PointF(small.Left + small.Width / 2f - s.Width / 2,
                        small.Top + small.Height / 2f));
            }
            else
            {
                if (_text != "")
                {
                    Size s = TextRenderer.MeasureText(_text, base.Font);
                    e.Graphics.DrawString(_text, base.Font, new SolidBrush(_fontColor),
                        new PointF(small.Left + small.Width / 2f - s.Width / 2,
                            small.Top + small.Height / 2f - s.Height / 2));
                }
                if (_icoImage != null)
                {
                    float side = Side(small) / 3f;
                    float left = small.Left + small.Width / 2f - side / 2f;
                    float top = small.Top + small.Height / 2f - side / 2f;
                    e.Graphics.DrawImage(_icoImage, new RectangleF(left, top, side, side),
                                                    new RectangleF(0, 0, _icoImage.Width, _icoImage.Height),
                    GraphicsUnit.Pixel);
                }
            }

            e.Graphics.Restore(state);

            e.Graphics.DrawEllipse(new Pen(_borderColor, 1), rect);
            e.Graphics.DrawEllipse(new Pen(_borderColor, 1), small);


            base.OnPaint(e);
        }


        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _mouseDown = true;
            ClickOnMouseDown(e);
            base.OnMouseDown(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _mouseDown = false;
            ClickOnMouseUp(e);
            base.OnMouseUp(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseEnter = true;
            _timer.Start();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseEnter = false;
            _timer.Start();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Sides the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.Int32.</returns>
        private int Side(Rectangle input)
        {
            if (input.Height <= input.Width)
            {
                return input.Height;
            }
            return input.Width;
        }

        /// <summary>
        /// Shrinks the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="size">The size.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle Shrink(Rectangle input, int size)
        {
            int width = input.Width - size * 2;
            int height = input.Height - size * 2;
            if (width < 1)
                width = 1;
            if (height < 1)
                height = 1;
            return new Rectangle(input.Left + size, input.Top + size, width, height);

        }

        /// <summary>
        /// Handles the Tick event of the _timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void _timer_Tick(object sender, EventArgs e)
        {
            if (_mouseEnter)
            {
                if (_focus < 0.9f)
                {
                    _focus = _focus + 0.1f;
                }
                else
                {
                    _timer.Stop();
                }
            }
            else
            {
                if (_focus > 0)
                {
                    _focus = _focus - 0.1f;
                }
                else
                {
                    _timer.Stop();
                }

            }
            Invalidate();
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

    //--------------- [Designer(typeof(ZeroitGlassOrbitDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitGlassOrbitDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitGlassOrbitDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitGlassOrbitSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitGlassOrbitSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitGlassOrbitSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitOrbitButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGlassOrbitSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitGlassOrbitSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitOrbitButton;

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

        #region Public Properties

        /// <summary>
        /// Gets or sets the icon image.
        /// </summary>
        /// <value>The icon image.</value>
        public Image IcoImage
        {
            get
            {
                return colUserControl.IcoImage;
            }
            set
            {
                GetPropertyByName("IcoImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the display text.
        /// </summary>
        /// <value>The display text.</value>
        public String DisplayText
        {
            get
            {
                return colUserControl.DisplayText;
            }
            set
            {
                GetPropertyByName("DisplayText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        public Color FontColor
        {
            get
            {
                return colUserControl.FontColor;
            }
            set
            {
                GetPropertyByName("FontColor").SetValue(colUserControl, value);
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
        /// Gets or sets the end color.
        /// </summary>
        /// <value>The end color.</value>
        public Color EndColor
        {
            get
            {
                return colUserControl.EndColor;
            }
            set
            {
                GetPropertyByName("EndColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the outer.
        /// </summary>
        /// <value>The color of the outer.</value>
        public Color OuterColor
        {
            get
            {
                return colUserControl.OuterColor;
            }
            set
            {
                GetPropertyByName("OuterColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the main.
        /// </summary>
        /// <value>The color of the main.</value>
        public Color MainColor
        {
            get
            {
                return colUserControl.MainColor;
            }
            set
            {
                GetPropertyByName("MainColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the inner shrink.
        /// </summary>
        /// <value>The inner shrink.</value>
        public float InnerShrink
        {
            get
            {
                return colUserControl.InnerShrink;
            }
            set
            {
                GetPropertyByName("InnerShrink").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the focu scales.
        /// </summary>
        /// <value>The focu scales.</value>
        public float FocuScales
        {
            get
            {
                return colUserControl.FocuScales;
            }
            set
            {
                GetPropertyByName("FocuScales").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the focus effect.
        /// </summary>
        /// <value>The focus effect.</value>
        public float FocusEffect
        {
            get
            {
                return colUserControl.FocusEffect;
            }
            set
            {
                GetPropertyByName("FocusEffect").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("IcoImage",
                                 "Ico Image", "Appearance",
                                 "Sets the image of the control."));

            items.Add(new DesignerActionPropertyItem("DisplayText",
                                 "Display Text", "Appearance",
                                 "Sets the text to display on the control."));

            items.Add(new DesignerActionPropertyItem("FontColor",
                                 "Font Color", "Appearance",
                                 "Sets the text color."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color."));
            
            items.Add(new DesignerActionPropertyItem("EndColor",
                "End Color", "Appearance",
                "Sets the end color."));

            items.Add(new DesignerActionPropertyItem("OuterColor",
                "Outer Color", "Appearance",
                "Sets the outer color."));

            items.Add(new DesignerActionPropertyItem("MainColor",
                "Main Color", "Appearance",
                "Sets the main color."));

            items.Add(new DesignerActionPropertyItem("InnerShrink",
                                 "Inner Shrink", "Appearance",
                                 "Sets the small rectangle shrink."));

            items.Add(new DesignerActionPropertyItem("FocuScales",
                                 "Focus Scales", "Appearance",
                                 "Sets the Focus scale."));

            items.Add(new DesignerActionPropertyItem("FocusEffect",
                                 "Focus Effect", "Appearance",
                                 "Sets the focus effect."));
            

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
