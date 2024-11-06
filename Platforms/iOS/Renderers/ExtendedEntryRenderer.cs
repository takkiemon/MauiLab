﻿using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using FacilityApp.Shared;
using FacilityApps;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace FacilityApps
{
    /// <summary>
    /// A renderer for the ExtendedEntry control.
    /// </summary>
    public class ExtendedEntryRenderer : EntryRenderer
    {
        /// <summary>
        /// The _left swipe gesture recognizer
        /// </summary>
        private UISwipeGestureRecognizer _leftSwipeGestureRecognizer;
        /// <summary>
        /// The _right swipe gesture recognizer
        /// </summary>
        private UISwipeGestureRecognizer _rightSwipeGestureRecognizer;

        /// <summary>
        /// The on element changed callback.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = e.NewElement as ExtendedEntry;

            if (view != null)
            {
                SetFont (view);
                SetTextAlignment (view);
                SetBorder (view);
                SetPlaceholderTextColor (view);
                SetKeyboardBar(view);
                SetIsNumeric(view);

                ResizeHeight ();
            }

            if (e.OldElement == null)
            {
                _leftSwipeGestureRecognizer = new UISwipeGestureRecognizer(() => view.LeftSwipe?.Invoke(this, EventArgs.Empty))
                    {
                        Direction = UISwipeGestureRecognizerDirection.Left
                    };

                _rightSwipeGestureRecognizer = new UISwipeGestureRecognizer(()=> view.RightSwipe?.Invoke(this, EventArgs.Empty))
                    {
                        Direction = UISwipeGestureRecognizerDirection.Right
                    };

                Control.AddGestureRecognizer(_leftSwipeGestureRecognizer);
                Control.AddGestureRecognizer(_rightSwipeGestureRecognizer);
            }

            if (Control == null)
            {
                return;
            }

            if (e.NewElement == null)
            {
                Control.RemoveGestureRecognizer(_leftSwipeGestureRecognizer);
                Control.RemoveGestureRecognizer(_rightSwipeGestureRecognizer);
            }
        }

        /// <summary>
        /// The on element property changed callback
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (ExtendedEntry)Element;

            if (e.PropertyName == ExtendedEntry.FontProperty.PropertyName)
            {
                SetFont(view);
            }
            else if (e.PropertyName == ExtendedEntry.XAlignProperty.PropertyName)
            {
                SetTextAlignment(view);
            }
            else if (e.PropertyName == ExtendedEntry.HasBorderProperty.PropertyName)
            {
                SetBorder(view);
            }
            else if (e.PropertyName == ExtendedEntry.PlaceholderTextColorProperty.PropertyName)
            {
                SetPlaceholderTextColor(view);
            }
            else if (e.PropertyName == ExtendedEntry.HasKeyboardBarProperty.PropertyName)
            {
                SetKeyboardBar(view);
            }
            else if (e.PropertyName == ExtendedEntry.IsNumericProperty.PropertyName)
            {
                SetIsNumeric(view);
            }

            ResizeHeight();
        }

        /// <summary>
        /// Sets the text alignment.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetTextAlignment(ExtendedEntry view)
        {
            switch (view.XAlign)
            {
                case TextAlignment.Center:
                    Control.TextAlignment = UITextAlignment.Center;
                    break;
                case TextAlignment.End:
                    Control.TextAlignment = UITextAlignment.Right;
                    break;
                case TextAlignment.Start:
                    Control.TextAlignment = UITextAlignment.Left;
                    break;
            }
        }

        /// <summary>
        /// Sets the font.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetFont(ExtendedEntry view)
        {
            UIFont uiFont;
            if (view.Font != Font.Default && (uiFont = view.Font.ToUIFont()) != null)
                Control.Font = uiFont;
            else if (view.Font == Font.Default)
            {
                var size = (nfloat)view.FontSize;
                Control.Font = UIFont.SystemFontOfSize(size);
            }
        }

        /// <summary>
        /// Sets the border.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetBorder(ExtendedEntry view)
        {
            Control.BorderStyle = view.HasBorder ? UITextBorderStyle.RoundedRect : UITextBorderStyle.None;
        }

        /// <summary>
        /// Resizes the height.
        /// </summary>
        private void ResizeHeight()
        {
            if (Element.HeightRequest >= 0) return;

            var height = Math.Max(Bounds.Height,
                new UITextField {Font = Control.Font}.IntrinsicContentSize.Height);

            Control.Frame = new CGRect(0.0f, 0.0f, (nfloat) Element.Width,  (nfloat) height);

            Element.HeightRequest = height;
        }

        /// <summary>
        /// Sets the color of the placeholder text.
        /// </summary>
        /// <param name="view">The view.</param>
        void SetPlaceholderTextColor(ExtendedEntry view)
        {
            /*
            UIColor *color = [UIColor lightTextColor];
            YOURTEXTFIELD.attributedPlaceholder = [[NSAttributedString alloc] initWithString:@"PlaceHolder Text" attributes:@{NSForegroundColorAttributeName: color}];
            */
            if(string.IsNullOrEmpty(view.Placeholder) == false && view.PlaceholderTextColor != Color.Default) {
                NSAttributedString placeholderString = new NSAttributedString(view.Placeholder, new UIStringAttributes(){ ForegroundColor = view.PlaceholderTextColor.ToUIColor() });
                Control.AttributedPlaceholder = placeholderString;
            }
        }

        void SetKeyboardBar(ExtendedEntry view)
        {
            if (!view.HasKeyboardBar)
            {
                Control.AutocorrectionType = UITextAutocorrectionType.No;
                var shortcut = Control.InputAssistantItem;
                shortcut.LeadingBarButtonGroups = new UIBarButtonItemGroup[0];
                shortcut.TrailingBarButtonGroups = new UIBarButtonItemGroup[0];
            }
        }

        void SetIsNumeric(ExtendedEntry view)
        {
            if (view.IsNumeric)
            {
                view.Keyboard = Keyboard.Numeric;
                Control.KeyboardType = UIKeyboardType.NumbersAndPunctuation;

                return;
            }

            if (view.Keyboard == Keyboard.Numeric)
            {
                // when coming back from numeric goto default
                view.Keyboard = Keyboard.Default;
                Control.KeyboardType = UIKeyboardType.Default;
            }
        }
    }
}