using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WPFCustomComponent.NumberUpDown.Controls
{
    public class NumberUpDown : Control
    {
        static NumberUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberUpDown),
                new FrameworkPropertyMetadata(typeof(NumberUpDown)));
        }

        #region Properties

        private RepeatButton _upButton;
        private RepeatButton _downButton;
        private TextBox _textBox;

        public int Value
        {
            get => (int) GetValue(ValueProperty);
            set
            {
                SetValue(ValueProperty, value);
                if (_textBox != null)
                    _textBox.Text = Value.ToString();
            }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(int), typeof(NumberUpDown),
                new PropertyMetadata(1));

        public int Max
        {
            get => (int) GetValue(MaxProperty);
            set
            {
                if (Value > Max)
                {
                    Value = Max;
                }

                SetValue(MaxProperty, value);
            }
        }

        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register(nameof(Max), typeof(int), typeof(NumberUpDown),
                new PropertyMetadata(default(int)));

        public int Min
        {
            get => (int) GetValue(MinProperty);
            set
            {
                if (Value < Min)
                {
                    Value = Min;
                }

                SetValue(MinProperty, value);
            }
        }

        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register(nameof(Min), typeof(int), typeof(NumberUpDown),
                new PropertyMetadata(default(int)));


        public int Step
        {
            get => (int) GetValue(StepProperty);
            set { SetValue(StepProperty, value); }
        }


        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register(nameof(Step), typeof(int), typeof(NumberUpDown),
                new PropertyMetadata(default(int)));

        #endregion


        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _textBox = (TextBox) Template.FindName("InteralBox", this);
            _upButton = (RepeatButton) Template.FindName("UpButton", this);
            _downButton = (RepeatButton) Template.FindName("DownButton", this);

            // TextBox Events
            _textBox.LostFocus += TextBoxOnLostFocus;
            _textBox.PreviewKeyDown += TextBoxOnPreviewKeyDown;
            _textBox.PreviewTextInput += TextBoxOnPreviewTextInput;
            _textBox.MouseWheel += TextBoxOnMouseWheel;

            // RepeatButton Evnets
            _upButton.Click += UpButtonOnClick;
            _downButton.Click += DownButtonOnClick;
            Value = (Value < Min) ? Min : Value;
        }

        private void DownButtonOnClick(object sender, RoutedEventArgs e)
        {
            if ((Value - 1) >= Min)
            {
                Value -= Step;
            }
        }

        private void UpButtonOnClick(object sender, RoutedEventArgs e)
        {
            if ((Value + 1) <= Max)
            {
                Value += Step;
            }
        }

        private void TextBoxOnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var textBox = (TextBox) sender;
            if (textBox == null) return;
            // 控制鼠标滚轮的影响，如果按下Shift键或者
            var step = Keyboard.Modifiers == (ModifierKeys.Shift | ModifierKeys.Control) ? 50
                : Keyboard.Modifiers == ModifierKeys.Shift ? 10
                : Keyboard.Modifiers == ModifierKeys.Control ? 5 : 1;
            // 表示增加
            if (e.Delta > 0)
            {
                if ((Value + step) <= Max)
                {
                    Value = Convert.ToInt32(textBox.Text) + step;
                }
            }

            // 表示减少
            if (e.Delta < 0)
            {
                if ((Value - step) >= Min)
                {
                    Value = Convert.ToInt32(textBox.Text) - step;
                }
            }

            e.Handled = true;
        }

        private void TextBoxOnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Text))
            {
                e.Handled = true;
                return;
            }

            if (IsInputAllowed(e.Text)) return;
            e.Handled = true;
        }

        /// <summary>
        /// 只有全数字才能匹配成功
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsInputAllowed(string input)
        {
            var regex = new Regex("[^-?0-9]+");
            return !regex.IsMatch(input);
        }

        private void TextBoxOnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
                return;

            if (e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Back || e.Key == Key.Delete)
                return;

            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }

            e.Handled = true;
        }

        private void TextBoxOnLostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox) sender;
            if (textBox == null || string.IsNullOrWhiteSpace(textBox.Text)) return;
            if (int.TryParse(textBox.Text, out int result))
            {
                Value = result;
            }
        }

        #endregion
    }
}