using System.Runtime.InteropServices;

/// <summary>
/// Holds Keyboard class which wraps calls to the user32.dll keybd_event method
/// </summary>
namespace KeyboardWrapper
{
    /// <summary>
    /// This class wraps calls to the user32.dll keybd_event method
    /// </summary>
    public class Keyboard
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        /// <summary>
        /// Key down flag
        /// </summary>
        private const int KEY_DOWN_EVENT = 0x0001;
        /// <summary>
        /// Key up flag
        /// </summary>
        private const int KEY_UP_EVENT = 0x0002;
        /// <summary>
        /// ms to wait between keystrokes when holding a key down
        /// </summary>
        private const int PauseBetweenStrokes = 50;

        /// <summary>
        /// Will hold a key down for a number of milliseconds
        /// </summary>
        /// <param name="key">byte value for key. can cast like this: (byte)System.Windows.Forms.Keys.F24</param>
        /// <param name="duration">ms to hold key down for</param>
        /// <example>
        /// <code>
        /// Keyboard.KeyUp((byte)Keys.F24,5000);
        /// </code>
        /// </example>
        public static void HoldKey(byte key, int duration)
        {
            int totalDuration = 0;
            while (totalDuration < duration)
            {
                keybd_event(key, 0, KEY_DOWN_EVENT, 0);
                keybd_event(key, 0, KEY_UP_EVENT, 0);
                System.Threading.Thread.Sleep(PauseBetweenStrokes);
                totalDuration += PauseBetweenStrokes;
            }
        }
        /// <summary>
        /// Will press a key
        /// </summary>
        /// <param name="key">byte value for key. can cast like this: (byte)System.Windows.Forms.Keys.F24</param>
        /// <example>
        /// <code>
        /// Keyboard.PressKey((byte)Keys.F24);
        /// </code>
        /// </example>
        public static void PressKey(byte key)
        {
            keybd_event(key, 0, KEY_DOWN_EVENT, 0);
            keybd_event(key, 0, KEY_UP_EVENT, 0);
        }
        /// <summary>
        /// Will trigger the KeyUp event for a key. Easy way to keep the computer awake without sending any input.
        /// </summary>
        /// <param name="key">byte value for key. can cast like this: (byte)System.Windows.Forms.Keys.F24</param>
        /// <example>
        /// <code>
        /// Keyboard.KeyUp((byte)Keys.F24);
        /// </code>
        /// </example>
        public static void KeyUp(byte key)
        {
            keybd_event(key, 0, KEY_UP_EVENT, 0);
        }

    }
}
