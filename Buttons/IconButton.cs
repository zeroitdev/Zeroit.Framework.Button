// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="IconButton.cs" company="Zeroit Dev Technologies">
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

    #region IconButton

    #region Alpha
    /// <summary>
    /// Summary description for alpha.
    /// </summary>
	public class alpha
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="alpha"/> class.
        /// </summary>
        public alpha()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Minimums the specified value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>System.Int32.</returns>
        private static int min(int val)
        {
            return (val < 0 ? 0 : val);
        }

        /// <summary>
        /// Sets the alpha.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        /// <param name="alpha">The alpha.</param>
        public static void setAlpha(Bitmap bmp, int alpha)
        {
            Color col;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    col = bmp.GetPixel(i, j);
                    if (col.A > 0)
                        bmp.SetPixel(i, j, Color.FromArgb(min(col.A - alpha), col.R, col.G, col.B));
                }
        }

        /// <summary>
        /// Returns the alpha.
        /// </summary>
        /// <param name="bmp">The BMP.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>Bitmap.</returns>
        public static Bitmap returnAlpha(Bitmap bmp, int alpha)
        {
            Color col;
            Bitmap bmp2 = new Bitmap(bmp);

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    col = bmp.GetPixel(i, j);
                    if (col.A > 0)
                        bmp2.SetPixel(i, j, Color.FromArgb(min(col.A - alpha), col.R, col.G, col.B));
                }
            return bmp2;
        }
    }

    #endregion

    #region Control

    /// <summary>
    /// Summary description for Iconits.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitButtonIconDesigner))]
    public class ZeroitIconButton : System.Windows.Forms.Control
    {

        #region Private Field
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;
        /// <summary>
        /// The timer1
        /// </summary>
        private System.Windows.Forms.Timer timer1;
        /// <summary>
        /// The t
        /// </summary>
        private System.Windows.Forms.ToolTip t = new ToolTip();
        /// <summary>
        /// The BMP
        /// </summary>
        Bitmap[] bmp;
        /// <summary>
        /// The flag
        /// </summary>
        int flag;
        /// <summary>
        /// The enter
        /// </summary>
        bool enter;

        /// <summary>
        /// The g
        /// </summary>
        private Graphics g, g2;
        /// <summary>
        /// The imwidth
        /// </summary>
        int imwidth, imheight;
        /// <summary>
        /// The curwidth
        /// </summary>
        double curwidth, curheight;
        /// <summary>
        /// The addx
        /// </summary>
        double addx, addy;
        /// <summary>
        /// The dblbuffer
        /// </summary>
        Bitmap dblbuffer;
        /// <summary>
        /// The blur
        /// </summary>
        bool blur = true;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public Bitmap Icon
        {
            get { return bmp[0]; }
            set
            {
                for (int i = 0; i < 4; i++)
                    bmp[i] = new Bitmap(Width, Height);
                dblbuffer = new Bitmap(Width, Height);

                bmp[0] = value;
                bmp[1] = alpha.returnAlpha(bmp[0], 60);
                bmp[2] = alpha.returnAlpha(bmp[0], 120);
                bmp[3] = alpha.returnAlpha(bmp[0], 180);
                draw(0);
            }
        }

        /// <summary>
        /// Gets or sets the height and width of the control.
        /// </summary>
        /// <value>The size.</value>
        public new Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                Width = ((Size)value).Width;
                Height = ((Size)value).Height;
                if (Width > 160)
                {
                    //MessageBox.Show("Width cannot exceed 160 :p");
                    Width = 160;
                }
                if (Height > 128)
                {
                    //MessageBox.Show("Height cannot exceed 128 :p");
                    Height = 128;
                }
                calc();
            }
        }

        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        /// <value>The size of the icon.</value>
        public Size IconSize
        {
            get { return new Size(imwidth, imheight); }
            set
            {
                imwidth = ((Size)value).Width;
                imheight = ((Size)value).Height;
                if (imwidth > Width) imwidth = Width;
                if (imheight > Height) imheight = Height;
                calc();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitIconButton" /> should have blur enabled/disabled.
        /// </summary>
        /// <value><c>true</c> if blur; otherwise, <c>false</c>.</value>
        public bool Blur
        {
            get { return blur; }
            set
            {
                blur = value;
                if (!blur)
                {
                    bmp[1].Dispose();
                    bmp[2].Dispose();
                    bmp[3].Dispose();
                }
                else
                {
                    bmp[1] = alpha.returnAlpha(bmp[0], 60);
                    bmp[2] = alpha.returnAlpha(bmp[0], 120);
                    bmp[3] = alpha.returnAlpha(bmp[0], 180);
                }
            }
        }

        /// <summary>
        /// Gets or sets the tooltip text.
        /// </summary>
        /// <value>The tooltip text.</value>
        public string TooltipText
        {
            get { return t.GetToolTip(this); }
            set
            {
                t.SetToolTip(this, value);
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitIconButton" /> class.
        /// </summary>
        public ZeroitIconButton()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();


            SetStyle(ControlStyles.SupportsTransparentBackColor, true);


            // TODO: Add any initialization after the InitializeComponent call			
            bmp = new Bitmap[4];
            for (int i = 0; i < 4; i++)
                bmp[i] = new Bitmap(Width, Height);
            dblbuffer = new Bitmap(Width, Height);
            IconSize = new Size(Width / 2, Height / 2);

            g = this.CreateGraphics();

            IncludeInConstructor();
            

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
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Iconits
            // 
            //this.BackColor = Parent.BackColor;
            this.Name = "Iconits";
            this.Size = new System.Drawing.Size(64, 64);
            this.IconSize = new Size(32, 32);

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Iconits_Paint);
            this.MouseEnter += new System.EventHandler(this.Iconits_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Iconits_MouseLeave);

        }
        #endregion

        /// <summary>
        /// Handles the Paint event of the Iconits control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void Iconits_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            TransparentInPaint(e.Graphics);

            draw(3);
        }

        /// <summary>
        /// Calculates this instance.
        /// </summary>
        private void calc()
        {
            curwidth = imwidth;
            curheight = imheight;

            addx = (double)(Width - imwidth) / 10;
            addy = (double)(Height - imheight) / 10;
        }

        /// <summary>
        /// Draws the specified state.
        /// </summary>
        /// <param name="state">The state.</param>
        private void draw(int state)
        {
            int st;

            if (blur)
                st = state;
            else
                st = 0;

            g2 = Graphics.FromImage(dblbuffer);
            g2.Clear(this.BackColor);
            g2.DrawImage(bmp[st], (int)((double)Width - curwidth) / 2, (int)((double)Height - curheight) / 2, (int)curwidth, (int)curheight);

            g.DrawImageUnscaled(dblbuffer, 0, 0);
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (enter)
            {
                if (curwidth < Width)
                {
                    curwidth += addx;
                }

                if (curheight < Height)
                {
                    curheight += addy;
                }

                if (curwidth >= Width && curheight >= Height) timer1.Stop();

                flag++;
            }
            else
            {
                if (curwidth > imwidth)
                {
                    curwidth -= addx;
                }

                if (curheight > imheight)
                {
                    curheight -= addy;
                }

                if (curwidth <= imwidth && curheight <= imheight) timer1.Stop();

                flag--;
            }

            if (flag > 9) draw(0);
            else if (flag > 6) draw(1);
            else if (flag > 3) draw(2);
            else draw(3);
        }

        /// <summary>
        /// Handles the MouseEnter event of the Iconits control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Iconits_MouseEnter(object sender, System.EventArgs e)
        {
            enter = true;
            timer1.Start();
        }

        /// <summary>
        /// Handles the MouseLeave event of the Iconits control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Iconits_MouseLeave(object sender, System.EventArgs e)
        {
            enter = false;
            timer1.Start();
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



    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitButtonIconDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitButtonIconDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitButtonIconSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitButtonIconSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitButtonIconSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitIconButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitButtonIconSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitButtonIconSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitIconButton;

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
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public Bitmap Icon
        {
            get
            {
                return colUserControl.Icon;
            }
            set
            {
                GetPropertyByName("Icon").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public Size Size
        {
            get
            {
                return colUserControl.Size;
            }
            set
            {
                GetPropertyByName("Size").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the icon.
        /// </summary>
        /// <value>The size of the icon.</value>
        public Size IconSize
        {
            get
            {
                return colUserControl.IconSize;
            }
            set
            {
                GetPropertyByName("IconSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tooltip text.
        /// </summary>
        /// <value>The tooltip text.</value>
        public string TooltipText
        {
            get
            {
                return colUserControl.TooltipText;
            }
            set
            {
                GetPropertyByName("TooltipText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitButtonIconSmartTagActionList"/> is blur.
        /// </summary>
        /// <value><c>true</c> if blur; otherwise, <c>false</c>.</value>
        public bool Blur
        {
            get
            {
                return colUserControl.Blur;
            }
            set
            {
                GetPropertyByName("Blur").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Icon",
                                 "Icon", "Appearance",
                                 "Sets the image of the control."));

            items.Add(new DesignerActionPropertyItem("Size",
                                 "Size", "Appearance",
                                 "Sets the expand limit. "));

            items.Add(new DesignerActionPropertyItem("IconSize",
                                 "Icon Size", "Appearance",
                                 "Sets the Icon Size. Max-Width:160 Max-Height:128."));

            items.Add(new DesignerActionPropertyItem("TooltipText",
                                 "Tooltip Text", "Appearance",
                                 "Sets the tooltip text."));

            items.Add(new DesignerActionPropertyItem("Blur",
                                 "Blur", "Appearance",
                                 "Enable the blur property of the control."));

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
