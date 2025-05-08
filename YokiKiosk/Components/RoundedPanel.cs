using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaburiKiosk.Utils;

namespace YokiKiosk.Components
{
    public class RoundedPanel : Panel
    {
        private int _borderWidth = 2;
        private int _borderRadius = 8;
        private Color _borderColor = Color.Black;
		private Color _innerBackgroundColor = Color.White;

        //렌더링 form 사이즈 변경시 깨짐 문제 해결 
        public RoundedPanel()
        {
            Resize += RoundedPanel_Resize; // 패널 크기 조정 시 이벤트 핸들러 등록
                                           // 
        }
        private void RoundedPanel_Resize(object? sender, EventArgs e)
        {
            Invalidate();// invalidate() 메서드는 패널을 다시 그리도록 요청하는 메서드입니다. 
                         // 즉, 패널의 크기가 변경될 때마다 다시 그려지도록 합니다.
        }




        // 속성들의 기본값을 설정하기 위해 DefaultValueAttribute를 사용
        [DefaultValue(2), Category("커스텀"), Description("보더 두께를 변경합니다")] //1. borderWidth의 기본값을 2로 설정

        //1. borderWidth는 패널의 테두리 두께를 설정하는 속성

        public int BorderWidth
		{
			get { return _borderWidth; }
			set 
            { _borderWidth = value;
                Invalidate();
            }
		}

		[DefaultValue(8), Category("커스텀"), Description("보더 둥글기를 변경합니다") ]
        //2. borderRadius는 패널의 모서리 둥글기를 설정하는 속성

		public int BorderRadius
        {
			get { return _borderRadius; }
            set
            { _borderRadius = value;
                Invalidate();
            }
		}

		[DefaultValue(typeof(Color), "Black"), Category("커스텀"), Description("보더 색상을 변경합니다")]
        //3. borderColor는 패널의 테두리 색상을 설정하는 속성

        public Color BorderColor
        {
			get { return _borderColor; }
			set
            { _borderColor = value;
                Invalidate();
            }
		}

		[DefaultValue(typeof(Color), "White"), Category("커스텀"), Description("보더 내부 색상을 변경합니다")]
        //4. innerBackgroundColor는 패널의 내부 배경 색상을 설정하는 속성

        public Color InnerBackgroundColor
        {
			get { return _innerBackgroundColor; }
			set
            { _innerBackgroundColor = value;
                Invalidate();
            }
		}

        // border 그리기
        //OnPaint 메서드는 패널이 그려질 때 호출되는 메서드로, 이곳에서 패널의 모양을 정의한다.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // 원래의 기본 그리기 동작을 유지

            // e.Graphics: 이 이벤트에서 제공하는 Graphics 객체입니다. 그림을 그릴 수 있는 도화지라고 보면 돼요.
            Graphics graphics = e.Graphics; // SmoothingMode.HighQuality: 선을 매끄럽게(안티 앨리어싱) 그린다 -> 모서리가 덜 깨져 보여요.   
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
          
            // 패널(테두리를 그릴 사격형의 위치, 크기) 경계 계산
            Rectangle rect = new Rectangle(
                _borderWidth, _borderWidth, 
                Width - _borderWidth * 2, 
                Height - _borderWidth * 2 
                );

            //graphics.DrawRectangle(new Pen(_borderColor, _borderWidth),rect); // 테두리 경계 확인 
            
            // 모서리가 둥근 패널(사각형을 그릴 준비)
            GraphicsPath path =  GraphicsUtil.GetRoundedRectanglePath(rect, _borderRadius);


            // ** using 문
            // c#에 나오는  using은 이 안에서만 잠깐 쓰고 자동으로 정리해줘라는 의미
            // using 필요한 이유?
            // => 1. 메모리 관리
            // SolidBrush와 Pen은 그림을 그리는 도구, 정리를 반드시 해줘야 한다 => 메모리 누수 방지
            
            // 패널 내부 영역 채우기 -> 패널 안쪽
            using (SolidBrush innerBrush = new SolidBrush(_innerBackgroundColor))
            {
                graphics.FillPath(innerBrush, path); // 패널 내부를 채운다.
            }

            // 보더 그리기 -> 페널 테두리
            using (Pen borderPen = new Pen(_borderColor, _borderWidth))
            {
                graphics.DrawPath(borderPen, path); // 패널 테두리를 그린다.
            }
        }
    }
}
