using System;
using System.Collections.Generic;
using System.ComponentModel;        // Attribute 사용을 위해
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;   // [DllImport("shlwapi.dll")] 사용을 위해


/// <summary>
/// 그림자를 그리고, 버튼 종류별 그리는 메서드를 호출하면, 모서리를 그리고(네온 버튼 제외), 버튼의 윗면을 그린다.
/// </summary>

namespace CustomControls_dll
{
    [DefaultEvent("Click")]
    public class ShadowPanel : Panel, IShadowBtn
    {
        #region 멤버
        private PanelGradientMode mBackgroundGradientMode = PanelGradientMode.Vertical;       // "배경 그라데이션 타입(대각선, 가로방향,세로방향)   "
        private int mRectRadius = 20;                               // "모서리의 둥근 반지름                              "
        private Color mStartColor = Color.FromArgb(232, 238, 249);      // "그라데이션 시작 색                                "
        private Color mEndColor = Color.FromArgb(168, 192, 234);    // "그라데이션 끝 색                                  "
        private BevelStyle mStyle = BevelStyle.Flat;                  // "버튼 모서리(경사면) 스타일 (함몰, 솟음, 평평)     "
        private int mEdgeWidth = 2;                                // "모서리의 너비                                     "
        private Color mFlatBorderColor = Color.FromArgb(102, 102, 102);    // "Flat일 경우, 테두리 색                            "
        private ShadowMode mShadowStyle = ShadowMode.ForwardDiagonal;       // "그림자 스타일 (대각, 둘러싼, 아래)                "
        private int mShadowShift = 0;                                // "그림자 평행이동 거리                              "
        private Color mShadowColor = Color.DimGray;                    // "그림자 색                                         "


        private float mFocusScaleWidth = 0.95f;
        private float mFocusScaleHeight = 0.85f;
        private Color mTextColor = Color.FromArgb(58, 32, 51);

        private const int decreaseShadowWidthHeight = 10;    // 그림자의 너비, 높이 감소. (기본값 10) -로 하면, 그림자의 너비,높이가 늘어남
        private Color mStartEdgeColor;
        private Color mEndEdgeColor;
        private Color mNeonColor = Color.Pink;
        private string mTextStr = string.Empty;

        private bool isLeftMouseButtonDown = false; // 버튼 클릭 이벤트에 사용할 flag
        private bool isMouseHover = false;


        #endregion 멤버 끝

        #region 속성들
        [Browsable(true), Category("Shadow Panel"), Description("배경 그라데이션 타입(대각선, 가로방향,세로방향)")]
        public PanelGradientMode BackgroundGradientMode { get { return mBackgroundGradientMode; } set { mBackgroundGradientMode = value; Invalidate(); } }
        [Browsable(true), Category("Shadow Panel"), Description("모서리의 둥근 반지름")]
        public int RectRadius { get { return mRectRadius; } set { mRectRadius = value; Invalidate(); } }
        [Browsable(true), Category("Shadow Panel"), Description("그라데이션 시작 색")]
        public Color StartColor { get { return mStartColor; } set { mStartColor = value; Invalidate(); } }
        [Browsable(true), Category("Shadow Panel"), Description("그라데이션 끝 색")]
        public Color EndColor { get { return mEndColor; } set { mEndColor = value; Invalidate(); } }
        [Browsable(true), Category("Shadow Panel"), Description("모서리의 너비. 네온: 5가 적당")]
        public int EdgeWidth { get { return mEdgeWidth; } set { mEdgeWidth = value; Invalidate(); } }
        [Browsable(true), Category("Shadow Panel"), Description("Flat일 경우, 테두리 색")]
        public Color FlatBorderColor { get { return mFlatBorderColor; } set { mFlatBorderColor = value; Invalidate(); } }
        [Browsable(true), Category("Shadow Panel"), Description("그림자 스타일 (대각, 둘러싼, 아래). 네온:둘러싼이 적당.")]
        public ShadowMode ShadowStyle { get { return mShadowStyle; } set { mShadowStyle = value; Invalidate(); } }
        [Browsable(true), Category("Shadow Panel"), Description("그림자 평행이동 거리. 네온:20이 적당.")]
        public int ShadowShift { get { return mShadowShift; } set { mShadowShift = value; Invalidate(); } }
        [Browsable(true), Category("Shadow Panel"), Description("그림자 색")]
        public Color ShadowColor { get { return mShadowColor; } set { mShadowColor = value; Invalidate(); } }

