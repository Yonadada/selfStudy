namespace YokiKiosk
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void productCard1_Clicked(object sender, YokiKiosk.Components.Products.IProductCard e)
        {
            MessageBox.Show($"{e.Title}, {e.Price}");
        }
    }
}
