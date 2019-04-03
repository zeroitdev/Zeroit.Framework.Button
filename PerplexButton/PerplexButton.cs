// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="PerplexButton.cs" company="Zeroit Dev Technologies">
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
    #region ZeroitButtonPerplex

    /// <summary>
    /// A class collection for rendering Perplex button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitButtonPerplexDesigner))]
    public class ZeroitPerplexButton : Control
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
        /// Sets the Image
        /// </summary>
        /// <value>The image.</value>
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
        /// Sets the Image size
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

        /// <summary>
        /// Sets the Image alignment
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

        #region Private Fields
        /// <summary>
        /// The state
        /// </summary>
        MouseState State = MouseState.None;
        /// <summary>
        /// The LGB1
        /// </summary>
        private Color lgb1 = Color.FromArgb(66, 67, 70);
        /// <summary>
        /// The LGB2
        /// </summary>
        private Color lgb2 = Color.FromArgb(43, 44, 48);
        /// <summary>
        /// The botbar1
        /// </summary>
        private Color botbar1 = Color.FromArgb(44, 45, 49);
        /// <summary>
        /// The botbar2
        /// </summary>
        private Color botbar2 = Color.FromArgb(45, 46, 50);
        /// <summary>
        /// The fill1
        /// </summary>
        private Color fill1 = Color.FromArgb(174, 195, 30);
        /// <summary>
        /// The fill2
        /// </summary>
        private Color fill2 = Color.FromArgb(141, 153, 16);
        /// <summary>
        /// The gloss over1
        /// </summary>
        private Color glossOver1 = Color.FromArgb(15, Color.FromArgb(26, 26, 26));
        /// <summary>
        /// The gloss over2
        /// </summary>
        private Color glossOver2 = Color.FromArgb(1, 255, 255, 255);
        /// <summary>
        /// The gloss down1
        /// </summary>
        private Color glossDown1 = Color.FromArgb(100, Color.FromArgb(26, 26, 26));
        /// <summary>
        /// The gloss down2
        /// </summary>
        private Color glossDown2 = Color.FromArgb(1, 255, 255, 255);
        /// <summary>
        /// The gloss default1
        /// </summary>
        private Color glossDefault1 = Color.FromArgb(75, Color.FromArgb(26, 26, 26));
        /// <summary>
        /// The gloss default2
        /// </summary>
        private Color glossDefault2 = Color.FromArgb(3, 255, 255, 255);
        /// <summary>
        /// The path1
        /// </summary>
        private Color path1 = Color.FromArgb(50, 50, 50);
        /// <summary>
        /// The path2
        /// </summary>
        private Color path2 = Color.Black;
        /// <summary>
        /// The text color1
        /// </summary>
        private Color textColor1 = Color.FromArgb(5, 5, 5);
        /// <summary>
        /// The text color2
        /// </summary>
        private Color textColor2 = Color.FromArgb(205, 205, 205);

        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;

        /// <summary>
        /// The angle
        /// </summary>
        private float angle = 90f;

        /// <summary>
        /// The text align
        /// </summary>
        private StringAlignment textAlign = StringAlignment.Center;

        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the Text alignment
        /// </summary>
        /// <value>The text align.</value>
        public StringAlignment TextAlign
        {
            get { return textAlign; }
            set
            {
                textAlign = value;
                Invalidate();
            }
        }

        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Sets the Rendering mode
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Sets the Border Width
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Angle
        /// </summary>
        /// <value>The angle.</value>
        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background Color
        /// </summary>
        /// <value>The lg b1.</value>
        /// <remarks>Sets the Linear gradient color 1 for the background</remarks>
        public Color LGB1
        {
            get { return lgb1; }
            set
            {
                lgb1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background Color
        /// </summary>
        /// <value>The lg b2.</value>
        /// <remarks>Sets the Linear gradient color 2 for the background</remarks>
        public Color LGB2
        {
            get { return lgb2; }
            set
            {
                lgb2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Bottom bar Color
        /// </summary>
        /// <value>The botbar1.</value>
        /// <remarks>Sets the Linear gradient color 1 for the bottom bar</remarks>
        public Color Botbar1
        {
            get { return botbar1; }
            set
            {
                botbar1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Bottom bar Color
        /// </summary>
        /// <value>The botbar2.</value>
        /// <remarks>Sets the Linear gradient color 2 for the bottom bar</remarks>
        public Color Botbar2
        {
            get { return botbar2; }
            set
            {
                botbar2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Fill color Bottom bar
        /// </summary>
        /// <value>The fill1.</value>
        /// <remarks>Sets the Linear gradient color 1 for the bottom bar</remarks>
        public Color Fill1
        {
            get { return fill1; }
            set
            {
                fill1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Fill color Bottom bar
        /// </summary>
        /// <value>The fill2.</value>
        /// <remarks>Sets the Linear gradient color 2 for the bottom bar</remarks>
        public Color Fill2
        {
            get { return fill2; }
            set
            {
                fill2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Hover color
        /// </summary>
        /// <value>The gloss over1.</value>
        /// <remarks>This sets gradient color 1 when it is hovered</remarks>
        public Color GlossOver1
        {
            get { return glossOver1; }
            set
            {
                glossOver1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Hover color
        /// </summary>
        /// <value>The gloss over2.</value>
        /// <remarks>This sets gradient color 2 when it is hovered</remarks>
        public Color GlossOver2
        {
            get { return glossOver2; }
            set
            {
                glossOver2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Pressed color
        /// </summary>
        /// <value>The gloss down1.</value>
        /// <remarks>This sets gradient color 1 when it is pressed</remarks>
        public Color GlossDown1
        {
            get { return glossDown1; }
            set
            {
                glossDown1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Pressed color
        /// </summary>
        /// <value>The gloss down2.</value>
        /// <remarks>This sets gradient color 2 when it is pressed</remarks>
        public Color GlossDown2
        {
            get { return glossDown2; }
            set
            {
                glossDown2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Default glossy color
        /// </summary>
        /// <value>The gloss default1.</value>
        /// <remarks>This sets gradient color 1 when it is in default state</remarks>
        public Color GlossDefault1
        {
            get { return glossDefault1; }
            set
            {
                glossDefault1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Default glossy color
        /// </summary>
        /// <value>The gloss default2.</value>
        /// <remarks>This sets gradient color 2 when it is in default state</remarks>
        public Color GlossDefault2
        {
            get { return glossDefault2; }
            set
            {
                glossDefault2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Outer Path color
        /// </summary>
        /// <value>The path1.</value>
        /// <remarks>This sets gradient color 1 for the outer path</remarks>
        public Color Path1
        {
            get { return path1; }
            set
            {
                path1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Outer Path color
        /// </summary>
        /// <value>The path2.</value>
        /// <remarks>This sets gradient color 2 for the outer path</remarks>
        public Color Path2
        {
            get { return path2; }
            set
            {
                path2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Text color
        /// </summary>
        /// <value>The text color1.</value>
        /// <remarks>This sets gradient color 1 for the text to display</remarks>
        public Color TextColor1
        {
            get { return textColor1; }
            set
            {
                textColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Text color
        /// </summary>
        /// <value>The text color2.</value>
        /// <remarks>This sets gradient color 2 for the text to display</remarks>
        public Color TextColor2
        {
            get { return textColor2; }
            set
            {
                textColor2 = value;
                Invalidate();
            }
        }



        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of the Perplex Button
        /// </summary>
        public ZeroitPerplexButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
            DoubleBuffered = true;

            IncludeInConstructor();

        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            State = MouseState.Down;
            ClickOnMouseDown(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            State = MouseState.Over;
            ClickOnMouseUp(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            State = MouseState.Over;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            State = MouseState.None;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int width = Size.Width;
            int height = Size.Height;

            if (width < 15 || height < 15)
            {
                Size = new Size(15, 15);
            }
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);
            //Bitmap B = new Bitmap(Width, Height);
            Graphics G = e.Graphics;
            Rectangle ClientRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            G.SmoothingMode = smoothing;
            G.InterpolationMode = InterpolationMode.HighQualityBicubic;
            G.Clear(BackColor);

            Rectangle imageRec = new Rectangle(0, 0, Width, Height);                                          
                                                                                                              
            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   
                                                                                                        


            Font drawFont = new Font("Tahoma", 8, FontStyle.Bold);
            
            Rectangle R1 = new Rectangle(0, 0, Width - 125, 35 / 2);
            Rectangle R2 = new Rectangle(5, Height - 10, Width - 11, 5);
            Rectangle R3 = new Rectangle(6, Height - 9, Width - 13, 3);
            Rectangle R4 = new Rectangle(1, 1, Width - 3, Height - 3);
            Rectangle R5 = new Rectangle(1, 0, Width - 1, Height - 1);
            Rectangle R6 = new Rectangle(0, -1, Width - 1, Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, lgb1, lgb2, angle);
            LinearGradientBrush botbar = new LinearGradientBrush(R2, botbar1, botbar2, angle);
            LinearGradientBrush fill = new LinearGradientBrush(R3, fill1, fill2, angle);
            LinearGradientBrush gloss = null;
            Pen o = new Pen(path1, 1);
            StringFormat format = new StringFormat() { Alignment = textAlign, LineAlignment = textAlign };
            if (State == MouseState.Over)
                gloss = new LinearGradientBrush(R1, glossOver1, glossOver2, angle);
            else if (State == MouseState.Down)
                gloss = new LinearGradientBrush(R1, glossDown1, glossDown2, angle);
            else
                gloss = new LinearGradientBrush(R1, glossDefault1, glossDefault2, angle);

            G.FillPath(lgb, Draw.RoundRect(ClientRectangle, 2));
            G.FillPath(gloss, Draw.RoundRect(ClientRectangle, 2));
            G.FillPath(botbar, Draw.RoundRect(R2, 1));
            G.FillPath(fill, Draw.RoundRect(R3, 1));
            G.DrawPath(o, Draw.RoundRect(ClientRectangle, 2));
            G.DrawPath(new Pen(path2, borderWidth), Draw.RoundRect(R4, 2));
            G.DrawString(Text, drawFont, new SolidBrush(textColor1), R5, format);
            G.DrawString(Text, drawFont, new SolidBrush(textColor2), R6, format);

            if ((Image == null))                                                                        ///
            {                                                                                       ///
                //G.DrawString(Text, Font, new SolidBrush(ForeColor), imageRec, new StringFormat           ///
                //{                                                                               ///
                //    Alignment = _TextAlignment,                                                 ///
                //    LineAlignment = StringAlignment.Center                                      ///
                //});                                                                             ///
            }                                                                                      ///
            else                                                                                        ///
            {                                                                                      ///
                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              ///
                //G.DrawString(Text, Font, new SolidBrush(ForeColor), imageRec, new StringFormat          ///
                //{                                                                               ///
                //    Alignment = _TextAlignment,                                                 ///
                //    LineAlignment = StringAlignment.Center                                      ///
                //});                                                                             ///
            }

            //e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            //G.Dispose();
            //B.Dispose();
            base.OnPaint(e);
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


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonPerplexDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonPerplexDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonPerplexSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonPerplexSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitButtonPerplexSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPerplexButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonPerplexSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonPerplexSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPerplexButton;

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
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle.</value>
        public float Angle
        {
            get
            {
                return colUserControl.Angle;
            }
            set
            {
                GetPropertyByName("Angle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get
            {
                return colUserControl.BorderWidth;
            }
            set
            {
                GetPropertyByName("BorderWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the lg b1.
        /// </summary>
        /// <value>The lg b1.</value>
        public Color LGB1
        {
            get
            {
                return colUserControl.LGB1;
            }
            set
            {
                GetPropertyByName("LGB1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the lg b2.
        /// </summary>
        /// <value>The lg b2.</value>
        public Color LGB2
        {
            get
            {
                return colUserControl.LGB2;
            }
            set
            {
                GetPropertyByName("LGB2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the botbar1.
        /// </summary>
        /// <value>The botbar1.</value>
        public Color Botbar1
        {
            get
            {
                return colUserControl.Botbar1;
            }
            set
            {
                GetPropertyByName("Botbar1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the botbar2.
        /// </summary>
        /// <value>The botbar2.</value>
        public Color Botbar2
        {
            get
            {
                return colUserControl.Botbar2;
            }
            set
            {
                GetPropertyByName("Botbar2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the fill1.
        /// </summary>
        /// <value>The fill1.</value>
        public Color Fill1
        {
            get
            {
                return colUserControl.Fill1;
            }
            set
            {
                GetPropertyByName("Fill1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the fill2.
        /// </summary>
        /// <value>The fill2.</value>
        public Color Fill2
        {
            get
            {
                return colUserControl.Fill2;
            }
            set
            {
                GetPropertyByName("Fill2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gloss over1.
        /// </summary>
        /// <value>The gloss over1.</value>
        public Color GlossOver1
        {
            get
            {
                return colUserControl.GlossOver1;
            }
            set
            {
                GetPropertyByName("GlossOver1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gloss over2.
        /// </summary>
        /// <value>The gloss over2.</value>
        public Color GlossOver2
        {
            get
            {
                return colUserControl.GlossOver2;
            }
            set
            {
                GetPropertyByName("GlossOver2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gloss down1.
        /// </summary>
        /// <value>The gloss down1.</value>
        public Color GlossDown1
        {
            get
            {
                return colUserControl.GlossDown1;
            }
            set
            {
                GetPropertyByName("GlossDown1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gloss down2.
        /// </summary>
        /// <value>The gloss down2.</value>
        public Color GlossDown2
        {
            get
            {
                return colUserControl.GlossDown2;
            }
            set
            {
                GetPropertyByName("GlossDown2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gloss default1.
        /// </summary>
        /// <value>The gloss default1.</value>
        public Color GlossDefault1
        {
            get
            {
                return colUserControl.GlossDefault1;
            }
            set
            {
                GetPropertyByName("GlossDefault1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the gloss default2.
        /// </summary>
        /// <value>The gloss default2.</value>
        public Color GlossDefault2
        {
            get
            {
                return colUserControl.GlossDefault2;
            }
            set
            {
                GetPropertyByName("GlossDefault2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the path1.
        /// </summary>
        /// <value>The path1.</value>
        public Color Path1
        {
            get
            {
                return colUserControl.Path1;
            }
            set
            {
                GetPropertyByName("Path1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the path2.
        /// </summary>
        /// <value>The path2.</value>
        public Color Path2
        {
            get
            {
                return colUserControl.Path2;
            }
            set
            {
                GetPropertyByName("Path2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text color1.
        /// </summary>
        /// <value>The text color1.</value>
        public Color TextColor1
        {
            get
            {
                return colUserControl.TextColor1;
            }
            set
            {
                GetPropertyByName("TextColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text color2.
        /// </summary>
        /// <value>The text color2.</value>
        public Color TextColor2
        {
            get
            {
                return colUserControl.TextColor2;
            }
            set
            {
                GetPropertyByName("TextColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get
            {
                return colUserControl.Smoothing;
            }
            set
            {
                GetPropertyByName("Smoothing").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("LGB1",
                                 "LGB 1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("LGB2",
                                 "LGB 2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Botbar1",
                                 "Botbar 1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Botbar2",
                                 "Botbar 2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Fill1",
                                 "Fill 1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Fill2",
                                 "Fill 2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("GlossOver1",
                                 "Gloss Over 1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("GlossOver2",
                                 "Gloss Over 2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("GlossDown1",
                                 "GlossDown1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("GlossDown2",
                                 "Gloss Down 2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("GlossDefault1",
                                 "GlossDefault1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("GlossDefault2",
                                 "Gloss Default 2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Path1",
                                 "Path 1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Path2",
                                 "Path 2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("TextColor1",
                                 "Text Color 1", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("TextColor2",
                                 "Text Color 2", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Angle",
                                 "Angle", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("BorderWidth",
                                 "Border Width", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Type few characters to filter Cities."));

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
