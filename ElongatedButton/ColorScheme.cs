// ***********************************************************************
// Assembly         : Zeroit.Framework.Button
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="ColorScheme.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;

namespace Zeroit.Framework.Button
{
    #region ColorScheme

    /// <summary>
    /// Sets the color scheme
    /// </summary>
    public enum EnmColorScheme
    {
        /// <summary>
        /// Sets the color scheme to Purple
        /// </summary>
        Purple,

        /// <summary>
        /// Sets the color scheme to Green
        /// </summary>
        Green,

        /// <summary>
        /// Sets the color scheme to Yellow
        /// </summary>
        Yellow,

        /// <summary>
        /// Sets the color scheme to Custom
        /// </summary>
        Custom
    }
    /// <summary>
    /// This class works as a common point for all the controls to
    /// implement the color scheme
    /// </summary>
    internal class ZeroitGroupButtonColorScheme
    {
        /// <summary>
        /// The o color scheme
        /// </summary>
        private EnmColorScheme oClrScheme;
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitGroupButtonColorScheme"/> class.
        /// </summary>
        /// <param name="aoColorScheme">The ao color scheme.</param>
        public ZeroitGroupButtonColorScheme(EnmColorScheme aoColorScheme)
        {
            //
            // TODO: Add constructor logic here
            //
            oClrScheme = aoColorScheme;

        }
        /// <summary>
        /// This method sets the values of different color properties
        /// for controls of IGradientButtonColor Type
        /// </summary>
        /// <param name="aCtrl">a control.</param>
        internal void SetColorScheme(IGradientButtonColor aCtrl)
        {
            switch (oClrScheme)
            {
                case EnmColorScheme.Green:
                    //=========================================================
                    //Setting color properties of button control for
                    //Green color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(193, 201, 140);
                    aCtrl.BackgroundBottomColor = Color.FromArgb(193, 201, 140);
                    aCtrl.BackgroundTopColor = Color.FromArgb(230, 233, 208);
                    aCtrl.BorderBottomColor = Color.FromArgb(230, 233, 208);
                    aCtrl.BorderTopColor = Color.FromArgb(193, 201, 140);
                    aCtrl.DefaultBorderColor = Color.FromArgb(167, 168, 127);
                    aCtrl.DisabledFontColor = Color.FromArgb(156, 147, 113);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(209, 215, 170);
                    aCtrl.DisabledTopColor = Color.FromArgb(240, 242, 227);
                    aCtrl.FontColor = Color.FromArgb(105, 110, 26);
                    aCtrl.PressedFontColor = Color.Black;

                    break;
                //---------------------------------------------------------
                case EnmColorScheme.Purple:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Purple color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(183, 157, 206);
                    aCtrl.BackgroundTopColor = Color.FromArgb(231, 222, 239);
                    aCtrl.BorderBottomColor = Color.FromArgb(224, 215, 233);
                    aCtrl.BorderTopColor = Color.FromArgb(193, 157, 206);
                    aCtrl.DefaultBorderColor = Color.FromArgb(132, 100, 161);
                    aCtrl.DisabledFontColor = Color.FromArgb(143, 116, 156);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(209, 192, 210);
                    aCtrl.DisabledTopColor = Color.FromArgb(237, 231, 230);
                    aCtrl.FontColor = Color.FromArgb(74, 30, 115);
                    aCtrl.PressedFontColor = Color.Black;
                    break;
                //---------------------------------------------------------
                case EnmColorScheme.Yellow:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Yellow color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(194, 168, 120);
                    aCtrl.BackgroundTopColor = Color.FromArgb(248, 245, 224);
                    aCtrl.BorderBottomColor = Color.FromArgb(229, 219, 196);
                    aCtrl.BorderTopColor = Color.FromArgb(194, 168, 120);
                    aCtrl.DefaultBorderColor = Color.FromArgb(189, 153, 74);
                    aCtrl.DisabledFontColor = Color.FromArgb(156, 147, 113);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(201, 177, 135);
                    aCtrl.DisabledTopColor = Color.FromArgb(241, 236, 212);
                    aCtrl.FontColor = Color.FromArgb(96, 83, 43);
                    aCtrl.PressedFontColor = Color.Black;
                    break;
                //---------------------------------------------------------

                case EnmColorScheme.Custom:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Yellow color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(194, 168, 120);
                    aCtrl.BackgroundTopColor = Color.FromArgb(248, 245, 224);
                    aCtrl.BorderBottomColor = Color.FromArgb(229, 219, 196);
                    aCtrl.BorderTopColor = Color.FromArgb(194, 168, 120);
                    aCtrl.DefaultBorderColor = Color.FromArgb(189, 153, 74);
                    aCtrl.DisabledFontColor = Color.FromArgb(156, 147, 113);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(201, 177, 135);
                    aCtrl.DisabledTopColor = Color.FromArgb(241, 236, 212);
                    //aCtrl.FontColor = Color.FromArgb(96, 83, 43);
                    aCtrl.PressedFontColor = Color.Black;
                    break;
            }
        }


