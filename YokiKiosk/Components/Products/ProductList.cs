using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;// ObservableCollection을 사용하려고 가져옴
using System.Collections.Specialized;// CollectionChanged 이벤트를 쓰기 위해 필요
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YokiKiosk.Models;

namespace YokiKiosk.Components.Products
{
    public partial class ProductList : UserControl
    {
        // 상품 클릭 이벤트 추가
        public event EventHandler<Product>? ItemClicked; 

        public ProductList()
        {
            InitializeComponent();

            // Items라는 상품 목록이 바뀌면 (예: 상품 추가/삭제) 아래 함수를 실행하라고 연결해요
            // Collectionchanged  이벤트는 ObservableCollection 이벤트 중 1개
            Items.CollectionChanged += Items_CollectionChanged;
        }
        
        // 상품 목록이 바뀌면 실행되는 함수
        private void Items_CollectionChanged(object? sender, 
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {   
            flpnl.Controls.Clear(); // 상품 목록을 비움
            // Items 안에 들어있는 모든 상품 하나하나를 꺼내서
            foreach (var item in Items)
            {    // 상품 하나에 대한 ProductCard를 새로 만든다
                var productCard = new ProductCard
                {
                    ID = item.ID,
                    Title = item.Title,
                    Price = item.Price,
                    Image = item.Image!,
                };
                productCard.Clicked += ProductCard_Clicked; // 클릭 이벤트 연결
                flpnl.Controls.Add(productCard);
            }
        }

        private void ProductCard_Clicked(object? sender, IProductCard e)
        {
            ItemClicked?.Invoke(this, e.ToProduct());
        }

        // 디자이너(UI 편집기)에서 이 속성의 내부 내용을 저장할 수 있도록 설정함
        // 즉, Items 속성 자체가 아니라 그 안의 Product 항목들까지 직렬화되게 함 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        // ObservableCollection은 List와 비슷하지만,
        // UI와 연동되는 컬렉션으로, 변경 사항이 자동으로 UI에 반영됨
        public ObservableCollection<Product> Items { get; set; } = [];// 처음엔 비어 있는 목록으로 시작
    }
}
