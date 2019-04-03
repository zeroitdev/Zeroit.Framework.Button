// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="OffButton.cs" company="Zeroit Dev Technologies">
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
    #region ZeroitOffButton

    /// <summary>
    /// A class collection for rendering Off Button
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Button" />
    [Designer(typeof(ZeroitOffButtonDesigner))]
    public partial class ZeroitOffButton : System.Windows.Forms.Button
    {

        #region Private Fileds
        //Timer
        /// <summary>
        /// The timer1
        /// </summary>
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        //Images
        /// <summary>
        /// The img on
        /// </summary>
        private Image _img_on;
        /// <summary>
        /// The img click
        /// </summary>
        private Image _img_click;
        /// <summary>
        /// The img back
        /// </summary>
        private Image _img_back;
        /// <summary>
        /// The img
        /// </summary>
        private Image _img;
        /// <summary>
        /// The img fad
        /// </summary>
        private Image _img_fad;
        /// <summary>
        /// The s folder
        /// </summary>
        private String s_folder;
        /// <summary>
        /// The s filename
        /// </summary>
        private String s_filename;

        //Fading
        /// <summary>
        /// The b fad
        /// </summary>
        bool b_fad = true;
        /// <summary>
        /// The i fad
        /// </summary>
        int i_fad = 0; //0 nothing, 1 entering, 2 leaving
        /// <summary>
        /// The i value
        /// </summary>
        int i_value = 255; //Level of transparency

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance of the Off Button
        /// </summary>
        //Constructor
        public ZeroitOffButton()
        {
            this.BackColor = Color.Transparent;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FlatAppearance.BorderSize = 0;
            this.TextAlign = ContentAlignment.BottomCenter;
            this.ImageAlign = ContentAlignment.TopCenter;
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(timer1_Tick);

            IncludeInConstructor();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the Image when it is Default.
        /// </summary>
        /// <value>The image on.</value>
        //Properties
        public Image ImageOn
        {
            get { return _img_on; }
            set { _img_on = value; }
        }

        /// <summary>
        /// Sets the Image when it is Clicked.
        /// </summary>
        /// <value>The image click.</value>
        public Image ImageClick
        {
            get { return _img_click; }
            set { _img_click = value; }
        }

        /// <summary>
        /// Sets the Background image.
        /// </summary>
        /// <value>The image back.</value>
        public Image ImageBack
        {
            get { return _img_back; }
            set
            {
                _img_back = value;
            }
        }
        /// <summary>
        /// Sets the Actual Image.
        /// </summary>
        /// <value>The actual image.</value>
        public Image ActualImage
        {
            get { return _img; }
            set
            {
                _img = value;
                this.Image = _img;
            }
        }

        /// <summary>
        /// Sets the image folder
        /// </summary>
        /// <value>The folder.</value>
        public string Folder
        {
            get { return s_folder; }
            set
            {
                if (value != null)
                {
                    if ((char)value[value.Length - 1] != '\\')
                    {
                        s_folder = value + "\\";
                    }
                    else
                    {
                        s_folder = value;
                    }
                }

            }
        }

        /// <summary>
        /// Sets the file name
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName
        {
            get { return s_filename; }
            set
            {
                s_filename = value;

                if (s_folder != null & s_filename != null)
                {
                    _img = Image.FromFile(s_folder + s_filename);
                    this.Image = _img;
                }
            }
        }


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

        /// <summary>
        /// Sets the rendering mode
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



        #endregion

        #region Private Methods


        //Methods
        /// <summary>
        /// Paints the background.
        /// </summary>
        public void PaintBackground()
        {
            object _img_temp = new object();
            if (i_fad == 1)
            {
                _img_temp = _img_on.Clone();
            }
            else if (i_fad == 2)
            {
                _img_temp = _img_back.Clone();
            }
            _img_fad = (Image)_img_temp;
            Graphics _grf = Graphics.FromImage(_img_fad);

            _grf.SmoothingMode = smoothing;
            SolidBrush brocha = new SolidBrush(Color.FromArgb(i_value, 255, 255, 255));
            //_grf.FillRectangle(brocha, 0, 0, _img_fad.Width, _img_fad.Height);

            _grf.FillRectangle(brocha, 0, 0, _img_fad.Width, _img_fad.Height);
            this.BackgroundImage = _img_fad;
        }


        #endregion

        #region Overrides and Events

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (i_fad)
            {
                case 1:
                    {
                        if (i_value == 0)
                        {
                            i_value = 255;
                        }
                        if (i_value > -1)
                        {
                            PaintBackground();
                            i_value -= 10;
                        }
                        else
                        {
                            i_value = 0;
                            PaintBackground();
                            timer1.Stop();
                        }
                        break;
                    }
                case 2:
                    {
                        if (i_value == 0)
                        {
                            i_value = 255;
                        }
                        if (i_value > -1)
                        {
                            PaintBackground();
                            i_value -= 10;
                        }
                        else
                        {
                            i_value = 0;
                            PaintBackground();
                            timer1.Stop();
                        }
                        break;

                    }
            }
        }
        /// <summary>
        /// Handles the <see cref="E:MouseEnter" /> event.
        /// </summary>
        /// <param name="e">Provides information for the event.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            if (b_fad)
            {
                i_fad = 1;
                timer1.Start();
            }
            else
            {
                this.BackgroundImage = _img_on;
            }
            base.OnMouseEnter(e);
        }
        /// <summary>
        /// Handles the <see cref="E:MouseLeave" /> event.
        /// </summary>
        /// <param name="e">Provides missing information for the event.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            if (b_fad) { i_fad = 2; timer1.Start(); }
            else
            {
                this.BackgroundImage = _img_back;
            }
            base.OnMouseLeave(e);

        }
        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseDown(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="mevent">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs mevent)
        {

            this.BackgroundImage = _img_click;
            ClickOnMouseDown(mevent);
            base.OnMouseDown(mevent);
        }
        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnMouseUp(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="mevent">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs mevent)
        {
            this.BackgroundImage = _img_on;

            ClickOnMouseUp(mevent);
            base.OnMouseUp(mevent);
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

        #endregion

        
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitOffButtonDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitOffButtonDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitOffButtonSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitOffButtonSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitOffButtonSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitOffButton colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitOffButtonSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitOffButtonSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitOffButton;

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
        /// Gets or sets the image on.
        /// </summary>
        /// <value>The image on.</value>
        public Image ImageOn
        {
            get
            {
                return colUserControl.ImageOn;
            }
            set
            {
                GetPropertyByName("ImageOn").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image click.
        /// </summary>
        /// <value>The image click.</value>
        public Image ImageClick
        {
            get
            {
                return colUserControl.ImageClick;
            }
            set
            {
                GetPropertyByName("ImageClick").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the image back.
        /// </summary>
        /// <value>The image back.</value>
        public Image ImageBack
        {
            get
            {
                return colUserControl.ImageBack;
            }
            set
            {
                GetPropertyByName("ImageBack").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the actual image.
        /// </summary>
        /// <value>The actual image.</value>
        public Image ActualImage
        {
            get
            {
                return colUserControl.ActualImage;
            }
            set
            {
                GetPropertyByName("ActualImage").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the folder.
        /// </summary>
        /// <value>The folder.</value>
        public string Folder
        {
            get
            {
                return colUserControl.Folder;
            }
            set
            {
                GetPropertyByName("Folder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName
        {
            get
            {
                return colUserControl.FileName;
            }
            set
            {
                GetPropertyByName("FileName").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public ContentAlignment TextAlign
        {
            get
            {
                return colUserControl.TextAlign;
            }
            set
            {
                GetPropertyByName("TextAlign").SetValue(colUserControl, value);
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
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
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

            items.Add(new DesignerActionPropertyItem("TextAlign",
                                 "Text Align", "Appearance",
                                 "Sets the position of the text."));

            items.Add(new DesignerActionPropertyItem("ImageAlign",
                                 "Image Align", "Appearance",
                                 "Sets the position of the image."));

            items.Add(new DesignerActionPropertyItem("ImageOn",
                                 "ImageOn", "Appearance",
                                 "Sets the active image."));

            items.Add(new DesignerActionPropertyItem("ImageClick",
                                 "Image Click", "Appearance",
                                 "Sets the image when the control is clicked."));

            items.Add(new DesignerActionPropertyItem("ImageBack",
                                 "Image Back", "Appearance",
                                 "Sets the back image of the control."));

            items.Add(new DesignerActionPropertyItem("ActualImage",
                                 "Actual Image", "Appearance",
                                 "Set the default image of the control."));

            items.Add(new DesignerActionPropertyItem("Folder",
                                 "Folder", "Appearance",
                                 "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("FileName",
                                 "File Name", "Appearance",
                                 "Choose a FileName."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the text of the control."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the graphics rendering mode."));



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
