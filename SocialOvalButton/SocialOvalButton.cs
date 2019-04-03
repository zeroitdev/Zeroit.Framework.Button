// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="SocialOvalButton.cs" company="Zeroit Dev Technologies">
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
    #region  Social Button Oval

    /// <summary>
    /// A class collection for rendering Social Oval Button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitSocialButtonOvalDesigner))]
    public class ZeroitOvalButton : Control
    {

        #region  Variables

        /// <summary>
        /// The image
        /// </summary>
        private Image _Image;
        /// <summary>
        /// The image align
        /// </summary>
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;
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
        /// The ellipse color hover
        /// </summary>
        private Color ellipseColorHover = Color.FromArgb(66, 76, 85);
        /// <summary>
        /// The ellipse color1 hover
        /// </summary>
        private Color ellipseColor1Hover = Color.Orange;
        /// <summary>
        /// The ellipse color angle
        /// </summary>
        private float ellipseColorAngle = 90f;
        /// <summary>
        /// The ellipse size
        /// </summary>
        private int ellipseSize = 53;
        /// <summary>
        /// The ellipse color border
        /// </summary>
        private Color ellipseColorBorder = Color.LightGray;
        /// <summary>
        /// The mousestate
        /// </summary>
        private int Mousestate;

        /// <summary>
        /// The ellipse brush type
        /// </summary>
        private EllipseBrushType ellipseBrushType = EllipseBrushType.Solid;

        /// <summary>
        /// The border width
        /// </summary>
        private int borderWidth = 1;
        #endregion

        #region  Properties
        /// <summary>
        /// Sets the brush to use for painting the button.
        /// </summary>
        public enum EllipseBrushType
        {
            /// <summary>
            /// Sets the brush to Linear Gradient.
            /// </summary>
            LinearGradient,

            /// <summary>
            /// Sets the brush to Solid.
            /// </summary>
            Solid
        }

        /// <summary>
        /// Sets the Brush to use in drawing the Control
        /// </summary>
        /// <value>The ellipse brush.</value>
        [Description("Sets the Brush to use in drawing the Control")]
        public EllipseBrushType EllipseBrush
        {
            get { return ellipseBrushType; }
            set
            {
                ellipseBrushType = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Color angle of the ellipse
        /// </summary>
        /// <value>The ellipse color angle.</value>
        /// <remarks>This is enabled when Linear Gradient brush type is selected</remarks>
        public float EllipseColorAngle
        {
            get { return ellipseColorAngle; }
            set
            {
                ellipseColorAngle = value;
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
        /// Sets the Background color when it is Hovered
        /// </summary>
        /// <value>The ellipse color hover.</value>
        /// <remarks>This is the Linear gradient color 1</remarks>
        public Color EllipseColorHover
        {
            get { return ellipseColorHover; }
            set
            {
                ellipseColorHover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background color when it is Hovered
        /// </summary>
        /// <value>The ellipse color hover1.</value>
        /// <remarks>This is the Linear gradient color 2</remarks>
        public Color EllipseColorHover1
        {
            get { return ellipseColor1Hover; }
            set
            {
                ellipseColor1Hover = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Sets the Background color when it is set to Default
        /// </summary>
        /// <value>The color of the ellipse.</value>
        /// <remarks>This is the Linear gradient color 1</remarks>
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
        /// Sets the Background color when it is set to Default
        /// </summary>
        /// <value>The ellipse color1.</value>
        /// <remarks>This is the Linear gradient color 2</remarks>
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
        /// Sets the size of the ellipse
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
        /// Sets the Image alignment
        /// </summary>
        /// <value>The image align.</value>
        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                this.Invalidate();
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

        /// <summary>
        /// Sets the Border Width
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value;
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
        /// Creates an instance of the Social Oval Button
        /// </summary>
        public ZeroitOvalButton()
        {
            //SetStyle(ControlStyles.AllPaintingInWmPaint| ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw, true);
            SetStyle((System.Windows.Forms.ControlStyles)(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint), true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;

            IncludeInConstructor();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            //ZeroitAnimate_Transition animate = new ZeroitAnimate_Transition();
            //animate.Target = this;
            //animate.Position = ZeroitAnimate_Transition.Positions.Top;
            //animate.Transitions = ZeroitAnimate_Transition.TransitionType.Bounce;
            //animate.TransitionTime = 50;
            //animate.Destination = this.Location.X + 5;
            //animate.ZeroitActivate();

            //ButtonAnimator animate = new ButtonAnimator();
            //animate.AnimationType = ButtonAnimator.GetAnimationType.YLocationEffect;
            //animate.EasingType = ButtonAnimator.EasingFunctionTypes.Linear;
            //animate.Duration = 2000;
            //animate.Reverse = true;
            //animate.Loops = 1;
            //animate.Target = this;
            //animate.ValueToReach = this.Location.X;
            //animate.Activate();


        }
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

            LinearGradientBrush InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 5, Height - 5), ellipseColor, ellipseColor1, ellipseColorAngle);
            LinearGradientBrush PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 5, Height - 5), ellipseColorHover, ellipseColor1Hover, ellipseColorAngle);
            //LinearGradientBrush PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width - 5, Height - 5), ellipseColorHover, ellipseColor1Hover, ellipseColorAngle);



            switch (ellipseBrushType)
            {

                case EllipseBrushType.LinearGradient:
                    switch (Mousestate)
                    {
                        case 0:
                            G.FillEllipse(InactiveGB, new Rectangle(0, 0, Width - 5, Height - 5));
                            G.DrawEllipse(new Pen(ellipseColorBorder) { Width = borderWidth }, new Rectangle(0, 0, Width - 5, Height - 5));

                            PointF ImgPoint = ImageLocation(GetStringFormat(ContentAlignment.MiddleCenter), Size, ImageSize);
                            if (Image != null)
                            {
                                G.DrawImage(_Image, (int)ImgPoint.X, (int)ImgPoint.Y, ImageSize.Width, ImageSize.Height);
                            }

                            break;
                        case 1:
                            G.FillEllipse(PressedGB, new Rectangle(0, 0, Width - 5, Height - 5));
                            G.DrawEllipse(new Pen(ellipseColorBorder) { Width = borderWidth }, new Rectangle(0, 0, Width - 5, Height - 5));

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

                case EllipseBrushType.Solid:
                    switch (Mousestate)
                    {
                        case 0:
                            G.FillEllipse(new SolidBrush(ellipseColor), new Rectangle(0, 0, Width - 5, Height - 5));
                            G.DrawEllipse(new Pen(ellipseColorBorder) { Width = borderWidth }, new Rectangle(0, 0, Width - 5, Height - 5));

                            PointF ImgPoint = ImageLocation(GetStringFormat(ContentAlignment.MiddleCenter), Size, ImageSize);
                            if (Image != null)
                            {
                                G.DrawImage(_Image, (int)ImgPoint.X, (int)ImgPoint.Y, ImageSize.Width, ImageSize.Height);
                            }

                            break;
                        case 1:
                            G.FillEllipse(new SolidBrush(ellipseColor1Hover), new Rectangle(0, 0, Width - 5, Height - 5));
                            G.DrawEllipse(new Pen(ellipseColorBorder) { Width = borderWidth }, new Rectangle(0, 0, Width - 5, Height - 5));

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

                //case EllipseBrushType.LinearGradient:
                //    G.FillEllipse(InactiveGB, new Rectangle(0, 0, Width - 5, Height - 5));
                //    G.DrawEllipse(new Pen(ellipseColorBorder), new Rectangle(0, 0, Width - 5, Height - 5));

                //    break;
                //case EllipseBrushType.Solid:
                //    G.FillEllipse(new SolidBrush(ellipseColor), new Rectangle(0, 0, Width - 5, Height - 5));
                //    G.DrawEllipse(new Pen(ellipseColorBorder), new Rectangle(0, 0, Width - 5, Height - 5));

                //    break;
                //default:
                //    break;
            }

            


            //G.FillEllipse(new SolidBrush(ellipseColor), new Rectangle(0, 0, Width - 5, Height -5));
            //G.DrawEllipse(new Pen(ellipseColorBorder), new Rectangle(0, 0, Width - 5, Height - 5));

            //G.FillPie(new SolidBrush(ellipseColor), new Rectangle(0, 0, Width - 5, Height - 5), 0, 270);
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

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitSocialButtonOvalDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitSocialButtonOvalDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitSocialButtonOvalSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitSocialButtonOvalSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitSocialButtonOvalSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitOvalButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSocialButtonOvalSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitSocialButtonOvalSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitOvalButton;

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
        /// Gets or sets the ellipse brush.
        /// </summary>
        /// <value>The ellipse brush.</value>
        public Zeroit.Framework.Button.ZeroitOvalButton.EllipseBrushType EllipseBrush
        {
            get { return colUserControl.EllipseBrush; }
            set
            {
                GetPropertyByName("EllipseBrush").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the ellipse color angle.
        /// </summary>
        /// <value>The ellipse color angle.</value>
        public float EllipseColorAngle
        {
            get
            {
                return colUserControl.EllipseColorAngle;
            }
            set
            {
                GetPropertyByName("EllipseColorAngle").SetValue(colUserControl, value);
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
        /// Gets or sets the ellipse color hover.
        /// </summary>
        /// <value>The ellipse color hover.</value>
        public Color EllipseColorHover
        {
            get
            {
                return colUserControl.EllipseColorHover;
            }
            set
            {
                GetPropertyByName("EllipseColorHover").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the ellipse color hover1.
        /// </summary>
        /// <value>The ellipse color hover1.</value>
        public Color EllipseColorHover1
        {
            get
            {
                return colUserControl.EllipseColorHover1;
            }
            set
            {
                GetPropertyByName("EllipseColorHover1").SetValue(colUserControl, value);
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
        /// Gets or sets the size of the ellipse.
        /// </summary>
        /// <value>The size of the ellipse.</value>
        public int EllipseSize
        {
            get
            {
                return colUserControl.EllipseSize;
            }
            set
            {
                GetPropertyByName("EllipseSize").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("EllipseBrush",
                                 "Brush", "Appearance",
                                 "Sets the brush type for painting the button."));
            items.Add(new DesignerActionPropertyItem("EllipseColorAngle",
                                 "ColorAngle", "Appearance",
                                 "Sets the angle of the color."));
            items.Add(new DesignerActionPropertyItem("EllipseColorBorder",
                                 "Color Border", "Appearance",
                                 "Sets the Border Color"));

            items.Add(new DesignerActionPropertyItem("EllipseColorHover",
                                 "Color Hover", "Appearance",
                                 "Sets the Hover Color."));

            items.Add(new DesignerActionPropertyItem("EllipseColorHover1",
                                 "Color Hover1", "Appearance",
                                 "Sets the Hover Color."));

            items.Add(new DesignerActionPropertyItem("EllipseColor",
                                 "Color", "Appearance",
                                 "Sets the Color of the Ellipse."));

            items.Add(new DesignerActionPropertyItem("EllipseColor1",
                                 "Color1", "Appearance",
                                 "Sets the Color of the Ellipse."));

            //items.Add(new DesignerActionPropertyItem("EllipseSize",
            //                     "Ellipse Size", "Appearance",
            //                     "Sets the Size of the Ellipse."));

            items.Add(new DesignerActionPropertyItem("Image",
                                 "Image", "Appearance",
                                 "Sets the Image of the Ellipse."));

            items.Add(new DesignerActionPropertyItem("ImageAlign",
                                 "Image Align", "Appearance",
                                 "Sets the Image Alignment of the Ellipse."));

            items.Add(new DesignerActionPropertyItem("BorderWidth",
                "Border Width", "Appearance",
                "Sets the Border Width of the Ellipse."));

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
