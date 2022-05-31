using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CustomControls_dll
{
    #region enum, interface 정의
    public enum BevelStyle  // 경사면 스타일
    {
        Lowered,    // 안으로 패인 버튼 스타일
        Raised,     // 위로 솟은 버튼 스타일
        Flat,        // 얇은 테두리
        Neon,
        GradientNeon,
    }

    public enum ShadowMode  // 그림자 방향
    {
        ForwardDiagonal = 0,    // 오른쪽 아래 그림자
        Surrounded = 1,         // 둘러싼 그림자
        Dropped = 2             // 아래방향 그림자

    }

    public enum PanelGradientMode
    {
        BackwardDiagonal = 3,           // 오른쪽 위에서 왼쪽 아래로
        ForwardDiagonal = 2,            // 왼쪽 위에서 오른쪽 아래로
        Horizontal = 0,                 // 가로 방향 (그라데이션을 왼쪽에서 오른족으로)
        Vertical = 1                    // 세로 방향 (그라데이션을 위에서 아래로)
    }

    // 네온 버튼은 EdgeWidth를 -5로 하는 게 좋음. 그럼 버튼의 크기가 커짐. 아니면, ShadowShift만큼 크기를 줄이는 메서드 부분에, 5만큼 키우면 될 듯.



    public interface IShadowBtn
    {
        // [Browsable(true), Category("Category Name"), Description("Property Description")]
        PanelGradientMode BackgroundGradientMode { get; set; }      //"배경 그라데이션 타입(대각선, 가로방향,세로방향)   "
        int RectRadius { get; set; }                                //"모서리의 둥근 반지름                              "
        Color StartColor { get; set; }                              //"그라데이션 시작 색                                "
        Color EndColor { get; set; }                                //"그라데이션 끝 색                                  "
        BevelStyle Style { get; set; }                              //"버튼 모서리(경사면) 스타일 (함몰, 솟음, 평평)     "
        int EdgeWidth { get; set; }                                 //"모서리의 너비                                     "
        Color FlatBorderColor { get; set; }                         //"Flat일 경우, 테두리 색                            "
        ShadowMode ShadowStyle { get; set; }                        //"그림자 스타일 (대각, 둘러싼, 아래)                "
        int ShadowShift { get; set; }                               //"그림자 평행이동 거리                              "
        Color ShadowColor { get; set; }                             //"그림자 색                                         "

    }
    #endregion enum, interface 정의 끝
    class Global
    {
    }
}
