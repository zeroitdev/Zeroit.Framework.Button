// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="SocialPieButton.cs" company="Zeroit Dev Technologies">
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
    #region  Social Button Pie

    /// <summary>
    /// A class collection for rendering
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />

    [Designer(typeof(ZeroitSocialButtonPieDesigner))]
    public class ZeroitPieButton : Control
    {

        #region  Variables

        /// <summary>
        /// The mousestate
        /// </summary>
        private int Mousestate;
        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image size
        /// </summary>
        private Size _ImageSize;
        /// <summary>
        /// The ellipse color
        /// </summary>
        private Color ellipseColor = Color.FromArgb(66, 76, 85); // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
        /// <summary>
        /// The ellipse color1
        /// </summary>
        private Color ellipseColor1 = Color.Orange;
        /// <summary>
        /// The ellipse color border
        /// </summary>
        private Color ellipseColorBorder = Color.LightGray;
        /// <summary>
        /// The ellipse color hover
        /// </summary>
        private Color ellipseColorHover = Color.Green;
        /// <summary>
        /// The ellipse color1 hover
        /// </summary>
        private Color ellipseColor1Hover = Color.Goldenrod;
        /// <summary>
        /// The ellipse size
        /// </summary>
        private int ellipseSize = 53;
        /// <summary>
        /// The pie start angle
        /// </summary>
        private float pieStartAngle = 0f;
        /// <summary>
        /// The piesweep angle
        /// </summary>
        private float piesweepAngle = 90f;
        /// <summary>
        /// The pie color angle
        /// </summary>
        private float pieColorAngle = 90f;
        /// <summary>
        /// The pie brush type
        /// </summary>
        private PieBrushType pieBrushType = PieBrushType.Solid;
        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;
        #endregion

        #region  Properties

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
        /// Sets the Hover color
        /// </summary>
        /// <value>The color of the ellipse clicked.</value>
        /// <remarks>This sets the hover color 1</remarks>
        public Color EllipseClickedColor
        {
            get { return ellipseColorHover; }
            set
            {
                ellipseColorHover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Hover color
        /// </summary>
        /// <value>The ellipse clicked color1.</value>
        /// <remarks>This sets the hover color 2</remarks>
        public Color EllipseClickedColor1
        {
            get { return ellipseColor1Hover; }
            set
            {
                ellipseColor1Hover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Border color
        /// </summary>
        /// <value>The ellipse color border.</value>
        public Color EllipseColorBorder
        {
            get { return ellipseColorBorder; }
            set
            {
                ellipseColorBorder = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the brush type
        /// </summary>
        public enum PieBrushType
        {
            /// <summary>
            /// Sets the brush type to Linear gradient
            /// </summary>
            LinearGradient,

            /// <summary>
            /// Sets teh brush type to solid
            /// </summary>
            Solid
        }

        /// <summary>
        /// Sets the Brush type
        /// </summary>
        /// <value>The pie brush.</value>
        public PieBrushType PieBrush
        {
            get { return pieBrushType; }
            set
            {
                pieBrushType = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Starting angle
        /// </summary>
        /// <value>The pie start angle.</value>
        public float PieStartAngle
        {
            get { return pieStartAngle; }
            set
            {
                pieStartAngle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Ending Angle
        /// </summary>
        /// <value>The pie sweep angle.</value>
        public float PieSweepAngle
        {
            get { return piesweepAngle; }
            set
            {
                piesweepAngle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets Linear gradient color angle
        /// </summary>
        /// <value>The pie color angle.</value>
        public float PieColorAngle
        {
            get { return pieColorAngle; }
            set
            {
                pieColorAngle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background color
        /// </summary>
        /// <value>The color of the ellipse.</value>
        /// <remarks>This sets the default background color 1</remarks>
        public Color EllipseColor
        {
            get { return ellipseColor; }
            set
            {
                ellipseColor = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background color
        /// </summary>
        /// <value>The ellipse color1.</value>
        /// <remarks>This sets the default background color 2</remarks>
        public Color EllipseColor1
        {
            get { return ellipseColor1; }
            set
            {
                ellipseColor1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Size of the ellipse
        /// </summary>
        /// <value>The size of the ellipse.</value>
        public int EllipseSize
        {
            get { return ellipseSize; }
            set
            {
                ellipseSize = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Image
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get
            {
                return _Image;
            }
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
            get
            {
                return _ImageSize;
            }
            set
            {
                _ImageSize = value;
                Invalidate();
            }
        }

        #endregion

        #region  EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Mousestate = 0;
            ClickOnMouseUp(e);
            Invalidate();
            base.OnMouseUp(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Mousestate = 1;
            ClickOnMouseDown(e);
            Invalidate();
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            Mousestate = 0;
            Invalidate();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = new Size(Width, Height);
        }

        //protected override void OnMouseEnter(EventArgs e)
        //{
        //    base.OnMouseEnter(e);
        //    EllipseColor = Color.FromArgb(181, 41, 42);
        //    Refresh();
        //}
        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    base.OnMouseLeave(e);
        //    EllipseColor = Color.FromArgb(66, 76, 85);
        //    Refresh();
        //}

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    EllipseColor = Color.FromArgb(153, 34, 34);
        //    Focus();
        //    Refresh();
        //}
        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    base.OnMouseUp(e);
        //    EllipseColor = Color.FromArgb(181, 41, 42);
        //    Refresh();
        //}

        #endregion

        #region  Image Designer

        /// <summary>
        /// Images the location.
        /// </summary>
        /// <param name="SF">The sf.</param>
        /// <param name="Area">The area.</param>
        /// <param name="ImageArea">The image area.</param>
        /// <returns>PointF.</returns>
        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = new PointF();
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = (float)((Area.Width - ImageArea.Width) / 2);
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = (float)((Area.Height - ImageArea.Height) / 2);
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
            }
            return SF;
        }

        #endregion

        /// <summary>
        /// Creates an instance of the Social Pie button
        /// </summary>
        public ZeroitPieButton()
        {
            //SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);

            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint), true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;

            IncludeInConstructor();
        }

        #region Center Text

        //------------------------------Include in Paint----------------------------//
        //
        // CenterString(G,Text,Font,ForeColor,this.ClientRectangle);
        //
        //------------------------------Include in Paint----------------------------//

        /// <summary>
        /// Center Text
        /// </summary>
        /// <param name="G">Set Graphics</param>
        /// <param name="T">Set string</param>
        /// <param name="F">Set Font</param>
        /// <param name="C">Set color</param>
        /// <param name="R">Set rectangle</param>
        private static void CenterString(System.Drawing.Graphics G, string T, Font F, Color C, Rectangle R)
        {
            SizeF TS = G.MeasureString(T, F);

            using (SolidBrush B = new SolidBrush(C))
            {
                G.DrawString(T, F, B, new Point((int)(R.Width / 2 - (TS.Width / 2)), (int)(R.Height / 2 - (TS.Height / 2))));
            }
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);

            Graphics G = e.Graphics;
            //G.Clear(Parent.BackColor);
            G.SmoothingMode = SmoothingMode.HighQuality;

            LinearGradientBrush InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 5, Height - 5), ellipseColor, ellipseColor1, pieColorAngle);
            LinearGradientBrush PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 5, Height - 5), ellipseColorHover, ellipseColor1Hover, pieColorAngle);

            switch (pieBrushType)
            {
                case PieBrushType.LinearGradient:
                    switch (Mousestate)
                    {
                        case 0:
                            G.FillPie(InactiveGB, new Rectangle(0, 0, Width - 5, Height - 5), pieStartAngle, piesweepAngle);
                            G.DrawPie(new Pen(ellipseColorBorder) { Width = BorderWidth }, new Rectangle(0, 0, Width - 5, Height - 5), pieStartAngle, piesweepAngle);

                            PointF ImgPoint = ImageLocation(GetStringFormat(ContentAlignment.MiddleCenter), Size, ImageSize);
                            if (Image != null)
                            {
                                G.DrawImage(_Image, (int)ImgPoint.X, (int)ImgPoint.Y, ImageSize.Width, ImageSize.Height);
                            }

                            break;
                        case 1:
                            G.FillPie(PressedGB, new Rectangle(0, 0, Width - 5, Height - 5), pieStartAngle, piesweepAngle);
                            G.DrawPie(new Pen(ellipseColorBorder) { Width = BorderWidth }, new Rectangle(0, 0, Width - 5, Height - 5), pieStartAngle, piesweepAngle);

                            PointF ImgPoint1 = ImageLocation(GetStringFormat(ContentAlignment.MiddleCenter), Size, ImageSize);
                            if (Image != null)
                            {
                                G.DrawImage(_Image, (int)ImgPoint1.X, (int)ImgPoint1.Y, ImageSize.Width, ImageSize.Height);
                            }
                            break;
                        default:
                            break;
                    }

                    break;
                case PieBrushType.Solid:
                    switch (Mousestate)
                    {
                        case 0:
                            G.FillPie(new SolidBrush(ellipseColor), new Rectangle(0, 0, Width - 5, Height - 5), pieStartAngle, piesweepAngle);
                            G.DrawPie(new Pen(ellipseColorBorder) { Width = BorderWidth }, new Rectangle(0, 0, Width - 5, Height - 5), pieStartAngle, piesweepAngle);

                            PointF ImgPoint = ImageLocation(GetStringFormat(ContentAlignment.MiddleCenter), Size, ImageSize);
                            if (Image != null)
                            {
                                G.DrawImage(_Image, (int)ImgPoint.X, (int)ImgPoint.Y, ImageSize.Width, ImageSize.Height);
                            }

                            break;
                        case 1:
                            G.FillPie(new SolidBrush(ellipseColorHover), new Rectangle(0, 0, Width - 5, Height - 5), pieStartAngle, piesweepAngle);
                            G.DrawPie(new Pen(ellipseColorBorder) { Width = BorderWidth }, new Rectangle(0, 0, Width - 5, Height - 5), pieStartAngle, piesweepAngle);

                            PointF ImgPoint1 = ImageLocation(GetStringFormat(ContentAlignment.MiddleCenter), Size, ImageSize);
                            if (Image != null)
                            {
                                G.DrawImage(_Image, (int)ImgPoint1.X, (int)ImgPoint1.Y, ImageSize.Width, ImageSize.Height);
                            }
                            break;
                        default:
                            break;
                    }

                    break;
                default:
                    break;

                    

            }

            CenterString(G, Text, Font, ForeColor, ClientRectangle);

            // HINTS:
            // The best size for the drawn image is 32x32\
            // The best matching color of drawn image is (RGB: 31, 40, 49)

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
    /// Class ZeroitSocialButtonPieDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSocialButtonPieDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitSocialButtonPieSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSocialButtonPieSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSocialButtonPieSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitPieButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSocialButtonPieSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSocialButtonPieSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitPieButton;

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
        /// Gets or sets the color of the ellipse clicked.
        /// </summary>
        /// <value>The color of the ellipse clicked.</value>
        public Color EllipseClickedColor
        {
            get
            {
                return colUserControl.EllipseClickedColor;
            }
            set
            {
                GetPropertyByName("EllipseClickedColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the ellipse clicked color1.
        /// </summary>
        /// <value>The ellipse clicked color1.</value>
        public Color EllipseClickedColor1
        {
            get
            {
                return colUserControl.EllipseClickedColor1;
            }
            set
            {
                GetPropertyByName("EllipseClickedColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the ellipse color border.
        /// </summary>
        /// <value>The ellipse color border.</value>
        public Color EllipseColorBorder
        {
            get
            {
                return colUserControl.EllipseColorBorder;
            }
            set
            {
                GetPropertyByName("EllipseColorBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the pie start angle.
        /// </summary>
        /// <value>The pie start angle.</value>
        public float PieStartAngle
        {
            get
            {
                return colUserControl.PieStartAngle;
            }
            set
            {
                GetPropertyByName("PieStartAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the pie sweep angle.
        /// </summary>
        /// <value>The pie sweep angle.</value>
        public float PieSweepAngle
        {
            get
            {
                return colUserControl.PieSweepAngle;
            }
            set
            {
                GetPropertyByName("PieSweepAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the pie color angle.
        /// </summary>
        /// <value>The pie color angle.</value>
        public float PieColorAngle
        {
            get
            {
                return colUserControl.PieColorAngle;
            }
            set
            {
                GetPropertyByName("PieColorAngle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the ellipse.
        /// </summary>
        /// <value>The color of the ellipse.</value>
        public Color EllipseColor
        {
            get
            {
                return colUserControl.EllipseColor;
            }
            set
            {
                GetPropertyByName("EllipseColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the ellipse color1.
        /// </summary>
        /// <value>The ellipse color1.</value>
        public Color EllipseColor1
        {
            get
            {
                return colUserControl.EllipseColor1;
            }
            set
            {
                GetPropertyByName("EllipseColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the pie brush.
        /// </summary>
        /// <value>The pie brush.</value>
        public ZeroitPieButton.PieBrushType PieBrush
        {
            get
            {
                return colUserControl.PieBrush;
            }
            set
            {
                GetPropertyByName("PieBrush").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("PieBrush",
                "Pie Brush", "Appearance",
                "Sets the draw mode of the control."));


            items.Add(new DesignerActionPropertyItem("EllipseClickedColor",
                                 "Clicked Color 0", "Appearance",
                                 "Selects the background hover color."));

            items.Add(new DesignerActionPropertyItem("EllipseClickedColor1",
                                 "Clicked Color 1", "Appearance",
                                 "Selects the background hover color."));

            items.Add(new DesignerActionPropertyItem("EllipseColorBorder",
                                 "Ellipse ColorBorder", "Appearance",
                                 "Sets the border color of the pie"));

            
            items.Add(new DesignerActionPropertyItem("EllipseColor",
                                 "Ellipse Color 0", "Appearance",
                                 "Sets the color of the pie"));

            items.Add(new DesignerActionPropertyItem("EllipseColor1",
                                 "Ellipse Color 1", "Appearance",
                                 "Sets the color of the pie"));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Sets Image of the pie"));

            items.Add(new DesignerActionPropertyItem("BorderWidth",
                "BorderWidth", "Appearance",
                "Sets the Border Width of the pie"));

            items.Add(new DesignerActionPropertyItem("PieStartAngle",
                "Pie Start Angle", "Appearance",
                "Sets the start angle of the pie"));

            items.Add(new DesignerActionPropertyItem("PieSweepAngle",
                "Pie Sweep Angle", "Appearance",
                "Sets the sweep angle of the pie"));

            items.Add(new DesignerActionPropertyItem("PieColorAngle",
                "Pie Color Angle", "Appearance",
                "Sets the color angle of the pie"));


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
