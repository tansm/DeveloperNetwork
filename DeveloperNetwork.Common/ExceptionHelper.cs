using System;

namespace DeveloperNetwork.Common {
    internal static class ExceptionHelper {

        public static void ThrowArgumentNullException(string paramName) {
            throw new ArgumentNullException(paramName);
        }

        public static void ThrowArgumentOutOfRangeException(string paramName) {
            throw new ArgumentOutOfRangeException(paramName);
        }
    }
}
