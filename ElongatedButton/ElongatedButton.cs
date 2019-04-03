// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ElongatedButton.cs" company="Zeroit Dev Technologies">
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
    #region Elongated Button

    /// <summary>
    /// A class for rendering ZeroitElongButton.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ButtonBase" />
    /// <seealso cref="Zeroit.Framework.Button.IGradientButtonColor" />
    /// <seealso cref="System.Windows.Forms.IButtonControl" />
    [Designer(typeof(ElongatedButtonDesigner))]
    public class ZeroitElongButton : System.Windows.Forms.ButtonBase,
        IGradientButtonColor, System.Windows.Forms.IButtonControl
    {

        #region Image Designer

        #region Include in paint method

        /////////////////////////////////////////////////////////////////////////////////////////////////// 
        // ------------------------Add this to the Paint Method ------------------------       Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   if ((Image == null))                                                                        {                                                                                       _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           {                                                                               Alignment = _TextAlignment,                                                 LineAlignment = StringAlignment.Center                                      });                                                                             }                                                                                      else                                                                                        {                                                                                      _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          {                                                                               Alignment = _TextAlignment,                                                 LineAlignment = StringAlignment.Center                                      });                                                                             }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion

        #region Include in Private Fields
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// The text alignment
        /// </summary>
        private StringAlignment _TextAlignment = StringAlignment.Center;

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// The custom colors
        /// </summary>
        private CustomColors customColors = new CustomColors();

        /// <summary>
        /// Set the custom colors.
        /// </summary>
        /// <value>The custom colors.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public CustomColors CustomColors
        {
            get { return customColors; }
            set
            {
                customColors = value;

                oColorScheme = new ZeroitGroupButtonColorScheme(mColorScheme);
                oColorScheme.SetColorScheme(this, customColors);

                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image Alignment
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image to be used
        /// </summary>
        /// <value>The image.</value>
        /// <remarks>Default image is null.</remarks>
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (value == null)
                {
                    _ImageSize = Size.Empty;
                }
                else
                {
                    _ImageSize = value.Size;
                }

                _Image = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the size of the Image
        /// </summary>
        /// <value>The size of the image.</value>
        public Size ImageSize
        {
            get { return _ImageSize; }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }



        #endregion

        #region Include in Private Methods
        /// <summary>
        /// Images the location.
        /// </summary>
        /// <param name="SF">The sf.</param>
        /// <param name="Area">The area.</param>
        /// <param name="ImageArea">The image area.</param>
        /// <returns>PointF.</returns>
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        /// <summary>
        /// Gets the string format.
        /// </summary>
        /// <param name="_ContentAlignment">The content alignment.</param>
        /// <returns>StringFormat.</returns>
        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion
        #endregion

        #region Enums
        /// <summary>
        /// Enum ControlState
        /// </summary>
        private enum ControlState
        {
            /// <summary>
            /// The normal
            /// </summary>
            Normal,
            /// <summary>
            /// The pressed
            /// </summary>
            Pressed,
        }
        #endregion

        #region Private Data Members
        /// <summary>
        /// The enm state
        /// </summary>
        private ControlState enmState = ControlState.Normal;
        /// <summary>
        /// The m color scheme
        /// </summary>
        private EnmColorScheme mColorScheme = EnmColorScheme.Yellow;
        /// <summary>
        /// The color background1
        /// </summary>
        private Color clrBackground1;
        /// <summary>
        /// The color background2
        /// </summary>
        private Color clrBackground2;
        /// <summary>
        /// The color disabled background1
        /// </summary>
        private Color clrDisabledBackground1;
        /// <summary>
        /// The color disabled background2
        /// </summary>
        private Color clrDisabledBackground2;
        /// <summary>
        /// The color border1
        /// </summary>
        private Color clrBorder1;
        /// <summary>
        /// The color border2
        /// </summary>
        private Color clrBorder2;
        /// <summary>
        /// The color default border
        /// </summary>
        private Color clrDefaultBorder;
        /// <summary>
        /// The color font mouse up
        /// </summary>
        private Color clrFontMouseUp;
        /// <summary>
        /// The color font mouse down
        /// </summary>
        private Color clrFontMouseDown;
        /// <summary>
        /// The color font disabled
        /// </summary>
        private Color clrFontDisabled;
        /// <summary>
        /// My dialog result
        /// </summary>
        private DialogResult myDialogResult;
        /// <summary>
        /// The o color scheme
        /// </summary>
        private ZeroitGroupButtonColorScheme oColorScheme;

        #region Private Properties
        /// <summary>
        /// Gets the border rectangle.
        /// </summary>
        /// <value>The border rectangle.</value>
        private Rectangle BorderRectangle
        {
            get
            {
                Rectangle rc = this.ClientRectangle;
                if (rc.Height % 2 == 0)
                {
                    return new Rectangle(1, 1, rc.Width - 3, rc.Height - 2);
                }
                else
                {
                    return new Rectangle(1, 1, rc.Width - 3, rc.Height - 3);
                }
            }
        }
        #endregion

        #endregion

        #region Public Properties

        /// <summary>
        /// This sets the BackColor
        /// </summary>
        /// <value>The color of the back.</value>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// Sets the FlatStyle
        /// </summary>
        /// <value>The flat style.</value>
        public new FlatStyle FlatStyle
        {
            get
            {
                return base.FlatStyle;
            }
            set
            {
                base.FlatStyle = FlatStyle.Standard;
            }
        }

        /// <summary>
        /// Sets the Color Scheme
        /// </summary>
        /// <value>The color scheme.</value>
        public EnmColorScheme ColorScheme
        {
            get
            {
                return mColorScheme;
            }
            set
            {
                mColorScheme = value;
                
                oColorScheme = new ZeroitGroupButtonColorScheme(mColorScheme);
                oColorScheme.SetColorScheme(this,customColors);
                Invalidate();
            }
        }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Interface Implementation of Background Bottom Color.
        /// <para>
        /// This sets the Background bottom Color
        /// </para>
        /// </summary>
        /// <value>The color of the background bottom.</value>
        Color IGradientBackgroundColor.BackgroundBottomColor
        {
            get
            {
                return clrBackground2;
            }
            set
            {
                clrBackground2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Background Top Color.
        /// <para>
        /// This sets the Top background Color
        /// </para>
        /// </summary>
        /// <value>The color of the background top.</value>
        Color IGradientBackgroundColor.BackgroundTopColor
        {
            get
            {
                return clrBackground1;
            }
            set
            {
                clrBackground1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Border bottom Color.
        /// <para>
        /// This sets the Bottom border Color
        /// </para>
        /// </summary>
        /// <value>The color of the border bottom.</value>
        Color IGradientBorderColor.BorderBottomColor
        {
            get
            {
                return clrBorder1;
            }
            set
            {
                clrBorder1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Border Top Color.
        /// <para>
        /// This sets the Top border Color
        /// </para>
        /// </summary>
        /// <value>The color of the border top.</value>
        Color IGradientBorderColor.BorderTopColor
        {
            get
            {
                return clrBorder2;
            }
            set
            {
                clrBorder2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Disabled Bottom Color.
        /// <para>
        /// This sets the Disabled Bottom Color
        /// </para>
        /// </summary>
        /// <value>The color of the disbaled bottom.</value>
        Color IGradientDisabledColor.DisbaledBottomColor
        {
            get
            {
                return clrDisabledBackground2;
            }
            set
            {
                clrDisabledBackground2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Disabled Top Color.
        /// <para>
        /// This sets the Disabled Top Color
        /// </para>
        /// </summary>
        /// <value>The color of the disabled top.</value>
        Color IGradientDisabledColor.DisabledTopColor
        {
            get
            {
                return clrDisabledBackground1;
            }
            set
            {
                clrDisabledBackground1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Font Color.
        /// <para>
        /// This sets the Font Color
        /// </para>
        /// </summary>
        /// <value>The color of the font.</value>
        Color IFontColor.FontColor
        {
            get
            {
                return clrFontMouseUp;
            }
            set
            {
                clrFontMouseUp = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Pressed Font Color.
        /// <para>
        /// This sets the Pressed Font Color
        /// </para>
        /// </summary>
        /// <value>The color of the pressed font.</value>
        Color IGradientButtonColor.PressedFontColor
        {
            get
            {
                return clrFontMouseDown;
            }
            set
            {
                clrFontMouseDown = value;
            }
        }

        /// <summary>
        /// Interface Implementation of Disabled Font Color.
        /// <para>
        /// This sets the Top Background Color
        /// </para>
        /// </summary>
        /// <value>The color of the disabled font.</value>
        Color IGradientDisabledColor.DisabledFontColor
        {
            get
            {
                return clrFontDisabled;
            }
            set
            {
                clrFontDisabled = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Default Border Color.
        /// <para>
        /// This sets the Default Border Color
        /// </para>
        /// </summary>
        /// <value>The default color of the border.</value>
        System.Drawing.Color IGradientButtonColor.DefaultBorderColor
        {
            get
            {
                return clrDefaultBorder;
            }
            set
            {
                clrDefaultBorder = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Interface Implementation of Dialog Result.
        /// <para>
        /// This sets the Dialog result
        /// </para>
        /// </summary>
        /// <value>The dialog result.</value>
        // Add implementation to the IButtonControl.DialogResult property.
        public DialogResult DialogResult
        {
            get
            {
                return this.myDialogResult;
            }

            set
            {
                if (Enum.IsDefined(typeof(DialogResult), value))
                {
                    this.myDialogResult = value;
                }
            }
        }

        /// <summary>
        /// Interface Implementation of Defualt notification.
        /// <para>
        /// This sets the Default notification
        /// </para>
        /// </summary>
        /// <param name="value">true if the control should behave as a default button; otherwise false.</param>
        // Add implementation to the IButtonControl.NotifyDefault method.
        public void NotifyDefault(bool value)
        {
            if (this.IsDefault != value)
            {
                this.IsDefault = value;
            }
        }

        /// <summary>
        /// Interface Implementation of Perform Click.
        /// <para>
        /// This sets the functionality for performing tasks when the mouse is clicked.
        /// </para>
        /// </summary>
        // Add implementation to the IButtonControl.PerformClick method.
        public void PerformClick()
        {
            if (this.CanSelect)
            {
                this.OnClick(EventArgs.Empty);
            }
        }

        #endregion

        /// <summary>
        /// Creates an instance of the Elongated Button
        /// </summary>
        public ZeroitElongButton() : base()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            this.Height = 17;
            this.Font = new Font("Tahoma", 8);
            clrBackground1 = Color.FromArgb(248, 245, 224);
            clrBackground2 = Color.FromArgb(194, 168, 120);

            clrFontDisabled = Color.FromArgb(156, 147, 113);
            clrFontMouseUp = Color.FromArgb(96, 83, 43);
            clrFontMouseDown = Color.Black;

            clrBorder1 = Color.FromArgb(229, 219, 196);
            clrBorder2 = Color.FromArgb(194, 168, 120);

            clrDefaultBorder = Color.FromArgb(189, 153, 74);

            clrDisabledBackground1 = Color.FromArgb(241, 236, 212);
            clrDisabledBackground2 = Color.FromArgb(216, 198, 159);

            //oColorScheme = new ZeroitGroupButtonColorScheme(mColorScheme);
            IncludeInConstructor();
        }

        #region Private Methods

        //Gets the Shadow colors which are the alpha colors of the 
        /// <summary>
        /// Gets the shadow brushes.
        /// </summary>
        /// <returns>Brush[].</returns>
        private Brush[] GetShadowBrushes()
        {
            int cintShadow = 2;
            Brush[] arrBrushes = new Brush[cintShadow - 1];
            int intAlphaOffset = 35;
            int intMaxAlpha = cintShadow * intAlphaOffset;

            for (int intIndex = 0; intIndex <= arrBrushes.GetUpperBound(0); intIndex++)
            {
                arrBrushes[intIndex] = new SolidBrush(Color.FromArgb(intMaxAlpha - (intIndex * intAlphaOffset), 174, 167, 124));
            }

            return arrBrushes;
        }

        /// <summary>
        /// Called when [draw default].
        /// </summary>
        /// <param name="g">The g.</param>
        private void OnDrawDefault(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;
            GraphicsPath myPath = GetGraphicPath(rcBorder);

            LinearGradientBrush brushBackGround =
                new LinearGradientBrush(rcBorder, clrBackground1, clrBackground2, LinearGradientMode.Vertical);
            Single[] relativeIntensisities = new Single[] { 0.0F, 0.08F, 1.0F };
            Single[] relativePositions = new Single[] { 0.0F, 0.44F, 1.0F };
            Blend blend = new Blend();

            blend.Factors = relativeIntensisities;
            blend.Positions = relativePositions;
            brushBackGround.Blend = blend;

            g.FillPath(brushBackGround, myPath);

            //Draw dark to light border for default button
            SolidBrush brushPen = new SolidBrush(clrDefaultBorder);
            Pen ps = new Pen(brushPen);

            DrawBorder(g, ps, this.BorderRectangle);
            brushPen = new SolidBrush(Color.FromArgb(128, clrDefaultBorder));
            ps = new Pen(brushPen);
            Rectangle rc = new Rectangle(this.BorderRectangle.X + 1, this.BorderRectangle.Y + 1, this.BorderRectangle.Width - 2, this.BorderRectangle.Height - 2);
            DrawBorder(g, ps, rc);
            rc.X += 1;
            rc.Y += 1;
            rc.Width -= 2;
            rc.Height -= 2;
            brushPen = new SolidBrush(Color.FromArgb(64, clrDefaultBorder));
            ps = new Pen(brushPen);
            DrawBorder(g, ps, rc);
        }

        /// <summary>
        /// Called when [draw normal].
        /// </summary>
        /// <param name="g">The g.</param>
        private void OnDrawNormal(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;
            GraphicsPath myPath = GetGraphicPath(rcBorder);
            Region rgn = new Region(this.BorderRectangle);
            rgn.Intersect(myPath);
            LinearGradientBrush brushBackGround =
                new LinearGradientBrush(rcBorder, clrBackground1, clrBackground2, LinearGradientMode.Vertical);
            Single[] relativeIntensisities = new Single[] { 0.0F, 0.08F, 1.0F };
            Single[] relativePositions = new Single[] { 0.0F, 0.44F, 1.0F };
            Blend blend = new Blend();
            blend.Factors = relativeIntensisities;
            blend.Positions = relativePositions;
            brushBackGround.Blend = blend;

            g.FillRegion(brushBackGround, rgn);

            LinearGradientBrush brushPen =
                new LinearGradientBrush(this.BorderRectangle, clrBorder1, clrBorder2, LinearGradientMode.ForwardDiagonal);

            brushPen.Blend = blend;
            Pen ps = new Pen(brushPen);

            DrawBorder(g, ps, this.BorderRectangle);
        }

        //Create Grahics Path for the elongated buttons
        /// <summary>
        /// Gets the graphic path.
        /// </summary>
        /// <param name="rc">The rc.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath GetGraphicPath(Rectangle rc)
        {
            int adjust = rc.Height % 2 == 0 ? 0 : 1;

            GraphicsPath Mypath = new GraphicsPath();

            //Add Top Line
            Mypath.AddLine(rc.Left + (Single)(rc.Height / 2), rc.Top, rc.Right - (Single)(rc.Height / 2), rc.Top);
            //Add Right Semi Circle
            Mypath.AddArc(rc.Right - rc.Height, rc.Top, rc.Height, rc.Height, 270, 180);
            //Add Bottom Line
            Mypath.AddLine(rc.Right - (Single)(rc.Height / 2) - adjust, rc.Bottom, rc.Left + (Single)(rc.Height / 2) + adjust, rc.Bottom);
            //Add Left Semi Circle
            Mypath.AddArc(rc.Left, rc.Top, rc.Height, rc.Height, 90, 180);

            return Mypath;
        }

        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="p">The p.</param>
        /// <param name="rc">The rc.</param>
        private void DrawBorder(Graphics g, Pen p, Rectangle rc)
        {
            int adjust = rc.Height % 2 == 0 ? 0 : 1;

            g.DrawLine(p, rc.Left + (Single)(rc.Height / 2), rc.Top, rc.Right - (Single)(rc.Height / 2), rc.Top);
            g.DrawArc(p, rc.Right - rc.Height, rc.Top, rc.Height, rc.Height, 270, 180);
            g.DrawLine(p, rc.Right - (Single)(rc.Height / 2) - adjust, rc.Bottom, rc.Left + (Single)(rc.Height / 2) + adjust, rc.Bottom);
            g.DrawArc(p, rc.Left, rc.Top, rc.Height, rc.Height, 90, 180);
        }

        /// <summary>
        /// Called when [draw disabled].
        /// </summary>
        /// <param name="g">The g.</param>
        private void OnDrawDisabled(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;
            GraphicsPath myPath = GetGraphicPath(rcBorder);

            LinearGradientBrush brushBackGround =
                new LinearGradientBrush(rcBorder, clrDisabledBackground1, clrDisabledBackground2, LinearGradientMode.Vertical);

            Single[] relativeIntensisities = new Single[] { 0.0F, 0.08F, 1.0F };
            Single[] relativePositions = new Single[] { 0.0F, 0.44F, 1.0F };

            Blend blend = new Blend();
            blend.Factors = relativeIntensisities;
            blend.Positions = relativePositions;
            brushBackGround.Blend = blend;
            g.FillPath(brushBackGround, myPath);
            LinearGradientBrush brushPen = new LinearGradientBrush(this.BorderRectangle, clrBorder1, clrBorder2, LinearGradientMode.ForwardDiagonal);
            brushPen.Blend = blend;
            Pen ps = new Pen(brushPen);
            DrawBorder(g, ps, this.BorderRectangle);
        }

        /// <summary>
        /// Called when [draw pressed].
        /// </summary>
        /// <param name="g">The g.</param>
        private void OnDrawPressed(Graphics g)
        {
            Rectangle rcBorder = this.BorderRectangle;
            GraphicsPath myPath = GetGraphicPath(rcBorder);

            LinearGradientBrush brushBackGround =
                new LinearGradientBrush(rcBorder, clrBackground2, clrBackground1, LinearGradientMode.Vertical);

            Single[] relativeIntensisities = new Single[] { 0.0F, 0.32F, 1.0F };
            Single[] relativePositions = new Single[] { 0.0F, 0.02F, 1.0F };

            Blend blend = new Blend();
            blend.Factors = relativeIntensisities;
            blend.Positions = relativePositions;
            brushBackGround.Blend = blend;
            g.FillPath(brushBackGround, myPath);
            LinearGradientBrush brushPen =
                new LinearGradientBrush(this.BorderRectangle, clrBorder1, clrBorder2, LinearGradientMode.ForwardDiagonal);

            brushPen.Blend = blend;
            Pen ps = new Pen(brushPen);
            DrawBorder(g, ps, this.BorderRectangle);
        }

        /// <summary>
        /// Called when [draw text].
        /// </summary>
        /// <param name="g">The g.</param>
        private void OnDrawText(Graphics g)
        {
            SizeF sz = g.MeasureString(this.Text, this.Font);
            Brush[] br = GetShadowBrushes();
            RectangleF rcText = new RectangleF(this.BorderRectangle.Left + ((this.BorderRectangle.Width - sz.Width) / 2), this.BorderRectangle.Top + ((this.BorderRectangle.Height - sz.Height) / 2), sz.Width, sz.Height);

            for (int intIndex = 0; intIndex <= br.GetUpperBound(0); intIndex++)
            {
                g.DrawString(this.Text, this.Font, br[intIndex], rcText.X + (br.GetUpperBound(0) - intIndex), rcText.Y + (br.GetUpperBound(0) - intIndex));
            }
            if (enmState == ControlState.Normal)
            {
                if (this.Enabled)
                {
                    g.DrawString(this.Text, this.Font, new SolidBrush(clrFontMouseUp), rcText);
                }
                else
                {
                    g.DrawString(this.Text, this.Font, new SolidBrush(clrFontDisabled), rcText);
                }
            }
            else
            {
                g.DrawString(this.Text, this.Font, new SolidBrush(clrFontMouseDown), rcText);
            }
        }
        #endregion

        #region Overridden Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            this.OnPaintBackground(e);
            SmoothingMode oldSmothing = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            Graphics G = e.Graphics;
            
            Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          ///
                                                                                                        ///
            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   ///
                                   
            switch (enmState)
            {
                case ControlState.Normal:
                    if (this.Enabled)
                    {
                        if (this.Focused || this.IsDefault)
                        {
                            //when the control has the focus this method is called
                            OnDrawDefault(e.Graphics);

                            if ((Image == null))                                                                        ///
                            {                                                                                       ///
                                //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           ///
                                //{                                                                               ///
                                //    Alignment = _TextAlignment,                                                 ///
                                //    LineAlignment = StringAlignment.Center                                      ///
                                //});                                                                             ///
                            }                                                                                      ///
                            else                                                                                        ///
                            {                                                                                      ///
                                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              ///
                                //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          ///
                                //{                                                                               ///
                                //    Alignment = _TextAlignment,                                                 ///
                                //    LineAlignment = StringAlignment.Center                                      ///
                                //});                                                                             ///
                            }
                        }
                        else
                        {
                            //when the contrl does not have the focus this method is acalled
                            OnDrawNormal(e.Graphics);

                            if ((Image == null))                                                                        ///
                            {                                                                                       ///
                                //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           ///
                                //{                                                                               ///
                                //    Alignment = _TextAlignment,                                                 ///
                                //    LineAlignment = StringAlignment.Center                                      ///
                                //});                                                                             ///
                            }                                                                                      ///
                            else                                                                                        ///
                            {                                                                                      ///
                                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              ///
                                //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          ///
                                //{                                                                               ///
                                //    Alignment = _TextAlignment,                                                 ///
                                //    LineAlignment = StringAlignment.Center                                      ///
                                //});                                                                             ///
                            }
                        }
                    }
                    else
                    {
                        //when the button is disabled this method is called
                        OnDrawDisabled(e.Graphics);

                        if ((Image == null))                                                                        ///
                        {                                                                                       ///
                            //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           ///
                            //{                                                                               ///
                            //    Alignment = _TextAlignment,                                                 ///
                            //    LineAlignment = StringAlignment.Center                                      ///
                            //});                                                                             ///
                        }                                                                                      ///
                        else                                                                                        ///
                        {                                                                                      ///
                            G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              ///
                            //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          ///
                            //{                                                                               ///
                            //    Alignment = _TextAlignment,                                                 ///
                            //    LineAlignment = StringAlignment.Center                                      ///
                            //});                                                                             ///
                        }
                    }
                    break;
                case ControlState.Pressed:
                    //when the mouse is pressed over the button 
                    OnDrawPressed(e.Graphics);

                    if ((Image == null))                                                                        ///
                    {                                                                                       ///
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           ///
                        //{                                                                               ///
                        //    Alignment = _TextAlignment,                                                 ///
                        //    LineAlignment = StringAlignment.Center                                      ///
                        //});                                                                             ///
                    }                                                                                      ///
                    else                                                                                        ///
                    {                                                                                      ///
                        G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              ///
                        //G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          ///
                        //{                                                                               ///
                        //    Alignment = _TextAlignment,                                                 ///
                        //    LineAlignment = StringAlignment.Center                                      ///
                        //});                                                                             ///
                    }
                    break;
            }
            OnDrawText(e.Graphics);

            Rectangle rc = new Rectangle(this.BorderRectangle.X - 1, this.BorderRectangle.Y - 1, this.BorderRectangle.Width + 2, this.BorderRectangle.Height + 2);
            this.Region = new Region(GetGraphicPath(rc));
            e.Graphics.SmoothingMode = oldSmothing;
        }

        //Redraw control when the button is resized
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
        }

        //Change the state to pressed
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                enmState = ControlState.Pressed;
                this.Invalidate();
            }

            ClickOnMouseDown(e);
        }

        //Change the state to normal
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            enmState = ControlState.Normal;
            this.Invalidate();
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

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ElongatedButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ElongatedButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ElongatedButtonSmartTagActionList(this.Component));
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
    /// Class ElongatedButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ElongatedButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitElongButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ElongatedButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ElongatedButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitElongButton;

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

        //where Color1_inactive property exist. Replace with an existing property
        /// <summary>
        /// Gets or sets the flat style.
        /// </summary>
        /// <value>The flat style.</value>
        public new FlatStyle FlatStyle
        {
            get
            {
                return colUserControl.FlatStyle;
            }
            set
            {
                GetPropertyByName("FlatStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color scheme.
        /// </summary>
        /// <value>The color scheme.</value>
        public EnmColorScheme ColorScheme
        {
            get
            {
                return colUserControl.ColorScheme;
            }
            set
            {
                GetPropertyByName("ColorScheme").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the custom colors.
        /// </summary>
        /// <value>The custom colors.</value>
        public CustomColors CustomColors
        {
            get
            {
                return colUserControl.CustomColors;
            }
            set
            {
                GetPropertyByName("CustomColors").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image align.
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
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

            items.Add(new DesignerActionPropertyItem("ColorScheme",
                "Color Scheme", "Appearance",
                "Sets the ColorScheme."));

            items.Add(new DesignerActionPropertyItem("FlatStyle",
                                 "Flat Style", "Appearance",
                                 "Sets the Flat Style."));

            //items.Add(new DesignerActionPropertyItem("CustomColors",
            //    "Custom Colors", "Appearance",
            //    "Sets the Custom Colors."));

            items.Add(new DesignerActionPropertyItem("Image",
                "Image", "Appearance",
                "Sets the Image of the control."));

            items.Add(new DesignerActionPropertyItem("ImageAlign",
                "Image Align", "Appearance",
                "Sets the Image Align."));

            items.Add(new DesignerActionPropertyItem("Text",
                "Text", "Appearance",
                "Sets the Text of the control."));

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

    /// <summary>
    /// A class for rendering Custom colors for the Elongated Button
    /// </summary>
    public class CustomColors
    {
        /// <summary>
        /// The background bottom color
        /// </summary>
        private Color backgroundBottomColor = Color.FromArgb(128, 255, 255);
        /// <summary>
        /// The background top color
        /// </summary>
        private Color backgroundTopColor = Color.FromArgb(255, 192, 128);
        /// <summary>
        /// The border bottom color
        /// </summary>
        private Color borderBottomColor = Color.FromArgb(255, 128, 255);
        /// <summary>
        /// The border top color
        /// </summary>
        private Color borderTopColor = Color.FromArgb(255, 128, 0);
        /// <summary>
        /// The default border color
        /// </summary>
        private Color defaultBorderColor = Color.Lime;
        /// <summary>
        /// The disabled font color
        /// </summary>
        private Color disabledFontColor = Color.FromArgb(255, 192, 128);
        /// <summary>
        /// The disbaled bottom color
        /// </summary>
        private Color disbaledBottomColor = Color.FromArgb(255, 255, 128);
        /// <summary>
        /// The disabled top color
        /// </summary>
        private Color disabledTopColor = Color.FromArgb(192, 0, 0);
        /// <summary>
        /// The font color
        /// </summary>
        private Color fontColor = Color.FromArgb(255, 128, 128);
        /// <summary>
        /// The pressed font color
        /// </summary>
        private Color pressedFontColor = Color.FromArgb(192, 192, 0);


        /// <summary>
        /// Gets or sets the color of the background bottom.
        /// </summary>
        /// <value>The color of the background bottom.</value>
        [DefaultValue(typeof(Color),"Red"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color BackgroundBottomColor
        {
            get { return backgroundBottomColor; }
            set
            {
                backgroundBottomColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the background top.
        /// </summary>
        /// <value>The color of the background top.</value>
        [DefaultValue(typeof(Color), "Yellow"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color BackgroundTopColor
        {
            get { return backgroundTopColor; }
            set
            {
                backgroundTopColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the border bottom.
        /// </summary>
        /// <value>The color of the border bottom.</value>
        [DefaultValue(typeof(Color), "Green"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color BorderBottomColor
        {
            get { return borderBottomColor; }
            set
            {
                borderBottomColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the border top.
        /// </summary>
        /// <value>The color of the border top.</value>
        [DefaultValue(typeof(Color), "LightBlue"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color BorderTopColor
        {
            get { return borderTopColor; }
            set
            {
                borderTopColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the default color of the border.
        /// </summary>
        /// <value>The default color of the border.</value>
        [DefaultValue(typeof(Color), "LightGreen"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color DefaultBorderColor
        {
            get { return defaultBorderColor; }
            set
            {
                defaultBorderColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the disabled font.
        /// </summary>
        /// <value>The color of the disabled font.</value>
        [DefaultValue(typeof(Color), "Gray"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color DisabledFontColor
        {
            get { return disabledFontColor; }
            set
            {
                disabledFontColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the disbaled bottom.
        /// </summary>
        /// <value>The color of the disbaled bottom.</value>
        [DefaultValue(typeof(Color), "Brown"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color DisbaledBottomColor
        {
            get { return disbaledBottomColor; }
            set
            {
                disbaledBottomColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the disabled top.
        /// </summary>
        /// <value>The color of the disabled top.</value>
        [DefaultValue(typeof(Color), "Gray"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color DisabledTopColor
        {
            get { return disabledTopColor; }
            set
            {
                disabledTopColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        [DefaultValue(typeof(Color), "Black"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color FontColor
        {
            get { return fontColor; }
            set
            {
                fontColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the pressed font.
        /// </summary>
        /// <value>The color of the pressed font.</value>
        [DefaultValue(typeof(Color), "Silver"),
         RefreshProperties(RefreshProperties.Repaint)]
        public Color PressedFontColor
        {
            get { return pressedFontColor; }
            set
            {
                pressedFontColor = value;
            }
        }
        

    }

    #endregion
}
