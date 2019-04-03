// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="KuzaButton.cs" company="Zeroit Dev Technologies">
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
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region ZeroitKuza Button


    #region Static Class
    /// <summary>
    /// Class ZeroitKuzaButtonCommon.
    /// </summary>
    static class ZeroitKuzaButtonCommon
    {
        /// <summary>
        /// Roundeds the rect.
        /// </summary>
        /// <param name="baseRect">The base rect.</param>
        /// <param name="topLeftRadius">The top left radius.</param>
        /// <param name="topRightRadius">The top right radius.</param>
        /// <param name="bottomLeftRadius">The bottom left radius.</param>
        /// <param name="bottomRightRadius">The bottom right radius.</param>
        /// <returns>System.Drawing.Drawing2D.GraphicsPath.</returns>
        public static System.Drawing.Drawing2D.GraphicsPath RoundedRect(
            System.Drawing.Rectangle baseRect, int topLeftRadius,
            int topRightRadius, int bottomLeftRadius, int bottomRightRadius)
        {
            int topLeftDiameter = topLeftRadius * 2;
            int topRightDiameter = topRightRadius * 2;
            int bottomLeftDiameter = bottomLeftRadius * 2;
            int bottomRightDiameter = bottomRightRadius * 2;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            System.Drawing.Rectangle rectTopLeft = new System.Drawing.Rectangle(
                baseRect.Left, baseRect.Top, topLeftDiameter, topLeftDiameter);
            System.Drawing.Rectangle rectTopRight = new System.Drawing.Rectangle(
                baseRect.Right - topRightDiameter, baseRect.Top, topRightDiameter, topRightDiameter);
            System.Drawing.Rectangle rectBottomLeft = new System.Drawing.Rectangle(
                baseRect.Left, baseRect.Bottom - bottomLeftDiameter, bottomLeftDiameter, bottomLeftDiameter);
            System.Drawing.Rectangle rectBottomRight = new System.Drawing.Rectangle(
                baseRect.Right - bottomRightDiameter, baseRect.Bottom - bottomRightDiameter, bottomRightDiameter, bottomRightDiameter);

            gp.AddArc(rectTopLeft, 180, 90);
            gp.AddArc(rectTopRight, 270, 90);
            gp.AddArc(rectBottomRight, 0, 90);
            gp.AddArc(rectBottomLeft, 90, 90);

            gp.CloseFigure();

            return gp;
        }

        /// <summary>
        /// Roundeds the rect.
        /// </summary>
        /// <param name="baseRect">The base rect.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <returns>System.Drawing.Drawing2D.GraphicsPath.</returns>
        public static System.Drawing.Drawing2D.GraphicsPath RoundedRect(
            System.Drawing.Rectangle baseRect, int cornerRadius)
        {
            int diameter = cornerRadius * 2;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            System.Drawing.Rectangle rectTopLeft = new System.Drawing.Rectangle(
                baseRect.Left, baseRect.Top, diameter, diameter);
            System.Drawing.Rectangle rectTopRight = new System.Drawing.Rectangle(
                baseRect.Right - diameter, baseRect.Top, diameter, diameter);
            System.Drawing.Rectangle rectBottomLeft = new System.Drawing.Rectangle(
                baseRect.Left, baseRect.Bottom - diameter, diameter, diameter);
            System.Drawing.Rectangle rectBottomRight = new System.Drawing.Rectangle(
                baseRect.Right - diameter, baseRect.Bottom - diameter, diameter, diameter);

            gp.AddArc(rectTopLeft, 180, 90);
            gp.AddArc(rectTopRight, 270, 90);
            gp.AddArc(rectBottomRight, 0, 90);
            gp.AddArc(rectBottomLeft, 90, 90);

            gp.CloseFigure();

            return gp;
        }
    }

    #endregion

    #region ZeroitKuzaButton

    /// <summary>
    /// A class collection for rendering Kuza button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    /// <seealso cref="System.Windows.Forms.IButtonControl" />
    [ToolboxItem(true)]
    [Designer(typeof(KuzaButtonDesigner))]
    public class ZeroitKuzaButton : Control, IButtonControl
    {

        #region Enumeration

        /// <summary>
        /// For Kuza Button Alignment
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// Sets the Alignment to Left
            /// </summary>
            Left,

            /// <summary>
            /// Sets the Alignment to Right
            /// </summary>
            Right
        };

        #endregion

        #region Private Fields
        /// <summary>
        /// The is mouse in
        /// </summary>
        private bool isMouseIn;
        /// <summary>
        /// The is mouse down
        /// </summary>
        private bool isMouseDown;
        /// <summary>
        /// The rounded corners
        /// </summary>
        private bool _roundedCorners = true;
        /// <summary>
        /// The show focus cue
        /// </summary>
        private bool _showFocusCue = true;
        /// <summary>
        /// The image alignment
        /// </summary>
        private Alignment _imageAlignment = Alignment.Right;

        /// <summary>
        /// The disabled style
        /// </summary>
        private SBButtonAppearance _disabledStyle = new SBButtonAppearance();
        /// <summary>
        /// The default style
        /// </summary>
        private SBButtonAppearance _defaultStyle = new SBButtonAppearance();
        /// <summary>
        /// The mouse over style
        /// </summary>
        private SBButtonAppearance _mouseOverStyle = new SBButtonAppearance();
        /// <summary>
        /// The mouse down style
        /// </summary>
        private SBButtonAppearance _mouseDownStyle = new SBButtonAppearance();

        /// <summary>
        /// The focus cue color
        /// </summary>
        private Color _focusCueColor = SystemColors.ControlDarkDark;

        /// <summary>
        /// The dialog result
        /// </summary>
        private DialogResult _dialogResult = DialogResult.None;

        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the Default style
        /// </summary>
        /// <value>The default style.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
        public SBButtonAppearance DefaultStyle
        {
            get
            {
                return _defaultStyle;
            }
            set
            {
                _defaultStyle = value;
            }
        }


        /// <summary>
        /// Sets the Mouse Hover style
        /// </summary>
        /// <value>The mouse over style.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
        public SBButtonAppearance MouseOverStyle
        {
            get
            {
                return _mouseOverStyle;
            }
        }

        /// <summary>
        /// Sets the Style when the Mouse is Clicked
        /// </summary>
        /// <value>The mouse down style.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
        public SBButtonAppearance MouseDownStyle
        {
            get
            {
                return _mouseDownStyle;
            }
        }

        /// <summary>
        /// Sets the Style when the button is not focused
        /// </summary>
        /// <value>The disabled style.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Appearance")]
        public SBButtonAppearance DisabledStyle
        {
            get
            {
                return _disabledStyle;
            }
        }

        /// <summary>
        /// Sets the Focus color
        /// </summary>
        /// <value>The color of the focus cue.</value>
        [Category("Appearance")]
        public Color FocusCueColor
        {
            get { return _focusCueColor; }
            set
            {
                _focusCueColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Set to enable Rounded corner
        /// </summary>
        /// <value><c>true</c> if [rounded corners]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        public bool RoundedCorners
        {
            get { return _roundedCorners; }
            set
            {
                _roundedCorners = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Set to show Focus
        /// </summary>
        /// <value><c>true</c> if [show focus cue]; otherwise, <c>false</c>.</value>
        [Category("Appearance")]
        public bool ShowFocusCue
        {
            get { return _showFocusCue; }
            set
            {
                _showFocusCue = value;
            }
        }

        /// <summary>
        /// The image
        /// </summary>
        private Image _image;

        /// <summary>
        /// Sets the Image
        /// </summary>
        /// <value>The image.</value>

        [Category("Appearance")]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image alignment
        /// </summary>
        /// <value>The image alignment.</value>
        [Category("Appearance")]
        public Alignment ImageAlignment
        {
            get { return _imageAlignment; }
            set
            {
                _imageAlignment = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Back color
        /// </summary>
        /// <value>The color of the back.</value>
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Sets the Fore color
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// Sets the Font
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false)]
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

        /// <summary>
        /// Sets the Background Image
        /// </summary>
        /// <value>The background image.</value>
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        /// <summary>
        /// Sets the Background Image Layout
        /// </summary>
        /// <value>The background image layout.</value>
        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        /// <summary>
        /// Sets the Text displayed on the button
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Dialog result
        /// </summary>
        /// <value>The dialog result.</value>
        [Category("Behavior")]
        public DialogResult DialogResult
        {
            get
            {
                return _dialogResult;
            }
            set
            {
                _dialogResult = value;
            }
        }


        #endregion

        #region IButtonControl Members

        /// <summary>
        /// This sets the Default notification.
        /// </summary>
        /// <param name="value">Set value</param>
        public void NotifyDefault(bool value)
        {
            //do nothing here
        }

        /// <summary>
        /// Sets the operation for Mouse Click event
        /// </summary>
        public void PerformClick()
        {
            base.OnClick(new EventArgs());
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
        /// Creates an instance of the ZeroitKuzaButton
        /// </summary>
        public ZeroitKuzaButton()
        {

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserMouse, true);

            this.BackColor = Color.Transparent;

            this.MouseOverStyle.BackColor1 = SystemColors.ButtonFace;
            this.MouseOverStyle.BackColor2 = SystemColors.ControlLightLight;
            this.MouseOverStyle.FillMode = LinearGradientMode.Vertical;

            this.MouseDownStyle.BackColor1 = SystemColors.ButtonFace;
            this.MouseDownStyle.BackColor2 = SystemColors.ControlDark;
            this.MouseDownStyle.FillMode = LinearGradientMode.Vertical;

            this.DisabledStyle.HightLightOpacity1 = 0;
            this.DisabledStyle.HightLightOpacity2 = 0;
            this.DisabledStyle.GlowOpacity = 0;
            this.DisabledStyle.TextColor = SystemColors.GrayText;

            this.DefaultStyle.SBButtonAppearanceChanged += new EventHandler<EventArgs>(DefaultStyle_SBButtonAppearanceChanged);

            IncludeInConstructor();

        }

        /// <summary>
        /// Handles the SBButtonAppearanceChanged event of the DefaultStyle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void DefaultStyle_SBButtonAppearanceChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

            if (!isMouseIn && !isMouseDown && this.Enabled)
                this.DrawDefault(e);

            if (isMouseIn && !isMouseDown && this.Enabled)
                this.DrawMouseOver(e);

            if (isMouseIn && isMouseDown && this.Enabled)
                this.DrawMouseDown(e);

            if (!isMouseIn && isMouseDown && this.Enabled)
                this.DrawMouseDown(e);

            if (!this.Enabled)
                this.DrawDisabled(e);

            if (this.Focused && this.ShowFocusCue && this.Enabled)
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(
                    2, 2, this.Width - 4, this.Height - 4), this.FocusCueColor,
                    ButtonBorderStyle.Dashed);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            isMouseIn = true;
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            isMouseIn = false;
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                this.Invalidate();
            }

            ClickOnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Select();

            isMouseDown = false;

            ClickOnMouseUp(e);

            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                isMouseDown = true;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            isMouseDown = false;

            if (e.KeyCode == Keys.Space)
                this.PerformClick();

            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs" /> that contains the event data.</param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.PerformClick();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.PerformClick();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            isMouseDown = false;
            this.Invalidate();
        }

        /// <summary>
        /// Processes a mnemonic character.
        /// </summary>
        /// <param name="charCode">The character to process.</param>
        /// <returns>true if the character was processed as a mnemonic by the control; otherwise, false.</returns>
        protected override bool ProcessMnemonic(char charCode)
        {
            if (CanSelect && IsMnemonic(charCode, this.Text))
            {
                this.PerformClick();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws the default.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawDefault(PaintEventArgs e)
        {
            LinearGradientBrush brBackground = new LinearGradientBrush(
                this.ClientRectangle, this.DefaultStyle.BackColor1, this.DefaultStyle.BackColor2,
                this.DefaultStyle.FillMode);
            LinearGradientBrush brHighlight = new LinearGradientBrush(new Rectangle(
                2, 2, this.Width - 5, this.Height / 2), Color.FromArgb(this.DefaultStyle.HightLightOpacity1, this.DefaultStyle.HighLightColor),
                Color.FromArgb(this.DefaultStyle.HightLightOpacity2, this.DefaultStyle.HighLightColor), LinearGradientMode.Vertical);
            LinearGradientBrush brGlow = new LinearGradientBrush(new Rectangle(
                0, this.Height - this.Height / 4 - 1, this.Width - 1, this.Height / 4),
                Color.Transparent, Color.FromArgb(this.DefaultStyle.GlowOpacity, this.DefaultStyle.GlowColor), LinearGradientMode.Vertical);

            Pen pnOuterBorder = new Pen(this.DefaultStyle.OuterBorderColor, 1);
            Pen pnInnerBorder = new Pen(Color.FromArgb(DefaultStyle.InnerBorderOpacity, this.DefaultStyle.InnerBorderColor));

            GraphicsPath gpBackground = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                0, 0, this.Width - 1, this.Height - 1), 3);
            GraphicsPath gpGlow = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4), 1, 1, 3, 3);
            GraphicsPath gpHighlight = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                2, 2, this.Width - 5, this.Height / 2 - 1), 3, 3, 1, 1);
            GraphicsPath gpOuterBorder = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                0, 0, this.Width - 1, this.Height - 1), 3);
            GraphicsPath gpInnerBorder = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                1, 1, this.Width - 3, this.Height - 3), 3);

            Rectangle rectBackground = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectGlow = new Rectangle(1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4);
            Rectangle rectHighlight = new Rectangle(2, 2, this.Width - 5, this.Height / 2 - 1);
            Rectangle rectOuterBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectInnerBorder = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

            Size textSize = TextRenderer.MeasureText(this.Text, this.DefaultStyle.Font);

            Point textPos = new Point(this.Width / 2 - textSize.Width / 2,
                this.Height / 2 - textSize.Height / 2);
            Point imagePos = new Point();

            switch (this.ImageAlignment)
            {
                case Alignment.Right:
                    if (this.Image != null)
                    {
                        textPos = new Point(5, this.Height / 2 - textSize.Height / 2);
                        imagePos = new Point(this.Width - this.Image.Width - 5,
                            this.Height / 2 - this.Image.Size.Height / 2);
                    }
                    break;
                case Alignment.Left:
                    if (this.Image != null)
                    {
                        textPos = new Point(this.Width - textSize.Width - 5,
                            this.Height / 2 - textSize.Height / 2);
                        imagePos = new Point(5, this.Height / 2 - this.Image.Size.Height / 2);
                    }
                    break;
            }

            if (this.RoundedCorners)
            {
                e.Graphics.FillPath(brBackground, gpBackground);
                e.Graphics.FillPath(brGlow, gpGlow);
                e.Graphics.FillPath(brHighlight, gpHighlight);
                e.Graphics.DrawPath(pnOuterBorder, gpOuterBorder);
                e.Graphics.DrawPath(pnInnerBorder, gpInnerBorder);
            }
            else
            {
                e.Graphics.FillRectangle(brBackground, rectBackground);
                e.Graphics.FillRectangle(brGlow, rectGlow);
                e.Graphics.FillRectangle(brHighlight, rectHighlight);
                e.Graphics.DrawRectangle(pnOuterBorder, rectOuterBorder);
                e.Graphics.DrawRectangle(pnInnerBorder, rectInnerBorder);
            }

            if (this.Image != null)
                e.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);

            TextRenderer.DrawText(e.Graphics, this.Text, this.DefaultStyle.Font, textPos, this.DefaultStyle.TextColor);
        }

        /// <summary>
        /// Draws the mouse over.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawMouseOver(PaintEventArgs e)
        {
            LinearGradientBrush brBackground = new LinearGradientBrush(
                this.ClientRectangle, this.MouseOverStyle.BackColor1, this.MouseOverStyle.BackColor2,
                this.MouseOverStyle.FillMode);
            LinearGradientBrush brHighlight = new LinearGradientBrush(new Rectangle(
                2, 2, this.Width - 5, this.Height / 2), Color.FromArgb(this.MouseOverStyle.HightLightOpacity1, this.MouseOverStyle.HighLightColor),
                Color.FromArgb(this.MouseOverStyle.HightLightOpacity2, this.MouseOverStyle.HighLightColor), LinearGradientMode.Vertical);
            LinearGradientBrush brGlow = new LinearGradientBrush(new Rectangle(
                0, this.Height - this.Height / 4 - 1, this.Width - 1, this.Height / 4),
                Color.Transparent, Color.FromArgb(this.MouseOverStyle.GlowOpacity, this.MouseOverStyle.GlowColor), LinearGradientMode.Vertical);

            Pen pnOuterBorder = new Pen(this.MouseDownStyle.OuterBorderColor, 1);
            Pen pnInnerBorder = new Pen(Color.FromArgb(MouseOverStyle.InnerBorderOpacity, this.MouseDownStyle.InnerBorderColor));

            GraphicsPath gpBackground = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                0, 0, this.Width - 1, this.Height - 1), 3);
            GraphicsPath gpGlow = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4), 1, 1, 3, 3);
            GraphicsPath gpHighlight = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                2, 2, this.Width - 5, this.Height / 2 - 1), 3, 3, 1, 1);
            GraphicsPath gpOuterBorder = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                0, 0, this.Width - 1, this.Height - 1), 3);
            GraphicsPath gpInnerBorder = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                1, 1, this.Width - 3, this.Height - 3), 3);

            Rectangle rectBackground = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectGlow = new Rectangle(1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4);
            Rectangle rectHighlight = new Rectangle(2, 2, this.Width - 5, this.Height / 2 - 1);
            Rectangle rectOuterBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectInnerBorder = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

            Size textSize = TextRenderer.MeasureText(this.Text, this.MouseOverStyle.Font);

            Point textPos = new Point(this.Width / 2 - textSize.Width / 2 - 1,
                this.Height / 2 - textSize.Height / 2 - 1);
            Point imagePos = new Point();

            switch (this.ImageAlignment)
            {
                case Alignment.Right:
                    if (this.Image != null)
                    {
                        textPos = new Point(4, this.Height / 2 - textSize.Height / 2 - 1);
                        imagePos = new Point(this.Width - this.Image.Width - 6,
                            this.Height / 2 - this.Image.Size.Height / 2 - 1);
                    }
                    break;
                case Alignment.Left:
                    if (this.Image != null)
                    {
                        textPos = new Point(this.Width - textSize.Width - 6,
                            this.Height / 2 - textSize.Height / 2 - 1);
                        imagePos = new Point(4, this.Height / 2 - this.Image.Size.Height / 2 - 1);
                    }
                    break;
            }

            if (this.RoundedCorners)
            {
                e.Graphics.FillPath(brBackground, gpBackground);
                e.Graphics.FillPath(brGlow, gpGlow);
                e.Graphics.FillPath(brHighlight, gpHighlight);
                e.Graphics.DrawPath(pnOuterBorder, gpOuterBorder);
                e.Graphics.DrawPath(pnInnerBorder, gpInnerBorder);
            }
            else
            {
                e.Graphics.FillRectangle(brBackground, rectBackground);
                e.Graphics.FillRectangle(brGlow, rectGlow);
                e.Graphics.FillRectangle(brHighlight, rectHighlight);
                e.Graphics.DrawRectangle(pnOuterBorder, rectOuterBorder);
                e.Graphics.DrawRectangle(pnInnerBorder, rectInnerBorder);
            }

            if (this.Image != null)
                e.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);

            TextRenderer.DrawText(e.Graphics, this.Text, this.MouseOverStyle.Font, textPos, this.MouseOverStyle.TextColor);
        }

        /// <summary>
        /// Draws the mouse down.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawMouseDown(PaintEventArgs e)
        {
            LinearGradientBrush brBackground = new LinearGradientBrush(
                this.ClientRectangle, this.MouseDownStyle.BackColor1, this.MouseDownStyle.BackColor2,
                this.MouseDownStyle.FillMode);
            LinearGradientBrush brHighlight = new LinearGradientBrush(new Rectangle(
                2, 2, this.Width - 5, this.Height / 2), Color.FromArgb(this.MouseDownStyle.HightLightOpacity1, this.MouseDownStyle.HighLightColor),
                Color.FromArgb(this.MouseDownStyle.HightLightOpacity2, this.MouseDownStyle.HighLightColor), LinearGradientMode.Vertical);
            LinearGradientBrush brGlow = new LinearGradientBrush(new Rectangle(
                0, this.Height - this.Height / 4 - 1, this.Width - 1, this.Height / 4),
                Color.Transparent, Color.FromArgb(this.MouseDownStyle.GlowOpacity, this.MouseDownStyle.GlowColor), LinearGradientMode.Vertical);

            Pen pnOuterBorder = new Pen(this.MouseDownStyle.OuterBorderColor, 1);
            Pen pnInnerBorder = new Pen(Color.FromArgb(MouseDownStyle.InnerBorderOpacity, this.MouseDownStyle.InnerBorderColor));

            GraphicsPath gpBackground = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                0, 0, this.Width - 1, this.Height - 1), 3);
            GraphicsPath gpGlow = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4), 1, 1, 3, 3);
            GraphicsPath gpHighlight = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                2, 2, this.Width - 5, this.Height / 2 - 1), 3, 3, 1, 1);
            GraphicsPath gpOuterBorder = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                0, 0, this.Width - 1, this.Height - 1), 3);
            GraphicsPath gpInnerBorder = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                1, 1, this.Width - 3, this.Height - 3), 3);

            Rectangle rectBackground = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectGlow = new Rectangle(1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4);
            Rectangle rectHighlight = new Rectangle(2, 2, this.Width - 5, this.Height / 2 - 1);
            Rectangle rectOuterBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectInnerBorder = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

            Size textSize = TextRenderer.MeasureText(this.Text, this.MouseDownStyle.Font);

            Point textPos = new Point(this.Width / 2 - textSize.Width / 2,
                this.Height / 2 - textSize.Height / 2);
            Point imagePos = new Point();

            switch (this.ImageAlignment)
            {
                case Alignment.Right:
                    if (this.Image != null)
                    {
                        textPos = new Point(5, this.Height / 2 - textSize.Height / 2);
                        imagePos = new Point(this.Width - this.Image.Width - 5,
                            this.Height / 2 - this.Image.Size.Height / 2);
                    }
                    break;
                case Alignment.Left:
                    if (this.Image != null)
                    {
                        textPos = new Point(this.Width - textSize.Width - 5,
                            this.Height / 2 - textSize.Height / 2);
                        imagePos = new Point(5, this.Height / 2 - this.Image.Size.Height / 2);
                    }
                    break;
            }

            if (this.RoundedCorners)
            {
                e.Graphics.FillPath(brBackground, gpBackground);
                e.Graphics.FillPath(brGlow, gpGlow);
                e.Graphics.FillPath(brHighlight, gpHighlight);
                e.Graphics.DrawPath(pnOuterBorder, gpOuterBorder);
                e.Graphics.DrawPath(pnInnerBorder, gpInnerBorder);
            }
            else
            {
                e.Graphics.FillRectangle(brBackground, rectBackground);
                e.Graphics.FillRectangle(brGlow, rectGlow);
                e.Graphics.FillRectangle(brHighlight, rectHighlight);
                e.Graphics.DrawRectangle(pnOuterBorder, rectOuterBorder);
                e.Graphics.DrawRectangle(pnInnerBorder, rectInnerBorder);
            }

            if (this.Image != null)
                e.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);

            TextRenderer.DrawText(e.Graphics, this.Text, this.MouseDownStyle.Font, textPos, this.MouseDownStyle.TextColor);
        }

        /// <summary>
        /// Draws the disabled.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void DrawDisabled(PaintEventArgs e)
        {
            LinearGradientBrush brBackground = new LinearGradientBrush(
                this.ClientRectangle, this.DisabledStyle.BackColor1, this.DisabledStyle.BackColor2,
                this.DefaultStyle.FillMode);
            LinearGradientBrush brHighlight = new LinearGradientBrush(new Rectangle(
                2, 2, this.Width - 5, this.Height / 2), Color.FromArgb(this.DisabledStyle.HightLightOpacity1, this.DisabledStyle.HighLightColor),
                Color.FromArgb(this.DisabledStyle.HightLightOpacity2, this.DisabledStyle.HighLightColor), LinearGradientMode.Vertical);
            LinearGradientBrush brGlow = new LinearGradientBrush(new Rectangle(
                0, this.Height - this.Height / 4 - 1, this.Width - 1, this.Height / 4),
                Color.Transparent, Color.FromArgb(this.DisabledStyle.GlowOpacity, this.DisabledStyle.GlowColor), LinearGradientMode.Vertical);

            Pen pnOuterBorder = new Pen(this.DisabledStyle.OuterBorderColor, 1);
            Pen pnInnerBorder = new Pen(Color.FromArgb(DisabledStyle.InnerBorderOpacity, this.DisabledStyle.InnerBorderColor));

            GraphicsPath gpBackground = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                0, 0, this.Width - 1, this.Height - 1), 3);
            GraphicsPath gpGlow = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4), 1, 1, 3, 3);
            GraphicsPath gpHighlight = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                2, 2, this.Width - 5, this.Height / 2 - 1), 3, 3, 1, 1);
            GraphicsPath gpOuterBorder = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                0, 0, this.Width - 1, this.Height - 1), 3);
            GraphicsPath gpInnerBorder = ZeroitKuzaButtonCommon.RoundedRect(new Rectangle(
                1, 1, this.Width - 3, this.Height - 3), 3);

            Rectangle rectBackground = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectGlow = new Rectangle(1, this.Height - this.Height / 4, this.Width - 3, this.Height / 4);
            Rectangle rectHighlight = new Rectangle(2, 2, this.Width - 5, this.Height / 2 - 1);
            Rectangle rectOuterBorder = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Rectangle rectInnerBorder = new Rectangle(1, 1, this.Width - 3, this.Height - 3);

            Size textSize = TextRenderer.MeasureText(this.Text, this.DisabledStyle.Font);

            Point textPos = new Point(this.Width / 2 - textSize.Width / 2,
                this.Height / 2 - textSize.Height / 2);
            Point imagePos = new Point();

            switch (this.ImageAlignment)
            {
                case Alignment.Right:
                    if (this.Image != null)
                    {
                        textPos = new Point(5, this.Height / 2 - textSize.Height / 2);
                        imagePos = new Point(this.Width - this.Image.Width - 5,
                            this.Height / 2 - this.Image.Size.Height / 2);
                    }
                    break;
                case Alignment.Left:
                    if (this.Image != null)
                    {
                        textPos = new Point(this.Width - textSize.Width - 5,
                            this.Height / 2 - textSize.Height / 2);
                        imagePos = new Point(5, this.Height / 2 - this.Image.Size.Height / 2);
                    }
                    break;
            }

            if (this.RoundedCorners)
            {
                e.Graphics.FillPath(brBackground, gpBackground);
                e.Graphics.FillPath(brGlow, gpGlow);
                e.Graphics.FillPath(brHighlight, gpHighlight);
                e.Graphics.DrawPath(pnOuterBorder, gpOuterBorder);
                e.Graphics.DrawPath(pnInnerBorder, gpInnerBorder);
            }
            else
            {
                e.Graphics.FillRectangle(brBackground, rectBackground);
                e.Graphics.FillRectangle(brGlow, rectGlow);
                e.Graphics.FillRectangle(brHighlight, rectHighlight);
                e.Graphics.DrawRectangle(pnOuterBorder, rectOuterBorder);
                e.Graphics.DrawRectangle(pnInnerBorder, rectInnerBorder);
            }

            if (this.Image != null)
                e.Graphics.DrawImage(this.Image, imagePos.X, imagePos.Y, this.Image.Width, this.Image.Height);

            TextRenderer.DrawText(e.Graphics, this.Text, this.DisabledStyle.Font, textPos, this.DisabledStyle.TextColor);
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

    /// <summary>
    /// A class collection for setting the appearance of the Kuza Button
    /// </summary>
    [Serializable()]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SBButtonAppearance
    {
        /// <summary>
        /// Occurs when [sb button appearance changed].
        /// </summary>
        public event EventHandler<EventArgs> SBButtonAppearanceChanged;

        /// <summary>
        /// The back color1
        /// </summary>
        private Color _backColor1 = SystemColors.ButtonFace;

        /// <summary>
        /// Sets the Back Color
        /// </summary>
        /// <value>The back color1.</value>
        /// <remarks>This sets the background color 1</remarks>
        public Color BackColor1
        {
            get { return _backColor1; }
            set
            {
                _backColor1 = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The back color2
        /// </summary>
        private Color _backColor2 = SystemColors.ButtonFace;

        /// <summary>
        /// Sets the Back Color
        /// </summary>
        /// <value>The back color2.</value>
        /// <remarks>This sets the background color 2</remarks>
        public Color BackColor2
        {
            get { return _backColor2; }
            set
            {
                _backColor2 = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The outer border color
        /// </summary>
        private Color _outerBorderColor = SystemColors.ControlDarkDark;

        /// <summary>
        /// Sets the Outer Border Color
        /// </summary>
        /// <value>The color of the outer border.</value>
        /// <remarks>This sets the outer border color 1</remarks>
        public Color OuterBorderColor
        {
            get { return _outerBorderColor; }
            set
            {
                _outerBorderColor = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The inner border color
        /// </summary>
        private Color _innerBorderColor = SystemColors.ControlLightLight;

        /// <summary>
        /// Sets the Inner Border Color
        /// </summary>
        /// <value>The color of the inner border.</value>
        /// <remarks>This sets the inner border color</remarks>
        public Color InnerBorderColor
        {
            get { return _innerBorderColor; }
            set
            {
                _innerBorderColor = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The glow color
        /// </summary>
        private Color _glowColor = SystemColors.ControlLightLight;

        /// <summary>
        /// Sets the Glow Color
        /// </summary>
        /// <value>The color of the glow.</value>
        /// <remarks>This sets the glow color</remarks>
        public Color GlowColor
        {
            get { return _glowColor; }
            set
            {
                _glowColor = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The high light color
        /// </summary>
        private Color _highLightColor = SystemColors.ControlLightLight;

        /// <summary>
        /// Sets the Highlight Color
        /// </summary>
        /// <value>The color of the high light.</value>
        public Color HighLightColor
        {
            get { return _highLightColor; }
            set
            {
                _highLightColor = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The text color
        /// </summary>
        private Color _textColor = SystemColors.ControlText;

        /// <summary>
        /// Sets the Text Color
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The font
        /// </summary>
        private Font _font = SystemFonts.DefaultFont;

        /// <summary>
        /// Sets the Font Color
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get { return _font; }
            set
            {
                _font = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The fill mode
        /// </summary>
        private LinearGradientMode _fillMode = LinearGradientMode.Horizontal;

        /// <summary>
        /// Sets the Fill mode
        /// </summary>
        /// <value>The fill mode.</value>
        public LinearGradientMode FillMode
        {
            get { return _fillMode; }
            set
            {
                _fillMode = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The inner border opacity
        /// </summary>
        private int _innerBorderOpacity = 200;

        /// <summary>
        /// Sets the Inner border opacity
        /// </summary>
        /// <value>The inner border opacity.</value>
        public int InnerBorderOpacity
        {
            get { return _innerBorderOpacity; }
            set
            {
                if (value > 255) value = 255;
                if (value < 0) value = 0;

                _innerBorderOpacity = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The high light opacity1
        /// </summary>
        private int _highLightOpacity1 = 200;

        /// <summary>
        /// Sets the Highlight opacity
        /// </summary>
        /// <value>The hight light opacity1.</value>
        /// <remarks>This sets highlight opacity 1</remarks>
        public int HightLightOpacity1
        {
            get { return _highLightOpacity1; }
            set
            {
                if (value > 255) value = 255;
                if (value < 0) value = 0;

                _highLightOpacity1 = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The high light opacity2
        /// </summary>
        private int _highLightOpacity2 = 150;

        /// <summary>
        /// Sets the Highlight opacity
        /// </summary>
        /// <value>The hight light opacity2.</value>
        /// <remarks>This sets highlight opacity 2</remarks>
        public int HightLightOpacity2
        {
            get { return _highLightOpacity2; }
            set
            {
                if (value > 255) value = 255;
                if (value < 0) value = 0;

                _highLightOpacity2 = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// The glow opacity
        /// </summary>
        private int _glowOpacity = 120;

        /// <summary>
        /// Sets the Glow opacity
        /// </summary>
        /// <value>The glow opacity.</value>
        public int GlowOpacity
        {
            get { return _glowOpacity; }
            set
            {
                if (value > 255) value = 255;
                if (value < 0) value = 0;

                _glowOpacity = value;
                AppearanceChanged();
            }
        }

        /// <summary>
        /// Sets to override the ToString
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return null;
        }

        /// <summary>
        /// Appearances the changed.
        /// </summary>
        private void AppearanceChanged()
        {
            EventHandler<EventArgs> temp = SBButtonAppearanceChanged;
            if (temp != null)
                temp(this, new EventArgs());
        }
    }


    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class KuzaButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class KuzaButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new KuzaButtonSmartTagActionList(this.Component));
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
    /// Class KuzaButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class KuzaButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitKuzaButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="KuzaButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public KuzaButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitKuzaButton;

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
        /// Gets or sets the color of the focus cue.
        /// </summary>
        /// <value>The color of the focus cue.</value>
        public Color FocusCueColor
        {
            get
            {
                return colUserControl.FocusCueColor;
            }
            set
            {
                GetPropertyByName("FocusCueColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [rounded corners].
        /// </summary>
        /// <value><c>true</c> if [rounded corners]; otherwise, <c>false</c>.</value>
        public bool RoundedCorners
        {
            get
            {
                return colUserControl.RoundedCorners;
            }
            set
            {
                GetPropertyByName("RoundedCorners").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show focus cue].
        /// </summary>
        /// <value><c>true</c> if [show focus cue]; otherwise, <c>false</c>.</value>
        public bool ShowFocusCue
        {
            get
            {
                return colUserControl.ShowFocusCue;
            }
            set
            {
                GetPropertyByName("ShowFocusCue").SetValue(colUserControl, value);
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
        /// Gets or sets the image alignment.
        /// </summary>
        /// <value>The image alignment.</value>
        public ZeroitKuzaButton.Alignment ImageAlignment
        {
            get
            {
                return colUserControl.ImageAlignment;
            }
            set
            {
                GetPropertyByName("ImageAlignment").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public new string Text
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
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value>The dialog result.</value>
        public DialogResult DialogResult
        {
            get
            {
                return colUserControl.DialogResult;
            }
            set
            {
                GetPropertyByName("DialogResult").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the default style.
        /// </summary>
        /// <value>The default style.</value>
        public SBButtonAppearance DefaultStyle
        {
            get
            {
                return colUserControl.DefaultStyle;
            }
            set
            {
                GetPropertyByName("DefaultStyle").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("FocusCueColor",
                                 "Focus Cue Color", "Appearance",
                                 "Sets the focus cue color."));

            items.Add(new DesignerActionPropertyItem("RoundedCorners",
                                 "Rounded Corners", "Appearance",
                                 "Sets the rounded corners."));

            items.Add(new DesignerActionPropertyItem("ShowFocusCue",
                "Show Focus Cue", "Appearance",
                "Sets the focus."));

            items.Add(new DesignerActionPropertyItem("Image",
                "Image", "Appearance",
                "Sets the Image."));

            items.Add(new DesignerActionPropertyItem("ImageAlignment",
                "Image Alignment", "Appearance",
                "Sets the Image Alignment."));

            items.Add(new DesignerActionPropertyItem("DialogResult",
                "Dialog Result", "Appearance",
                "Sets the Dialog Result."));

            items.Add(new DesignerActionPropertyItem("Text",
                "Text", "Appearance",
                "Sets the Text."));

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
