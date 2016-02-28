using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CalculatorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Calculate_Click(object sender, EventArgs e)
    {
        double a = 0, b=0;

        Calculator MyCalc = new Calculator();
        try
        {
            a = System.Convert.ToDouble(txt_num1.Text);
            b = System.Convert.ToDouble(txt_num2.Text);
            if (rad_operations.SelectedItem.Value == "add")
            {
                lbl_operand.Text = "+";
                lbl_result.Text = MyCalc.Add(a, b).ToString();
            }
            else if (rad_operations.SelectedItem.Value == "subtract")
            {
                lbl_operand.Text = "-";
                lbl_result.Text = MyCalc.Subtract(a, b).ToString();
            }
            else if (rad_operations.SelectedItem.Value == "multiply")
            {
                lbl_operand.Text = "*";
                lbl_result.Text = MyCalc.Multiply(a, b).ToString();
            }
            else if (rad_operations.SelectedItem.Value == "division")
            {
                lbl_operand.Text = "/";
                lbl_result.Text = MyCalc.Divison(a, b).ToString();
            }
        }
        catch {
            lbl_result.Text = "Error";
        }
    }
}