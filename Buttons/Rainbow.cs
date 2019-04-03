// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Rainbow.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zeroit.Framework.Button
{

    #region Rainbow Button

    #region Delegates
    /// <summary>
    /// Event handler delegate for the ColorChanged event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ColorChangedEventHandler(object sender, EventArgs e);
    /// <summary>
    /// Event handler delegate for the TransparentcyChanged event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void TransparentcyChangedEventHandler
        (object sender, EventArgs e);

    #endregion

    #region Control    
    /// <summary>
    /// A multi colored button with five colours merged as one in a rainbow effect
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [Designer(typeof(ZeroitButtonRainBowDesigner))]    
    public class ZeroitRainBowButton : System.Windows.Forms.Button
    {
        #region Class varibles, constructors and events

        #region Events


        /// <summary>
        /// Event that is called when a colour is changed
        /// </summary>
        public event ColorChangedEventHandler ColorChanged;

        /// <summary>
        /// Event that is called when the transparentcy is changed
        /// </summary>
        public event TransparentcyChangedEventHandler TransparentcyChanged;

        #endregion

        #region Fields


        // 2 colours that make up the lineargradientbrushs
        /// <summary>
        /// The color1
        /// </summary>
        private Color _color1;
        /// <summary>
        /// The color2
        /// </summary>
        private Color _color2;
        /// <summary>
        /// The color3
        /// </summary>
        private Color _color3;
        /// <summary>
        /// The color4
        /// </summary>
        private Color _color4;
        /// <summary>
        /// The color5
        /// </summary>
        private Color _color5;

        // trasparentcy for the color merge
        // initalize them with 64, can be changed later
        /// <summary>
        /// The color transparentcy1
        /// </summary>
        private int _colorTransparentcy1 = 64;
        /// <summary>
        /// The color transparentcy2
        /// </summary>
        private int _colorTransparentcy2 = 64;
        /// <summary>
        /// The color transparentcy3
        /// </summary>
        private int _colorTransparentcy3 = 64;
        /// <summary>
        /// The color transparentcy4
        /// </summary>
        private int _colorTransparentcy4 = 64;
        /// <summary>
        /// The color transparentcy5
        /// </summary>
        private int _colorTransparentcy5 = 64;

        /// <summary>
        /// The angle1
        /// </summary>
        private float angle1 = 5;
        /// <summary>
        /// The angle2
        /// </summary>
        private float angle2 = 5;
        /// <summary>
        /// The angle3
        /// </summary>
        private float angle3 = 5;
        /// <summary>
        /// The angle4
        /// </summary>
        private float angle4 = 5;
        #endregion

        #region Public Properties


        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle1.</value>
        public float ColorAngle1
        {
            get { return angle1; }
            set
            {
                angle1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle2.</value>
        public float ColorAngle2
        {
            get { return angle2; }
            set
            {
                angle2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle3.</value>
        public float ColorAngle3
        {
            get { return angle3; }
            set
            {
                angle3 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the angle.
        /// </summary>
        /// <value>The angle4.</value>
        public float ColorAngle4
        {
            get { return angle4; }
            set
            {
                angle4 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// First colour from the left
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
        {
            get { return _color1; }
            set { _color1 = value; Invalidate(); invokeColorChange(); }
        }
        /// <summary>
        /// Second colour from the left
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
        {
            get { return _color2; }
            set { _color2 = value; Invalidate(); invokeColorChange(); }
        }
        /// <summary>
        /// Third colour from the left
        /// </summary>
        /// <value>The color3.</value>
        public Color Color3
        {
            get { return _color3; }
            set { _color3 = value; Invalidate(); invokeColorChange(); }
        }
        /// <summary>
        /// Forth colour from the left
        /// </summary>
        /// <value>The color4.</value>
        public Color Color4
        {
            get { return _color4; }
            set { _color4 = value; Invalidate(); invokeColorChange(); }
        }
        /// <summary>
        /// Fifth colour from the left
        /// </summary>
        /// <value>The color5.</value>
        public Color Color5
        {
            get { return _color5; }
            set { _color5 = value; Invalidate(); invokeColorChange(); }
        }

        /// <summary>
        /// Transparency for Color1
        /// </summary>
        /// <value>The color transparentcy1.</value>
        public int ColorTransparentcy1
        {
            get { return _colorTransparentcy1; }
            set { _colorTransparentcy1 = value; Invalidate(); invokeTransparentcyChange(); }
        }
        /// <summary>
        /// Transparency for Color2
        /// </summary>
        /// <value>The color transparentcy2.</value>
        public int ColorTransparentcy2
        {
            get { return _colorTransparentcy2; }
            set { _colorTransparentcy2 = value; Invalidate(); invokeTransparentcyChange(); }
        }
        /// <summary>
        /// Transparency for Color3
        /// </summary>
        /// <value>The color transparentcy3.</value>
        public int ColorTransparentcy3
        {
            get { return _colorTransparentcy3; }
            set { _colorTransparentcy3 = value; Invalidate(); invokeTransparentcyChange(); }
        }
        /// <summary>
        /// Transparency for Color4
        /// </summary>
        /// <value>The color transparentcy4.</value>
        public int ColorTransparentcy4
        {
            get { return _colorTransparentcy4; }
            set { _colorTransparentcy4 = value; Invalidate(); invokeTransparentcyChange(); }
        }
        /// <summary>
        /// Transparency for Color5
        /// </summary>
        /// <value>The color transparentcy5.</value>
        public int ColorTransparentcy5
        {
            get { return _colorTransparentcy5; }
            set { _colorTransparentcy5 = value; Invalidate(); invokeTransparentcyChange(); }
        }

        #endregion

        #region Button Constructors

        /// <summary>
        /// rainbowButton Constructor
        /// </summary>
        /// <param name="color1">First colour on the left of the button</param>
        /// <param name="color2">Second colour on the left of the button</param>
        /// <param name="color3">Third colour on the left of the button</param>
        /// <param name="color4">Forth colour on the left of the button</param>
        /// <param name="color5">Fifth colour on the left of the button</param>
        public ZeroitRainBowButton
            (Color color1, Color color2, Color color3, Color color4, Color color5)
        {
            Color1 = color1;
            Color2 = color2;
            Color3 = color3;
            Color4 = color4;
            Color5 = color5;
            IncludeInConstructor();
        }
        /// <summary>
        /// Constructor that uses default colours(Green,Yellow,Red,Blue)
        /// </summary>
        public ZeroitRainBowButton()
        {
            Color1 = Color.Green;
            Color2 = Color.Yellow;
            Color3 = Color.Red;
            Color4 = Color.Blue;
            Color5 = Color.DeepPink;

            IncludeInConstructor();
        }

        #endregion

        #endregion

        #region Overrides
        /// <summary>
        /// Over written OnPaint class. Does all the drawing
        /// </summary>
        /// <param name="pe">PaintEventArgs used to do the drawing</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            TransparentInPaint(pe.Graphics);

            base.OnPaint(pe);

            
            // getting 25% of the ClientRectangle
            float percentage = ClientRectangle.Width * 0.25f;

            // getting rectangle to fill
            RectangleF pRect = new RectangleF(new PointF(0.0f, 0.0f), new SizeF(percentage, ClientRectangle.Height));

            // create the first transparent colours
            Color c1 = Color.FromArgb(ColorTransparentcy1, Color1);
            Color c2 = Color.FromArgb(ColorTransparentcy2, Color2);

            // create the first brush
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush
                (pRect, c1, c2, angle1);

            // fill the first segment
            pe.Graphics.FillRectangle(b, pRect);

            // get second rectangle
            pRect.Offset(percentage, 0);

            // get the second colours
            c1 = Color.FromArgb(ColorTransparentcy2, Color2);
            c2 = Color.FromArgb(ColorTransparentcy3, Color3);

            // create second brush
            b.Dispose();
            b = new System.Drawing.Drawing2D.LinearGradientBrush
                (pRect, c1, c2, angle2);

            // fill the second segment
            pe.Graphics.FillRectangle(b, pRect);

            // get third rectangle
            pRect.Offset(percentage, 0);

            // get the third colours
            c1 = Color.FromArgb(ColorTransparentcy3, Color3);
            c2 = Color.FromArgb(ColorTransparentcy4, Color4);

            // create third brush
            b.Dispose();
            b = new System.Drawing.Drawing2D.LinearGradientBrush
                (pRect, c1, c2, angle3);

            // fill the third rectangle
            pe.Graphics.FillRectangle(b, pRect);

            // get last rectangle
            pRect.Offset(percentage, 0);

            // get the last colours
            c1 = Color.FromArgb(ColorTransparentcy4, Color4);
            c2 = Color.FromArgb(ColorTransparentcy5, Color5);

            // create last brush
            b.Dispose();
            b = new System.Drawing.Drawing2D.LinearGradientBrush
                (pRect, c1, c2, angle4);

            // fill the last rectangle
            pe.Graphics.FillRectangle(b, pRect);

            // dispose of resources
            b.Dispose();
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Invokes the color change.
        /// </summary>
        private void invokeColorChange()
        {
            if (ColorChanged != null)
            {
                EventArgs e = new EventArgs();
                ColorChanged(this, e);
            }
        }
        /// <summary>
        /// Invokes the transparentcy change.
        /// </summary>
        private void invokeTransparentcyChange()
        {
            if (TransparentcyChanged != null)
            {
                EventArgs e = new EventArgs();
                TransparentcyChanged(this, e);
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

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonRainBowDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonRainBowDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonRainBowSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonRainBowSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitButtonRainBowSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitRainBowButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonRainBowSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonRainBowSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitRainBowButton;

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
        /// Gets or sets the color1.
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
        {
            get
            {
                return colUserControl.Color1;
            }
            set
            {
                GetPropertyByName("Color1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color2.
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
        {
            get
            {
                return colUserControl.Color2;
            }
            set
            {
                GetPropertyByName("Color2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color3.
        /// </summary>
        /// <value>The color3.</value>
        public Color Color3
        {
            get
            {
                return colUserControl.Color3;
            }
            set
            {
                GetPropertyByName("Color3").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color4.
        /// </summary>
        /// <value>The color4.</value>
        public Color Color4
        {
            get
            {
                return colUserControl.Color4;
            }
            set
            {
                GetPropertyByName("Color4").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color5.
        /// </summary>
        /// <value>The color5.</value>
        public Color Color5
        {
            get
            {
                return colUserControl.Color5;
            }
            set
            {
                GetPropertyByName("Color5").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color angle1.
        /// </summary>
        /// <value>The color angle1.</value>
        public float ColorAngle1
        {
            get
            {
                return colUserControl.ColorAngle1;
            }
            set
            {
                GetPropertyByName("ColorAngle1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color angle2.
        /// </summary>
        /// <value>The color angle2.</value>
        public float ColorAngle2
        {
            get
            {
                return colUserControl.ColorAngle2;
            }
            set
            {
                GetPropertyByName("ColorAngle2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color angle3.
        /// </summary>
        /// <value>The color angle3.</value>
        public float ColorAngle3
        {
            get
            {
                return colUserControl.ColorAngle3;
            }
            set
            {
                GetPropertyByName("ColorAngle3").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color angle4.
        /// </summary>
        /// <value>The color angle4.</value>
        public float ColorAngle4
        {
            get
            {
                return colUserControl.ColorAngle4;
            }
            set
            {
                GetPropertyByName("ColorAngle4").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color transparentcy1.
        /// </summary>
        /// <value>The color transparentcy1.</value>
        public int ColorTransparentcy1
        {
            get
            {
                return colUserControl.ColorTransparentcy1;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color transparentcy2.
        /// </summary>
        /// <value>The color transparentcy2.</value>
        public int ColorTransparentcy2
        {
            get
            {
                return colUserControl.ColorTransparentcy2;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color transparentcy3.
        /// </summary>
        /// <value>The color transparentcy3.</value>
        public int ColorTransparentcy3
        {
            get
            {
                return colUserControl.ColorTransparentcy3;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy3").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color transparentcy4.
        /// </summary>
        /// <value>The color transparentcy4.</value>
        public int ColorTransparentcy4
        {
            get
            {
                return colUserControl.ColorTransparentcy4;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy4").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color transparentcy5.
        /// </summary>
        /// <value>The color transparentcy5.</value>
        public int ColorTransparentcy5
        {
            get
            {
                return colUserControl.ColorTransparentcy5;
            }
            set
            {
                GetPropertyByName("ColorTransparentcy5").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Color1",
                                 "Color1", "Appearance",
                                 "Sets the background color of rainbow1."));

            items.Add(new DesignerActionPropertyItem("Color2",
                                 "Color2", "Appearance",
                                 "Sets the background color of rainbow2."));

            items.Add(new DesignerActionPropertyItem("Color3",
                                 "Color3", "Appearance",
                                 "Sets the background color of rainbow3."));

            items.Add(new DesignerActionPropertyItem("Color4",
                                 "Color4", "Appearance",
                                 "Sets the background color of rainbow4."));

            items.Add(new DesignerActionPropertyItem("Color5",
                                 "Color5", "Appearance",
                                 "Sets the background color of rainbow5."));

            items.Add(new DesignerActionPropertyItem("ColorAngle1",
                                 "ColorAngle1", "Appearance",
                                 "Sets the color angle."));

            items.Add(new DesignerActionPropertyItem("ColorAngle2",
                                 "ColorAngle2", "Appearance",
                                 "Sets the color angle."));

            items.Add(new DesignerActionPropertyItem("ColorAngle3",
                                 "ColorAngle3", "Appearance",
                                 "Sets the color angle."));

            items.Add(new DesignerActionPropertyItem("ColorAngle4",
                                 "ColorAngle4", "Appearance",
                                 "Sets the color angle."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy1",
                                 "ColorTransparentcy1", "Appearance",
                                 "Sets the color transparency for color1."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy2",
                                 "ColorTransparentcy2", "Appearance",
                                 "Sets the color transparency for color2."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy3",
                                 "ColorTransparentcy3", "Appearance",
                                 "Sets the color transparency for color3."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy4",
                                 "ColorTransparentcy4", "Appearance",
                                 "Sets the color transparency for color4."));

            items.Add(new DesignerActionPropertyItem("ColorTransparentcy5",
                                 "ColorTransparentcy5", "Appearance",
                                 "Sets the color transparency for color5."));

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
