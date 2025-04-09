using System;

namespace UCDCourseEditor.Utils;

public static class ConfigPaths
{
    // use %appdata%/UCDCourseEditor/ for user-specific settings

    private static string AppDataPath;

    static ConfigPaths()
    {
        AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/UCDCourseEditor/";
        EnsureConfigFileExists();
    }

    public static string ConfigPath => AppDataPath + "config.json";
    public static string DatabasePath => AppDataPath + "database.db";
    public static string LogPath => AppDataPath + "logs/";
    public static string TempPath => AppDataPath + "temp/";
    public static string SettingsPath => AppDataPath + "settings.json";

    public static void EnsureConfigFileExists()
    {
        if (!System.IO.Directory.Exists(AppDataPath))
        {
            System.IO.Directory.CreateDirectory(AppDataPath);
        }

        if (!System.IO.File.Exists(ConfigPath))
        {
            System.IO.File.Create(ConfigPath).Dispose();
        }

        if (!System.IO.Directory.Exists(LogPath))
        {
            System.IO.Directory.CreateDirectory(LogPath);
        }

        if (!System.IO.Directory.Exists(TempPath))
        {
            System.IO.Directory.CreateDirectory(TempPath);
        }
        
        if (!System.IO.File.Exists(SettingsPath))
        {
            System.IO.File.Create(SettingsPath).Dispose();
        }
        
        if (!System.IO.File.Exists(DatabasePath))
        {
            System.IO.File.Create(DatabasePath).Dispose();
        }
        
        
    }
}