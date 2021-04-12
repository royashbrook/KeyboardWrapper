# README.md

KeyboardWrapper is a small class to wrap the user32.dll calls required to sendkeys to the keyboard.

This will act like you pressed a key, but does not target active windows. This should also simulate a keypress, not just sending keys to an application like SendKeys does.

This wrapper is windows only as it uses user32.dll.