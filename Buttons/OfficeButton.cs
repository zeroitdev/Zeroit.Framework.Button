// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="OfficeButton.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region OfficeButton    
    /// <summary>
    /// A class collection for rendering an office like button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    public class ZeroitOfficeButton : System.Windows.Forms.Button
    {
        #region Enum
        /// <summary>
        /// Enum representing the button state
        /// </summary>
        public enum ZeroitButtonState
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The pressed
            /// </summary>
            Pressed,
            /// <summary>
            /// The selected
            /// </summary>
            Selected
        }
        #endregion

        #region Fields
        /// <summary>
        /// The button state
        /// </summary>
        ZeroitButtonState _buttonState = ZeroitButtonState.None;
        /// <summary>
        /// The selection blend
        /// </summary>
        ColorBlend _selectionBlend = null;
        /// <summary>
        /// The interpolation colors
        /// </summary>
        Color[] _interpolationColors = null;
        /// <summary>
        /// The definition padding
        /// </summary>
        Int32 DEF_PADDING = 10;
        #endregion

        #region Properties
        /// <summary>
        /// The gradient mode
        /// </summary>
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;

        /// <summary>
        /// Gets or sets the linear gradient mode.
        /// </summary>
        /// <value>The gradient mode.</value>
        public LinearGradientMode GradientMode
        {
            get
            {
                return gradientMode;
            }

            set
            {
                gradientMode = value;
                Invalidate();
            }
        }
        /// <summary>
        /// Gets the interpolation colors.
        /// </summary>
        /// <value>The interpolation colors.</value>
        internal Color[] InterpolationColors
        {
            get
            {
                if (_interpolationColors == null)
                {
                    _interpolationColors = new Color[]
                    {
                        Color.FromArgb(255,226,119),
                        Color.FromArgb(255,227,124),
                        Color.FromArgb(255,229,133),
                        Color.FromArgb(255,238,164),
                        Color.FromArgb(255,244,192),
                        Color.FromArgb(255,250,214),
                        Color.FromArgb(255,252,224)
                    };
                }

                return _interpolationColors;
            }
        }

        /// <summary>
        /// Gets or sets the state of the button.
        /// </summary>
        /// <value>The state of the button.</value>
        public ZeroitButtonState ButtonState
        {
            get { return _buttonState; }
            set { _buttonState = value; }
        }

        /// <summary>
        /// Gets the selection blend.
        /// </summary>
        /// <value>The selection blend.</value>
        internal ColorBlend SelectionBlend
        {
            get
            {
                if (_selectionBlend == null)
                {
                    _selectionBlend = new ColorBlend(7);
                    _selectionBlend.Positions = new float[]
                    {
                       0F,
                       0.83F,
                       0.86F,
                       0.9F,
                       0.93F,
                       0.96F,
                       1F
                    };
                }

                return _selectionBlend;
            }

        }

        #endregion

        #region Ctor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitOfficeButton" /> class.
        /// </summary>
        public ZeroitOfficeButton()
        {
            IncludeInConstructor();
        }
        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnPaint(System.Windows.Forms.PaintEventArgs)" /> event.
        /// </summary>
        /// <param name="pevent">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            TransparentInPaint(pevent.Graphics);

            PaintButtonBackground(pevent);

            PaintImageAndText(pevent);

            PaintButtonBorder(pevent);
        }

        #endregion

        #region Implementations

        /// <summary>
        /// Paints the image and text.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PaintImageAndText(PaintEventArgs e)
        {
            Rectangle txtRect = GetTextRectangle(e.Graphics);
            Rectangle imgRect = Rectangle.Empty;
            Rectangle client = this.ClientRectangle;

            if (this.Image != null)
            {
                imgRect = new Rectangle(Point.Empty, this.Image.Size);

                e.Graphics.DrawImageUnscaled(this.Image, new Point((this.Width - imgRect.Width) / 2, DEF_PADDING));
            }

            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, new Point((this.Width - txtRect.Width) / 2, imgRect.Height + 2 * DEF_PADDING));
        }

        /// <summary>
        /// Gets the text rectangle.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <returns>Rectangle.</returns>
        private Rectangle GetTextRectangle(Graphics graphics)
        {
            Size sz = TextRenderer.MeasureText(graphics, this.Text, this.Font, Size.Empty, TextFormatFlags.WordBreak);
            return new Rectangle(Point.Empty, sz);
        }

        /// <summary>
        /// Paints the button background.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PaintButtonBackground(PaintEventArgs e)
        {
            ZeroitButtonState state = GetButtonState();

            using (LinearGradientBrush brush = GetBackgroundGradientBrush(state))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        /// <summary>
        /// Gets the background gradient brush.
        /// </summary>
        /// <param name="buttonState">State of the button.</param>
        /// <returns>LinearGradientBrush.</returns>
        private LinearGradientBrush GetBackgroundGradientBrush(ZeroitButtonState buttonState)
        {
            Color gradientBegin = Color.Empty;
            Color gradientEnd = Color.Empty;

            switch (buttonState)
            {
                case ZeroitButtonState.None:
                    gradientBegin = Color.FromArgb(163, 163, 163);
                    gradientEnd = Color.FromArgb(201, 201, 201);
                    break;
                case ZeroitButtonState.Pressed:
                    gradientBegin = Color.FromArgb(254, 226, 135);
                    gradientEnd = Color.FromArgb(251, 214, 120);
                    break;
                case ZeroitButtonState.Selected:
                    LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, gradientEnd, gradientBegin, gradientMode);
                    this.SelectionBlend.Colors = this.InterpolationColors;
                    brush.InterpolationColors = this.SelectionBlend;
                    return brush;
            }
            return new LinearGradientBrush(this.ClientRectangle, gradientEnd, gradientBegin, gradientMode);
        }

        /// <summary>
        /// Paints the button border.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PaintButtonBorder(PaintEventArgs e)
        {
            PaintButtonBorder(e, GetButtonState());
        }

        /// <summary>
        /// Paints the button border.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <param name="buttonState">State of the button.</param>
        private void PaintButtonBorder(PaintEventArgs e, ZeroitButtonState buttonState)
        {
            Rectangle border = this.ClientRectangle;
            border.Inflate(0, 0);
            border.Size = new Size(this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);

            switch (buttonState)
            {
                case ZeroitButtonState.Pressed:
                    {
                        using (Pen borderPen = new Pen(Color.FromArgb(194, 118, 43)))
                        {
                            e.Graphics.DrawRectangle(borderPen, border);
                        }
                    }
                    break;
                case ZeroitButtonState.Selected:
                    {
                        Rectangle innerLine = border;
                        innerLine.Inflate(-1, -1);
                        innerLine.Size = new Size(border.Width - 2, border.Height - 2);

                        using (Pen borderPen = new Pen(Color.FromArgb(248, 212, 39)))
                        {
                            e.Graphics.DrawRectangle(borderPen, border);
                        }

                        using (Pen borderPen = new Pen(Color.WhiteSmoke))
                        {
                            e.Graphics.DrawRectangle(borderPen, innerLine);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets the state of the button.
        /// </summary>
        /// <returns>ZeroitButtonState.</returns>
        protected ZeroitButtonState GetButtonState()
        {
            Point mousePosition = this.PointToClient(Control.MousePosition);

            if (this.ClientRectangle.Contains(mousePosition))
            {
                if (Control.MouseButtons == MouseButtons.None)
                    return ZeroitButtonState.Selected;
                else
                    return ZeroitButtonState.Pressed;
            }

            return ZeroitButtonState.None;
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

    #endregion


}
