namespace Products_Data_View_With_EntityFramework
{
    public partial class Form1 : Form
    {
        private ProductDal productDal = new ProductDal();
        public Form1()
        {
            InitializeComponent();
        }

        //Form Y�klenir Y�klenmez ne olaca��
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            //data grid view'in data kayna�� productDalda List d�nen getAll metodudur
            dgwProducts.DataSource = productDal.getAll();
        }

        //Data Grid View'de bir h�creye t�klay�nca ne olacak
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Cells[0] Id ye denk gelir
            txtNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            txtPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            txtStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            productDal.addProduct(
                new Product()
                {
                    Name = txtName.Text,
                    Price = Convert.ToInt32(txtPrice.Text),
                    StockAmount=Convert.ToInt32(txtStockAmount.Text)
                });
            LoadProducts();
            MessageBox.Show("�r�n Eklendi");
        }

        
        //Yukar�daki ile ayn�d�r tek fark vard�r
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productDal.updateProduct(new Product()
            {
                /*Hangi kullan�c�y� de�i�tirece�imiz dgw'den al�nan �d bilgisi ile yap�l�r bu y�zden id h�crelerden al�n�p de�i�tirilmez dgw'de var olan id ile atama yap�l�r*/
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = txtNameUpdate.Text,
                Price = Convert.ToInt32(txtPriceUpdate.Text),
                StockAmount = Convert.ToInt32(txtStockAmountUpdate.Text)
            });
            LoadProducts();
            MessageBox.Show("�r�n G�ncellendi");
        }

        //Silme i�leminde sadece dgw'den gelen id ile kullan�c� bulunup silinir
        private void btnDelete_Click(object sender, EventArgs e)
        {
            productDal.deleteProduct(new Product()
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("�r�n Silindi");
        }
    }
}