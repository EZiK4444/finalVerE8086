using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace e8086
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AXi_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int hexNumber;
            e.Handled = !int.TryParse(e.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out hexNumber);
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (OperationType.SelectedItem == MOVo)
            {
                TextBox sourceTextBox = getSourceTextBox();

                if (sourceTextBox.Text.Length == 4)
                {
                    TextBox destTextBox = getDestTextBox();

                    destTextBox.Text = sourceTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Input must be 4 characters.");
                }

            }
            else
            {
                if (SourceObj.SelectedIndex != DestObj.SelectedIndex)
                {
                    TextBox sourceTextBox = getSourceTextBoxCHG();

                    TextBox destTextBox = getDestTextBox();

                    var tmp = destTextBox.Text;
                    destTextBox.Text = sourceTextBox.Text;
                    sourceTextBox.Text = tmp;
                }
                else
                {
                    MessageBox.Show("Source and destination cannot be equal.");
                }
            }
        }

        private TextBox getDestTextBox()
        {
            var destCombobox = DestObj.SelectedValue.ToString();
            var destComboboxValue = destCombobox.Split(":")[1].Trim() + "o";
            var destTextBox = (TextBox)this.FindName(destComboboxValue);
            return destTextBox;
        }

        private TextBox getSourceTextBox()
        {
            var sourceCombobox = SourceObj.SelectedValue.ToString();
            var sourceComboboxValue = sourceCombobox.Split(":")[1].Trim() + "i";
            var sourceTextBox = (TextBox)this.FindName(sourceComboboxValue);
            return sourceTextBox;
        }

        private TextBox getSourceTextBoxCHG()
        {
            var sourceCombobox = SourceObj.SelectedValue.ToString();
            var sourceComboboxValue = sourceCombobox.Split(":")[1].Trim() + "o";
            var sourceTextBox = (TextBox)this.FindName(sourceComboboxValue);
            return sourceTextBox;
        }
    }

}