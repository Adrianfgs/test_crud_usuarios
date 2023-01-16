namespace Crud_de_Usuarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            loadform(new home());
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0); 
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock= DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag= f;
            f.Show();




        }




    }
}