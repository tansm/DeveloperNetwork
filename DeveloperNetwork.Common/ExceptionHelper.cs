using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperNetwork.Common {
    internal static class ExceptionHelper {

        public static void ThrowArgumentNullException(string paramName) {
            throw new ArgumentNullException(paramName);
        }
    }
}
