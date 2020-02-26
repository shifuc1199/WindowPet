using System.Runtime.InteropServices;
using System;
using UnityEngine;
public struct MARGINS
{
    public int cxLeftWidth;
    public int cxRightWidth;
    public int cyTopHeight;
    public int cyBottomHeight;
}
public struct RECT
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}
public struct POINT
{
    public int X;
    public int Y;

    public POINT(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

public class WindowContainer : MonoBehaviour
{
    public static WindowContainer Instance;
    // Use this for initialization
    [SerializeField]
    private Material m_Material;
    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);
    [DllImport("user32.dll")]
    static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);
    [DllImport("user32.dll")]
    static   extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int Width, int Height, uint flags);
    [DllImport("user32.dll")]
      static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    static extern bool GetCursorPos(ref POINT lpPoint);
    // Definitions of window styles
    const int GWL_STYLE = -16;
    const int GWL_EXSTYLE = -20;
    const uint WS_POPUP = 0x80000000;
    const uint WS_VISIBLE = 0x10000000;
    const uint WS_EX_TRANSPARENT = 0x00000020;
    const uint WS_EX_LAYERED = 0x00080000;
    const int WS_EX_TOOLWINDOW = 0x00000080;
    public IntPtr window_handler;
    private IntPtr HWND_TOP_MOST = new IntPtr(-1);
    public const int width = 1920;
    public const int height = 1080;

    bool isInRole = false;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SetWindowScreen();
        var margins = new MARGINS() { cxLeftWidth = -1 };
        window_handler = FindWindow(null, UnityEngine.Application.productName);
        SetWindowLong(window_handler, GWL_STYLE, WS_POPUP | WS_VISIBLE);
        SetWindowLong(window_handler, GWL_EXSTYLE, WS_EX_LAYERED|WS_EX_TOOLWINDOW| WS_EX_TRANSPARENT);
        DwmExtendFrameIntoClientArea(window_handler, ref margins);
        SetWindowPos(window_handler, HWND_TOP_MOST, 0, 0, 0, 0, 1|2);
    }

    void SetWindowScreen()
    {
        Screen.SetResolution(width, height, true);
    }

    void OnRenderImage(RenderTexture from, RenderTexture to)
    {
        Graphics.Blit(from, to, m_Material);
    }

    Vector2 WindowPositionToUnity()
    {
        POINT p = new POINT();
        GetCursorPos(ref p);
        return new Vector2(p.X,height-p.Y);
    }
    
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(WindowPositionToUnity());
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,10000))
        {
            if (!isInRole)
            {
                isInRole = true;
                SetWindowLong(window_handler, GWL_EXSTYLE, WS_EX_LAYERED| WS_EX_TOOLWINDOW);
            }
        }
        else
        {
            if (isInRole)
            {
                isInRole = false;
                SetWindowLong(window_handler, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED| WS_EX_TOOLWINDOW);
            }
        }
    }
}