        [Browsable(true), Category("Shadow Panel"), Description("그림자 그라데이션 고정색 가로 비율. 네온: 0.77f, 일반: 0.95f")]
        public float FocusScaleWidth { get => mFocusScaleWidth; set { mFocusScaleWidth = value > 1f ? 1f : value < 0f ? 0f : value; Invalidate(); } }      // 0f ~ 1f사이
        [Browsable(true), Category("Shadow Panel"), Description("그림자 그라데이션 고정색 세로 비율. 네온: 0.65f, 일반: 0.85f")]
        public float FocusScaleHeight { get => mFocusScaleHeight; set { mFocusScaleHeight = value > 1f ? 1f : value < 0f ? 0f : value; Invalidate(); } }   // 0f ~ 1f사이
        [Browsable(true), Category("Shadow Panel"), Description("텍스트 글자색")]
        public Color TextColor { get => mTextColor; set { mTextColor = value; Invalidate(); } }   // 0f ~ 1f사이
        [Browsable(true), Category("Shadow Panel"), Description("텍스트 글자")]
        public string TextString { get => mTextStr; set { mTextStr = value; Invalidate(); } }   // 0f ~ 1f사이


        [Browsable(true), Category("Shadow Panel"), Description("버튼 모서리(경사면) 스타일 (함몰, 솟음, 평평, 네온)")]
        public BevelStyle Style
        {
            get { return mStyle; }
            set
            {
                mStyle = value;
                // 네온 설정일 경우, 네온 효과를 위해서 FocusScale등 몇몇 초기 설정을 바꿈.
                //if (value == BevelStyle.Neon || value == BevelStyle.GradientNeon)  // 네온으로 설정했을 때, 멤버 변수의 설정을 변경
                //{
                //    mEdgeWidth = 5;
                //    mFocusScaleWidth = 0.77f;
                //    mFocusScaleHeight = 0.65f;
                //    mRectRadius = 20;
                //    mShadowShift = 20;
                //    mShadowStyle = ShadowMode.Surrounded;
                //}
                //else
                //{
                //    mEdgeWidth = 3;
                //    mFocusScaleWidth = 0.95f;
                //    mFocusScaleHeight = 0.85f;
                //    mRectRadius = 20;
                //    mShadowShift = 10;
                //    mShadowStyle = ShadowMode.ForwardDiagonal;
                //}
                Invalidate();
            }
        }

        // 네온 버튼의 색을 지정하면, 그에 맞는 그라데이션 색 들을 자동으로 색에 맞게 설정한다.
        // 나중에 지정하도록 바꿀 듯하다. 클릭했을 때의 색도 
        [Browsable(true), Category("Shadow Panel"), Description("네온 버튼의 색 지정")]
        public Color NeonColor
        {
            get => mNeonColor;
            set
            {
                mNeonColor = value;
                Invalidate();
            }
        }

        #endregion 속성들. 끝

        #region 생성자
        public ShadowPanel()
        {
            SetShadowPanelFormStyle();
        }


