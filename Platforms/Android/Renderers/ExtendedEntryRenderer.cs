using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Text;
using Android.Text.Method;
using Android.Util;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
//using XLabs.Forms.Controls;
//using XLabs.Forms.Extensions;
using FacilityApp.Shared;
using Color = Xamarin.Forms.Color;
using FacilityAppAndroid;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using static Android.Views.View;
using System.Threading.Tasks;
using Android.Views.Animations;
using Android.Views.InputMethods;
using Android.Widget;
using Android.App;
using Plugin.CurrentActivity;
using System.Linq;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace FacilityAppAndroid
{
    /// <summary>
    /// Interface of TypefaceCaches
    /// </summary>
    public interface ITypefaceCache
    {
        /// <summary>
        /// Removes typeface from cache
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="typeface">Typeface.</param>
        void StoreTypeface(string key, Typeface typeface);

        /// <summary>
        /// Removes the typeface.
        /// </summary>
        /// <param name="key">The key.</param>
        void RemoveTypeface(string key);

        /// <summary>
        /// Retrieves the typeface.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Typeface.</returns>
        Typeface RetrieveTypeface(string key);
    }

    /// <summary>
    /// TypefaceCache caches used typefaces for performance and memory reasons. 
    /// Typeface cache is singleton shared through execution of the application.
    /// You can replace default implementation of the cache by implementing ITypefaceCache 
    /// interface and setting instance of your cache to static property SharedCache of this class
    /// </summary>
    public static class TypefaceCache
    {
        private static ITypefaceCache sharedCache;

        /// <summary>
        /// Returns the shared typeface cache.
        /// </summary>
        /// <value>The shared cache.</value>
        public static ITypefaceCache SharedCache {
            get {
                if(sharedCache == null)
                {
                    sharedCache = new DefaultTypefaceCache();
                }
                return sharedCache;
            }
            set {
                if(sharedCache != null && sharedCache.GetType() == typeof(DefaultTypefaceCache))
                {
                    ((DefaultTypefaceCache)sharedCache).PurgeCache();
                }
                sharedCache = value;
            }
        }




    }

    /// <summary>
    /// Default implementation of the typeface cache.
    /// </summary>
    internal class DefaultTypefaceCache : ITypefaceCache
    {
        private Dictionary<string,Typeface> _cacheDict;

        public DefaultTypefaceCache()
        {
            _cacheDict = new Dictionary<string, Typeface>();
        }


        public Typeface RetrieveTypeface(string key)
        {
            if(_cacheDict.ContainsKey(key))
            {
                return _cacheDict[key];
            } else
            {
                return null;
            }
        }

        public void StoreTypeface(string key, Typeface typeface)
        {
            _cacheDict[key] = typeface;
        }

        public void RemoveTypeface(string key)
        {
            _cacheDict.Remove(key);
        }

        public void PurgeCache()
        {
            _cacheDict = new Dictionary<string, Typeface>();
        }
    }



    /// <summary>
    /// Andorid specific extensions for Font class.
    /// </summary>
    public static class FontExtensions
    {

        /// <summary>
        /// This method returns typeface for given typeface using following rules:
        /// 1. Lookup in the cache
        /// 2. If not found, look in the assets in the fonts folder. Save your font under its FontFamily name. 
        /// If no extension is written in the family name .ttf is asumed
        /// 3. If not found look in the files under fonts/ folder
        /// If no extension is written in the family name .ttf is asumed
        /// 4. If not found, try to return typeface from Xamarin.Forms ToTypeface() method
        /// 5. If not successfull, return Typeface.Default
        /// </summary>
        /// <returns>The extended typeface.</returns>
        /// <param name="font">Font</param>
        /// <param name="context">Android Context</param>
        public static Typeface ToExtendedTypeface(this Font font, Context context)
        {
            Typeface typeface = null;

            //1. Lookup in the cache
            var hashKey = font.ToHasmapKey();
            typeface = TypefaceCache.SharedCache.RetrieveTypeface(hashKey);

#if DEBUG
            if (typeface != null)
            {
                Console.WriteLine("Typeface for font {0} found in cache", font);
            }
#endif

            //2. If not found, try custom asset folder
            if(typeface == null && !string.IsNullOrEmpty(font.FontFamily))
            {
                string filename = font.FontFamily;

                //if no extension given then assume and add .ttf
                if(filename.LastIndexOf(".", StringComparison.Ordinal) != filename.Length - 4)
                {
                    filename = string.Format("{0}.ttf", filename);
                }

                var potentialFiles = new string[]
                {
                    "fonts/" + filename,
                    filename
                };

                foreach (var path in potentialFiles)
                {
                    try
                    {
                        typeface = Typeface.CreateFromAsset(context.Assets, path);
                    }
                    catch (Exception)
                    {
#if DEBUG
                        Console.WriteLine("Failed to load font: {0}, trying load from file", path);
#endif

                        try
                        {
                            typeface = Typeface.CreateFromFile(path);
                        }
                        catch (Exception)
                        {
#if DEBUG
                            Console.WriteLine("Failed to load font from file: {0}", path);
#endif
                        }
                    }
                }
            }

            //3. If not found, fall back to default Xamarin.Forms implementation to load system font
            if(typeface == null)
            {
                typeface = font.ToTypeface();
            }

            if(typeface == null)
            {
                #if DEBUG
                Console.WriteLine("Falling back to default typeface");
                #endif
                typeface = Typeface.Default;
            }

            //Store in cache
            TypefaceCache.SharedCache.StoreTypeface(hashKey, typeface);

            return typeface;

        }

        /// <summary>
        /// Provides unique identifier for the given font.
        /// </summary>
        /// <returns>Unique string identifier for the given font</returns>
        /// <param name="font">Font.</param>
        private static string ToHasmapKey(this Font font)
        {
            return string.Format("{0}.{1}.{2}.{3}", font.FontFamily, font.FontSize, font.NamedSize, (int)font.FontAttributes);
        }
    }

    public class DecimalKeyListener : Java.Lang.Object, IKeyListener
    {
        private DigitsKeyListener KeyListener;

        public DecimalKeyListener(DigitsKeyListener keyListener)
        {
            KeyListener = keyListener;
        }

        public InputTypes InputType => InputTypes.ClassNumber | InputTypes.NumberFlagDecimal;

        public void ClearMetaKeyState(Android.Views.View view, IEditable content, [GeneratedEnum] MetaKeyStates states)
        {
            KeyListener.ClearMetaKeyState(view, content, states);
        }

        public bool OnKeyDown(Android.Views.View view, IEditable text, [GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return KeyListener.OnKeyDown(view, text, keyCode, e);
        }

        public bool OnKeyOther(Android.Views.View view, IEditable text, KeyEvent e)
        {
            return KeyListener.OnKeyOther(view, text, e);
        }

        public bool OnKeyUp(Android.Views.View view, IEditable text, [GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return KeyListener.OnKeyUp(view, text, keyCode, e);
        }
    }


    public class NullListener : Java.Lang.Object, IOnTouchListener
    {
        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            return true;
        }
    }

    /// <summary>
    /// Class ExtendedEntryRenderer.
    /// </summary>
    public class ExtendedEntryRenderer : EntryRenderer, IOnTouchListener
    {
        private const int MinDistance = 10;

        private float downX, downY, upX, upY;
        
        private Drawable originalBackground;

        public ExtendedEntryRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = (ExtendedEntry)Element;
            
            if (Control != null && e.NewElement != null && e.NewElement.IsPassword)
            {
                Control.SetTypeface(Typeface.Default, TypefaceStyle.Normal);
                Control.TransformationMethod = new PasswordTransformationMethod();
            }
            
            if (originalBackground == null)
				originalBackground = Control.Background;

			var nativeEditText = (global::Android.Widget.EditText)Control;
			nativeEditText.SetBackground(null);

            SetFont(view);
            SetTextAlignment(view);
            SetBorder(view);
            SetPlaceholderTextColor(view);
            SetIsNumeric(view, e);
            SetIsPassword(view);

            if (e.NewElement == null)
            {
                this.Touch -= HandleTouch;
            }

            if (e.OldElement == null)
            {
                this.Touch += HandleTouch;
            }
        }

        /// <summary>
        /// Handles the touch.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Android.Views.View.TouchEventArgs"/> instance containing the event data.</param>
        void HandleTouch (object sender, TouchEventArgs e)
        {
            var element = (ExtendedEntry)this.Element;
            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    this.downX = e.Event.GetX();
                    this.downY = e.Event.GetY();
                    return;
                case MotionEventActions.Up:
                case MotionEventActions.Cancel:
                case MotionEventActions.Move:
                    this.upX = e.Event.GetX();
                    this.upY = e.Event.GetY();

                    float deltaX = this.downX - this.upX;
                    float deltaY = this.downY - this.upY;

                        // swipe horizontal?
                    if(Math.Abs(deltaX) > Math.Abs(deltaY))
                    {
                        if(Math.Abs(deltaX) > MinDistance)
                        {
                            if (deltaX < 0)
                            {
                                element.OnRightSwipe(this, EventArgs.Empty); 
                                return;
                            }

                            if (deltaX > 0)
                            {
                                element.OnLeftSwipe(this, EventArgs.Empty); 
                                return;
                            }
                        }
                        else 
                        {
                            Log.Info("ExtendedEntry", "Horizontal Swipe was only " + Math.Abs(deltaX) + " long, need at least " + MinDistance);
                            return; // We don't consume the event
                        }
                    }
                    // swipe vertical?
//                    else 
//                    {
//                        if(Math.abs(deltaY) > MIN_DISTANCE){
//                            // top or down
//                            if(deltaY < 0) { this.onDownSwipe(); return true; }
//                            if(deltaY > 0) { this.onUpSwipe(); return true; }
//                        }
//                        else {
//                            Log.i(logTag, "Vertical Swipe was only " + Math.abs(deltaX) + " long, need at least " + MIN_DISTANCE);
//                            return false; // We don't consume the event
//                        }
//                    }

                    return;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
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
            else if (e.PropertyName == ExtendedEntry.IsNumericProperty.PropertyName)
            {
                //SetIsNumeric(view);
            }
            else if (e.PropertyName == "IsPassword")
            {
                SetIsPassword(view);
            }
            else
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
                {
                    this.Control.SetBackgroundColor(view.BackgroundColor.ToAndroid());
                }
            }
        }

        ///// <summary>
        ///// Sets the border.
        ///// </summary>
        ///// <param name="view">The view.</param>
        private void SetBorder(ExtendedEntry view)
        {
           if (view.HasBorder == false)
           {
                var shape = new ShapeDrawable(new RectShape());
                shape.Paint.Alpha = 0;
                shape.Paint.SetStyle(Paint.Style.Stroke);
                Control.Background = shape;
           }
           else 
           {
               Control.SetBackground (originalBackground);
           }
        }

        /// <summary>
        /// Sets the text alignment.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetTextAlignment(ExtendedEntry view)
        {
            switch (view.XAlign)
            {
                case Xamarin.Forms.TextAlignment.Center:
                    Control.Gravity = GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    Control.Gravity = GravityFlags.End;
                    break;
                case Xamarin.Forms.TextAlignment.Start:
                    Control.Gravity = GravityFlags.Start;
                    break;
            }
        }

        /// <summary>
        /// Sets the font.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetFont(ExtendedEntry view)
        {
            if (view.Font != Font.Default) 
            {
                Control.TextSize = view.Font.ToScaledPixel();
                Control.Typeface = view.Font.ToExtendedTypeface(Context);
            }
        }

        /// <summary>
        /// Sets the color of the placeholder text.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetPlaceholderTextColor(ExtendedEntry view)
        {
            if (view.PlaceholderTextColor != Color.Default)
            {
                Control.SetHintTextColor(view.PlaceholderTextColor.ToAndroid());    
            }       
        }

        private void SetIsNumeric(ExtendedEntry view, ElementChangedEventArgs<Entry> e)
        {
            if (!view.IsNumeric)
            {
                return;
            }

            var newCustomEntryKeyboard = e.NewElement as ExtendedEntry;
            var oldCustomEntryKeyboard = e.OldElement as ExtendedEntry;

            if (newCustomEntryKeyboard == null && oldCustomEntryKeyboard == null)
            {
                return;
            }

            EditText.ShowSoftInputOnFocus = false;
            inputConnection = EditText.OnCreateInputConnection(new EditorInfo());

            if (e.NewElement != null)
            {
                extendedEntry = newCustomEntryKeyboard;
                CreateCustomKeyboard();

                // Here we set the EditText event handlers
                EditText.FocusChange += Control_FocusChange;
                EditText.Click += EditText_Click;
                EditText.Touch += EditText_Touch;
            }

            // Dispose control
            if (e.OldElement != null)
            {
                EditText.FocusChange -= Control_FocusChange;
                EditText.Click -= EditText_Click;
                EditText.Touch -= EditText_Touch;
            }
        }

        private void SetIsPassword(ExtendedEntry view)
        {
            if (!view.IsPassword)
            {
                return;
            }

            (Control as FormsEditText).InputType = InputTypes.ClassText | InputTypes.TextVariationPassword;
        }

        private Context context;

        // This will map the button resource id to the String value that we want to 
        // input when that button is clicked.
        Dictionary<int, string> keyValues = new();

        // Our communication link to the EditText
        IInputConnection inputConnection;

        private ExtendedEntry extendedEntry;

        private KeyboardView keyboardView;

        protected override void OnFocusChangeRequested(object sender, VisualElement.FocusRequestArgs e)
        {
            e.Result = true;

            if (e.Focus)
                Control.RequestFocus();
            else
                Control.ClearFocus();
        }

        private void SetClick(IOnTouchListener listener)
        {
            keyValues = new();
            for (var i = 0; i < keyboardView.ChildCount; i++)
            {
                var row = (ViewGroup)keyboardView.GetChildAt(i);
                for (var j = 0; j < row.ChildCount; j++)
                {
                    var button = (Android.Widget.Button)row.GetChildAt(j);
                    keyValues.Add(button.Id, button.Text);
                    button.SetOnTouchListener(listener);
                }
            }
        }

        // Event handlers
        private void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            // Workaround to avoid null reference exceptions in runtime
            if (EditText.Text == null)
                EditText.Text = string.Empty;

            if (e.HasFocus)
            {
                SetClick(this);

                if (Element.Keyboard == Keyboard.Text)
                {
                    CreateCustomKeyboard();
                }

                ShowKeyboardWithAnimation();
            }
            else
            {
                // When the control loses focus, we set an empty listener to avoid crashes
                SetClick(new NullListener());

                HideKeyboardView();
            }
        }

        private void EditText_Click(object sender, System.EventArgs e)
        {
            ShowKeyboardWithAnimation();
        }

        private void EditText_Touch(object sender, TouchEventArgs e)
        {
            EditText.OnTouchEvent(e.Event);

            e.Handled = true;
        }

        // Keyboard related section

        // Method to create our custom keyboard view
        private void CreateCustomKeyboard()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var rootView = activity.Window.DecorView.FindViewById(Android.Resource.Id.Content);
            var activityRootView = (ViewGroup)((ViewGroup)rootView).GetChildAt(0);

            keyboardView = activityRootView.FindViewById<KeyboardView>(Resource.Id.customKeyboard);

            // If the previous line fails, it means the keyboard needs to be created and added
            if (keyboardView == null)
            {
                keyboardView = (KeyboardView)activity.LayoutInflater.Inflate(Resource.Layout.CustomKeyboard, null);
                keyboardView.Id = Resource.Id.customKeyboard;
                keyboardView.Focusable = true;
                keyboardView.FocusableInTouchMode = true;

                var delete = (Android.Widget.Button)keyboardView.FindViewById(Resource.Id.button_delete);
                Typeface fontawesome = Typeface.CreateFromAsset(CrossCurrentActivity.Current.Activity.Assets, "webfonts/fa-solid-900.ttf");
                delete.SetTypeface(fontawesome, TypefaceStyle.Normal);

                var separator = (Android.Widget.Button)keyboardView.FindViewById(Resource.Id.button_decimal);
                separator.Text = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                var layoutParams = new Android.Widget.RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
                layoutParams.AddRule(LayoutRules.AlignParentBottom);
                activityRootView.AddView(keyboardView, layoutParams);

                HideKeyboardView();
            }
        }

        // Method to show our custom keyboard
        private void ShowKeyboardWithAnimation()
        {
            // First we must ensure that keyboard is hidden to
            // prevent showing it multiple times
            if (keyboardView.Visibility == ViewStates.Gone)
            {
                // Ensure native keyboard is hidden
                var imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
                imm.HideSoftInputFromWindow(EditText.WindowToken, 0);

                var animation = AnimationUtils.LoadAnimation(context, Resource.Animation.slide_in_bottom);
                keyboardView.Animation = animation;

                keyboardView.Enabled = true;

                // Show custom keyboard with animation
                keyboardView.Visibility = ViewStates.Visible;
                keyboardView.BringToFront();

                var element = FindScrollViewChild();
                if (element != null)
                {
                    element.Padding = new Thickness(0, 0, 0, 200);
                }
            }
        }

        // Method to hide our custom keyboard
        private void HideKeyboardView()
        {
            var element = FindScrollViewChild();
            if (element != null)
            {
                element.Padding = new Thickness(0, 0, 0, 0);
            }

            keyboardView.Visibility = ViewStates.Gone;
            keyboardView.Enabled = false;
        }

        private Xamarin.Forms.Layout FindScrollViewChild()
        {
            var element = extendedEntry.Parent;
            while (element != null && element.Parent is not Xamarin.Forms.ScrollView)
            {
                element = element.Parent;
            }

            return element as Xamarin.Forms.Layout;
        }

        private Task touchHandler = null;

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            // do nothing if the InputConnection has not been set yet
            if (inputConnection == null)
            {
                return true;
            }

            switch (e.Action)
            {
                case MotionEventActions.Down:
                    HandleTouch(v);
                    if (touchHandler != null &&
                        (
                            touchHandler.Status == TaskStatus.Running ||
                            touchHandler.Status == TaskStatus.WaitingToRun ||
                            touchHandler.Status == TaskStatus.WaitingForActivation
                        )
                    )
                    {
                        break;
                    }

                    touchHandler = Task.Run(async () =>
                    {
                        await Task.Delay(500);
                        Device.StartTimer(TimeSpan.FromSeconds(.1), () =>
                        {
                            if (!v.Pressed)
                            {
                                return false;
                            }

                            HandleTouch(v);

                            return true;
                        });
                    });
                    break;

                case MotionEventActions.Up:
                    break;

                default:
                    break;
            }

            return false;
        }

        private void HandleTouch(Android.Views.View v)
        {
            switch(v.Id)
            {
                case Resource.Id.button_delete:
                    string selectedText = inputConnection.GetSelectedText(0);
                    if (TextUtils.IsEmpty(selectedText))
                    {
                        // no selection, so delete previous character
                        inputConnection.DeleteSurroundingText(1, 0);
                    }
                    else
                    {
                        // delete the selection
                        inputConnection.CommitText("", 1);
                    }
                    break;

                case Resource.Id.button_enter:
                    HideKeyboardView();
                    break;

                case Resource.Id.button_decimal:
                    if (extendedEntry.IsInteger)
                    {
                        break;
                    }

                    var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    if (!extendedEntry.Text.Any(c => c.ToString() == separator))
                    {
                        inputConnection.CommitText(separator, 1);
                    }
                    break;

                case Resource.Id.button_negative:
                    if (extendedEntry.IsUnsigned)
                    {
                        break;
                    }

                    if (extendedEntry.Text.Length > 0)
                    {
                        if (extendedEntry.Text[0] == '-')
                        {
                            inputConnection.SetComposingRegion(0, 1);
                            inputConnection.CommitText("", extendedEntry.Text.Length);
                        }
                        else
                        {
                            inputConnection.SetComposingRegion(0, 1);
                            inputConnection.CommitText("-" + extendedEntry.Text[0], extendedEntry.Text.Length);
                        }
                        break;
                    }

                    goto default;
                default:
                    string value = keyValues[v.Id];
                    inputConnection.CommitText(value, 1);
                    break;
            }

            // Ensure native keyboard is hidden
            var imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(EditText.WindowToken, 0);
        }
    }
}