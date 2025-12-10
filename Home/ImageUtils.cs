using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace ChattingAppTeam6.Home.Utils
{
    // 이미지 관련 유틸 모음
    public static class ImageUtils
    {
        public static Image BytesToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                using (var temp = Image.FromStream(ms))
                {
                    return new Bitmap(temp);
                }
            }
        }


        /*
        // 이름을 기반으로 간단한 이니셜 아바타(동그란 프로필 이미지) 만들어 준다고 함
        // 솔직히 저도 잘 몰라요 기본 이미지 하나 만들어서 이미지 잘 되나 보려고 넣은거라
        // 그냥없애도되는부분이기도함
        public static Image CreateInitialsAvatar(string name)
        {
            int w = 64, h = 64;

            // 64x64 비트맵 하나 만들고 거기다가 그림
            var bmp = new Bitmap(w, h);

            using (var g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // 배경색 (파란 톤)
                g.Clear(Color.FromArgb(0x6C, 0x8A, 0xE4));

                // 기본 이니셜은 ? 로 시작
                string initials = "?";

                // 이름이 있으면 앞 글자들로 이니셜 생성
                if (!string.IsNullOrWhiteSpace(name))
                {
                    // 공백 기준으로 쪼갬: "Hong Gil Dong" → ["Hong", "Gil", "Dong"]
                    var parts = name
                        .Trim()
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 2)
                    {
                        // 단어가 두 개 이상이면 앞 두 글자 사용 (예: "Hong Gil" → "HG")
                        initials = (parts[0][0].ToString() + parts[1][0].ToString())
                            .ToUpperInvariant();
                    }
                    else
                    {
                        // 단어 하나면 첫 글자 하나만 (예: "Hong" → "H")
                        initials = parts[0][0].ToString().ToUpperInvariant();
                    }
                }

                // 글꼴/브러시 설정 (흰색 볼드 글씨)
                using (var font = new Font("Segoe UI", 20, FontStyle.Bold, GraphicsUnit.Pixel))
                using (var brush = new SolidBrush(Color.White))
                {
                    // 텍스트 크기 구해서 중앙 정렬되도록 위치 계산
                    var size = g.MeasureString(initials, font);
                    float x = (w - size.Width) / 2;
                    float y = (h - size.Height) / 2;

                    g.DrawString(initials, font, brush, x, y);

                    // 바깥쪽 흰색 동그라미 테두리
                    using (var pen = new Pen(Color.White, 2))
                    {
                        g.DrawEllipse(pen, 1, 1, w - 3, h - 3);
                    }
                }
            }

            // Bitmap 자체를 반환 (호출 쪽에서 dispose 해주면 됨)
            return bmp;
        }
        */

        
    }
}