        private void SetShadowPanelFormStyle()
        {
            this.Size = new Size(200, 50);
            //            this.Paint += this.Button_Paint;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);    // 화면에 직접 그리지 않고, 먼저 버퍼에 그리므로, 깜빡이가 줄어 듦.
            SetStyle(ControlStyles.UserPaint, true);                // 운영체제에서 컨트롤을 그리지 않고, 자체에서 컨트롤을 그림
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);     // WM_ERASEBKGND 메시지 무시
            SetStyle(ControlStyles.ResizeRedraw, true);             // 크기가 변하면 자동으로 다시 그림
            SetStyle(ControlStyles.Selectable, true);               // 컨트롤이 포커스를 받을 수 있음.
            SetStyle(ControlStyles.SupportsTransparentBackColor, true); // 알파 구성요소가 255미만인 Control.BackColor를 수락. 버튼의 배경색에 TransParent색을 넣을 수 있음
        }

        public void SetPanelInit()
        {
            if (mStyle == BevelStyle.Neon || mStyle == BevelStyle.GradientNeon)  // 네온으로 설정했을 때, 멤버 변수의 설정을 변경
            {
                mEdgeWidth = 5;
                mFocusScaleWidth = 0.77f;
                mFocusScaleHeight = 0.65f;
                mRectRadius = 20;
                mShadowShift = 20;
                mShadowStyle = ShadowMode.Surrounded;
            }
            else
            {
                mEdgeWidth = 3;
                mFocusScaleWidth = 0.95f;
                mFocusScaleHeight = 0.85f;
                mRectRadius = 20;
                mShadowShift = 10;
                mShadowStyle = ShadowMode.ForwardDiagonal;
            }
        }

        #endregion 생성자. 끝.

