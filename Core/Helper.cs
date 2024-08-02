using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace N_Health_API.Core
{
    public class Helper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
