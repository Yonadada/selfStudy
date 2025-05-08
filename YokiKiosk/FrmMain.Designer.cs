namespace YokiKiosk
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Models.Product product1 = new Models.Product();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            Models.Product product2 = new Models.Product();
            Models.Product product3 = new Models.Product();
            Models.Product product4 = new Models.Product();
            Models.Product product5 = new Models.Product();
            headerControl1 = new YokiKiosk.Components.HeaderControl();
            productList1 = new YokiKiosk.Components.Products.ProductList();
            SuspendLayout();
            // 
            // headerControl1
            // 
            headerControl1.Description = "저희 음식점은 국내산만 사용합니다.\r\n누구나 즐길 수 있는 합리적인 가격으로 모시겠습니다.";
            headerControl1.Dock = DockStyle.Top;
            headerControl1.Location = new Point(0, 0);
            headerControl1.Name = "headerControl1";
            headerControl1.Size = new Size(956, 150);
            headerControl1.TabIndex = 0;
            headerControl1.Title = "요키네 음식점에 오신 것을 환영합니다";
            // 
            // productList1
            // 
            product1.ID = 1;
            product1.Image = (Image)resources.GetObject("product1.Image");
            product1.Price = new decimal(new int[] { 2000, 0, 0, 0 });
            product1.Title = "사과";
            product2.ID = 2;
            product2.Image = (Image)resources.GetObject("product2.Image");
            product2.Price = new decimal(new int[] { 23000, 0, 0, 0 });
            product2.Title = "치킨";
            product3.ID = 3;
            product3.Image = (Image)resources.GetObject("product3.Image");
            product3.Price = new decimal(new int[] { 2500, 0, 0, 0 });
            product3.Title = "초코칩";
            product4.ID = 4;
            product4.Image = (Image)resources.GetObject("product4.Image");
            product4.Price = new decimal(new int[] { 6400, 0, 0, 0 });
            product4.Title = "햄버거";
            product5.ID = 5;
            product5.Image = (Image)resources.GetObject("product5.Image");
            product5.Price = new decimal(new int[] { 5400, 0, 0, 0 });
            product5.Title = "아이스크림";
            productList1.Items.Add(product1);
            productList1.Items.Add(product2);
            productList1.Items.Add(product3);
            productList1.Items.Add(product4);
            productList1.Items.Add(product5);
            productList1.Location = new Point(12, 156);
            productList1.Name = "productList1";
            productList1.Size = new Size(540, 307);
            productList1.TabIndex = 2;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 580);
            Controls.Add(headerControl1);
            Controls.Add(productList1);
            Name = "FrmMain";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Components.HeaderControl headerControl1;
        private Components.Products.ProductList productList1;
    }
}
