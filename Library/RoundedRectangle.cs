using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls_dll
{
    class RoundedRectangle
    {
        // 모서리가 둥근 사각형을 rect와 radius에 맞게 그리고,
        // 아래로 쳐지는 그림자 스타일의 경우, 아래 가운데 부분을 5% 들어올리는 베지에 곡선을 추가해서 GraphicsPath개체를 반환.
        // 그림자나 버튼을 그릴 때 사용
        public static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius, bool dropStyle = false)
        {
            int x = rect.X;
            int y = rect.Y;
            int width = rect.Width;
            int height = rect.Height;

            int xPlusWidth = x + width;
            int yPlusHeight = y + height;
            int yPlusHeightMinusRadius = yPlusHeight - radius;
            int yPlusRadius = y + radius;
            int doubleRadius = radius * 2;

            int xPlusWidthMinusRadius = xPlusWidth - radius;
            int xPlusWidthMinusDoubleRadius = xPlusWidth - doubleRadius;
            int yPlusHeightMinusDoubleRadius = yPlusHeight - doubleRadius;
            int xPlusRadius = x + radius;

            int xPlusHalfWidth = x + width / 2;
            int yPlus95PercentHeight = yPlusHeight - height / 20;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();

            // 왼쪽위 호
            if (doubleRadius > 0)       // .AddArc의 rect는 시작 지점이 180도로 회전한 지점이고, 끝 지점이 90도로 회전을 마친 지점이다.
            {
                path.AddArc(x, y, doubleRadius, doubleRadius, 180, 90);     // doubleRadius, doubleRadius영역에 호(원)를 그림
                path.AddArc(xPlusWidthMinusDoubleRadius, y, doubleRadius, doubleRadius, 270, 90);
                path.AddArc(xPlusWidthMinusDoubleRadius, yPlusHeightMinusDoubleRadius, doubleRadius, doubleRadius, 0, 90);
            }
            else
            // radius가 0이면, x,y에서 x+width,y로 선을 긋는다. 아니면, x+r, y에서 x+width -r, y까지 선을 긋는다. 사실 패스에선 자동이지만 호를 그리지 않는 경우가 있으므로,
            {
                path.AddLine(x, y, xPlusWidth, y);                      // radius가 0이면, 그냥 사각형이 그려짐.
                path.AddLine(xPlusWidth, y, xPlusWidth, yPlusHeight);
            }

            // 아래로 쳐지는 그림자 스타일일 경우
            if (dropStyle)
                path.AddBezier(
                    new Point(xPlusWidthMinusRadius, yPlusHeight),      // 오른쪽 코너(곡선일 경우 곡선 그리고 나서)부터 시작함.
                    new Point(xPlusHalfWidth, yPlus95PercentHeight),    // 약간 위로 패이게 그림자가 생김.(아래의 왼쪽, 오른쪽이 튀어나오게 됨.(그냥 그림자 스타일인듯?)
                    new Point(xPlusHalfWidth, yPlus95PercentHeight),    // 약간 위로 패이게 그림자가 생김.(아래의 왼쪽, 오른쪽이 튀어나오게 됨.(그냥 그림자 스타일인듯?)
                    new Point(xPlusRadius, yPlusHeight));               // 왼쪽 코너를 그리기 위해, (Radius가 0이면 왼쪽 아래 지점)
            else // 아래로 쳐지는 그림자 스타일이 아닌 경우(ForwardDiagonal이나 Surrounding의 경우)
                path.AddLine(xPlusWidthMinusRadius, yPlusHeight, xPlusRadius, yPlusHeight);     // 왼쪽 아래 코너 그리기 전까지 선으로 연결.(Radius가 0이면 왼쪽 아래 지점)

            if (doubleRadius > 0)    // 모서리의 반경 Radius를 지정했을 경우,
                path.AddArc(x, yPlusHeightMinusDoubleRadius, doubleRadius, doubleRadius, 90, 90);   // 왼쪽 위,너비,높이 지정 후, 호를 그림

            // 왼쪽 아래 끝 점과 시작점을 이어 줌.
            path.CloseFigure();
            return path;
        }

        // .FillPath로 칠하는데, AntiAlias를 설정해서 칠하고, 다시 설정을 원래대로 돌려 놓음.
        public static void FillRoundedRectangleAntiAlias(Graphics g, Brush rectBrush, Rectangle rect, int radius)
        {
            // 둥근 사각형 path를 얻어, AntiAlias로 칠하고, Graphics개체의 AntiAlias 설정을 원래대로 돌려 놓는다.
            GraphicsPath path = GetRoundedRectanglePath(rect, radius);
            SmoothingMode savedMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(rectBrush, path);
            g.SmoothingMode = savedMode;
        }

        // 패스 개체의 윤곽선을 그리는 메서드
        public static void DrawRoundedRectangleAntiAlias(Graphics g, Pen pen, Rectangle rect, int radius)
        {
            GraphicsPath path = GetRoundedRectanglePath(rect, radius);
            SmoothingMode savedMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawPath(pen, path);
            g.SmoothingMode = savedMode;
        }

    }
}
