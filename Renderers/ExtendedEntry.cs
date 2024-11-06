using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FacilityApp.Shared
{
    /// <summary>
    /// An extended entry control that allows the Font and text X alignment to be set
    /// </summary>
    public class ExtendedEntry : Entry
    {
        /// <summary>
        /// The font property
        /// </summary>
        public static readonly BindableProperty FontProperty = BindableProperty.Create("Font", typeof(Font), typeof(ExtendedEntry), new Font());

        /// <summary>
        /// The XAlign property
        /// </summary>
        public static readonly BindableProperty XAlignProperty = BindableProperty.Create("XAlign", typeof(TextAlignment), typeof(ExtendedEntry), TextAlignment.Start);

        /// <summary>
        /// The HasBorder property
        /// </summary>
        public static readonly BindableProperty HasBorderProperty = BindableProperty.Create("HasBorder", typeof(bool), typeof(ExtendedEntry), true);

        /// <summary>
        /// The PlaceholderTextColor property
        /// </summary>
        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create("PlaceholderTextColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        /// <summary>
        /// The Placeholder property
        /// </summary>
        new public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create("Placeholder", typeof(string), typeof(ExtendedEntry), "", propertyChanged: PlaceholderPropertyChanged);

        public static void PlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ExtendedEntry)bindable).SetPlaceholder();
        }

        new public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        /// <summary>
        /// The HasKeyboardBar property
        /// </summary>
        public static readonly BindableProperty HasKeyboardBarProperty = BindableProperty.Create("HasKeyboardBar", typeof(bool), typeof(ExtendedEntry), true);

        /// <summary>
        /// Gets or sets the Font
        /// </summary>
        public Font Font
        {
            get { return (Font)GetValue(FontProperty); }
            set { SetValue(FontProperty, value); }
        }

        /// <summary>
        /// Gets or sets the X alignment of the text
        /// </summary>
        public TextAlignment XAlign
        {
            get { return (TextAlignment)GetValue(XAlignProperty); }
            set { SetValue(XAlignProperty, value); }
        }

        /// <summary>
        /// Gets or sets if the border should be shown or not
        /// </summary>
        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        /// <summary>
        /// Sets color for placeholder text
        /// </summary>
        public Color PlaceholderTextColor
        {
            get { return (Color)GetValue(PlaceholderTextColorProperty); }
            set { SetValue(PlaceholderTextColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets if the keyboard bar should be shown or not
        /// </summary>
        public bool HasKeyboardBar
        {
            get { return (bool)GetValue(HasKeyboardBarProperty); }
            set { SetValue(HasKeyboardBarProperty, value); }
        }

        private void SetText(string text)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Text = text;
            });
        }

        public ExtendedEntry()
        {
            TextChanged += (sender, args) =>
            {
                string old = args.OldTextValue;
                string value = args.NewTextValue;

                if (IsNumeric)
                {
                    if (value != null && value.Length != 0)
                    {
                        var cultured = Regex.Replace(value, "[.,]", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        if (cultured != value)
                        {
                            value = cultured;
                        }
                    }

                    if (!IsValidNumeric(value))
                    {
                        SetText(IsValidNumeric(old) ? old : "");

                        return;
                    }
                    else if (Text != value)
                    {
                        SetText(value);
                    }
                }

                if (value != old)
                {
                    ValueChanged?.Invoke(this, new TextChangedEventArgs(old, value));
                }
            };
        }

        /// <summary>
        /// The left swipe
        /// </summary>
        public EventHandler LeftSwipe;
        /// <summary>
        /// The right swipe
        /// </summary>
        public EventHandler RightSwipe;

        public void OnLeftSwipe(object sender, EventArgs e)
        {
            var handler = this.LeftSwipe;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void OnRightSwipe(object sender, EventArgs e)
        {
            var handler = this.RightSwipe;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void SetPlaceholder()
        {
            if (!string.IsNullOrWhiteSpace(Placeholder))
            {
                base.Placeholder = Placeholder;

                return;
            }

            if (!IsNumeric)
            {
                return;
            }

            decimal result = 0;
            string format = IsInteger ? "0" : "0.00";
            base.Placeholder = result.ToString(format, System.Globalization.CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// The IsNumericProperty property
        /// </summary>
        public static readonly BindableProperty IsNumericProperty = BindableProperty.Create(nameof(IsNumeric), typeof(bool), typeof(ExtendedEntry), false, propertyChanged: TypePropertyChanged);

        public bool IsNumeric
        {
            get { return (bool)GetValue(IsNumericProperty); }
            set { SetValue(IsNumericProperty, value); }
        }

        public static readonly BindableProperty IsIntegerProperty = BindableProperty.Create(nameof(IsInteger), typeof(bool), typeof(ExtendedEntry), false, propertyChanged: TypePropertyChanged);

        public bool IsInteger
        {
            get { return (bool)GetValue(IsIntegerProperty); }
            set { SetValue(IsIntegerProperty, value); }
        }

        public static readonly BindableProperty IsUnsignedProperty = BindableProperty.Create(nameof(IsUnsigned), typeof(bool), typeof(ExtendedEntry), false, propertyChanged: TypePropertyChanged);

        public bool IsUnsigned
        {
            get { return (bool)GetValue(IsUnsignedProperty); }
            set { SetValue(IsUnsignedProperty, value); }
        }

        public static void TypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ExtendedEntry)bindable).SetPlaceholder();
        }

        private bool IsValidNumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            var currentCulture = System.Globalization.CultureInfo.CurrentCulture;

            // Make sure all characters are numbers
            bool isValid = value
                .ToCharArray()
                .Count(c =>
                    !char.IsDigit(c) &&
                    (c.ToString() != currentCulture.NumberFormat.NumberDecimalSeparator || IsInteger) &&
                    (c.ToString() != currentCulture.NumberFormat.NegativeSign || IsUnsigned)
                ) == 0;

            value = Regex.Replace(value, "[.,]", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            // Make sure we only have one decimal separator
            isValid = isValid && (
                (value.Last().ToString() == currentCulture.NumberFormat.NumberDecimalSeparator && value.Count(c => c.ToString() == currentCulture.NumberFormat.NumberDecimalSeparator) <= 1) ||
                (value.Last().ToString() != currentCulture.NumberFormat.NumberDecimalSeparator && value.Count(c => c.ToString() == currentCulture.NumberFormat.NumberDecimalSeparator) <= 1)
            );

            // Make sure we only have one negative sign and its at the start
            isValid = isValid && (
                (value.First().ToString() != currentCulture.NumberFormat.NegativeSign && value.Count(c => c.ToString() == currentCulture.NumberFormat.NegativeSign) == 0) ||
                (value.First().ToString() == currentCulture.NumberFormat.NegativeSign && value.Count(c => c.ToString() == currentCulture.NumberFormat.NegativeSign) == 1)
            );

            return isValid;
        }

        public EventHandler<TextChangedEventArgs> ValueChanged;
    }
}
