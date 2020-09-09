using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MS.Interop.WinUser {
    public enum WindowMessage {
        WM_NULL = 0,
        WM_CREATE = 1,
        WM_DESTROY = 2,
        WM_MOVE = 3,
        WM_SIZE = 5,
        WM_ACTIVATE = 6,
        WM_SETFOCUS = 7,
        WM_KILLFOCUS = 8,
        WM_ENABLE = 10,
        WM_SETREDRAW = 11,
        WM_SETTEXT = 12,
        WM_GETTEXT = 13,
        WM_GETTEXTLENGTH = 14,
        WM_PAINT = 15,
        WM_CLOSE = 16,
        WM_QUERYENDSESSION = 17,
        WM_QUIT = 18,
        WM_QUERYOPEN = 19,
        WM_ERASEBKGND = 20,
        WM_SYSCOLORCHANGE = 21,
        WM_ENDSESSION = 22,
        WM_SHOWWINDOW = 24,
        WM_CTLCOLOR = 25,
        WM_WININICHANGE = 26,
        WM_SETTINGCHANGE = 26,
        WM_DEVMODECHANGE = 27,
        WM_ACTIVATEAPP = 28,
        WM_FONTCHANGE = 29,
        WM_TIMECHANGE = 30,
        WM_CANCELMODE = 31,
        WM_SETCURSOR = 32,
        WM_TABLET_MAXOFFSET = 32,
        WM_MOUSEACTIVATE = 33,
        WM_CHILDACTIVATE = 34,
        WM_QUEUESYNC = 35,
        WM_GETMINMAXINFO = 36,
        WM_PAINTICON = 38,
        WM_ICONERASEBKGND = 39,
        WM_NEXTDLGCTL = 40,
        WM_SPOOLERSTATUS = 42,
        WM_DRAWITEM = 43,
        WM_MEASUREITEM = 44,
        WM_DELETEITEM = 45,
        WM_VKEYTOITEM = 46,
        WM_CHARTOITEM = 47,
        WM_SETFONT = 48,
        WM_GETFONT = 49,
        WM_SETHOTKEY = 50,
        WM_GETHOTKEY = 51,
        WM_QUERYDRAGICON = 55,
        WM_COMPAREITEM = 57,
        WM_GETOBJECT = 61,
        WM_COMPACTING = 65,
        WM_COMMNOTIFY = 68,
        WM_WINDOWPOSCHANGING = 70,
        WM_WINDOWPOSCHANGED = 71,
        WM_POWER = 72,
        WM_COPYDATA = 74,
        WM_CANCELJOURNAL = 75,
        WM_NOTIFY = 78,
        WM_INPUTLANGCHANGEREQUEST = 80,
        WM_INPUTLANGCHANGE = 81,
        WM_TCARD = 82,
        WM_HELP = 83,
        WM_USERCHANGED = 84,
        WM_NOTIFYFORMAT = 85,
        WM_CONTEXTMENU = 123,
        WM_STYLECHANGING = 124,
        WM_STYLECHANGED = 125,
        WM_DISPLAYCHANGE = 126,
        WM_GETICON = 127,
        WM_SETICON = 128,
        WM_NCCREATE = 129,
        WM_NCDESTROY = 130,
        WM_NCCALCSIZE = 131,
        WM_NCHITTEST = 132,
        WM_NCPAINT = 133,
        WM_NCACTIVATE = 134,
        WM_GETDLGCODE = 135,
        WM_SYNCPAINT = 136,
        WM_MOUSEQUERY = 155,
        WM_NCMOUSEMOVE = 160,
        WM_NCLBUTTONDOWN = 161,
        WM_NCLBUTTONUP = 162,
        WM_NCLBUTTONDBLCLK = 163,
        WM_NCRBUTTONDOWN = 164,
        WM_NCRBUTTONUP = 165,
        WM_NCRBUTTONDBLCLK = 166,
        WM_NCMBUTTONDOWN = 167,
        WM_NCMBUTTONUP = 168,
        WM_NCMBUTTONDBLCLK = 169,
        WM_NCXBUTTONDOWN = 171,
        WM_NCXBUTTONUP = 172,
        WM_NCXBUTTONDBLCLK = 173,
        WM_INPUT = 255,
        WM_KEYFIRST = 256,
        WM_KEYDOWN = 256,
        WM_KEYUP = 257,
        WM_CHAR = 258,
        WM_DEADCHAR = 259,
        WM_SYSKEYDOWN = 260,
        WM_SYSKEYUP = 261,
        WM_SYSCHAR = 262,
        WM_SYSDEADCHAR = 263,
        WM_KEYLAST = 264,
        WM_IME_STARTCOMPOSITION = 269,
        WM_IME_ENDCOMPOSITION = 270,
        WM_IME_COMPOSITION = 271,
        WM_IME_KEYLAST = 271,
        WM_INITDIALOG = 272,
        WM_COMMAND = 273,
        WM_SYSCOMMAND = 274,
        WM_TIMER = 275,
        WM_HSCROLL = 276,
        WM_VSCROLL = 277,
        WM_INITMENU = 278,
        WM_INITMENUPOPUP = 279,
        WM_MENUSELECT = 287,
        WM_MENUCHAR = 288,
        WM_ENTERIDLE = 289,
        WM_UNINITMENUPOPUP = 293,
        WM_CHANGEUISTATE = 295,
        WM_UPDATEUISTATE = 296,
        WM_QUERYUISTATE = 297,
        WM_CTLCOLORMSGBOX = 306,
        WM_CTLCOLOREDIT = 307,
        WM_CTLCOLORLISTBOX = 308,
        WM_CTLCOLORBTN = 309,
        WM_CTLCOLORDLG = 310,
        WM_CTLCOLORSCROLLBAR = 311,
        WM_CTLCOLORSTATIC = 312,
        WM_MOUSEMOVE = 512,
        WM_MOUSEFIRST = 512,
        WM_LBUTTONDOWN = 513,
        WM_LBUTTONUP = 514,
        WM_LBUTTONDBLCLK = 515,
        WM_RBUTTONDOWN = 516,
        WM_RBUTTONUP = 517,
        WM_RBUTTONDBLCLK = 518,
        WM_MBUTTONDOWN = 519,
        WM_MBUTTONUP = 520,
        WM_MBUTTONDBLCLK = 521,
        WM_MOUSEWHEEL = 522,
        WM_XBUTTONDOWN = 523,
        WM_XBUTTONUP = 524,
        WM_XBUTTONDBLCLK = 525,
        WM_MOUSEHWHEEL = 526,
        WM_MOUSELAST = 526,
        WM_PARENTNOTIFY = 528,
        WM_ENTERMENULOOP = 529,
        WM_EXITMENULOOP = 530,
        WM_NEXTMENU = 531,
        WM_SIZING = 532,
        WM_CAPTURECHANGED = 533,
        WM_MOVING = 534,
        WM_POWERBROADCAST = 536,
        WM_DEVICECHANGE = 537,
        WM_MDICREATE = 544,
        WM_MDIDESTROY = 545,
        WM_MDIACTIVATE = 546,
        WM_MDIRESTORE = 547,
        WM_MDINEXT = 548,
        WM_MDIMAXIMIZE = 549,
        WM_MDITILE = 550,
        WM_MDICASCADE = 551,
        WM_MDIICONARRANGE = 552,
        WM_MDIGETACTIVE = 553,
        WM_MDISETMENU = 560,
        WM_ENTERSIZEMOVE = 561,
        WM_EXITSIZEMOVE = 562,
        WM_DROPFILES = 563,
        WM_MDIREFRESHMENU = 564,
        WM_IME_SETCONTEXT = 641,
        WM_IME_NOTIFY = 642,
        WM_IME_CONTROL = 643,
        WM_IME_COMPOSITIONFULL = 644,
        WM_IME_SELECT = 645,
        WM_IME_CHAR = 646,
        WM_IME_REQUEST = 648,
        WM_IME_KEYDOWN = 656,
        WM_IME_KEYUP = 657,
        WM_MOUSEHOVER = 673,
        WM_NCMOUSELEAVE = 674,
        WM_MOUSELEAVE = 675,
        WM_WTSSESSION_CHANGE = 689,
        WM_TABLET_DEFBASE = 704,
        WM_TABLET_ADDED = 712,
        WM_TABLET_DELETED = 713,
        WM_TABLET_FLICK = 715,
        WM_TABLET_QUERYSYSTEMGESTURESTATUS = 716,
        WM_CUT = 768,
        WM_COPY = 769,
        WM_PASTE = 770,
        WM_CLEAR = 771,
        WM_UNDO = 772,
        WM_RENDERFORMAT = 773,
        WM_RENDERALLFORMATS = 774,
        WM_DESTROYCLIPBOARD = 775,
        WM_DRAWCLIPBOARD = 776,
        WM_PAINTCLIPBOARD = 777,
        WM_VSCROLLCLIPBOARD = 778,
        WM_SIZECLIPBOARD = 779,
        WM_ASKCBFORMATNAME = 780,
        WM_CHANGECBCHAIN = 781,
        WM_HSCROLLCLIPBOARD = 782,
        WM_QUERYNEWPALETTE = 783,
        WM_PALETTEISCHANGING = 784,
        WM_PALETTECHANGED = 785,
        WM_HOTKEY = 786,
        WM_PRINT = 791,
        WM_PRINTCLIENT = 792,
        WM_APPCOMMAND = 793,
        WM_THEMECHANGED = 794,
        WM_DWMCOMPOSITIONCHANGED = 798,
        WM_DWMNCRENDERINGCHANGED = 799,
        WM_DWMCOLORIZATIONCOLORCHANGED = 800,
        WM_DWMWINDOWMAXIMIZEDCHANGE = 801,
        WM_DWMSENDICONICTHUMBNAIL = 803,
        WM_DWMSENDICONICLIVEPREVIEWBITMAP = 806,
        WM_HANDHELDFIRST = 856,
        WM_HANDHELDLAST = 863,
        WM_AFXFIRST = 864,
        WM_AFXLAST = 895,
        WM_PENWINFIRST = 896,
        WM_PENWINLAST = 911,
        WM_USER = 1024,
        WM_APP = 32768
    }

    public enum GetWindow_Cmd : uint {
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_OWNER = 4,
        GW_CHILD = 5,
        GW_ENABLEDPOPUP = 6
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT {
        public int x;
        public int y;
    }

    public static class WinUser {
        #region constantes

        public const int DWM_TNP_VISIBLE = 0x8;
        public const int DWM_TNP_OPACITY = 0x4;
        public const int DWM_TNP_RECTDESTINATION = 0x1;

        public const int CCHILDREN_TITLEBAR = 5;

        //Constantes para ShowWindow  
        public const int SW_HIDE = 0;
        public const int SW_NORMAL = 1;

        //Mover el ratón.
        public const uint MOUSEEVENTF_MOVE = 0x0001;
        //Presión del botón izquierdo del ratón.
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        //Levantar el botón izquierdo del ratón.
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;
        //Presión del botón derecho del ratón.
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //Levantar el botón derecho del ratón.
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        //Indicar que las coordenadas indicadas son absolutas. En caso de no incluir este valor, los valores X e Y se sumarán a la posición actual del ratón.
        public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_RESTORE = 0xF120;
        public const int SC_DEFAULT = 0xF160;
        public const int SC_SCREENSAVE = 0xF140;

        public const uint CW_USEDEFAULT = 0x80000000;
        public const uint WS_BORDER = 0x800000;
        public const uint WS_CAPTION = 0xc00000;
        public const uint WS_CHILD = 0x40000000;
        public const uint WS_CHILDWINDOW = 0x40000000;
        public const uint WS_CLIPCHILDREN = 0x2000000;
        public const uint WS_CLIPSIBLINGS = 0x4000000;
        public const uint WS_DISABLED = 0x8000000;
        public const uint WS_DLGFRAME = 0x400000; //cambia controlbox
        public const uint WS_GROUP = 0x20000;
        public const uint WS_HSCROLL = 0x100000;
        public const uint WS_ICONIC = 0x20000000;
        public const uint WS_MAXIMIZE = 0x1000000;
        public const uint WS_MAXIMIZEBOX = 0x10000;
        public const uint WS_MINIMIZE = 0x20000000;
        public const uint WS_MINIMIZEBOX = 0x20000;
        public const uint WS_OVERLAPPED = 0;
        public const uint WS_OVERLAPPEDWINDOW = 0xcf0000;
        public const uint WS_POPUP = 0x80000000;
        public const uint WS_POPUPWINDOW = 0x80880000;
        public const uint WS_SIZEBOX = 0x40000;
        public const uint WS_SYSMENU = 0x80000;
        public const uint WS_TABSTOP = 0x10000;
        public const uint WS_THICKFRAME = 0x40000;
        public const uint WS_TILED = 0;
        public const uint WS_TILEDWINDOW = 0xcf0000;
        public const uint WS_VISIBLE = 0x10000000;
        public const uint WS_VSCROLL = 0x200000;

        public const int WS_EX_ACCEPTFILES = 16;
        public const int WS_EX_APPWINDOW = 0x40000;
        public const int WS_EX_CLIENTEDGE = 512;
        public const int WS_EX_COMPOSITED = 0x2000000; /* XP */
        public const int WS_EX_CONTEXTHELP = 0x400;
        public const int WS_EX_CONTROLPARENT = 0x10000;
        public const int WS_EX_DLGMODALFRAME = 1;
        public const int WS_EX_LAYERED = 0x80000;   /* w2k */
        public const int WS_EX_LAYOUTRTL = 0x400000; /* w98, w2k */
        public const int WS_EX_LEFT = 0;
        public const int WS_EX_LEFTSCROLLBAR = 0x4000;
        public const int WS_EX_LTRREADING = 0;
        public const int WS_EX_MDICHILD = 64;
        public const int WS_EX_NOACTIVATE = 0x8000000; /* w2k */
        public const int WS_EX_NOINHERITLAYOUT = 0x100000; /* w2k */
        public const int WS_EX_NOPARENTNOTIFY = 4;
        public const int WS_EX_OVERLAPPEDWINDOW = 0x300;
        public const int WS_EX_PALETTEWINDOW = 0x188;
        public const int WS_EX_RIGHT = 0x1000;
        public const int WS_EX_RIGHTSCROLLBAR = 0;
        public const int WS_EX_RTLREADING = 0x2000;
        public const int WS_EX_STATICEDGE = 0x20000;
        public const int WS_EX_TOOLWINDOW = 128;
        public const int WS_EX_TOPMOST = 8;
        public const int WS_EX_TRANSPARENT = 32;
        public const int WS_EX_WINDOWEDGE = 256;

        public const int GWL_EXSTYLE = -20;
        public const int GWL_STYLE = -16;

        public const int LWA_COLORKEY = 0x01;
        public const int LWA_ALPHA = 0x02;
        public const int ULW_COLORKEY = 0x01;
        public const int ULW_ALPHA = 0x02;
        public const int ULW_OPAQUE = 0x04;
        #endregion

        #region Structurs
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect {
            internal Rect(int left, int top, int right, int bottom) {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TITLEBARINFO {
            public TITLEBARINFO(uint cbSize, Rect rcTitleBar, uint[] rgstate) {
                CBSize = cbSize;
                RCTitleBar = rcTitleBar;
                RGState = new uint[CCHILDREN_TITLEBAR + 1];
                RGState = rgstate;
            }
            public TITLEBARINFO(bool bd) {
                CBSize = 0;
                RCTitleBar = new Rect();
                RGState = new uint[CCHILDREN_TITLEBAR + 1];
            }
            public uint CBSize;
            public Rect RCTitleBar;
            public uint[] RGState;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_THUMBNAIL_PROPERTIES {
            public int dwFlags;
            public Rect rcDestination;
            public Rect rcSource;
            public byte opacity;
            public bool fVisible;
            public bool fSourceClientAreaOnly;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PSIZE {
            public int x;
            public int y;
        }

        #endregion

        #region ApiFunctions
        [DllImport("user32.DLL", EntryPoint = "SendMessage", SetLastError = true)]
        public extern static int SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)] //
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [DllImport("user32")]
        public static extern bool GetMessage(ref int lpMsg, IntPtr handle, uint mMsgFilterInMain, uint mMsgFilterMax);

        [DllImport("user32.dll")]
        public static extern bool GetTitleBarInfo(IntPtr hwnd, out TITLEBARINFO pti);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("Kernel32", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
        public static extern Int32 GetCurrentWin32ThreadId();

        //Oculta y muestra una ventana a partir de su HWND  
        [DllImport("user32")]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32")]
        public static extern bool DestroyWindow(IntPtr hwnd);

        [DllImport("user32")]
        public static extern bool CloseWindow(IntPtr hwnd);

        [DllImport("user32")]
        public static extern bool CloseWindowStation(IntPtr hwnd);

        [DllImport("user32")]
        public static extern bool ShowWindowAsync(IntPtr hwnd, int nCmdShow);

        [DllImport("user32")]
        public static extern void GetWindowRect(IntPtr hwnd, out Rect lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool SetCursorPos(uint x, uint y);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern long SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

        [DllImport("user32")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        // Determina mediante el handle si una ventana está visible  
        [DllImport("user32")]
        public static extern bool IsWindowVisible(IntPtr hwnd);

        [DllImport("user32")]
        public static extern bool IsWindowEnabled(IntPtr hwnd);

        // Determina mediante el handle si es un ventana  
        [DllImport("user32")]
        public static extern bool IsWindow(IntPtr hwnd);

        //recupera un handle de ventana 
        [DllImport("user32")]
        public static extern IntPtr GetWindow(IntPtr hwnd, GetWindow_Cmd wCmd);

        [DllImport("user32")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32")]
        public static extern IntPtr GetParent(IntPtr hWndChild);

        [DllImport("user32")]
        public static extern IntPtr GetAncestor(IntPtr hWndChild, uint gaFlags);

        [DllImport("user32.dll")]
        public extern static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(POINT p);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder title, int size);

        [DllImport("user32.dll")]
        public static extern int SetWindowText(IntPtr hwnd, StringBuilder title, int size);

        //Activa y desactive ventanas  
        [DllImport("user32")]
        public static extern void EnableWindow(IntPtr hwnd, bool fEnable);

        //Recupera el nombre de clase de ventana a partir de su handle
        [DllImport("user32")]
        public static extern void GetClassName(IntPtr hwnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("dwmapi.dll")]
        public static extern int DwmRegisterThumbnail(IntPtr dest, IntPtr src, out IntPtr thumb);

        [DllImport("dwmapi.dll")]
        public static extern int DwmUnregisterThumbnail(IntPtr thumb);

        [DllImport("dwmapi.dll")]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr thumb, out PSIZE size);

        [DllImport("dwmapi.dll")]
        public static extern int DwmUpdateThumbnailProperties(IntPtr hThumb, ref DWM_THUMBNAIL_PROPERTIES props);

        [DllImport("user32")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);
        #endregion

        public enum WindowStyle {
            WS_EX_ACCEPTFILES = 16,
            WS_EX_APPWINDOW = 0x40000,
            WS_EX_CLIENTEDGE = 512,
            WS_EX_COMPOSITED = 0x2000000,
            WS_EX_CONTEXTHELP = 0x400,
            WS_EX_CONTROLPARENT = 0x10000,
            WS_EX_DLGMODALFRAME = 1,
            WS_EX_LAYERED = 0x80000,
            WS_EX_LAYOUTRTL = 0x400000,
            WS_EX_LEFT = 0,
            WS_EX_LEFTSCROLLBAR = 0x4000,
            WS_EX_LTRREADING = 0,
            WS_EX_MDICHILD = 64,
            WS_EX_NOACTIVATE = 0x8000000,
            WS_EX_NOINHERITLAYOUT = 0x100000,
            WS_EX_NOPARENTNOTIFY = 4,
            WS_EX_OVERLAPPEDWINDOW = 0x300,
            WS_EX_PALETTEWINDOW = 0x188,
            WS_EX_RIGHT = 0x1000,
            WS_EX_RIGHTSCROLLBAR = 0,
            WS_EX_RTLREADING = 0x2000,
            WS_EX_STATICEDGE = 0x20000,
            WS_EX_TOOLWINDOW = 128,
            WS_EX_TOPMOST = 8,
            WS_EX_TRANSPARENT = 32,
            WS_EX_WINDOWEDGE = 256,
        }

        public enum ActionsWindow {
            Close = 0xF060,
            Minimize = 0xF020,
            Maximize = 0xF030,
            Restore = 0xF120,
            Default = 0xF160
        }

        public static bool GetWindowStyle(IntPtr handle, int Exstyle, WindowStyle style) {
            switch (style) {
                case WindowStyle.WS_EX_APPWINDOW:
                    return (GetWindowLong(handle, Exstyle) & 0x300) != 0;
                case WindowStyle.WS_EX_TOOLWINDOW:
                    return (GetWindowLong(handle, Exstyle) & 0x300) != 0;
                default: return false;
            }
        }

        public static void PerformClick(uint x, uint y) {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN, x, y, 0, UIntPtr.Zero);
            Thread.Sleep(200);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP, x, y, 0, UIntPtr.Zero);
        }

        public static void SendKey(IntPtr handle, string keys) {
            foreach (var i in keys)
                SendMessage(handle, 0x0102, i, 0);
        }

        public static void KeyDown(IntPtr handle, int key) {
            WinUser.SendMessage(handle, 0x0100, key, 0);
        }

        public static bool IsMaximize(IntPtr hwnd) {
            if ((WinUser.GetWindowLong(hwnd, WinUser.GWL_STYLE) & WinUser.WS_MAXIMIZE) != 0)
                return true;
            return false;
        }

        public static bool IsMinimize(IntPtr hwnd) {
            if ((WinUser.GetWindowLong(hwnd, WinUser.GWL_STYLE) & WinUser.WS_MINIMIZE) != 0)
                return true;
            return false;
        }

        public static void ActionWindow(IntPtr hwnd, ActionsWindow act) {
            EnableWindow(hwnd, true);
            switch (act) {
                case ActionsWindow.Close: SendMessage(hwnd, WM_SYSCOMMAND, SC_CLOSE, 0); break;
                case ActionsWindow.Minimize: SendMessage(hwnd, WM_SYSCOMMAND, SC_MINIMIZE, 0); break;
                case ActionsWindow.Maximize: SendMessage(hwnd, WM_SYSCOMMAND, SC_MAXIMIZE, 0); break;
                case ActionsWindow.Default: SendMessage(hwnd, WM_SYSCOMMAND, SC_DEFAULT, 0); break;
                case ActionsWindow.Restore: SendMessage(hwnd, WM_SYSCOMMAND, SC_RESTORE, 0); break;
            }
        }
    }

    public class Win32APITools {
        /// <summary>Almacena el ID de proceso y el handler de una ventana</summary> 
        private class AuxInfo {
            public int processID;
            public IntPtr handler;
        }

        /// <summary>
        /// Delegado para hacer de callback
        /// </summary>
        /// <param name="hwnd" />handler de la ventana
        /// <param name="lParam" />paramétro con la informacion necesaria para el proceso
        /// <returns>Valor de retorno del proceso</returns>
        private delegate bool ChildWindows(IntPtr hwnd, AuxInfo lParam);

        /// <summary>
        /// Recorre las ventanas y ejecuta un proceso para cada una de ellas
        /// </summary>
        /// <param name="lpEnumFunc" />Delegado con el proceso a utilizar para cada ventana
        /// <param name="lParam" />paramétro con la informacion necesaria para el proceso
        /// <returns>Retorna true si se recorren todas las ventanas, de lo contrario false o segun determine el usuario a trabes del callback</returns>
        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, ChildWindows lpEnumFunc, AuxInfo lParam);

        /// <summary>
        /// Devuelve el ID del proceso al que pertenece el hilo de la ventana
        /// </summary>
        /// <param name="hwnd" />handler de la ventana
        /// <param name="lpdwProcessId" />ID del proceso (parámetro de salida)
        /// <returns>ID del Thread que creó la ventana</returns>
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, out int lpdwProcessId);

        /// <summary>
        /// Indica si una ventana es o no visible
        /// </summary>
        /// <param name="hWnd" />handler de la ventana
        /// <returns>Indicador de si la v entana es o no visible</returns>
        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// Obtiene el handler de la ventana asociada a un proceso
        /// Este procedimiento es solo de utileria para usarse con EnumWindows 
        /// y no deberia ser invocado directamente
        /// </summary>
        /// <param name="hwnd" />handler de la ventana actual
        /// <param name="info" />informacion auxiliar para el proceso
        /// <returns>false si encuentra la ventana, true sino</returns>
        private static bool _GetProcessWindowHandler(IntPtr hwnd, AuxInfo info) {
            int processID;
            GetWindowThreadProcessId(hwnd, out processID);

            if (processID == info.processID) {
                info.handler = hwnd;
                return false;
            } else {
                info.handler = IntPtr.Zero;
                return true;
            }
        }

        /// <summary>
        /// Devuelve el handler de la ventana asociada al proceso
        /// </summary>
        /// <param name="pid" />Id del proceso
        /// <returns>handler de la ventana</returns>
        public static IntPtr GetProcessWindowHandler(IntPtr hWndParent, int pid) {
            //Delegado con el proceso auxiliar de búsqueda
            ChildWindows getHandlerVentana = new ChildWindows(_GetProcessWindowHandler);
            //Informacion auxiliar
            AuxInfo informacion = new AuxInfo();
            informacion.processID = pid;

            /*Repetir bucle hasta que este presente la ventana del proceso
             *(puede que la enumeracion se realice y windows  aún no haya creado 
             *la primera ventana del proceso o bien no la haya hecho visible, 
             *por lo cual se debe repetir el bucle hasta encontrala)*/
            do {
                /*Enumerar las ventanas buscando la que coincida con
                 *el id de proceso contenido en informacion */
                EnumChildWindows(hWndParent, getHandlerVentana, informacion);
            } while (informacion.handler == IntPtr.Zero || !IsWindowVisible(informacion.handler));

            return informacion.handler;
        }
    }
    public class WindowHandleInfo {
        private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

        private IntPtr _MainHandle;

        public WindowHandleInfo(IntPtr handle) {
            this._MainHandle = handle;
        }

        public List<IntPtr> GetAllChildHandles() {
            List<IntPtr> childHandles = new List<IntPtr>();

            GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
            IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

            try {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(this._MainHandle, childProc, pointerChildHandlesList);
            } finally {
                gcChildhandlesList.Free();
            }

            return childHandles;
        }

        private bool EnumWindow(IntPtr hWnd, IntPtr lParam) {
            GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

            if (gcChildhandlesList == null || gcChildhandlesList.Target == null) {
                return false;
            }

            List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
            //if (childHandles != null) {
            childHandles.Add(hWnd);
            return true;
            //}

            //return false;
        }
    }
}