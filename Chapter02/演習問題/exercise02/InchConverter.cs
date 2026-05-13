using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise02 {
    public static class InchConverter {
        public static readonly double ratio = 0.0254;

        //メートルからインチに変換
        public static double ToInch(double meter) {
            return meter / ratio;
        }

        //インチからメートルに換算
        public static double ToMeter(double inch) {
            return inch * ratio;
        }
    }
}
