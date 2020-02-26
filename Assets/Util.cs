using System;
using System.IO;
using IWshRuntimeLibrary;
public class Util    
{
    public static bool SetupStartup(string short_name)
    {
        var start_up_dir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        var target_pth = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        return  CreateShortcut(start_up_dir, short_name, target_pth);
    }

    public static void CancelStartup(string short_name)
    {
        if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + short_name))
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + short_name);
    }

 
    private static bool CreateShortcut(string direstory, string shortcurName, string targetPath, string description = null, string iconLocation = null)
    {
        try
        {
            if (!Directory.Exists(direstory))
            {
                Directory.CreateDirectory(direstory);
            }
            // 添加引用com中搜索Windows Script Host Object Model, 如果在unity中使用则需下载 Interop.IWshRuntimeLibrary.dll 并放到代码同一文件夹
            string shortscurPath = Path.Combine(direstory, string.Format("{0}", shortcurName)); 
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortscurPath); // 创建快捷方式对象
            shortcut.TargetPath = targetPath; // 指定目标路径
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath); //设置起始位置
            shortcut.WindowStyle = 1; // 设置运行方式，默认为常规窗口
            shortcut.Description = description; // 设置备注
            shortcut.IconLocation = string.IsNullOrEmpty(iconLocation) ? targetPath : iconLocation; //设置图标路径
            shortcut.Save(); // 保存快捷方式
            return true;
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log(e.StackTrace);
        }
        return false;
    }
}