        /// <summary>
        /// This method sets the values of different color properties
        /// for controls of IGradientButtonColor Type
        /// </summary>
        /// <param name="aCtrl">a control.</param>
        /// <param name="customColors">The custom colors.</param>
        internal void SetColorScheme(IGradientButtonColor aCtrl, CustomColors customColors)
        {
            switch (oClrScheme)
            {
                case EnmColorScheme.Green:
                    //=========================================================
                    //Setting color properties of button control for
                    //Green color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(193, 201, 140);
                    aCtrl.BackgroundBottomColor = Color.FromArgb(193, 201, 140);
                    aCtrl.BackgroundTopColor = Color.FromArgb(230, 233, 208);
                    aCtrl.BorderBottomColor = Color.FromArgb(230, 233, 208);
                    aCtrl.BorderTopColor = Color.FromArgb(193, 201, 140);
                    aCtrl.DefaultBorderColor = Color.FromArgb(167, 168, 127);
                    aCtrl.DisabledFontColor = Color.FromArgb(156, 147, 113);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(209, 215, 170);
                    aCtrl.DisabledTopColor = Color.FromArgb(240, 242, 227);
                    aCtrl.FontColor = Color.FromArgb(105, 110, 26);
                    aCtrl.PressedFontColor = Color.Black;

                    break;
                //---------------------------------------------------------
                case EnmColorScheme.Purple:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Purple color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(183, 157, 206);
                    aCtrl.BackgroundTopColor = Color.FromArgb(231, 222, 239);
                    aCtrl.BorderBottomColor = Color.FromArgb(224, 215, 233);
                    aCtrl.BorderTopColor = Color.FromArgb(193, 157, 206);
                    aCtrl.DefaultBorderColor = Color.FromArgb(132, 100, 161);
                    aCtrl.DisabledFontColor = Color.FromArgb(143, 116, 156);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(209, 192, 210);
                    aCtrl.DisabledTopColor = Color.FromArgb(237, 231, 230);
                    aCtrl.FontColor = Color.FromArgb(74, 30, 115);
                    aCtrl.PressedFontColor = Color.Black;
                    break;
                //---------------------------------------------------------
                case EnmColorScheme.Yellow:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Yellow color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = Color.FromArgb(194, 168, 120);
                    aCtrl.BackgroundTopColor = Color.FromArgb(248, 245, 224);
                    aCtrl.BorderBottomColor = Color.FromArgb(229, 219, 196);
                    aCtrl.BorderTopColor = Color.FromArgb(194, 168, 120);
                    aCtrl.DefaultBorderColor = Color.FromArgb(189, 153, 74);
                    aCtrl.DisabledFontColor = Color.FromArgb(156, 147, 113);
                    aCtrl.DisbaledBottomColor = Color.FromArgb(201, 177, 135);
                    aCtrl.DisabledTopColor = Color.FromArgb(241, 236, 212);
                    aCtrl.FontColor = Color.FromArgb(96, 83, 43);
                    aCtrl.PressedFontColor = Color.Black;
                    break;
                //---------------------------------------------------------

                case EnmColorScheme.Custom:
                    //=========================================================
                    //Setting color properties of button control for 
                    //Yellow color scheme
                    //---------------------------------------------------------
                    aCtrl.BackgroundBottomColor = customColors.BackgroundBottomColor;
                    aCtrl.BackgroundTopColor = customColors.BackgroundTopColor;
                    aCtrl.BorderBottomColor = customColors.BorderBottomColor;
                    aCtrl.BorderTopColor = customColors.BorderTopColor;
                    aCtrl.DefaultBorderColor = customColors.DefaultBorderColor;
                    aCtrl.DisabledFontColor = customColors.DisabledFontColor;
                    aCtrl.DisbaledBottomColor = customColors.DisbaledBottomColor;
                    aCtrl.DisabledTopColor = customColors.DisabledTopColor;
                    //aCtrl.FontColor = Color.FromArgb(96, 83, 43);
                    aCtrl.PressedFontColor = customColors.PressedFontColor;
                    break;
            }
        }

