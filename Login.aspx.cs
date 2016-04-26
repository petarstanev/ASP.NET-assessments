using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login_form : System.Web.UI.Page
{
    ArrayList users;

    protected void Page_Load(object sender, EventArgs e)
    {
        users = new ArrayList();

        LabelBotCheck.Text = GenerateCoupon(4);
    }


    private string GenerateCoupon(int length)
    {
        Random random = new Random();
        string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        StringBuilder result = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            result.Append(characters[random.Next(characters.Length)]);
        }
        return result.ToString();
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        String username = TextBoxUsername.Text;
        String password = TextBoxPassword.Text;

        if (authenticateviaDatabase())
        {
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(TextBoxUsername.Text,false);
        }
        else
        {
            LabelFailed.Text = "Wrong username and password";
        }
    }

    private bool authenticateviaForms()
    {
        if (TextBoxUsername.Text == "user" && TextBoxPassword.Text == "pass")
            return true;
        return false;
    }

    private bool authenticateviaDatabase()
    {
        string sqlCommand = "SELECT * FROM users";
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; 

        DataSet ds = GetDataSet(connectionString,sqlCommand );

        foreach (DataTable table in ds.Tables)
        {
            foreach (DataRow row in table.Rows)
            {
                string usernameCheck = row[0].ToString();
                string passwordCheck = row[1].ToString();

                if (usernameCheck.Equals(TextBoxUsername.Text) && passwordCheck.Equals(TextBoxPassword.Text))
                    return true;
            }
        }


        return false;
    }

    public DataSet GetDataSet(string ConnectionString, string SQL)
    {
        SqlConnection conn = new SqlConnection(ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = SQL;
        da.SelectCommand = cmd;
        DataSet ds = new DataSet();

        conn.Open();
        da.Fill(ds);
        conn.Close();

        return ds;
    }


    private Boolean containUser(User user)
    {
        foreach (User testuser in users)
        {
            if (testuser.username.Equals(user.username) && testuser.password.Equals(user.password))
                return true;
        }
        return false;
    }

   
}