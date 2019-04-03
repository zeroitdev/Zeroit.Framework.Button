// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 02-13-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 05-06-2018
// ***********************************************************************
// <copyright file="LedButton.cs" company="Zeroit Dev Technologies">
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
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Led Button

    /// <summary>
    /// This is a .Net control for Windows Forms that emulates a
    /// LED light with two states On and Off.
    /// <para>The purpose of the control is to
    /// provide a sleek looking representation of an LED light that is sizable,
    /// has a transparent background and can be set to different colors.
    /// </para>
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />

    [Designer(typeof(ZeroitLedBulbButtonDesigner))]
    public partial class ZeroitLedBulbButton : Control
    {
        #region Enums

        /// <summary>
        /// The blinks
        /// </summary>
        private Blinks blinks = Blinks.Once;

        /// <summary>
        /// Enum representing the number of times to Blink
        /// </summary>
        public enum Blinks
        {
            /// <summary>
            /// The once
            /// </summary>
            Once,
            /// <summary>
            /// The infinite
            /// </summary>
            Infinite
        }



        #endregion

        #region Fields

        /// <summary>
        /// The color
        /// </summary>
        private Color _color;
        /// <summary>
        /// The on
        /// </summary>
        private bool _on = true;
        /// <summary>
        /// The reflection color
        /// </summary>
        private Color _reflectionColor = Color.FromArgb(180, 255, 255, 255);
        /// <summary>
        /// The surround color
        /// </summary>
        private Color[] _surroundColor = new Color[] { Color.FromArgb(0, 255, 255, 255) };
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        /// <summary>
        /// The blink
        /// </summary>
        private int _blink = 0;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the number of blinks.
        /// </summary>
        /// <value>The number of blinks.</value>
        public int BlinkSpeed
        {
            get { return _blink; }
            set
            {
                _blink = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets or Sets the color of the LED light
        /// </summary>
        /// <value>The color.</value>
        [DefaultValue(typeof(Color), "153, 255, 54")]
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                this.DarkColor = ControlPaint.Dark(_color);
                this.DarkDarkColor = ControlPaint.DarkDark(_color);
                this.Invalidate();  // Redraw the control
            }
        }

        /// <summary>
        /// Dark shade of the LED color used for gradient
        /// </summary>
        /// <value>The color of the dark.</value>
        public Color DarkColor { get; protected set; }

        /// <summary>
        /// Very dark shade of the LED color used for gradient
        /// </summary>
        /// <value>The color of the dark dark.</value>
        public Color DarkDarkColor { get; protected set; }

        /// <summary>
        /// Gets or Sets whether the light is turned on
        /// </summary>
        /// <value><c>true</c> if on; otherwise, <c>false</c>.</value>
        public bool On
        {
            get { return _on; }
            set { _on = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the type of the blink.
        /// </summary>
        /// <value>The type of the blink.</value>
        public Blinks BlinkType
        {
            get { return blinks; }
            set
            {
                blinks = value;
                Invalidate();
            }
        }
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLedBulbButton" /> class.
        /// </summary>
        public ZeroitLedBulbButton()
        {
            SetStyle(ControlStyles.DoubleBuffer
            | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.ResizeRedraw
            | ControlStyles.UserPaint
            | ControlStyles.SupportsTransparentBackColor, true);

            this.Color = Color.FromArgb(255, 153, 255, 54);
            _timer.Tick += new EventHandler(
                (object sender, EventArgs e) => { this.On = !this.On; }
            );

            this.Click += BlinkLight;

            IncludeInConstructor();
        }


        #endregion

        #region Methods

        /// <summary>
        /// Handles the Paint event for this UserControl
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            // Create an offscreen graphics object for double buffering
            Bitmap offScreenBmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (System.Drawing.Graphics g = Graphics.FromImage(offScreenBmp))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                // Draw the control
                drawControl(g, this.On);
                // Draw the image to the screen
                e.Graphics.DrawImageUnscaled(offScreenBmp, 0, 0);
            }
        }

        /// <summary>
        /// Renders the control to an image
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="on">if set to <c>true</c> [on].</param>
        private void drawControl(Graphics g, bool on)
        {
            // Is the bulb on or off
            Color lightColor = (on) ? this.Color : Color.FromArgb(150, this.DarkColor);
            Color darkColor = (on) ? this.DarkColor : this.DarkDarkColor;

            // Calculate the dimensions of the bulb
            int width = this.Width - (this.Padding.Left + this.Padding.Right);
            int height = this.Height - (this.Padding.Top + this.Padding.Bottom);
            // Diameter is the lesser of width and height
            int diameter = Math.Min(width, height);
            // Subtract 1 pixel so ellipse doesn't get cut off
            diameter = Math.Max(diameter - 1, 1);

            // Draw the background ellipse
            var rectangle = new Rectangle(this.Padding.Left, this.Padding.Top, diameter, diameter);
            g.FillEllipse(new SolidBrush(darkColor), rectangle);

            // Draw the glow gradient
            var path = new GraphicsPath();
            path.AddEllipse(rectangle);
            var pathBrush = new PathGradientBrush(path);
            pathBrush.CenterColor = lightColor;
            pathBrush.SurroundColors = new Color[] { Color.FromArgb(0, lightColor) };
            g.FillEllipse(pathBrush, rectangle);

            // Draw the white reflection gradient
            var offset = Convert.ToInt32(diameter * .15F);
            var diameter1 = Convert.ToInt32(rectangle.Width * .8F);
            var whiteRect = new Rectangle(rectangle.X - offset, rectangle.Y - offset, diameter1, diameter1);
            var path1 = new GraphicsPath();
            path1.AddEllipse(whiteRect);
            var pathBrush1 = new PathGradientBrush(path);
            pathBrush1.CenterColor = _reflectionColor;
            pathBrush1.SurroundColors = _surroundColor;
            g.FillEllipse(pathBrush1, whiteRect);

            // Draw the border
            g.SetClip(this.ClientRectangle);
            if (this.On) g.DrawEllipse(new Pen(Color.FromArgb(85, Color.Black), 1F), rectangle);
        }

        /// <summary>
        /// Causes the Led to start blinking
        /// </summary>
        /// <param name="milliseconds">Number of milliseconds to blink for. 0 stops blinking</param>
        public void Blink(int milliseconds)
        {
            if (milliseconds > 0)
            {
                this.On = true;
                _timer.Interval = milliseconds;
                _timer.Enabled = true;
            }
            else
            {
                _timer.Enabled = false;
                this.On = false;
            }
        }

        #endregion

        #region Led On and Blink


        // Turn the bulb On or Off
        /// <summary>
        /// Handles the <see cref="E:Light" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OnLight(object sender, EventArgs e)
        {
            ((ZeroitLedBulbButton)sender).On = !((ZeroitLedBulbButton)sender).On;
        }


        //Led Bulb Blink
        /// <summary>
        /// Blinks the light.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void BlinkLight(object sender, EventArgs e)
        {
            switch (blinks)
            {
                case Blinks.Once:
                    ((ZeroitLedBulbButton)sender).On = !((ZeroitLedBulbButton)sender).On;
                    break;
                case Blinks.Infinite:
                    //if (_blink == 0) _blink = 500;
                    //else _blink = 0;
                    ((ZeroitLedBulbButton)sender).Blink(_blink);
                    break;

                default:
                    break;
            }

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

    //--------------- [Designer(typeof(ZeroitLedBulbButtonDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitLedBulbButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitLedBulbButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitLedBulbButtonSmartTagActionList(this.Component));
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
    /// Class ZeroitLedBulbButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitLedBulbButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitLedBulbButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitLedBulbButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitLedBulbButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitLedBulbButton;

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
        /// Gets or sets a value indicating whether this <see cref="ZeroitLedBulbButtonSmartTagActionList"/> is on.
        /// </summary>
        /// <value><c>true</c> if on; otherwise, <c>false</c>.</value>
        public bool On
        {
            get
            {
                return colUserControl.On;
            }
            set
            {
                GetPropertyByName("On").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get
            {
                return colUserControl.Color;
            }
            set
            {
                GetPropertyByName("Color").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the blink.
        /// </summary>
        /// <value>The type of the blink.</value>
        public Zeroit.Framework.Button.ZeroitLedBulbButton.Blinks BlinkType
        {
            get
            {
                return colUserControl.BlinkType;
            }
            set
            {
                GetPropertyByName("BlinkType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the blink speed.
        /// </summary>
        /// <value>The blink speed.</value>
        public int BlinkSpeed
        {
            get
            {
                return colUserControl.BlinkSpeed;
            }
            set
            {
                GetPropertyByName("BlinkSpeed").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("On",
                                 "On", "Appearance",
                                 "Set to on the led bulb."));

            items.Add(new DesignerActionPropertyItem("Color",
                                 "Color", "Appearance",
                                 "Sets the color of the led."));

            items.Add(new DesignerActionPropertyItem("BlinkType",
                                 "Blink Type", "Appearance",
                                 "Sets the type of blink."));

            items.Add(new DesignerActionPropertyItem("BlinkSpeed",
                                 "Blink Speed", "Appearance",
                                 "Sets the blink speed. A lower value increases speed"));

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
