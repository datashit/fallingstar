#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("igkHCDiKCQIKigkJCKjvBSthPlSIONtKXcHlTmkDlUbPIFJmP3zySPTORKebgcKJMr2cKm9fkMrY4MwNe4fgE0thdBqQ0GTD7BxlOu8Ls9bj6JZuzfnbXkk66hjrsUNkBFKxiik7jdhgWePttjLPQvlTj7kPGZuN2u94MCBKBz5zEkQrZ+ONp3EGB7nRqBP9FRZsJO2OoyKDnkIZBGr5H1f9ZLoxmQkhvc6ndHtmu4XgqfoaHFxcpLrYPXkmFHYodbk8syZDOglIh8zcbQsqtYscBJiatBeFijL+Z1hw6UfcoZER6iNcZSb5rMW1WvnBaOfIfjqCv/V1pH9nDXMp2OhMmh44igkqOAUOASKOQI7/BQkJCQ0IC9jgEOTG338tbwoLCQgJ");
        private static int[] order = new int[] { 1,6,4,10,7,13,7,13,11,12,11,12,12,13,14 };
        private static int key = 8;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
