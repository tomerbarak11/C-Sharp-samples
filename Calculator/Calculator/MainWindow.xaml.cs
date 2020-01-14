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
namespace Calculator    
{    
    public partial class MainWindow : Window    
    {    
        private int curBase;
        string ERROR_MSG="Invalid input, press AC to continue";
        public MainWindow()    
        {    
            InitializeComponent();
            curBase = 10;
        }    
    
        private void onClickDigitsAndOperations(object sender, RoutedEventArgs e)    
        {    
            Button b = (Button) sender;
            String op= b.Content.ToString();
            String []mathOps = {"+","-","*","/"};
            if (MatUtil.isInGivenBase(op, curBase) || mathOps.Contains(op))
                 tb.Text += op; 
        }
    
        private void Result_click(object sender, RoutedEventArgs e)    
        {    
            try    
            {    
                result();    
            }    
            catch (Exception exc)    
            {    
                tb.Text = ERROR_MSG;    
            }    
        }    
    
        private void result()    
        {    
            String op;    
            int iOp = 0;    
            if (tb.Text.Contains("+"))    
            {    
                iOp = tb.Text.IndexOf("+");    
            }    
            else if (tb.Text.Contains("-"))    
            {    
                iOp = tb.Text.IndexOf("-");    
            }    
            else if (tb.Text.Contains("*"))    
            {    
                iOp = tb.Text.IndexOf("*");    
            }    
            else if (tb.Text.Contains("/"))    
            {    
                iOp = tb.Text.IndexOf("/");    
            }    
                
            op = tb.Text.Substring(iOp, 1);

            string firstNum = tb.Text.Substring(0, iOp);
            string secNum = tb.Text.Substring(iOp + 1, tb.Text.Length - iOp - 1);
            double op1 = Convert.ToDouble((Convert.ToInt32(firstNum, this.curBase)));
            double op2 = Convert.ToDouble((Convert.ToInt32(secNum, this.curBase)));
            double res;
            if (op == "+")    
            {
                res = op1 + op2;
            }    
            else if (op == "-")    
            {
                res = op1 - op2;
            }    
            else if (op == "*")
            {
                res = op1 * op2;
            }    
            else
            {
                res = op1 / op2;
            }
            if(curBase==16)
            {
                tb.Text=MatUtil.DoubleToHex(res);
            }
            else if(curBase==10)
            {
                tb.Text = res.ToString("F2");
            }
            else
            {
                tb.Text = Convert.ToString(Convert.ToInt32(res),curBase);
            }
        }

        private void ShutdownCalc(object sender, RoutedEventArgs e)    
        {    
            Application.Current.Shutdown();    
        }

        private void onXClick(object sender, RoutedEventArgs e)    
        {    
            tb.Text = "";    
        }    
    
        private void onClearClick(object sender, RoutedEventArgs e)    
        {    
            if (tb.Text.Length > 0)
            {    
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1);    
            }    
        }

        private void onClickBinary(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (tb.Text != "" && MatUtil.isInGivenBase(tb.Text, curBase))
            {
                if (curBase == 10)
                    tb.Text = Convert.ToString(Convert.ToInt32(tb.Text, 10), 2);

                else if (curBase == 16)
                    tb.Text = Convert.ToString(Convert.ToInt32(tb.Text, 16), 2);
            }
            else
              tb.Text = "";
            curBase = 2;
        }

        private void onClickDec(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (tb.Text != "" && MatUtil.isInGivenBase(tb.Text, curBase))
            {
                if (curBase == 2)
                    tb.Text = Convert.ToString(Convert.ToInt32(tb.Text, 2), 10);

                else if (curBase == 16)
                    tb.Text = Convert.ToString(Convert.ToInt32(tb.Text, 16), 10);
            }
            else
                tb.Text = "";
            curBase = 10;
        }

        private void onClickHex(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (tb.Text != "" && MatUtil.isInGivenBase(tb.Text, curBase))
            {
                if (curBase == 2)
                    tb.Text = Convert.ToString(Convert.ToInt32(tb.Text, 2), 16).ToUpper();

                else if (curBase == 10)
                    tb.Text = Convert.ToString(Convert.ToInt32(tb.Text, 10), 16).ToUpper();
            }
            else
                tb.Text = "";
            curBase = 16;
        }    

    }    
}    