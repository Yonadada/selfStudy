using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YokiKiosk.Components
{
    public partial class HeaderControl : UserControl
    {
        public HeaderControl()
        {
            InitializeComponent();
        }

        // 사용자 정의 코드를 밖으로 공유하기 위해서는 프러퍼티를 사용해야 한다.
        public string Title { get => LblTitle.Text; set => LblTitle.Text = value; }

        // Title은 단일 줄이지만 Description은 여러 줄이므로 MultilineStringEditor를 사용한다.
        [Editor(typeof(MultilineStringEditor),typeof(UITypeEditor))]

        public string Description{ get => LblDescription.Text; set => LblDescription.Text = value; }

    }
}
