// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Aqua.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Button Aqua    
    /// <summary>
    /// A class collection for rendering acqua gradient button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Description("Aqua Button Control")]
    [Designer(typeof(ZeroitButtonAcquaGradientDesigner))]
    public class ZeroitAcquaGradientButton : Control
    {
        #region Class Constants

        /// <summary>
        /// The button default width
        /// </summary>
        private static int ButtonDefaultWidth = 80;

        // Set this to the height of your source bitmaps
        /// <summary>
        /// The button height
        /// </summary>
        private static int ButtonHeight = 30;

        // If your source bitmaps have shadows, set this 
        // to the shadow size so DrawText can position the 
        // label appears centered on the label
        /// <summary>
        /// The button shadow offset
        /// </summary>
        private static int ButtonShadowOffset = 5;

        // These settings approximate the pulse effect
        // of buttons on Mac OS X
        /// <summary>
        /// The pulse interval
        /// </summary>
        private static int PulseInterval = 70;
        /// <summary>
        /// The pulse gamma maximum
        /// </summary>
        private static float PulseGammaMax = 1.8f;
        /// <summary>
        /// The pulse gamma minimum
        /// </summary>
        private static float PulseGammaMin = 0.7f;
        /// <summary>
        /// The pulse gamma shift
        /// </summary>
        private static float PulseGammaShift = 0.2f;
        /// <summary>
        /// The pulse gamma reduction threshold
        /// </summary>
        private static float PulseGammaReductionThreshold = 0.2f;
        /// <summary>
        /// The pulse gamma shift reduction
        /// </summary>
        private static float PulseGammaShiftReduction = 0.5f;

        #endregion
        
        #region Member Variables

        // Appearance
        /// <summary>
        /// The pulse
        /// </summary>
        protected bool pulse = false;
        /// <summary>
        /// The size to label
        /// </summary>
        protected bool sizeToLabel = true;

        // Pulsing
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer;
        /// <summary>
        /// The gamma
        /// </summary>
        private float gamma, gammaShift;

        // Mouse tracking
        /// <summary>
        /// The pt mouse position
        /// </summary>
        protected Point ptMousePosition;
        /// <summary>
        /// The mouse pressed
        /// </summary>
        private bool mousePressed;

        //
        // Summary:
        //     Gets or sets a value indicating whether the button control is the default button.
        //
        // Returns:
        //     true if the button control is the default button; otherwise, false.
        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        public bool IsDefault { get; set; }


        // Images used to draw the button
        /// <summary>
        /// The img left
        /// </summary>
        private Image imgLeft, imgFill, imgRight;

        // Rectangles to position images on the button face
        /// <summary>
        /// The rc left
        /// </summary>
        private Rectangle rcLeft, rcRight;

        // Matrices for transparency transformation
        /// <summary>
        /// The ia default
        /// </summary>
        private ImageAttributes iaDefault, iaNormal;
        /// <summary>
        /// The cm default
        /// </summary>
        private ColorMatrix cmDefault, cmNormal;

        #endregion
        
        #region Constructors and Initializers

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAcquaGradientButton"/> class.
        /// </summary>
        public ZeroitAcquaGradientButton()
        {
            InitializeComponent();


            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.StandardClick, true);

            BackColor = Color.Transparent;

            pulse = true;

            IncludeInConstructor();

        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
        }

        #endregion
        
        #region Properties        
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitAcquaGradientButton" /> pulses. Note that only the default button can pulse.
        /// </summary>
        /// <value><c>true</c> if pulse; otherwise, <c>false</c>.</value>
        [Description("Determines whether the button pulses. Note that only the default button can pulse.")]
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Pulse
        {
            get { return pulse; }
            set { pulse = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the button should automatically size to fit the label.
        /// </summary>
        /// <value><c>true</c> if size to label; otherwise, <c>false</c>.</value>
        [Description("Determines whether the button should automatically size to fit the label")]
        [Category("Layout")]
        [DefaultValue(true)]
        public bool SizeToLabel
        {
            get { return sizeToLabel; }
            set
            {
                sizeToLabel = value;
                OnTextChanged(EventArgs.Empty);
            }
        }

        #endregion
        
        #region Property overrides

        /* AquaButton has a fixed height */
        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(ZeroitAcquaGradientButton.ButtonDefaultWidth,
                    ZeroitAcquaGradientButton.ButtonHeight);
            }
        }


        /* Shadow Control.Width to make it browsable */
        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <value>The width.</value>
        [Description("See also: SizeToLabel")]
        [Category("Layout")]
        [Browsable(true)]
        public new int Width
        {
            get { return base.Width; }
            set { base.Width = value; }
        }

        /* Shadow Control.Height to make it browsable and read only */
        /// <summary>
        /// Gets or sets the height of the control. Aqua buttons have a fixed height.
        /// </summary>
        /// <value>The height.</value>
        [Description("Aqua buttons have a fixed height")]
        [Category("Layout")]
        [Browsable(true)]
        [ReadOnly(true)]
        public new int Height { get { return base.Height; } }

        #endregion
        
        #region Method overrides

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.CreateControl" /> method.
        /// </summary>
        protected override void OnCreateControl()
        {
            LoadImages();
            InitializeGraphics();
        }


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            if (sizeToLabel)
            {
                Graphics g = this.CreateGraphics();
                SizeF sizeF = g.MeasureString(Text, Font);
                Width = imgLeft.Width + (int)sizeF.Width + imgRight.Width;
                g.Dispose();
            }
            Invalidate();
            Update();
            base.OnTextChanged(e);
        }



        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            base.Height = 27;

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Pulse = false;
            IsDefault = false;


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IsDefault = true;
            pulse = true;


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);


        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.Clear(Parent.BackColor);
            TransparentInPaint(g);
            Draw(g);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (pulse == true)
                StartPulsing();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (pulse == false)
                StopPulsing();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
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

                StopPulsing();
            }

            ClickOnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
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
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (mousePressed)
            {
                mousePressed = false;

                StartPulsing();

                Invalidate();
                Update();
            }

            ClickOnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs" /> that contains the event data.</param>
        public void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (mousePressed && e.KeyChar == '\x001B')  // Escape
            {
                mousePressed = false;

                StartPulsing();

                Invalidate();
                Update();
            }
        }

        #endregion
        
        #region Implementation

        /// <summary>
        /// Loads the images.
        /// </summary>
        public void LoadImages()
        {
            //imgLeft = new Bitmap(GetType(), "Button.left.png");
            //imgRight = new Bitmap(GetType(), "Button.right.png");
            //imgFill = new Bitmap(GetType(), "Button.fill.png");

            imgLeft = new Bitmap(Properties.Resources.aqualeft);
            imgRight = new Bitmap(Properties.Resources.aquaright);
            imgFill = new Bitmap(Properties.Resources.aquafill);
        }

        /// <summary>
        /// Initializes the graphics.
        /// </summary>
        public void InitializeGraphics()
        {
            // Rectangles for placing images relative to the client rectangle
            rcLeft = new Rectangle(1, 0, imgLeft.Width, imgLeft.Height);
            rcRight = new Rectangle(-1, 0, imgRight.Width, imgRight.Height);

            // Image attributes used to lighten default buttons

            cmDefault = new ColorMatrix();
            cmDefault.Matrix33 = 0.5f;  // reduce opacity by 50%

            iaDefault = new ImageAttributes();
            iaDefault.SetColorMatrix(cmDefault, ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            // Image attributes that lighten and desaturate normal buttons

            cmNormal = new ColorMatrix();

            // desaturate the image
            cmNormal.Matrix00 = 1 / 3f;
            cmNormal.Matrix01 = 1 / 3f;
            cmNormal.Matrix02 = 1 / 3f;
            cmNormal.Matrix10 = 1 / 3f;
            cmNormal.Matrix11 = 1 / 3f;
            cmNormal.Matrix12 = 1 / 3f;
            cmNormal.Matrix20 = 1 / 3f;
            cmNormal.Matrix21 = 1 / 3f;
            cmNormal.Matrix22 = 1 / 3f;
            cmNormal.Matrix33 = 0.5f;  // reduce opacity by 50%

            iaNormal = new ImageAttributes();
            iaNormal.SetColorMatrix(cmNormal, ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
        }

        /// <summary>
        /// Starts the pulsing.
        /// </summary>
        public void StartPulsing()
        {
            if (Focused && Pulse && !this.DesignModeDetected())
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = ZeroitAcquaGradientButton.PulseInterval;
                timer.Tick += new EventHandler(TimerOnTick);
                gamma = ZeroitAcquaGradientButton.PulseGammaMax;
                gammaShift = -ZeroitAcquaGradientButton.PulseGammaShift;
                timer.Start();
            }
        }

        /// <summary>
        /// Stops the pulsing.
        /// </summary>
        public void StopPulsing()
        {
            if (timer != null)
            {
                iaDefault.SetGamma(1.0f, ColorAdjustType.Bitmap);
                timer.Stop();
            }
        }

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        public void Draw(Graphics g)
        {
            DrawButton(g);
            DrawText(g);
        }

        /// <summary>
        /// Draws the button.
        /// </summary>
        /// <param name="g">The g.</param>
        public void DrawButton(Graphics g)
        {
            // Update our destination rectangles
            rcRight.X = this.Width - imgRight.Width;

            if (mousePressed)
            {
                if (ClientRectangle.Contains(ptMousePosition.X, ptMousePosition.Y))
                    DrawButtonState(g, iaDefault);
                else
                    DrawButtonState(g, iaNormal);
            }
            else if (pulse = true && IsDefault == true)
                DrawButtonState(g, iaDefault);
            else
                DrawButtonState(g, iaNormal);
        }

        /// <summary>
        /// Draws the state of the button.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="ia">The ia.</param>
        public void DrawButtonState(Graphics g, ImageAttributes ia)
        {
            TextureBrush tb;

            // Draw the left and right endcaps
            g.DrawImage(imgLeft, rcLeft, 0, 0,
                imgLeft.Width, imgLeft.Height, GraphicsUnit.Pixel, ia);

            g.DrawImage(imgRight, rcRight, 0, 0,
                imgRight.Width, imgRight.Height, GraphicsUnit.Pixel, ia);

            // Draw the middle
            tb = new TextureBrush(imgFill,
                new Rectangle(0, 0, imgFill.Width, imgFill.Height), ia);
            tb.WrapMode = WrapMode.Tile;

            g.FillRectangle(tb, imgLeft.Width, 0,
                this.Width - (imgLeft.Width + imgRight.Width),
                imgFill.Height);

            tb.Dispose();
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The g.</param>
        public void DrawText(Graphics g)
        {
            RectangleF layoutRect =
                new RectangleF(0, 0, this.Width,
                    this.Height - ZeroitAcquaGradientButton.ButtonShadowOffset);

            int LabelShadowOffset = 1;

            StringFormat fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;

            // Draw the shadow below the label
            layoutRect.Offset(0, LabelShadowOffset);
            SolidBrush textShadowBrush = new SolidBrush(Color.Gray);
            g.DrawString(Text, Font, textShadowBrush, layoutRect, fmt);
            textShadowBrush.Dispose();

            // and the label itself
            layoutRect.Offset(0, -LabelShadowOffset);
            SolidBrush brushFiller = new SolidBrush(Color.Black);
            g.DrawString(Text, Font, brushFiller, layoutRect, fmt);
            brushFiller.Dispose();
        }

        /// <summary>
        /// Timers the on tick.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void TimerOnTick(object obj, EventArgs e)
        {
            // set the new gamma level
            if ((gamma - ZeroitAcquaGradientButton.PulseGammaMin < ZeroitAcquaGradientButton.PulseGammaReductionThreshold) ||
                (ZeroitAcquaGradientButton.PulseGammaMax - gamma < ZeroitAcquaGradientButton.PulseGammaReductionThreshold))
                gamma += gammaShift * ZeroitAcquaGradientButton.PulseGammaShiftReduction;
            else
                gamma += gammaShift;

            if (gamma <= ZeroitAcquaGradientButton.PulseGammaMin || gamma >= ZeroitAcquaGradientButton.PulseGammaMax)
                gammaShift = -gammaShift;

            iaDefault.SetGamma(gamma, ColorAdjustType.Bitmap);

            Invalidate();
            Update();
        }

        /// <summary>
        /// Designs the mode detected.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DesignModeDetected()
        {
            // base.DesignMode always returns false, so try this workaround
            IDesignerHost host =
                (IDesignerHost)this.GetService(typeof(IDesignerHost));

            return (host != null);
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

    /// <summary>
    /// Class ZeroitButtonAcquaGradientDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    public class ZeroitButtonAcquaGradientDesigner : System.Windows.Forms.Design.ControlDesigner
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonAcquaGradientDesigner"/> class.
        /// </summary>
        public ZeroitButtonAcquaGradientDesigner()
        {
        }

        //Overrides

        /// <summary>
        /// Remove Button and Control properties that are
        /// not supported by the Aqua Button
        /// </summary>
        /// <param name="Properties">The properties.</param>
        protected override void PostFilterProperties(IDictionary Properties)
        {
            //Properties.Remove("AllowDrop");
            //Properties.Remove("BackColor");
            //Properties.Remove("BackgroundImage");
            //Properties.Remove("ContextMenu");
            //Properties.Remove("FlatStyle");
            //Properties.Remove("ForeColor");
            //Properties.Remove("Image");
            //Properties.Remove("ImageAlign");
            //Properties.Remove("ImageIndex");
            //Properties.Remove("ImageList");
            //Properties.Remove("Size");
            //Properties.Remove("TextAlign");
        }
    }

    #endregion


}
