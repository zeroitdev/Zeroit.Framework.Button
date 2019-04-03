// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="GlossyButton.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Glossy Button

    #region Control
    /// <summary>
    /// A class collection for rendering Glossy Button.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitGlossyButtonDesigner))]
    public partial class ZeroitGlossyButton : UserControl
    {


        #region Image Designer

        #region Include in paint method

        ///////////////////////////////////////////////////////////////////////////////////////////////// 
        //                                                                                             //                                                                     
        //         ------------------------Add this to the Paint Method ------------------------       //
        //                                                                                             //
        // Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
        //                                                                                             //
        // PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
        //                                                                                             //
        // if ((Image == null))                                                                        //
        //     {                                                                                       //
        //         G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        // else                                                                                        //
        //      {                                                                                      //
        //         G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
        //          G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
        //             {                                                                               //
        //                 Alignment = _TextAlignment,                                                 //
        //                 LineAlignment = StringAlignment.Center                                      //
        //             });                                                                             //
        //      }                                                                                      //
        //                                                                                             //
        /////////////////////////////////////////////////////////////////////////////////////////////////

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
        /// Sets the Image.
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
        /// Sets the Image size.
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
        /// Sets the Image alignment.
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

        #region Constructor

        /// <summary>
        /// Creates an instance of a Glossy Button
        /// </summary>
        public ZeroitGlossyButton()
        {
            InitializeComponent();

            IncludeInConstructor();

            label1.Text = Text;
        }
        #endregion

        #region DLL Imports

        // Import the Gdi32 DLL
        /// <summary>
        /// Creates the round rect RGN.
        /// </summary>
        /// <param name="leftRect">The left rect.</param>
        /// <param name="topRect">The top rect.</param>
        /// <param name="rightRect">The right rect.</param>
        /// <param name="bottomRect">The bottom rect.</param>
        /// <param name="wEllipse">The w ellipse.</param>
        /// <param name="hEllipse">The h ellipse.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        // Import the Method from DLL. With this method you can create a Form with rounded corners
        private static extern IntPtr CreateRoundRectRgn(int leftRect, int topRect, int rightRect, int bottomRect, int wEllipse, int hEllipse);

        #endregion

        #region Private Fields

        // Create a Pen that will draw the border of the button.
        /// <summary>
        /// The border
        /// </summary>
        private Color border = Color.Aqua;
        /// <summary>
        /// The hover color
        /// </summary>
        private Color hoverColor = Color.Firebrick;
        /// <summary>
        /// The pressed color
        /// </summary>
        private Color pressedColor = Color.Maroon;
        /// <summary>
        /// The normal color
        /// </summary>
        private Color normalColor = Color.DodgerBlue;
        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the color for the Border.
        /// </summary>
        /// <value>The border.</value>
        public Color Border
        {
            get { return border; }
            set
            {
                border = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the color when the button is Hovered.
        /// </summary>
        /// <value>The color of the hover.</value>
        public Color HoverColor
        {
            get { return hoverColor; }
            set
            {
                hoverColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the color when the button is Pressed.
        /// </summary>
        /// <value>The color of the pressed.</value>
        public Color PressedColor
        {
            get { return pressedColor; }
            set
            {
                pressedColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the color when the button is Normal.
        /// </summary>
        /// <value>The color of the normal.</value>
        public Color NormalColor
        {
            get { return normalColor; }
            set
            {
                normalColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Sets the Text for the button.
        /// </summary>
        /// <value>The text.</value>
        // Configure the BtnText Property
        [Description("The text associated with the control")]
        [Category("Appearance")]
        public new string Text
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
                label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
            }
        }

        /// <summary>
        /// Sets the Font for the button.
        /// </summary>
        /// <value>The font.</value>
        // Set the font of label1 through the Font Property of ZeroitGlossyButton
        public override Font Font
        {
            get
            {
                return label1.Font;
            }
            set
            {
                label1.Font = value;
                // Center the label
                label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Ons the mouse enter.
        /// </summary>
        protected void onMouseEnter()
        {
            border = Color.Red;
            this.BackColor = hoverColor;
            this.Invalidate();
        }

        /// <summary>
        /// Ons the mouse down.
        /// </summary>
        protected void onMouseDown()
        {
            this.BackColor = pressedColor;
            this.Invalidate();
        }

        /// <summary>
        /// Normals the style.
        /// </summary>
        protected void NormalStyle()
        {
            border = Color.Aqua;
            this.BackColor = normalColor;
            this.Invalidate();
        }
        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            TransparentInPaint(e.Graphics);
            base.OnPaint(e);

            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle R1 = new Rectangle(0, 0, Width, Height);                                          //
                                                                                                        //
            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);                   //
                                                                                                        //


            // Create the rounded corners for your form (in this case your button)
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 3, 3));
            // Create a transparent white gradient
            LinearGradientBrush lb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(150, Color.White), Color.FromArgb(50, Color.White), LinearGradientMode.Vertical);
            // Draw the gradient
            G.FillRectangle(lb, 2, 2, this.Width - 6, this.Height / 2);
            // Draw the border
            G.DrawRectangle(new Pen(border), 0, 0, this.Width - 3, this.Height - 3);

            if ((Image == null))                                                                        //
            {                                                                                       //
                G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat           //
                {                                                                               //
                    Alignment = _TextAlignment,                                                 //
                    LineAlignment = StringAlignment.Center                                      //
                });                                                                             //
            }                                                                                      //
            else                                                                                        //
            {                                                                                      //
                G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);              //
                G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat          //
                {                                                                               //
                    Alignment = _TextAlignment,                                                 //
                    LineAlignment = StringAlignment.Center                                      //
                });                                                                             //
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            // Center the label
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            onMouseEnter();
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            NormalStyle();
        }
        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            onMouseDown();
            ClickOnMouseDown(e);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            onMouseEnter();
            ClickOnMouseUp(e);
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the MouseEnter event of the label1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            onMouseEnter();
        }

        /// <summary>
        /// Handles the MouseLeave event of the label1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            NormalStyle();
        }

        /// <summary>
        /// Handles the MouseDown event of the label1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            onMouseDown();
        }

        /// <summary>
        /// Handles the MouseUp event of the label1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            onMouseEnter();
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

    partial class ZeroitGlossyButton
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(25, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            //this.label1.Text = Text;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // ZeroitGlossyButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "ZeroitGlossyButton";
            this.Size = new System.Drawing.Size(86, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;
    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(ZeroitGlossyButtonDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitGlossyButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitGlossyButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitGlossyButtonSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitGlossyButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitGlossyButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitGlossyButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGlossyButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitGlossyButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitGlossyButton;

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
        /// Gets or sets the border.
        /// </summary>
        /// <value>The border.</value>
        public Color Border
        {
            get
            {
                return colUserControl.Border;
            }
            set
            {
                GetPropertyByName("Border").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the hover.
        /// </summary>
        /// <value>The color of the hover.</value>
        public Color HoverColor
        {
            get
            {
                return colUserControl.HoverColor;
            }
            set
            {
                GetPropertyByName("HoverColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the pressed.
        /// </summary>
        /// <value>The color of the pressed.</value>
        public Color PressedColor
        {
            get
            {
                return colUserControl.PressedColor;
            }
            set
            {
                GetPropertyByName("PressedColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the normal.
        /// </summary>
        /// <value>The color of the normal.</value>
        public Color NormalColor
        {
            get
            {
                return colUserControl.NormalColor;
            }
            set
            {
                GetPropertyByName("NormalColor").SetValue(colUserControl, value);
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
        /// Gets or sets the font.
        /// </summary>
        /// <value>The font.</value>
        public Font Font
        {
            get
            {
                return colUserControl.Font;
            }
            set
            {
                GetPropertyByName("Font").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Border",
                                 "Border", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("HoverColor",
                                 "Hover Color", "Appearance",
                                 "Sets the hover color."));

            items.Add(new DesignerActionPropertyItem("PressedColor",
                                 "Pressed Color", "Appearance",
                                 "Sets the pressed color."));

            items.Add(new DesignerActionPropertyItem("NormalColor",
                                 "Normal Color", "Appearance",
                                 "Sets the normal color."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets teh button text."));

            items.Add(new DesignerActionPropertyItem("Font",
                                 "Font", "Appearance",
                                 "Sets the font for the button text."));

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
