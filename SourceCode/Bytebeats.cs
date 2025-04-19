using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static Vanara.PInvoke.WinMm;


namespace Galaxy
{
    public class Bytebeats
    {
        static SafeHWAVEOUT hWaveOut;
        public static void Bytebeat1()
        {
            while (true)
            {
                Random r = new Random();
                Console.Beep(r.Next(100, 300), 100);
                Console.Beep(r.Next(37, 200), 100);
            }
        }
        public static void Bytebeat2()
        {
            WAVEFORMATEX wfx = new WAVEFORMATEX();
            const int hz = 44100;
            wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
            wfx.nSamplesPerSec = hz;
            wfx.nAvgBytesPerSec = hz;
            wfx.wBitsPerSample = 8;
            wfx.nBlockAlign = 1;
            wfx.nChannels = 1;
            wfx.cbSize = 0;
            const uint MAPPER = 0xFFFFFFFF;
            waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);
            byte[] sbuffer = new byte[16000 * 1600];
            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)(t*(42&t/ 40) >> 10);
            }
            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);
            WAVEHDR header = new WAVEHDR();
            header.lpData = handle.AddrOfPinnedObject();
            header.dwBufferLength = (uint)sbuffer.Length;
            header.dwFlags = 0;
            header.dwLoops = 0;
            
            waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadAbortException)
            {
                waveOutReset(hWaveOut);
                waveOutClose(hWaveOut);
                handle.Free();
            }
        }
        public static void Bytebeat3()
        {
            WAVEFORMATEX wfx = new WAVEFORMATEX();
            const int hz = 44100;
            wfx.wFormatTag = WAVE_FORMAT.WAVE_FORMAT_PCM;
            wfx.nSamplesPerSec = hz;
            wfx.nAvgBytesPerSec = hz;
            wfx.wBitsPerSample = 8;
            wfx.nBlockAlign = 1;
            wfx.nChannels = 1;
            wfx.cbSize = 0;
            const uint MAPPER = 0xFFFFFFFF;
            waveOutOpen(out hWaveOut, MAPPER, in wfx, IntPtr.Zero, IntPtr.Zero, WAVE_OPEN.CALLBACK_NULL);
            byte[] sbuffer = new byte[16000 * 160];
            for (uint t = 0; t < sbuffer.Length; t++)
            {
                sbuffer[t] = (byte)((t ^ t >> 10) * t >> 16);
            }
            GCHandle handle = GCHandle.Alloc(sbuffer, GCHandleType.Pinned);
            WAVEHDR header = new WAVEHDR();
            header.lpData = handle.AddrOfPinnedObject();
            header.dwBufferLength = (uint)sbuffer.Length;
            header.dwFlags = 0;
            header.dwLoops = 0;

            waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadAbortException)
            {
                waveOutReset(hWaveOut);
                waveOutClose(hWaveOut);
                handle.Free();
            }
        }
    }
}
