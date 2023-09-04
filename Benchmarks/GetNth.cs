using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarks
{
    //9/1/2023 7:44:43 PM|VNCLogViewer|100|Verbose|D:\VNCLogViewer.exe|30988||31536|crhodes|App.Application_Startup||Enter
    
    public class GetNth
    {
        public int GetNthIndex(string s, char c, int n)
        {
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }
            return -1;
            // = s.TakeWhile(c => n -= (c == t ? 1 : 0)) > 0).Count();
        }

        public int GetNthIndex2(string s, char c, int n)
        {
            var idx = s.IndexOf(c, 0);

            while (idx >= 0 && --n > 0)
            {
                idx = s.IndexOf(c, idx + 1);
            }

            return idx;
        }

        public int GetNthIndex3(ReadOnlySpan<char> sSpan, char c, int n)
        {
            var idx = sSpan.IndexOf(c);
 
            while (idx >= 0 && --n > 0)
            {
                idx++;  // Go past c
                ReadOnlySpan<char> remainingSpan = sSpan.Slice(idx, sSpan.Length - idx);

                idx += remainingSpan.IndexOf(c);
            }

            return idx;
        }

        public int GetNthIndex4(ReadOnlySpan<char> sSpan, char c, int n)
        {
            ReadOnlySpan<char> remainingSpan = new ReadOnlySpan<char>();

            var idx = sSpan.IndexOf(c);

            while (idx >= 0 && --n > 0)
            {
                idx++;  // Go past c
                remainingSpan = sSpan.Slice(idx, sSpan.Length - idx);

                idx += remainingSpan.IndexOf(c);
            }

            return idx;
        }
    }
}