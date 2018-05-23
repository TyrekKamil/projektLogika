using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using prodzekt.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void andSymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u2227";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            var selectionIndex = textBoxFormula.SelectionStart;
            textBoxFormula.Text = textBoxFormula.Text.Insert(selectionIndex, insertText);
            textBoxFormula.SelectionStart = selectionIndex + insertText.Length;
            textBoxFormula.Focus();
        }

        private void orSymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u2228";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            var selectionIndex = textBoxFormula.SelectionStart;
            textBoxFormula.Text = textBoxFormula.Text.Insert(selectionIndex, insertText);
            textBoxFormula.SelectionStart = selectionIndex + insertText.Length;
            textBoxFormula.Focus();

        }

             private void leftImplySymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u21d0";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            var selectionIndex = textBoxFormula.SelectionStart;
            textBoxFormula.Text = textBoxFormula.Text.Insert(selectionIndex, insertText);
            textBoxFormula.SelectionStart = selectionIndex + insertText.Length;
            textBoxFormula.Focus();
        }

        private void rightImplySymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u21d2";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            var selectionIndex = textBoxFormula.SelectionStart;
            textBoxFormula.Text = textBoxFormula.Text.Insert(selectionIndex, insertText);
            textBoxFormula.SelectionStart = selectionIndex + insertText.Length;
            textBoxFormula.Focus();
        }

        private void eqSymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u21d4";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            var selectionIndex = textBoxFormula.SelectionStart;
            textBoxFormula.Text = textBoxFormula.Text.Insert(selectionIndex, insertText);
            textBoxFormula.SelectionStart = selectionIndex + insertText.Length;
            textBoxFormula.Focus();
        }

        private void negationSymbolButton_Click(object sender, RoutedEventArgs e)
        {
            string insertText = "\\u00AC";
            insertText = System.Text.RegularExpressions.Regex.Unescape(insertText);
            var selectionIndex = textBoxFormula.SelectionStart;
            textBoxFormula.Text = textBoxFormula.Text.Insert(selectionIndex, insertText);
            textBoxFormula.SelectionStart = selectionIndex + insertText.Length;
            textBoxFormula.Focus();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxFormula.Text = "";
        }

        private void textBoxFormula_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (textBoxFormula.Text == "Wpisz formułę")
            {
                textBoxFormula.Text = "";
            }
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {

            Parser parser = new Parser(textBoxFormula.Text);
            string msgtext;
            bool result = parser.checkIfValid();
            if (result)
            {
                msgtext = "Zadana formuła jest poprawna";
            }
            else
            {
                msgtext = "Zadana formuła nie jest poprawna";
            }
            MessageBox.Show(msgtext);
        }

 
    }
}