        #region protected override

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button != MouseButtons.Left) return;
            isLeftMouseButtonDown = false;
            this.Refresh();

        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            isLeftMouseButtonDown = true;
            this.Refresh();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isMouseHover = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isLeftMouseButtonDown = false;
            isMouseHover = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            base.OnPaintBackground(e);
            PaintShadowPanel(e.Graphics);
        }

        #endregion protected override

        #region 메인 Paint 메서드 (그림자를 그리고, 버튼 종류별 그리는 메서드를 호출하면, 모서리를 그리고(네온 버튼 제외), 버튼의 윗면을 그린다.)
        // 버튼을 그림 (그림자를 그리고, 버튼의 영역을 얻어온 후 그림)
        private void PaintShadowPanel(Graphics g)
        {
            Rectangle bevelRect = new Rectangle();

            // 밑바탕에 그림자를 먼저 그림
            if (mShadowShift > 0)    // 그림자 위치가 버튼의 위치와 다르면, 그림자를 그림.
                DrawShadow(g);

            // 그림자 위에, 경사면을 포함한 사각형을 그림
            int bevelX = 0;
            int bevelY = 0;
            int bevelWidth = 0;
            int bevelHeight = 0;
            switch (mShadowStyle)
            {
                // 그림자 스타일에 따라, 사각형의 위치와 크기를 조절.
                case ShadowMode.ForwardDiagonal:
                    bevelWidth = Width - mShadowShift - 1;    // 그림자의 이동 위치만큼 버튼을 작게 축소후, 버튼의 곡선이 짤리지 않게 -1 더 빼 줌
                    bevelHeight = Height - mShadowShift - 1;  // 그림자의 이동 위치만큼 버튼을 작게 축소후, 버튼의 곡선이 짤리지 않게 -1 더 빼 줌
                    bevelRect = new Rectangle(0, 0, bevelWidth, bevelHeight);
                    break;
                case ShadowMode.Surrounded:
                    bevelX = mShadowShift;               // 왼쪽 위로 그림자가 그려져 있고, 버튼을 그림자 평행이동만큼 오른쪽으로 옮김
                    bevelY = (Style == BevelStyle.Neon || Style == BevelStyle.GradientNeon) ? mShadowShift : mShadowShift + mEdgeWidth;  // Neon버튼일 경우, 버튼을 더 아래로 내려서 그리진 않음.
                    //bevelY = mShadowShift + mEdgeWidth;  // 왼쪽 위로 그림자라 그려져 잇고, 버튼을 그림자 평행이동만큼 아래로 옮김. 버튼의 모서리 길이만큼 더 내림(굳이 안 해도 될 것 같긴 하지만)
                    bevelWidth = Width - (2 * mShadowShift) - 1;    // 그림자 이동 거리의 두배만큼 너비 축소
                    bevelHeight = Height - (2 * mShadowShift) - 1;  // 그림자 이동 거리의 두배만큼 높이 축소
                    bevelRect = new Rectangle(bevelX, bevelY, bevelWidth, bevelHeight);
                    break;
                case ShadowMode.Dropped:
                    bevelWidth = Width - 1;                             // 그림자를 평행이동 했다고, 너비가 줄어들지 않음.
                    bevelHeight = Height - (2 * mShadowShift) - 1;     // 그림자를 평행이동 한 만큼*2배, 높이를 줄임// 
                    bevelRect = new Rectangle(0, 0, bevelWidth, bevelHeight);
                    break;
            }

            // 베블과 베벨을 제외한 영역을 그림.(베블 영역을 전달하면, 베블영역과 베블영역을 제외한 윗 사각형 영역, 이렇게 두 개 그림)
            // 그림자를 그릴 땐, 그림자 스타일에 따라그리지만,
            // 버튼을 그릴 땐, 버튼의 스타일에 따라 그림.
            // 그림자를 그렸으므로, 버튼을 그림.
            switch (Style)
            {
                case BevelStyle.Lowered:
                    if (isLeftMouseButtonDown) DrawRaisedPn(g, bevelRect); else DrawLoweredPn(g, bevelRect);
                    break;
                case BevelStyle.Raised:
                    if (isLeftMouseButtonDown) DrawLoweredPn(g, bevelRect); else DrawRaisedPn(g, bevelRect);
                    break;
                case BevelStyle.Flat:
                    if (isLeftMouseButtonDown)
                    {
                        Color oldColor = mStartColor;
                        mStartColor = mEndColor;
                        mEndColor = oldColor;
                        DrawFlatPn(g, bevelRect);
                        mEndColor = mStartColor;
                        mStartColor = oldColor;
                    }
                    else
                        DrawFlatPn(g, bevelRect);

                    break;
                case BevelStyle.Neon:
                case BevelStyle.GradientNeon:
                    DrawNeonPn(g, bevelRect);
                    break;
            }


            // 버튼에 표시할 Text 중앙 정렬
            StringFormat sf = new StringFormat()
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center,
            };

            // 버튼의 글자를 그림
            g.DrawString(this.mTextStr,
                new Font(this.Font.Name, this.Font.Size), new SolidBrush(mTextColor),
                new Rectangle(bevelRect.X, bevelRect.Y, bevelRect.Width + 2, bevelRect.Height + 4),
                sf);

        }
        #endregion 메인 Paint 메서드. 끝.

        #region 그림자 그리는 메서드
        private void DrawShadow(Graphics g)
        {
            Rectangle shadowRect = new Rectangle();
            GraphicsPath shadowPath;
            switch (mShadowStyle)
            {
                // 둥근 사각형 Path에 전달할 사각 영역(둥글기 전 영역)
                case ShadowMode.ForwardDiagonal:
                    // 그림자의 크기를 버튼의 크기보다 20만큼 줄이고,(x,y 10씩 이동, width,height 10씩 감소) 그림자 평행 이동 길이*2만큼 줄임.
                    shadowRect = new Rectangle(mShadowShift + decreaseShadowWidthHeight, mShadowShift + decreaseShadowWidthHeight,
                        Width - mShadowShift - decreaseShadowWidthHeight, Height - mShadowShift - decreaseShadowWidthHeight);
                    break;
                case ShadowMode.Surrounded:
                    // 둘러싸는 그림자의 경우, 버튼의 최대 크기
                    shadowRect = new Rectangle(0, 0, Width, Height);
                    break;
                case ShadowMode.Dropped:
                    // 아래쪽 그림자의 경우, 그림자 평행이동 길이*2만큼 그림자의 폭을 줄임.(평행이동한 만큼 멀다는 뜻이므로) -2줄인 건 아래쪽 그림자 너비의 기본값인듯.
                    shadowRect = new Rectangle(mShadowShift, 0, Width - 2 * mShadowShift, Height);
                    break;
            }

            // 둥근 모서리 그림자 영역을 얻음
            shadowPath = RoundedRectangle.GetRoundedRectanglePath(shadowRect, mRectRadius, mShadowStyle == ShadowMode.Dropped ? true : false);

            // GraphicsPath개체를 그림
            using (PathGradientBrush shadowBrush = new PathGradientBrush(shadowPath)) // 주위 점들(path개체)을 PathGradientBrush에 전달해서 패스 그라데이션 브러시 생성
            {
                if (Style == BevelStyle.Neon || Style == BevelStyle.GradientNeon) shadowBrush.Blend = GetNeonBlend(shadowRect);
                // 진하게 표시될 영역(위치) 설정
                shadowBrush.CenterPoint = new PointF(shadowRect.Width / 2, shadowRect.Height / 2);  // 이 영역은 나중에 .FocusScales에서 0.95f, 0.85f로 확대됨.
                // Neon버튼이 아닐 경우, 일반 그림자 색으로 칠하고, Neon일 경우, 클릭했을 때의 색으로 그림자 색을 바꾼다.
                Color shadowColor = (Style != BevelStyle.Neon && Style != BevelStyle.GradientNeon) ? mShadowColor : isLeftMouseButtonDown ? ControlPaint.Light(ControlPaint.LightLight(mStartColor)) : isMouseHover ? ControlPaint.Light(mStartColor) : mStartColor;
                // 클릭했을 때, 색이 변하지 않게 하려면,
                // Color shadowColor = mShadowColor;
                shadowBrush.CenterColor = shadowColor;
                // 그라데이션은 패스의 끝점의 SurroundColors에서 CenterPoint의 CenterColor로 진행되는데, CenterPoint의 가로,세로 크기를 지정한다.
                // 이걸 지정하지 않으면, CenterPoint와의 거리가 너무 멀어, 그림자그라데이션이 진행되지 않으므로, 포커스를 최대한 키워서 그림자의 그라데이션을 표현한다.
                shadowBrush.FocusScales = new PointF(mFocusScaleWidth, mFocusScaleHeight);
                Color[] endColor = { Color.Transparent };   // 그림자의 중심과 섞일 끝 컬러(투명색)
                shadowBrush.SurroundColors = endColor;  // EndColor는 투명색     // 컬러 배열이지만, 한 색만 담음
                g.FillPath(shadowBrush, shadowPath);              // 그림자는 AntiAlias없는 듯
            }
        }
        #endregion 그림자 그리는 메서드. 끝.

        #region 네온 버튼의 그림자를 번지게 그리는 혼합 비율을 설정하는 메서드
        public Blend GetNeonBlend(Rectangle rectWithShadow) // 확장성을 위해, Lowered와 Raised도 일단 넣어 두었다.
        {
            Rectangle lgbRect = rectWithShadow;
            lgbRect.Inflate(1, 1);  // LinearGradientBrush 생성에 쓰일 lgbRect의 크기를 좌,우로 1씩 확대

            // Blend생성
            Blend rectWithShadowBlend = new Blend();
            if (mRectRadius >= 150)  // 모서리의 반경이 아주 크면, 좀 더 세분해서 그라데이션
            {
                rectWithShadowBlend.Positions = new float[] { 0.0f, .2f, .4f, .6f, .8f, 1.0f };
                rectWithShadowBlend.Factors = new float[] { 0f, 0f, .2f, .4f, 1f, 1f };   // 끝 점의 섞이는 비율
            }
            else
            {
                switch (Style)
                {
                    case BevelStyle.Lowered:
                        rectWithShadowBlend.Positions = new float[] { 0f, .49f, .52f, 1f };   // 0, 중간앞, 중간뒤, 끝
                        rectWithShadowBlend.Factors = new float[] { 0f, .6f, .99f, 1f };   // 끝 점의 섞이는 비율
                        break;
                    case BevelStyle.Raised:
                        rectWithShadowBlend.Positions = new float[] { 0f, .45f, .51f, 1f };   // 0, 중간앞, 중간뒤, 끝
                        rectWithShadowBlend.Factors = new float[] { 0f, 0f, .2f, 1f };   // 끝 점의 섞이는 비율
                        break;
                    case BevelStyle.Flat:
                        rectWithShadowBlend.Positions = new float[] { 0f, .45f, .51f, 1f };   // 0, 중간앞, 중간뒤, 끝
                        rectWithShadowBlend.Factors = new float[] { 0f, 0f, .2f, .9f };   // 끝 점의 섞이는 비율
                        break;
                    case BevelStyle.Neon:
                    case BevelStyle.GradientNeon:
                        rectWithShadowBlend.Positions = new float[] { 0.0f, .2f, .4f, .6f, .8f, 1.0f };
                        rectWithShadowBlend.Factors = new float[] { 0f, .2f, .4f, .6f, .8f, 1f };   // 끝 점의 섞이는 비율
                        break;
                }
            }

            return rectWithShadowBlend;

            // 아래처럼 LinearGradientBrush에 .Blend속성에 저장후, 그 브러시로 그리면 됨.
            //    rectBrushWithEdge.Blend = rectWithShadowBlend;
        }
        #endregion 네온 버튼의 그림자를 번지게 그리는 혼합 비율을 설정하는 메서드




        #region 종류별로 버튼을 그리는 메서드. (그림자를 그리고 이 메서드가 호출됨.)
        // mStartEdgeColor -> mEndEdgeColor 바깥쪽 사각형(모서리 포함)을 그림
        // mStartColor -> mEndColor         안쪽 사각형(모서리 제외)를 그림
        // 낮게 패인 버튼을 그림
        private void DrawLoweredPn(Graphics g, Rectangle bevelRect)
        {
            float darknessBegin = mStartColor.GetSaturation();   // 채도를 반환 (채도의 0%는 무채색) HSV모델의 반지름에 해당.
            float darknessEnd = mEndColor.GetSaturation();       // 채도를 반환 (채도의 0%는 무채색) (채도 는 무채색을 섞는 비율에 따라 달라짐)
            // 더 탁한색을 선택(더 어두운)
            Color mainColor = darknessEnd <= darknessBegin ? mEndColor : mStartColor; // 더 탁한 색(어두운?)으로 메인 색을 설정.(채도가 더 낮은 색으로)(채도가 낮으면 무채색)

            // 버튼의 그라데이션 색과 반대로 더 어둡고, 더 밝게 해서, 모서리의 그라데이션 색을 설정
            mStartEdgeColor = ControlPaint.Dark(mainColor);    // 버튼의 시작색과 끝색중 어두운 색을 더 어둡게해서, 모서리 그라데이션 시작색으로 설정
            mEndEdgeColor = ControlPaint.Light(mainColor);     // 버튼의 시작색과 끝색중 어두운 색을 더 밝게 해서, 모서리 그라데이션의 끝색으로 설정

            // 바깥쪽 사각형(모서리 포함)을 칠함
            FillRectangleWithEdges(g, ref bevelRect);
            bevelRect.Inflate(-mEdgeWidth, -mEdgeWidth);    // 양 끝의 모서리 너비만큼 좌, 우를 축소
            Rectangle rectWithoutBevel = bevelRect;                  // bevelRect를 그냥 사용해도 되지만, 코드를 이해하기 쉽도록 이름을 바꿈
            // 안쪽 사각형을 그림
            FillRectangleWithoutEdges(g, rectWithoutBevel);
        }

        // 솟은 버튼을 그림
        private void DrawRaisedPn(Graphics g, Rectangle bevelRect)
        {
            // 필요하지는 않지만, 원본에 있던 내용이라 남겨 둠.
            //float darknessBegin = mStartColor.GetSaturation();
            //float darknessEnd = mEndColor.GetSaturation();
            //// 더 선명한(밝은?) 색을 선택
            //Color mainColor = darknessEnd >= darknessBegin ? mEndColor : mStartColor;

            // 시작색을 더 밝게, 끝 색을 더 어둡게 해서, 모서리의 그라데이션 색에 설정
            mStartEdgeColor = ControlPaint.Light(mStartColor);
            mEndEdgeColor = ControlPaint.Dark(mEndColor);

            // 모서리를 포함한 뒷 사각형을 그리고,
            FillRectangleWithEdges(g, ref bevelRect);
            bevelRect.Inflate(-mEdgeWidth, -mEdgeWidth);
            Rectangle rectWithoutBevel = bevelRect;
            FillRectangleWithoutEdges(g, rectWithoutBevel);
            // 모서리를 뺀 안쪽 사각형을 그림
        }

        // Flat스타일을 그릴 때 사용
        private void DrawFlatPn(Graphics g, Rectangle bevelRect)
        {
            // 바깥쪽 사각형을 먼저 그리고,
            using (Brush bevelGradientBrush = new SolidBrush(mFlatBorderColor))
            {
                RoundedRectangle.FillRoundedRectangleAntiAlias(g, bevelGradientBrush, bevelRect, mRectRadius);
            }
            // bevel(모서리) 부분을 제외.(안쪽 사각형 영역이 됨)
            bevelRect.Inflate(-mEdgeWidth, -mEdgeWidth);
            Rectangle rectWithoutBevel = bevelRect;
            // 안쪽 사각형을 다시 그림. // bevelRect로 해도 되지만, 코드를 읽기 쉽게 하기 위해 이름을 topRect로 바꿈.
            using (Brush topGradientBrush = new LinearGradientBrush(rectWithoutBevel, mStartColor, mEndColor, (LinearGradientMode)this.BackgroundGradientMode))
            {
                RoundedRectangle.FillRoundedRectangleAntiAlias(g, topGradientBrush, rectWithoutBevel, mRectRadius);
            }
        }

        // 그림자를 그린 후, 네온 버튼을 그릴 때, (Flat과 그리는 게 거의 비슷)
        private void DrawNeonPn(Graphics g, Rectangle bevelRect)
        {
            //// 바깥쪽 사각형을 먼저 그리고, (단색 브러시)
            //using (Brush bevelSolidBrush = new SolidBrush(mFlatBorderColor))
            //    RoundedRectangle.FillRoundedRectangleAntiAlias(g, bevelSolidBrush, bevelRect, mRectRadius);  // FillPath로 색칠
            // bevel(모서리) 부분을 제외.(안쪽 사각형 영역이 됨)

            // 네온 버튼의 경우, 어차피 확대해서 그리므로, 모서리 부분을 그리진 않음.
            bevelRect.Inflate(mEdgeWidth, mEdgeWidth);



            Rectangle rectWithoutBevel = bevelRect;
            Color startColor = isLeftMouseButtonDown ? ControlPaint.Light(ControlPaint.LightLight(mStartColor)) : isMouseHover ? ControlPaint.Light(mStartColor) : mStartColor;
            // 그라데이션 네온일 경우만, 그라데이션으로 네온 색을 표시
            Color endColor = Style == BevelStyle.GradientNeon ? mEndColor : isLeftMouseButtonDown ? ControlPaint.Light(ControlPaint.LightLight(mStartColor)) : isMouseHover ? ControlPaint.Light(mStartColor) : mEndColor;
            // 안쪽 사각형을 다시 그림. (그라데이션 브러시)
            // bevelRect로 해도 되지만, 코드를 읽기 쉽게 하기 위해 이름을 topRect로 바꿈.
            using (LinearGradientBrush topGradientBrush = new LinearGradientBrush(rectWithoutBevel, startColor, endColor, (LinearGradientMode)this.BackgroundGradientMode))
                RoundedRectangle.FillRoundedRectangleAntiAlias(g, topGradientBrush, rectWithoutBevel, mRectRadius);   // FillPath로 색칠
        }

        #endregion 종류별로 버튼을 그리는 메서드. (그림자를 그리고 이 메서드가 호출됨). 끝.



        #region 모서리 그리는 메서드(그림자 그리고 바로 다음에 그림. 네온 버튼에선 안 쓰임)
        protected virtual void FillRectangleWithEdges(Graphics g, ref Rectangle rectWithEdge)
        {
            Rectangle lgbRect = rectWithEdge;
            lgbRect.Inflate(1, 1);  // LinearGradientBrush 생성에 쓰일 lgbRect의 크기를 좌,우로 1씩 확대

            // Blend생성
            Blend rectWithEdgeBlend = new Blend();
            if (mRectRadius >= 150)  // 모서리의 반경이 아주 크면, 좀 더 세분해서 그라데이션
            {
                rectWithEdgeBlend.Positions = new float[] { 0.0f, .2f, .4f, .6f, .8f, 1.0f };
                rectWithEdgeBlend.Factors = new float[] { 0f, 0f, .2f, .4f, 1f, 1f };   // 끝 점의 섞이는 비율
            }
            else
            {
                switch (Style)
                {
                    case BevelStyle.Lowered:
                        rectWithEdgeBlend.Positions = new float[] { 0f, .49f, .52f, 1f };   // 0, 중간앞, 중간뒤, 끝
                        rectWithEdgeBlend.Factors = new float[] { 0f, .6f, .99f, 1f };   // 끝 점의 섞이는 비율
                        break;
                    case BevelStyle.Raised:
                        rectWithEdgeBlend.Positions = new float[] { 0f, .45f, .51f, 1f };   // 0, 중간앞, 중간뒤, 끝
                        rectWithEdgeBlend.Factors = new float[] { 0f, 0f, .2f, 1f };   // 끝 점의 섞이는 비율
                        break;
                }
            }

            // 그라데이션 설정한 브러시 생성
            using (LinearGradientBrush rectBrushWithEdge = new LinearGradientBrush(lgbRect, mStartEdgeColor, mEndEdgeColor, LinearGradientMode.ForwardDiagonal))
            {
                // 브러시에 혼합 지점과 비율을 설정
                rectBrushWithEdge.Blend = rectWithEdgeBlend;
                RoundedRectangle.FillRoundedRectangleAntiAlias(g, rectBrushWithEdge, rectWithEdge, mRectRadius);    // 모서리가 포함된 사각 영역을 동그랗게 그림
            }
        }
        #endregion 모서리 그리는 메서드(그림자 그리고 바로 다음에 그림. 네온 버튼에선 안 쓰임)

        #region 실제 버튼을 그리는 메서드. (모서리 그린 다음 호출)
        protected virtual void FillRectangleWithoutEdges(Graphics g, Rectangle rectWithoutEdge)
        {
            using (Brush rectBrushWithoutEdge = new LinearGradientBrush(rectWithoutEdge, mStartColor, mEndColor, (LinearGradientMode)this.BackgroundGradientMode))
            {
                RoundedRectangle.FillRoundedRectangleAntiAlias(g, rectBrushWithoutEdge, rectWithoutEdge, mRectRadius);
            }
        }
        #endregion 실제 버튼을 그리는 메서드. (모서리 그린 다음 호출)



        ~ShadowPanel()
        {
            this.Dispose();
        }




    }

}
