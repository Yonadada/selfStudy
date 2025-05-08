using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YokiKiosk.Models;

namespace YokiKiosk.Components.Products
{
    //
    public interface IProductCard
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Image Image { get; set; }
        // Clicked라는 이벤트 추가
        event EventHandler<IProductCard> Clicked;

        public Product ToProduct()
        {
           return new Product
            {
                ID = ID,
                Title = Title,
                Price = Price,
                Image = Image
            };
        }
    }

    [DefaultEvent("Clicked")] // 이 컨트롤을 클릭했을 때 발생하는 이벤트를 기본으로 설정
    // IProductCard 인터페이스 구현 Ctrl + . (dot) 누르면 자동으로 구현됨
    public partial class ProductCard : UserControl, IProductCard
    {
        // [1] 필드 - 데이터를 저장하는 변수(부품) -> 단순 데이터 저장용
        private decimal _price;

        //[2] 생성자 - 클래스를 처음 만들 때 자동으로 실행되는 "조립 설명서"
        public ProductCard()
        {
            InitializeComponent();
            AddClickEvent(this); // 클릭 이벤트 추가
        }

        // [3] 메서드 - 어떤 일을 하는 "기능"
        private void AddClickEvent(Control parentControl)
        {
            //지금 parentControl 안에 있는 모든 자식 컨트롤을 하나씩 꺼내서 작업하려는 거야
            //예: 그림, 텍스트, 버튼 등
            foreach (Control control in parentControl.Controls)
            {
                // "이 컨트롤을 누르면 Clicked 이벤트 발생"이라는 작업을 하려는 거야
                //(_,__) 는 이벤트에서 받은 값은 안쓸거니까 이름 생략할게요 라는 뜻
                // Clicked?.Invoke(this, this);는 Clicked 이벤트가 비어있지 않다면
                    // this(지금 이 ProductCard)를 누가 클릭했는지 알려주는 신호로 보냄 
                control.Click += (_,__) => Clicked?.Invoke(this, this); // 클릭 이벤트 발생
                
                if (control.HasChildren) //이 컨트롤 안에 또 다른 자식 컨트롤이 있다면 (예: 그룹박스 안에 텍스트박스가 또 있음)
                {
                    AddClickEvent(control); //  다시 자기 자신을 호출해서 그 안에 있는 컨트롤들에도 클릭 이벤트를 추가 => 재귀호출
                }

            }
        }

        // [4] 프로퍼티 - 외부에서 값을 읽고 쓰는 "조절 창" -> (UI와 연결된 로직)
        public int ID { get; set; }
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value.Trim(); }
        public decimal Price 
        { 
           
            get => _price; set 
            {
                _price = value;
                SetPrice(); // 메서드 호출 // 가격을 설정하면 화면에 표시도 바꿔줘
            }

        }
        public Image Image { get => picBox.Image; set => picBox.Image = value; }

        // Lblprice에서 3자리마다 콤마를 찍어주는 메서드, 마지막 원을 붙여주는 메서드
        // ? 은 c#에서 nullable을 의미함, Clicked가 null이 아니면 실행, null이면 무시
        public event EventHandler<IProductCard>? Clicked;

        // [5] 이벤트 - 클릭되면 바깥에 "알림" 보내는 장치
        private void SetPrice()
        {
            //   lblPrice.Text = _price.ToString("0,000") + "원"; // 1. 기존 코드 
            lblPrice.Text = $"{_price:#,000}원"; // 2. 변경 코드 -> 보관된 문자열로 변경(코드 단순화) 

        }
    }
}
