// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="GlassButtonDefault.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Zeroit.Framework.Button
{

    #region GlassButton Default
    /// <summary>
    /// Represents a glass button control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [ToolboxBitmap(typeof(ZeroitGlassButtonDefault)), ToolboxItem(true), ToolboxItemFilter("System.Windows.Forms"), Description("Raises an event when the user clicks it.")]
    [Designer(typeof(ZeroitGlassButtonDefaultDesigner))]
    public partial class ZeroitGlassButtonDefault : System.Windows.Forms.Button
    {
        #region " Constructors "

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGlassButtonDefault" /> class.
        /// </summary>
        public ZeroitGlassButtonDefault()
        {
            InitializeComponent();
            timer.Interval = animationLength / framesCount;
            base.BackColor = Color.Transparent;
            BackColor = Color.Black;
            ForeColor = Color.White;
            OuterBorderColor = Color.White;
            InnerBorderColor = Color.Black;
            ShineColor = Color.White;
            GlowColor = Color.FromArgb(-7488001);//unchecked((int)(0xFF8DBDFF)));
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, false);
            IncludeInConstructor();
        }

        #endregion

        #region " Fields and Properties "

        /// <summary>
        /// The back color
        /// </summary>
        private Color _backColor;
        /// <summary>
        /// Gets or sets the background color of the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [DefaultValue(typeof(Color), "Black")]
        public virtual new Color BackColor
        {
            get { return _backColor; }
            set
            {
                if (!_backColor.Equals(value))
                {
                    _backColor = value;
                    UseVisualStyleBackColor = false;
                    CreateFrames();
                    OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [DefaultValue(typeof(Color), "White")]
        public virtual new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// The inner border color
        /// </summary>
        private Color _innerBorderColor;
        /// <summary>
        /// Gets or sets the inner border color of the control.
        /// </summary>
        /// <value>The color of the inner border.</value>
        [DefaultValue(typeof(Color), "Black"), Category("Appearance"), Description("The inner border color of the control.")]
        public virtual Color InnerBorderColor
        {
            get { return _innerBorderColor; }
            set
            {
                if (_innerBorderColor != value)
                {
                    _innerBorderColor = value;
                    CreateFrames();
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                    OnInnerBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// The outer border color
        /// </summary>
        private Color _outerBorderColor;
        /// <summary>
        /// Gets or sets the outer border color of the control.
        /// </summary>
        /// <value>The color of the outer border.</value>
        [DefaultValue(typeof(Color), "White"), Category("Appearance"), Description("The outer border color of the control.")]
        public virtual Color OuterBorderColor
        {
            get { return _outerBorderColor; }
            set
            {
                if (_outerBorderColor != value)
                {
                    _outerBorderColor = value;
                    CreateFrames();
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                    OnOuterBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// The shine color
        /// </summary>
        private Color _shineColor;
        /// <summary>
        /// Gets or sets the shine color of the control.
        /// </summary>
        /// <value>The color of the shine.</value>
        [DefaultValue(typeof(Color), "White"), Category("Appearance"), Description("The shine color of the control.")]
        public virtual Color ShineColor
        {
            get { return _shineColor; }
            set
            {
                if (_shineColor != value)
                {
                    _shineColor = value;
                    CreateFrames();
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                    OnShineColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// The glow color
        /// </summary>
        private Color _glowColor;
        /// <summary>
        /// Gets or sets the glow color of the control.
        /// </summary>
        /// <value>The color of the glow.</value>
        [DefaultValue(typeof(Color), "255,141,189,255"), Category("Appearance"), Description("The glow color of the control.")]
        public virtual Color GlowColor
        {
            get { return _glowColor; }
            set
            {
                if (_glowColor != value)
                {
                    _glowColor = value;
                    CreateFrames();
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                    OnGlowColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// The fade on focus
        /// </summary>
        private bool _fadeOnFocus;
        /// <summary>
        /// Gets or sets a value indicating whether the button should fade in and fade out when it's getting and loosing the focus.
        /// </summary>
        /// <value><c>true</c> if fading with changing the focus; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Category("Appearance"), Description("Indicates whether the button should fade in and fade out when it is getting and loosing the focus.")]
        public virtual bool FadeOnFocus
        {
            get { return _fadeOnFocus; }
            set
            {
                if (_fadeOnFocus != value)
                {
                    _fadeOnFocus = value;
                }
            }
        }

        /// <summary>
        /// The is hovered
        /// </summary>
        private bool _isHovered;
        /// <summary>
        /// The is focused
        /// </summary>
        private bool _isFocused;
        /// <summary>
        /// The is focused by key
        /// </summary>
        private bool _isFocusedByKey;
        /// <summary>
        /// The is key down
        /// </summary>
        private bool _isKeyDown;
        /// <summary>
        /// The is mouse down
        /// </summary>
        private bool _isMouseDown;
        /// <summary>
        /// Gets a value indicating whether this instance is pressed.
        /// </summary>
        /// <value><c>true</c> if this instance is pressed; otherwise, <c>false</c>.</value>
        private bool IsPressed { get { return _isKeyDown || (_isMouseDown && _isHovered); } }

        /// <summary>
        /// Gets the state of the button control.
        /// </summary>
        /// <value>The state of the button control.</value>
        [Browsable(false)]
        public PushButtonState State
        {
            get
            {
                if (!Enabled)
                {
                    return PushButtonState.Disabled;
                }
                if (IsPressed)
                {
                    return PushButtonState.Pressed;
                }
                if (_isHovered)
                {
                    return PushButtonState.Hot;
                }
                if (_isFocused || IsDefault)
                {
                    return PushButtonState.Default;
                }
                return PushButtonState.Normal;
            }
        }

        #endregion

        #region " Events "

        /// <summary>
        /// Occurs when the value of the <see cref="P:Glass.GlassButton.InnerBorderColor" /> property changes.
        /// </summary>
        [Description("Event raised when the value of the InnerBorderColor property is changed."), Category("Property Changed")]
        public event EventHandler InnerBorderColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.InnerBorderColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnInnerBorderColorChanged(EventArgs e)
        {
            if (InnerBorderColorChanged != null)
            {
                InnerBorderColorChanged(this, e);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:Glass.GlassButton.OuterBorderColor" /> property changes.
        /// </summary>
        [Description("Event raised when the value of the OuterBorderColor property is changed."), Category("Property Changed")]
        public event EventHandler OuterBorderColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.OuterBorderColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnOuterBorderColorChanged(EventArgs e)
        {
            if (OuterBorderColorChanged != null)
            {
                OuterBorderColorChanged(this, e);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:Glass.GlassButton.ShineColor" /> property changes.
        /// </summary>
        [Description("Event raised when the value of the ShineColor property is changed."), Category("Property Changed")]
        public event EventHandler ShineColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.ShineColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnShineColorChanged(EventArgs e)
        {
            if (ShineColorChanged != null)
            {
                ShineColorChanged(this, e);
            }
        }

        /// <summary>
        /// Occurs when the value of the <see cref="P:Glass.GlassButton.GlowColor" /> property changes.
        /// </summary>
        [Description("Event raised when the value of the GlowColor property is changed."), Category("Property Changed")]
        public event EventHandler GlowColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.GlowColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnGlowColorChanged(EventArgs e)
        {
            if (GlowColorChanged != null)
            {
                GlowColorChanged(this, e);
            }
        }

        #endregion

        #region " Overrided Methods "

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            CreateFrames();
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            _isKeyDown = _isMouseDown = false;
            base.OnClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Enter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnter(EventArgs e)
        {
            _isFocused = _isFocusedByKey = true;
            base.OnEnter(e);
            if (_fadeOnFocus)
            {
                FadeIn();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Leave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _isFocused = _isFocusedByKey = _isKeyDown = _isMouseDown = false;
            Invalidate();
            if (_fadeOnFocus)
            {
                FadeOut();
            }
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnKeyUp(System.Windows.Forms.KeyEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _isKeyDown = true;
                Invalidate();
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnKeyUp(System.Windows.Forms.KeyEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (_isKeyDown && e.KeyCode == Keys.Space)
            {
                _isKeyDown = false;
                Invalidate();
            }
            base.OnKeyUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_isMouseDown && e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                _isFocusedByKey = false;
                Invalidate();
            }

            ClickOnMouseDown(e);
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _isMouseDown = false;
                Invalidate();
            }

            ClickOnMouseUp(e);
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseMove(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != MouseButtons.None)
            {
                if (!ClientRectangle.Contains(e.X, e.Y))
                {
                    if (_isHovered)
                    {
                        _isHovered = false;
                        Invalidate();
                    }
                }
                else if (!_isHovered)
                {
                    _isHovered = true;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            FadeIn();
            Invalidate();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            if (!(FadeOnFocus && _isFocusedByKey)) FadeOut();
            Invalidate();
            base.OnMouseLeave(e);
        }

        #endregion

        #region " Painting "

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnPaint(System.Windows.Forms.PaintEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawButtonBackgroundFromBuffer(e.Graphics);
            DrawForegroundFromButton(e);
            DrawButtonForeground(e.Graphics);

            if (Paint != null)
            {
                Paint(this, e);
            }
        }

        /// <summary>
        /// Occurs when the control is redrawn.
        /// </summary>
        public new event PaintEventHandler Paint;

        /// <summary>
        /// Draws the button background from buffer.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void DrawButtonBackgroundFromBuffer(Graphics graphics)
        {
            int frame;
            if (!Enabled)
            {
                frame = FRAME_DISABLED;
            }
            else if (IsPressed)
            {
                frame = FRAME_PRESSED;
            }
            else if (!IsAnimating && _currentFrame == 0)
            {
                frame = FRAME_NORMAL;
            }
            else
            {
                if (!HasAnimationFrames)
                {
                    CreateFrames(true);
                }
                frame = FRAME_ANIMATED + _currentFrame;
            }
            if (_frames == null || _frames.Count == 0)
            {
                CreateFrames();
            }
            graphics.DrawImage(_frames[frame], Point.Empty);
        }

        /// <summary>
        /// Creates the background frame.
        /// </summary>
        /// <param name="pressed">if set to <c>true</c> [pressed].</param>
        /// <param name="hovered">if set to <c>true</c> [hovered].</param>
        /// <param name="animating">if set to <c>true</c> [animating].</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="glowOpacity">The glow opacity.</param>
        /// <returns>Image.</returns>
        private Image CreateBackgroundFrame(bool pressed, bool hovered,
            bool animating, bool enabled, float glowOpacity)
        {
            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0)
            {
                rect.Width = 1;
            }
            if (rect.Height <= 0)
            {
                rect.Height = 1;
            }
            Image img = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.Clear(Color.Transparent);
                DrawButtonBackground(g, rect, pressed, hovered, animating, enabled,
                    _outerBorderColor, _backColor, _glowColor, _shineColor, _innerBorderColor,
                    glowOpacity);
            }
            return img;
        }

        /// <summary>
        /// Draws the button background.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="pressed">if set to <c>true</c> [pressed].</param>
        /// <param name="hovered">if set to <c>true</c> [hovered].</param>
        /// <param name="animating">if set to <c>true</c> [animating].</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        /// <param name="outerBorderColor">Color of the outer border.</param>
        /// <param name="backColor">Color of the back.</param>
        /// <param name="glowColor">Color of the glow.</param>
        /// <param name="shineColor">Color of the shine.</param>
        /// <param name="innerBorderColor">Color of the inner border.</param>
        /// <param name="glowOpacity">The glow opacity.</param>
        private static void DrawButtonBackground(Graphics g, Rectangle rectangle,
            bool pressed, bool hovered, bool animating, bool enabled,
            Color outerBorderColor, Color backColor, Color glowColor, Color shineColor,
            Color innerBorderColor, float glowOpacity)
        {
            SmoothingMode sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            #region " white border "
            Rectangle rect = rectangle;
            rect.Width--;
            rect.Height--;
            using (GraphicsPath bw = CreateRoundRectangle(rect, 4))
            {
                using (Pen p = new Pen(outerBorderColor))
                {
                    g.DrawPath(p, bw);
                }
            }
            #endregion

            rect.X++;
            rect.Y++;
            rect.Width -= 2;
            rect.Height -= 2;
            Rectangle rect2 = rect;
            rect2.Height >>= 1;

            #region " content "
            using (GraphicsPath bb = CreateRoundRectangle(rect, 2))
            {
                int opacity = pressed ? 0xcc : 0x7f;
                using (Brush br = new SolidBrush(Color.FromArgb(opacity, backColor)))
                {
                    g.FillPath(br, bb);
                }
            }
            #endregion

            #region " glow "
            if ((hovered || animating) && !pressed)
            {
                using (GraphicsPath clip = CreateRoundRectangle(rect, 2))
                {
                    g.SetClip(clip, CombineMode.Intersect);
                    using (GraphicsPath brad = CreateBottomRadialPath(rect))
                    {
                        using (PathGradientBrush pgr = new PathGradientBrush(brad))
                        {
                            int opacity = (int)(0xB2 * glowOpacity + .5f);
                            RectangleF bounds = brad.GetBounds();
                            pgr.CenterPoint = new PointF((bounds.Left + bounds.Right) / 2f, (bounds.Top + bounds.Bottom) / 2f);
                            pgr.CenterColor = Color.FromArgb(opacity, glowColor);
                            pgr.SurroundColors = new Color[] { Color.FromArgb(0, glowColor) };
                            g.FillPath(pgr, brad);
                        }
                    }
                    g.ResetClip();
                }
            }
            #endregion

            #region " shine "
            if (rect2.Width > 0 && rect2.Height > 0)
            {
                rect2.Height++;
                using (GraphicsPath bh = CreateTopRoundRectangle(rect2, 2))
                {
                    rect2.Height++;
                    int opacity = 0x99;
                    if (pressed | !enabled)
                    {
                        opacity = (int)(.4f * opacity + .5f);
                    }
                    using (LinearGradientBrush br = new LinearGradientBrush(rect2, Color.FromArgb(opacity, shineColor), Color.FromArgb(opacity / 3, shineColor), LinearGradientMode.Vertical))
                    {
                        g.FillPath(br, bh);
                    }
                }
                rect2.Height -= 2;
            }
            #endregion

            #region " black border "
            using (GraphicsPath bb = CreateRoundRectangle(rect, 3))
            {
                using (Pen p = new Pen(innerBorderColor))
                {
                    g.DrawPath(p, bb);
                }
            }
            #endregion

            g.SmoothingMode = sm;
        }

        /// <summary>
        /// Draws the button foreground.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawButtonForeground(Graphics g)
        {
            if (Focused && ShowFocusCues/* && isFocusedByKey*/)
            {
                Rectangle rect = ClientRectangle;
                rect.Inflate(-4, -4);
                ControlPaint.DrawFocusRectangle(g, rect);
            }
        }

        /// <summary>
        /// The image button
        /// </summary>
        private System.Windows.Forms.Button _imageButton;
        /// <summary>
        /// Draws the foreground from button.
        /// </summary>
        /// <param name="pevent">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawForegroundFromButton(PaintEventArgs pevent)
        {
            if (_imageButton == null)
            {
                _imageButton = new System.Windows.Forms.Button();
                _imageButton.Parent = new TransparentControl();
                _imageButton.SuspendLayout();
                _imageButton.BackColor = Color.Transparent;
                _imageButton.FlatAppearance.BorderSize = 0;
                _imageButton.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                _imageButton.SuspendLayout();
            }
            _imageButton.AutoEllipsis = AutoEllipsis;
            if (Enabled)
            {
                _imageButton.ForeColor = ForeColor;
            }
            else
            {
                _imageButton.ForeColor = Color.FromArgb((3 * ForeColor.R + _backColor.R) >> 2,
                    (3 * ForeColor.G + _backColor.G) >> 2,
                    (3 * ForeColor.B + _backColor.B) >> 2);
            }
            _imageButton.Font = Font;
            _imageButton.RightToLeft = RightToLeft;
            _imageButton.Image = Image;
            if (Image != null && !Enabled)
            {
                Size size = Image.Size;
                float[][] newColorMatrix = new float[5][];
                newColorMatrix[0] = new float[] { 0.2125f, 0.2125f, 0.2125f, 0f, 0f };
                newColorMatrix[1] = new float[] { 0.2577f, 0.2577f, 0.2577f, 0f, 0f };
                newColorMatrix[2] = new float[] { 0.0361f, 0.0361f, 0.0361f, 0f, 0f };
                float[] arr = new float[5];
                arr[3] = 1f;
                newColorMatrix[3] = arr;
                newColorMatrix[4] = new float[] { 0.38f, 0.38f, 0.38f, 0f, 1f };
                System.Drawing.Imaging.ColorMatrix matrix = new System.Drawing.Imaging.ColorMatrix(newColorMatrix);
                System.Drawing.Imaging.ImageAttributes disabledImageAttr = new System.Drawing.Imaging.ImageAttributes();
                disabledImageAttr.ClearColorKey();
                disabledImageAttr.SetColorMatrix(matrix);
                _imageButton.Image = new Bitmap(Image.Width, Image.Height);
                using (Graphics gr = Graphics.FromImage(_imageButton.Image))
                {
                    gr.DrawImage(Image, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, disabledImageAttr);
                }
            }
            _imageButton.ImageAlign = ImageAlign;
            _imageButton.ImageIndex = ImageIndex;
            _imageButton.ImageKey = ImageKey;
            _imageButton.ImageList = ImageList;
            _imageButton.Padding = Padding;
            _imageButton.Size = Size;
            _imageButton.Text = Text;
            _imageButton.TextAlign = TextAlign;
            _imageButton.TextImageRelation = TextImageRelation;
            _imageButton.UseCompatibleTextRendering = UseCompatibleTextRendering;
            _imageButton.UseMnemonic = UseMnemonic;
            _imageButton.ResumeLayout();
            InvokePaint(_imageButton, pevent);
            if (_imageButton.Image != null && _imageButton.Image != Image)
            {
                _imageButton.Image.Dispose();
                _imageButton.Image = null;
            }
        }

        /// <summary>
        /// Class TransparentControl.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.Control" />
        private class TransparentControl : Control
        {
            /// <summary>
            /// Paints the background of the control.
            /// </summary>
            /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains information about the control to paint.</param>
            protected override void OnPaintBackground(PaintEventArgs pevent) { }
            /// <summary>
            /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
            /// </summary>
            /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
            protected override void OnPaint(PaintEventArgs e) { }
        }

        /// <summary>
        /// Creates the round rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private static GraphicsPath CreateRoundRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int l = rectangle.Left;
            int t = rectangle.Top;
            int w = rectangle.Width;
            int h = rectangle.Height;
            int d = radius << 1;
            path.AddArc(l, t, d, d, 180, 90); // topleft
            path.AddLine(l + radius, t, l + w - radius, t); // top
            path.AddArc(l + w - d, t, d, d, 270, 90); // topright
            path.AddLine(l + w, t + radius, l + w, t + h - radius); // right
            path.AddArc(l + w - d, t + h - d, d, d, 0, 90); // bottomright
            path.AddLine(l + w - radius, t + h, l + radius, t + h); // bottom
            path.AddArc(l, t + h - d, d, d, 90, 90); // bottomleft
            path.AddLine(l, t + h - radius, l, t + radius); // left
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Creates the top round rectangle.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private static GraphicsPath CreateTopRoundRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int l = rectangle.Left;
            int t = rectangle.Top;
            int w = rectangle.Width;
            int h = rectangle.Height;
            int d = radius << 1;
            path.AddArc(l, t, d, d, 180, 90); // topleft
            path.AddLine(l + radius, t, l + w - radius, t); // top
            path.AddArc(l + w - d, t, d, d, 270, 90); // topright
            path.AddLine(l + w, t + radius, l + w, t + h); // right
            path.AddLine(l + w, t + h, l, t + h); // bottom
            path.AddLine(l, t + h, l, t + radius); // left
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Creates the bottom radial path.
        /// </summary>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>GraphicsPath.</returns>
        private static GraphicsPath CreateBottomRadialPath(Rectangle rectangle)
        {
            GraphicsPath path = new GraphicsPath();
            RectangleF rect = rectangle;
            rect.X -= rect.Width * .35f;
            rect.Y -= rect.Height * .15f;
            rect.Width *= 1.7f;
            rect.Height *= 2.3f;
            path.AddEllipse(rect);
            path.CloseFigure();
            return path;
        }

        #endregion

        #region " Unused Properties & Events "

        /// <summary>
        /// This property is not relevant for this class.
        /// </summary>
        /// <value>The flat appearance.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatButtonAppearance FlatAppearance
        {
            get { return base.FlatAppearance; }
        }

        /// <summary>
        /// This property is not relevant for this class.
        /// </summary>
        /// <value>The flat style.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
            set { base.FlatStyle = value; }
        }

        /// <summary>
        /// This property is not relevant for this class.
        /// </summary>
        /// <value><c>true</c> if [use visual style back color]; otherwise, <c>false</c>.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseVisualStyleBackColor
        {
            get { return base.UseVisualStyleBackColor; }
            set { base.UseVisualStyleBackColor = value; }
        }

        #endregion

        #region " Animation Support "

        /// <summary>
        /// The frames
        /// </summary>
        private List<Image> _frames;

        /// <summary>
        /// The frame disabled
        /// </summary>
        private const int FRAME_DISABLED = 0;
        /// <summary>
        /// The frame pressed
        /// </summary>
        private const int FRAME_PRESSED = 1;
        /// <summary>
        /// The frame normal
        /// </summary>
        private const int FRAME_NORMAL = 2;
        /// <summary>
        /// The frame animated
        /// </summary>
        private const int FRAME_ANIMATED = 3;

        /// <summary>
        /// Gets a value indicating whether this instance has animation frames.
        /// </summary>
        /// <value><c>true</c> if this instance has animation frames; otherwise, <c>false</c>.</value>
        private bool HasAnimationFrames
        {
            get
            {
                return _frames != null && _frames.Count > FRAME_ANIMATED;
            }
        }

        /// <summary>
        /// Creates the frames.
        /// </summary>
        private void CreateFrames()
        {
            CreateFrames(false);
        }

        /// <summary>
        /// Creates the frames.
        /// </summary>
        /// <param name="withAnimationFrames">if set to <c>true</c> [with animation frames].</param>
        private void CreateFrames(bool withAnimationFrames)
        {
            DestroyFrames();
            if (!IsHandleCreated)
            {
                return;
            }
            if (_frames == null)
            {
                _frames = new List<Image>();
            }
            _frames.Add(CreateBackgroundFrame(false, false, false, false, 0));
            _frames.Add(CreateBackgroundFrame(true, true, false, true, 0));
            _frames.Add(CreateBackgroundFrame(false, false, false, true, 0));
            if (!withAnimationFrames)
            {
                return;
            }
            for (int i = 0; i < framesCount; i++)
            {
                _frames.Add(CreateBackgroundFrame(false, true, true, true, (float)i / (framesCount - 1F)));
            }
        }

        /// <summary>
        /// Destroys the frames.
        /// </summary>
        private void DestroyFrames()
        {
            if (_frames != null)
            {
                while (_frames.Count > 0)
                {
                    _frames[_frames.Count - 1].Dispose();
                    _frames.RemoveAt(_frames.Count - 1);
                }
            }
        }

        /// <summary>
        /// The animation length
        /// </summary>
        private const int animationLength = 300;
        /// <summary>
        /// The frames count
        /// </summary>
        private const int framesCount = 10;
        /// <summary>
        /// The current frame
        /// </summary>
        private int _currentFrame;
        /// <summary>
        /// The direction
        /// </summary>
        private int _direction;

        /// <summary>
        /// Gets a value indicating whether this instance is animating.
        /// </summary>
        /// <value><c>true</c> if this instance is animating; otherwise, <c>false</c>.</value>
        private bool IsAnimating
        {
            get
            {
                return _direction != 0;
            }
        }

        /// <summary>
        /// Fades the in.
        /// </summary>
        private void FadeIn()
        {
            _direction = 1;
            timer.Enabled = true;
        }

        /// <summary>
        /// Fades the out.
        /// </summary>
        private void FadeOut()
        {
            _direction = -1;
            timer.Enabled = true;
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                return;
            }
            Refresh();
            _currentFrame += _direction;
            if (_currentFrame == -1)
            {
                _currentFrame = 0;
                timer.Enabled = false;
                _direction = 0;
                return;
            }
            if (_currentFrame == framesCount)
            {
                _currentFrame = framesCount - 1;
                timer.Enabled = false;
                _direction = 0;
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

    }

    #region Designer Generated Code
    partial class ZeroitGlassButtonDefault
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
            try
            {
                if (disposing)
                {
                    if (_imageButton != null)
                    {
                        _imageButton.Parent.Dispose();
                        _imageButton.Parent = null;
                        _imageButton.Dispose();
                        _imageButton = null;
                    }
                    DestroyFrames();
                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            this.ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer;
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitGlassButtonDefaultDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitGlassButtonDefaultDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitGlassButtonDefaultSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitGlassButtonDefaultSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitGlassButtonDefaultSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitGlassButtonDefault colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGlassButtonDefaultSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitGlassButtonDefaultSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitGlassButtonDefault;

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
        /// Gets or sets the color of the inner border.
        /// </summary>
        /// <value>The color of the inner border.</value>
        public Color InnerBorderColor
        {
            get
            {
                return colUserControl.InnerBorderColor;
            }
            set
            {
                GetPropertyByName("InnerBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the outer border.
        /// </summary>
        /// <value>The color of the outer border.</value>
        public Color OuterBorderColor
        {
            get
            {
                return colUserControl.OuterBorderColor;
            }
            set
            {
                GetPropertyByName("OuterBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the shine.
        /// </summary>
        /// <value>The color of the shine.</value>
        public Color ShineColor
        {
            get
            {
                return colUserControl.ShineColor;
            }
            set
            {
                GetPropertyByName("ShineColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the glow.
        /// </summary>
        /// <value>The color of the glow.</value>
        public Color GlowColor
        {
            get
            {
                return colUserControl.GlowColor;
            }
            set
            {
                GetPropertyByName("GlowColor").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("InnerBorderColor",
                                 "Inner Border Color", "Appearance",
                                 "Sets the inner border color."));

            items.Add(new DesignerActionPropertyItem("OuterBorderColor",
                                 "Outer Border Color", "Appearance",
                                 "Sets the inner border color."));

            items.Add(new DesignerActionPropertyItem("ShineColor",
                                 "Shine Color", "Appearance",
                                 "Sets the shine color."));

            items.Add(new DesignerActionPropertyItem("GlowColor",
                                 "Glow Color", "Appearance",
                                 "Sets the glow color."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Sets the image of the control."));

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
