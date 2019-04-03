// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="PulseButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Pulse Button

    #region Control


    /// <summary>
    /// A class collection for rendering a pulse button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [Designer(typeof(ZeroitButtonPulseDesigner))]
    public partial class ZeroitPulseButton : System.Windows.Forms.Button
    {
        #region -- Members --
        /// <summary>
        /// The pulse timer
        /// </summary>
        private readonly System.Windows.Forms.Timer pulseTimer;
        /// <summary>
        /// The pulses
        /// </summary>
        private RectangleF[] pulses;
        /// <summary>
        /// The center rect
        /// </summary>
        private RectangleF centerRect;
        /// <summary>
        /// The pulse colors
        /// </summary>
        private Color[] pulseColors;
        /// <summary>
        /// The pulse width
        /// </summary>
        private int pulseWidth;
        /// <summary>
        /// The mouse over
        /// </summary>
        private bool mouseOver;
        /// <summary>
        /// The pressed
        /// </summary>
        private bool pressed;
        /// <summary>
        /// The pulse speed
        /// </summary>
        private float pulseSpeed;

        /// <summary>
        /// Enum representing the shape of <c><see cref="ZeroitPulseButton" /></c>
        /// </summary>
        public enum Shape
        {
            /// <summary>
            /// The round
            /// </summary>
            Round,
            /// <summary>
            /// The rectangle
            /// </summary>
            Rectangle
        }
        #endregion

        #region -- Properties --

        /// <summary>
        /// Gets or sets the top button color.
        /// </summary>
        /// <value>The top button color.</value>
        [Browsable(true), DefaultValue(typeof(Color), "CornflowerBlue")]
        [Category("Appearance")]
        public Color ButtonColorTop { get; set; }

        /// <summary>
        /// Gets or sets the bottom button color.
        /// </summary>
        /// <value>The bottom button color.</value>
        [Browsable(true), DefaultValue(typeof(Color), "DodgerBlue")]
        [Category("Appearance")]
        public Color ButtonColorBottom { get; set; }

        /// <summary>
        /// Gets or sets the color of the pulse.
        /// </summary>
        /// <value>The color of the pulse.</value>
        [Browsable(true), DefaultValue(typeof(Color), "Black")]
        [Category("Appearance")]
        public Color PulseColor { get; set; }

        /// <summary>
        /// Gets or sets the type of the shape.
        /// </summary>
        /// <value>The type of the shape.</value>
        [Browsable(true), DefaultValue(typeof(Shape), "Round")]
        [Category("Appearance")]
        public Shape ShapeType { get; set; }

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        [Browsable(true), DefaultValue(10)]
        [Category("Appearance")]
        public int CornerRadius { get; set; }

        /// <summary>
        /// Gets or sets the color of the focus.
        /// </summary>
        /// <value>The color of the focus.</value>
        [Browsable(true), DefaultValue(typeof(Color), "Orange")]
        [Category("Appearance")]
        public Color FocusColor { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        [Browsable(true), DefaultValue(typeof(Color), "White")]
        [Category("Appearance")]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        /// <summary>
        /// Gets or sets the number of pulses.
        /// </summary>
        /// <value>The number of pulses.</value>
        [Browsable(true), DefaultValue(3)]
        [Category("Appearance")]
        public int NumberOfPulses
        {
            get { return pulses.Length; }
            set
            {
                if (value <= 0) return;
                pulses = new RectangleF[value];
                pulseColors = new Color[value];
                ArrangePulses();
            }
        }

        /// <summary>
        /// Gets or sets the width of the pulse.
        /// </summary>
        /// <value>The width of the pulse.</value>
        [Browsable(true), DefaultValue(10)]
        [Category("Appearance")]
        public int PulseWidth
        {
            get { return pulseWidth; }
            set { pulseWidth = value; ArrangePulses(); }
        }

        /// <summary>
        /// Gets or sets the wave speed.
        /// </summary>
        /// <value>The speed of the pulses.</value>
        [Browsable(true), DefaultValue(typeof(float), "0.3f")]
        [Category("Appearance")]
        public float PulseSpeed
        {
            get { return pulseSpeed; }
            set
            {
                if (value <= 0) return;
                pulseSpeed = value;
            }
        }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        [Browsable(false), DefaultValue(50)]
        public int Interval
        {
            get { return pulseTimer.Interval; }
            set { pulseTimer.Interval = value; }
        }

        #endregion

        #region -- Constructor --
        /// <summary>
        /// Initializes a new instance of the <see cref="PulseButton" /> class.
        /// </summary>
        public ZeroitPulseButton()
        {
            // Control styles
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            InitializeComponent();
            // Layout & initialization
            SuspendLayout();
            pulseWidth = 10;
            PulseSpeed = .3f;
            ButtonColorTop = Color.CornflowerBlue;
            ButtonColorBottom = Color.DodgerBlue;
            FocusColor = Color.Orange;
            PulseColor = Color.Black;
            ShapeType = Shape.Round;
            CornerRadius = 10;
            Image = null;
            base.TextAlign = ContentAlignment.MiddleCenter;
            Size = new Size(40, 40);
            // Timer
            pulseTimer = new System.Windows.Forms.Timer { Interval = 50 };
            pulseTimer.Tick += PulseTimerTick;
            pulses = new RectangleF[3];
            pulseColors = new Color[3];
            ArrangePulses();
            pulseTimer.Enabled = true;
            IncludeInConstructor();

            ResumeLayout(true);
        }

        #endregion

        #region -- EventHandlers --

        /// <summary>
        /// Handles the pulse timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void PulseTimerTick(object sender, EventArgs e)
        {
            pulseTimer.Enabled = false;
            InflatePulses();
            Invalidate();
            pulseTimer.Enabled = true;
        }

        #endregion

        #region -- Protected overrides --

        #region - Mouse -

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left) return;
            pressed = false;
            ClickOnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            pressed = true;
            ClickOnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseMove(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="mevent">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            mouseOver = centerRect.Contains(mevent.Location);
        }

        /// <summary>
        /// Raises the <see cref="Control.OnMouseLeave" /> event.
        /// </summary>
        /// <param name="e">A <see cref="EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseOver = false;
            pressed = false;
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            pulseTimer.Enabled = Enabled;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (pulses == null || pulses.Length == 0) return;
            ArrangePulses();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            base.OnPaintBackground(e);

            TransparentInPaint(e.Graphics);

            // Set Graphics interpolation and smoothing
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw pulses
            DrawPulses(g);

            if (centerRect.IsEmpty) return;
            // Draw center
            DrawCenter(g);

            // Draw border
            DrawBorder(g);
            // Image
            if (Image != null)
                g.DrawImage(Image, centerRect);

            // Draw highlight
            if (mouseOver)
                DrawHighLight(g);
            // Reflex
            if (!pressed) DrawReflex(g);
            // Text
            DrawText(g);
        }

        #endregion

        #region -- Protected virtual methods --

        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="g">The graphics object</param>
        protected virtual void DrawBorder(Graphics g)
        {
            using (var pen = new Pen(!Focused ? Color.FromArgb(60, Color.Black) : FocusColor, 2))
                PaintShape(g, pen, centerRect);
        }

        /// <summary>
        /// Draws the center.
        /// </summary>
        /// <param name="g">The graphics object</param>
        protected virtual void DrawCenter(Graphics g)
        {
            if (Enabled)
            {
                using (var lgb = new LinearGradientBrush(centerRect, ButtonColorTop, ButtonColorBottom,
                                                      LinearGradientMode.Vertical))
                {
                    PaintShape(g, lgb, centerRect);
                }
            }
            else
            {
                using (var lgb = new SolidBrush(Color.Gray))
                    PaintShape(g, lgb, centerRect);

            }
        }

        /// <summary>
        /// Draws the pulses.
        /// </summary>
        /// <param name="g">The graphics object</param>
        protected virtual void DrawPulses(Graphics g)
        {
            if (!Enabled) return;
            for (var i = 0; i < pulses.Length; i++)
            {
                using (var sb = new SolidBrush(pulseColors[i]))
                {
                    PaintShape(g, sb, pulses[i]);
                }
            }
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The graphics object</param>
        protected virtual void DrawText(Graphics g)
        {
            var format = new StringFormat(StringFormat.GenericDefault) { Trimming = StringTrimming.EllipsisCharacter };
            format.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            format.FormatFlags ^= StringFormatFlags.LineLimit;
            format.HotkeyPrefix = HotkeyPrefix.Show;
            SizeF size = g.MeasureString(Text, Font, new SizeF(centerRect.Width, centerRect.Height), format);
            RectangleF textRect = GetAlignPlacement(TextAlign, centerRect, size);
            using (var sb = new SolidBrush(ForeColor))
                g.DrawString(Text, Font, sb, textRect, format);
        }

        /// <summary>
        /// Draws the reflex.
        /// </summary>
        /// <param name="g">The graphics object</param>
        protected virtual void DrawReflex(Graphics g)
        {
            using (var path = new GraphicsPath())
            {
                RectangleF rect = centerRect;
                rect.Height = rect.Height / 2;
                if (ShapeType == Shape.Round)
                {
                    path.AddArc(centerRect, -180, 180);
                    RectangleF reflexRectangle = rect;
                    reflexRectangle.Offset(0, rect.Height);
                    reflexRectangle.Height /= 6;
                    path.AddArc(reflexRectangle, 0, 180);
                    path.CloseFigure();
                }
                else
                {
                    rect.Height += rect.Height / 6;
                    path.AddRectangle(rect);
                }
                RectangleF area = path.GetBounds();
                using (var lgb = new LinearGradientBrush(area, Color.FromArgb(30, Color.White),
                                                      Color.FromArgb(60, Color.White), -90))
                {
                    g.FillPath(lgb, path);
                }
            }
        }

        /// <summary>
        /// Draws the high light.
        /// </summary>
        /// <param name="g">The graphics object</param>
        protected virtual void DrawHighLight(Graphics g)
        {
            RectangleF highlightRect = centerRect;
            highlightRect.Inflate(-2, -2);
            using (var pen = new Pen(Color.FromArgb(60, Color.White), 4))
            {
                if (ShapeType == Shape.Round)
                    g.DrawEllipse(pen, highlightRect);
                else
                    g.DrawPath(pen, GetRoundRect(g, highlightRect, CornerRadius));
            }
        }

        /// <summary>
        /// Paints the shape.
        /// </summary>
        /// <param name="g">The graphics object</param>
        /// <param name="p">The pen</param>
        /// <param name="rectangle">The rectangle.</param>
        protected virtual void PaintShape(Graphics g, Pen p, RectangleF rectangle)
        {
            if (ShapeType == Shape.Round)
                g.DrawEllipse(p, rectangle);
            else
                using (var path = GetRoundRect(g, rectangle, CornerRadius))
                    g.DrawPath(p, path);
        }

        /// <summary>
        /// Paints the shape.
        /// </summary>
        /// <param name="g">The graphics object</param>
        /// <param name="b">The brush</param>
        /// <param name="rectangle">The rectangle.</param>
        protected virtual void PaintShape(Graphics g, Brush b, RectangleF rectangle)
        {
            if (ShapeType == Shape.Round)
                g.FillEllipse(b, rectangle);
            else
                using (var path = GetRoundRect(g, rectangle, CornerRadius))
                    g.FillPath(b, path);
        }

        #endregion

        #region -- Public static methods --

        /// <summary>
        /// Gets a path of a rectangle with round corners.
        /// </summary>
        /// <param name="g">The graphics object</param>
        /// <param name="rect">The rectangle</param>
        /// <param name="radius">The corner radius</param>
        /// <returns>GraphicsPath.</returns>
        public static GraphicsPath GetRoundRect(Graphics g, RectangleF rect, float radius)
        {
            var gp = new GraphicsPath();
            var diameter = radius * 2;
            gp.AddArc(rect.X + rect.Width - diameter, rect.Y, diameter, diameter, 270, 90);
            gp.AddArc(rect.X + rect.Width - diameter, rect.Y + rect.Height - diameter, diameter, diameter, 0, 90);
            gp.AddArc(rect.X, rect.Y + rect.Height - diameter, diameter, diameter, 90, 90);
            gp.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            gp.CloseFigure();
            return gp;
        }

        /// <summary>
        /// Gets the placement.
        /// </summary>
        /// <param name="align">The alignment of the element</param>
        /// <param name="rect">A retangle</param>
        /// <param name="element">The element to be placed</param>
        /// <returns>RectangleF.</returns>
        public static RectangleF GetAlignPlacement(ContentAlignment align, RectangleF rect, SizeF element)
        {
            // Left & Top (default)
            float lft = rect.Left;
            float top = rect.Y;
            // Right
            if ((align & (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight)) != 0)
                lft = rect.Right - element.Width;
            // Center
            else if ((align & (ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter)) != 0)
                lft = (rect.Width / 2) - (element.Width / 2) + rect.Left;
            // Bottom
            if ((align & (ContentAlignment.BottomCenter | ContentAlignment.BottomLeft | ContentAlignment.BottomRight)) != 0)
                top = rect.Bottom - element.Height;
            // Middle
            else if ((align & (ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft | ContentAlignment.MiddleRight)) != 0)
                top = (rect.Height / 2) - (element.Height / 2) + rect.Y;

            return new RectangleF(lft, top, element.Width, element.Height);
        }

        #endregion

        #region -- Private methods --

        /// <summary>
        /// Arranges the pulses.
        /// </summary>
        private void ArrangePulses()
        {
            centerRect = new RectangleF(pulseWidth, pulseWidth, Width - 2 * pulseWidth, Height - 2 * pulseWidth);
            for (var i = 1; i <= pulses.Length; i++)
            {
                pulses[i - 1] = new RectangleF(
                    pulseWidth * i / (float)pulses.Length,
                    pulseWidth * i / (float)pulses.Length,
                    Width - 2 * pulseWidth * i / pulses.Length,
                    Height - 2 * pulseWidth * i / pulses.Length
                    );
                pulseColors[i - 1] = Color.FromArgb((int)(Math.Min(pulses[i - 1].X * 255 / pulseWidth, 255)), Color.White);
            }
        }

        /// <summary>
        /// Inflates the pulses.
        /// </summary>
        private void InflatePulses()
        {
            for (var i = 0; i < pulses.Length; i++)
            {
                pulses[i].Inflate(PulseSpeed, PulseSpeed);
                if (pulses[i].Width > Width || pulses[i].Height > Height || pulses[i].X < 0 || pulses[i].Y < 0)
                    pulses[i] = new RectangleF(pulseWidth, pulseWidth, Width - 2 * pulseWidth, Height - 2 * pulseWidth);
                pulseColors[i] = Color.FromArgb((int)(Math.Min(pulses[i].X * 255 / pulseWidth, 255)), PulseColor);
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

    partial class ZeroitPulseButton

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
    /// Class ZeroitButtonPulseDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonPulseDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonPulseSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonPulseSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitButtonPulseSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPulseButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonPulseSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonPulseSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPulseButton;

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
        /// Gets or sets the button color top.
        /// </summary>
        /// <value>The button color top.</value>
        public Color ButtonColorTop
        {
            get
            {
                return colUserControl.ButtonColorTop;
            }
            set
            {
                GetPropertyByName("ButtonColorTop").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button color bottom.
        /// </summary>
        /// <value>The button color bottom.</value>
        public Color ButtonColorBottom
        {
            get
            {
                return colUserControl.ButtonColorBottom;
            }
            set
            {
                GetPropertyByName("ButtonColorBottom").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the pulse.
        /// </summary>
        /// <value>The color of the pulse.</value>
        public Color PulseColor
        {
            get
            {
                return colUserControl.PulseColor;
            }
            set
            {
                GetPropertyByName("PulseColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the focus.
        /// </summary>
        /// <value>The color of the focus.</value>
        public Color FocusColor
        {
            get
            {
                return colUserControl.FocusColor;
            }
            set
            {
                GetPropertyByName("FocusColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the shape.
        /// </summary>
        /// <value>The type of the shape.</value>
        public Zeroit.Framework.Button.ZeroitPulseButton.Shape ShapeType
        {
            get
            {
                return colUserControl.ShapeType;
            }
            set
            {
                GetPropertyByName("ShapeType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        public int CornerRadius
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
        /// Gets or sets the number of pulses.
        /// </summary>
        /// <value>The number of pulses.</value>
        public int NumberOfPulses
        {
            get
            {
                return colUserControl.NumberOfPulses;
            }
            set
            {
                GetPropertyByName("NumberOfPulses").SetValue(colUserControl, value);
            }
        }


        /// <summary>
        /// Gets or sets the width of the pulse.
        /// </summary>
        /// <value>The width of the pulse.</value>
        public int PulseWidth
        {
            get
            {
                return colUserControl.PulseWidth;
            }
            set
            {
                GetPropertyByName("PulseWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the pulse speed.
        /// </summary>
        /// <value>The pulse speed.</value>
        public float PulseSpeed
        {
            get
            {
                return colUserControl.PulseSpeed;
            }
            set
            {
                GetPropertyByName("PulseSpeed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        public int Interval
        {
            get
            {
                return colUserControl.Interval;
            }
            set
            {
                GetPropertyByName("Interval").SetValue(colUserControl, value);
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


            items.Add(new DesignerActionPropertyItem("ShapeType",
                                 "Shape Type", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ButtonColorTop",
                                 "Button Color Top", "Appearance",
                                 "Sets the top button color."));

            items.Add(new DesignerActionPropertyItem("ButtonColorBottom",
                                 "Button Color Bottom", "Appearance",
                                 "Sets the bottom button color."));

            items.Add(new DesignerActionPropertyItem("PulseColor",
                                 "Pulse Color", "Appearance",
                                 "Sets the pulse color."));

            items.Add(new DesignerActionPropertyItem("FocusColor",
                                 "Focus Color", "Appearance",
                                 "Sets the focus color."));

            items.Add(new DesignerActionPropertyItem("CornerRadius",
                                 "Corner Radius", "Appearance",
                                 "Sets the corner radius."));

            items.Add(new DesignerActionPropertyItem("NumberOfPulses",
                                 "Number Of Pulses", "Appearance",
                                 "Sets the number of pulses."));

            items.Add(new DesignerActionPropertyItem("PulseWidth",
                                 "Pulse Width", "Appearance",
                                 "Sets the width of the pulse."));

            items.Add(new DesignerActionPropertyItem("PulseSpeed",
                                 "Pulse Speed", "Appearance",
                                 "Sets the pulse speed."));

            items.Add(new DesignerActionPropertyItem("Interval",
                                 "Interval", "Appearance",
                                 "Sets the time interval."));

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
