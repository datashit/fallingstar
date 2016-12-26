#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("urHPN5SgggcQY7NBsugaPV0L6NODtiFpeRNeZypLHXI+utT+KF9e4EUFBf3jgWQgf00vcSzgZep/GmNQcGLUgTkAurTva5YboArW4FZAwtQOpD3jaMBQeOSX/i0iP+LcufCjQxHelYU0UnPs0kVdwcPtTtzTa6c+rZcd/sLYm9Br5MVzNgbJk4G5lVSI8UqkTE81fbTX+nvaxxtAXTOgRtNQXlFh01BbU9NQUFHxtlxyOGcNASmwHoX4yEizegU8f6D1nOwDoJgxvpEnY9vmrCz9Jj5UKnCBsRXDR2HTUHNhXFdYe9cZ16ZcUFBQVFFS0WGCEwSYvBcwWswflnkLP2YlqxEi3rlKEjgtQ8mJPZq1RTxjtlLqj4G5Sb2fhiZ0NlNSUFFQ");
        private static int[] order = new int[] { 7,2,12,13,11,8,11,8,12,9,13,12,12,13,14 };
        private static int key = 81;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
