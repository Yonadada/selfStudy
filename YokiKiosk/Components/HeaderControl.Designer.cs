namespace YokiKiosk.Components
{
    partial class HeaderControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            LblTitle = new Label();
            LblDescription = new Label();
            SuspendLayout();
            // 
            // LblTitle
            // 
            LblTitle.AutoSize = true;
            LblTitle.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            LblTitle.Location = new Point(14, 12);
            LblTitle.Name = "LblTitle";
            LblTitle.Size = new Size(87, 30);
            LblTitle.TabIndex = 0;
            LblTitle.Text = "LblTitle";
            // 
            // LblDescription
            // 
            LblDescription.AutoSize = true;
            LblDescription.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            LblDescription.ForeColor = Color.Gray;
            LblDescription.Location = new Point(14, 57);
            LblDescription.Name = "LblDescription";
            LblDescription.Size = new Size(116, 21);
            LblDescription.TabIndex = 0;
            LblDescription.Text = "LblDescription";
            // 
            // HeaderControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LblDescription);
            Controls.Add(LblTitle);
            Name = "HeaderControl";
            Size = new Size(485, 96);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblTitle;
        private Label LblDescription;
    }
}