        /// <summary>
        /// This method sets the values of different color properties
        /// for controls of IGradientContainer Type
        /// </summary>
        /// <param name="aCtrl">a control.</param>
        /// <exception cref="Zeroit.Framework.Button.InvalidColorSchemeException"></exception>
        internal void SetColorScheme(IGradientContainer aCtrl)
        {
            switch (oClrScheme)
            {
                case EnmColorScheme.Green:
                    //=========================================================
                    // Setting color properties of container control for 
                    // Green color scheme
                    //---------------------------------------------------------
                    aCtrl.FontColor = Color.FromArgb(57, 66, 1);
                    aCtrl.ShadowColor = Color.FromArgb(142, 143, 116);
                    aCtrl.BorderTopColor = Color.FromArgb(225, 225, 183);
                    aCtrl.BorderBottomColor = Color.FromArgb(167, 168, 127);
                    aCtrl.BackgroundTopColor = Color.FromArgb(245, 243, 219);
                    aCtrl.BackgroundBottomColor = Color.FromArgb(214, 209, 153);
                    break;
                //---------------------------------------------------------
                case EnmColorScheme.Purple:
                    //=========================================================
                    // Setting color properties of container control for 
                    // Purple color scheme
                    //---------------------------------------------------------
                    aCtrl.FontColor = Color.FromArgb(137, 101, 163);
                    aCtrl.ShadowColor = Color.FromArgb(110, 92, 121);
                    aCtrl.BorderTopColor = Color.FromArgb(234, 218, 245);
                    aCtrl.BorderBottomColor = Color.FromArgb(191, 161, 211);
                    aCtrl.BackgroundTopColor = Color.FromArgb(251, 246, 255);
                    aCtrl.BackgroundBottomColor = Color.FromArgb(241, 229, 249);
                    break;
                //---------------------------------------------------------

                default:
                    // For container control if other than Purple or Green
                    // any other value is selected it throws an exception
                    throw new InvalidColorSchemeException();
            }
        }
    }
    /// <summary>
    /// This class define the exception which is thrown on invalid selection
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class InvalidColorSchemeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidColorSchemeException"/> class.
        /// </summary>
        public InvalidColorSchemeException() : base("Color Scheme Not Supported")
        {
        }
    }

    /// <summary>
    /// This interface defines properties
    /// for control that have diffrent colors
    /// is disabled mode i.e. ZeroitElongButton
    /// </summary>
    internal interface IGradientDisabledColor
    {
        /// <summary>
        /// Gets or sets the color of the disabled font.
        /// </summary>
        /// <value>The color of the disabled font.</value>
        Color DisabledFontColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the disbaled bottom.
        /// </summary>
        /// <value>The color of the disbaled bottom.</value>
        Color DisbaledBottomColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the disabled top.
        /// </summary>
        /// <value>The color of the disabled top.</value>
        Color DisabledTopColor { get; set; }
    }

    /// <summary>
    /// This interface defines property
    /// for the color of the text on
    /// the control
    /// </summary>
    internal interface IFontColor
    {
        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        Color FontColor { get; set; }
    }

    /// <summary>
    /// This interface defines properties
    /// to set the control background
    /// Gradient's top color and bottom color
    /// </summary>
    internal interface IGradientBackgroundColor
    {
        /// <summary>
        /// Gets or sets the color of the background bottom.
        /// </summary>
        /// <value>The color of the background bottom.</value>
        Color BackgroundBottomColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the background top.
        /// </summary>
        /// <value>The color of the background top.</value>
        Color BackgroundTopColor { get; set; }
    }

    /// <summary>
    /// This interface defines properties
    /// to set control's Gradient Border's
    /// Top color and Bottom Color
    /// </summary>
    internal interface IGradientBorderColor
    {
        /// <summary>
        /// Gets or sets the color of the border top.
        /// </summary>
        /// <value>The color of the border top.</value>
        Color BorderTopColor { get; set; }
        /// <summary>
        /// Gets or sets the color of the border bottom.
        /// </summary>
        /// <value>The color of the border bottom.</value>
        Color BorderBottomColor { get; set; }
    }

    /// <summary>
    /// This interface combines the interfaces
    /// needed for button controls and add button
    /// specific properties
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Button.IFontColor" />
    /// <seealso cref="Zeroit.Framework.Button.IGradientDisabledColor" />
    /// <seealso cref="Zeroit.Framework.Button.IGradientBackgroundColor" />
    /// <seealso cref="Zeroit.Framework.Button.IGradientBorderColor" />
    internal interface IGradientButtonColor :
                    IFontColor, IGradientDisabledColor,
                    IGradientBackgroundColor, IGradientBorderColor
    {
        /// <summary>
        /// Gets or sets the color of the pressed font.
        /// </summary>
        /// <value>The color of the pressed font.</value>
        Color PressedFontColor { get; set; }
        /// <summary>
        /// Gets or sets the default color of the border.
        /// </summary>
        /// <value>The default color of the border.</value>
        Color DefaultBorderColor { get; set; }
    }

    /// <summary>
    /// This interface combines the interfaces
    /// needed for container controls and add
    /// container specific property
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Button.IFontColor" />
    /// <seealso cref="Zeroit.Framework.Button.IGradientBackgroundColor" />
    /// <seealso cref="Zeroit.Framework.Button.IGradientBorderColor" />
    internal interface IGradientContainer :
                        IFontColor, IGradientBackgroundColor,
                        IGradientBorderColor
    {
        /// <summary>
        /// Gets or sets the color of the shadow.
        /// </summary>
        /// <value>The color of the shadow.</value>
        Color ShadowColor { get; set; }
    }

    #endregion
}
